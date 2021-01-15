using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200007B RID: 123
    public partial class CompactScrap : BaseForm
    {
        // Token: 0x06000407 RID: 1031 RVA: 0x00019DF8 File Offset: 0x00017FF8
        public CompactScrap(ScrapBase scrap, CCompactStyleItem item, Point clickpoint)
        {
            InitializeComponent();
            this.scrap = scrap;
            _thumbnail = scrap.GetViewImage();
            _dragmode = false;
            if (clickpoint == Point.Empty)
            {
                _clickpoint = new Point(base.Width / 2, base.Height / 2);
            }
            else
            {
                _clickpoint = clickpoint;
            }
            _pen = new Pen(Color.FromArgb(item.LineColor), 1f);
            if (!item.SoldLine)
            {
                _pen.DashStyle = DashStyle.Dash;
                _pen.DashPattern = new float[]
                {
                    4f,
                    4f
                };
            }
            else
            {
                _pen.DashStyle = DashStyle.Solid;
            }
            if (item.LineColor == Color.Fuchsia.ToArgb())
            {
                BackColor = Color.Magenta;
                base.TransparencyKey = Color.Magenta;
            }
            base.Opacity = item.Opacity / 100.0;
        }

        // Token: 0x06000408 RID: 1032 RVA: 0x00019F00 File Offset: 0x00018100
        private void CompactScrap_Load(object sender, EventArgs e)
        {
            if (scrap != null)
            {
                //if (scrap.Visible)
                {
                    scrap.Visible = false;
                    scrap.StyleForm = this;
                }
                ConvertScrapPosToCompact();
            }
        }

        // Token: 0x06000409 RID: 1033 RVA: 0x00019F80 File Offset: 0x00018180
        private void CompactScrap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (scrap != null)
            {
                //if (!scrap.Visible)
                {
                    scrap.Visible = true;
                    scrap.StyleForm = null;
                    scrap.RemoveStyle(typeof(CCompactStyleItem));
                }
                ConvertCompactPosToScrap();
            }
        }

        // Token: 0x0600040A RID: 1034 RVA: 0x00019FFE File Offset: 0x000181FE
        private void CompactScrap_DoubleClick(object sender, EventArgs e)
        {
            _thumbnail.Dispose();
            base.Close();
        }

        // Token: 0x0600040B RID: 1035 RVA: 0x0001A014 File Offset: 0x00018214
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(_thumbnail, new Point(-_clickpoint.X + base.Width / 2, -_clickpoint.Y + base.Height / 2));
            e.Graphics.DrawRectangle(Pens.White, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
            e.Graphics.DrawRectangle(_pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
        }

        // Token: 0x0600040C RID: 1036 RVA: 0x0001A0B0 File Offset: 0x000182B0
        private void DragStart(Point pt)
        {
            _dragmode = true;
            _dragpoint = pt;
        }

        // Token: 0x0600040D RID: 1037 RVA: 0x0001A0C0 File Offset: 0x000182C0
        private void DragEnd()
        {
            _dragmode = false;
        }

        // Token: 0x0600040E RID: 1038 RVA: 0x0001A0CC File Offset: 0x000182CC
        private void DragMove(Point pt)
        {
            if (_dragmode)
            {
                base.Left += pt.X - _dragpoint.X;
                base.Top += pt.Y - _dragpoint.Y;

                if (scrap != null)
                {
                    ConvertCompactPosToScrap();
                    scrap.fireScrapLocationChangedEvent();
                }
            }
        }

        // Token: 0x0600040F RID: 1039 RVA: 0x0001A121 File Offset: 0x00018321
        private void CompactScrap_MouseDown(object sender, MouseEventArgs e)
        {
            DragStart(e.Location);
        }

        // Token: 0x06000410 RID: 1040 RVA: 0x0001A12F File Offset: 0x0001832F
        private void CompactScrap_MouseUp(object sender, MouseEventArgs e)
        {
            DragEnd();
        }

        // Token: 0x06000411 RID: 1041 RVA: 0x0001A137 File Offset: 0x00018337
        private void CompactScrap_MouseMove(object sender, MouseEventArgs e)
        {
            DragMove(e.Location);
        }

        // Token: 0x06000412 RID: 1042 RVA: 0x0001A145 File Offset: 0x00018345
        private void CompactScrap_Leave(object sender, EventArgs e)
        {
            DragEnd();
        }

        // Token: 0x06000413 RID: 1043 RVA: 0x0001A14D File Offset: 0x0001834D
        private void CompactScrap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Return || e.KeyCode == Keys.Return)
            {
                base.Close();
            }
        }

        private void ConvertScrapPosToCompact()
        {
            var left = scrap.Left + _clickpoint.X - base.Width / 2;
            var top = scrap.Top + _clickpoint.Y - base.Height / 2;
            base.Left = left;
            base.Top = top;
        }

        private void ConvertCompactPosToScrap()
        {
            var left = base.Left + base.Width / 2 - _clickpoint.X;
            var top = base.Top + base.Height / 2 - _clickpoint.Y;
            scrap.Left = left;
            scrap.Top = top;
        }


        // Token: 0x04000269 RID: 617
        public ScrapBase scrap;

        // Token: 0x0400026A RID: 618
        private Image _thumbnail;

        // Token: 0x0400026B RID: 619
        private bool _dragmode;

        // Token: 0x0400026C RID: 620
        private Point _dragpoint;

        // Token: 0x0400026D RID: 621
        private Pen _pen;

        // Token: 0x0400026E RID: 622
        private Point _clickpoint;
    }
}
