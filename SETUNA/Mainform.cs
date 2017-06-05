namespace SETUNA
{
    using com.clearunit;
    using SETUNA.Main;
    using SETUNA.Main.KeyItems;
    using SETUNA.Main.Option;
    using SETUNA.Main.Style;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    public sealed class Mainform : Form, IScrapKeyPressEventListener, IScrapAddedListener, IScrapRemovedListener, IScrapStyleListener, IScrapMenuListener, ISingletonForm
    {
        private Queue<ScrapSource> _imgpool;
        private bool _iscapture = false;
        private bool _isoption = false;
        private bool _isstart = false;
        private Button button1;
        private Button button4;
        private static CaptureForm cap_form;
        private IContainer components;
        public Queue<ScrapBase> dustbox;
        private ClickCapture frmClickCapture;
        private SplashForm frmSplash;
        public KeyItemBook keyBook;
        public SetunaOption optSetuna;
        public ScrapBook scrapBook;
        private NotifyIcon setunaIcon;
        private ContextStyleMenuStrip setunaIconMenu;
        private ContextStyleMenuStrip subMenu;
        private ToolStripMenuItem testToolStripMenuItem;
        private Timer timPool;
        private ToolTip toolTip1;

        public Mainform()
        {
            this.InitializeComponent();
            this.scrapBook = new ScrapBook(this);
            this.scrapBook.addKeyPressListener(this);
            this.scrapBook.addScrapAddedListener(this);
            this.scrapBook.addScrapRemovedListener(this);
            this.optSetuna = new SetunaOption();
            this.dustbox = new Queue<ScrapBase>();
            this.scrapBook.DustBox = this.dustbox;
            this.scrapBook.DustBoxCapacity = 5;
            this.keyBook = this.optSetuna.GetKeyItemBook();
            this._imgpool = new Queue<ScrapSource>();
            this.SetSubMenu();
            this.Width = 300;
            this.Height = 100;

            InitImage();
        }

        void InitImage()
        {
            var tPath = Cache.path;
            DirectoryInfo tInfo = new DirectoryInfo(tPath);
            var tFiles = tInfo.GetFiles("*.jpeg");
            if (tFiles != null && tFiles.Length > 0)
            {
                foreach (var tFileInfo in tFiles)
                {
                    try
                    {
                        Image tImg = Image.FromFile(tFileInfo.FullName);
                        var tGuid = tFileInfo.Name.Replace(tFileInfo.Extension, string.Empty);
                        if (tImg != null)
                        {
                            this.scrapBook.AddScrap(tImg, 0, 0, tImg.Width, tImg.Height, tGuid);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("加载图片失败：" + ex.ToString());
                    }

                }
            }
        }

        public void AddImageList(ScrapSource src)
        {
            this._imgpool.Enqueue(src);
            this.timPool.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.StartCapture();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Option();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.optSetuna = SetunaOption.GetDefaultOption();
            int num = 0;
            num++;
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void CloseSetuna()
        {
            base.Close();
        }

        void ISingletonForm.DetectExternalStartup(string version, string[] args)
        {
            base.Invoke(new ExternalStartupDelegate(this.ExternalStartup), new object[] { version, args });
        }

        private void CommandCutRect(Rectangle rect, string fname)
        {
            using (Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb))
            {
                Point location = new Point(rect.X, rect.Y);
                CaptureForm.CopyFromScreen(bitmap, location);
                if (fname == "")
                {
                    this.AddImageList(new ScrapSourceImage(bitmap, location));
                }
            }
        }

        public void CommandRun(string[] args)
        {
            Console.WriteLine("-命令行参数--------------------");
            int num = 0;
            Rectangle rect = new Rectangle(0, 0, 0, 0);
            string fname = "";
            foreach (string str4 in args)
            {
                try
                {
                    string path = str4;
                    string str = "";
                    if (str4.Length > 3)
                    {
                        str = path.Substring(0, 3);
                        if ((str.Substring(0, 1) == "/") && (str.Substring(2, 1) == ":"))
                        {
                            path = str4.Substring(str.Length, path.Length - str.Length);
                        }
                        else
                        {
                            str = "";
                        }
                    }
                    if (str.Length > 0)
                    {
                        if (str == "/R:")
                        {
                            string[] strArray = path.Split(new char[] { ',' });
                            if (strArray.Length == 4)
                            {
                                rect = new Rectangle
                                {
                                    X = int.Parse(strArray[0]),
                                    Y = int.Parse(strArray[1]),
                                    Width = int.Parse(strArray[2]),
                                    Height = int.Parse(strArray[3])
                                };
                                Console.WriteLine("[位置]" + rect.ToString());
                                continue;
                            }
                        }
                        if (str == "/P:")
                        {
                            fname = path;
                        }
                        if (str == "/C:")
                        {
                            if (path.ToUpper() == "OPTION")
                            {
                                num = 1;
                                continue;
                            }
                            if (path.ToUpper() == "CAPTURE")
                            {
                                num = 2;
                                continue;
                            }
                            if (path.ToUpper() == "SUBMENU")
                            {
                                num = 3;
                                continue;
                            }
                        }
                    }
                    this.AddImageList(new ScrapSourcePath(path));
                    Console.WriteLine(path);
                }
                catch
                {
                    Console.WriteLine("[Error]" + str4);
                }
            }
            Console.WriteLine("---------------------------------------");
            if ((rect.Width >= 10) && (rect.Height >= 10))
            {
                this.CommandCutRect(rect, fname);
            }
            else if ((num != 0) && this.IsStart)
            {
                switch (num)
                {
                    case 1:
                        if (this.IsOption)
                        {
                            break;
                        }
                        this.Option();
                        return;

                    case 2:
                        if (!this.IsCapture)
                        {
                            this.StartCapture();
                        }
                        break;

                    default:
                        return;
                }
            }
        }

        public void CreateScrapFromImage(Image image, Point location)
        {
            if (image != null)
            {
                using (Bitmap bitmap = (Bitmap)image.Clone())
                {
                    if (location == Point.Empty)
                    {
                        location = Cursor.Position;
                    }
                    int x = location.X;
                    int y = location.Y;
                    this.scrapBook.AddScrap((Bitmap)bitmap.Clone(), x, y, bitmap.Width, bitmap.Height);
                }
            }
        }

        private void CreateScrapFromsource(ScrapSource src)
        {
            this.CreateScrapFromImage(src.GetImage(), src.GetPosition());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EndCapture(CaptureForm cform)
        {
            try
            {
                Console.WriteLine("Mainform EndCapture Start---");
                if (cform.DialogResult == DialogResult.OK)
                {
                    using (Bitmap bitmap = cform.ClipBitmap)
                    {
                        if (bitmap != null)
                        {
                            this.scrapBook.AddScrap(bitmap, cform.ClipStart.X, cform.ClipStart.Y, cform.ClipSize.Width, cform.ClipSize.Height);
                        }
                    }
                }
                cform.Hide();
                Cursor.Clip = Rectangle.Empty;
                Console.WriteLine("Mainform EndCapture End---");
            }
            catch (Exception exception)
            {
                Console.WriteLine("MainForm EndCapture Exception:" + exception.Message);
            }
            finally
            {
                this.IsCapture = false;
                if (this.frmClickCapture != null)
                {
                    this.frmClickCapture.Restart();
                }
            }
        }

        private void ExternalStartup(string version, string[] args)
        {
            if (Application.ProductVersion != version)
            {
                MessageBox.Show("SETUNA已经运行在不同的版本。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (args.Length > 0)
            {
                this.CommandRun(args);
            }
            else if (this.optSetuna.Setuna.DupType == SetunaOption.SetunaOptionData.OpeningType.Capture)
            {
                this.StartCapture();
            }
        }

        private void frmClickCapture_ClickCaptureEvent(object sender, EventArgs e)
        {
            this.StartCapture();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Mainform));
            this.button1 = new Button();
            this.button4 = new Button();
            this.timPool = new Timer(this.components);
            this.setunaIcon = new NotifyIcon(this.components);
            this.setunaIconMenu = new ContextStyleMenuStrip(this.components);
            this.subMenu = new ContextStyleMenuStrip(this.components);
            this.testToolStripMenuItem = new ToolStripMenuItem();
            this.toolTip1 = new ToolTip(this.components);
            this.subMenu.SuspendLayout();
            base.SuspendLayout();
            manager.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = Color.Gray;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            manager.ApplyResources(this.button4, "button4");
            this.button4.ForeColor = Color.Gray;
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.timPool.Tick += new EventHandler(this.timPool_Tick);
            this.setunaIcon.ContextMenuStrip = this.setunaIconMenu;
            manager.ApplyResources(this.setunaIcon, "setunaIcon");
            this.setunaIcon.MouseClick += new MouseEventHandler(this.setunaIcon_MouseClick);
            this.setunaIconMenu.Name = "setunaIconMenu";
            this.setunaIconMenu.Scrap = null;
            manager.ApplyResources(this.setunaIconMenu, "setunaIconMenu");
            this.setunaIconMenu.Opening += new CancelEventHandler(this.setunaIconMenu_Opening);
            this.subMenu.Items.AddRange(new ToolStripItem[] { this.testToolStripMenuItem });
            this.subMenu.Name = "subMenu";
            this.subMenu.Scrap = null;
            manager.ApplyResources(this.subMenu, "subMenu");
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            manager.ApplyResources(this.testToolStripMenuItem, "testToolStripMenuItem");
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.StripAmpersands = true;
            this.toolTip1.ToolTipIcon = ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "asfdadsf";
            base.AutoScaleMode = AutoScaleMode.None;
            manager.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.setunaIconMenu;
            base.Controls.Add(this.button4);
            base.Controls.Add(this.button1);
            base.MaximizeBox = false;
            base.Name = "Mainform";
            base.TopMost = true;
            base.Load += new EventHandler(this.Mainform_Load);
            base.Shown += new EventHandler(this.Mainform_Shown);
            base.FormClosing += new FormClosingEventHandler(this.Mainform_FormClosing);
            this.subMenu.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void LoadOption()
        {
            string configFile = SetunaOption.ConfigFile;
            try
            {
                if (!File.Exists(configFile))
                {
                    this.optSetuna = SetunaOption.GetDefaultOption();
                }
                else
                {
                    System.Type[] allType = SetunaOption.GetAllType();
                    XmlSerializer serializer = new XmlSerializer(typeof(SetunaOption), allType);
                    FileStream stream = new FileStream(configFile, FileMode.Open);
                    this.optSetuna = (SetunaOption)serializer.Deserialize(stream);
                    stream.Close();
                }
            }
            catch
            {
                this.optSetuna = SetunaOption.GetDefaultOption();
                MessageBox.Show("无法读取配置文件。\n使用默认设置。", "SETUNA2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                this.OptionApply();
            }
        }

        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.optSetuna.UnregistHotKey();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            base.Visible = false;
            this.LoadOption();
            this.OptionApply();
            this.SaveOption();
            if (this.optSetuna.Setuna.ShowSplashWindow)
            {
                this.frmSplash = new SplashForm();
                base.AddOwnedForm(this.frmSplash);
                this.frmSplash.Show(this);
                this.frmSplash.SplashTimer.Start();
            }
            this.timPool.Start();
            cap_form = new CaptureForm(this.optSetuna.Setuna);
            this.IsStart = true;
        }

        private void Mainform_Shown(object sender, EventArgs e)
        {
        }

        private void miCapture_Click(object sender, EventArgs e)
        {
            this.StartCapture();
        }

        private void miOption_Click(object sender, EventArgs e)
        {
            this.Option();
        }

        private void miSetunaClose_Click(object sender, EventArgs e)
        {
            this.CloseSetuna();
        }

        public void OnActiveScrapInList(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Tag != null)
            {
                ((ScrapBase)item.Tag).Activate();
            }
        }

        public void Option()
        {
            if (!this.IsCapture)
            {
                this.IsOption = true;
                SetunaOption opt = (SetunaOption)this.optSetuna.Clone();
                List<ScrapBase> list = new List<ScrapBase>();
                try
                {
                    foreach (ScrapBase base2 in this.scrapBook)
                    {
                        if (base2.Visible && base2.TopMost)
                        {
                            list.Add(base2);
                        }
                    }
                    foreach (ScrapBase base3 in list)
                    {
                        base3.TopMost = false;
                    }
                    base.TopMost = false;
                    this.optSetuna.UnregistHotKey();
                    if (this.frmClickCapture != null)
                    {
                        this.frmClickCapture.Stop();
                    }
                    OptionForm form = new OptionForm(opt)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        this.optSetuna = form.Option;
                        this.OptionApply();
                    }
                    if (!this.optSetuna.RegistHotKey(base.Handle))
                    {
                        this.optSetuna.ScrapHotKeyEnable = false;
                        new HotkeyMsg { HotKey = (Keys)this.optSetuna.ScrapHotKey }.ShowDialog();
                    }
                    if (form.DialogResult == DialogResult.OK)
                    {
                        this.SaveOption();
                    }
                }
                finally
                {
                    base.TopMost = true;
                    foreach (ScrapBase base4 in list)
                    {
                        base4.TopMost = true;
                    }
                    this.IsOption = false;
                }
            }
        }

        private void OptionApply()
        {
            try
            {
                this.keyBook = this.optSetuna.GetKeyItemBook();
                if (this.optSetuna.Setuna.DustBoxEnable)
                {
                    this.scrapBook.DustBoxCapacity = (short)this.optSetuna.Setuna.DustBoxCapacity;
                }
                else
                {
                    this.scrapBook.DustBoxCapacity = 0;
                }
                if (!this.optSetuna.RegistHotKey(base.Handle))
                {
                    this.optSetuna.ScrapHotKeyEnable = false;
                    new HotkeyMsg { HotKey = (Keys)this.optSetuna.ScrapHotKey }.ShowDialog();
                }
                if (this.optSetuna.Setuna.AppType == SetunaOption.SetunaOptionData.ApplicationType.ApplicationMode)
                {
                    base.ShowInTaskbar = true;
                    this.setunaIcon.Visible = false;
                    base.MinimizeBox = true;
                    base.Visible = true;
                }
                else
                {
                    this.setunaIcon.Visible = true;
                    base.ShowInTaskbar = false;
                    base.MinimizeBox = false;
                    base.WindowState = FormWindowState.Normal;
                    base.Visible = this.optSetuna.Setuna.ShowMainWindow;
                }
                this.subMenu.Items.Clear();
                foreach (int num in this.optSetuna.Scrap.SubMenuStyles)
                {
                    if (num >= 0)
                    {
                        foreach (CStyle style in this.optSetuna.Styles)
                        {
                            if (style.StyleID == num)
                            {
                                this.subMenu.Items.Add(style.GetToolStrip(this.scrapBook));
                            }
                        }
                    }
                    else
                    {
                        CStyle preStyle = CPreStyles.GetPreStyle(num);
                        if (preStyle != null)
                        {
                            this.subMenu.Items.Add(preStyle.GetToolStrip(this.scrapBook));
                        }
                    }
                }
                if (this.optSetuna.Setuna.ClickCapture)
                {
                    if (this.frmClickCapture == null)
                    {
                        this.frmClickCapture = new ClickCapture(this.optSetuna.Setuna.ClickCaptureValue);
                        this.frmClickCapture.ClickCaptureEvent += new ClickCapture.ClipCaptureDelegate(this.frmClickCapture_ClickCaptureEvent);
                        this.frmClickCapture.Show();
                    }
                    else
                    {
                        this.frmClickCapture.ClickFlags = this.optSetuna.Setuna.ClickCaptureValue;
                        this.frmClickCapture.Restart();
                    }
                }
                else if (this.frmClickCapture != null)
                {
                    this.frmClickCapture.Close();
                    this.frmClickCapture.Dispose();
                    this.frmClickCapture = null;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Mainform OptionApply Exception:" + exception.Message);
            }
        }

        public void RestoreScrap(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            List<ScrapBase> list = new List<ScrapBase>();
            while (this.dustbox.Count > 0)
            {
                ScrapBase base2 = this.dustbox.Dequeue();
                if (!base2.Equals(item.Tag))
                {
                    list.Add(base2);
                }
                else
                {
                    this.scrapBook.AddScrap(base2);
                    base2.Show();
                }
            }
            this.dustbox.Clear();
            foreach (ScrapBase base3 in list)
            {
                this.dustbox.Enqueue(base3);
            }
            new ScrapEventArgs();
        }

        private void SaveOption()
        {
            string configFile = SetunaOption.ConfigFile;
            System.Type[] allType = SetunaOption.GetAllType();
            try
            {
                XmlSerializer serializer = new XmlSerializer(this.optSetuna.GetType(), allType);
                FileStream stream = new FileStream(configFile, FileMode.Create);
                serializer.Serialize((Stream)stream, this.optSetuna);
                stream.Close();
            }
            catch
            {
                MessageBox.Show("无法保存配置文件。", "SETUNA2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void ScrapActivated(object sender, ScrapEventArgs e)
        {
            bool inactiveAlphaChange = this.optSetuna.Scrap.InactiveAlphaChange;
            bool inactiveLineChange = this.optSetuna.Scrap.InactiveLineChange;
        }

        public void ScrapAdded(object sender, ScrapEventArgs e)
        {
        }

        public void ScrapCreated(object sender, ScrapEventArgs e)
        {
            CStyle style = this.optSetuna.FindStyle(this.optSetuna.Scrap.CreateStyleID);
            if (style != null)
            {
                e.scrap.Initialized = false;
                style.Apply(ref e.scrap);
            }
            else
            {
                e.scrap.Initialized = true;
            }
        }

        public void ScrapInactived(object sender, ScrapEventArgs e)
        {
            if (this.optSetuna.Scrap.InactiveAlphaChange)
            {
                e.scrap.InactiveOpacity = 1.0 - (((double)this.optSetuna.Scrap.InactiveAlphaValue) / 100.0);
            }
            else
            {
                e.scrap.InactiveOpacity = e.scrap.ActiveOpacity;
            }
            bool inactiveLineChange = this.optSetuna.Scrap.InactiveLineChange;
        }

        public void ScrapInactiveMouseOut(object sender, ScrapEventArgs e)
        {
            if (this.optSetuna.Scrap.InactiveAlphaChange)
            {
                e.scrap.InactiveOpacity = 1.0 - (((double)this.optSetuna.Scrap.InactiveAlphaValue) / 100.0);
            }
            else
            {
                e.scrap.InactiveOpacity = e.scrap.ActiveOpacity;
            }
            bool inactiveLineChange = this.optSetuna.Scrap.InactiveLineChange;
        }

        public void ScrapInactiveMouseOver(object sender, ScrapEventArgs e)
        {
            if (this.optSetuna.Scrap.MouseOverAlphaChange)
            {
                e.scrap.RollOverOpacity = 1.0 - (((double)this.optSetuna.Scrap.MouseOverAlphaValue) / 100.0);
            }
            else
            {
                e.scrap.RollOverOpacity = e.scrap.ActiveOpacity;
            }
            bool mouseOverLineChange = this.optSetuna.Scrap.MouseOverLineChange;
        }

        public void ScrapKeyPress(object sender, ScrapKeyPressEventArgs e)
        {
            KeyItem item = this.keyBook.FindKeyItem(e.key);
            if (item != null)
            {
                ScrapBase scrap = (ScrapBase)sender;
                item.ParentStyle.Apply(ref scrap);
            }
        }

        public void ScrapMenuOpening(object sender, ScrapMenuArgs e)
        {
            this.subMenu.Scrap = e.scrap;
            this.subMenu.Show(e.scrap, e.scrap.PointToClient(Cursor.Position));
        }

        public void ScrapRemoved(object sender, ScrapEventArgs e)
        {
        }

        private void SetSubMenu()
        {
            this.setunaIconMenu.Scrap = this.scrapBook.GetDummyScrap();
            this.setunaIconMenu.Items.Clear();
            this.setunaIconMenu.Items.Add(new CScrapListStyle().GetToolStrip(this.scrapBook));
            this.setunaIconMenu.Items.Add(new CDustBoxStyle().GetToolStrip(this.scrapBook));
            this.setunaIconMenu.Items.Add(new CDustEraseStyle().GetToolStrip());
            this.setunaIconMenu.Items.Add(new ToolStripSeparator());
            this.setunaIconMenu.Items.Add(new CCaptureStyle().GetToolStrip());
            this.setunaIconMenu.Items.Add(new ToolStripSeparator());
            this.setunaIconMenu.Items.Add(new CShowVersionStyle().GetToolStrip());
            this.setunaIconMenu.Items.Add(new COptionStyle().GetToolStrip());
            this.setunaIconMenu.Items.Add(new ToolStripSeparator());
            this.setunaIconMenu.Items.Add(new CShutDownStyle().GetToolStrip());
        }

        private void setunaIcon_MouseClick(object sender, MouseEventArgs e)
        {
            base.Activate();
        }

        private void setunaIconMenu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        public void StartCapture()
        {
            if ((!this.IsCapture && (cap_form != null)) && !this.IsOption)
            {
                try
                {
                    if (this.frmClickCapture != null)
                    {
                        this.frmClickCapture.Stop();
                    }
                    this.IsCapture = true;
                    Console.WriteLine(string.Concat(new object[] { "9 - ", DateTime.Now.ToString(), " ", DateTime.Now.Millisecond }));
                    cap_form.OnCaptureClose = new CaptureForm.CaptureClosedDelegate(this.EndCapture);
                    cap_form.ShowCapture(this.optSetuna.Setuna);
                    Console.WriteLine(string.Concat(new object[] { "16 - ", DateTime.Now.ToString(), " ", DateTime.Now.Millisecond }));
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Mainform StartCapture Exception:" + exception.Message);
                    this.IsCapture = false;
                    if (cap_form != null)
                    {
                        cap_form.DialogResult = DialogResult.Cancel;
                    }
                    this.EndCapture(cap_form);
                }
            }
        }

        private void timPool_Tick(object sender, EventArgs e)
        {
            if (((this._imgpool.Count == 0) || this.IsCapture) || (this.IsOption || !this.IsStart))
            {
                this.timPool.Stop();
            }
            else
            {
                using (ScrapSource source = this._imgpool.Dequeue())
                {
                    this.CreateScrapFromsource(source);
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if ((m.Msg == 0x312) && (((int)m.WParam) == 1))
            {
                this.StartCapture();
            }
        }

        public bool IsCapture
        {
            get
            {
                return
                this._iscapture;
            }
            set
            {
                this._iscapture = value;
                if (!value && (this._imgpool.Count > 0))
                {
                    this.timPool.Start();
                }
            }
        }

        public bool IsOption
        {
            get
            {
                return
                this._isoption;
            }
            set
            {
                this._isoption = value;
                if (!value && (this._imgpool.Count > 0))
                {
                    this.timPool.Start();
                }
            }
        }

        public bool IsStart
        {
            get
            {
                return
                this._isstart;
            }
            set
            {
                this._isstart = value;
                if (value && (this._imgpool.Count > 0))
                {
                    this.timPool.Start();
                }
            }
        }

        private delegate void ExternalStartupDelegate(string version, string[] args);
    }
}

