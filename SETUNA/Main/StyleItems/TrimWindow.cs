namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    internal sealed class TrimWindow : ScrapDrawForm
    {
        private Rectangle _areabottom;
        private Rectangle _arealeft;
        private Rectangle _arearight;
        private Rectangle _areatop;
        private bool _drag;
        private Locate _locmouse;
        private Locate _locsel;
        private int _sbottom;
        private int _sleft;
        private int _sright;
        private int _stop;
        private Pen penCenter;

        public TrimWindow(ScrapBase scrap) : base(scrap)
        {
            this.penCenter = new Pen(Color.Gray);
            this.penCenter.DashStyle = DashStyle.Dot;
            this.TrimRight = scrap.Image.Width;
            this.TrimBottom = scrap.Image.Height;
            this.TrimLeft = 0;
            this.TrimTop = 0;
            this._locmouse = Locate.None;
            this._locsel = Locate.None;
            this._drag = false;
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x124, 0x10a);
            base.Name = "TrimWindow";
            base.ResumeLayout(false);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (this._locsel != Locate.None)
            {
                if ((this._locsel & Locate.Left) != Locate.None)
                {
                    this.TrimLeft = 0;
                }
                if ((this._locsel & Locate.Right) != Locate.None)
                {
                    this.TrimRight = base._scrap.Image.Width;
                }
                if ((this._locsel & Locate.Top) != Locate.None)
                {
                    this.TrimTop = 0;
                }
                if ((this._locsel & Locate.Bottom) != Locate.None)
                {
                    this.TrimBottom = base._scrap.Image.Height;
                }
                this.Refresh();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Left)
            {
                if ((this._locsel & Locate.Left) != Locate.None)
                {
                    this.TrimLeft--;
                }
                if ((this._locsel & Locate.Right) != Locate.None)
                {
                    this.TrimRight--;
                }
                this.Refresh();
            }
            else if (e.KeyCode == Keys.Right)
            {
                if ((this._locsel & Locate.Left) != Locate.None)
                {
                    this.TrimLeft++;
                }
                if ((this._locsel & Locate.Right) != Locate.None)
                {
                    this.TrimRight++;
                }
                this.Refresh();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if ((this._locsel & Locate.Top) != Locate.None)
                {
                    this.TrimTop--;
                }
                if ((this._locsel & Locate.Bottom) != Locate.None)
                {
                    this.TrimBottom--;
                }
                this.Refresh();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if ((this._locsel & Locate.Top) != Locate.None)
                {
                    this.TrimTop++;
                }
                if ((this._locsel & Locate.Bottom) != Locate.None)
                {
                    this.TrimBottom++;
                }
                this.Refresh();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                base.DialogResult = DialogResult.Cancel;
                base.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this._locsel = this._locmouse;
            this._drag = this._locsel != Locate.None;
            this.Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!this._drag)
            {
                bool flag2;
                bool flag3;
                bool flag4;
                bool flag = flag2 = flag3 = flag4 = false;
                this._locmouse = Locate.None;
                if (this._arealeft.IntersectsWith(new Rectangle(e.X, e.Y, 1, 1)))
                {
                    flag = true;
                    this._locmouse |= Locate.Left;
                }
                else if (this._arearight.IntersectsWith(new Rectangle(e.X, e.Y, 1, 1)))
                {
                    flag2 = true;
                    this._locmouse |= Locate.Right;
                }
                if (this._areatop.IntersectsWith(new Rectangle(e.X, e.Y, 1, 1)))
                {
                    flag3 = true;
                    this._locmouse |= Locate.Top;
                }
                else if (this._areabottom.IntersectsWith(new Rectangle(e.X, e.Y, 1, 1)))
                {
                    flag4 = true;
                    this._locmouse |= Locate.Bottom;
                }
                if ((flag && flag3) || (flag2 && flag4))
                {
                    this.Cursor = Cursors.SizeNWSE;
                }
                else if ((flag && flag4) || (flag2 && flag3))
                {
                    this.Cursor = Cursors.SizeNESW;
                }
                else if (flag || flag2)
                {
                    this.Cursor = Cursors.SizeWE;
                }
                else if (flag3 || flag4)
                {
                    this.Cursor = Cursors.SizeNS;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                if ((this._locsel & Locate.Left) != Locate.None)
                {
                    this.TrimLeft = e.X - 50;
                }
                if ((this._locsel & Locate.Right) != Locate.None)
                {
                    this.TrimRight = e.X - 50;
                }
                if ((this._locsel & Locate.Top) != Locate.None)
                {
                    this.TrimTop = e.Y - 50;
                }
                if ((this._locsel & Locate.Bottom) != Locate.None)
                {
                    this.TrimBottom = e.Y - 50;
                }
                this.Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this._drag = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(base._scrap.Image, this.TrimLeft + 50, this.TrimTop + 50, new Rectangle(this.TrimLeft, this.TrimTop, (this.TrimRight - this.TrimLeft) + 1, (this.TrimBottom - this.TrimTop) + 1), GraphicsUnit.Pixel);
            e.Graphics.DrawLine(this.penCenter, new PointF(((((float) this.TrimRectangle.Width) / 2f) + this.TrimLeft) + 50f, 50f), new PointF(((((float) this.TrimRectangle.Width) / 2f) + this.TrimLeft) + 50f, base._baseimg.Height - 50f));
            e.Graphics.DrawLine(this.penCenter, new PointF(0f, ((((float) this.TrimRectangle.Height) / 2f) + this.TrimTop) + 50f), new PointF((float) base._baseimg.Width, ((((float) this.TrimRectangle.Height) / 2f) + this.TrimTop) + 50f));
            e.Graphics.DrawLine(Pens.SkyBlue, new Point((this.TrimLeft - 1) + 50, 0), new Point((this.TrimLeft - 1) + 50, base._baseimg.Height));
            e.Graphics.DrawLine(Pens.SkyBlue, new Point(this.TrimRight + 50, 0), new Point(this.TrimRight + 50, base._baseimg.Height));
            e.Graphics.DrawLine(Pens.SkyBlue, new Point(0, (this.TrimTop - 1) + 50), new Point(base._baseimg.Width, (this.TrimTop - 1) + 50));
            e.Graphics.DrawLine(Pens.SkyBlue, new Point(0, this.TrimBottom + 50), new Point(base._baseimg.Width, this.TrimBottom + 50));
            if ((this._locsel & Locate.Left) != Locate.None)
            {
                e.Graphics.DrawLine(Pens.Orange, new Point((this.TrimLeft - 1) + 50, 0), new Point((this.TrimLeft - 1) + 50, base._baseimg.Height));
            }
            if ((this._locsel & Locate.Right) != Locate.None)
            {
                e.Graphics.DrawLine(Pens.Orange, new Point(this.TrimRight + 50, 0), new Point(this.TrimRight + 50, base._baseimg.Height));
            }
            if ((this._locsel & Locate.Top) != Locate.None)
            {
                e.Graphics.DrawLine(Pens.Orange, new Point(0, (this.TrimTop - 1) + 50), new Point(base._baseimg.Width, (this.TrimTop - 1) + 50));
            }
            if ((this._locsel & Locate.Bottom) != Locate.None)
            {
                e.Graphics.DrawLine(Pens.Orange, new Point(0, this.TrimBottom + 50), new Point(base._baseimg.Width, this.TrimBottom + 50));
            }
            e.Graphics.DrawString(this.TrimRectangle.Width.ToString() + " x " + this.TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, (float) 2f, (float) 3f);
            e.Graphics.DrawString(this.TrimRectangle.Width.ToString() + " x " + this.TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, (float) 3f, (float) 2f);
            e.Graphics.DrawString(this.TrimRectangle.Width.ToString() + " x " + this.TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, (float) 4f, (float) 3f);
            e.Graphics.DrawString(this.TrimRectangle.Width.ToString() + " x " + this.TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, (float) 3f, (float) 4f);
            e.Graphics.DrawString(this.TrimRectangle.Width.ToString() + " x " + this.TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, (float) 2f, (float) 2f);
            e.Graphics.DrawString(this.TrimRectangle.Width.ToString() + " x " + this.TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, (float) 4f, (float) 2f);
            e.Graphics.DrawString(this.TrimRectangle.Width.ToString() + " x " + this.TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, (float) 2f, (float) 4f);
            e.Graphics.DrawString(this.TrimRectangle.Width.ToString() + " x " + this.TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.Black, (float) 4f, (float) 4f);
            e.Graphics.DrawString(this.TrimRectangle.Width.ToString() + " x " + this.TrimRectangle.Height.ToString(), Control.DefaultFont, Brushes.White, (float) 3f, (float) 3f);
        }

        public int TrimBottom
        {
            get{return  
                this._sbottom;}
            set
            {
                if (value < (this.TrimTop + 10))
                {
                    value = this.TrimTop + 10;
                }
                if (value > base._scrap.Image.Height)
                {
                    value = base._scrap.Image.Height;
                }
                this._sbottom = value;
                this._areabottom.X = 0;
                this._areabottom.Y = (this.TrimBottom - 3) + 50;
                this._areabottom.Width = base.Width;
                this._areabottom.Height = 7;
            }
        }

        public int TrimLeft
        {
            get{return  
                this._sleft;}
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > (this.TrimRight - 10))
                {
                    value = this.TrimRight - 10;
                }
                this._sleft = value;
                this._arealeft.X = ((this.TrimLeft - 1) - 3) + 50;
                this._arealeft.Y = 0;
                this._arealeft.Width = 7;
                this._arealeft.Height = base.Height;
            }
        }

        public Rectangle TrimRectangle =>
            new Rectangle { 
                Width=this.TrimRight - this.TrimLeft,
                Height=this.TrimBottom - this.TrimTop
            };

        public int TrimRight
        {
            get{return  
                this._sright;}
            set
            {
                if (value < (this.TrimLeft + 10))
                {
                    value = this.TrimLeft + 10;
                }
                if (value > base._scrap.Image.Width)
                {
                    value = base._scrap.Image.Width;
                }
                this._sright = value;
                this._arearight.X = (this.TrimRight - 3) + 50;
                this._arearight.Y = 0;
                this._arearight.Width = 7;
                this._arearight.Height = base.Height;
            }
        }

        public int TrimTop
        {
            get{return  
                this._stop;}
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > (this.TrimBottom - 10))
                {
                    value = this.TrimBottom - 10;
                }
                this._stop = value;
                this._areatop.X = 0;
                this._areatop.Y = ((this.TrimTop - 1) - 3) + 50;
                this._areatop.Width = base.Width;
                this._areatop.Height = 7;
            }
        }

        private enum Locate
        {
            Bottom = 8,
            Left = 1,
            None = 0,
            Right = 2,
            Top = 4
        }
    }
}

