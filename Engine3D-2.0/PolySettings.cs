using System.ComponentModel;

namespace Engine3D_2._0
{
    // Classe base para configs genéricas
    internal abstract class PolySettings
    {
        [Category("Geral")]
        [Description("Nome do poliedro.")]
        public string Nome { get; set; } = "Poliedro";
    }

    // Configurações para Cubo
    internal class CubeSettings : PolySettings
    {
        [Category("Dimensões")]
        [Description("Tamanho das arestas do cubo.")]
        public float Tamanho { get; set; } = 5f;

        public new string Nome { get; set; } = "Cubo";
    }

    // Configurações para Pirâmide
    internal class PyramidSettings : PolySettings
    {
        [Category("Dimensões")]
        [Description("Raio da base da pirâmide.")]
        [DisplayName("Raio da Base")]
        public float RaioBase { get; set; } = 3f;

        [Category("Dimensões")]
        [Description("Altura da pirâmide.")]
        public float Altura { get; set; } = 5f;

        [Category("Geometria")]
        [Description("Número de lados da base da pirâmide.")]
        [DisplayName("Lados da Base")]
        public int LadosBase { get; set; } = 4;

        public new string Nome { get; set; } = "Pirâmide";
    }

    // Configurações para Dodecaedro
    internal class DodecahedronSettings : PolySettings
    {
        [Category("Dimensões")]
        [Description("Tamanho (raio aproximado da esfera circunscrita).")]
        public float Tamanho { get; set; } = 5f;

        public new string Nome { get; set; } = "Dodecaedro";
    }

    // Configurações para Icosaedro
    internal class IcosahedronSettings : PolySettings
    {
        [Category("Dimensões")]
        [Description("Tamanho (raio aproximado da esfera circunscrita).")]
        public float Tamanho { get; set; } = 5f;

        public new string Nome { get; set; } = "Isocaedro";
    }

    // Configurações para Prisma
    internal class PrismSettings : PolySettings
    {
        [Category("Dimensões")]
        [Description("Raio central do prisma.")]
        [DisplayName("Raio Central")]
        public float RaioCentral { get; set; } = 1f;

        [Category("Dimensões")]
        [Description("Altura do centro ao topo/base do prisma.")]
        public float Altura { get; set; } = 2f;

        [Category("Geometria")]
        [Description("Número de lados do polígono no centro.")]
        [DisplayName("Lados no Centro")]
        public int LadosCentro { get; set; } = 4;

        public new string Nome { get; set; } = "Prisma";
    }

    // Configurações para Prisma Reto
    internal class StraightPrismSettings : PolySettings
    {
        [Category("Dimensões")]
        [Description("Raio central do prisma reto.")]
        [DisplayName("Raio Central")]
        public float RaioCentral { get; set; } = 1f;

        [Category("Dimensões")]
        [Description("Altura do prisma reto.")]
        public float Altura { get; set; } = 2f;

        [Category("Geometria")]
        [Description("Número de lados do polígono original.")]
        [DisplayName("Lados")]
        public int LadosCentro { get; set; } = 4;

        public new string Nome { get; set; } = "Prisma Reto";
    }

    // Configurações para Tronco de Pirâmide
    internal class PyramidStemSettings : PolySettings
    {
        [Category("Dimensões")]
        [Description("Raio da base da pirâmide.")]
        [DisplayName("Raio da Base")]
        public float RaioCentral { get; set; } = 3f;

        [Category("Dimensões")]
        [Description("Altura da pirâmide.")]
        public float Altura { get; set; } = 5f;

        [Category("Geometria")]
        [Description("Número de lados da base da pirâmide.")]
        [DisplayName("Lados da Base")]
        public int LadosBase { get; set; } = 4;

        [Category("Geometria")]
        [Description("O \"Ponto de corte\" é a altura em que o políedro será \"fatiado\".\nEste valor é dado em % → 0 < X < 1.")]
        [DisplayName("Ponto de Corte")]
        public float PontoDeCorte { get; set; } = 0.5f;

        public new string Nome { get; set; } = "Tronco de Pirâmide";
    }
}
