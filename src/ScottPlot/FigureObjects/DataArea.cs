using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ScottPlot.Drawing;

namespace ScottPlot.FigureObjects
{
    class DataArea : IFigureObject
    {
        public Layer Layer { get { return Layer.DataArea; } set { } }
        public bool IsVisible { get; set; } = true;
        public double MinimumWidth { get; set; } = double.NaN;
        public double MinimumHeight { get; set; } = double.NaN;
        public (double x, double y, double width, double height) GetSizeAndPosition(Canvas canvas)
            => (canvas.PlotLocation.x, canvas.PlotLocation.y, canvas.PlotSize.width, canvas.PlotSize.height);

        public Color Color = Color.White;

        public DataArea()
        {

        }

        public DataArea(Color color)
        {
            Color = color;
        }

        public void Render(Canvas canvas)
        {
            using (Graphics gfx = Graphics.FromImage(canvas.Bmp))
            using (Brush brush = new SolidBrush(Color))
            {
                var (x, y, width, height) = GetSizeAndPosition(canvas);
                RectangleF rect = new RectangleF((float)x, (float)y, (float)width, (float)height);
                Console.WriteLine($"drawing data area {Color} {rect}");
                gfx.FillRectangle(brush, rect);
            }
        }
    }
}
