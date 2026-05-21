namespace Engine3D_2._0
{
    partial class PenSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PenSettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.espessuraNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tamVerticNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.espessuraNumUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tamVerticNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.espessuraNumUpDown);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Espessura";
            // 
            // espessuraNumUpDown
            // 
            this.espessuraNumUpDown.Location = new System.Drawing.Point(6, 19);
            this.espessuraNumUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.espessuraNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.espessuraNumUpDown.Name = "espessuraNumUpDown";
            this.espessuraNumUpDown.Size = new System.Drawing.Size(126, 20);
            this.espessuraNumUpDown.TabIndex = 1;
            this.espessuraNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.espessuraNumUpDown.ValueChanged += new System.EventHandler(this.espessuraNumUpDown_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 126);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configurações da Caneta";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tamVerticNumUpDown);
            this.groupBox3.Location = new System.Drawing.Point(6, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(138, 47);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tamanho Vértices";
            // 
            // tamVerticNumUpDown
            // 
            this.tamVerticNumUpDown.Location = new System.Drawing.Point(6, 19);
            this.tamVerticNumUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.tamVerticNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tamVerticNumUpDown.Name = "tamVerticNumUpDown";
            this.tamVerticNumUpDown.Size = new System.Drawing.Size(126, 20);
            this.tamVerticNumUpDown.TabIndex = 1;
            this.tamVerticNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tamVerticNumUpDown.ValueChanged += new System.EventHandler(this.tamVerticNumUpDown_ValueChanged);
            // 
            // PenSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 148);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PenSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caneta";
            this.Load += new System.EventHandler(this.PenSettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.espessuraNumUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tamVerticNumUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown espessuraNumUpDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown tamVerticNumUpDown;
    }
}