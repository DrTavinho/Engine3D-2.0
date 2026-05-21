using System;

namespace Engine3D_2._0
{
    // Isso permite expandir o objeto no PropertyGrid (clica na setinha e abre X, Y, Z).
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]

    public class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3 GetForward(float yaw, float pitch)
        {
            float cosPitch = (float)Math.Cos(pitch);
            float sinPitch = (float)Math.Sin(pitch);
            float cosYaw = (float)Math.Cos(yaw);
            float sinYaw = (float)Math.Sin(yaw);

            return new Vector3(
                cosPitch * sinYaw,
                sinPitch,
                cosPitch * cosYaw
            );
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        // operadores úteis
        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3 operator *(Vector3 a, float s) => new Vector3(a.X * s, a.Y * s, a.Z * s);
        public static Vector3 operator *(float s, Vector3 a) => a * s;
        public static Vector3 operator /(Vector3 a, float s) => new Vector3(a.X / s, a.Y / s, a.Z / s);

        // produto escalar
        public static float Dot(Vector3 a, Vector3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        // produto vetorial
        public static Vector3 Cross(Vector3 a, Vector3 b)
            => new Vector3(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X
            );

        public static Vector3 RotateX(Vector3 v, float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            return new Vector3(
                v.X,
                v.Y * cos - v.Z * sin,
                v.Y * sin + v.Z * cos
            );
        }

        public static Vector3 RotateY(Vector3 v, float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            return new Vector3(
                v.X * cos + v.Z * sin,
                v.Y,
                -v.X * sin + v.Z * cos
            );
        }

        public static Vector3 RotateZ(Vector3 v, float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            return new Vector3(
                v.X * cos - v.Y * sin,
                v.X * sin + v.Y * cos,
                v.Z
            );
        }

        public float Length() => (float)Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector3 Normalize()
        {
            float len = Length();
            if (len <= 1e-6f) return new Vector3(0, 0, 0);
            return this / len;
        }

    }
}
