using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ScottPlot.FigureObjects
{
    public abstract class Ticks
    {
        public bool IsAntiAliased { get; set; } = true;

        // customizable properties
        public Color tickColor { get; set; } = Color.Black;
        public float tickLength = 3;
        public Color gridColor { get; set; } = Color.LightGray;
    }
}
