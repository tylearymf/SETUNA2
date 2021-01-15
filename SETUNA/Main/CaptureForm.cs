using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SETUNA.Main.Option;

namespace SETUNA.Main
{
    // Token: 0x02000046 RID: 70
    public sealed partial class CaptureForm : BaseForm
    {
        // Token: 0x0600028B RID: 651
        [DllImport("User32.Dll")]
        private static extern IntPtr GetDesktopWindow();

        // Token: 0x0600028C RID: 652
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindow(IntPtr hWnd, uint cCmd);

        // Token: 0x0600028D RID: 653
        [DllImport("user32.dll")]
        private static extern IntPtr GetTopWindow(IntPtr hWnd);

        // Token: 0x0600028E RID: 654
        [DllImport("user32.dll", EntryPoint = "GetWindow")]
        private static extern IntPtr GetNextWindow(IntPtr hWnd, uint wCmd);

        // Token: 0x0600028F RID: 655
        [DllImport("user32.dll")]
        private static extern int EnumWindows(CaptureForm.EnumWindowsCallBack lpFunc, int lParam);

        // Token: 0x06000290 RID: 656
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCnt);

        // Token: 0x06000291 RID: 657
        [DllImport("user32.dll")]
        private static extern int IsWindowVisible(IntPtr hWnd);

