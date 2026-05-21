using System;
using System.Windows.Forms;

namespace Engine3D_2._0
{
    public partial class PolyEditorForm : Form
    {
        private MainForm mainForm;

        CubeSettings cube = new CubeSettings();
        PyramidSettings pyramid = new PyramidSettings();
        DodecahedronSettings dodecahedron = new DodecahedronSettings();
        IcosahedronSettings icosahedron = new IcosahedronSettings();
        PrismSettings prisma = new PrismSettings();
        StraightPrismSettings prismaReto = new StraightPrismSettings();
        PyramidStemSettings pyramidStem = new PyramidStemSettings();

        public PolyEditorForm(MainForm parent)
        {
            InitializeComponent();
            mainForm = parent;
        }

        private void PolyEditorForm_Load(object sender, EventArgs e)
        {
            cube.Tamanho = mainForm.CuboSize;

            pyramid.RaioBase = mainForm.PiramideRadius;
            pyramid.Altura = mainForm.PiramideHeight;
            pyramid.LadosBase = mainForm.PiramideBaseSides;

            dodecahedron.Tamanho = mainForm.DodecaedroSize;

            icosahedron.Tamanho = mainForm.IcosaedroSize;

            prisma.RaioCentral = mainForm.PrismaRadius;
            prisma.LadosCentro = mainForm.PrismaSides;
            prisma.Altura = mainForm.PrismaHeight;

            prismaReto.RaioCentral = mainForm.PrismaRetoRadius;
            prismaReto.LadosCentro = mainForm.PrismaRetoSides;
            prismaReto.Altura = mainForm.PrismaRetoHeight;

            pyramidStem.RaioCentral = mainForm.PiramideTroncoRadius;
            pyramidStem.LadosBase = mainForm.PiramideTroncoSides;
            pyramidStem.Altura = mainForm.PiramideTroncoHeight;
            pyramidStem.PontoDeCorte = mainForm.PiramideTroncoCutOff;
        }

        private void ShowPolySettings(string polyType)
        {
            switch (polyType)
            {
                case "Cubo":
                    propertyGrid.SelectedObject = cube;
                    cube.Tamanho = mainForm.CuboSize;
                break;

                case "Pirâmide":
                    propertyGrid.SelectedObject = pyramid;
                    pyramid.RaioBase = mainForm.PiramideRadius;
                    pyramid.Altura = mainForm.PiramideHeight;
                    pyramid.LadosBase = mainForm.PiramideBaseSides;
                break;

                case "Dodecaedro":
                    propertyGrid.SelectedObject = dodecahedron;
                    dodecahedron.Tamanho = mainForm.DodecaedroSize;
                break;

                case "Icosaedro":
                    propertyGrid.SelectedObject = icosahedron;
                    icosahedron.Tamanho = mainForm.IcosaedroSize;
                break;

                case "Prisma":
                    propertyGrid.SelectedObject = prisma;
                    prisma.RaioCentral = mainForm.PrismaRadius;
                    prisma.LadosCentro = mainForm.PrismaSides;
                    prisma.Altura = mainForm.PrismaHeight;
                break;

                case "Prisma Reto":
                    propertyGrid.SelectedObject = prismaReto;
                    prismaReto.RaioCentral = mainForm.PrismaRetoRadius;
                    prismaReto.LadosCentro = mainForm.PrismaRetoSides;
                    prismaReto.Altura = mainForm.PrismaRetoHeight;
                break;

                case "Tronco de Pirâmide":
                    propertyGrid.SelectedObject = pyramidStem;
                    pyramidStem.RaioCentral = mainForm.PiramideTroncoRadius;
                    pyramidStem.LadosBase = mainForm.PiramideTroncoSides;
                    pyramidStem.Altura = mainForm.PiramideTroncoHeight;
                    pyramidStem.PontoDeCorte = mainForm.PiramideTroncoCutOff;
                break;
            }
        }

        private void poliedroCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPolySettings(poliedroCombobox.Text);
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            mainForm.CuboSize = cube.Tamanho;

            mainForm.PiramideRadius = pyramid.RaioBase;
            mainForm.PiramideHeight = pyramid.Altura;
            mainForm.PiramideBaseSides = pyramid.LadosBase;

            mainForm.DodecaedroSize = dodecahedron.Tamanho;

            mainForm.IcosaedroSize = icosahedron.Tamanho;

            mainForm.PrismaRadius = prisma.RaioCentral;
            mainForm.PrismaSides = prisma.LadosCentro;
            mainForm.PrismaHeight = prisma.Altura;

            mainForm.PrismaRetoRadius = prismaReto.RaioCentral;
            mainForm.PrismaRetoSides = prismaReto.LadosCentro;
            mainForm.PrismaRetoHeight = prismaReto.Altura;

            mainForm.PiramideTroncoRadius = pyramidStem.RaioCentral;
            mainForm.PiramideTroncoSides = pyramidStem.LadosBase;
            mainForm.PiramideTroncoHeight = pyramidStem.Altura;
            mainForm.PiramideTroncoCutOff = pyramidStem.PontoDeCorte;
        }
    }
}
