using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MIConvexHull;

namespace Engine3D_2._0
{
    // implementação de MIConvexHull
    public static class PolyhedronUtils
    {
        public static void RecalculateEdgesUsingConvexHull(Polyhedron poly)
        {
            if (poly == null) throw new ArgumentNullException(nameof(poly));
            if (poly.Vertices == null || poly.Vertices.Count < 4) return; // precisa de pelo menos 4 pontos não coplanares

            // 1) cria a lista de Vertex3D na mesma ordem de poly.Vertices
            var inputVertices = poly.Vertices.Select(v => new Vertex3D(v)).ToList();

            // 2) cria o convex hull (sobrecarga genérica)
            var hullObj = ConvexHull.Create<Vertex3D, DefaultConvexFace<Vertex3D>>(inputVertices);

            // 3) tenta extrair as faces de forma robusta (direct -> Result.Faces -> reflexão)
            IEnumerable<DefaultConvexFace<Vertex3D>> faces = null;

            // 3.a) se o objeto tiver propriedade "Faces" diretamente
            var hullType = hullObj.GetType();
            var facesProp = hullType.GetProperty("Faces", BindingFlags.Public | BindingFlags.Instance);
            if (facesProp != null)
            {
                faces = facesProp.GetValue(hullObj) as IEnumerable<DefaultConvexFace<Vertex3D>>;
            }

            // 3.b) se não, tenta acessar "Result" e então "Faces"
            if (faces == null)
            {
                var resultProp = hullType.GetProperty("Result", BindingFlags.Public | BindingFlags.Instance);
                if (resultProp != null)
                {
                    var resultVal = resultProp.GetValue(hullObj);
                    if (resultVal != null)
                    {
                        var facesProp2 = resultVal.GetType().GetProperty("Faces", BindingFlags.Public | BindingFlags.Instance);
                        if (facesProp2 != null)
                        {
                            faces = facesProp2.GetValue(resultVal) as IEnumerable<DefaultConvexFace<Vertex3D>>;
                        }
                    }
                }
            }

            // 3.c) último recurso: reflexão mais agressiva (lança se falhar)
            if (faces == null)
            {
                throw new InvalidOperationException("Não foi possível obter as faces do convex hull. Versão da MIConvexHull incompatível.");
            }

            // 4) mapa de Vertex3D -> índice (mesma ordem de poly.Vertices)
            var indexMap = new Dictionary<Vertex3D, int>();
            for (int i = 0; i < inputVertices.Count; i++)
                indexMap[inputVertices[i]] = i;

            // 5) construir conjunto de arestas únicas a partir das faces triangulares
            var edgeSet = new HashSet<(int, int)>();
            foreach (var f in faces)
            {
                var verts = f.Vertices.Cast<Vertex3D>().ToArray();
                for (int i = 0; i < verts.Length; i++)
                {
                    var va = verts[i];
                    var vb = verts[(i + 1) % verts.Length];

                    if (!indexMap.TryGetValue(va, out int a) || !indexMap.TryGetValue(vb, out int b))
                        continue; // proteção caso algo não bata (não deveria acontecer)

                    var ordered = a < b ? (a, b) : (b, a);
                    edgeSet.Add(ordered);
                }
            }

            // 6) substitui as arestas do poliedro
            poly.Edges = edgeSet.ToList();
        }
    }
}
