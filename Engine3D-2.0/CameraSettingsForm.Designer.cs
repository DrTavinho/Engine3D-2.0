namespace Engine3D_2._0
{
    partial class CameraSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraSettingsForm));
            this.fovGroupbox = new System.Windows.Forms.GroupBox();
            this.fovBar = new System.Windows.Forms.TrackBar();
            this.sensitivityGroupbox = new System.Windows.Forms.GroupBox();
            this.sensitivityTrackbar = new System.Windows.Forms.TrackBar();
            this.flySpeedGroupbox = new System.Windows.Forms.GroupBox();
            this.flySpeedTrackbar = new System.Windows.Forms.TrackBar();
            this.fovGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fovBar)).BeginInit();
            this.sensitivityGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityTrackbar)).BeginInit();
            this.flySpeedGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flySpeedTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // fovGroupbox
            // 
            this.fovGroupbox.Controls.Add(this.fovBar);
            this.fovGroupbox.Location = new System.Drawing.Point(12, 12);
            this.fovGroupbox.Name = "fovGroupbox";
            this.fovGroupbox.Size = new System.Drawing.Size(227, 74);
            this.fovGroupbox.TabIndex = 8;
            this.fovGroupbox.TabStop = false;
            this.fovGroupbox.Text = "FOV: 60";
            // 
            // fovBar
            // 
            this.fovBar.Location = new System.Drawing.Point(6, 19);
            this.fovBar.Maximum = 120;
            this.fovBar.Minimum = 30;
            this.fovBar.Name = "fovBar";
            this.fovBar.Size = new System.Drawing.Size(215, 45);
            this.fovBar.TabIndex = 1;
            this.fovBar.TickFrequency = 10;
            this.fovBar.Value = 60;
            this.fovBar.Scroll += new System.EventHandler(this.fovBar_Scroll);
            // 
            // sensitivityGroupbox
            // 
            this.sensitivityGroupbox.Controls.Add(this.sensitivityTrackbar);
            this.sensitivityGroupbox.Location = new System.Drawing.Point(12, 92);
            this.sensitivityGroupbox.Name = "sensitivityGroupbox";
            this.sensitivityGroupbox.Size = new System.Drawing.Size(227, 74);
            this.sensitivityGroupbox.TabIndex = 9;
            this.sensitivityGroupbox.TabStop = false;
            this.sensitivityGroupbox.Text = "Sensibilidade da Câmera: 100%";
            // 
            // sensitivityTrackbar
            // 
            this.sensitivityTrackbar.Location = new System.Drawing.Point(6, 19);
            this.sensitivityTrackbar.Maximum = 200;
            this.sensitivityTrackbar.Name = "sensitivityTrackbar";
            this.sensitivityTrackbar.Size = new System.Drawing.Size(215, 45);
            this.sensitivityTrackbar.TabIndex = 1;
            this.sensitivityTrackbar.TickFrequency = 20;
            this.sensitivityTrackbar.Value = 100;
            this.sensitivityTrackbar.Scroll += new System.EventHandler(this.sensitivityTrackbar_Scroll);
            // 
            // flySpeedGroupbox
            // 
            this.flySpeedGroupbox.Controls.Add(this.flySpeedTrackbar);
            this.flySpeedGroupbox.Location = new System.Drawing.Point(12, 172);
            this.flySpeedGroupbox.Name = "flySpeedGroupbox";
            this.flySpeedGroupbox.Size = new System.Drawing.Size(227, 74);
            this.flySpeedGroupbox.TabIndex = 10;
            this.flySpeedGroupbox.TabStop = false;
            this.flySpeedGroupbox.Text = "Velocidade de Voo da Câmera: 100%";
            // 
            // flySpeedTrackbar
            // 
            this.flySpeedTrackbar.Location = new System.Drawing.Point(6, 19);
            this.flySpeedTrackbar.Maximum = 200;
            this.flySpeedTrackbar.Name = "flySpeedTrackbar";
            this.flySpeedTrackbar.Size = new System.Drawing.Size(215, 45);
            this.flySpeedTrackbar.TabIndex = 1;
            this.flySpeedTrackbar.TickFrequency = 20;
            this.flySpeedTrackbar.Value = 100;
            this.flySpeedTrackbar.Scroll += new System.EventHandler(this.flySpeedTrackbar_Scroll);
            // 
            // CameraSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(251, 258);
            this.Controls.Add(this.flySpeedGroupbox);
            this.Controls.Add(this.sensitivityGroupbox);
            this.Controls.Add(this.fovGroupbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações da Câmera";
            this.Load += new System.EventHandler(this.CameraSettingsForm_Load);
            this.fovGroupbox.ResumeLayout(false);
            this.fovGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fovBar)).EndInit();
            this.sensitivityGroupbox.ResumeLayout(false);
            this.sensitivityGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityTrackbar)).EndInit();
            this.flySpeedGroupbox.ResumeLayout(false);
            this.flySpeedGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flySpeedTrackbar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox fovGroupbox;
        private System.Windows.Forms.TrackBar fovBar;
        private System.Windows.Forms.GroupBox sensitivityGroupbox;
        private System.Windows.Forms.TrackBar sensitivityTrackbar;
        private System.Windows.Forms.GroupBox flySpeedGroupbox;
        private System.Windows.Forms.TrackBar flySpeedTrackbar;
    }
}