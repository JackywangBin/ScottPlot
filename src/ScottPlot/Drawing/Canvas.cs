using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ScottPlot.Drawing
{
    // this class stores the thing to be drawn upon, and the minimum
    // necessary information required to use a coordinate system.

    // ultimately this class will replace the settings module.

    // ultimately drawing calls can be injected into the canvas class,
    // allowing for an abstracted drawing library

    public class Canvas
    {
        public Bitmap Bmp { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        // dimensions of plot area (TODO: make its own class)
        public int PlotPadL { get; private set; } = 50;
        public int PlotPadR { get; private set; } = 10;
        public int PlotPadT { get; private set; } = 60;
        public int PlotPadB { get; private set; } = 40;
        public (int x, int y) PlotLocation { get { return (PlotPadL, PlotPadT); } }
        public (int width, int height) PlotSize { get { return (Width - PlotPadR - PlotPadL, Height - PlotPadB - PlotPadT); } }

        public Canvas(int width, int height)
        {
            Bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Width = width;
            Height = height;
        }

        public Canvas(Bitmap bmp)
        {
            Bmp = bmp;
            Width = bmp.Width;   // WARNING: reading this property from the Bitmap is very slow
            Height = bmp.Height; // WARNING: reading this property from the Bitmap is very slow
        }
    }
}
