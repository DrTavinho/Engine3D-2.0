using System;

namespace Engine3D_2._0
{
    internal class Camera
    {
        public Vector3 Position;
        public Vector3 Forward;
        public Vector3 Up;

        public Vector3 Right;   // cache do vetor direita
        public Vector3 WorldUp = new Vector3(0, 1, 0); // "up" verdadeiro do mundo

        public float Yaw { get; set; }
        public float Pitch { get; set; }

        public Camera(Vector3 pos)
        {
            Position = pos;
            Forward = new Vector3(0, 0, 1); // olhando para frente
            Up = WorldUp;      // “para cima” é eixo Y
            Right = Vector3.Cross(Forward, Up).Normalize();
        }

        // rotação de yaw e pitch para movimentar a câmera estilo jogos de tiro
        public void Rotate(float deltaYaw, float deltaPitch)
        {
            Yaw += deltaYaw;
            Pitch += deltaPitch;

            // limita o pitch para evitar "girar de ponta cabeça"
            float limit = (float)(Math.PI / 2 - 0.01f);
            if (Pitch > limit) Pitch = limit;
            if (Pitch < -limit) Pitch = -limit;

            // calcula direção "forward" com base nos ângulos
            float cosPitch = (float)Math.Cos(Pitch);
            float sinPitch = (float)Math.Sin(Pitch);
            float cosYaw = (float)Math.Cos(Yaw);
            float sinYaw = (float)Math.Sin(Yaw);

            Forward = new Vector3(
                cosPitch * sinYaw,
                sinPitch,
                cosPitch * cosYaw
            ).Normalize();   

            // vetor "right" é o produto vetorial entre Forward e o Up global
            Vector3 right = Vector3.Cross(Forward, new Vector3(0, 1, 0)).Normalize();

            // vetor "up" (perpendicular ao plano da câmera)
            Up = Vector3.Cross(right, Forward).Normalize();
        }

        // Função para forçar atualização de yaw e pitch caso alterado manualmente
        public void UpdateDirection()
        {
            float cosPitch = (float)Math.Cos(Pitch);
            float sinPitch = (float)Math.Sin(Pitch);
            float cosYaw = (float)Math.Cos(Yaw);
            float sinYaw = (float)Math.Sin(Yaw);

            Forward = new Vector3(
                cosPitch * sinYaw,
                sinPitch,
                cosPitch * cosYaw
            );

            Vector3 right = Vector3.Cross(Forward, new Vector3(0, 1, 0));
            Up = Vector3.Cross(right, Forward);
        }

    }

}
