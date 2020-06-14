using System;
using System.Collections.Generic;
using System.Text;
using ScottPlot.Drawing;

namespace ScottPlot
{
    public interface IRenderable
    {
        bool IsAntiAliased { get; set; }
        void Render(Canvas canvas);
    }
}
