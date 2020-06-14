using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ScottPlot.Drawing;
using ScottPlot.FigureObject;

namespace ScottPlot.FigureObjects
{
    class AxisLabelSouth : AxisLabel, IFigureObject
    {
        public AxisLabelSouth(string text)
        {
            this.text = text;
            alignment = Alignment.South;
        }

        public override (double x, double y, double width, double height) GetSizeAndPosition(Canvas canvas)
        {
            double x1 = canvas.PlotPadL;
            double x2 = canvas.Width - canvas.PlotPadR;
            double y1 = canvas.PlotPadT + canvas.PlotSize.height;
            double y2 = canvas.Height;
            double width = x2 - x1;
            double height = y2 - y1;
            return (x1, y1, width, height);
        }
    }
}
