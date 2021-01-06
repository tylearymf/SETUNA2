using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x020000A5 RID: 165
    public class PenToolCommand : ToolCommand
    {
        // Token: 0x06000557 RID: 1367 RVA: 0x00024AEC File Offset: 0x00022CEC
        public PenToolCommand(Color color, float pen_width)
        {
            _pen = new Pen(color, pen_width)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };
            _points = new List<Point>();
        }

        // Token: 0x06000558 RID: 1368 RVA: 0x00024B24 File Offset: 0x00022D24
        public void AddPoint(Point pt)
        {
            _points.Add(pt);
        }

        // Token: 0x06000559 RID: 1369 RVA: 0x00024B32 File Offset: 0x00022D32
        public override void Draw(Graphics g)
        {
            if (_points.Count > 2)
            {
                g.DrawCurve(_pen, _points.ToArray());
            }
        }

        // Token: 0x0600055A RID: 1370 RVA: 0x00024B59 File Offset: 0x00022D59
        public override void Dispose()
        {
        }

        // Token: 0x04000355 RID: 853
        private Pen _pen;

        // Token: 0x04000356 RID: 854
        private List<Point> _points;
    }
}
