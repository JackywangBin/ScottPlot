using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using ScottPlot.Drawing;

namespace ScottPlot.FigureObjects
{
    class TicksSouth : Ticks, IRenderable
    {
        public TicksSouth()
        {
        }

        public void Render(Canvas canvas)
        {
            // determine tick coordinates
            List<double> tickCoords = new List<double>();
            double nextTickPosition = canvas.PlotXmin;
            while (nextTickPosition <= canvas.PlotXmax)
            {
                tickCoords.Add(nextTickPosition);
                nextTickPosition += 1;
            }

            // draw the ticks
            using (Graphics gfx = Graphics.FromImage(canvas.Bmp))
            using (Pen tickLinePen = new Pen(tickColor))
            using (Pen gridLinePen = new Pen(gridColor))
            using (Font font = new Font(FontFamily.GenericSansSerif, 10))
            using (Brush labelBrush = new SolidBrush(Color.Black))
            using (StringFormat sf = Drawing.GDI.StringFormat(Alignment.North))
            {
                if (IsAntiAliased)
                {
                    gfx.SmoothingMode = SmoothingMode.AntiAlias;
                    gfx.TextRenderingHint = TextRenderingHint.AntiAlias;
                }

                for (int i = 0; i < tickCoords.Count; i++)
                {
                    double coordinateX = tickCoords[i];
                    float pxX = canvas.PixelX(coordinateX);
                    float pxY = canvas.Height - canvas.PlotPadB;
                    float pxTopEdge = canvas.PlotPadT;
                    string label = $"{coordinateX}";

                    // draw tick
                    gfx.DrawLine(tickLinePen, pxX, pxY, pxX, pxY + tickLength);

                    // draw grid line
                    gfx.DrawLine(gridLinePen, pxX, pxY, pxX, pxTopEdge);

                    // draw tick label
                    float maxHalfWidth = 50;
                    float maxHeight = 20;
                    RectangleF labelRect = new RectangleF(
                        x: pxX - maxHalfWidth,
                        y: pxY + tickLength,
                        width: maxHalfWidth * 2,
                        height: maxHeight);
                    gfx.DrawString(label, font, labelBrush, labelRect, sf);
                }
            }
        }
    }
}
