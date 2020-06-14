using System;
using System.Collections.Generic;
using System.Text;
using ScottPlot.Drawing;

namespace ScottPlot
{
    public interface IFigureObject
    {
        bool IsVisible { get; set; }
        double MinimumWidth { get; set; }
        double MinimumHeight { get; set; }
        bool IsBelowData { get; set; }

        (double x, double y, double width, double height) GetSizeAndPosition(Canvas canvas);

        void Render(Canvas canvas);
    }
}
