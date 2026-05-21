using MIConvexHull;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Engine3D_2._0
{
    public class Polyhedron : ICustomTypeDescriptor
    {
        [Category("Geral")]
        [DisplayName("Nome")]
        public string Name { get; set; } = "Poliedro";

        [Category("Geral")]
        [DisplayName("Visibilidade")]
        public bool Visible { get; set; } = true;

        [Category("Transformação")]
        [DisplayName("Posição")]
        public Vector3 Position { get; set; } = new Vector3(0, 0, 0);

        [Category("Transformação")]
        [DisplayName("Rotação X")]
        public float RotationX { get; set; } = 0f; // em graus

        [Category("Transformação")]
        [DisplayName("Rotação Y")]
        public float RotationY { get; set; } = 0f; // em graus

        [Category("Transformação")]
        [DisplayName("Rotação Z")]
        public float RotationZ { get; set; } = 0f; // em graus

        [Category("Transformação")]
        [DisplayName("Escala")]
        public float Scale { get; set; } = 1f;

        [Browsable(false)] // não queremos mostrar a lista crua
        public List<Vector3> Vertices { get; set; }

        [Browsable(false)] // idem para as arestas
        public List<(int, int)> Edges { get; set; }

        public Polyhedron(List<Vector3> vertices, List<(int, int)> edges)
        {
            Vertices = vertices;
            Edges = edges;
            RecalculateFaces();
        }

        // faces serão feitas usando o MIConvexHull, implemetação está fora de escopo
        [Browsable(false)]
        public List<List<Vector3>> Faces { get; set; } = new List<List<Vector3>>();
        public class Face
        {
            public int[] Indices { get; set; }   // índices dos vértices que formam a face
            public Vector3 Normal { get; set; }  // normal da face
        }

        public void RemoveVertexAndReconnect3D(int index)
        {
            if (index < 0 || index >= Vertices.Count) return;

            Vector3 removedVertex = Vertices[index];

            // 1. Pega os vizinhos
            var neighbors = Edges
                .Where(e => e.Item1 == index || e.Item2 == index)
                .Select(e => e.Item1 == index ? e.Item2 : e.Item1)
                .ToList();

            if (neighbors.Count < 3)
            {
                // se tiver menos de 3 vizinhos, só remove
                Vertices.RemoveAt(index);
                Edges.RemoveAll(e => e.Item1 == index || e.Item2 == index);
                for (int i = 0; i < Edges.Count; i++)
                {
                    var (a, b) = Edges[i];
                    if (a > index) a--;
                    if (b > index) b--;
                    Edges[i] = (a, b);
                }
                return;
            }

            // 2. Calcula centroide
            Vector3 centroid = new Vector3(0, 0, 0);
            foreach (var n in neighbors)
                centroid += Vertices[n];
            centroid /= neighbors.Count;

            // 3. Calcula normal aproximada da face
            Vector3 normal = new Vector3(0, 0, 0);
            for (int i = 0; i < neighbors.Count; i++)
            {
                Vector3 a = Vertices[neighbors[i]] - centroid;
                Vector3 b = Vertices[neighbors[(i + 1) % neighbors.Count]] - centroid;
                normal += Vector3.Cross(a, b);
            }
            normal = normal.Normalize();

            // 4. Cria base local (e1, e2) para projetar vizinhos no plano da face
            Vector3 e1 = (Vertices[neighbors[0]] - centroid).Normalize();
            Vector3 e2 = Vector3.Cross(normal, e1).Normalize();

            // 5. Calcula ângulo de cada vizinho em relação ao centroide
            var neighborAngles = new List<(int idx, double angle)>();
            foreach (var n in neighbors)
            {
                Vector3 v = Vertices[n] - centroid;
                double x = Vector3.Dot(v, e1);
                double y = Vector3.Dot(v, e2);
                double angle = Math.Atan2(y, x);
                neighborAngles.Add((n, angle));
            }

            // 6. Ordena por ângulo
            neighborAngles.Sort((a, b) => a.angle.CompareTo(b.angle));

            // 7. Remove vértice e arestas conectadas
            Vertices.RemoveAt(index);
            Edges.RemoveAll(e => e.Item1 == index || e.Item2 == index);

            // 8. Ajusta índices das arestas restantes
            for (int i = 0; i < Edges.Count; i++)
            {
                var (a, b) = Edges[i];
                if (a > index) a--;
                if (b > index) b--;
                Edges[i] = (a, b);
            }

            // 9. Reconecta vizinhos ordenados
            int count = neighborAngles.Count;
            for (int i = 0; i < count; i++)
            {
                int a = neighborAngles[i].idx > index ? neighborAngles[i].idx - 1 : neighborAngles[i].idx;
                int b = neighborAngles[(i + 1) % count].idx > index ? neighborAngles[(i + 1) % count].idx - 1 : neighborAngles[(i + 1) % count].idx;
                if (!Edges.Contains((a, b)) && !Edges.Contains((b, a)))
                    Edges.Add((a, b));
            }
        }

        public void RecalculateFaces()
        {
            // Converte vértices atuais para Vertex3D (usado pelo MIConvexHull)
            var hullVertices = Vertices
                .Select(v => new Vertex3D(new Vector3(v.X, v.Y, v.Z)))
                .ToList();

            // Calcula o Convex Hull
            var hull = ConvexHull.Create<Vertex3D, DefaultConvexFace<Vertex3D>>(hullVertices);

            // Atualiza lista de faces
            Faces.Clear();
            foreach (var face in hull.Result.Faces)
            {
                List<Vector3> faceVerts = new List<Vector3>();
                foreach (var v in face.Vertices)
                {
                    faceVerts.Add(v.ToVector3());
                }
                Faces.Add(faceVerts);
            }

            // Atualiza lista de arestas a partir das faces
            Edges.Clear();
            foreach (var face in Faces)
            {
                for (int i = 0; i < face.Count; i++)
                {
                    // encontra índices dos vértices na lista original
                    int a = Vertices.FindIndex(v => v.X == face[i].X && v.Y == face[i].Y && v.Z == face[i].Z);
                    int b = Vertices.FindIndex(v => v.X == face[(i + 1) % face.Count].X &&
                                                    v.Y == face[(i + 1) % face.Count].Y &&
                                                    v.Z == face[(i + 1) % face.Count].Z);

                    if (a >= 0 && b >= 0)
                    {
                        var edge = (Math.Min(a, b), Math.Max(a, b));
                        if (!Edges.Contains(edge))
                            Edges.Add(edge);
                    }
                }
            }
        }

        // --- ICustomTypeDescriptor ---
        public PropertyDescriptorCollection GetProperties()
        {
            var props = new List<PropertyDescriptor>();

            // pega as propriedades normais (Name, Position, RotationY)
            props.AddRange(TypeDescriptor.GetProperties(this, true)
                                         .Cast<PropertyDescriptor>()
                                         .Where(p => p.IsBrowsable));

            // adiciona os vértices dinamicamente
            for (int i = 0; i < Vertices.Count; i++)
            {
                props.Add(new VertexPropertyDescriptor(this, i));
            }

            return new PropertyDescriptorCollection(props.ToArray());
        }

        // delega os outros métodos
        public AttributeCollection GetAttributes() => TypeDescriptor.GetAttributes(this, true);
        public string GetClassName() => TypeDescriptor.GetClassName(this, true);
        public string GetComponentName() => TypeDescriptor.GetComponentName(this, true);
        public TypeConverter GetConverter() => TypeDescriptor.GetConverter(this, true);
        public EventDescriptor GetDefaultEvent() => TypeDescriptor.GetDefaultEvent(this, true);
        public PropertyDescriptor GetDefaultProperty() => TypeDescriptor.GetDefaultProperty(this, true);
        public object GetEditor(Type editorBaseType) => TypeDescriptor.GetEditor(this, editorBaseType, true);
        public EventDescriptorCollection GetEvents(Attribute[] attributes) => TypeDescriptor.GetEvents(this, attributes, true);
        public EventDescriptorCollection GetEvents() => TypeDescriptor.GetEvents(this, true);
        public object GetPropertyOwner(PropertyDescriptor pd) => this;
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes) => GetProperties();
    }
}
