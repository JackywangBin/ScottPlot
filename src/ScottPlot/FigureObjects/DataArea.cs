using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ScottPlot.Drawing;

namespace ScottPlot.FigureObjects
{
    class DataArea : IRenderable
    {
        public bool IsBelowData() => true;
        public bool IsAntiAliased { get; set; } = false;

        public Color fillColor = Color.White;

        public DataArea()
        {

        }

        public DataArea(Color color)
        {
            fillColor = color;
        }

        public void Render(Canvas canvas)
        {
            using (Graphics gfx = Graphics.FromImage(canvas.Bmp))
            using (Brush brush = new SolidBrush(fillColor))
            {
                gfx.FillRectangle(brush, canvas.PlotLocation.x, canvas.PlotLocation.y, canvas.PlotSize.width, canvas.PlotSize.height);
            }
        }
    }
}
