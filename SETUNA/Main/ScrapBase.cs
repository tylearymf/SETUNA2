using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SETUNA.Main.Style;
using SETUNA.Main.StyleItems;

namespace SETUNA.Main
{
    // Token: 0x02000008 RID: 8
    public sealed partial class ScrapBase : BaseForm
    {
        // Token: 0x14000001 RID: 1
        // (add) Token: 0x06000037 RID: 55 RVA: 0x00003461 File Offset: 0x00001661
        // (remove) Token: 0x06000038 RID: 56 RVA: 0x0000347A File Offset: 0x0000167A
        public event ScrapBase.ScrapEventHandler ScrapCloseEvent;

        // Token: 0x14000002 RID: 2
        // (add) Token: 0x06000039 RID: 57 RVA: 0x00003493 File Offset: 0x00001693
        // (remove) Token: 0x0600003A RID: 58 RVA: 0x000034AC File Offset: 0x000016AC
        public event ScrapBase.ScrapEventHandler ScrapCreateEvent;

        // Token: 0x14000003 RID: 3
        // (add) Token: 0x0600003B RID: 59 RVA: 0x000034C5 File Offset: 0x000016C5
        // (remove) Token: 0x0600003C RID: 60 RVA: 0x000034DE File Offset: 0x000016DE
        public event ScrapBase.ScrapEventHandler ScrapActiveEvent;

        // Token: 0x14000004 RID: 4
        // (add) Token: 0x0600003D RID: 61 RVA: 0x000034F7 File Offset: 0x000016F7
        // (remove) Token: 0x0600003E RID: 62 RVA: 0x00003510 File Offset: 0x00001710
        public event ScrapBase.ScrapEventHandler ScrapInactiveEvent;

        // Token: 0x14000005 RID: 5
        // (add) Token: 0x0600003F RID: 63 RVA: 0x00003529 File Offset: 0x00001729
        // (remove) Token: 0x06000040 RID: 64 RVA: 0x00003542 File Offset: 0x00001742
        public event ScrapBase.ScrapEventHandler ScrapInactiveEnterEvent;

        // Token: 0x14000006 RID: 6
        // (add) Token: 0x06000041 RID: 65 RVA: 0x0000355B File Offset: 0x0000175B
        // (remove) Token: 0x06000042 RID: 66 RVA: 0x00003574 File Offset: 0x00001774
        public event ScrapBase.ScrapEventHandler ScrapInactiveOutEvent;

        // Token: 0x14000007 RID: 7
        // (add) Token: 0x06000043 RID: 67 RVA: 0x0000358D File Offset: 0x0000178D
        // (remove) Token: 0x06000044 RID: 68 RVA: 0x000035A6 File Offset: 0x000017A6
        public event ScrapBase.ScrapSubMenuHandler ScrapSubMenuOpening;

        public event ScrapBase.ScrapEventHandler ScrapLocationChangedEvent;

        public event ScrapBase.ScrapEventHandler ScrapImageChangedEvent;

        public event ScrapBase.ScrapEventHandler ScrapStyleAppliedEvent;

        public event ScrapBase.ScrapEventHandler ScrapStyleRemovedEvent;


        // Token: 0x1700000C RID: 12
        // (get) Token: 0x06000046 RID: 70 RVA: 0x000035DC File Offset: 0x000017DC
        // (set) Token: 0x06000045 RID: 69 RVA: 0x000035BF File Offset: 0x000017BF
        public double ActiveOpacity
        {
            get => _activeOpacity;
            set
            {
                _activeOpacity = value;
                if (ActiveForm == this)
                {
                    Opacity = _activeOpacity;
                }
            }
        }

        // Token: 0x1700000D RID: 13
        // (get) Token: 0x06000048 RID: 72 RVA: 0x00003609 File Offset: 0x00001809
        // (set) Token: 0x06000047 RID: 71 RVA: 0x000035E4 File Offset: 0x000017E4
        public double InactiveOpacity
        {
            get => _inactiveOpacity;
            set
            {
                _inactiveOpacity = value;
                if (ActiveForm != this && !_isMouseEnter)
                {
                    Opacity = _inactiveOpacity;
                }
            }
        }

