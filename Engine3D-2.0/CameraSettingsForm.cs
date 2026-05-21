using System;
using System.Windows.Forms;

namespace Engine3D_2._0
{
    public partial class CameraSettingsForm : Form
    {
        private MainForm mainForm;

        public CameraSettingsForm(MainForm parent)
        {
            InitializeComponent();
            mainForm = parent;
        }

        private void CameraSettingsForm_Load(object sender, EventArgs e)
        {
            fovGroupbox.Text = $"FOV: {mainForm.UserFov.ToString()}";
            fovBar.Value = (int)mainForm.UserFov;

            sensitivityGroupbox.Text = $"Sensibilidade da Câmera: {mainForm.MouseSensitivity / 0.002 * 100:F0}%";
            sensitivityTrackbar.Value = (int)(mainForm.MouseSensitivity / 0.002 * 100);

            flySpeedGroupbox.Text = $"Velocidade de Voo da Câmera: {mainForm.CameraFlySpeed / 0.35 * 100:F0}%";
            flySpeedTrackbar.Value = (int)(mainForm.CameraFlySpeed / 0.35 * 100);

        }

        private void fovBar_Scroll(object sender, EventArgs e)
        {
            mainForm.UserFov = fovBar.Value;
            fovGroupbox.Text = $"FOV: {mainForm.UserFov.ToString()}";
            mainForm.NeedsRedraw = true;
            
        }

        private void sensitivityTrackbar_Scroll(object sender, EventArgs e)
        {
            mainForm.MouseSensitivity = sensitivityTrackbar.Value;
            sensitivityGroupbox.Text = $"Sensibilidade da Câmera: {sensitivityTrackbar.Value:F0}%";
        }

        private void flySpeedTrackbar_Scroll(object sender, EventArgs e)
        {
            mainForm.CameraFlySpeed = flySpeedTrackbar.Value;
            flySpeedGroupbox.Text = $"Velocidade de Voo da Câmera: {flySpeedTrackbar.Value:F0}%";
        }
    }
}
