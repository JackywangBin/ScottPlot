using System;
using System.Collections.Generic;
using System.Text;

namespace ScottPlot
{
    public enum Layer
    {
        Background, // probably only thing that belongs here is the background fill
        BeforeDataFill, // axis labels, ticks, and tick labels make sense here
        DataBackground, // probably only thing that belongs here is data fill and grid
        AfterPlottables // things like above-plot annotations, arrows, and legend
    };

    public interface IFigureObject
    {
        bool IsVisible { get; set; }
        double MinimumWidth { get; set; }
        double MinimumHeight { get; set; }
        Layer Layer { get; set; }

        (double width, double height) GetSize();
        (double x, double y) GetPosition();

        void Render(Settings settings);
    }
}
