using System;
using System.Collections.Generic;
using System.Text;
using ScottPlot.Drawing;

namespace ScottPlot
{
    public enum Layer
    {
        FigureBackground, // probably only thing that belongs here is the background fill
        FigureBelowData, // axis labels, ticks, and tick labels make sense here
        DataArea, // probably only thing that belongs here is data fill and grid
        AboveData // things like above-plot annotations, arrows, and legend
    };

    public interface IFigureObject
    {
        bool IsVisible { get; set; }
        double MinimumWidth { get; set; }
        double MinimumHeight { get; set; }
        Layer Layer { get; set; }

        (double x, double y, double width, double height) GetSizeAndPosition(Canvas canvas);

        void Render(Canvas canvas);
    }
}
