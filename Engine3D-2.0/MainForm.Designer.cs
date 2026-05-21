namespace Engine3D_2._0
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.viewportPanel = new System.Windows.Forms.Panel();
            this.controlsLbl = new System.Windows.Forms.Label();
            this.cameraControlModeBtn = new System.Windows.Forms.Button();
            this.labelFps = new System.Windows.Forms.Label();
            this.xyzLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cenaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pirâmideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.troncoDePirâmideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prismaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.prismaRetoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodecaedroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.icosaedroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirEditorDePoliedrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirEditorDasArestasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novosPoliedrosEm000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarVérticesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vérticesSóEmSelecionadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sombrearPoliedrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desselecionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletarVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.métodoMIConvexHullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.métodoVizinhosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesDaCâmeraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaçãoComBaseNaCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverterMouseYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverterMouseXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetarPosiçãoDaCâmeraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxScene = new System.Windows.Forms.ListBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.viewportContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adicionarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cuboToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pirâmideToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.troncoDePirâmideToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.prismaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prismaRetoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dodecaedroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.icosaedroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirEditorDePoliedrosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirConfiguraçãoDaCanetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.viewportPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.viewportContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewportPanel
            // 
            this.viewportPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.viewportPanel.Controls.Add(this.controlsLbl);
            this.viewportPanel.Controls.Add(this.cameraControlModeBtn);
            this.viewportPanel.Controls.Add(this.labelFps);
            this.viewportPanel.Controls.Add(this.xyzLabel);
            this.viewportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewportPanel.Location = new System.Drawing.Point(0, 0);
            this.viewportPanel.Name = "viewportPanel";
            this.viewportPanel.Size = new System.Drawing.Size(540, 472);
            this.viewportPanel.TabIndex = 0;
            this.viewportPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.viewportPanel_MouseClick);
            this.viewportPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewportPanel_MouseDown);
            // 
            // controlsLbl
            // 
            this.controlsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.controlsLbl.AutoSize = true;
            this.controlsLbl.BackColor = System.Drawing.Color.Transparent;
            this.controlsLbl.Location = new System.Drawing.Point(1, 404);
            this.controlsLbl.Name = "controlsLbl";
            this.controlsLbl.Size = new System.Drawing.Size(79, 65);
            this.controlsLbl.TabIndex = 6;
            this.controlsLbl.Text = "WASD - Mover\r\nMouse - Olhar\r\nEspaço- Subir\r\nShift - Descer\r\nEsc - Sair";
            this.controlsLbl.Visible = false;
            // 
            // cameraControlModeBtn
            // 
            this.cameraControlModeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraControlModeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraControlModeBtn.Location = new System.Drawing.Point(497, 3);
            this.cameraControlModeBtn.Name = "cameraControlModeBtn";
            this.cameraControlModeBtn.Size = new System.Drawing.Size(40, 40);
            this.cameraControlModeBtn.TabIndex = 5;
            this.cameraControlModeBtn.Text = "👁️";
            this.cameraControlModeBtn.UseVisualStyleBackColor = true;
            this.cameraControlModeBtn.Click += new System.EventHandler(this.cameraControlModeBtn_Click);
            // 
            // labelFps
            // 
            this.labelFps.AutoSize = true;
            this.labelFps.BackColor = System.Drawing.Color.Transparent;
            this.labelFps.Location = new System.Drawing.Point(1, 2);
            this.labelFps.Name = "labelFps";
            this.labelFps.Size = new System.Drawing.Size(39, 13);
            this.labelFps.TabIndex = 4;
            this.labelFps.Text = "FPS: 0";
            // 
            // xyzLabel
            // 
            this.xyzLabel.AutoSize = true;
            this.xyzLabel.BackColor = System.Drawing.Color.Transparent;
            this.xyzLabel.Location = new System.Drawing.Point(1, 15);
            this.xyzLabel.Name = "xyzLabel";
            this.xyzLabel.Size = new System.Drawing.Size(116, 13);
            this.xyzLabel.TabIndex = 3;
            this.xyzLabel.Text = "XYZ: 0.00 | 0.00  | 0.00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cenaToolStripMenuItem,
            this.opçõesToolStripMenuItem,
            this.movimentaçãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            // 
            // cenaToolStripMenuItem
            // 
            this.cenaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem,
            this.abrirEditorDePoliedrosToolStripMenuItem,
            this.abrirEditorDasArestasToolStripMenuItem,
            this.novosPoliedrosEm000ToolStripMenuItem,
            this.visualizarVérticesToolStripMenuItem,
            this.vérticesSóEmSelecionadoToolStripMenuItem,
            this.sombrearPoliedrosToolStripMenuItem});
            this.cenaToolStripMenuItem.Name = "cenaToolStripMenuItem";
            this.cenaToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.cenaToolStripMenuItem.Text = "Cena";
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuboToolStripMenuItem,
            this.pirâmideToolStripMenuItem,
            this.troncoDePirâmideToolStripMenuItem,
            this.prismaToolStripMenuItem1,
            this.prismaRetoToolStripMenuItem,
            this.dodecaedroToolStripMenuItem,
            this.icosaedroToolStripMenuItem});
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.adicionarToolStripMenuItem.Text = "Adicionar";
            // 
            // cuboToolStripMenuItem
            // 
            this.cuboToolStripMenuItem.Name = "cuboToolStripMenuItem";
            this.cuboToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cuboToolStripMenuItem.Text = "Cubo";
            this.cuboToolStripMenuItem.Click += new System.EventHandler(this.cuboToolStripMenuItem_Click);
            // 
            // pirâmideToolStripMenuItem
            // 
            this.pirâmideToolStripMenuItem.Name = "pirâmideToolStripMenuItem";
            this.pirâmideToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pirâmideToolStripMenuItem.Text = "Pirâmide";
            this.pirâmideToolStripMenuItem.Click += new System.EventHandler(this.pirâmideToolStripMenuItem_Click);
            // 
            // troncoDePirâmideToolStripMenuItem
            // 
            this.troncoDePirâmideToolStripMenuItem.Name = "troncoDePirâmideToolStripMenuItem";
            this.troncoDePirâmideToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.troncoDePirâmideToolStripMenuItem.Text = "Tronco de Pirâmide";
            this.troncoDePirâmideToolStripMenuItem.Click += new System.EventHandler(this.troncoDePirâmideToolStripMenuItem_Click);
            // 
            // prismaToolStripMenuItem1
            // 
            this.prismaToolStripMenuItem1.Name = "prismaToolStripMenuItem1";
            this.prismaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.prismaToolStripMenuItem1.Text = "Prisma";
            this.prismaToolStripMenuItem1.Click += new System.EventHandler(this.prismaToolStripMenuItem_Click);
            // 
            // prismaRetoToolStripMenuItem
            // 
            this.prismaRetoToolStripMenuItem.Name = "prismaRetoToolStripMenuItem";
            this.prismaRetoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.prismaRetoToolStripMenuItem.Text = "Prisma Reto";
            this.prismaRetoToolStripMenuItem.Click += new System.EventHandler(this.prismaRetoToolStripMenuItem_Click);
            // 
            // dodecaedroToolStripMenuItem
            // 
            this.dodecaedroToolStripMenuItem.Name = "dodecaedroToolStripMenuItem";
            this.dodecaedroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dodecaedroToolStripMenuItem.Text = "Dodecaedro";
            this.dodecaedroToolStripMenuItem.Click += new System.EventHandler(this.dodecaedroToolStripMenuItem_Click);
            // 
            // icosaedroToolStripMenuItem
            // 
            this.icosaedroToolStripMenuItem.Name = "icosaedroToolStripMenuItem";
            this.icosaedroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.icosaedroToolStripMenuItem.Text = "Icosaedro";
            this.icosaedroToolStripMenuItem.Click += new System.EventHandler(this.icosaedroToolStripMenuItem_Click);
            // 
            // abrirEditorDePoliedrosToolStripMenuItem
            // 
            this.abrirEditorDePoliedrosToolStripMenuItem.Name = "abrirEditorDePoliedrosToolStripMenuItem";
            this.abrirEditorDePoliedrosToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.abrirEditorDePoliedrosToolStripMenuItem.Text = "Abrir Editor de Poliedros";
            this.abrirEditorDePoliedrosToolStripMenuItem.Click += new System.EventHandler(this.abrirEditorDePoliedrosToolStripMenuItem_Click);
            // 
            // abrirEditorDasArestasToolStripMenuItem
            // 
            this.abrirEditorDasArestasToolStripMenuItem.Name = "abrirEditorDasArestasToolStripMenuItem";
            this.abrirEditorDasArestasToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.abrirEditorDasArestasToolStripMenuItem.Text = "Abrir Configuração da Caneta";
            this.abrirEditorDasArestasToolStripMenuItem.Click += new System.EventHandler(this.abrirEditorDasArestasToolStripMenuItem_Click);
            // 
            // novosPoliedrosEm000ToolStripMenuItem
            // 
            this.novosPoliedrosEm000ToolStripMenuItem.CheckOnClick = true;
            this.novosPoliedrosEm000ToolStripMenuItem.Name = "novosPoliedrosEm000ToolStripMenuItem";
            this.novosPoliedrosEm000ToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.novosPoliedrosEm000ToolStripMenuItem.Text = "Novos Poliedros no Centro da Cena?";
            // 
            // visualizarVérticesToolStripMenuItem
            // 
            this.visualizarVérticesToolStripMenuItem.Checked = true;
            this.visualizarVérticesToolStripMenuItem.CheckOnClick = true;
            this.visualizarVérticesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.visualizarVérticesToolStripMenuItem.Name = "visualizarVérticesToolStripMenuItem";
            this.visualizarVérticesToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.visualizarVérticesToolStripMenuItem.Text = "Visualizar Vértices?";
            this.visualizarVérticesToolStripMenuItem.Click += new System.EventHandler(this.visualizarVérticesToolStripMenuItem_Click);
            // 
            // vérticesSóEmSelecionadoToolStripMenuItem
            // 
            this.vérticesSóEmSelecionadoToolStripMenuItem.Checked = true;
            this.vérticesSóEmSelecionadoToolStripMenuItem.CheckOnClick = true;
            this.vérticesSóEmSelecionadoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vérticesSóEmSelecionadoToolStripMenuItem.Name = "vérticesSóEmSelecionadoToolStripMenuItem";
            this.vérticesSóEmSelecionadoToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.vérticesSóEmSelecionadoToolStripMenuItem.Text = "Vértices Só Em Selecionado?";
            this.vérticesSóEmSelecionadoToolStripMenuItem.Click += new System.EventHandler(this.vérticesSóEmSelecionadoToolStripMenuItem_Click);
            // 
            // sombrearPoliedrosToolStripMenuItem
            // 
            this.sombrearPoliedrosToolStripMenuItem.CheckOnClick = true;
            this.sombrearPoliedrosToolStripMenuItem.Name = "sombrearPoliedrosToolStripMenuItem";
            this.sombrearPoliedrosToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.sombrearPoliedrosToolStripMenuItem.Text = "Sombrear Poliedros?";
            this.sombrearPoliedrosToolStripMenuItem.Click += new System.EventHandler(this.sombrearPoliedrosToolStripMenuItem_Click);
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desselecionarToolStripMenuItem,
            this.resetarToolStripMenuItem,
            this.deletarToolStripMenuItem,
            this.deletarVérticeToolStripMenuItem});
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opçõesToolStripMenuItem.Text = "Opções";
            // 
            // desselecionarToolStripMenuItem
            // 
            this.desselecionarToolStripMenuItem.Enabled = false;
            this.desselecionarToolStripMenuItem.Name = "desselecionarToolStripMenuItem";
            this.desselecionarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.desselecionarToolStripMenuItem.Text = "Desselecionar";
            this.desselecionarToolStripMenuItem.Click += new System.EventHandler(this.desselecionarToolStripMenuItem_Click);
            // 
            // resetarToolStripMenuItem
            // 
            this.resetarToolStripMenuItem.Name = "resetarToolStripMenuItem";
            this.resetarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.resetarToolStripMenuItem.Text = "Resetar Grade";
            this.resetarToolStripMenuItem.Click += new System.EventHandler(this.resetarToolStripMenuItem_Click);
            // 
            // deletarToolStripMenuItem
            // 
            this.deletarToolStripMenuItem.Enabled = false;
            this.deletarToolStripMenuItem.Name = "deletarToolStripMenuItem";
            this.deletarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deletarToolStripMenuItem.Text = "Deletar Poliedro";
            this.deletarToolStripMenuItem.Click += new System.EventHandler(this.deletarToolStripMenuItem_Click);
            // 
            // deletarVérticeToolStripMenuItem
            // 
            this.deletarVérticeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.métodoMIConvexHullToolStripMenuItem,
            this.métodoVizinhosToolStripMenuItem});
            this.deletarVérticeToolStripMenuItem.Enabled = false;
            this.deletarVérticeToolStripMenuItem.Name = "deletarVérticeToolStripMenuItem";
            this.deletarVérticeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deletarVérticeToolStripMenuItem.Text = "Deletar Vértice";
            // 
            // métodoMIConvexHullToolStripMenuItem
            // 
            this.métodoMIConvexHullToolStripMenuItem.Name = "métodoMIConvexHullToolStripMenuItem";
            this.métodoMIConvexHullToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.métodoMIConvexHullToolStripMenuItem.Text = "Método ConvexHull";
            this.métodoMIConvexHullToolStripMenuItem.Click += new System.EventHandler(this.métodoMIConvexHullToolStripMenuItem_Click);
            // 
            // métodoVizinhosToolStripMenuItem
            // 
            this.métodoVizinhosToolStripMenuItem.Name = "métodoVizinhosToolStripMenuItem";
            this.métodoVizinhosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.métodoVizinhosToolStripMenuItem.Text = "Método Vizinhos";
            this.métodoVizinhosToolStripMenuItem.Click += new System.EventHandler(this.deletarVérticeToolStripMenuItem_Click);
            // 
            // movimentaçãoToolStripMenuItem
            // 
            this.movimentaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesDaCâmeraToolStripMenuItem,
            this.movimentaçãoComBaseNaCameraToolStripMenuItem,
            this.inverterMouseYToolStripMenuItem,
            this.inverterMouseXToolStripMenuItem,
            this.resetarPosiçãoDaCâmeraToolStripMenuItem});
            this.movimentaçãoToolStripMenuItem.Name = "movimentaçãoToolStripMenuItem";
            this.movimentaçãoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.movimentaçãoToolStripMenuItem.Text = "Câmera";
            // 
            // configuraçõesDaCâmeraToolStripMenuItem
            // 
            this.configuraçõesDaCâmeraToolStripMenuItem.Name = "configuraçõesDaCâmeraToolStripMenuItem";
            this.configuraçõesDaCâmeraToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.configuraçõesDaCâmeraToolStripMenuItem.Text = "Abrir Configurações da Câmera";
            this.configuraçõesDaCâmeraToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesDaCâmeraToolStripMenuItem_Click);
            // 
            // movimentaçãoComBaseNaCameraToolStripMenuItem
            // 
            this.movimentaçãoComBaseNaCameraToolStripMenuItem.CheckOnClick = true;
            this.movimentaçãoComBaseNaCameraToolStripMenuItem.Name = "movimentaçãoComBaseNaCameraToolStripMenuItem";
            this.movimentaçãoComBaseNaCameraToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.movimentaçãoComBaseNaCameraToolStripMenuItem.Text = "Movimentação Relativa à Câmera?";
            // 
            // inverterMouseYToolStripMenuItem
            // 
            this.inverterMouseYToolStripMenuItem.CheckOnClick = true;
            this.inverterMouseYToolStripMenuItem.Name = "inverterMouseYToolStripMenuItem";
            this.inverterMouseYToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.inverterMouseYToolStripMenuItem.Text = "Inverter Mouse Y?";
            // 
            // inverterMouseXToolStripMenuItem
            // 
            this.inverterMouseXToolStripMenuItem.CheckOnClick = true;
            this.inverterMouseXToolStripMenuItem.Name = "inverterMouseXToolStripMenuItem";
            this.inverterMouseXToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.inverterMouseXToolStripMenuItem.Text = "Inverter Mouse X?";
            // 
            // resetarPosiçãoDaCâmeraToolStripMenuItem
            // 
            this.resetarPosiçãoDaCâmeraToolStripMenuItem.Name = "resetarPosiçãoDaCâmeraToolStripMenuItem";
            this.resetarPosiçãoDaCâmeraToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.resetarPosiçãoDaCâmeraToolStripMenuItem.Text = "Resetar Posição da Câmera";
            this.resetarPosiçãoDaCâmeraToolStripMenuItem.Click += new System.EventHandler(this.resetarPosiçãoDaCâmeraToolStripMenuItem_Click);
            // 
            // listBoxScene
            // 
            this.listBoxScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxScene.FormattingEnabled = true;
            this.listBoxScene.ItemHeight = 16;
            this.listBoxScene.Location = new System.Drawing.Point(0, 0);
            this.listBoxScene.Name = "listBoxScene";
            this.listBoxScene.Size = new System.Drawing.Size(216, 138);
            this.listBoxScene.TabIndex = 8;
            this.listBoxScene.SelectedIndexChanged += new System.EventHandler(this.listBoxScene_SelectedIndexChanged);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(216, 330);
            this.propertyGrid.TabIndex = 10;
            this.propertyGrid.ToolbarVisible = false;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            this.propertyGrid.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.propertyGrid1_SelectedGridItemChanged);
            // 
            // viewportContextMenu
            // 
            this.viewportContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem1,
            this.abrirEditorDePoliedrosToolStripMenuItem1,
            this.aToolStripMenuItem,
            this.abrirConfiguraçãoDaCanetaToolStripMenuItem});
            this.viewportContextMenu.Name = "viewportContextMenu";
            this.viewportContextMenu.Size = new System.Drawing.Size(241, 92);
            // 
            // adicionarToolStripMenuItem1
            // 
            this.adicionarToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuboToolStripMenuItem1,
            this.pirâmideToolStripMenuItem1,
            this.troncoDePirâmideToolStripMenuItem1,
            this.prismaToolStripMenuItem,
            this.prismaRetoToolStripMenuItem1,
            this.dodecaedroToolStripMenuItem1,
            this.icosaedroToolStripMenuItem1});
            this.adicionarToolStripMenuItem1.Name = "adicionarToolStripMenuItem1";
            this.adicionarToolStripMenuItem1.Size = new System.Drawing.Size(240, 22);
            this.adicionarToolStripMenuItem1.Text = "Adicionar";
            // 
            // cuboToolStripMenuItem1
            // 
            this.cuboToolStripMenuItem1.Name = "cuboToolStripMenuItem1";
            this.cuboToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.cuboToolStripMenuItem1.Text = "Cubo";
            this.cuboToolStripMenuItem1.Click += new System.EventHandler(this.cuboToolStripMenuItem_Click);
            // 
            // pirâmideToolStripMenuItem1
            // 
            this.pirâmideToolStripMenuItem1.Name = "pirâmideToolStripMenuItem1";
            this.pirâmideToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.pirâmideToolStripMenuItem1.Text = "Pirâmide";
            this.pirâmideToolStripMenuItem1.Click += new System.EventHandler(this.pirâmideToolStripMenuItem_Click);
            // 
            // troncoDePirâmideToolStripMenuItem1
            // 
            this.troncoDePirâmideToolStripMenuItem1.Name = "troncoDePirâmideToolStripMenuItem1";
            this.troncoDePirâmideToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.troncoDePirâmideToolStripMenuItem1.Text = "Tronco de Pirâmide";
            this.troncoDePirâmideToolStripMenuItem1.Click += new System.EventHandler(this.troncoDePirâmideToolStripMenuItem_Click);
            // 
            // prismaToolStripMenuItem
            // 
            this.prismaToolStripMenuItem.Name = "prismaToolStripMenuItem";
            this.prismaToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.prismaToolStripMenuItem.Text = "Prisma";
            this.prismaToolStripMenuItem.Click += new System.EventHandler(this.prismaToolStripMenuItem_Click);
            // 
            // prismaRetoToolStripMenuItem1
            // 
            this.prismaRetoToolStripMenuItem1.Name = "prismaRetoToolStripMenuItem1";
            this.prismaRetoToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.prismaRetoToolStripMenuItem1.Text = "Prisma Reto";
            this.prismaRetoToolStripMenuItem1.Click += new System.EventHandler(this.prismaRetoToolStripMenuItem_Click);
            // 
            // dodecaedroToolStripMenuItem1
            // 
            this.dodecaedroToolStripMenuItem1.Name = "dodecaedroToolStripMenuItem1";
            this.dodecaedroToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.dodecaedroToolStripMenuItem1.Text = "Dodecaedro";
            this.dodecaedroToolStripMenuItem1.Click += new System.EventHandler(this.dodecaedroToolStripMenuItem_Click);
            // 
            // icosaedroToolStripMenuItem1
            // 
            this.icosaedroToolStripMenuItem1.Name = "icosaedroToolStripMenuItem1";
            this.icosaedroToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.icosaedroToolStripMenuItem1.Text = "Icosaedro";
            this.icosaedroToolStripMenuItem1.Click += new System.EventHandler(this.icosaedroToolStripMenuItem_Click);
            // 
            // abrirEditorDePoliedrosToolStripMenuItem1
            // 
            this.abrirEditorDePoliedrosToolStripMenuItem1.Name = "abrirEditorDePoliedrosToolStripMenuItem1";
            this.abrirEditorDePoliedrosToolStripMenuItem1.Size = new System.Drawing.Size(240, 22);
            this.abrirEditorDePoliedrosToolStripMenuItem1.Text = "Abrir Editor de Poliedros";
            this.abrirEditorDePoliedrosToolStripMenuItem1.Click += new System.EventHandler(this.abrirEditorDePoliedrosToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.aToolStripMenuItem.Text = "Abrir Configurações da Câmera";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesDaCâmeraToolStripMenuItem_Click);
            // 
            // abrirConfiguraçãoDaCanetaToolStripMenuItem
            // 
            this.abrirConfiguraçãoDaCanetaToolStripMenuItem.Name = "abrirConfiguraçãoDaCanetaToolStripMenuItem";
            this.abrirConfiguraçãoDaCanetaToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.abrirConfiguraçãoDaCanetaToolStripMenuItem.Text = "Abrir Configuração da Caneta";
            this.abrirConfiguraçãoDaCanetaToolStripMenuItem.Click += new System.EventHandler(this.abrirEditorDasArestasToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxScene);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(216, 472);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(12, 27);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.viewportPanel);
            this.splitContainer2.Size = new System.Drawing.Size(760, 472);
            this.splitContainer2.SplitterDistance = 216;
            this.splitContainer2.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple 3D Engine";
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.viewportPanel.ResumeLayout(false);
            this.viewportPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.viewportContextMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel viewportPanel;
        private System.Windows.Forms.Label xyzLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cenaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.Label labelFps;
        private System.Windows.Forms.ListBox listBoxScene;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pirâmideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desselecionarToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ToolStripMenuItem resetarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverterMouseYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverterMouseXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentaçãoComBaseNaCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodecaedroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novosPoliedrosEm000ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesDaCâmeraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarVérticesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vérticesSóEmSelecionadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirEditorDePoliedrosToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip viewportContextMenu;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cuboToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pirâmideToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dodecaedroToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abrirEditorDePoliedrosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetarPosiçãoDaCâmeraToolStripMenuItem;
        private System.Windows.Forms.Button cameraControlModeBtn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prismaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prismaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abrirEditorDasArestasToolStripMenuItem;
        private System.Windows.Forms.Label controlsLbl;
        private System.Windows.Forms.ToolStripMenuItem deletarVérticeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem métodoVizinhosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem métodoMIConvexHullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prismaRetoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prismaRetoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sombrearPoliedrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem troncoDePirâmideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem troncoDePirâmideToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abrirConfiguraçãoDaCanetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem icosaedroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem icosaedroToolStripMenuItem1;
    }
}

