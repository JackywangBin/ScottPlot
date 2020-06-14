using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ScottPlot.Drawing;
using ScottPlot.FigureObject;

namespace ScottPlot.FigureObjects
{
    public class AxisLabelNorth : AxisLabel, IRenderable
    {
        public AxisLabelNorth(string text)
        {
            this.text = text;
            alignment = Alignment.North;
        }

        public override (double x, double y, double width, double height) GetSizeAndPosition(Canvas canvas)
        {
            double x1 = canvas.PlotPadL;
            double x2 = canvas.Width - canvas.PlotPadR;
            double y1 = 0;
            double y2 = canvas.PlotPadT;
            double width = x2 - x1;
            double height = y2 - y1;
            return (x1, y1, width, height);
        }
    }
}
