using System;
using System.Collections.Generic;

namespace Engine3D_2._0
{
    internal class PolyFactory
    {
        public static Polyhedron CreateCube(float size = 1f)
        {
            float s = size / 2f;

            var vertices = new List<Vector3>
            {
                new Vector3(-s, -s, -s),
                new Vector3(-s, -s,  s),
                new Vector3(-s,  s, -s),
                new Vector3(-s,  s,  s),
                new Vector3( s, -s, -s),
                new Vector3( s, -s,  s),
                new Vector3( s,  s, -s),
                new Vector3( s,  s,  s)
            };

            var edges = new List<(int, int)>
            {
                (0,1),(1,3),(3,2),(2,0),
                (4,5),(5,7),(7,6),(6,4),
                (0,4),(1,5),(2,6),(3,7)
            };

            return new Polyhedron(vertices, edges);
        }

        public static Polyhedron CreatePyramid(int baseSides, float radius = 3f, float height = 5f)
        {
            if (baseSides < 3) baseSides = 3; // mínimo 3 lados

            var vertices = new List<Vector3>();

            // base no plano XZ
            for (int i = 0; i < baseSides; i++)
            {
                float angle = i * 2 * (float)Math.PI / baseSides;
                vertices.Add(new Vector3(radius * (float)Math.Cos(angle), 0, radius * (float)Math.Sin(angle)));
            }

            // topo
            vertices.Add(new Vector3(0, height, 0));

            var edges = new List<(int, int)>();

            // base
            for (int i = 0; i < baseSides; i++)
                edges.Add((i, (i + 1) % baseSides));

            // laterais
            for (int i = 0; i < baseSides; i++)
                edges.Add((i, baseSides)); // topo é o último vértice

            return new Polyhedron(vertices, edges);
        }

        public static Polyhedron CreateDodecahedron(float size = 1f)
        {
            float phi = (1 + (float)Math.Sqrt(5)) / 2f;
            float invPhi = 1f / phi;

            var vertices = new List<Vector3>();

            // (±1, ±1, ±1)
            foreach (var x in new[] { -1f, 1f })
                foreach (var y in new[] { -1f, 1f })
                    foreach (var z in new[] { -1f, 1f })
                        vertices.Add(new Vector3(x, y, z));

            // (0, ±1/φ, ±φ)
            foreach (var y in new[] { -invPhi, invPhi })
                foreach (var z in new[] { -phi, phi })
                    vertices.Add(new Vector3(0, y, z));

            // (±1/φ, ±φ, 0)
            foreach (var x in new[] { -invPhi, invPhi })
                foreach (var y in new[] { -phi, phi })
                    vertices.Add(new Vector3(x, y, 0));

            // (±φ, 0, ±1/φ)
            foreach (var x in new[] { -phi, phi })
                foreach (var z in new[] { -invPhi, invPhi })
                    vertices.Add(new Vector3(x, 0, z));

            // Escala pelo "size"
            for (int i = 0; i < vertices.Count; i++)
                vertices[i] *= (size / 2f);

            // Lista de arestas (30 no total)
            var edges = new List<(int, int)>
            {
                (0,8),  (0,12), (0,16),
                (1,9),  (1,12), (1,17),
                (2,10), (2,13), (2,16),
                (3,11), (3,13), (3,17),
                (4,8),  (4,14), (4,18),
                (5,9),  (5,14), (5,19),
                (6,10), (6,15), (6,18),
                (7,11), (7,15), (7,19),
                (8,10), (9,11),
                (12,14),(13,15),
                (16,17),(18,19)
            };

            return new Polyhedron(vertices, edges);
        }