        // Token: 0x1700000E RID: 14
        // (get) Token: 0x0600004A RID: 74 RVA: 0x00003636 File Offset: 0x00001836
        // (set) Token: 0x06000049 RID: 73 RVA: 0x00003611 File Offset: 0x00001811
        public double RollOverOpacity
        {
            get => _rolloverOpacity;
            set
            {
                _rolloverOpacity = value;
                if (ActiveForm != this && _isMouseEnter)
                {
                    Opacity = _rolloverOpacity;
                }
            }
        }

        // Token: 0x1700000F RID: 15
        // (get) Token: 0x0600004C RID: 76 RVA: 0x00003658 File Offset: 0x00001858
        // (set) Token: 0x0600004B RID: 75 RVA: 0x0000363E File Offset: 0x0000183E
        public int ActiveMargin
        {
            get => _activeMargin;
            set
            {
                _activeMargin = value;
                Padding = new Padding(_activeMargin);
            }
        }

        // Token: 0x17000010 RID: 16
        // (get) Token: 0x0600004E RID: 78 RVA: 0x0000368A File Offset: 0x0000188A
        // (set) Token: 0x0600004D RID: 77 RVA: 0x00003660 File Offset: 0x00001860
        public int InactiveMargin
        {
            get => _inactiveMargin;
            set
            {
                _inactiveMargin = value;
                if (ActiveForm != this && !_isMouseEnter)
                {
                    Padding = new Padding(_inactiveMargin);
                }
            }
        }

        // Token: 0x17000011 RID: 17
        // (get) Token: 0x06000050 RID: 80 RVA: 0x000036BC File Offset: 0x000018BC
        // (set) Token: 0x0600004F RID: 79 RVA: 0x00003692 File Offset: 0x00001892
        public int RollOverMargin
        {
            get => _rolloverMargin;
            set
            {
                _rolloverMargin = value;
                if (ActiveForm != this && _isMouseEnter)
                {
                    Padding = new Padding(_rolloverMargin);
                }
            }
        }

        // Token: 0x06000051 RID: 81 RVA: 0x000036C4 File Offset: 0x000018C4
        public ScrapBase()
        {
            InitializeComponent();
            base.KeyPreview = true;
            closePrepare = false;
            _dragmode = false;
            _scale = 100;
            _opacity = base.Opacity;
            _blTargetSet = false;
            _ptTarget = default(Point);
            _solidframe = true;
            _inactiveOpacity = Opacity;
            _activeOpacity = Opacity;
            _rolloverOpacity = Opacity;
            DateTime = System.DateTime.Now;
            Name = DateTime.ToCustomString();
            _interpolationmode = InterpolationMode.HighQualityBicubic;
        }

        // Token: 0x06000052 RID: 82 RVA: 0x000037B8 File Offset: 0x000019B8
        ~ScrapBase()
        {
            ImageAllDispose();
        }

        // Token: 0x06000054 RID: 84 RVA: 0x000039BE File Offset: 0x00001BBE
        private void ImageAllDispose()
        {
            ImageDispose(ref imgView);
        }

