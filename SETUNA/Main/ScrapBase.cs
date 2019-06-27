namespace SETUNA.Main
{
    using SETUNA.Main.Style;
    using SETUNA.Main.StyleItems;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public sealed class ScrapBase : Form
    {
        private int _activeMargin;
        private double _activeOpacity;
        private bool _blTargetSet;
        private string _datetime;
        private bool _dragmode;
        private Point _dragpoint;
        private bool _err_opac;
        private int _inactiveMargin;
        private double _inactiveOpacity;
        private System.Drawing.Drawing2D.InterpolationMode _interpolationmode;
        private bool _isMouseEnter;
        private string _name;
        private double _opacity;
        public ScrapBook _parent;
        private Point _ptTarget;
        private int _rolloverMargin;
        private double _rolloverOpacity;
        private double _saveopacity;
        private int _scale;
        private bool _solidframe;
        private bool closePrepare;
        private IContainer components;
        private const int GWL_EXSTYLE = -20;
        private System.Drawing.Image imgView;
        public bool Initialized;
        private bool IsStyleApply;
        private int StyleAppliIndex;
        private Timer StyleApplyTimer;
        private Point StyleClickPoint = Point.Empty;
        private CStyleItem[] StyleItems;
        private Timer timOpacity;
        private const int WS_EX_LAYERED = 0x80000;

        public event ScrapEventHandler ScrapActiveEvent;

        public event ScrapEventHandler ScrapCloseEvent;

        public event ScrapEventHandler ScrapCreateEvent;

        public event ScrapEventHandler ScrapInactiveEnterEvent;

        public event ScrapEventHandler ScrapInactiveEvent;

        public event ScrapEventHandler ScrapInactiveOutEvent;

        public event ScrapSubMenuHandler ScrapSubMenuOpening;

        public ScrapBase()
        {
            this.InitializeComponent();
            base.KeyPreview = true;
            this.closePrepare = false;
            this._dragmode = false;
            this._scale = 100;
            this._opacity = base.Opacity;
            this._blTargetSet = false;
            this._ptTarget = new Point();
            this._solidframe = true;
            this._inactiveOpacity = this.Opacity;
            this._activeOpacity = this.Opacity;
            this._rolloverOpacity = this.Opacity;
            this.DateTime = System.DateTime.Now.ToString();
            this.Name = this.DateTime.Replace("/", "").Replace(":", "").Replace("浏览", "").Replace(" ", "-");
            this._interpolationmode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        }

        public void addScrapMenuEvent(IScrapMenuListener listener)
        {
            this.ScrapSubMenuOpening = (ScrapSubMenuHandler)Delegate.Combine(this.ScrapSubMenuOpening, new ScrapSubMenuHandler(listener.ScrapMenuOpening));
        }

        public void addScrapStyleEvent(IScrapStyleListener listener)
        {
            this.ScrapCreateEvent = (ScrapEventHandler)Delegate.Combine(this.ScrapCreateEvent, new ScrapEventHandler(listener.ScrapCreated));
            this.ScrapActiveEvent = (ScrapEventHandler)Delegate.Combine(this.ScrapActiveEvent, new ScrapEventHandler(listener.ScrapActivated));
            this.ScrapInactiveEvent = (ScrapEventHandler)Delegate.Combine(this.ScrapInactiveEvent, new ScrapEventHandler(listener.ScrapInactived));
            this.ScrapInactiveEnterEvent = (ScrapEventHandler)Delegate.Combine(this.ScrapInactiveEnterEvent, new ScrapEventHandler(listener.ScrapInactiveMouseOver));
            this.ScrapInactiveOutEvent = (ScrapEventHandler)Delegate.Combine(this.ScrapInactiveOutEvent, new ScrapEventHandler(listener.ScrapInactiveMouseOut));
        }

        public void ApplyStyleItem(object sender, EventArgs e)
        {
            this.StyleApplyTimer.Enabled = false;
            if (this.StyleItems != null && this.StyleAppliIndex < this.StyleItems.Length)
            {
                int waitinterval = 1;
                ScrapBase scrap = this;
                try
                {
                    CStyleItem item = this.StyleItems[this.StyleAppliIndex];
                    if (this.Initialized || (!this.Initialized && item.IsInitApply))
                    {
                        item.Apply(ref scrap, out waitinterval, this.StyleClickPoint);
                    }
                    this.StyleAppliIndex++;
                    if (waitinterval <= 0)
                    {
                        waitinterval = 1;
                    }
                    this.StyleApplyTimer.Interval = waitinterval;
                    this.StyleApplyTimer.Enabled = true;
                }
                catch (Exception exception)
                {
                    Console.WriteLine("ScrapBase ApplyStyleItem Exception:" + exception.ToString());
                    this.IsStyleApply = false;
                }
            }
            else
            {
                this.IsStyleApply = false;
            }
            if (!this.IsStyleApply && !this.Initialized)
            {
                this.Initialized = true;
            }
        }

        public void ApplyStyles(CStyle style, Point clickpoint)
        {
            if (!this.IsStyleApply)
            {
                if ((style != null && cacheInfo.styleID != style.StyleID) || cacheInfo.stylePoint != clickpoint)
                {
                    cacheInfo.styleID = style == null ? 0 : style.StyleID;
                    cacheInfo.stylePoint = clickpoint;
                    ApplyCache();
                }

                this.StyleClickPoint = clickpoint;
                this.IsStyleApply = true;
                this.StyleAppliIndex = 0;
                this.StyleItems = style == null ? null : style.Items;
                if (this.StyleApplyTimer == null)
                {
                    this.StyleApplyTimer = new Timer();
                    this.StyleApplyTimer.Enabled = false;
                    this.StyleApplyTimer.Tick += new EventHandler(this.ApplyStyleItem);
                }
                this.StyleApplyTimer.Interval = 1;
                this.StyleApplyTimer.Start();
            }
        }

        private void DragEnd()
        {
            this._dragmode = false;
            base.SuspendLayout();
            this.Opacity = this._saveopacity;
            base.ResumeLayout();

            if (this.cacheInfo.posX != base.Left || this.cacheInfo.posY != base.Top)
            {
                this.cacheInfo.posX = base.Left;
                this.cacheInfo.posY = base.Top;
                ApplyCache();
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
            this._saveopacity = this.Opacity;
            base.SuspendLayout();
            this.Opacity = 0.5;
            base.ResumeLayout();
        }

        ~ScrapBase()
        {
            this.ImageAllDispose();
        }

        public System.Drawing.Image GetThumbnail()
        {
            Bitmap image = new Bitmap(230, 150, PixelFormat.Format24bppRgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.FillRectangle(Brushes.DarkGray, 0, 0, image.Width, image.Height);
            if ((this.imgView.Width <= (image.Width - 1)) || (this.imgView.Height <= (image.Height - 1)))
            {
                graphics.DrawImageUnscaled(this.imgView, 1, 1);
            }
            else
            {
                double num;
                Size size = new Size(this.imgView.Width - 1, this.imgView.Height - 1);
                if (((size.Width - image.Width) - 1) <= ((size.Height - image.Height) - 1))
                {
                    num = ((double)(image.Width - 1)) / ((double)(size.Width - 1));
                }
                else
                {
                    num = ((double)(image.Height - 1)) / ((double)(size.Height - 1));
                }
                size.Width = (int)(size.Width * num);
                size.Height = (int)(size.Height * num);
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(this.imgView, 1, 1, size.Width, size.Height);
            }
            graphics.DrawRectangle(Pens.Black, 0, 0, image.Width - 1, image.Height - 1);
            return image;
        }

        public System.Drawing.Image GetViewImage()
        {
            Bitmap bitmap = new Bitmap(base.Width, base.Height, PixelFormat.Format24bppRgb);
            base.DrawToBitmap(bitmap, new Rectangle(0, 0, base.Width, base.Height));
            return bitmap;
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        private void ImageAllDispose()
        {
            this.ImageDispose(ref this.imgView);
        }

        private void ImageDispose(ref System.Drawing.Image img)
        {
            if (img != null)
            {
                img.Dispose();
                img = null;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScrapBase));
            this.timOpacity = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timOpacity
            // 
            this.timOpacity.Interval = 15;
            this.timOpacity.Tick += new System.EventHandler(this.timOpacity_Tick);
            // 
            // ScrapBase
            // 
            this.AllowDrop = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "ScrapBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.ScrapBase_Activated);
            this.Deactivate += new System.EventHandler(this.ScrapBase_Deactivate);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ScrapBase_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ScrapBase_DragEnter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScrapBase_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScrapBase_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ScrapBase_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlImg_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ScrapBase_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ScrapBase_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlImg_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlImg_MouseUp);
            this.ResumeLayout(false);

        }

        protected override void OnClosed(EventArgs e)
        {
            this.ImageAllDispose();
            base.OnClosed(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (((e.CloseReason == CloseReason.ApplicationExitCall) || (e.CloseReason == CloseReason.TaskManagerClosing)) || (e.CloseReason == CloseReason.WindowsShutDown))
            {
                Console.WriteLine("由系统结束");
            }
            else if (!this.closePrepare)
            {
                e.Cancel = true;
                this.OnScrapClose(new ScrapEventArgs());
            }
            base.OnFormClosing(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int width = (int)(this.imgView.Width * (((float)this._scale) / 100f));
            int height = (int)(this.imgView.Height * (((float)this._scale) / 100f));
            int all = this.Padding.All;
            e.Graphics.InterpolationMode = this._interpolationmode;
            e.Graphics.DrawImage(this.imgView, all, all, width, height);
            if (!this._solidframe)
            {
                Pen pen = new Pen(Color.FromArgb(0xf3, 0xf3, 0xf3));
                e.Graphics.DrawLine(pen, 0, 0, base.Width, 0);
                e.Graphics.DrawLine(pen, 0, 0, 0, base.Height);
                pen.Dispose();
                pen = null;
            }
        }

        public void OnScrapClose(ScrapEventArgs e)
        {
            if (this.ScrapCloseEvent != null)
            {
                this.ScrapCloseEvent(this, e);
            }

            CacheManager.DeleteCacheInfo(mInfo);
            mInfo = null;
        }

        public void OnScrapCreated()
        {
            if (this.ScrapCreateEvent != null)
            {
                this.ScrapCreateEvent(this, new ScrapEventArgs(this));
            }
        }

        private void pnlImg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DragStart(e.Location);
            }
        }

        private void pnlImg_MouseMove(object sender, MouseEventArgs e)
        {
            this.DragMove(e.Location);
        }

        private void pnlImg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DragEnd();
            }
        }

        private void ScrapBase_Activated(object sender, EventArgs e)
        {
            if (this.ScrapActiveEvent != null)
            {
                this.ScrapActiveEvent(sender, new ScrapEventArgs(this));
            }
            this.Opacity = this.ActiveOpacity;
        }

        private void ScrapBase_Deactivate(object sender, EventArgs e)
        {
            if (this.ScrapInactiveEvent != null)
            {
                this.ScrapInactiveEvent(sender, new ScrapEventArgs(this));
            }
            if (!this._isMouseEnter)
            {
                this.Opacity = this.InactiveOpacity;
            }
        }

        private void ScrapBase_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (string str in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    this.Manager.AddDragImageFileName(str);
                }
            }
        }

        private void ScrapBase_DragEnter(object sender, DragEventArgs e)
        {
            if (this.Manager.IsImageDrag)
            {
                e.Effect = DragDropEffects.Move | DragDropEffects.Copy | DragDropEffects.Scroll;
            }
        }

        private void ScrapBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                base.Close();
            }
        }

        private void ScrapBase_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (this.ScrapSubMenuOpening != null))
            {
                this.ScrapSubMenuOpening(sender, new ScrapMenuArgs(this, null));
            }
        }

        private void ScrapBase_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Manager.WClickStyle(this, e.Location);
        }

        private void ScrapBase_MouseEnter(object sender, EventArgs e)
        {
            this._isMouseEnter = true;
            if (!this.Focused && (this.ScrapInactiveEnterEvent != null))
            {
                this.ScrapInactiveEnterEvent(sender, new ScrapEventArgs(this));
            }
            if (Form.ActiveForm != this)
            {
                this.Opacity = this.RollOverOpacity;
            }
        }

        private void ScrapBase_MouseLeave(object sender, EventArgs e)
        {
            this._isMouseEnter = false;
            if (!this.Focused && (this.ScrapInactiveOutEvent != null))
            {
                this.ScrapInactiveOutEvent(sender, new ScrapEventArgs(this));
            }
            if (Form.ActiveForm != this)
            {
                this.Opacity = this.InactiveOpacity;
            }
        }

        public void ScrapClose()
        {
            this.closePrepare = true;
            base.Close();
            GC.Collect();
        }

        public void ScrapResize()
        {
            base.Width = this.imgView.Width + (this.Padding.Left + this.Padding.Right);
            base.Height = this.imgView.Height + (this.Padding.Top + this.Padding.Bottom);
        }

        public void SetBounds(int x, int y, int width, int height, BoundsSpecified specified)
        {
            this.SetBoundsCore(x, y, width, height, specified);
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        private void timOpacity_Tick(object sender, EventArgs e)
        {
            try
            {
                if (base.Opacity != this._opacity)
                {
                    if (this._err_opac)
                    {
                        try
                        {
                            this._opacity = 1.0;
                            base.Opacity = 1.0;
                        }
                        catch
                        {
                            Console.WriteLine("ScrapBase timOpacity_Tick Exception2:---");
                        }
                    }
                    else
                    {
                        double num = base.Opacity - this._opacity;
                        if (Math.Abs(num) < 0.10000000149011612)
                        {
                            try
                            {
                                if (base.Opacity != this._opacity)
                                {
                                    base.Opacity = this._opacity;
                                }
                            }
                            catch (Win32Exception exception)
                            {
                                this.timOpacity.Stop();
                                this._err_opac = true;
                                this.Opacity = 1.0;
                                Console.WriteLine("ScrapBase timOpacity_Tick Exception: " + exception.Message + ", Opaque True");
                            }
                            catch (Exception exception2)
                            {
                                Console.WriteLine("ScrapBase timOpacity_Tick Exception: " + exception2.Message + ", " + base.Opacity.ToString() + ", " + this._opacity.ToString());
                            }
                        }
                        else if (num < 0.0)
                        {
                            base.Opacity += 0.10000000149011612;
                        }
                        else
                        {
                            base.Opacity -= 0.10000000149011612;
                        }
                    }
                }
                if (this._blTargetSet)
                {
                    int num3;
                    int num5;
                    int num2 = base.Top - this._ptTarget.Y;
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
                        base.Top = this._ptTarget.Y;
                    }
                    else
                    {
                        base.Top += num3;
                    }
                    int num4 = base.Left - this._ptTarget.X;
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
                        base.Left = this._ptTarget.X;
                    }
                    else
                    {
                        base.Left += num5;
                    }
                    if ((base.Top == this._ptTarget.Y) && (base.Left == this._ptTarget.X))
                    {
                        this._blTargetSet = false;
                    }
                    else
                    {
                        this.Refresh();
                    }
                }
                if ((base.Opacity == this._opacity) && !this._blTargetSet)
                {
                    this.timOpacity.Enabled = false;
                }
            }
            catch (Exception exception3)
            {
                Console.WriteLine("ScrapBase timOpacity_Tick Exception:" + exception3.Message);
            }
        }

        public int ActiveMargin
        {
            get
            {
                return
                this._activeMargin;
            }
            set
            {
                this._activeMargin = value;
                this.Padding = new System.Windows.Forms.Padding(this._activeMargin);
            }
        }

        public double ActiveOpacity
        {
            get
            {
                return
                this._activeOpacity;
            }
            set
            {
                this._activeOpacity = value;
                if (Form.ActiveForm == this)
                {
                    this.Opacity = this._activeOpacity;
                }
            }
        }

        public string DateTime
        {
            get
            {
                return
                this._datetime;
            }
            set
            {
                this._datetime = value;
            }
        }

        public ScrapBaseInfo cacheInfo
        {
            set
            {
                mInfo = value;
            }
            get { return mInfo; }
        }
        ScrapBaseInfo mInfo;

        public bool isFirstInitCompactScrap { set; get; } = false;

        public System.Drawing.Image Image
        {
            get
            {
                return
                this.imgView;
            }
            set
            {
                this.ImageAllDispose();

                var bitmap = new Bitmap(value);
                this.imgView = (System.Drawing.Image)bitmap;

                //this.imgView = (System.Drawing.Image)value.Clone();

                if (this.imgView == null)
                {
                    Console.WriteLine("ScrapBase Image : unll");
                }
                this.Scale = this.Scale;
                this.Refresh();
            }
        }

        public int InactiveMargin
        {
            get
            {
                return
                this._inactiveMargin;
            }
            set
            {
                this._inactiveMargin = value;
                if ((Form.ActiveForm != this) && !this._isMouseEnter)
                {
                    this.Padding = new System.Windows.Forms.Padding(this._inactiveMargin);
                }
            }
        }

        public double InactiveOpacity
        {
            get
            {
                return
                this._inactiveOpacity;
            }
            set
            {
                this._inactiveOpacity = value;
                if ((Form.ActiveForm != this) && !this._isMouseEnter)
                {
                    this.Opacity = this._inactiveOpacity;
                }
            }
        }

        public System.Drawing.Drawing2D.InterpolationMode InterpolationMode
        {
            get
            {
                return
                this._interpolationmode;
            }
            set
            {
                this._interpolationmode = value;
            }
        }

        public ScrapBook Manager
        {
            get
            {
                return
                this._parent;
            }
            set
            {
                this._parent = value;
                if (this.ScrapCloseEvent == null)
                {
                    this.ScrapCloseEvent = (ScrapEventHandler)Delegate.Combine(this.ScrapCloseEvent, new ScrapEventHandler(this._parent.ScrapClose));
                    base.KeyDown += new KeyEventHandler(this._parent.OnKeyUp);
                }
            }
        }

        public string Name
        {
            get
            {
                return
                this._name;
            }
            set
            {
                this._name = value;
                this.Text = this._name;
            }
        }

        public double Opacity
        {
            get
            {
                return
                this._opacity;
            }
            set
            {
                this._opacity = value;
                if (this._opacity != base.Opacity)
                {
                    this.timOpacity.Enabled = true;
                }
            }
        }

        public System.Windows.Forms.Padding Padding
        {
            get
            {
                return
                base.Padding;
            }
            set
            {
                base.Padding = value;
                BoundsSpecified none = BoundsSpecified.None;
                int x = 0;
                int y = 0;
                int width = ((int)(this.imgView.Width * (((float)this._scale) / 100f))) + (value.All * 2);
                int height = ((int)(this.imgView.Height * (((float)this._scale) / 100f))) + (value.All * 2);
                if (base.Width != width)
                {
                    none |= BoundsSpecified.Width | BoundsSpecified.X;
                    x = base.Left + ((base.Width - width) / 2);
                }
                if (base.Height != height)
                {
                    none |= BoundsSpecified.Height | BoundsSpecified.Y;
                    y = base.Top + ((base.Height - height) / 2);
                }
                if (none != BoundsSpecified.None)
                {
                    this.SetBoundsCore(x, y, width, height, BoundsSpecified.Location);
                    base.ClientSize = new Size(width, height);
                }
            }
        }

        public int RollOverMargin
        {
            get
            {
                return
                this._rolloverMargin;
            }
            set
            {
                this._rolloverMargin = value;
                if ((Form.ActiveForm != this) && this._isMouseEnter)
                {
                    this.Padding = new System.Windows.Forms.Padding(this._rolloverMargin);
                }
            }
        }

        public double RollOverOpacity
        {
            get
            {
                return
                this._rolloverOpacity;
            }
            set
            {
                this._rolloverOpacity = value;
                if ((Form.ActiveForm != this) && this._isMouseEnter)
                {
                    this.Opacity = this._rolloverOpacity;
                }
            }
        }

        public int Scale
        {
            get
            {
                return
                this._scale;
            }
            set
            {
                this._scale = value;
                if (this._scale < -200)
                {
                    this._scale = -200;
                }
                if (this._scale > 200)
                {
                    this._scale = 200;
                }
                base.Width = ((int)(this.imgView.Width * (((float)this._scale) / 100f))) + (this.Padding.All * 2);
                base.Height = ((int)(this.imgView.Height * (((float)this._scale) / 100f))) + (this.Padding.All * 2);
                this.Refresh();
            }
        }

        public bool SolidFrame
        {
            get
            {
                return
                this._solidframe;
            }
            set
            {
                this._solidframe = value;
            }
        }

        public Point TargetLocation
        {
            get
            {
                if (this._blTargetSet)
                {
                    return this._ptTarget;
                }
                return base.Location;
            }
            set
            {
                this._ptTarget = value;
                if (this._ptTarget != base.Location)
                {
                    this._blTargetSet = true;
                    this.timOpacity.Enabled = true;
                }
            }
        }

        public bool Visible
        {
            get
            {
                return
                base.Visible;
            }
            set
            {
                if (!value && (base.FormBorderStyle != FormBorderStyle.None))
                {
                    base.ShowInTaskbar = false;
                }
                else if (value && (base.FormBorderStyle != FormBorderStyle.None))
                {
                    base.ShowInTaskbar = true;
                }
                base.Visible = value;
            }
        }

        public delegate void ScrapEventHandler(object sender, ScrapEventArgs e);

        public delegate void ScrapSubMenuHandler(object sender, ScrapMenuArgs e);

        public void ApplyCache()
        {
            CacheManager.SaveCacheInfo(mInfo);
        }
    }
}

