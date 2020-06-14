using System.Drawing;

namespace ScottPlot
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

        // TODO: make plot area dimensions its own class
        public int PlotPadL { get; private set; } = 50;
        public int PlotPadR { get; private set; } = 10;
        public int PlotPadT { get; private set; } = 60;
        public int PlotPadB { get; private set; } = 40;
        public (int x, int y) PlotLocation { get { return (PlotPadL, PlotPadT); } }
        public (int width, int height) PlotSize { get { return (Width - PlotPadR - PlotPadL, Height - PlotPadB - PlotPadT); } }

        // TODO: move axis info to its own class
        public double PlotXmin = -10;
        public double PlotXmax = 10;
        public double PlotYmin = -1;
        public double PlotYmax = 1;

        public float PixelY(double coordinateY)
        {
            double unitsFromYmin = coordinateY - PlotYmin;
            double pixelsFromYmin = unitsFromYmin * PxPerUnitY();
            return (float)(Height - PlotPadB - pixelsFromYmin);
        }

        public float PixelX(double coordinateX)
        {
            double unitsFromXmin = coordinateX - PlotXmin;
            double pixelsFromXmin = unitsFromXmin * PxPerUnitX();
            return (float)(PlotPadL + pixelsFromXmin);
        }

        public double CoordinateX(float pixelX)
        {
            return 0;
        }

        public double CoordinateY(float pixelY)
        {
            return 0;
        }

        public float PxPerUnitX()
        {
            return (float)(PlotSize.width / (PlotXmax - PlotXmin));
        }

        public float PxPerUnitY()
        {
            return (float)(PlotSize.height / (PlotYmax - PlotYmin));
        }

        public Canvas(int width, int height)
        {
            Bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Width = width;
            Height = height;
        }

        public void Pan(double unitsX, double unitsY)
        {
            PlotXmin += unitsX;
            PlotXmax += unitsX;
            PlotYmin += unitsY;
            PlotYmax += unitsY;
        }

        public Canvas(Bitmap bmp)
        {
            Bmp = bmp;
            Width = bmp.Width;   // WARNING: reading this property from the Bitmap is very slow
            Height = bmp.Height; // WARNING: reading this property from the Bitmap is very slow
        }
    }
}
