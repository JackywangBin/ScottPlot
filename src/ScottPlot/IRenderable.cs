using System;
using System.Collections.Generic;
using System.Text;
using ScottPlot.Drawing;

namespace ScottPlot
{
    public interface IRenderable
    {
        void Render(Canvas canvas);
    }
}
