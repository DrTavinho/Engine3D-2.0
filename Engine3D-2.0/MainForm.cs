using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using MIConvexHull; // algoritmo de Convex Hull 3D (recalcular as faces de um poliedro após a remoção de vértices)

namespace Engine3D_2._0
{
    public partial class MainForm : Form
    {
        // Variaveis -----------------------------------------------------------------------------------------------------------------------------------------------------------------

        private List<Polyhedron> scenePolys = new List<Polyhedron>();
        private Polyhedron selectedPoly = null;

        private Color VertexColor { get; set; } = Color.Red;
        private int VertexSize { get; set; } = 6;

        private float userFov = 60f;
        public float UserFov
        {
            get => userFov;
            set => userFov = value;
        }

        // controle de atualizações da cena
        private bool needsRedraw = true;
        public bool NeedsRedraw
        {
            get => needsRedraw;
            set => needsRedraw = value;
        }

        // contador de FPS para a cena
        private int frameCount = 0;
        private float fps = 0f;
        private Timer fpsTimer;
        private Timer renderTimer;

        // pen
        private float lineThickness = 1f;   // valor padrão
        public float LineThickness
        {
            get => lineThickness;
            set => lineThickness = value;
        }
        private Pen scenePen;

        // vertices
        private int vertexPointSize = 6;   // valor padrão
        public int VertexPointSize
        {
            get => vertexPointSize;
            set => vertexPointSize = value;
        }

        // câmera
        private Camera camera;
        private bool firstMouseMove = true;
        private float lastMouseX, lastMouseY;
        private bool isControllingCamera = false;
        private Point screenCenter; // centro da tela do viewport

        private float cameraFlySpeed = 0.35f; // ajuste da velocidade de voo da camera
        public float CameraFlySpeed
        {
            get => cameraFlySpeed;
            set => cameraFlySpeed = (0.35f * value) / 100; // set é feito em % de valores entre 0 e 200
        }

        private float mouseSensitivity = 0.002f; // ajuste a sensibilidade
        public float MouseSensitivity
        {
            get => mouseSensitivity;
            set => mouseSensitivity = (0.002f * value)/100; // set é feito em % de valores entre 0 e 200
        }

        // movimentação
        private HashSet<Keys> keysPressed = new HashSet<Keys>();

        // grid de chão
        private List<(Vector3, Vector3)> gridLines = new List<(Vector3, Vector3)>();
        private int gridSize = 2;        // quantidade de linhas em cada direção
        private float gridStep = 8f;     // tamanho de cada casa

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------



        // Funções Principais -----------------------------------------------------------------------------------------------------------------------------------------------------------------

