using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ScottPlot.Drawing;

namespace ScottPlot.FigureObjects
{
    public class FigureArea : IFigureObject
    {
        public Layer Layer { get { return Layer.FigureBackground; } set { } }
        public bool IsVisible { get; set; } = true;
        public double MinimumWidth { get; set; } = double.NaN;
        public double MinimumHeight { get; set; } = double.NaN;
        public (double x, double y, double width, double height) GetSizeAndPosition(Canvas canvas)
            => (double.NaN, double.NaN, double.NaN, double.NaN);

        public Color Color = Color.White;

        public FigureArea()
        {

        }

        public FigureArea(Color color)
        {
            Color = color;
        }

        public void Render(Canvas canvas)
        {
            using (Graphics gfx = Graphics.FromImage(canvas.Bmp))
            {
                Console.WriteLine("drawing background");
                gfx.Clear(Color);
            }
        }
    }
}
