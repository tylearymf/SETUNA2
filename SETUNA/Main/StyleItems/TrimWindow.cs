using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000073 RID: 115
    internal sealed partial class TrimWindow : ScrapDrawForm
    {
        // Token: 0x060003BC RID: 956 RVA: 0x0001684C File Offset: 0x00014A4C
        public TrimWindow(ScrapBase scrap) : base(scrap)
        {
            penCenter = new Pen(Color.Gray)
            {
                DashStyle = DashStyle.Dot
            };
            TrimRight = scrap.Image.Width;
            TrimBottom = scrap.Image.Height;
            TrimLeft = 0;
            TrimTop = 0;
            _locmouse = TrimWindow.Locate.None;
            _locsel = TrimWindow.Locate.None;
            _drag = false;
        }

        // Token: 0x1700008C RID: 140
        // (get) Token: 0x060003BE RID: 958 RVA: 0x00016937 File Offset: 0x00014B37
        // (set) Token: 0x060003BD RID: 957 RVA: 0x000168C4 File Offset: 0x00014AC4
        public int TrimLeft
        {
            get => _sleft;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > TrimRight - 10)
                {
                    value = TrimRight - 10;
                }
                _sleft = value;
                _arealeft.X = TrimLeft - 1 - 3 + 50;
                _arealeft.Y = 0;
                _arealeft.Width = 7;
                _arealeft.Height = base.Height;
            }
        }

        // Token: 0x1700008D RID: 141
        // (get) Token: 0x060003C0 RID: 960 RVA: 0x000169CF File Offset: 0x00014BCF
        // (set) Token: 0x060003BF RID: 959 RVA: 0x00016940 File Offset: 0x00014B40
        public int TrimRight
        {
            get => _sright;
            set
            {
                if (value < TrimLeft + 10)
                {
                    value = TrimLeft + 10;
                }
                if (value > _scrap.Image.Width)
                {
                    value = _scrap.Image.Width;
                }
                _sright = value;
                _arearight.X = TrimRight - 3 + 50;
                _arearight.Y = 0;
                _arearight.Width = 7;
                _arearight.Height = base.Height;
            }
        }

        // Token: 0x1700008E RID: 142
        // (get) Token: 0x060003C2 RID: 962 RVA: 0x00016A4B File Offset: 0x00014C4B
        // (set) Token: 0x060003C1 RID: 961 RVA: 0x000169D8 File Offset: 0x00014BD8
        public int TrimTop
        {
            get => _stop;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > TrimBottom - 10)
                {
                    value = TrimBottom - 10;
                }
                _stop = value;
                _areatop.X = 0;
                _areatop.Y = TrimTop - 1 - 3 + 50;
                _areatop.Width = base.Width;
                _areatop.Height = 7;
            }
        }

        // Token: 0x1700008F RID: 143
        // (get) Token: 0x060003C4 RID: 964 RVA: 0x00016AE3 File Offset: 0x00014CE3
        // (set) Token: 0x060003C3 RID: 963 RVA: 0x00016A54 File Offset: 0x00014C54
        public int TrimBottom
        {
            get => _sbottom;
            set
            {
                if (value < TrimTop + 10)
                {
                    value = TrimTop + 10;
                }
                if (value > _scrap.Image.Height)
                {
                    value = _scrap.Image.Height;
                }
                _sbottom = value;
                _areabottom.X = 0;
                _areabottom.Y = TrimBottom - 3 + 50;
                _areabottom.Width = base.Width;
                _areabottom.Height = 7;
            }
        }

        // Token: 0x17000090 RID: 144
        // (get) Token: 0x060003C5 RID: 965 RVA: 0x00016AEC File Offset: 0x00014CEC
        public Rectangle TrimRectangle => new Rectangle
        {
            Width = TrimRight - TrimLeft,
            Height = TrimBottom - TrimTop
        };

        // Token: 0x060003C6 RID: 966 RVA: 0x00016B2C File Offset: 0x00014D2C
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(_scrap.Image, TrimLeft + 50, TrimTop + 50, new Rectangle(TrimLeft, TrimTop, TrimRight - TrimLeft + 1, TrimBottom - TrimTop + 1), GraphicsUnit.Pixel);
            e.Graphics.DrawLine(penCenter, new PointF(TrimRectangle.Width / 2f + TrimLeft + 50f, 50f), new PointF(TrimRectangle.Width / 2f + TrimLeft + 50f, _baseimg.Height - 50f));
            e.Graphics.DrawLine(penCenter, new PointF(0f, TrimRectangle.Height / 2f + TrimTop + 50f), new PointF(_baseimg.Width, TrimRectangle.Height / 2f + TrimTop + 50f));
            e.Graphics.DrawLine(Pens.SkyBlue, new Point(TrimLeft - 1 + 50, 0), new Point(TrimLeft - 1 + 50, _baseimg.Height));
            e.Graphics.DrawLine(Pens.SkyBlue, new Point(TrimRight + 50, 0), new Point(TrimRight + 50, _baseimg.Height));
            e.Graphics.DrawLine(Pens.SkyBlue, new Point(0, TrimTop - 1 + 50), new Point(_baseimg.Width, TrimTop - 1 + 50));
            e.Graphics.DrawLine(Pens.SkyBlue, new Point(0, TrimBottom + 50), new Point(_baseimg.Width, TrimBottom + 50));
            if ((_locsel & TrimWindow.Locate.Left) != TrimWindow.Locate.None)
            {
                e.Graphics.DrawLine(Pens.Orange, new Point(TrimLeft - 1 + 50, 0), new Point(TrimLeft - 1 + 50, _baseimg.Height));
            }
            if ((_locsel & TrimWindow.Locate.Right) != TrimWindow.Locate.None)
            {
                e.Graphics.DrawLine(Pens.Orange, new Point(TrimRight + 50, 0), new Point(TrimRight + 50, _baseimg.Height));
            }
            if ((_locsel & TrimWindow.Locate.Top) != TrimWindow.Locate.None)
            {
                e.Graphics.DrawLine(Pens.Orange, new Point(0, TrimTop - 1 + 50), new Point(_baseimg.Width, TrimTop - 1 + 50));
            }
            if ((_locsel & TrimWindow.Locate.Bottom) != TrimWindow.Locate.None)
            {
                e.Graphics.DrawLine(Pens.Orange, new Point(0, TrimBottom + 50), new Point(_baseimg.Width, TrimBottom + 50));
            }
            e.Graphics.DrawString(TrimRectangle.Width.ToString() + " x " + TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, 2f, 3f);
            e.Graphics.DrawString(TrimRectangle.Width.ToString() + " x " + TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, 3f, 2f);
            e.Graphics.DrawString(TrimRectangle.Width.ToString() + " x " + TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, 4f, 3f);
            e.Graphics.DrawString(TrimRectangle.Width.ToString() + " x " + TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, 3f, 4f);
            e.Graphics.DrawString(TrimRectangle.Width.ToString() + " x " + TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, 2f, 2f);
            e.Graphics.DrawString(TrimRectangle.Width.ToString() + " x " + TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, 4f, 2f);
            e.Graphics.DrawString(TrimRectangle.Width.ToString() + " x " + TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, 2f, 4f);
            e.Graphics.DrawString(TrimRectangle.Width.ToString() + " x " + TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, 4f, 4f);
            e.Graphics.DrawString(TrimRectangle.Width.ToString() + " x " + TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.White, 3f, 3f);
        }

        // Token: 0x060003C7 RID: 967 RVA: 0x0001719B File Offset: 0x0001539B
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _locsel = _locmouse;
            _drag = (_locsel != TrimWindow.Locate.None);
            Refresh();
        }

        // Token: 0x060003C8 RID: 968 RVA: 0x000171C8 File Offset: 0x000153C8
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _drag = false;
        }

        // Token: 0x060003C9 RID: 969 RVA: 0x000171D8 File Offset: 0x000153D8
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (_locsel == TrimWindow.Locate.None)
            {
                return;
            }
            if ((_locsel & TrimWindow.Locate.Left) != TrimWindow.Locate.None)
            {
                TrimLeft = 0;
            }
            if ((_locsel & TrimWindow.Locate.Right) != TrimWindow.Locate.None)
            {
                TrimRight = _scrap.Image.Width;
            }
            if ((_locsel & TrimWindow.Locate.Top) != TrimWindow.Locate.None)
            {
                TrimTop = 0;
            }
            if ((_locsel & TrimWindow.Locate.Bottom) != TrimWindow.Locate.None)
            {
                TrimBottom = _scrap.Image.Height;
            }
            Refresh();
        }

        // Token: 0x060003CA RID: 970 RVA: 0x00017260 File Offset: 0x00015460
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Left)
            {
                if ((_locsel & TrimWindow.Locate.Left) != TrimWindow.Locate.None)
                {
                    TrimLeft--;
                }
                if ((_locsel & TrimWindow.Locate.Right) != TrimWindow.Locate.None)
                {
                    TrimRight--;
                }
                Refresh();
                return;
            }
            if (e.KeyCode == Keys.Right)
            {
                if ((_locsel & TrimWindow.Locate.Left) != TrimWindow.Locate.None)
                {
                    TrimLeft++;
                }
                if ((_locsel & TrimWindow.Locate.Right) != TrimWindow.Locate.None)
                {
                    TrimRight++;
                }
                Refresh();
                return;
            }
            if (e.KeyCode == Keys.Up)
            {
                if ((_locsel & TrimWindow.Locate.Top) != TrimWindow.Locate.None)
                {
                    TrimTop--;
                }
                if ((_locsel & TrimWindow.Locate.Bottom) != TrimWindow.Locate.None)
                {
                    TrimBottom--;
                }
                Refresh();
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                if ((_locsel & TrimWindow.Locate.Top) != TrimWindow.Locate.None)
                {
                    TrimTop++;
                }
                if ((_locsel & TrimWindow.Locate.Bottom) != TrimWindow.Locate.None)
                {
                    TrimBottom++;
                }
                Refresh();
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                base.DialogResult = DialogResult.Cancel;
                base.Close();
                return;
            }
            if (e.KeyCode == Keys.Return)
            {
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        // Token: 0x060003CB RID: 971 RVA: 0x000173A8 File Offset: 0x000155A8
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_drag)
            {
                if ((_locsel & TrimWindow.Locate.Left) != TrimWindow.Locate.None)
                {
                    TrimLeft = e.X - 50;
                }
                if ((_locsel & TrimWindow.Locate.Right) != TrimWindow.Locate.None)
                {
                    TrimRight = e.X - 50;
                }
                if ((_locsel & TrimWindow.Locate.Top) != TrimWindow.Locate.None)
                {
                    TrimTop = e.Y - 50;
                }
                if ((_locsel & TrimWindow.Locate.Bottom) != TrimWindow.Locate.None)
                {
                    TrimBottom = e.Y - 50;
                }
                Refresh();
                return;
            }
            bool flag4;
            bool flag3;
            bool flag2;
            var flag = flag2 = (flag3 = (flag4 = false));
            _locmouse = TrimWindow.Locate.None;
            if (_arealeft.IntersectsWith(new Rectangle(e.X, e.Y, 1, 1)))
            {
                flag2 = true;
                _locmouse |= TrimWindow.Locate.Left;
            }
            else if (_arearight.IntersectsWith(new Rectangle(e.X, e.Y, 1, 1)))
            {
                flag = true;
                _locmouse |= TrimWindow.Locate.Right;
            }
            if (_areatop.IntersectsWith(new Rectangle(e.X, e.Y, 1, 1)))
            {
                flag3 = true;
                _locmouse |= TrimWindow.Locate.Top;
            }
            else if (_areabottom.IntersectsWith(new Rectangle(e.X, e.Y, 1, 1)))
            {
                flag4 = true;
                _locmouse |= TrimWindow.Locate.Bottom;
            }
            if ((flag2 && flag3) || (flag && flag4))
            {
                Cursor = Cursors.SizeNWSE;
                return;
            }
            if ((flag2 && flag4) || (flag && flag3))
            {
                Cursor = Cursors.SizeNESW;
                return;
            }
            if (flag2 || flag)
            {
                Cursor = Cursors.SizeWE;
                return;
            }
            if (flag3 || flag4)
            {
                Cursor = Cursors.SizeNS;
                return;
            }
            Cursor = Cursors.Default;
        }

        // Token: 0x04000219 RID: 537
        private int _sleft;

        // Token: 0x0400021A RID: 538
        private int _sright;

        // Token: 0x0400021B RID: 539
        private int _stop;

        // Token: 0x0400021C RID: 540
        private int _sbottom;

        // Token: 0x0400021D RID: 541
        private Rectangle _arealeft;

        // Token: 0x0400021E RID: 542
        private Rectangle _arearight;

        // Token: 0x0400021F RID: 543
        private Rectangle _areatop;

        // Token: 0x04000220 RID: 544
        private Rectangle _areabottom;

        // Token: 0x04000221 RID: 545
        private TrimWindow.Locate _locmouse;

        // Token: 0x04000222 RID: 546
        private TrimWindow.Locate _locsel;

        // Token: 0x04000223 RID: 547
        private bool _drag;

        // Token: 0x04000224 RID: 548
        private Pen penCenter;

        // Token: 0x02000074 RID: 116
        private enum Locate
        {
            // Token: 0x04000226 RID: 550
            None,
            // Token: 0x04000227 RID: 551
            Left,
            // Token: 0x04000228 RID: 552
            Right,
            // Token: 0x04000229 RID: 553
            Top = 4,
            // Token: 0x0400022A RID: 554
            Bottom = 8
        }
    }
}
