namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class PenToolCommand : ToolCommand
    {
        private Pen _pen;
        private List<Point> _points;

        public PenToolCommand(Color color, float pen_width)
        {
            this._pen = new Pen(color, pen_width);
            this._pen.StartCap = LineCap.Round;
            this._pen.EndCap = LineCap.Round;
            this._points = new List<Point>();
        }

        public void AddPoint(Point pt)
        {
            this._points.Add(pt);
        }

        public override void Dispose()
        {
        }

        public override void Draw(Graphics g)
        {
            if (this._points.Count > 2)
            {
                g.DrawCurve(this._pen, this._points.ToArray());
            }
        }
    }
}