        // Token: 0x17000012 RID: 18
        // (get) Token: 0x06000056 RID: 86 RVA: 0x000039EF File Offset: 0x00001BEF
        // (set) Token: 0x06000055 RID: 85 RVA: 0x000039CC File Offset: 0x00001BCC
        public new double Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                if (_opacity != base.Opacity)
                {
                    timOpacity.Enabled = true;
                }
            }
        }

        // Token: 0x17000013 RID: 19
        // (get) Token: 0x06000058 RID: 88 RVA: 0x00003A00 File Offset: 0x00001C00
        // (set) Token: 0x06000057 RID: 87 RVA: 0x000039F7 File Offset: 0x00001BF7
        public bool SolidFrame
        {
            get => _solidframe;
            set => _solidframe = value;
        }

        // Token: 0x06000059 RID: 89
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        // Token: 0x0600005A RID: 90
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        // Token: 0x0600005B RID: 91 RVA: 0x00003A08 File Offset: 0x00001C08
        private void timOpacity_Tick(object sender, EventArgs e)
        {
            try
            {
                if (base.Opacity != _opacity)
                {
                    if (_err_opac)
                    {
                        try
                        {
                            _opacity = 1.0;
                            base.Opacity = 1.0;
                            goto IL_166;
                        }
                        catch
                        {
                            Console.WriteLine("ScrapBase timOpacity_Tick Exception2:---");
                            goto IL_166;
                        }
                    }
                    var num = base.Opacity - _opacity;
                    if (Math.Abs(num) < 0.10000000149011612)
                    {
                        try
                        {
                            if (base.Opacity != _opacity)
                            {
                                base.Opacity = _opacity;
                            }
                            goto IL_166;
                        }
                        catch (Win32Exception ex)
                        {
                            timOpacity.Stop();
                            _err_opac = true;
                            Opacity = 1.0;
                            Console.WriteLine("ScrapBase timOpacity_Tick Exception: " + ex.Message + ", Opaque True");
                            goto IL_166;
                        }
                        catch (Exception ex2)
                        {
                            Console.WriteLine(string.Concat(new string[]
                            {
                                "ScrapBase timOpacity_Tick Exception: ",
                                ex2.Message,
                                ", ",
                                base.Opacity.ToString(),
                                ", ",
                                _opacity.ToString()
                            }));
                            goto IL_166;
                        }
                    }
                    if (num < 0.0)
                    {
                        base.Opacity += 0.10000000149011612;
                    }
                    else
                    {
                        base.Opacity -= 0.10000000149011612;
                    }
                }
            IL_166:
                if (_blTargetSet)
                {
                    var num2 = base.Top - _ptTarget.Y;
                    int num3;
                    if (num2 > 0)
                    {
                        num3 = -(Math.Abs(num2) / 3);
                    }
                    else
                    {
                        num3 = Math.Abs(num2) / 3;
                    }
                    if (num3 == 0)
                    {
                        base.Top = _ptTarget.Y;
                    }
                    else
                    {
                        base.Top += num3;
                    }
                    var num4 = base.Left - _ptTarget.X;
                    int num5;
                    if (num4 > 0)
                    {
                        num5 = -(Math.Abs(num4) / 2);
                    }
                    else
                    {
                        num5 = Math.Abs(num4) / 2;
                    }
                    if (num5 == 0)
                    {
                        base.Left = _ptTarget.X;
                    }
                    else
                    {
                        base.Left += num5;
                    }
                    if (base.Top == _ptTarget.Y && base.Left == _ptTarget.X)
                    {
                        _blTargetSet = false;
                    }
                    else
                    {
                        Refresh();
                    }
                }
                if (base.Opacity == _opacity && !_blTargetSet)
                {
                    timOpacity.Enabled = false;
                }
            }
            catch (Exception ex3)
            {
                Console.WriteLine("ScrapBase timOpacity_Tick Exception:" + ex3.Message);
            }
        }

        // Token: 0x17000014 RID: 20
        // (get) Token: 0x0600005D RID: 93 RVA: 0x00003D3B File Offset: 0x00001F3B
        // (set) Token: 0x0600005C RID: 92 RVA: 0x00003D0C File Offset: 0x00001F0C
        public Point TargetLocation
        {
            get
            {
                if (_blTargetSet)
                {
                    return _ptTarget;
                }
                return base.Location;
            }
            set
            {
                _ptTarget = value;
                if (_ptTarget != base.Location)
                {
                    _blTargetSet = true;
                    timOpacity.Enabled = true;
                }
            }
        }

        // Token: 0x0600005E RID: 94 RVA: 0x00003D52 File Offset: 0x00001F52
        private void ImageDispose(ref Image img)
        {
            if (img != null)
            {
                img.Dispose();
                img = null;
            }
        }

        // Token: 0x0600005F RID: 95 RVA: 0x00003D62 File Offset: 0x00001F62
        private void ScrapBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                base.Close();
            }
        }

        // Token: 0x17000015 RID: 21
        // (get) Token: 0x06000061 RID: 97 RVA: 0x00003DBB File Offset: 0x00001FBB
        // (set) Token: 0x06000060 RID: 96 RVA: 0x00003D7E File Offset: 0x00001F7E
        public Image Image
        {
            get => imgView;
            set
            {
                ImageAllDispose();
                imgView = (Image)value.Clone();
                if (imgView == null)
                {
                    Console.WriteLine("ScrapBase Image : unll");
                }
                Scale = Scale;
                Refresh();

                if (ScrapImageChangedEvent != null)
                {
                    ScrapImageChangedEvent(this, new ScrapEventArgs(this));
                }
            }
        }

        // Token: 0x06000062 RID: 98 RVA: 0x00003DC4 File Offset: 0x00001FC4
        public Image GetViewImage()
        {
            var bitmap = new Bitmap(base.Width, base.Height, PixelFormat.Format24bppRgb);
            base.DrawToBitmap(bitmap, new Rectangle(0, 0, base.Width, base.Height));
            return bitmap;
        }

        // Token: 0x06000063 RID: 99 RVA: 0x00003E04 File Offset: 0x00002004
        public Image GetThumbnail()
        {
            var bitmap = new Bitmap(230, 150, PixelFormat.Format24bppRgb);
            var graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(Brushes.DarkGray, 0, 0, bitmap.Width, bitmap.Height);
            if (imgView.Width <= bitmap.Width - 1 || imgView.Height <= bitmap.Height - 1)
            {
                graphics.DrawImageUnscaled(imgView, 1, 1);
            }
            else
            {
                var size = new Size(imgView.Width - 1, imgView.Height - 1);
                double num;
                if (size.Width - bitmap.Width - 1 <= size.Height - bitmap.Height - 1)
                {
                    num = (bitmap.Width - 1) / (double)(size.Width - 1);
                }
                else
                {
                    num = (bitmap.Height - 1) / (double)(size.Height - 1);
                }
                size.Width = (int)(size.Width * num);
                size.Height = (int)(size.Height * num);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(imgView, 1, 1, size.Width, size.Height);
            }
            graphics.DrawRectangle(Pens.Black, 0, 0, bitmap.Width - 1, bitmap.Height - 1);
            return bitmap;
        }

        // Token: 0x06000064 RID: 100 RVA: 0x00003F58 File Offset: 0x00002158
        public void ScrapResize()
        {
            base.Width = imgView.Width + (Padding.Left + Padding.Right);
            base.Height = imgView.Height + (Padding.Top + Padding.Bottom);
        }

        // Token: 0x06000065 RID: 101 RVA: 0x00003FC4 File Offset: 0x000021C4
        protected override void OnPaint(PaintEventArgs e)
        {
            //var width = (int)(imgView.Width * (_scale / 100f));
            //var height = (int)(imgView.Height * (_scale / 100f));
            var all = Padding.All;
            e.Graphics.InterpolationMode = _interpolationmode;
            //e.Graphics.DrawImage(imgView, all, all, width, height);
            e.Graphics.DrawImage(imgView, all, all, Width - all * 2, Height - all * 2);
            if (!_solidframe)
            {
                var pen = new Pen(Color.FromArgb(243, 243, 243));
                e.Graphics.DrawLine(pen, 0, 0, Width, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, Height);
                pen.Dispose();
            }
        }

        // Token: 0x17000016 RID: 22
        // (get) Token: 0x06000067 RID: 103 RVA: 0x0000409C File Offset: 0x0000229C
        // (set) Token: 0x06000066 RID: 102 RVA: 0x00004093 File Offset: 0x00002293
        public InterpolationMode InterpolationMode
        {
            get => _interpolationmode;
            set => _interpolationmode = value;
        }

        // Token: 0x17000017 RID: 23
        // (get) Token: 0x06000069 RID: 105 RVA: 0x0000416A File Offset: 0x0000236A
        // (set) Token: 0x06000068 RID: 104 RVA: 0x000040A4 File Offset: 0x000022A4
        public new Padding Padding
        {
            get => base.Padding;
            set
            {
                base.Padding = value;

                var x = Left - value.All;
                var y = Top - value.All;
                var num = (int)(imgView.Width * (_scale / 100f)) + value.All * 2;
                var num2 = (int)(imgView.Height * (_scale / 100f)) + value.All * 2;
                SetBoundsCore(x, y, num, num2, BoundsSpecified.Location);
                base.ClientSize = new Size(num, num2);
            }
        }

        // Token: 0x0600006A RID: 106 RVA: 0x00004174 File Offset: 0x00002374
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown)
            {
                Console.WriteLine("由系统结束");
            }
            else if (!closePrepare)
            {
                e.Cancel = true;
                OnScrapClose(new ScrapEventArgs(this));
            }
            base.OnFormClosing(e);
        }

        // Token: 0x0600006B RID: 107 RVA: 0x000041C9 File Offset: 0x000023C9
        protected override void OnClosed(EventArgs e)
        {
            ImageAllDispose();
            _applyFinished = null;

            base.OnClosed(e);
        }

        // Token: 0x0600006C RID: 108 RVA: 0x000041D8 File Offset: 0x000023D8
        public void OnScrapClose(ScrapEventArgs e)
        {
            if (ScrapCloseEvent != null)
            {
                ScrapCloseEvent(this, e);
            }
        }

        // Token: 0x0600006D RID: 109 RVA: 0x000041EF File Offset: 0x000023EF
        public void ScrapClose()
        {
            closePrepare = true;
            base.Close();
            GC.Collect();
        }

        // Token: 0x17000018 RID: 24
        // (get) Token: 0x0600006F RID: 111 RVA: 0x0000425E File Offset: 0x0000245E
        // (set) Token: 0x0600006E RID: 110 RVA: 0x00004204 File Offset: 0x00002404
        public ScrapBook Manager
        {
            get => _parent;
            set
            {
                _parent = value;
                if (ScrapCloseEvent == null)
                {
                    ScrapCloseEvent = (ScrapBase.ScrapEventHandler)Delegate.Combine(ScrapCloseEvent, new ScrapBase.ScrapEventHandler(_parent.ScrapClose));
                    base.KeyDown += _parent.OnKeyUp;
                }
            }
        }

        // Token: 0x17000019 RID: 25
        // (get) Token: 0x06000071 RID: 113 RVA: 0x0000427B File Offset: 0x0000247B
        // (set) Token: 0x06000070 RID: 112 RVA: 0x00004266 File Offset: 0x00002466
        public new string Name
        {
            get => _name;
            set
            {
                _name = value;
                Text = _name;
            }
        }

        // Token: 0x1700001A RID: 26
        // (get) Token: 0x06000073 RID: 115 RVA: 0x0000428C File Offset: 0x0000248C
        // (set) Token: 0x06000072 RID: 114 RVA: 0x00004283 File Offset: 0x00002483
        public DateTime DateTime
        {
            get => _datetime;
            set => _datetime = value;
        }

        // Token: 0x1700001B RID: 27
        // (get) Token: 0x06000075 RID: 117 RVA: 0x00004342 File Offset: 0x00002542
        // (set) Token: 0x06000074 RID: 116 RVA: 0x00004294 File Offset: 0x00002494
        public new int Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                if (_scale < -200)
                {
                    _scale = -200;
                }
                if (_scale > 200)
                {
                    _scale = 200;
                }
                base.Width = (int)(imgView.Width * (_scale / 100f)) + Padding.All * 2;
                base.Height = (int)(imgView.Height * (_scale / 100f)) + Padding.All * 2;
                Refresh();
            }
        }

        public int StyleID => _styleID;

        public Point StyleClickPoint => _styleClickPoint;

        public Cache.CacheItem CacheItem
        {
            set => _cacheItem = value;
            get => _cacheItem;
        }

        public Form StyleForm { set; get; }

        // Token: 0x06000076 RID: 118 RVA: 0x0000434A File Offset: 0x0000254A
        private void DragStart(Point pt)
        {
            _dragmode = true;
            _dragpoint = pt;
            _saveopacity = Opacity;
            base.SuspendLayout();
            Opacity = 0.5;
            base.ResumeLayout();
        }

        // Token: 0x06000077 RID: 119 RVA: 0x00004381 File Offset: 0x00002581
        private void DragEnd()
        {
            _dragmode = false;
            base.SuspendLayout();
            Opacity = _saveopacity;
            base.ResumeLayout();
        }

        // Token: 0x06000078 RID: 120 RVA: 0x000043A4 File Offset: 0x000025A4
        private void DragMove(Point pt)
        {
            if (_dragmode)
            {
                base.Left += pt.X - _dragpoint.X;
                base.Top += pt.Y - _dragpoint.Y;
            }
        }

        // Token: 0x06000079 RID: 121 RVA: 0x000043F9 File Offset: 0x000025F9
        private void pnlImg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DragStart(e.Location);
            }
        }

        // Token: 0x0600007A RID: 122 RVA: 0x00004414 File Offset: 0x00002614
        private void pnlImg_MouseMove(object sender, MouseEventArgs e)
        {
            DragMove(e.Location);
        }

        // Token: 0x0600007B RID: 123 RVA: 0x00004422 File Offset: 0x00002622
        private void pnlImg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DragEnd();
            }
        }

        // Token: 0x0600007C RID: 124 RVA: 0x00004438 File Offset: 0x00002638
        public void addScrapStyleEvent(IScrapStyleListener listener)
        {
            ScrapCreateEvent = (ScrapBase.ScrapEventHandler)Delegate.Combine(ScrapCreateEvent, new ScrapBase.ScrapEventHandler(listener.ScrapCreated));
            ScrapActiveEvent = (ScrapBase.ScrapEventHandler)Delegate.Combine(ScrapActiveEvent, new ScrapBase.ScrapEventHandler(listener.ScrapActivated));
            ScrapInactiveEvent = (ScrapBase.ScrapEventHandler)Delegate.Combine(ScrapInactiveEvent, new ScrapBase.ScrapEventHandler(listener.ScrapInactived));
            ScrapInactiveEnterEvent = (ScrapBase.ScrapEventHandler)Delegate.Combine(ScrapInactiveEnterEvent, new ScrapBase.ScrapEventHandler(listener.ScrapInactiveMouseOver));
            ScrapInactiveOutEvent = (ScrapBase.ScrapEventHandler)Delegate.Combine(ScrapInactiveOutEvent, new ScrapBase.ScrapEventHandler(listener.ScrapInactiveMouseOut));
        }

        // Token: 0x0600007D RID: 125 RVA: 0x000044F4 File Offset: 0x000026F4
        public void OnScrapCreated()
        {
            if (ScrapCreateEvent != null)
            {
                ScrapCreateEvent(this, new ScrapEventArgs(this));
            }
        }

        // Token: 0x0600007E RID: 126 RVA: 0x00004510 File Offset: 0x00002710
        private void ScrapBase_Activated(object sender, EventArgs e)
        {
            if (ScrapActiveEvent != null)
            {
                ScrapActiveEvent(sender, new ScrapEventArgs(this));
            }

            ActiveForm = this;
            Opacity = ActiveOpacity;
        }

        // Token: 0x0600007F RID: 127 RVA: 0x00004538 File Offset: 0x00002738
        private void ScrapBase_Deactivate(object sender, EventArgs e)
        {
            if (ScrapInactiveEvent != null)
            {
                ScrapInactiveEvent(sender, new ScrapEventArgs(this));
            }
            if (!_isMouseEnter)
            {
                Opacity = InactiveOpacity;
            }
        }

        // Token: 0x06000080 RID: 128 RVA: 0x00004568 File Offset: 0x00002768
        private void ScrapBase_MouseEnter(object sender, EventArgs e)
        {
            _isMouseEnter = true;
            if (!Focused && ScrapInactiveEnterEvent != null)
            {
                ScrapInactiveEnterEvent(sender, new ScrapEventArgs(this));
            }
            if (ActiveForm != this)
            {
                Opacity = RollOverOpacity;
            }
        }

        // Token: 0x06000081 RID: 129 RVA: 0x000045A7 File Offset: 0x000027A7
        private void ScrapBase_MouseLeave(object sender, EventArgs e)
        {
            _isMouseEnter = false;
            if (!Focused && ScrapInactiveOutEvent != null)
            {
                ScrapInactiveOutEvent(sender, new ScrapEventArgs(this));
            }
            if (ActiveForm != this)
            {
                Opacity = InactiveOpacity;
            }
        }

        // Token: 0x06000082 RID: 130 RVA: 0x000045E6 File Offset: 0x000027E6
        public void addScrapMenuEvent(IScrapMenuListener listener)
        {
            ScrapSubMenuOpening = (ScrapBase.ScrapSubMenuHandler)Delegate.Combine(ScrapSubMenuOpening, new ScrapBase.ScrapSubMenuHandler(listener.ScrapMenuOpening));
        }

        public void addScrapLocationChangedEvent(IScrapLocationChangedListener listener)
        {
            ScrapLocationChangedEvent = (ScrapBase.ScrapEventHandler)Delegate.Combine(ScrapLocationChangedEvent, new ScrapBase.ScrapEventHandler(listener.ScrapLocationChanged));
        }

        public void fireScrapLocationChangedEvent()
        {
            if (ScrapLocationChangedEvent != null)
            {
                ScrapLocationChangedEvent(this, new ScrapEventArgs(this));
            }
        }

        public void addScrapImageChangedEvent(IScrapImageChangedListener listener)
        {
            ScrapImageChangedEvent = (ScrapBase.ScrapEventHandler)Delegate.Combine(ScrapImageChangedEvent, new ScrapBase.ScrapEventHandler(listener.ScrapImageChanged));
        }

        public void addScrapStyleAppliedEvent(IScrapStyleAppliedListener listener)
        {
            ScrapStyleAppliedEvent = (ScrapBase.ScrapEventHandler)Delegate.Combine(ScrapStyleAppliedEvent, new ScrapBase.ScrapEventHandler(listener.ScrapStyleApplied));
        }

        public void addScrapStyleRemovedEvent(IScrapStyleRemovedListener listener)
        {
            ScrapStyleRemovedEvent = (ScrapBase.ScrapEventHandler)Delegate.Combine(ScrapStyleRemovedEvent, new ScrapBase.ScrapEventHandler(listener.ScrapStyleRemoved));
        }


        // Token: 0x06000083 RID: 131 RVA: 0x0000460B File Offset: 0x0000280B
        private void ScrapBase_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ScrapSubMenuOpening != null)
            {
                ScrapSubMenuOpening(sender, new ScrapMenuArgs(this, null));
            }
        }

        // Token: 0x1700001C RID: 28
        // (get) Token: 0x06000085 RID: 133 RVA: 0x00004664 File Offset: 0x00002864
        // (set) Token: 0x06000084 RID: 132 RVA: 0x00004635 File Offset: 0x00002835
        public new bool Visible
        {
            get => base.Visible;
            set
            {
                if (!value && base.FormBorderStyle != FormBorderStyle.None)
                {
                    base.ShowInTaskbar = false;
                }
                else if (value && base.FormBorderStyle != FormBorderStyle.None)
                {
                    base.ShowInTaskbar = true;
                }
                base.Visible = value;

                _visible = value;
            }
        }

        // Token: 0x06000086 RID: 134 RVA: 0x0000466C File Offset: 0x0000286C
        public new void SetBounds(int x, int y, int width, int height, BoundsSpecified specified)
        {
            SetBoundsCore(x, y, width, height, specified);
        }

        public void ApplyStylesFromCache(CStyle style, Point clickpoint, Action applyFinished = null)
        {
            var styleItems = new List<CStyleItem>(style.Items);
            styleItems.RemoveAll(x => !StyleItemDictionary.CanRestore(x.GetType()));

            _applyFinished = applyFinished;
            ApplyStyles(style.StyleID, styleItems.ToArray(), clickpoint);
        }

        // Token: 0x06000087 RID: 135 RVA: 0x0000467C File Offset: 0x0000287C
        public void ApplyStyles(int styleID, CStyleItem[] styleItems, Point clickpoint)
        {
            if (IsStyleApply)
            {
                return;
            }
            _styleClickPoint = clickpoint;
            IsStyleApply = true;
            StyleAppliIndex = 0;
            _styleID = styleID;
            _styleItems = styleItems.ToList();
            if (StyleApplyTimer == null)
            {
                StyleApplyTimer = new Timer
                {
                    Enabled = false
                };
                StyleApplyTimer.Tick += ApplyStyleItem;
            }
            StyleApplyTimer.Interval = 1;
            StyleApplyTimer.Start();
        }

        // Token: 0x06000088 RID: 136 RVA: 0x000046FC File Offset: 0x000028FC
        public void ApplyStyleItem(object sender, EventArgs e)
        {
            StyleApplyTimer.Enabled = false;
            if (StyleAppliIndex < _styleItems.Count)
            {
                var num = 1;
                var scrapBase = this;
                try
                {
                    var cstyleItem = _styleItems[StyleAppliIndex];
                    if (Initialized || (!Initialized && cstyleItem.IsInitApply))
                    {
                        cstyleItem.Apply(ref scrapBase, out num, _styleClickPoint);
                    }
                    StyleAppliIndex++;
                    if (num <= 0)
                    {
                        num = 1;
                    }
                    StyleApplyTimer.Interval = num;
                    StyleApplyTimer.Enabled = true;
                    goto IL_AD;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ScrapBase ApplyStyleItem Exception:" + ex.ToString());
                    IsStyleApply = false;
                    goto IL_AD;
                }
            }
            else
            {
                _applyFinished?.Invoke();
                _applyFinished = null;

                if (ScrapStyleAppliedEvent != null)
                {
                    ScrapStyleAppliedEvent(this, new ScrapEventArgs(this));
                }
            }
            IsStyleApply = false;
        IL_AD:
            if (!IsStyleApply && !Initialized)
            {
                Initialized = true;
            }
        }

        public void RemoveStyle(Type styleItemType)
        {
            if (_styleItems.Count > 0)
            {
                _styleItems.RemoveAll(x => x.GetType() == styleItemType);
            }

            if (_styleItems.Count == 0)
            {
                _styleID = 0;
                _styleClickPoint = Point.Empty;

                if (ScrapStyleRemovedEvent != null)
                {
                    ScrapStyleRemovedEvent(this, new ScrapEventArgs(this));
                }
            }
        }


        // Token: 0x06000089 RID: 137 RVA: 0x000047E0 File Offset: 0x000029E0
        private void ScrapBase_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Manager.WClickStyle(this, e.Location);
        }

        // Token: 0x0600008A RID: 138 RVA: 0x000047F4 File Offset: 0x000029F4
        private void ScrapBase_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (var path in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    Manager.AddDragImageFileName(path);
                }
            }
        }

        // Token: 0x0600008B RID: 139 RVA: 0x00004847 File Offset: 0x00002A47
        private void ScrapBase_DragEnter(object sender, DragEventArgs e)
        {
            if (Manager.IsImageDrag)
            {
                e.Effect = DragDropEffects.All;
            }
        }


        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);

            if (ScrapLocationChangedEvent != null)
            {
                ScrapLocationChangedEvent(e, new ScrapEventArgs(this));
            }
        }


        private void ScrapBase_SizeChanged(object sender, EventArgs e)
        {
        }

        private void ScrapBase_VisibleChanged(object sender, EventArgs e)
        {
            _visible = Visible;
        }


        public bool GetVisibleFlag()
        {
            return _visible;
        }


        // Token: 0x04000021 RID: 33
        private const int WS_EX_LAYERED = 524288;

        // Token: 0x04000022 RID: 34
        private const int GWL_EXSTYLE = -20;

        // Token: 0x04000023 RID: 35
        public ScrapBook _parent;

        // Token: 0x04000024 RID: 36
        private Image imgView;

        // Token: 0x04000025 RID: 37
        private bool closePrepare;

        // Token: 0x04000026 RID: 38
        private string _name;

        // Token: 0x04000027 RID: 39
        private DateTime _datetime;

        // Token: 0x04000028 RID: 40
        private int _scale;

        // Token: 0x04000029 RID: 41
        private bool _solidframe;

        // Token: 0x0400002A RID: 42
        private bool _dragmode;

        // Token: 0x0400002B RID: 43
        private Point _dragpoint;

        // Token: 0x0400002C RID: 44
        private double _saveopacity;

        // Token: 0x0400002F RID: 47
        private bool _blTargetSet;

        // Token: 0x04000030 RID: 48
        private Point _ptTarget;

        // Token: 0x04000031 RID: 49
        private Timer StyleApplyTimer;

        // Token: 0x04000032 RID: 50
        private int StyleAppliIndex;

        // Token: 0x04000033 RID: 51
        private int _styleID;

        private List<CStyleItem> _styleItems;

        // Token: 0x04000034 RID: 52
        private bool IsStyleApply;

        // Token: 0x04000035 RID: 53
        private Point _styleClickPoint = Point.Empty;

        // Token: 0x04000036 RID: 54
        public bool Initialized;

        // Token: 0x04000037 RID: 55
        private bool _err_opac;

        // Token: 0x0400003F RID: 63
        private double _opacity;

        // Token: 0x04000040 RID: 64
        private bool _isMouseEnter;

        // Token: 0x04000041 RID: 65
        private double _activeOpacity;

        // Token: 0x04000042 RID: 66
        private double _inactiveOpacity;

        // Token: 0x04000043 RID: 67
        private double _rolloverOpacity;

        // Token: 0x04000044 RID: 68
        private int _activeMargin;

        // Token: 0x04000045 RID: 69
        private int _inactiveMargin;

        // Token: 0x04000046 RID: 70
        private int _rolloverMargin;

        // Token: 0x04000047 RID: 71
        private InterpolationMode _interpolationmode;

        private Cache.CacheItem _cacheItem;

        private Action _applyFinished;

        // Token: 0x0200002B RID: 43
        // (Invoke) Token: 0x060001A6 RID: 422
        public delegate void ScrapEventHandler(object sender, ScrapEventArgs e);

        // Token: 0x0200002D RID: 45
        // (Invoke) Token: 0x060001AC RID: 428
        public delegate void ScrapSubMenuHandler(object sender, ScrapMenuArgs e);

        private bool _visible = true;

    }
}
