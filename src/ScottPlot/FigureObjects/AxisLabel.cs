using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using ScottPlot;
using ScottPlot.Drawing;

namespace ScottPlot.FigureObject
{
    public abstract class AxisLabel
    {
        public bool IsVisible { get; set; } = true;
        public double MinimumWidth { get; set; } = 0;
        public double MinimumHeight { get; set; } = 0;
        public Layer Layer { get { return Layer.FigureBelowData; } set { } }

        // customizable properties
        public string text { get; set; }
        public Color fontColor { get; set; } = Color.Black;
        public Color backColor { get; set; } = Color.LightBlue;
        public Alignment alignment = Alignment.Center;

        public abstract (double x, double y, double width, double height) GetSizeAndPosition(Canvas canvas);
        public float angle = 0;

        public void Render(Canvas canvas)
        {
            if (IsVisible == false)
                return;

            using (Graphics gfx = Graphics.FromImage(canvas.Bmp))
            using (Font font = new Font(FontFamily.GenericSansSerif, 16))
            using (Brush fontBrush = new SolidBrush(fontColor))
            using (Brush backBrush = new SolidBrush(backColor))
            using (StringFormat sf = GDI.StringFormat(alignment))
            {
                var (x, y, width, height) = GetSizeAndPosition(canvas);
                RectangleF rect = new RectangleF((float)x, (float)y, (float)width, (float)height);

                if (backColor != Color.Transparent)
                    gfx.FillRectangle(backBrush, rect);

                if (angle == 0)
                {
                    gfx.DrawString(text, font, fontBrush, rect, sf);
                }
                else
                {
                    GraphicsState state = gfx.Save();
                    gfx.ResetTransform();
                    gfx.RotateTransform(angle);
                    gfx.TranslateTransform(rect.X, rect.Y + rect.Height, MatrixOrder.Append);
                    RectangleF rect2 = new RectangleF(0, 0, rect.Height, rect.Width);
                    gfx.DrawString(text, font, fontBrush, rect2, sf);
                    gfx.Restore(state);
                }
            }
        }
    }
}
