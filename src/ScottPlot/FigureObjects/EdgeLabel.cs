using System;
using System.Collections.Generic;
using System.Text;
using ScottPlot;

namespace ScottPlot.FigureObject
{
    // An EdgeLabel represents at the edge of a figure or data area (e.g., Title, XLabel, and YLabel)
    public class EdgeLabel : IFigureObject
    {
        public bool IsVisible { get; set; } = true;
        public double MinimumWidth { get; set; } = 0;
        public double MinimumHeight { get; set; } = 0;
        public Layer Layer { get; set; } = Layer.BeforeDataFill;

        public (double x, double y) GetPosition()
        {
            throw new NotImplementedException();
        }

        public (double width, double height) GetSize()
        {
            throw new NotImplementedException();
        }

        public void Render(Settings settings)
        {
            throw new NotImplementedException();
        }
    }
}
