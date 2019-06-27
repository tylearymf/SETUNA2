namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class CompactScrap : Form
    {
        private Point _clickpoint;
        private bool _dragmode;
        private Point _dragpoint;
        private Pen _pen;
        private ScrapBase _scrap;
        private Image _thumbnail;
        private IContainer components;

        public CompactScrap(ScrapBase scrap, CCompactStyleItem item, Point clickpoint)
        {
            this.InitializeComponent();
            this._scrap = scrap;
            this._thumbnail = scrap.GetViewImage();
            this._dragmode = false;
            if (clickpoint == Point.Empty)
            {
                this._clickpoint = new Point(base.Width / 2, base.Height / 2);
            }
            else
            {
                this._clickpoint = clickpoint;
            }
            this._pen = new Pen(Color.FromArgb(item.LineColor), 1f);
            if (!item.SoldLine)
            {
                this._pen.DashStyle = DashStyle.Dash;
                this._pen.DashPattern = new float[] { 4f, 4f };
            }
            else
            {
                this._pen.DashStyle = DashStyle.Solid;
            }
            if (item.LineColor == Color.Fuchsia.ToArgb())
            {
                this.BackColor = Color.Magenta;
                base.TransparencyKey = Color.Magenta;
            }
            base.Opacity = ((double)item.Opacity) / 100.0;
        }

        private void CompactScrap_DoubleClick(object sender, EventArgs e)
        {
            _scrap.ApplyStyles(null, Point.Empty);
            this._thumbnail.Dispose();
            base.Close();
        }

        private void CompactScrap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._scrap != null)
            {
                int num = (base.Left + (base.Width / 2)) - this._clickpoint.X;
                int num2 = (base.Top + (base.Height / 2)) - this._clickpoint.Y;
                this._scrap.Left = num;
                this._scrap.Top = num2;
                if (!this._scrap.Visible)
                {
                    this._scrap.Visible = true;
                }
            }
        }

        private void CompactScrap_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.Enter)) || (e.KeyCode == Keys.Enter))
            {
                base.Close();
            }
        }

        private void CompactScrap_Leave(object sender, EventArgs e)
        {
            this.DragEnd();
        }

        private void CompactScrap_Load(object sender, EventArgs e)
        {
            if (this._scrap != null)
            {
                if (this._scrap.Visible)
                {
                    this._scrap.Visible = false;
                }

                int num = 0;
                int num2 = 0;
                if (_scrap.isFirstInitCompactScrap && _scrap.cacheInfo != null)
                {
                    _scrap.isFirstInitCompactScrap = false;
                    num = _scrap.cacheInfo.posX;
                    num2 = _scrap.cacheInfo.posY;
                }
                else
                {
                    num = (this._scrap.Left + this._clickpoint.X) - (base.Width / 2);
                    num2 = (this._scrap.Top + this._clickpoint.Y) - (base.Height / 2);
                }

                base.Left = num;
                base.Top = num2;
            }
        }

        private void CompactScrap_MouseDown(object sender, MouseEventArgs e)
        {
            this.DragStart(e.Location);
        }

        private void CompactScrap_MouseMove(object sender, MouseEventArgs e)
        {
            this.DragMove(e.Location);
        }

        private void CompactScrap_MouseUp(object sender, MouseEventArgs e)
        {
            this.DragEnd();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DragEnd()
        {
            this._dragmode = false;

            if (_scrap.cacheInfo.posX != base.Left || _scrap.cacheInfo.posY != base.Top)
            {
                _scrap.cacheInfo.posX = base.Left;
                _scrap.cacheInfo.posY = base.Top;
                _scrap.ApplyCache();
            }
        }

        private void DragMove(Point pt)
        {
            if (this._dragmode)
            {
                base.Left += pt.X - this._dragpoint.X;
                base.Top += pt.Y - this._dragpoint.Y;
            }
        }

        private void DragStart(Point pt)
        {
            this._dragmode = true;
            this._dragpoint = pt;
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Fuchsia;
            base.ClientSize = new Size(50, 50);
            base.ControlBox = false;
            base.FormBorderStyle = FormBorderStyle.None;
            this.MaximumSize = new Size(50, 50);
            this.MinimumSize = new Size(50, 50);
            base.Name = "CompactScrap";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            this.Text = "CompactScrap";
            base.TopMost = true;
            base.TransparencyKey = Color.Fuchsia;
            base.Load += new EventHandler(this.CompactScrap_Load);
            base.MouseUp += new MouseEventHandler(this.CompactScrap_MouseUp);
            base.DoubleClick += new EventHandler(this.CompactScrap_DoubleClick);
            base.FormClosed += new FormClosedEventHandler(this.CompactScrap_FormClosed);
            base.Leave += new EventHandler(this.CompactScrap_Leave);
            base.MouseDown += new MouseEventHandler(this.CompactScrap_MouseDown);
            base.MouseMove += new MouseEventHandler(this.CompactScrap_MouseMove);
            base.KeyDown += new KeyEventHandler(this.CompactScrap_KeyDown);
            base.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(this._thumbnail, new Point(-this._clickpoint.X + (base.Width / 2), -this._clickpoint.Y + (base.Height / 2)));
            e.Graphics.DrawRectangle(Pens.White, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
            e.Graphics.DrawRectangle(this._pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
        }
    }
}

