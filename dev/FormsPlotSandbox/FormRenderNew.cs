using ScottPlot;
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
        ScottPlot.Plot plt = new ScottPlot.Plot();
        public FormRenderNew()
        {
            InitializeComponent();
            plt.RenderSetup();
            Render();
        }

        private void btnRender_Click(object sender, EventArgs e) => Render();
        private void FormRenderNew_SizeChanged(object sender, EventArgs e) => Render();

        private void Render()
        {
            Bitmap bmp = plt.Render(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = bmp;
        }

        PointF mouseDownLocation = new PointF(-1, -1);
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownLocation = new PointF(-1, -1);
            Render();
        }

        bool busy = false;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            bool mouseIsDown = (mouseDownLocation.X != -1);
            if (mouseIsDown)
            {
                if (busy)
                    return;

                busy = true;

                float deltaPxX = e.Location.X - mouseDownLocation.X;
                float deltaPxY = e.Location.Y - mouseDownLocation.Y;

                var canvas = new Canvas(pictureBox1.Width, pictureBox1.Height);

                double deltaUnitsX = -deltaPxX / canvas.PxPerUnitX();
                double deltaUnitsY = deltaPxY / canvas.PxPerUnitY();
                canvas.Pan(deltaUnitsX, deltaUnitsY);

                plt.Render(canvas);
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = canvas.Bmp;
                pictureBox1.Refresh();
                busy = false;
            }
        }
    }
}
