using Engine3D_2._0;
using MIConvexHull;

// necessario para usar MIConvexHull
public class Vertex : IVertex
{
    public double[] Position { get; set; }

    public Vertex(Vector3 position)
    {
        Position = new double[] { position.X, position.Y, position.Z };
    }
}