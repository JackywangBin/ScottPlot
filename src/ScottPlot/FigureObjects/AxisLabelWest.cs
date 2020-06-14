using System;
using System.Collections.Generic;
using System.Text;
using ScottPlot.Drawing;
using ScottPlot.FigureObject;

namespace ScottPlot.FigureObjects
{
    class AxisLabelWest : AxisLabel, IFigureObject
    {
        public AxisLabelWest(string text)
        {
            this.text = text;
            alignment = Alignment.North;
            angle = -90;
        }

        public override (double x, double y, double width, double height) GetSizeAndPosition(Canvas canvas)
        {
            double x1 = 0;
            double x2 = canvas.PlotPadL;
            double y1 = canvas.PlotPadT;
            double y2 = canvas.PlotPadT + canvas.PlotSize.height;
            double width = x2 - x1;
            double height = y2 - y1;
            return (x1, y1, width, height);
        }
    }
}