        public MainForm()
        {
            InitializeComponent();

            // cria camera na posição inicial
            camera = new Camera(new Vector3(0, 10, -40));

            // captura movimento do mouse
            viewportPanel.MouseMove += ViewportPanel_MouseMove;

            // cria grid de chão
            GenerateGrid(); 

            // Timer de render
            renderTimer = new Timer();
            renderTimer.Interval = 20;
            renderTimer.Tick += (s, e) => 
            {
                UpdateCameraMovement(); // processa teclas múltiplas
                if (needsRedraw)
                {
                    viewportPanel.Invalidate();
                    needsRedraw = false;
                }
            };
            renderTimer.Start();

            // aumentar desenpenho para evitar flickering da cena
            DoubleBuffered = true;
            typeof(Panel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(viewportPanel, true, null);

            // movimentos da camera
            KeyPreview = true; // ler teclas presionadas no form
            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;

            // conecta o evento de paint do painel
            viewportPanel.Paint += ViewportPanel_Paint;

            // inicializa label de coordenadas da camera
            xyzLabel.Text = $"XYZ: {camera.Position.X:F2} | {camera.Position.Y:F2} | {camera.Position.Z:F2}";

            // pen
            scenePen = new Pen(Color.White, lineThickness);
            scenePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            scenePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            // contador de FPS
            fpsTimer = new Timer();
            fpsTimer.Interval = 1000; // atualiza a cada 1 segundo
            fpsTimer.Tick += (s, e) =>
            {
                fps = frameCount;
                frameCount = 0;
                labelFps.Text = $"FPS: {fps}";
            };
            fpsTimer.Start();

            // coisas de design
            propertyGrid.MouseWheel += propertyGrid1_MouseWheel;
            viewportPanel.Controls.Add(xyzLabel);
            botoes_ativos_edicao(false);
            needsRedraw = true;
        }

        private void GenerateGrid()
        {
            gridLines.Clear();
            for (int i = -gridSize; i <= gridSize; i++)
            {
                float pos = i * gridStep;
                // linhas paralelas X
                gridLines.Add((new Vector3(-gridSize * gridStep, 0, pos), new Vector3(gridSize * gridStep, 0, pos)));
                // linhas paralelas Z
                gridLines.Add((new Vector3(pos, 0, -gridSize * gridStep), new Vector3(pos, 0, gridSize * gridStep)));
            }
        }

        // Movimentação da câmera na cena
        private void UpdateCameraMovement()
        {
            if (!isControllingCamera) return;

            // movimento da camera
            if(viewportPanel.Focused){

                Vector3 forward = movimentaçãoComBaseNaCameraToolStripMenuItem.Checked
                    ? camera.Forward
                    : new Vector3(camera.Forward.X, 0, camera.Forward.Z).Normalize();

                Vector3 worldUp = movimentaçãoComBaseNaCameraToolStripMenuItem.Checked
                    ? camera.Up
                    : camera.WorldUp;

                Vector3 Right = Vector3.Cross(camera.Forward, camera.Up).Normalize();

                if (keysPressed.Contains(Keys.W)) camera.Position += forward * cameraFlySpeed;
                if (keysPressed.Contains(Keys.S)) camera.Position -= forward * cameraFlySpeed;
                if (keysPressed.Contains(Keys.A)) camera.Position -= Right * cameraFlySpeed;
                if (keysPressed.Contains(Keys.D)) camera.Position += Right * cameraFlySpeed;

                // sobe/desce sempre relativo ao mundo
                if (keysPressed.Contains(Keys.ShiftKey)) camera.Position -= worldUp * cameraFlySpeed;
                if (keysPressed.Contains(Keys.Space)) camera.Position += worldUp * cameraFlySpeed;
            }

            // atualizar label de coords
            xyzLabel.Text = $"XYZ: {camera.Position.X:F2} | {camera.Position.Y:F2} | {camera.Position.Z:F2}";

            needsRedraw = true;
        }

        // Função de renderização principal
        private void ViewportPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.Clear(Color.Black); //pinta fundo
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // luz
            Vector3 lightDir = new Vector3(1, 1, -1).Normalize(); // direção da luz

            // camera
            Vector3 camForward = camera.Forward.Normalize(); // direcao frontal em relacao a camera
            Vector3 camRight = Vector3.Cross(camForward, camera.Up).Normalize(); // vetor lateral
            Vector3 camUp = Vector3.Cross(camRight, camForward); // garante perpendicularidade. Vetor cima

            // desenha grid na cena
            foreach (var line in gridLines)
            {
                Vector3 p1 = ToCameraSpace(line.Item1);
                Vector3 p2 = ToCameraSpace(line.Item2);
                if (p1.Z <= 0.1f || p2.Z <= 0.1f) continue;

                scenePen.Color = Color.Gray;
                g.DrawLine(scenePen, Project(p1), Project(p2));
            }

            // cria lista de faces com Z médio
            var facesToDraw = new List<(List<Vector3> Vertices, Vector3 Normal, float Depth)>();
            // desenha todos os poliedros na cena
            foreach (var poly in scenePolys) // para cada poliedro na cena...
            {
                if (!poly.Visible) continue; // pula caso visibilidade = falso
                facesToDraw.Clear();
                poly.RecalculateFaces();

                // levar em consideração a rotação do poliedro
                float cos = (float)Math.Cos(poly.RotationY);
                float sin = (float)Math.Sin(poly.RotationY);

                foreach (var face in poly.Faces)
                {
                    if (sombrearPoliedrosToolStripMenuItem.Checked)
                    {
                        if (face.Count < 3) continue;
                        Vector3 v0 = face[0];
                        Vector3 v1 = face[1];
                        Vector3 v2 = face[2];
                        Vector3 normal = Vector3.Cross(v1 - v0, v2 - v0).Normalize();

                        // Back-face culling
                        Vector3 viewDir = (camera.Position - poly.Position).Normalize();
                        if (Vector3.Dot(normal, viewDir) < 0) continue;

                        // profundidade média da face
                        float depth = face.Average(v => (v * poly.Scale + poly.Position - camera.Position).Length());

                        facesToDraw.Add((face, normal, depth));
                    }
                    else
                    {
                        for (int i = 0; i < face.Count; i++)
                        {
                            Vector3 v1 = face[i];
                            Vector3 v2 = face[(i + 1) % face.Count]; // conecta ao próximo, fechando o loop

                            // aplica escala, rotação e posição
                            Vector3 worldV1 = ApplyRotation(v1, poly) * poly.Scale + poly.Position;
                            Vector3 worldV2 = ApplyRotation(v2, poly) * poly.Scale + poly.Position;

                            Vector3 cp1 = ToCameraSpace(worldV1);
                            Vector3 cp2 = ToCameraSpace(worldV2);

                            if (cp1.Z <= 0.1f || cp2.Z <= 0.1f) continue;

                            // desenhar aresta da face
                            Pen facePen = scenePen; // já existe
                            facePen.Color = (poly == selectedPoly) ? Color.Aqua : Color.White;
                            g.DrawLine(facePen, Project(cp1), Project(cp2));
                        }
                    }
                }

                if (sombrearPoliedrosToolStripMenuItem.Checked)
                {
                    // ordena da mais distante para a mais próxima
                    facesToDraw.Sort((a, b) => b.Depth.CompareTo(a.Depth)); // algoritmo do pintor

                    // desenha faces
                    foreach (var (face, normal, depth) in facesToDraw)
                    {
                        // decide intensidade da luz
                        float intensity = Math.Max(0.1f, Vector3.Dot(normal, lightDir));
                        Color baseColor = Color.White;
                        int r = (int)(baseColor.R * intensity);
                        int gCol = (int)(baseColor.G * intensity);
                        int b = (int)(baseColor.B * intensity);
                        Color shadedColor = Color.FromArgb(r, gCol, b);

                        PointF[] projected = face.Select(v =>
                        {
                            Vector3 worldV = ApplyRotation(v, poly) * poly.Scale + poly.Position;
                            Vector3 camV = ToCameraSpace(worldV);
                            return Project(camV);
                        }).ToArray();

                        using (Brush brush = new SolidBrush(shadedColor))
                            g.FillPolygon(brush, projected); // pinta face

                        g.DrawPolygon(Pens.Black, projected); // desenhas arestas
                    }
                }

                // desenha vertices como circulos para visualização na cena
                if (visualizarVérticesToolStripMenuItem.Checked)
                    foreach (var v in poly.Vertices.Select((vert, idx) => (vert, idx))) // v é uma tupla
                    {
                        int idx = v.idx;
                        Vector3 vert = v.vert;

                        if (vérticesSóEmSelecionadoToolStripMenuItem.Checked && poly != selectedPoly) break;

                        // aplica escala
                        Vector3 scaledV = new Vector3(
                            v.vert.X * poly.Scale,
                            v.vert.Y * poly.Scale,
                            v.vert.Z * poly.Scale
                        );

                        // aplica rotação completa (X, Y, Z) + posição do poliedro
                        Vector3 worldV = ApplyRotation(scaledV, poly) + poly.Position;

                        // converte para espaço da câmera
                        Vector3 cp = ToCameraSpace(worldV);
                        if (cp.Z <= 0.1f) continue;

                        // obter projeção final em 2D
                        PointF p = Project(cp);

                        int size = vertexPointSize; // tamanho do círculo

                        // verifica se este vértice está selecionado
                        bool isSelectedVertex = (poly == selectedPoly && idx == vertexSelectedIndex);

                        // desenhar circulo com bordas
                        Brush fill = isSelectedVertex ? Brushes.Lime : (poly == selectedPoly ? Brushes.Red : Brushes.Yellow);
                        Pen border = isSelectedVertex ? new Pen(Color.Green, 2) : Pens.Black;

                        g.FillEllipse(fill, p.X - size / 2, p.Y - size / 2, size, size);
                        g.DrawEllipse(border, p.X - size / 2, p.Y - size / 2, size, size);
                    }
            }

            frameCount++;
        }

