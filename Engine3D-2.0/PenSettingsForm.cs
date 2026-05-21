using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine3D_2._0
{
    public partial class PenSettingsForm : Form
    {
        private MainForm mainForm;

        public PenSettingsForm(MainForm parent)
        {
            InitializeComponent();
            mainForm = parent;
        }

        private void PenSettingsForm_Load(object sender, EventArgs e)
        {
            espessuraNumUpDown.Value = (decimal)mainForm.LineThickness;
            tamVerticNumUpDown.Value = (decimal)mainForm.VertexPointSize;
        }

        private void espessuraNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            mainForm.LineThickness = (float)espessuraNumUpDown.Value;
            mainForm.SetLineThickness(mainForm.LineThickness);
        }

        private void tamVerticNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            mainForm.VertexPointSize = (int)tamVerticNumUpDown.Value;
            mainForm.NeedsRedraw = true;
        }
    }
}
