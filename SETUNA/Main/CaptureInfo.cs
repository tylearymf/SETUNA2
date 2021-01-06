using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SETUNA.Main
{
    // Token: 0x020000A7 RID: 167
    public sealed partial class CaptureInfo : BaseForm
    {
        // Token: 0x06000563 RID: 1379 RVA: 0x00025A2C File Offset: 0x00023C2C
        ~CaptureInfo()
        {
        }

        // Token: 0x06000564 RID: 1380 RVA: 0x00025A54 File Offset: 0x00023C54
        protected override void OnClosing(CancelEventArgs e)
        {
            if (baseImage != null)
            {
                baseImage.Dispose();
            }
            baseImage = null;
            base.OnClosing(e);
        }

        // Token: 0x170000BF RID: 191
        // (set) Token: 0x06000565 RID: 1381 RVA: 0x00025A77 File Offset: 0x00023C77
        public Image Image
        {
            set => baseImage = (Image)value.Clone();
        }

        // Token: 0x170000C0 RID: 192
        // (get) Token: 0x06000567 RID: 1383 RVA: 0x00025A93 File Offset: 0x00023C93
        // (set) Token: 0x06000566 RID: 1382 RVA: 0x00025A8A File Offset: 0x00023C8A
        public Point MouseLocation
        {
            get => ptMouse;
            set => ptMouse = value;
        }

        // Token: 0x170000C1 RID: 193
        // (get) Token: 0x06000569 RID: 1385 RVA: 0x00025AA4 File Offset: 0x00023CA4
        // (set) Token: 0x06000568 RID: 1384 RVA: 0x00025A9B File Offset: 0x00023C9B
        public Point StartPoint
        {
            get => ptStart;
            set => ptStart = value;
        }

        // Token: 0x170000C2 RID: 194
        // (get) Token: 0x0600056B RID: 1387 RVA: 0x00025AB5 File Offset: 0x00023CB5
        // (set) Token: 0x0600056A RID: 1386 RVA: 0x00025AAC File Offset: 0x00023CAC
        public Color MouseColor
        {
            get => colMouse;
            set => colMouse = value;
        }

        // Token: 0x170000C3 RID: 195
        // (get) Token: 0x0600056D RID: 1389 RVA: 0x00025AC6 File Offset: 0x00023CC6
        // (set) Token: 0x0600056C RID: 1388 RVA: 0x00025ABD File Offset: 0x00023CBD
        public bool IsSelecting
        {
            get => _isDrag;
            set => _isDrag = value;
        }

        // Token: 0x0600056E RID: 1390 RVA: 0x00025ACE File Offset: 0x00023CCE
        public CaptureInfo()
        {
            InitializeComponent();
            baseImage = null;
            base.Top = 100;
        }

        // Token: 0x0600056F RID: 1391 RVA: 0x00025AEC File Offset: 0x00023CEC
        private void CaptureInfo_Paint(object sender, PaintEventArgs e)
        {
            if (isActive || baseImage == null)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, base.Width, base.Height);
            }
            else
            {
                e.Graphics.DrawImageUnscaled(baseImage, -base.Left, -base.Top, base.Width, base.Height);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(180, 0, 0, 0)), 0, 0, base.Width, base.Height);
            }
            var p = new Point(10, 10);
            var font = new Font("Segoe UI Symbol", 9f);
            e.Graphics.DrawString("X:" + ptMouse.X.ToString(), font, new SolidBrush(Color.White), p);
            e.Graphics.DrawString("Y:" + ptMouse.Y.ToString(), font, new SolidBrush(Color.White), p.X, p.Y + font.GetHeight() + 3f);
            if (_isDrag)
            {
                e.Graphics.DrawString("W:" + Math.Abs(ptMouse.X - ptStart.X).ToString(), font, new SolidBrush(Color.White), p.X + 50, p.Y);
                e.Graphics.DrawString("H:" + Math.Abs(ptMouse.Y - ptStart.Y).ToString(), font, new SolidBrush(Color.White), p.X + 50, p.Y + font.GetHeight() + 3f);
            }
            else
            {
                e.Graphics.DrawString("W:----", font, new SolidBrush(Color.White), p.X + 50, p.Y);
                e.Graphics.DrawString("H:----", font, new SolidBrush(Color.White), p.X + 50, p.Y + font.GetHeight() + 3f);
            }
            p.Y += 40;
            e.Graphics.FillRectangle(new SolidBrush(colMouse), new Rectangle(p.X, p.Y, 30, 30));
            e.Graphics.DrawString("红：" + colMouse.R.ToString(), font, new SolidBrush(Color.White), p.X + 35, p.Y);
            p.Y += (int)font.GetHeight() + 3;
            e.Graphics.DrawString("绿：" + colMouse.G.ToString(), font, new SolidBrush(Color.White), p.X + 35, p.Y);
            p.Y += (int)font.GetHeight() + 3;
            e.Graphics.DrawString("蓝：" + colMouse.B.ToString(), font, new SolidBrush(Color.White), p.X + 35, p.Y);
            p.Y += (int)font.GetHeight() + 3;
            e.Graphics.DrawString("#:" + colMouse.R.ToString("X2") + colMouse.G.ToString("X2") + colMouse.B.ToString("X2"), font, new SolidBrush(Color.White), p.X + 35, p.Y);
        }

        // Token: 0x06000570 RID: 1392 RVA: 0x00025F30 File Offset: 0x00024130
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        // Token: 0x06000571 RID: 1393 RVA: 0x00025F32 File Offset: 0x00024132
        private void CaptureInfo_MouseDown(object sender, MouseEventArgs e)
        {
            ptStart = new Point(e.X, e.Y);
            isActive = true;
            base.Opacity = 0.5;
            Refresh();
        }

        // Token: 0x06000572 RID: 1394 RVA: 0x00025F67 File Offset: 0x00024167
        private void CaptureInfo_MouseUp(object sender, MouseEventArgs e)
        {
            isActive = false;
            base.Opacity = 1.0;
            Refresh();
        }

        // Token: 0x06000573 RID: 1395 RVA: 0x00025F88 File Offset: 0x00024188
        private void CaptureInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (isActive)
            {
                base.Left += e.X - ptStart.X;
                base.Top += e.Y - ptStart.Y;
                Refresh();
            }
        }

        // Token: 0x06000574 RID: 1396 RVA: 0x00025FE1 File Offset: 0x000241E1
        private void timRefresh_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        // Token: 0x06000575 RID: 1397 RVA: 0x00025FE9 File Offset: 0x000241E9
        private void CaptureInfo_Load(object sender, EventArgs e)
        {
        }

        // Token: 0x06000576 RID: 1398 RVA: 0x00025FEB File Offset: 0x000241EB
        private void ThreadTask()
        {
            for (; ; )
            {
                base.Invoke(new CaptureInfo.RefreshDelegate(RefreshInfo));
                Thread.Sleep(100);
            }
        }

        // Token: 0x06000577 RID: 1399 RVA: 0x00026008 File Offset: 0x00024208
        private void RefreshInfo()
        {
            Refresh();
        }

        // Token: 0x06000578 RID: 1400 RVA: 0x00026010 File Offset: 0x00024210
        private void CaptureInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trd != null)
            {
                trd.Abort();
            }
        }

        // Token: 0x06000579 RID: 1401 RVA: 0x00026025 File Offset: 0x00024225
        private void CaptureInfo_Shown(object sender, EventArgs e)
        {
            trd = new Thread(new ThreadStart(ThreadTask))
            {
                IsBackground = true
            };
        }

        // Token: 0x0400036B RID: 875
        private Image baseImage;

        // Token: 0x0400036C RID: 876
        private bool isActive;

        // Token: 0x0400036D RID: 877
        private Point ptStart;

        // Token: 0x0400036E RID: 878
        private Point ptMouse;

        // Token: 0x0400036F RID: 879
        private Color colMouse;

        // Token: 0x04000370 RID: 880
        private bool _isDrag;

        // Token: 0x04000371 RID: 881
        private Thread trd;

        // Token: 0x020000A8 RID: 168
        // (Invoke) Token: 0x0600057D RID: 1405
        private delegate void RefreshDelegate();
    }
}
