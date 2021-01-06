using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SETUNA
{
    // Token: 0x02000045 RID: 69
    public partial class ClickCapture : BaseForm
    {
        // Token: 0x14000016 RID: 22
        // (add) Token: 0x0600027C RID: 636 RVA: 0x0000D5FA File Offset: 0x0000B7FA
        // (remove) Token: 0x0600027D RID: 637 RVA: 0x0000D613 File Offset: 0x0000B813
        public event ClickCapture.ClipCaptureDelegate ClickCaptureEvent;

        // Token: 0x0600027E RID: 638 RVA: 0x0000D62C File Offset: 0x0000B82C
        public ClickCapture(bool[] values)
        {
            InitializeComponent();
            ClickFlags = values;
            CursorRect = new Rectangle(0, 0, 1, 1);
            ClickPosition = ClickCapture.ClickPositionType.CP0;
        }

        // Token: 0x17000069 RID: 105
        // (set) Token: 0x0600027F RID: 639 RVA: 0x0000D658 File Offset: 0x0000B858
        public bool[] ClickFlags
        {
            set
            {
                if (value.Length < 10)
                {
                    return;
                }
                CC1 = value[1];
                CC2 = value[2];
                CC3 = value[3];
                CC4 = value[4];
                CC6 = value[6];
                CC7 = value[7];
                CC8 = value[8];
                CC9 = value[9];
            }
        }

        // Token: 0x06000280 RID: 640 RVA: 0x0000D6B8 File Offset: 0x0000B8B8
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Cursor.Position == LastMousePosition)
            {
                return;
            }
            var screen = Screen.FromPoint(Cursor.Position);
            if (MaximumSize != screen.Bounds.Size)
            {
                MaximumSize = screen.Bounds.Size;
            }
            int num4;
            int num3;
            int num2;
            var num = num2 = (num3 = (num4 = int.MaxValue));
            if (CC8)
            {
                num2 = Cursor.Position.Y - screen.Bounds.Top;
            }
            if (CC4)
            {
                num = Cursor.Position.X - screen.Bounds.Left;
            }
            if (CC6)
            {
                num3 = screen.Bounds.Right - Cursor.Position.X;
            }
            if (CC2)
            {
                num4 = screen.Bounds.Bottom - Cursor.Position.Y;
            }
            var num5 = Math.Min(num2, num4);
            num5 = Math.Min(num5, num);
            num5 = Math.Min(num5, num3);
            var clickPositionType = ClickCapture.ClickPositionType.CP0;
            if (num5 < 2147483647)
            {
                if (num5 == num2)
                {
                    clickPositionType = ClickCapture.ClickPositionType.CP8;
                }
                else if (num5 == num)
                {
                    clickPositionType = ClickCapture.ClickPositionType.CP4;
                }
                else if (num5 == num3)
                {
                    clickPositionType = ClickCapture.ClickPositionType.CP6;
                }
                else if (num5 == num4)
                {
                    clickPositionType = ClickCapture.ClickPositionType.CP2;
                }
                else
                {
                    clickPositionType = ClickCapture.ClickPositionType.CP0;
                }
            }
            double num9;
            double num8;
            double num7;
            var num6 = num7 = (num8 = (num9 = double.MaxValue));
            if (CC7)
            {
                var num10 = Cursor.Position.X - screen.Bounds.Left;
                var num11 = Cursor.Position.Y - screen.Bounds.Top;
                num7 = Math.Abs(Math.Sqrt(num10 * num10 + num11 * num11));
            }
            if (CC9)
            {
                var num10 = screen.Bounds.Right - Cursor.Position.X;
                var num11 = Cursor.Position.Y - screen.Bounds.Top;
                num6 = Math.Abs(Math.Sqrt(num10 * num10 + num11 * num11));
            }
            if (CC1)
            {
                var num10 = Cursor.Position.X - screen.Bounds.Left;
                var num11 = screen.Bounds.Bottom - Cursor.Position.Y;
                num8 = Math.Abs(Math.Sqrt(num10 * num10 + num11 * num11));
            }
            if (CC3)
            {
                var num10 = screen.Bounds.Right - Cursor.Position.X;
                var num11 = screen.Bounds.Bottom - Cursor.Position.Y;
                num9 = Math.Abs(Math.Sqrt(num10 * num10 + num11 * num11));
            }
            var num12 = Math.Min(num7, num6);
            num12 = Math.Min(num12, num8);
            num12 = Math.Min(num12, num9);
            if (num12 < 1.7976931348623157E+308)
            {
                if (num12 == num7)
                {
                    if (clickPositionType != ClickCapture.ClickPositionType.CP4 && clickPositionType != ClickCapture.ClickPositionType.CP8 && num12 < num5)
                    {
                        clickPositionType = ClickCapture.ClickPositionType.CP7;
                    }
                }
                else if (num12 == num6)
                {
                    if (clickPositionType != ClickCapture.ClickPositionType.CP6 && clickPositionType != ClickCapture.ClickPositionType.CP8 && num12 < num5)
                    {
                        clickPositionType = ClickCapture.ClickPositionType.CP9;
                    }
                }
                else if (num12 == num8)
                {
                    if (clickPositionType != ClickCapture.ClickPositionType.CP4 && clickPositionType != ClickCapture.ClickPositionType.CP2 && num12 < num5)
                    {
                        clickPositionType = ClickCapture.ClickPositionType.CP1;
                    }
                }
                else if (num12 == num9 && clickPositionType != ClickCapture.ClickPositionType.CP6 && clickPositionType != ClickCapture.ClickPositionType.CP2 && num12 < num5)
                {
                    clickPositionType = ClickCapture.ClickPositionType.CP3;
                }
            }
            if (ClickPosition != clickPositionType)
            {
                ClickPosition = clickPositionType;
                LastMousePosition = Cursor.Position;
                switch (clickPositionType)
                {
                    case ClickCapture.ClickPositionType.CP7:
                        SetBoundsCore(screen.Bounds.Left, screen.Bounds.Top, 1, 1, BoundsSpecified.All);
                        break;
                    case ClickCapture.ClickPositionType.CP8:
                        SetBoundsCore(screen.Bounds.Left, screen.Bounds.Top, screen.Bounds.Width, 1, BoundsSpecified.All);
                        break;
                    case ClickCapture.ClickPositionType.CP9:
                        SetBoundsCore(screen.Bounds.Right - 1, screen.Bounds.Top, 1, 1, BoundsSpecified.All);
                        break;
                    case ClickCapture.ClickPositionType.CP4:
                        SetBoundsCore(screen.Bounds.Left, screen.Bounds.Top, 1, screen.Bounds.Height, BoundsSpecified.All);
                        break;
                    case ClickCapture.ClickPositionType.CP6:
                        SetBoundsCore(screen.Bounds.Right - 1, screen.Bounds.Top, 1, screen.Bounds.Height, BoundsSpecified.All);
                        break;
                    case ClickCapture.ClickPositionType.CP1:
                        SetBoundsCore(screen.Bounds.Left, screen.Bounds.Bottom - 1, 1, 1, BoundsSpecified.All);
                        break;
                    case ClickCapture.ClickPositionType.CP2:
                        SetBoundsCore(screen.Bounds.Left, screen.Bounds.Bottom - 1, screen.Bounds.Width, 1, BoundsSpecified.All);
                        break;
                    case ClickCapture.ClickPositionType.CP3:
                        SetBoundsCore(screen.Bounds.Right - 1, screen.Bounds.Bottom - 1, 1, 1, BoundsSpecified.All);
                        break;
                }
                if (clickPositionType == ClickCapture.ClickPositionType.CP0 && base.Visible)
                {
                    base.Visible = false;
                }
                if (clickPositionType != ClickCapture.ClickPositionType.CP0 && !base.Visible)
                {
                    base.Visible = true;
                }
                Refresh();
                Console.WriteLine(base.Bounds.ToString());
            }
            CursorRect.Location = Cursor.Position;
            if (base.Bounds.IntersectsWith(CursorRect))
            {
                try
                {
                    ClickCapture.Win32Api.SetWindowPos((int)base.Handle, 0, 0, 0, 0, 0, 83U);
                }
                catch
                {
                    Console.WriteLine("SetWindowPos Error");
                }
            }
        }

        // Token: 0x1700006A RID: 106
        // (get) Token: 0x06000282 RID: 642 RVA: 0x0000DCE5 File Offset: 0x0000BEE5
        // (set) Token: 0x06000281 RID: 641 RVA: 0x0000DCDC File Offset: 0x0000BEDC
        private ClickCapture.ClickPositionType ClickPosition { get; set; }

        // Token: 0x1700006B RID: 107
        // (get) Token: 0x06000284 RID: 644 RVA: 0x0000DCF6 File Offset: 0x0000BEF6
        // (set) Token: 0x06000283 RID: 643 RVA: 0x0000DCED File Offset: 0x0000BEED
        private Point LastMousePosition { get; set; }

        // Token: 0x06000285 RID: 645 RVA: 0x0000DCFE File Offset: 0x0000BEFE
        public void Restart()
        {
            base.Visible = true;
            timer1.Start();
        }

        // Token: 0x06000286 RID: 646 RVA: 0x0000DD12 File Offset: 0x0000BF12
        public void Stop()
        {
            timer1.Stop();
            base.Visible = false;
        }

        // Token: 0x06000287 RID: 647 RVA: 0x0000DD26 File Offset: 0x0000BF26
        private void ClickCapture_Click(object sender, EventArgs e)
        {
            if (ClickCaptureEvent != null)
            {
                ClickCaptureEvent(sender, e);
            }
        }

        // Token: 0x06000288 RID: 648 RVA: 0x0000DD3D File Offset: 0x0000BF3D
        private void ClickCapture_MouseEnter(object sender, EventArgs e)
        {
        }

        // Token: 0x04000118 RID: 280
        private const int AREASIZE = 1;

        // Token: 0x04000119 RID: 281
        private bool CC7;

        // Token: 0x0400011A RID: 282
        private bool CC8;

        // Token: 0x0400011B RID: 283
        private bool CC9;

        // Token: 0x0400011C RID: 284
        private bool CC4;

        // Token: 0x0400011D RID: 285
        private bool CC6;

        // Token: 0x0400011E RID: 286
        private bool CC1;

        // Token: 0x0400011F RID: 287
        private bool CC2;

        // Token: 0x04000120 RID: 288
        private bool CC3;

        // Token: 0x04000121 RID: 289
        private Rectangle CursorRect;

        // Token: 0x02000054 RID: 84
        // (Invoke) Token: 0x06000311 RID: 785
        public delegate void ClipCaptureDelegate(object sender, EventArgs e);

        // Token: 0x020000B0 RID: 176
        private class Win32Api
        {
            // Token: 0x06000596 RID: 1430
            [DllImport("user32.dll")]
            public static extern bool SetWindowPos(int hWnd, int hWndAfter, int X, int Y, int cx, int cy, uint uFlags);

            // Token: 0x04000376 RID: 886
            public const uint SWP_NOSIZE = 1U;

            // Token: 0x04000377 RID: 887
            public const uint SWP_NOMOVE = 2U;

            // Token: 0x04000378 RID: 888
            public const uint SWP_SHOWWINDOW = 64U;

            // Token: 0x04000379 RID: 889
            public const uint SWP_NOACTIVATE = 16U;

            // Token: 0x0400037A RID: 890
            public const int HWND_TOP = 0;
        }

        // Token: 0x020000B1 RID: 177
        private enum ClickPositionType
        {
            // Token: 0x0400037C RID: 892
            CP7,
            // Token: 0x0400037D RID: 893
            CP8,
            // Token: 0x0400037E RID: 894
            CP9,
            // Token: 0x0400037F RID: 895
            CP4,
            // Token: 0x04000380 RID: 896
            CP6,
            // Token: 0x04000381 RID: 897
            CP1,
            // Token: 0x04000382 RID: 898
            CP2,
            // Token: 0x04000383 RID: 899
            CP3,
            // Token: 0x04000384 RID: 900
            CP0
        }
    }
}
