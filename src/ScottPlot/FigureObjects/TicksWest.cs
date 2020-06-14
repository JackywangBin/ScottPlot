using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ScottPlot.Drawing;

namespace ScottPlot.FigureObjects
{
    public class TicksWest : Ticks, IRenderable
    {
        public TicksWest()
        {
        }

        public void Render(Canvas canvas)
        {
            // determine tick coordinates
            List<double> tickCoords = new List<double>();
            double nextTickPosition = canvas.PlotYmin;
            while (nextTickPosition <= canvas.PlotYmax)
            {
                tickCoords.Add(nextTickPosition);
                nextTickPosition += .2;
            }

            using (Graphics gfx = Graphics.FromImage(canvas.Bmp))
            using (Pen tickLinePen = new Pen(tickColor))
            using (Pen gridLinePen = new Pen(gridColor))
            using (Font font = new Font(FontFamily.GenericSansSerif, 10))
            using (Brush labelBrush = new SolidBrush(Color.Black))
            using (StringFormat sf = Drawing.GDI.StringFormat(Alignment.East))
            {
                for (int i = 0; i < tickCoords.Count; i++)
                {
                    double coordinateY = tickCoords[i];
                    float pxX = canvas.PlotPadL;
                    float pxY = canvas.PixelY(coordinateY);
                    string label = $"{Math.Round(coordinateY, 8)}";

                    // draw tick
                    gfx.DrawLine(tickLinePen, pxX, pxY, pxX - tickLength, pxY);

                    // draw grid line
                    gfx.DrawLine(gridLinePen, pxX, pxY, canvas.Width - canvas.PlotPadR, pxY);

                    // draw tick label
                    float maxHalfWidth = 50;
                    float maxHeight = 20;
                    RectangleF labelRect = new RectangleF(
                        x: pxX - maxHalfWidth * 2 - tickLength,
                        y: pxY - maxHeight,
                        width: maxHalfWidth * 2,
                        height: maxHeight * 2);
                    gfx.DrawString(label, font, labelBrush, labelRect, sf);
                }
            }
        }
    }
}
