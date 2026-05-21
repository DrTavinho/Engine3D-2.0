using MIConvexHull;

namespace Engine3D_2._0
{
    // necessario para usar MIConvexHull
    public class Vertex3D : IVertex
    {
        public double[] Position { get; }

        public Vertex3D(Vector3 v)
        {
            Position = new double[] { v.X, v.Y, v.Z };
        }

        // Método auxiliar para voltar a Vector3
        public Vector3 ToVector3() => new Vector3((float)Position[0], (float)Position[1], (float)Position[2]);
    }
}