        // Token: 0x06000292 RID: 658
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out CaptureForm.RECT lpRect);

        // Token: 0x06000293 RID: 659
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        // Token: 0x06000294 RID: 660
        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

        // Token: 0x06000295 RID: 661
        [DllImport("gdi32.dll")]
        private static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        // Token: 0x06000296 RID: 662
        [DllImport("Gdi32.dll")]
        private static extern IntPtr CreateDC(string Display, string c, object b, object a);

        // Token: 0x06000297 RID: 663
        [DllImport("Gdi32.dll")]
        private static extern bool DeleteDC(IntPtr handle);

        // Token: 0x1700006C RID: 108
        // (get) Token: 0x06000298 RID: 664 RVA: 0x0000DE7C File Offset: 0x0000C07C
        public Bitmap ClipBitmap
        {
            get
            {
                if (bmpClip != null)
                {
                    return bmpClip;
                }
                return null;
            }
        }

        // Token: 0x1700006D RID: 109
        // (get) Token: 0x06000299 RID: 665 RVA: 0x0000DE8E File Offset: 0x0000C08E
        public Point ClipStart => ptClipStart;

        // Token: 0x1700006E RID: 110
        // (get) Token: 0x0600029A RID: 666 RVA: 0x0000DE96 File Offset: 0x0000C096
        public Size ClipSize => ptClipSize;

        public static Screen TargetScreen => targetScreen;


        // Token: 0x1700006F RID: 111
        // (set) Token: 0x0600029B RID: 667 RVA: 0x0000DE9E File Offset: 0x0000C09E
        public CaptureForm.CaptureClosedDelegate OnCaptureClose
        {
            set => CaptureClosedHandler = value;
        }

        // Token: 0x0600029C RID: 668 RVA: 0x0000DEA8 File Offset: 0x0000C0A8
        public CaptureForm(SetunaOption.SetunaOptionData opt)
        {
            InitializeComponent();
            targetScreen = GetCurrentScreen();
            CaptureForm.imgSnap = new Bitmap(targetScreen.Bounds.Width, targetScreen.Bounds.Height, PixelFormat.Format24bppRgb);
            CaptureForm.selArea = new Form
            {
                AutoScaleMode = AutoScaleMode.None,
                BackColor = Color.Blue,
                BackgroundImageLayout = ImageLayout.None,
                ControlBox = false,
                FormBorderStyle = FormBorderStyle.None,
                MaximizeBox = false,
                MinimizeBox = false,
                MinimumSize = new Size(1, 1),
                ClientSize = new Size(1, 1),
                ShowIcon = false,
                ShowInTaskbar = false,
                SizeGripStyle = SizeGripStyle.Hide,
                StartPosition = FormStartPosition.Manual,
                Text = "CaptureSelArea",
                TopMost = true,
                Left = 0,
                Top = 0,
                Width = 1,
                Height = 1,
                Visible = false
            };
            base.AddOwnedForm(CaptureForm.selArea);
            CaptureForm.selLineHor1 = new CaptureSelLine(SelLineType.Horizon, opt.SelectLineSolid, opt.SelectLineColor);
            base.AddOwnedForm(CaptureForm.selLineHor1);
            CaptureForm.selLineHor1.Show(this);
            CaptureForm.selLineHor2 = new CaptureSelLine(SelLineType.Horizon, opt.SelectLineSolid, opt.SelectLineColor);
            base.AddOwnedForm(CaptureForm.selLineHor2);
            CaptureForm.selLineHor2.Show(this);
            CaptureForm.selLineVer1 = new CaptureSelLine(SelLineType.Vertical, opt.SelectLineSolid, opt.SelectLineColor);
            base.AddOwnedForm(CaptureForm.selLineVer1);
            CaptureForm.selLineVer1.Show(this);
            CaptureForm.selLineVer2 = new CaptureSelLine(SelLineType.Vertical, opt.SelectLineSolid, opt.SelectLineColor);
            base.AddOwnedForm(CaptureForm.selLineVer2);
            CaptureForm.selLineVer2.Show(this);
            CaptureForm.selLineHor1.Visible = false;
            CaptureForm.selLineHor2.Visible = false;
            CaptureForm.selLineVer1.Visible = false;
            CaptureForm.selLineVer2.Visible = false;
            CaptureForm.selArea.Visible = false;

            fullscreenHorLine = new CaptureSelLine(SelLineType.Horizon, opt.FullscreenCursorSolid, opt.FullscreenCursorLineColor)
            {
                ShowWhiteBackground = false
            };
            InitChildForm(fullscreenHorLine);
            fullscreenVerLine = new CaptureSelLine(SelLineType.Vertical, opt.FullscreenCursorSolid, opt.FullscreenCursorLineColor)
            {
                ShowWhiteBackground = false
            };
            InitChildForm(fullscreenVerLine);

            magnifier = new Magnifier();
            base.AddOwnedForm(magnifier);
            magnifier.Show();
            magnifier.Visible = false;

            base.Opacity = 0.99000000953674316;
        }

        void InitChildForm(Form form)
        {
            base.AddOwnedForm(form);
            form.Cursor = Cursors.Cross;
            form.Opacity = 0.0099999997764825821;

            form.Show(this);
            form.Visible = false;
        }

        // Token: 0x0600029D RID: 669 RVA: 0x0000E104 File Offset: 0x0000C304
        public void ShowCapture(SetunaOption.SetunaOptionData opt)
        {
            if (CaptureForm.imgSnap == null)
            {
                return;
            }
            //Cursor.Current = Cursors.Cross;
            targetScreen = GetCurrentScreen();
            if (targetScreen.Bounds.Width != CaptureForm.imgSnap.Width || targetScreen.Bounds.Height != CaptureForm.imgSnap.Height)
            {
                CaptureForm.imgSnap = new Bitmap(targetScreen.Bounds.Width, targetScreen.Bounds.Height, PixelFormat.Format24bppRgb);
            }
            trd = new Thread(new ThreadStart(ThreadTask))
            {
                IsBackground = true
            };
            trd.Start();
            Console.WriteLine(string.Concat(new object[]
            {
                "10 - ",
                DateTime.Now.ToString(),
                " ",
                DateTime.Now.Millisecond
            }));
            Console.WriteLine(string.Concat(new object[]
            {
                "11 - ",
                DateTime.Now.ToString(),
                " ",
                DateTime.Now.Millisecond
            }));
            blAreaVisible = (opt.SelectAreaTransparent != 100);
            CaptureForm.selArea.Opacity = 1f - opt.SelectAreaTransparent / 100f;
            CaptureForm.selArea.BackColor = opt.SelectBackColor;
            if (!CaptureForm.selArea.Visible)
            {
                CaptureForm.selArea.Show(this);
            }
            Console.WriteLine(string.Concat(new object[]
            {
                "12 - ",
                DateTime.Now.ToString(),
                " ",
                DateTime.Now.Millisecond
            }));
            SetBoundsCore(targetScreen.Bounds.X, targetScreen.Bounds.Y, targetScreen.Bounds.Width, targetScreen.Bounds.Height, BoundsSpecified.All);
            Console.WriteLine(string.Concat(new object[]
            {
                "13 - ",
                DateTime.Now.ToString(),
                " ",
                DateTime.Now.Millisecond
            }));
            CaptureForm.selLineHor1.SetPen(opt.SelectLineSolid, opt.SelectLineColor);
            CaptureForm.selLineHor1.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y - 10, targetScreen.Bounds.Width, 1);
            if (!CaptureForm.selLineHor1.Visible)
            {
                CaptureForm.selLineHor1.Show(this);
            }
            CaptureForm.selLineHor2.SetPen(opt.SelectLineSolid, opt.SelectLineColor);
            CaptureForm.selLineHor2.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y - 10, targetScreen.Bounds.Width, 1);
            if (!CaptureForm.selLineHor2.Visible)
            {
                CaptureForm.selLineHor2.Show(this);
            }
            CaptureForm.selLineVer1.SetPen(opt.SelectLineSolid, opt.SelectLineColor);
            CaptureForm.selLineVer1.SetBounds(targetScreen.Bounds.X - 10, targetScreen.Bounds.Y, 1, targetScreen.Bounds.Height);
            if (!CaptureForm.selLineVer1.Visible)
            {
                CaptureForm.selLineVer1.Show(this);
            }
            CaptureForm.selLineVer2.SetPen(opt.SelectLineSolid, opt.SelectLineColor);
            CaptureForm.selLineVer2.SetBounds(targetScreen.Bounds.X - 10, targetScreen.Bounds.Y, 1, targetScreen.Bounds.Height);
            if (!CaptureForm.selLineVer2.Visible)
            {
                CaptureForm.selLineVer2.Show(this);
            }
            Console.WriteLine(string.Concat(new object[]
            {
                "14 - ",
                DateTime.Now.ToString(),
                " ",
                DateTime.Now.Millisecond
            }));

            fullscreenHorLine.SetPen(opt.FullscreenCursorSolid, opt.FullscreenCursorLineColor);
            fullscreenVerLine.SetPen(opt.FullscreenCursorSolid, opt.FullscreenCursorLineColor);
            fullscreenHorLine.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y, targetScreen.Bounds.Width, 1);
            fullscreenVerLine.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y, 1, targetScreen.Bounds.Height);

            Thread.Sleep(1);
            Cursor.Clip = targetScreen.Bounds;
        }

        // Token: 0x0600029E RID: 670 RVA: 0x0000E628 File Offset: 0x0000C828
        private Screen GetCurrentScreen()
        {
            var rectangle = new Rectangle(Cursor.Position, new Size(1, 1));
            foreach (var screen in Screen.AllScreens)
            {
                if (rectangle.IntersectsWith(screen.Bounds))
                {
                    return screen;
                }
            }
            return Screen.PrimaryScreen;
        }

        // Token: 0x0600029F RID: 671 RVA: 0x0000E680 File Offset: 0x0000C880
        private void ThreadTask()
        {
            var flag = CaptureForm.CopyFromScreen(CaptureForm.imgSnap, new Point(targetScreen.Bounds.X, targetScreen.Bounds.Y));
            if (flag)
            {
                base.Invoke(new CaptureForm.ShowFormDelegate(ShowForm));
                return;
            }
            base.Invoke(new CaptureForm.ShowFormDelegate(CancelForm));
        }

        // Token: 0x060002A0 RID: 672 RVA: 0x0000E6F0 File Offset: 0x0000C8F0
        public static bool CopyFromScreen(Image img, Point location)
        {
            var result = true;
            var intPtr = IntPtr.Zero;
            Graphics graphics = null;
            try
            {
                intPtr = CaptureForm.GetDC(IntPtr.Zero);
                graphics = Graphics.FromImage(img);
                {
                    var intPtr2 = IntPtr.Zero;
                    try
                    {
                        intPtr2 = graphics.GetHdc();
                        CaptureForm.BitBlt(intPtr2, 0, 0, img.Width, img.Height, intPtr, location.X, location.Y, 1087111200);

                        if (Mainform.Instance.optSetuna.Setuna.CursorEnabled)
                        {
                            var cursorPos = Cursor.Position;
                            cursorPos.X -= targetScreen.Bounds.X;
                            WindowsAPI.DrawCursorImageToScreenImage(cursorPos, intPtr2);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }
                    finally
                    {
                        if (intPtr2 != IntPtr.Zero)
                        {
                            graphics.ReleaseHdc(intPtr2);
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2);
                result = false;
            }
            finally
            {
                graphics.Dispose();

                if (intPtr != IntPtr.Zero)
                {
                    CaptureForm.DeleteDC(intPtr);
                }
            }
            return result;
        }

        // Token: 0x060002A1 RID: 673 RVA: 0x0000E7E4 File Offset: 0x0000C9E4
        private void ShowForm()
        {
            Cursor.Current = Cursors.Cross;

            base.Opacity = 0.0099999997764825821;
            base.Visible = true;
            base.Opacity = 0.0099999997764825821;

            if (Mainform.Instance.optSetuna.Setuna.FullscreenCursor)
            {
                fullscreenHorLine.Opacity = base.Opacity;
                fullscreenHorLine.Visible = base.Visible;
                fullscreenVerLine.Opacity = base.Opacity;
                fullscreenVerLine.Visible = base.Visible;
                fullscreenHorLine.Refresh();
                fullscreenVerLine.Refresh();
            }

            if (Mainform.Instance.optSetuna.Setuna.MagnifierEnabled)
            {
                magnifier.Opacity = base.Opacity;
                magnifier.Visible = base.Visible;
                magnifier.Refresh();
            }

            Refresh();
            Thread.Sleep(10);
            base.Opacity = 0.99000000953674316;

            if (Mainform.Instance.optSetuna.Setuna.FullscreenCursor)
            {
                fullscreenHorLine.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y, targetScreen.Bounds.Width, 1);
                fullscreenVerLine.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y, 1, targetScreen.Bounds.Height);

                fullscreenHorLine.Opacity = base.Opacity;
                fullscreenVerLine.Opacity = base.Opacity;
            }

            if (Mainform.Instance.optSetuna.Setuna.MagnifierEnabled)
            {
                magnifier.SetLocation(magnifier.LocationType);
                magnifier.Opacity = base.Opacity;
            }
        }

        // Token: 0x060002A2 RID: 674 RVA: 0x0000E832 File Offset: 0x0000CA32
        private void CancelForm()
        {
            base.DialogResult = DialogResult.Cancel;
            EndCapture();
        }

        // Token: 0x060002A3 RID: 675 RVA: 0x0000E841 File Offset: 0x0000CA41
        private void LineRefresh()
        {
            CaptureForm.selLineVer1.Refresh();
            CaptureForm.selLineVer2.Refresh();
            CaptureForm.selLineHor1.Refresh();
            CaptureForm.selLineHor2.Refresh();
        }

        // Token: 0x060002A4 RID: 676 RVA: 0x0000E86C File Offset: 0x0000CA6C
        ~CaptureForm()
        {
        }

        // Token: 0x060002A5 RID: 677 RVA: 0x0000E894 File Offset: 0x0000CA94
        public new void Hide()
        {
            Console.WriteLine("Hide Start---");
            CaptureForm.selArea.Hide();
            CaptureForm.selLineHor1.Hide();
            CaptureForm.selLineHor2.Hide();
            CaptureForm.selLineVer1.Hide();
            CaptureForm.selLineVer2.Hide();
            CaptureForm.selArea.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y, 1, 1);
            CaptureForm.selLineHor1.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y - 10, targetScreen.Bounds.Width, 1);
            CaptureForm.selLineHor2.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y - 10, targetScreen.Bounds.Width, 1);
            CaptureForm.selLineVer1.SetBounds(targetScreen.Bounds.X - 10, targetScreen.Bounds.Y, 1, targetScreen.Bounds.Height);
            CaptureForm.selLineVer2.SetBounds(targetScreen.Bounds.X - 10, targetScreen.Bounds.Y, 1, targetScreen.Bounds.Height);

            fullscreenHorLine.Hide();
            fullscreenVerLine.Hide();
            fullscreenHorLine.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y, targetScreen.Bounds.Width, 1);
            fullscreenVerLine.SetBounds(targetScreen.Bounds.X, targetScreen.Bounds.Y, 1, targetScreen.Bounds.Height);

            magnifier.Hide();

            base.Hide();
            Console.WriteLine("Hide end---");
        }

        // Token: 0x060002A6 RID: 678 RVA: 0x0000EA54 File Offset: 0x0000CC54
        protected override void OnClosing(CancelEventArgs e)
        {
            if (bmpClip != null)
            {
                bmpClip.Dispose();
            }
            bmpClip = null;
            Console.WriteLine("打开截取");
            base.OnClosing(e);
        }

        // Token: 0x060002A7 RID: 679 RVA: 0x0000EA84 File Offset: 0x0000CC84
        private void DrawSelRect()
        {
            var point = default(Point);
            var point2 = default(Point);
            ptEnd = new Point(Cursor.Position.X, Cursor.Position.Y);
            if (ptEnd.X == ptPrevEnd.X && ptEnd.Y == ptPrevEnd.Y)
            {
                return;
            }
            ptPrevEnd.X = ptEnd.X;
            ptPrevEnd.Y = ptEnd.Y;
            point.X = Math.Min(ptStart.X, ptEnd.X);
            point.Y = Math.Min(ptStart.Y, ptEnd.Y);
            point2.X = Math.Max(ptStart.X, ptEnd.X);
            point2.Y = Math.Max(ptStart.Y, ptEnd.Y);
            DrawSelectArea(point.X, point.Y, point2.X - point.X, point2.Y - point.Y, BoundsSpecified.All);
        }

        private void CaptureForm_VisibleChanged(object sender, System.EventArgs e)
        {
            if (Visible)
            {
                TopMost = true;
                Layer.LayerManager.Instance.SuspendRefresh();
            }
            else
            {
                Layer.LayerManager.Instance.ResumeRefresh();
            }
        }

        // Token: 0x060002A8 RID: 680 RVA: 0x0000EBDF File Offset: 0x0000CDDF
        private void CaptureForm_Paint(object sender, PaintEventArgs e)
        {
            if (CaptureForm.imgSnap != null)
            {
                e.Graphics.DrawImageUnscaled(CaptureForm.imgSnap, 0, 0);
            }
        }

        // Token: 0x060002A9 RID: 681 RVA: 0x0000EBFA File Offset: 0x0000CDFA
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        // Token: 0x060002AA RID: 682 RVA: 0x0000EBFC File Offset: 0x0000CDFC
        private void CaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        // Token: 0x060002AB RID: 683 RVA: 0x0000EC00 File Offset: 0x0000CE00
        private void CaptureForm_MouseDown(object sender, MouseEventArgs e)
        {
            ptStart.X = targetScreen.Bounds.X + e.X;
            ptStart.Y = targetScreen.Bounds.Y + e.Y;
            DrawSelectArea(0, 0, 1, 1, BoundsSpecified.Size);
            blDrag = true;
        }

        // Token: 0x060002AC RID: 684 RVA: 0x0000EC7C File Offset: 0x0000CE7C
        private void DrawSelectArea(int x1, int y1, int x2, int y2, BoundsSpecified bound)
        {
            var rectangle = new Rectangle(CaptureForm.selArea.Location, CaptureForm.selArea.Size);
            if ((bound & BoundsSpecified.Size) != BoundsSpecified.None && blAreaVisible)
            {
                rectangle.Width = x2;
                rectangle.Height = y2;
            }
            if ((bound & BoundsSpecified.Location) != BoundsSpecified.None && blAreaVisible)
            {
                rectangle.X = x1;
                rectangle.Y = y1;
            }
            var visible = x1 != 0 || y1 != 0 || x2 != 1 || y2 != 1;
            CaptureForm.selLineHor1.Visible = visible;
            CaptureForm.selLineHor2.Visible = visible;
            CaptureForm.selLineVer1.Visible = visible;
            CaptureForm.selLineVer2.Visible = visible;
            CaptureForm.selArea.Visible = visible;
            CaptureForm.selLineHor1.SetSelSize(x1 - targetScreen.Bounds.X, x2);
            if (CaptureForm.selLineHor1.Top != y1)
            {
                CaptureForm.selLineHor1.Top = y1;
            }
            CaptureForm.selLineHor2.SetSelSize(x1 - targetScreen.Bounds.X, x2);
            if (CaptureForm.selLineHor2.Top != y1 + y2)
            {
                CaptureForm.selLineHor2.Top = y1 + y2;
            }
            CaptureForm.selLineVer1.SetSelSize(y1 - targetScreen.Bounds.Y, y2);
            if (CaptureForm.selLineVer1.Left != x1)
            {
                CaptureForm.selLineVer1.Left = x1;
            }
            CaptureForm.selLineVer2.SetSelSize(y1 - targetScreen.Bounds.Y, y2);
            if (CaptureForm.selLineVer2.Left != x1 + x2)
            {
                CaptureForm.selLineVer2.Left = x1 + x2;
            }
            if (blAreaVisible)
            {
                try
                {
                    CaptureForm.selArea.SetBounds(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, BoundsSpecified.All);
                    CaptureForm.selArea.Refresh();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("CaptureForm DrawSelectArea Exception: " + ex.Message);
                }
            }
        }

        // Token: 0x060002AD RID: 685 RVA: 0x0000EE84 File Offset: 0x0000D084
        private void CaptureForm_MouseUp(object sender, MouseEventArgs e)
        {
            ptEnd.X = targetScreen.Bounds.X + e.X;
            ptEnd.Y = targetScreen.Bounds.Y + e.Y;
            blDrag = false;
            EntryCapture(ptStart, ptEnd);
        }

        // Token: 0x060002AE RID: 686 RVA: 0x0000EEF4 File Offset: 0x0000D0F4
        private void CaptureForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mainform.Instance.optSetuna.Setuna.FullscreenCursor)
            {
                var cursorPos = Cursor.Position;

                fullscreenHorLine.SetSelSize(0, targetScreen.Bounds.Width);
                fullscreenHorLine.Top = cursorPos.Y;
                fullscreenVerLine.SetSelSize(0, targetScreen.Bounds.Height);
                fullscreenVerLine.Left = cursorPos.X;
            }

            if (blDrag)
            {
                DrawSelRect();
            }
            else
            {
                DrawSelectArea(0, 0, 1, 1, BoundsSpecified.All);
            }

            if (Mainform.Instance.optSetuna.Setuna.MagnifierEnabled)
            {
                var cursorPos = Cursor.Position;
                var point = Point.Empty;
                var point2 = Point.Empty;

                if (blDrag)
                {
                    point.X = Math.Min(ptStart.X, ptEnd.X);
                    point.Y = Math.Min(ptStart.Y, ptEnd.Y);
                    point2.X = Math.Max(ptStart.X, ptEnd.X);
                    point2.Y = Math.Max(ptStart.Y, ptEnd.Y);
                }

                magnifier.SetText(cursorPos.X, cursorPos.Y, point2.X - point.X, point2.Y - point.Y);
            }
        }

        // Token: 0x060002AF RID: 687 RVA: 0x0000EF14 File Offset: 0x0000D114
        public void EntryCapture(Point lptStart, Point lptEnd)
        {
            try
            {
                Console.WriteLine("EntryCapture Start---");
                Console.WriteLine(lptStart.ToString() + ", " + lptEnd.ToString());
                var point = new Point(Math.Min(lptStart.X, lptEnd.X), Math.Min(lptStart.Y, lptEnd.Y));
                ptClipStart = point;
                var size = new Size(Math.Abs(lptStart.X - lptEnd.X), Math.Abs(lptStart.Y - lptEnd.Y));
                ptClipSize = size;
                if (size.Width < 10 || size.Height < 10)
                {
                    base.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    CreateClip(point, size);
                    base.DialogResult = DialogResult.OK;
                    CaptureForm.rctLast = new Rectangle(point, size);
                }
                Console.WriteLine("EntryCapture End---");
                EndCapture();
            }
            catch (Exception ex)
            {
                Console.WriteLine("EntryCaptureException: " + ex.Message);
                Console.WriteLine("");
            }
        }

        // Token: 0x060002B0 RID: 688 RVA: 0x0000F03C File Offset: 0x0000D23C
        private void EndCapture()
        {
            Hide();
            if (CaptureClosedHandler != null)
            {
                CaptureClosedHandler(this);
            }
        }

        // Token: 0x060002B1 RID: 689 RVA: 0x0000F058 File Offset: 0x0000D258
        private void GetWindowInfo()
        {
            aryHWnd = new List<IntPtr>();
            var intPtr = CaptureForm.GetTopWindow(CaptureForm.GetDesktopWindow());
            while ((intPtr = CaptureForm.GetNextWindow(intPtr, 2U)) != IntPtr.Zero)
            {
                if (CaptureForm.IsWindowVisible(intPtr) != 0 && CaptureForm.GetWindow(intPtr, 4U) == IntPtr.Zero)
                {
                    aryHWnd.Add(intPtr);
                }
            }
        }

        // Token: 0x060002B2 RID: 690 RVA: 0x0000F0BC File Offset: 0x0000D2BC
        private void SelectWindowRect(Point ptMouse)
        {
            if (aryHWnd != null)
            {
                foreach (var hWnd in aryHWnd)
                {
                    if (CaptureForm.GetWindowRect(hWnd, out var rect) && rect.left <= ptMouse.X && ptMouse.X <= rect.right && rect.top <= ptMouse.Y && ptMouse.Y <= rect.bottom)
                    {
                        DrawSelectArea(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top, BoundsSpecified.All);
                        break;
                    }
                }
            }
        }

        // Token: 0x060002B3 RID: 691 RVA: 0x0000F19C File Offset: 0x0000D39C
        private void CreateClip(Point pt, Size size)
        {
            if (bmpClip != null)
            {
                bmpClip.Dispose();
            }
            bmpClip = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);
            using (var graphics = Graphics.FromImage(bmpClip))
            {
                graphics.DrawImageUnscaled(CaptureForm.imgSnap, -(pt.X - targetScreen.Bounds.X), -(pt.Y - targetScreen.Bounds.Y));
            }
        }

        // Token: 0x060002B5 RID: 693 RVA: 0x0000F278 File Offset: 0x0000D478
        private void CaptureForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '0')
            {
                Console.WriteLine("Captureform KeyPress Start---");
                var rectangle = CaptureForm.rctLast;
                EntryCapture(new Point(rectangle.Left, rectangle.Top), new Point(rectangle.Right, rectangle.Bottom));
                Console.WriteLine("Captureform KeyPress End---");
                return;
            }
            if (e.KeyChar == '\u001b')
            {
                base.DialogResult = DialogResult.Cancel;
                EndCapture();
            }
        }

        // Token: 0x060002B6 RID: 694 RVA: 0x0000F2F0 File Offset: 0x0000D4F0
        private void CaptureForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V && Clipboard.ContainsImage())
            {
                ptClipStart = Cursor.Position;
                bmpClip = (Bitmap)Clipboard.GetImage();
                base.DialogResult = DialogResult.OK;
                EndCapture();
            }
        }


        // Token: 0x04000127 RID: 295
        private const int GW_OWNER = 4;

        // Token: 0x04000128 RID: 296
        private const int GW_HWNDNEXT = 2;

        // Token: 0x04000129 RID: 297
        private const int SRCCOPY = 13369376;

        // Token: 0x0400012A RID: 298
        private const int CAPTUREBLT = 1073741824;

        // Token: 0x0400012B RID: 299
        private static Image imgSnap;

        // Token: 0x0400012C RID: 300
        private Bitmap bmpClip;

        // Token: 0x0400012D RID: 301
        private bool blDrag;

        // Token: 0x0400012E RID: 302
        private Point ptStart;

        // Token: 0x0400012F RID: 303
        private Point ptEnd;

        // Token: 0x04000130 RID: 304
        private Point ptPrevEnd;

        // Token: 0x04000131 RID: 305
        private Point ptClipStart;

        // Token: 0x04000132 RID: 306
        private Size ptClipSize;

        // Token: 0x04000133 RID: 307
        private static Screen targetScreen;

        // Token: 0x04000134 RID: 308
        private static Form selArea;

        // Token: 0x04000135 RID: 309
        private static CaptureSelLine selLineVer1;

        // Token: 0x04000136 RID: 310
        private static CaptureSelLine selLineVer2;

        // Token: 0x04000137 RID: 311
        private static CaptureSelLine selLineHor1;

        // Token: 0x04000138 RID: 312
        private static CaptureSelLine selLineHor2;

        // Token: 0x04000139 RID: 313
        private bool blAreaVisible;

        // Token: 0x0400013A RID: 314
        private static Rectangle rctLast = new Rectangle(0, 0, 0, 0);

        // Token: 0x0400013B RID: 315
        public CaptureForm.CaptureClosedDelegate CaptureClosedHandler;

        // Token: 0x0400013C RID: 316
        private Thread trd;

        // Token: 0x0400013D RID: 317
        private List<IntPtr> aryHWnd;

        // Token: 0x0200004E RID: 78
        // (Invoke) Token: 0x060002C9 RID: 713
        public delegate void CaptureClosedDelegate(CaptureForm cform);

        // Token: 0x0200006C RID: 108
        public struct POINT
        {
            // Token: 0x04000205 RID: 517
            public int x;

            // Token: 0x04000206 RID: 518
            public int y;
        }

        // Token: 0x0200006D RID: 109
        public struct RECT
        {
            // Token: 0x04000207 RID: 519
            public int left;

            // Token: 0x04000208 RID: 520
            public int top;

            // Token: 0x04000209 RID: 521
            public int right;

            // Token: 0x0400020A RID: 522
            public int bottom;
        }

        // Token: 0x0200006E RID: 110
        // (Invoke) Token: 0x060003A6 RID: 934
        private delegate int EnumWindowsCallBack(IntPtr hWnd, int lParam);

        // Token: 0x0200006F RID: 111
        // (Invoke) Token: 0x060003AA RID: 938
        private delegate void ShowFormDelegate();

        // Token: 0x02000070 RID: 112
        // (Invoke) Token: 0x060003AE RID: 942
        private delegate void LineRefreshDelegate();


        private static CaptureSelLine fullscreenHorLine;
        private static CaptureSelLine fullscreenVerLine;

        private static Magnifier magnifier;

    }
}
