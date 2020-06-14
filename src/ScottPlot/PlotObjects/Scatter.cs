using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ScottPlot.PlotObjects
{
    public class Scatter : IRenderable
    {
        public double[] Xs { get; private set; }
        public double[] Ys { get; private set; }
        public bool IsAntiAliased { get; set; } = true;

        // customizable options
        public float markerSize = 5;
        public float lineWidth = 1;
        public Color color = Color.Magenta;

        public Scatter(double[] xs, double[] ys)
        {
            Update(xs, ys);
        }

        public void Update(double[] xs, double[] ys)
        {
            if (xs is null || ys is null)
                throw new ArgumentException("xs and ys cannot be null");

            if (xs.Length != ys.Length)
                throw new ArgumentException("xs and ys must have the same length");

            Xs = xs;
            Ys = ys;
        }

        public void UpdateXs(double[] xs)
        {
            if (xs is null)
                throw new ArgumentException("xs cannot be null");

            if (xs.Length != Ys.Length)
                throw new ArgumentException("xs and ys must have the same length");

            Xs = xs;
        }

        public void UpdateYs(double[] ys)
        {
            if (ys is null)
                throw new ArgumentException("ys cannot be null");

            if (ys.Length != Xs.Length)
                throw new ArgumentException("xs and ys must have the same length");

            Ys = ys;
        }

        public void Render(Canvas canvas)
        {
            using (var gfx = Graphics.FromImage(canvas.Bmp))
            using (var brush = new SolidBrush(color))
            using (var pen = new Pen(color))
            {
                RectangleF clipRect = new Rectangle(canvas.PlotLocation.x, canvas.PlotLocation.y, canvas.PlotSize.width, canvas.PlotSize.height);
                gfx.Clip = new Region(clipRect);

                if (IsAntiAliased)
                    gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                PointF[] points = new PointF[Xs.Length];
                for (int i = 0; i < Xs.Length; i++)
                    points[i] = new PointF(canvas.PixelX(Xs[i]), canvas.PixelY(Ys[i]));

                if (markerSize > 0)
                    foreach (var point in points)
                        gfx.FillEllipse(brush, point.X - markerSize, point.Y - markerSize, markerSize * 2, markerSize * 2);

                if (lineWidth > 0)
                    gfx.DrawLines(pen, points);
            }
        }
    }
}