        private void UpdateSceneList()
        {
            int selectedIndex = listBoxScene.SelectedIndex; // salva seleção atual
            listBoxScene.Items.Clear();

            for (int i = 0; i < scenePolys.Count; i++)
            {
                listBoxScene.Items.Add($"{i}. {scenePolys[i].Name} ({scenePolys[i].Vertices.Count} vertices)");
            }

            // restaura seleção
            if (selectedIndex >= 0 && selectedIndex < listBoxScene.Items.Count)
                listBoxScene.SelectedIndex = selectedIndex;
            else
                listBoxScene.SelectedIndex = -1;

            needsRedraw = true;
        }

        private void listBoxScene_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxScene.SelectedIndex;
            if (index >= 0 && index < scenePolys.Count)
            {
                selectedPoly = scenePolys[index];
                botoes_ativos_edicao(true);

                propertyGrid.SelectedObject = selectedPoly;
                propertyGrid.Refresh();
                needsRedraw = true;
            }
            else
            {
                selectedPoly = null;
                botoes_ativos_edicao(false);
            }
        }

        private void ViewportPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isControllingCamera) return; // só move se estiver controlando a camera

            if (firstMouseMove) // evita pulo inicial da camera devido à reposicionalização inicial do cursor
            {
                lastMouseX = e.X;
                lastMouseY = e.Y;
                firstMouseMove = false;
                return;
            }

            // calcula delta em relação ao centro
            float deltaX = e.X - viewportPanel.Width / 2;
            float deltaY = e.Y - viewportPanel.Height / 2;

            lastMouseX = e.X;
            lastMouseY = e.Y;

            // aplica rotação na câmera
            camera.Rotate(
                ((inverterMouseXToolStripMenuItem.Checked) ? deltaX : -deltaX) * mouseSensitivity, 
                ((inverterMouseYToolStripMenuItem.Checked) ? deltaY : -deltaY) * mouseSensitivity
            );

            // Recentraliza o mouse
            screenCenter = viewportPanel.PointToScreen(new Point(viewportPanel.Width / 2, viewportPanel.Height / 2));
            Cursor.Position = screenCenter;

            needsRedraw = true;
            viewportPanel.Invalidate();
        }

        bool internalGridUpdate = false;
        private void SelectVetexOnViewPortClick(MouseEventArgs e)
        {
            if (scenePolys.Count == 0)
                return;

            float closestDist = float.MaxValue;
            Polyhedron closestPoly = null;
            int closestVertexIndex = -1;

            // percorre todos os poliedros da cena
            foreach (var poly in scenePolys)
            {
                for (int i = 0; i < poly.Vertices.Count; i++)
                {
                    Vector3 v = poly.Vertices[i];

                    // aplica escala e rotação
                    Vector3 worldV = ApplyRotation(v * poly.Scale, poly) + poly.Position;

                    // converte para espaço da câmera
                    Vector3 cp = ToCameraSpace(worldV);
                    if (cp.Z <= 0.1f) continue;

                    // projeção 3D -> 2D
                    PointF p = Project(cp);

                    // calcula distância do clique até o vértice
                    float dx = p.X - e.X;
                    float dy = p.Y - e.Y;
                    float dist = (float)Math.Sqrt(dx * dx + dy * dy);

                    // se o vértice estiver suficientemente próximo do clique
                    if (dist < 8f && dist < closestDist)
                    {
                        closestDist = dist;
                        closestPoly = poly;
                        closestVertexIndex = i;
                    }
                }
            }
            
            // define seleção, se encontrou algum vértice
            if (closestPoly != null)
            {
                selectedPoly = closestPoly;
                vertexSelectedIndex = closestVertexIndex;

                internalGridUpdate = true;

                int polyIndex = scenePolys.IndexOf(selectedPoly);
                if (polyIndex >= 0 && polyIndex < listBoxScene.Items.Count)
                {
                    listBoxScene.SelectedIndex = polyIndex;
                }

                propertyGrid.SelectedObject = selectedPoly;
                propertyGrid.Refresh();

                SelectVertexInPropertyGrid(selectedPoly, vertexSelectedIndex);

                internalGridUpdate = false;

                needsRedraw = true;
                viewportPanel.Invalidate();

            }
        }

        private bool IsFaceVisible(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 cameraPos)
        {
            // Calcula o vetor normal da face
            Vector3 normal = Vector3.Cross(v2 - v1, v3 - v1).Normalize();

            // Calcula o vetor da face até a câmera
            Vector3 toCamera = (cameraPos - v1).Normalize();

            // Produto escalar: se > 0, a face está voltada para a câmera
            return Vector3.Dot(normal, toCamera) > 0;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------



        // Codigo para a geração de novos poliedros na cena ---------------------------------------------------------------------------------------------------------------------------------

        private void CreatePolyEnd(Polyhedron poly, string name) // codigo compartilhado
        {
            if (!novosPoliedrosEm000ToolStripMenuItem.Checked)
            {
                Vector3 forward = camera.Forward.Normalize();
                poly.Position = camera.Position + forward * 30; // adiciona à frente da câmera
            }
            else poly.Position = new Vector3(0, 2.5f, 0);

            poly.Name = name;

            scenePolys.Add(poly);
            UpdateSceneList();
            needsRedraw = true;
        }

        // Cubo
        private float cuboSize = 5f;
        public float CuboSize
        {
            get => cuboSize;
            set => cuboSize = value;
        }

        // Piramide
        private int piramideBaseSides = 4;
        public int PiramideBaseSides
        {
            get => piramideBaseSides;
            set => piramideBaseSides = value;
        }

        private float piramideRadius = 3f;
        public float PiramideRadius
        {
            get => piramideRadius;
            set => piramideRadius = value;
        }

        private float piramideHeight = 5f;
        public float PiramideHeight
        {
            get => piramideHeight;
            set => piramideHeight = value;
        }

        // Dodecaedro
        private float dodecaedroSize = 5f;
        public float DodecaedroSize
        {
            get => dodecaedroSize;
            set => dodecaedroSize = value;
        }

        // Icosaedro
        private float icosaedroSize = 5f;
        public float IcosaedroSize
        {
            get => icosaedroSize;
            set => icosaedroSize = value;
        }

        // Prisma
        private int prismaSides = 4;
        public int PrismaSides
        {
            get => prismaSides;
            set => prismaSides = value;
        }

        private float prismaRadius = 3f;
        public float PrismaRadius
        {
            get => prismaRadius;
            set => prismaRadius = value;
        }

        private float prismaHeight = 5f;
        public float PrismaHeight
        {
            get => prismaHeight;
            set => prismaHeight = value;
        }

        // Prisma reto
        private int prismaRetoSides = 6;
        public int PrismaRetoSides
        {
            get => prismaRetoSides;
            set => prismaRetoSides = value;
        }

        private float prismaRetoRadius = 2f;
        public float PrismaRetoRadius
        {
            get => prismaRetoRadius;
            set => prismaRetoRadius = value;
        }

        private float prismaRetoHeight = 6f;
        public float PrismaRetoHeight
        {
            get => prismaRetoHeight;
            set => prismaRetoHeight = value;
        }

        // Tronco de Pirâmide
        private int piramideTroncoSides = 4;
        public int PiramideTroncoSides
        {
            get => prismaRetoSides;
            set => prismaRetoSides = value;
        }

        private float piramideTroncoRadius = 3f;
        public float PiramideTroncoRadius
        {
            get => piramideTroncoRadius;
            set => piramideTroncoRadius = value;
        }

        private float piramideTroncoHeight = 5f;
        public float PiramideTroncoHeight
        {
            get => piramideTroncoHeight;
            set => piramideTroncoHeight = value;
        }

        private float piramideTroncoCutOff = 0.5f;
        public float PiramideTroncoCutOff
        {
            get => piramideTroncoCutOff;
            set => piramideTroncoCutOff = value;
        }

        // Clicks de botão na interface
        private void cuboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Polyhedron poly = PolyFactory.CreateCube(cuboSize);
            CreatePolyEnd(poly, "Cubo");
        }

        private void pirâmideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Polyhedron poly = PolyFactory.CreatePyramid(piramideBaseSides, piramideRadius, piramideHeight);
            CreatePolyEnd(poly, "Pirâmide");
        }

        private void dodecaedroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Polyhedron poly = PolyFactory.CreateDodecahedron(dodecaedroSize);
            CreatePolyEnd(poly, "Dodecaedro");
        }

        private void prismaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Polyhedron poly = PolyFactory.CreatePrism(prismaSides, prismaRadius, prismaHeight);
            CreatePolyEnd(poly, "Prisma");
        }

        private void prismaRetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Polyhedron poly = PolyFactory.CreateStraightPrism(prismaRetoSides, prismaRetoRadius, prismaRetoHeight);
            CreatePolyEnd(poly, "Prisma Reto");
        }

        private void troncoDePirâmideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Polyhedron poly = PolyFactory.CreatePyramidStem(piramideTroncoSides, piramideTroncoRadius, piramideTroncoHeight, piramideTroncoCutOff);
            CreatePolyEnd(poly, "Tronco de Pirâmide");
        }

        private void icosaedroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Polyhedron poly = PolyFactory.CreateIcosahedron(icosaedroSize);
            CreatePolyEnd(poly, "Icosaedro");
        }

        // função auxiliar para adicionar novos poliedros na cena
        private void AddPolyhedron(Polyhedron poly) 
        {
            scenePolys.Add(poly);
            needsRedraw = true;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------



        // Controles para abrir outros formulários ---------------------------------------------------------------------------------------------------------------------------------

        private CameraSettingsForm cameraSettingsForm;
        private void configuraçõesDaCâmeraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cameraSettingsForm == null || cameraSettingsForm.IsDisposed)
            {
                cameraSettingsForm = new CameraSettingsForm(this);
                cameraSettingsForm.Show();
            }
            else
            {
                cameraSettingsForm.BringToFront();
            }
        }

        private PolyEditorForm polyEditorForm;
        private void abrirEditorDePoliedrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (polyEditorForm == null || polyEditorForm.IsDisposed)
            {
                polyEditorForm = new PolyEditorForm(this);
                polyEditorForm.Show();
            }
            else
            {
                polyEditorForm.BringToFront();
            }
        }

        private PenSettingsForm penSettingsForm;
        private void abrirEditorDasArestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (penSettingsForm == null || penSettingsForm.IsDisposed)
            {
                penSettingsForm = new PenSettingsForm(this);
                penSettingsForm.Show();
            }
            else
            {
                penSettingsForm.BringToFront();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------



        // Outros controles básicos de elementos no formulário e pequenas funções ---------------------------------------------------------------------------------------------------------------------------------

        private PointF Project(Vector3 v) // serve para obter posição final projetado em 2D
        {
            if (v.Z <= 0.1f) return new PointF(9999, 9999); // evita divisão por zero/atrás da câmera

            // centro da tela
            float cx = viewportPanel.Width / 2f;
            float cy = viewportPanel.Height / 2f;

            // converte FOV (em graus) para fator de projeção
            float fovRad = userFov * (float)Math.PI / 180f;
            float f = (viewportPanel.Width / 2f) / (float)Math.Tan(fovRad / 2f);

            float px = cx + (v.X * f) / v.Z;
            float py = cy - (v.Y * f) / v.Z;

            return new PointF(px, py);
        }

        private Vector3 ToCameraSpace(Vector3 worldPos)
        {
            Vector3 camForward = camera.Forward.Normalize();
            Vector3 camRight = Vector3.Cross(camForward, camera.Up).Normalize();
            Vector3 camUp = Vector3.Cross(camRight, camForward);

            Vector3 relative = worldPos - camera.Position;

            return new Vector3(
                Vector3.Dot(relative, camRight),   // X local
                Vector3.Dot(relative, camUp),      // Y local
                Vector3.Dot(relative, camForward)  // Z local
            );
        }

        // solução em:
        // https://stackoverflow.com/questions/24571817/how-to-set-selected-item-of-property-grid
        private void SelectVertexInPropertyGrid(Polyhedron poly, int vertexIndex)
        {
            if (poly == null || vertexIndex < 0)
                return;

            // força recarregar o objeto
            propertyGrid.SelectedObject = poly;
            propertyGrid.Refresh();

            // procura o GridItem que corresponde ao vértice selecionado
            var gi = propertyGrid.EnumerateAllItems()
                .FirstOrDefault(item =>
                    item.PropertyDescriptor is VertexPropertyDescriptor vpd &&
                    vpd.Index == vertexIndex);

            if (gi != null)
            {
                propertyGrid.Focus();
                gi.Select(); // destaca o vértice na PropertyGrid
            }
        }

        public void SetLineThickness(float thickness)
        {
            lineThickness = thickness;

            if (scenePen != null)
                scenePen.Dispose(); // descarta o antigo

            scenePen = new Pen(Color.White, lineThickness);
            scenePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            scenePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            needsRedraw = true;
            viewportPanel.Invalidate();
        }

        private void viewportPanel_MouseClick(object sender, MouseEventArgs e)
        {
            SelectVetexOnViewPortClick(e);
        }

        private void viewportPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !isControllingCamera)
            {
                viewportContextMenu.Show(viewportPanel, e.Location);
            }
        }

        private void resetarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridStep = 8f;
            GenerateGrid();
            needsRedraw = true;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            // ao atualizar valores para o poliedro selecionado
            this.ActiveControl = null;
            selectedPoly.RecalculateFaces();
            viewportPanel.Focus();
            UpdateSceneList();
            needsRedraw = true;
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            listBoxScene.ClearSelected();
            propertyGrid.SelectedObject = null;
            viewportPanel.Focus();
            selectedPoly = null;
            UpdateSceneList();
            needsRedraw = true;
        }

        private void deletarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deletar_selecionado();
        }

        private void deletar_selecionado()
        {
            if (selectedPoly != null)
            {
                scenePolys.Remove(selectedPoly);
                selectedPoly = null;
                UpdateSceneList();
                needsRedraw = true;

                botoes_ativos_edicao(false);
                propertyGrid.SelectedObject = null;
            }
        }

        private void botoes_ativos_edicao(bool opt)
        {
            deletarToolStripMenuItem.Enabled = opt;
            desselecionarToolStripMenuItem.Enabled = opt;
        }

        private void desselecionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxScene.ClearSelected();
            propertyGrid.SelectedObject = null;
            vertexSelectedIndex = -1;
            deletarVérticeToolStripMenuItem.Enabled = false;
            needsRedraw = true;
        }

        private bool keyPressed = false;
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            keysPressed.Add(e.KeyCode);

            if (!IsEditingText(this) && !keyPressed)
            {
                if (e.KeyCode == Keys.Delete) // verifica se é Delete
                {
                    // Verifica se há um poliedro selecionado
                    if (HasSelectedVertex())
                    {
                        DeleteSelectedVertexConvexHull();
                    }
                    else if (selectedPoly != null && !HasSelectedVertex())
                    {
                        deletar_selecionado();
                    }
                }
                else if (keysPressed.Contains(Keys.Escape))
                {
                    if (!isControllingCamera)
                    {
                        listBoxScene.ClearSelected();
                        propertyGrid.SelectedObject = null;
                        viewportPanel.Focus();
                        selectedPoly = null;
                        UpdateSceneList();
                        needsRedraw = true;
                    }
                    else
                    {
                        isControllingCamera = false;
                        controlsLbl.Visible = false;
                        Cursor.Show();
                        cameraControlModeBtn.Visible = true;
                    }
                }
                else if (keysPressed.Contains(Keys.Oemplus) || keysPressed.Contains(Keys.Add)) // +
                {
                    gridStep += 0.5f;
                    GenerateGrid();
                }
                if (keysPressed.Contains(Keys.OemMinus) || keysPressed.Contains(Keys.Subtract)) // -
                {
                    gridStep = Math.Max(0.5f, gridStep - 0.5f); // evita <=0
                    GenerateGrid();
                }
            }
            keyPressed = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            keysPressed.Remove(e.KeyCode);
            keyPressed = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            needsRedraw = true;
        }

        private void cameraControlModeBtn_Click(object sender, EventArgs e)
        {
            firstMouseMove = true;

            cameraControlModeBtn.Visible = false;

            controlsLbl.Visible = true;

            // Oculta o cursor
            Cursor.Hide();

            // Define o centro da tela do viewport
            screenCenter = viewportPanel.PointToScreen(new Point(viewportPanel.Width / 2, viewportPanel.Height / 2));

            // Centraliza o mouse
            Cursor.Position = screenCenter;

            isControllingCamera = true;
            viewportPanel.Focus(); // garante que o painel capture teclado/mouse
        }

        private void visualizarVérticesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            needsRedraw = true;
        }

        private void vérticesSóEmSelecionadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            needsRedraw = true;
        }

        private void resetarPosiçãoDaCâmeraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.Position = new Vector3(0, 10, -40);
            camera.Pitch = 0f;
            camera.Yaw = 0f;
            camera.UpdateDirection();
            needsRedraw = true;
            viewportPanel.Invalidate();
        }

        // Matrizes de rotação composta
        // A matriz de rotação total será: R = Rz ​* Ry ​* Rx​
        Vector3 ApplyRotation(Vector3 v, Polyhedron poly)
        {
            float radX = poly.RotationX * (float)Math.PI / 180f;
            float radY = poly.RotationY * (float)Math.PI / 180f;
            float radZ = poly.RotationZ * (float)Math.PI / 180f;

            float cx = (float)Math.Cos(radX);
            float sx = (float)Math.Sin(radX);
            float cy = (float)Math.Cos(radY);
            float sy = (float)Math.Sin(radY);
            float cz = (float)Math.Cos(radZ);
            float sz = (float)Math.Sin(radZ);

            // Rotação em X
            float x1 = v.X;
            float y1 = cx * v.Y - sx * v.Z;
            float z1 = sx * v.Y + cx * v.Z;

            // Rotação em Y
            float x2 = cy * x1 + sy * z1;
            float y2 = y1;
            float z2 = -sy * x1 + cy * z1;

            // Rotação em Z
            float x3 = cz * x2 - sz * y2;
            float y3 = sz * x2 + cz * y2;
            float z3 = z2;

            return new Vector3(x3, y3, z3);
        }

        private int vertexSelectedIndex = -1;
        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            if (internalGridUpdate) return;
            if (e.NewSelection == null) return;

            GridItem item = e.NewSelection;

            // Se for subpropriedade (X, Y ou Z), sobe até o pai
            while (item.Parent != null && !(item.PropertyDescriptor is VertexPropertyDescriptor))
            {
                item = item.Parent;
            }

            // verifica se é um VertexPropertyDescriptor
            if (item.PropertyDescriptor is VertexPropertyDescriptor vpd)
            {
                vertexSelectedIndex = vpd.Index;  // salva índice do vértice
                selectedPoly = vpd.Owner;         // salva o poliedro dono
                deletarVérticeToolStripMenuItem.Enabled = true;
            }
            else
            {
                vertexSelectedIndex = -1;
                deletarVérticeToolStripMenuItem.Enabled = false;
            }

            needsRedraw = true;
        }

        private void DeleteSelectedVertex()
        {
            if (vertexSelectedIndex != -1 && selectedPoly != null)
            {
                selectedPoly.RemoveVertexAndReconnect3D(vertexSelectedIndex);
                vertexSelectedIndex = -1;
                propertyGrid.SelectedObject = null;
                needsRedraw = true;
                viewportPanel.Invalidate();

                // atualiza propertygrid e listbox se necessário
                propertyGrid.SelectedObject = selectedPoly;
                propertyGrid.Refresh();
                UpdateSceneList();
            }
        }

        private void DeleteSelectedVertexConvexHull()
        {
            if (selectedPoly == null || vertexSelectedIndex < 0) return;

            // remove o vértice da lista do poliedro
            if (vertexSelectedIndex >= 0 && vertexSelectedIndex < selectedPoly.Vertices.Count)
            {
                selectedPoly.Vertices.RemoveAt(vertexSelectedIndex);
            }

            // recalcula arestas usando convex hull
            PolyhedronUtils.RecalculateEdgesUsingConvexHull(selectedPoly);

            // atualiza UI
            vertexSelectedIndex = -1;
            propertyGrid.SelectedObject = null;
            propertyGrid.SelectedObject = selectedPoly; // garante que grid mostra o objeto atualizado
            propertyGrid.Refresh();
            UpdateSceneList(); // se você tem função para atualizar a listbox
            needsRedraw = true;
            viewportPanel.Invalidate();
        }

        private void deletarVérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedVertex();
        }

        private void métodoMIConvexHullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedVertexConvexHull();
        }

        private void propertyGrid1_MouseWheel(object sender, MouseEventArgs e)
        {
            GridItem item = propertyGrid.SelectedGridItem;
            if (item == null || item.PropertyDescriptor == null) return;

            Type type = item.PropertyDescriptor.PropertyType;
            object currentValue = item.Value;
            float delta = e.Delta > 0 ? 1f : -1f; // ajuste sensibilidade

            try
            {
                // Descobre se é propriedade filha (Vector3.X/Y/Z) ou raiz (RotationX/Y/Z)
                object targetObject = item.Parent?.Value ?? propertyGrid.SelectedObject;

                if (item.Label.Contains("Rotation"))
                {
                    float newValue = Convert.ToSingle(currentValue) + delta * 1f; // ajusta sensibilidade
                    item.PropertyDescriptor.SetValue(targetObject, newValue);
                }
                else if (type == typeof(int))
                {
                    int newValue = (int)currentValue + (int)delta;
                    item.PropertyDescriptor.SetValue(targetObject, newValue);
                }
                else if (type == typeof(float) || type == typeof(double))
                {
                    float newValue = Convert.ToSingle(currentValue) + delta * 0.25f; // ajusta sensibilidade
                    item.PropertyDescriptor.SetValue(targetObject, newValue);
                }

                propertyGrid.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao alterar propriedade: " + ex.Message);
            }
            needsRedraw = true;
        }

        // teste para desabilitar a tecla delete enquanto estiver editando textos
        bool IsEditingText(Control container) // não funciona pra propertygrid pq: pau no meu cu
        {
            Control focused = container.FindForm()?.ActiveControl;
            while (focused != null)
            {
                // Tipos básicos de input
                if (focused is TextBoxBase || focused is NumericUpDown || focused is DomainUpDown)
                    return true;

                if (focused is ComboBox cb && cb.DropDownStyle == ComboBoxStyle.DropDown)
                    return true;

                // Verifica PropertyGrid internamente
                if (focused is PropertyGrid pg)
                {
                    var gridViewField = typeof(PropertyGrid).GetField("gridView", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (gridViewField != null)
                    {
                        var gridView = gridViewField.GetValue(pg);
                        if (gridView != null)
                        {
                            var editField = gridView.GetType().GetField("edit", BindingFlags.NonPublic | BindingFlags.Instance);
                            if (editField != null)
                            {
                                var editor = editField.GetValue(gridView) as Control;
                                if (editor != null && editor.Focused)
                                    return true;
                            }
                        }
                    }
                }

                // Sobe na hierarquia
                focused = focused.Parent;
            }

            return false;
        }

        private bool HasSelectedVertex()
        {
            return selectedPoly != null
                && vertexSelectedIndex >= 0
                && vertexSelectedIndex < selectedPoly.Vertices.Count;
        }

        private void sombrearPoliedrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            needsRedraw = true;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------



    }
}
