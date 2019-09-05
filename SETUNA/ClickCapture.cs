namespace SETUNA
{
    using SETUNA.Main.Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ClickCapture : Form
    {
        private const int AREASIZE = 1;
        private bool CC1;
        private bool CC2;
        private bool CC3;
        private bool CC4;
        private bool CC6;
        private bool CC7;
        private bool CC8;
        private bool CC9;
        private IContainer components;
        private Rectangle CursorRect;
        private Timer timer1;
        private LayerInfo mLayerInfo;

        public event ClipCaptureDelegate ClickCaptureEvent;

        public ClickCapture(bool[] values)
        {
            this.InitializeComponent();
            this.ClickFlags = values;
            this.CursorRect = new Rectangle(0, 0, 1, 1);
            this.ClickPosition = ClickPositionType.CP0;
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
        }

        private void ClickCapture_Click(object sender, EventArgs e)
        {
            if (this.ClickCaptureEvent != null)
            {
                this.ClickCaptureEvent(sender, e);
            }
        }

        private void ClickCapture_MouseEnter(object sender, EventArgs e)
        {
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
            this.components = new Container();
            this.timer1 = new Timer(this.components);
            base.SuspendLayout();
            this.timer1.Enabled = true;
            this.timer1.Interval = 150;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            base.ClientSize = new Size(10, 10);
            base.ControlBox = false;
            base.FormBorderStyle = FormBorderStyle.None;
            this.MaximumSize = new Size(10, 10);
            this.MinimumSize = new Size(1, 1);
            base.Name = "ClickCapture";
            base.Opacity = 0.01;
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.TopMost = true;
            base.MouseEnter += new EventHandler(this.ClickCapture_MouseEnter);
            base.Click += new EventHandler(this.ClickCapture_Click);
            base.ResumeLayout(false);
        }

        public void Restart()
        {
            base.Visible = true;
            this.timer1.Start();
        }

        public void Stop()
        {
            this.timer1.Stop();
            base.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Cursor.Position != this.LastMousePosition)
            {
                int num2;
                int num3;
                int num4;
                double num7;
                double num8;
                double num9;
                int num10;
                int num11;
                Screen screen = Screen.FromPoint(Cursor.Position);
                if (this.MaximumSize != screen.Bounds.Size)
                {
                    this.MaximumSize = screen.Bounds.Size;
                }
                int num = num2 = num3 = num4 = 0x7fffffff;
                if (this.CC8)
                {
                    num = Cursor.Position.Y - screen.Bounds.Top;
                }
                if (this.CC4)
                {
                    num2 = Cursor.Position.X - screen.Bounds.Left;
                }
                if (this.CC6)
                {
                    num3 = screen.Bounds.Right - Cursor.Position.X;
                }
                if (this.CC2)
                {
                    num4 = screen.Bounds.Bottom - Cursor.Position.Y;
                }
                int num5 = Math.Min(Math.Min(Math.Min(num, num4), num2), num3);
                ClickPositionType type = ClickPositionType.CP0;
                if (num5 < 0x7fffffff)
                {
                    if (num5 == num)
                    {
                        type = ClickPositionType.CP8;
                    }
                    else if (num5 == num2)
                    {
                        type = ClickPositionType.CP4;
                    }
                    else if (num5 == num3)
                    {
                        type = ClickPositionType.CP6;
                    }
                    else if (num5 == num4)
                    {
                        type = ClickPositionType.CP2;
                    }
                    else
                    {
                        type = ClickPositionType.CP0;
                    }
                }
                double num6 = num7 = num8 = num9 = double.MaxValue;
                if (this.CC7)
                {
                    num10 = Cursor.Position.X - screen.Bounds.Left;
                    num11 = Cursor.Position.Y - screen.Bounds.Top;
                    num6 = Math.Abs(Math.Sqrt((double) ((num10 * num10) + (num11 * num11))));
                }
                if (this.CC9)
                {
                    num10 = screen.Bounds.Right - Cursor.Position.X;
                    num11 = Cursor.Position.Y - screen.Bounds.Top;
                    num7 = Math.Abs(Math.Sqrt((double) ((num10 * num10) + (num11 * num11))));
                }
                if (this.CC1)
                {
                    num10 = Cursor.Position.X - screen.Bounds.Left;
                    num11 = screen.Bounds.Bottom - Cursor.Position.Y;
                    num8 = Math.Abs(Math.Sqrt((double) ((num10 * num10) + (num11 * num11))));
                }
                if (this.CC3)
                {
                    num10 = screen.Bounds.Right - Cursor.Position.X;
                    num11 = screen.Bounds.Bottom - Cursor.Position.Y;
                    num9 = Math.Abs(Math.Sqrt((double) ((num10 * num10) + (num11 * num11))));
                }
                double num12 = Math.Min(Math.Min(Math.Min(num6, num7), num8), num9);
                if (num12 < double.MaxValue)
                {
                    if (num12 == num6)
                    {
                        if (((type != ClickPositionType.CP4) && (type != ClickPositionType.CP8)) && (num12 < num5))
                        {
                            type = ClickPositionType.CP7;
                        }
                    }
                    else if (num12 == num7)
                    {
                        if (((type != ClickPositionType.CP6) && (type != ClickPositionType.CP8)) && (num12 < num5))
                        {
                            type = ClickPositionType.CP9;
                        }
                    }
                    else if (num12 == num8)
                    {
                        if (((type != ClickPositionType.CP4) && (type != ClickPositionType.CP2)) && (num12 < num5))
                        {
                            type = ClickPositionType.CP1;
                        }
                    }
                    else if (((num12 == num9) && (type != ClickPositionType.CP6)) && ((type != ClickPositionType.CP2) && (num12 < num5)))
                    {
                        type = ClickPositionType.CP3;
                    }
                }
                if (this.ClickPosition != type)
                {
                    this.ClickPosition = type;
                    this.LastMousePosition = Cursor.Position;
                    switch (type)
                    {
                        case ClickPositionType.CP7:
                            this.SetBoundsCore(screen.Bounds.Left, screen.Bounds.Top, 1, 1, BoundsSpecified.All);
                            break;

                        case ClickPositionType.CP8:
                            this.SetBoundsCore(screen.Bounds.Left, screen.Bounds.Top, screen.Bounds.Width, 1, BoundsSpecified.All);
                            break;

                        case ClickPositionType.CP9:
                            this.SetBoundsCore(screen.Bounds.Right - 1, screen.Bounds.Top, 1, 1, BoundsSpecified.All);
                            break;

                        case ClickPositionType.CP4:
                            this.SetBoundsCore(screen.Bounds.Left, screen.Bounds.Top, 1, screen.Bounds.Height, BoundsSpecified.All);
                            break;

                        case ClickPositionType.CP6:
                            this.SetBoundsCore(screen.Bounds.Right - 1, screen.Bounds.Top, 1, screen.Bounds.Height, BoundsSpecified.All);
                            break;

                        case ClickPositionType.CP1:
                            this.SetBoundsCore(screen.Bounds.Left, screen.Bounds.Bottom - 1, 1, 1, BoundsSpecified.All);
                            break;

                        case ClickPositionType.CP2:
                            this.SetBoundsCore(screen.Bounds.Left, screen.Bounds.Bottom - 1, screen.Bounds.Width, 1, BoundsSpecified.All);
                            break;

                        case ClickPositionType.CP3:
                            this.SetBoundsCore(screen.Bounds.Right - 1, screen.Bounds.Bottom - 1, 1, 1, BoundsSpecified.All);
                            break;
                    }
                    if ((type == ClickPositionType.CP0) && base.Visible)
                    {
                        base.Visible = false;
                    }
                    if ((type != ClickPositionType.CP0) && !base.Visible)
                    {
                        base.Visible = true;
                    }
                    this.Refresh();
                    Console.WriteLine(base.Bounds.ToString());
                }
                this.CursorRect.Location = Cursor.Position;
                if (base.Bounds.IntersectsWith(this.CursorRect))
                {
                    try
                    {
                        Win32Api.SetWindowPos((int) base.Handle, 0, 0, 0, 0, 0, 0x53);
                    }
                    catch
                    {
                        Console.WriteLine("SetWindowPos Error");
                    }
                }
            }
        }

        public bool[] ClickFlags
        {
            set
            {
                if (value.Length >= 10)
                {
                    this.CC1 = value[1];
                    this.CC2 = value[2];
                    this.CC3 = value[3];
                    this.CC4 = value[4];
                    this.CC6 = value[6];
                    this.CC7 = value[7];
                    this.CC8 = value[8];
                    this.CC9 = value[9];
                }
            }
        }

        private ClickPositionType ClickPosition { get; set; }

        private Point LastMousePosition { get; set; }

        private enum ClickPositionType
        {
            CP7,
            CP8,
            CP9,
            CP4,
            CP6,
            CP1,
            CP2,
            CP3,
            CP0
        }

        public delegate void ClipCaptureDelegate(object sender, EventArgs e);

        private class Win32Api
        {
            public const int HWND_TOP = 0;
            public const uint SWP_NOACTIVATE = 0x10;
            public const uint SWP_NOMOVE = 2;
            public const uint SWP_NOSIZE = 1;
            public const uint SWP_SHOWWINDOW = 0x40;

            [DllImport("user32.dll")]
            public static extern bool SetWindowPos(int hWnd, int hWndAfter, int X, int Y, int cx, int cy, uint uFlags);
        }
    }
}

