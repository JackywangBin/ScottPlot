using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable CS0618 // Type or member is obsolete
namespace FormsPlotSandbox
{
    public partial class FormRenderNew : Form
    {
        public FormRenderNew()
        {
            InitializeComponent();
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            var plt = new ScottPlot.Plot();
            plt.RenderSetup();
            Bitmap bmp = plt.Render(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = bmp;
        }
    }
}
