using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ScottPlot.FigureObjects
{
    public abstract class Ticks
    {
        public bool IsVisible { get; set; } = true;
        public double MinimumWidth { get; set; } = 0;
        public double MinimumHeight { get; set; } = 0;
        public bool IsBelowData { get { return true; } set { } }

        // customizable properties
        public Color tickColor { get; set; } = Color.Black;
        public float tickLength = 3;
        public Color gridColor { get; set; } = Color.LightGray;
    }
}
