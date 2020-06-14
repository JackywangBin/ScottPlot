using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ScottPlot.Drawing;

namespace ScottPlot.FigureObjects
{
    public class FigureArea : IRenderable
    {
        public bool IsBelowData() => true;
        public bool IsVisible { get; set; } = true;

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
