namespace SETUNA.Main
{
    using SETUNA.Main.Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public sealed class CaptureInfo : Form
    {
        private bool _isDrag;
        private System.Drawing.Image baseImage;
        private Color colMouse;
        private IContainer components;
        private bool isActive;
        private Point ptMouse;
        private Point ptStart;
        private Thread trd;
        private LayerInfo mLayerInfo;

        public CaptureInfo()
        {
            this.InitializeComponent();
            this.baseImage = null;
            base.Top = 100;
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
        }

        private void CaptureInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.trd != null)
            {
                this.trd.Abort();
            }
        }

        private void CaptureInfo_Load(object sender, EventArgs e)
        {
        }

        private void CaptureInfo_MouseDown(object sender, MouseEventArgs e)
        {
            this.ptStart = new Point(e.X, e.Y);
            this.isActive = true;
            base.Opacity = 0.5;
            this.Refresh();
        }

        private void CaptureInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isActive)
            {
                base.Left += e.X - this.ptStart.X;
                base.Top += e.Y - this.ptStart.Y;
                this.Refresh();
            }
        }

        private void CaptureInfo_MouseUp(object sender, MouseEventArgs e)
        {
            this.isActive = false;
            base.Opacity = 1.0;
            this.Refresh();
        }

        private void CaptureInfo_Paint(object sender, PaintEventArgs e)
        {
            if (this.isActive || (this.baseImage == null))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, base.Width, base.Height);
            }
            else
            {
                e.Graphics.DrawImageUnscaled(this.baseImage, -base.Left, -base.Top, base.Width, base.Height);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(180, 0, 0, 0)), 0, 0, base.Width, base.Height);
            }
            Point point = new Point(10, 10);
            Font font = new Font("Segoe UI Symbol", 9f);
            e.Graphics.DrawString("X:" + this.ptMouse.X.ToString(), font, new SolidBrush(Color.White), (PointF) point);
            e.Graphics.DrawString("Y:" + this.ptMouse.Y.ToString(), font, new SolidBrush(Color.White), (float) point.X, (point.Y + font.GetHeight()) + 3f);
            if (this._isDrag)
            {
                e.Graphics.DrawString("W:" + Math.Abs((int) (this.ptMouse.X - this.ptStart.X)).ToString(), font, new SolidBrush(Color.White), (float) (point.X + 50), (float) point.Y);
                e.Graphics.DrawString("H:" + Math.Abs((int) (this.ptMouse.Y - this.ptStart.Y)).ToString(), font, new SolidBrush(Color.White), (float) (point.X + 50), (point.Y + font.GetHeight()) + 3f);
            }
            else
            {
                e.Graphics.DrawString("W:----", font, new SolidBrush(Color.White), (float) (point.X + 50), (float) point.Y);
                e.Graphics.DrawString("H:----", font, new SolidBrush(Color.White), (float) (point.X + 50), (point.Y + font.GetHeight()) + 3f);
            }
            point.Y += 40;
            e.Graphics.FillRectangle(new SolidBrush(this.colMouse), new Rectangle(point.X, point.Y, 30, 30));
            e.Graphics.DrawString("红：" + this.colMouse.R.ToString(), font, new SolidBrush(Color.White), (float) (point.X + 0x23), (float) point.Y);
            point.Y += ((int) font.GetHeight()) + 3;
            e.Graphics.DrawString("绿：" + this.colMouse.G.ToString(), font, new SolidBrush(Color.White), (float) (point.X + 0x23), (float) point.Y);
            point.Y += ((int) font.GetHeight()) + 3;
            e.Graphics.DrawString("蓝：" + this.colMouse.B.ToString(), font, new SolidBrush(Color.White), (float) (point.X + 0x23), (float) point.Y);
            point.Y += ((int) font.GetHeight()) + 3;
            string introduced12 = this.colMouse.R.ToString("X2");
            string introduced13 = this.colMouse.G.ToString("X2");
            e.Graphics.DrawString("#:" + introduced12 + introduced13 + this.colMouse.B.ToString("X2"), font, new SolidBrush(Color.White), (float) (point.X + 0x23), (float) point.Y);
        }

        private void CaptureInfo_Shown(object sender, EventArgs e)
        {
            this.trd = new Thread(new ThreadStart(this.ThreadTask));
            this.trd.IsBackground = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        ~CaptureInfo()
        {
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            base.ClientSize = new Size(110, 0x83);
            base.ControlBox = false;
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(100, 200);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "CaptureInfo";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "info";
            base.TopMost = true;
            base.Load += new EventHandler(this.CaptureInfo_Load);
            base.MouseUp += new MouseEventHandler(this.CaptureInfo_MouseUp);
            base.Paint += new PaintEventHandler(this.CaptureInfo_Paint);
            base.Shown += new EventHandler(this.CaptureInfo_Shown);
            base.MouseDown += new MouseEventHandler(this.CaptureInfo_MouseDown);
            base.FormClosing += new FormClosingEventHandler(this.CaptureInfo_FormClosing);
            base.MouseMove += new MouseEventHandler(this.CaptureInfo_MouseMove);
            base.ResumeLayout(false);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.baseImage != null)
            {
                this.baseImage.Dispose();
            }
            this.baseImage = null;
            base.OnClosing(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        private void RefreshInfo()
        {
            this.Refresh();
        }

        private void ThreadTask()
        {
            while (true)
            {
                base.Invoke(new RefreshDelegate(this.RefreshInfo));
                Thread.Sleep(100);
            }
        }

        private void timRefresh_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        public System.Drawing.Image Image
        {
            set
            {
                this.baseImage = (System.Drawing.Image) value.Clone();
            }
        }

        public bool IsSelecting
        {
            get{return  
                this._isDrag;}
            set
            {
                this._isDrag = value;
            }
        }

        public Color MouseColor
        {
            get{return  
                this.colMouse;}
            set
            {
                this.colMouse = value;
            }
        }

        public Point MouseLocation
        {
            get{return  
                this.ptMouse;}
            set
            {
                this.ptMouse = value;
            }
        }

        public Point StartPoint
        {
            get{return  
                this.ptStart;}
            set
            {
                this.ptStart = value;
            }
        }

        private delegate void RefreshDelegate();
    }
}

