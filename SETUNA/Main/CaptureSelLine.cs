namespace SETUNA.Main
{
    using SETUNA.Main.Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public sealed class CaptureSelLine : Form
    {
        private SelLineType _linetype;
        private IContainer components;
        private static int DashOffset;
        private int lastw;
        private int lastx;
        private float[] pat;
        private Pen penBack;
        private Pen penLine;
        private Pen penWhite;
        private Point ptSel;
        private Size szSel;
        private LayerInfo mLayerInfo;

        public CaptureSelLine()
        {
            this.InitializeComponent();
            base.Width = 1;
            base.Height = 1;
            this._linetype = SelLineType.Horizon;
        }

        public CaptureSelLine(SelLineType linetype, bool issolid, Color linecolor)
        {
            this._linetype = linetype;
            this.InitializeComponent();
            this.pat = new float[] { 4f, 4f };
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.penBack = new Pen(new SolidBrush(Color.Fuchsia), 1f);
            this.penLine = new Pen(linecolor, 1f);
            this.SetPen(issolid, linecolor);
            base.TransparencyKey = Color.Fuchsia;
            this.penWhite = new Pen(new SolidBrush(Color.White), 1f);
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
        }

        public static void AddDashOffset()
        {
            DashOffset++;
            if (DashOffset > 7)
            {
                DashOffset = 0;
            }
        }

        private void CaptureSelLine_Paint(object sender, PaintEventArgs e)
        {
            if (this.penLine != null)
            {
                if (this._linetype == SelLineType.Horizon)
                {
                    e.Graphics.DrawLine(this.penWhite, new Point(this.ptSel.X, 0), new Point((this.ptSel.X + this.szSel.Width) - 1, 0));
                    e.Graphics.DrawLine(this.penLine, new Point(this.ptSel.X + DashOffset, 0), new Point((this.ptSel.X + this.szSel.Width) - 1, 0));
                    if (DashOffset > 4)
                    {
                        e.Graphics.DrawLine(this.penLine, new Point(this.ptSel.X, 0), new Point(this.ptSel.X + (DashOffset - 4), 0));
                    }
                }
                else
                {
                    e.Graphics.DrawLine(this.penWhite, new Point(0, this.ptSel.Y), new Point(0, (this.ptSel.Y + this.szSel.Height) - 1));
                    e.Graphics.DrawLine(this.penLine, new Point(0, this.ptSel.Y + DashOffset), new Point(0, (this.ptSel.Y + this.szSel.Height) - 1));
                    if (DashOffset > 4)
                    {
                        e.Graphics.DrawLine(this.penLine, new Point(0, this.ptSel.Y), new Point(0, this.ptSel.Y + (DashOffset - 4)));
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.Fuchsia;
            this.BackgroundImageLayout = ImageLayout.None;
            base.ClientSize = new Size(1, 1);
            base.ControlBox = false;
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.None;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            this.MinimumSize = new Size(1, 1);
            base.Name = "CaptureSelLine";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            base.TopMost = true;
            base.TransparencyKey = Color.Transparent;
            base.Paint += new PaintEventHandler(this.CaptureSelLine_Paint);
            base.ResumeLayout(false);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        public void SetPen(bool issolid, Color linecolor)
        {
            if (this.penLine.Color.ToArgb() != linecolor.ToArgb())
            {
                this.penLine = new Pen(linecolor, 1f);
            }
            if (!issolid)
            {
                this.penLine.DashStyle = DashStyle.Dash;
                this.penLine.DashPattern = this.pat;
            }
            else
            {
                this.penLine.DashStyle = DashStyle.Solid;
            }
        }

        public void SetSelSize(int x, int width)
        {
            if (this._linetype == SelLineType.Horizon)
            {
                this.ptSel.X = x;
                this.szSel.Width = width;
            }
            else
            {
                this.ptSel.Y = x;
                this.szSel.Height = width;
            }
            if ((this.lastx != x) || (this.lastw != width))
            {
                base.Invalidate();
                base.Update();
                this.lastx = x;
                this.lastw = width;
            }
        }
    }
}