        public static Polyhedron CreateIcosahedron(float size = 1f)
        {
            float phi = (1 + (float)Math.Sqrt(5)) / 2f;

            var vertices = new List<Vector3>();

            // Vértices (0, ±1, ±φ), (±1, ±φ, 0), (±φ, 0, ±1)
            foreach (var a in new[] { -1f, 1f })
            {
                foreach (var b in new[] { -phi, phi })
                {
                    vertices.Add(new Vector3(0, a, b)); // (0, ±1, ±φ)
                    vertices.Add(new Vector3(a, b, 0)); // (±1, ±φ, 0)
                    vertices.Add(new Vector3(b, 0, a)); // (±φ, 0, ±1)
                }
            }

            // Escala pelo "size"
            for (int i = 0; i < vertices.Count; i++)
                vertices[i] *= (size / 2f);

            // Lista de arestas (30 no total)
            // Índices baseados na ordem acima, conectando vértices adjacentes
            var edges = new List<(int, int)>
            {
                (0,1),(0,4),(0,6),(1,5),(1,7),(2,3),(2,4),(2,8),(3,5),(3,9),
                (4,10),(5,11),(6,10),(6,12),(7,11),(7,13),(8,12),(8,14),(9,13),(9,15),
                (10,16),(11,17),(12,18),(13,19),(14,16),(14,18),(15,17),(15,19),(16,18),(17,19)
            };

            return new Polyhedron(vertices, edges);
        }

        public static Polyhedron CreatePrism(int sides, float radius = 3f, float height = 5f)
        {
            if (sides < 3) sides = 3; // mínimo 3 lados

            var vertices = new List<Vector3>();

            // base no plano XZ
            for (int i = 0; i < sides; i++)
            {
                float angle = i * 2 * (float)Math.PI / sides;
                vertices.Add(new Vector3(radius * (float)Math.Cos(angle), 0, radius * (float)Math.Sin(angle)));
            }

            // ponto superior
            vertices.Add(new Vector3(0, height, 0));

            // ponto inferior
            vertices.Add(new Vector3(0, -height, 0));

            var edges = new List<(int, int)>();

            // centro
            for (int i = 0; i < sides; i++)
                edges.Add((i, (i + 1) % sides));

            // laterais
            for (int i = 0; i < sides; i++)
            {
                edges.Add((i, sides)); // topo é o último vértice
                edges.Add((i, sides+1));
            }

            return new Polyhedron(vertices, edges);
        }

        public static Polyhedron CreateStraightPrism(int baseSides, float radius = 3f, float height = 5f)
        {
            if (baseSides < 3) baseSides = 3; // mínimo 3 lados

            var vertices = new List<Vector3>();

            // base/topo no plano XZ
            for (int i = 0; i < baseSides; i++)
            {
                float angle = i * 2 * (float)Math.PI / baseSides;
                vertices.Add(new Vector3(radius * (float)Math.Cos(angle), 0, radius * (float)Math.Sin(angle)));
                vertices.Add(new Vector3(radius * (float)Math.Cos(angle), height, radius * (float)Math.Sin(angle)));
            }

            var edges = new List<(int, int)>();

            for (int i = 0; i < baseSides; i=i+2)
                edges.Add((i, (i + 1)));

            return new Polyhedron(vertices, edges);
        }

        public static Polyhedron CreatePyramidStem(int sides, float radius = 3f, float height = 5f, float cutOffPoint = 0.8f)
        {
            if (sides < 3) sides = 3; // mínimo 3 lados
            if (cutOffPoint <= 0) cutOffPoint = 0.1f;
            if (cutOffPoint > 1) cutOffPoint = 1f;

            var vertices = new List<Vector3>();

            // base no plano XZ
            for (int i = 0; i < sides; i++)
            {
                float angle = i * 2 * (float)Math.PI / sides;
                vertices.Add(new Vector3(radius * (float)Math.Cos(angle), 0, radius * (float)Math.Sin(angle)));

                vertices.Add(new Vector3(radius * (float)Math.Cos(angle) * (1 - cutOffPoint), height * cutOffPoint, radius * (float)Math.Sin(angle) * (1 - cutOffPoint)));
            }

            var edges = new List<(int, int)>();

            for (int i = 0; i < sides; i = i + 2)
                edges.Add((i, (i + 1)));

            return new Polyhedron(vertices, edges);
        }

    }
}
