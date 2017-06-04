namespace SETUNA.Main.Option
{
    using com.clearunit;
    using SETUNA.Main;
    using SETUNA.Main.KeyItems;
    using SETUNA.Main.Style;
    using SETUNA.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class OptionForm : Form
    {
        private int _activeStyleId;
        private int _createStyleId;
        private int _inactiveStyleId;
        private TabPage _pageScrapMenu;
        private TabPage _pageStyle;
        private SetunaOption _so;
        private int _wclickStyleId;
        private Button btnCancel;
        private Button btnDeleteStyle;
        private Button btnEditStyle;
        private Button btnInitialize;
        private Button btnNewStyle;
        private Button btnOK;
        private Button btnScrapMenuMove;
        private Button button1;
        private CheckBox checkBox1;
        private CheckBox chkCC1;
        private CheckBox chkCC2;
        private CheckBox chkCC3;
        private CheckBox chkCC4;
        private CheckBox chkCC6;
        private CheckBox chkCC7;
        private CheckBox chkCC8;
        private CheckBox chkCC9;
        private CheckBox chkDustBox;
        private CheckBox chkInactiveAlphaChange;
        private CheckBox chkMouseOverAlphaChange;
        private CheckBox chkScrapImageDrag;
        private CheckBox chkShowMainWindow;
        private CheckBox chkSplash;
        private ComboBox cmbCreateStyle;
        private ComboBox cmbWClickStyle;
        private IContainer components;
        private Panel detailPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox1;
        private GroupBox groupBox10;
        private GroupBox groupBox11;
        private GroupBox groupBox12;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private GroupBox groupBox9;
        private HotkeyControl hotkeyControl1;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblComment;
        private Label lblMenuAll;
        private Label lblMenuCapture;
        private Label lblMenuMenu;
        private Label lblMenuScrap;
        private Label lblMenuStyle;
        private ListBox listKeyItems;
        private SetunaListBox listScrapMenuItems;
        private SetunaListBox listScrapMenuList;
        private SetunaListBox listScrapMenuStyles;
        private ListBox listStyleItems;
        private SetunaListBox listStyles;
        private NumericUpDown numDustBox;
        private NumericUpDown numInactiveAlpha;
        private NumericUpDown numMouseOverAlpha;
        private NumericUpDown numSelectAreaTrans;
        private TabPage pageAll;
        private TabPage pageCapture;
        private TabPage pageScrap;
        private TabPage pageScrapMenu;
        private TabPage pageStyle;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private PictureBox picSelectAreaBackColor;
        private PictureBox picSelectAreaLineColor;
        private PictureBox pictureBox1;
        private Panel pnlScrapStyle;
        private RadioButton rdoDupCapture;
        private RadioButton rdoDupNone;
        private RadioButton rdoExeTypeApp;
        private RadioButton rdoExeTypeResident;
        private RadioButton rdoSelLineTypeDotted;
        private RadioButton rdoSelLineTypeSolid;
        private WithoutTabControl tabControl1;
        private ToolTip toolTip1;

        public OptionForm(SetunaOption opt)
        {
            this.InitializeComponent();
            this._pageStyle = this.pageStyle;
            this._pageScrapMenu = this.pageScrapMenu;
            this._so = opt;
            this.LoadSetunaOption();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btnCopy_Click_1(object sender, EventArgs e)
        {
            if (this.listStyles.SelectedItem != null)
            {
                KeyItemBook book;
                this.GetKeyItemBook_ScrapStyle(out book);
                CStyle trgStyle = ((CStyle) this.listStyles.SelectedItem).DeepCopy();
                trgStyle.StyleName = "";
                trgStyle.ClearKey();
                StyleEditForm form = new StyleEditForm(trgStyle, book) {
                    Text = "新建自动操作"
                };
                if (form.ShowDialog() == DialogResult.OK)
                {
                    trgStyle.MakeStyleID();
                    this.listStyles.Items.Add(trgStyle);
                }
            }
        }

        private void btnDeleteStyle_Click(object sender, EventArgs e)
        {
            if (this.listStyles.SelectedItem != null)
            {
                int styleID = ((CStyle) this.listStyles.SelectedItem).StyleID;
                this.listStyles.Items.Remove(this.listStyles.SelectedItem);
                if (this._createStyleId == styleID)
                {
                    this._createStyleId = 0;
                }
                if (this._activeStyleId == styleID)
                {
                    this._activeStyleId = 0;
                }
                if (this._inactiveStyleId == styleID)
                {
                    this._inactiveStyleId = 0;
                }
                this.RefreshStyleList_Scrap();
            }
        }

        private void btnEditStyle_Click(object sender, EventArgs e)
        {
            this.EditStyle_ScrapStyle();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("进行设置内容的初始化。", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this._so = SetunaOption.GetDefaultOption();
                this.LoadSetunaOption();
            }
        }

        private void btnNewStyle_Click(object sender, EventArgs e)
        {
            KeyItemBook book;
            this.GetKeyItemBook_ScrapStyle(out book);
            CStyle trgStyle = new CStyle();
            using (StyleEditForm form = new StyleEditForm(trgStyle, book))
            {
                form.Text = "新建自动操作";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    trgStyle.MakeStyleID();
                    this.listStyles.Items.Add(trgStyle);
                    this.RefreshStyleList_Scrap();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.WriteSetunaOption();
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btnScrapMenuMove_Click(object sender, EventArgs e)
        {
            if (this.listScrapMenuStyles.SelectedIndex >= 0)
            {
                this.listScrapMenuStyles_MouseDoubleClick(null, null);
            }
            else if (this.listScrapMenuItems.SelectedIndex >= 0)
            {
                this.listScrapMenuItems_MouseDoubleClick(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void chkCC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox box = (CheckBox) sender;
                if (box.Checked)
                {
                    box.BackColor = Color.FromArgb(0xdf, 0xf1, 0xff);
                }
                else
                {
                    box.BackColor = SystemColors.Window;
                }
            }
            catch
            {
            }
        }

        private void cmbCreateStyle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CStyle selectedItem = (CStyle) this.cmbCreateStyle.SelectedItem;
            if (selectedItem.StyleName != "")
            {
                this._createStyleId = selectedItem.StyleID;
            }
            else
            {
                this._createStyleId = 0;
            }
        }

        private void cmbWClickStyle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CStyle selectedItem = (CStyle) this.cmbWClickStyle.SelectedItem;
            if (selectedItem.StyleName != "")
            {
                this._wclickStyleId = selectedItem.StyleID;
            }
            else
            {
                this._wclickStyleId = 0;
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

        private void EditStyle_ScrapStyle()
        {
            if (this.listStyles.SelectedItem != null)
            {
                KeyItemBook book;
                this.GetKeyItemBook_ScrapStyle(out book);
                int selectedIndex = this.listStyles.SelectedIndex;
                StyleEditForm form = new StyleEditForm((CStyle) this.listStyles.SelectedItem, book) {
                    Text = ((CStyle) this.listStyles.SelectedItem).StyleName + "的相关编辑"
                };
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.listStyles.Items[selectedIndex] = form.Style;
                    this.RefreshStyleList_Scrap();
                }
            }
        }

        private int FindStyle_Scrap(ComboBox combo, int styleId)
        {
            if (styleId != 0)
            {
                for (int i = 0; i < combo.Items.Count; i++)
                {
                    CStyle style = (CStyle) combo.Items[i];
                    if (style.StyleID == styleId)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        private void GetKeyItemBook_ScrapStyle(out KeyItemBook keybook)
        {
            keybook = new KeyItemBook();
            for (int i = 0; i < this.listStyles.Items.Count; i++)
            {
                CStyle style = (CStyle) this.listStyles.Items[i];
                keybook.AddKeyItem(style.KeyItems);
            }
        }

        private List<int> GetStyleIDList_Menu()
        {
            List<int> list = new List<int>();
            foreach (CStyle style in this.listScrapMenuList.Items)
            {
                list.Add(style.StyleID);
            }
            return list;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.panel2 = new Panel();
            this.lblComment = new Label();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.panel3 = new Panel();
            this.detailPanel = new Panel();
            this.tabControl1 = new WithoutTabControl();
            this.pageAll = new TabPage();
            this.groupBox7 = new GroupBox();
            this.chkSplash = new CheckBox();
            this.groupBox5 = new GroupBox();
            this.chkDustBox = new CheckBox();
            this.label14 = new Label();
            this.numDustBox = new NumericUpDown();
            this.btnInitialize = new Button();
            this.groupBox6 = new GroupBox();
            this.chkShowMainWindow = new CheckBox();
            this.rdoExeTypeResident = new RadioButton();
            this.rdoExeTypeApp = new RadioButton();
            this.pageCapture = new TabPage();
            this.groupBox12 = new GroupBox();
            this.label16 = new Label();
            this.chkCC6 = new CheckBox();
            this.chkCC4 = new CheckBox();
            this.chkCC2 = new CheckBox();
            this.chkCC8 = new CheckBox();
            this.chkCC3 = new CheckBox();
            this.chkCC1 = new CheckBox();
            this.chkCC9 = new CheckBox();
            this.chkCC7 = new CheckBox();
            this.groupBox3 = new GroupBox();
            this.rdoDupCapture = new RadioButton();
            this.rdoDupNone = new RadioButton();
            this.groupBox4 = new GroupBox();
            this.rdoSelLineTypeDotted = new RadioButton();
            this.rdoSelLineTypeSolid = new RadioButton();
            this.label12 = new Label();
            this.numSelectAreaTrans = new NumericUpDown();
            this.picSelectAreaBackColor = new PictureBox();
            this.picSelectAreaLineColor = new PictureBox();
            this.label10 = new Label();
            this.label9 = new Label();
            this.label8 = new Label();
            this.label7 = new Label();
            this.groupBox2 = new GroupBox();
            this.checkBox1 = new CheckBox();
            this.label3 = new Label();
            this.hotkeyControl1 = new HotkeyControl();
            this.pageScrap = new TabPage();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.pnlScrapStyle = new Panel();
            this.cmbWClickStyle = new ComboBox();
            this.label5 = new Label();
            this.cmbCreateStyle = new ComboBox();
            this.label4 = new Label();
            this.panel4 = new Panel();
            this.chkScrapImageDrag = new CheckBox();
            this.groupBox11 = new GroupBox();
            this.label15 = new Label();
            this.label13 = new Label();
            this.numMouseOverAlpha = new NumericUpDown();
            this.chkMouseOverAlphaChange = new CheckBox();
            this.label11 = new Label();
            this.label6 = new Label();
            this.numInactiveAlpha = new NumericUpDown();
            this.chkInactiveAlphaChange = new CheckBox();
            this.pageStyle = new TabPage();
            this.groupBox1 = new GroupBox();
            this.button1 = new Button();
            this.listStyles = new SetunaListBox();
            this.listKeyItems = new ListBox();
            this.label2 = new Label();
            this.label1 = new Label();
            this.btnEditStyle = new Button();
            this.listStyleItems = new ListBox();
            this.btnDeleteStyle = new Button();
            this.btnNewStyle = new Button();
            this.pageScrapMenu = new TabPage();
            this.btnScrapMenuMove = new Button();
            this.groupBox10 = new GroupBox();
            this.listScrapMenuList = new SetunaListBox();
            this.groupBox9 = new GroupBox();
            this.listScrapMenuItems = new SetunaListBox();
            this.groupBox8 = new GroupBox();
            this.listScrapMenuStyles = new SetunaListBox();
            this.panel1 = new Panel();
            this.lblMenuStyle = new Label();
            this.lblMenuCapture = new Label();
            this.lblMenuMenu = new Label();
            this.lblMenuScrap = new Label();
            this.lblMenuAll = new Label();
            this.pictureBox1 = new PictureBox();
            this.toolTip1 = new ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.detailPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.pageAll.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.numDustBox.BeginInit();
            this.groupBox6.SuspendLayout();
            this.pageCapture.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.numSelectAreaTrans.BeginInit();
            ((ISupportInitialize) this.picSelectAreaBackColor).BeginInit();
            ((ISupportInitialize) this.picSelectAreaLineColor).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pageScrap.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlScrapStyle.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.numMouseOverAlpha.BeginInit();
            this.numInactiveAlpha.BeginInit();
            this.pageStyle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pageScrapMenu.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.panel2.Controls.Add(this.lblComment);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = DockStyle.Bottom;
            this.panel2.Location = new Point(0, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(580, 40);
            this.panel2.TabIndex = 1;
            this.lblComment.Location = new Point(12, 6);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new Size(0x166, 0x17);
            this.lblComment.TabIndex = 2;
            this.btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x1dc, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x5e, 0x1b);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnOK.Location = new Point(0x178, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x5e, 0x1b);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.panel3.Controls.Add(this.detailPanel);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = DockStyle.Fill;
            this.panel3.Location = new Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(580, 360);
            this.panel3.TabIndex = 2;
            this.detailPanel.BackColor = Color.White;
            this.detailPanel.BorderStyle = BorderStyle.Fixed3D;
            this.detailPanel.Controls.Add(this.tabControl1);
            this.detailPanel.Location = new Point(0x81, 0);
            this.detailPanel.Margin = new Padding(0);
            this.detailPanel.Name = "detailPanel";
            this.detailPanel.Size = new Size(0x1c3, 360);
            this.detailPanel.TabIndex = 0;
            this.tabControl1.Appearance = TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.pageAll);
            this.tabControl1.Controls.Add(this.pageCapture);
            this.tabControl1.Controls.Add(this.pageScrap);
            this.tabControl1.Controls.Add(this.pageStyle);
            this.tabControl1.Controls.Add(this.pageScrapMenu);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Margin = new Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x1bf, 0x164);
            this.tabControl1.SizeMode = TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_TabIndexChanged);
            this.pageAll.BackColor = Color.White;
            this.pageAll.Controls.Add(this.groupBox7);
            this.pageAll.Controls.Add(this.groupBox5);
            this.pageAll.Controls.Add(this.btnInitialize);
            this.pageAll.Controls.Add(this.groupBox6);
            this.pageAll.Location = new Point(4, 0x18);
            this.pageAll.Name = "pageAll";
            this.pageAll.Padding = new Padding(5);
            this.pageAll.Size = new Size(0x1b7, 0x148);
            this.pageAll.TabIndex = 1;
            this.pageAll.Text = "常规";
            this.pageAll.UseVisualStyleBackColor = true;
            this.groupBox7.Controls.Add(this.chkSplash);
            this.groupBox7.Location = new Point(8, 0xb2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new Size(0x1a7, 0x33);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "其他";
            this.chkSplash.AutoSize = true;
            this.chkSplash.Location = new Point(0x10, 0x16);
            this.chkSplash.Name = "chkSplash";
            this.chkSplash.Size = new Size(0x9a, 0x10);
            this.chkSplash.TabIndex = 7;
            this.chkSplash.Text = "显示启动界面";
            this.toolTip1.SetToolTip(this.chkSplash, "将在启动SETUNA时的几秒钟内显示标志。");
            this.chkSplash.UseVisualStyleBackColor = true;
            this.groupBox5.Controls.Add(this.chkDustBox);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.numDustBox);
            this.groupBox5.Location = new Point(8, 0x66);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0x1a7, 70);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "回收站的设置";
            this.chkDustBox.AutoSize = true;
            this.chkDustBox.Location = new Point(0x10, 0x16);
            this.chkDustBox.Name = "chkDustBox";
            this.chkDustBox.Size = new Size(0x54, 0x10);
            this.chkDustBox.TabIndex = 4;
            this.chkDustBox.Text = "使用回收站";
            this.toolTip1.SetToolTip(this.chkDustBox, "使用回收站的话，参考图将暂时储存在回收站里。\n可以根据情况需要从回收站中取出。");
            this.chkDustBox.UseVisualStyleBackColor = true;
            this.label14.AutoSize = true;
            this.label14.Location = new Point(0x48, 0x2b);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x24, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "张为上限";
            this.numDustBox.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x80);
            this.numDustBox.Location = new Point(0x25, 40);
            int[] bits = new int[4];
            bits[0] = 50;
            this.numDustBox.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 1;
            this.numDustBox.Minimum = new decimal(numArray2);
            this.numDustBox.Name = "numDustBox";
            this.numDustBox.Size = new Size(0x23, 0x13);
            this.numDustBox.TabIndex = 5;
            this.numDustBox.TextAlign = HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.numDustBox, "指定在回收站中放入的最大张数。\n超过限额将丢弃旧的参考图。");
            int[] numArray3 = new int[4];
            numArray3[0] = 5;
            this.numDustBox.Value = new decimal(numArray3);
            this.btnInitialize.Location = new Point(0xf9, 0xeb);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new Size(0xb6, 0x1b);
            this.btnInitialize.TabIndex = 8;
            this.btnInitialize.Text = "设置全部恢复为默认状态";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new EventHandler(this.btnInitialize_Click);
            this.groupBox6.Controls.Add(this.chkShowMainWindow);
            this.groupBox6.Controls.Add(this.rdoExeTypeResident);
            this.groupBox6.Controls.Add(this.rdoExeTypeApp);
            this.groupBox6.Location = new Point(8, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(0x1a7, 0x58);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "操作类型";
            this.chkShowMainWindow.AutoSize = true;
            this.chkShowMainWindow.Location = new Point(0x22, 60);
            this.chkShowMainWindow.Name = "chkShowMainWindow";
            this.chkShowMainWindow.Size = new Size(0x80, 0x10);
            this.chkShowMainWindow.TabIndex = 2;
            this.chkShowMainWindow.Text = "显示主窗口";
            this.chkShowMainWindow.UseVisualStyleBackColor = true;
            this.rdoExeTypeResident.AutoSize = true;
            this.rdoExeTypeResident.Location = new Point(0x10, 0x27);
            this.rdoExeTypeResident.Name = "rdoExeTypeResident";
            this.rdoExeTypeResident.Size = new Size(0x6b, 0x10);
            this.rdoExeTypeResident.TabIndex = 1;
            this.rdoExeTypeResident.Text = "常驻任务栏";
            this.toolTip1.SetToolTip(this.rdoExeTypeResident, "在任务栏上显示图标。");
            this.rdoExeTypeResident.UseVisualStyleBackColor = true;
            this.rdoExeTypeResident.CheckedChanged += new EventHandler(this.rdoExeTypeResident_CheckedChanged);
            this.rdoExeTypeApp.AutoSize = true;
            this.rdoExeTypeApp.Checked = true;
            this.rdoExeTypeApp.Location = new Point(0x10, 0x13);
            this.rdoExeTypeApp.Name = "rdoExeTypeApp";
            this.rdoExeTypeApp.Size = new Size(0x5c, 0x10);
            this.rdoExeTypeApp.TabIndex = 0;
            this.rdoExeTypeApp.TabStop = true;
            this.rdoExeTypeApp.Text = "应用软件";
            this.toolTip1.SetToolTip(this.rdoExeTypeApp, "显示主窗口、最小化到任务栏上");
            this.rdoExeTypeApp.UseVisualStyleBackColor = true;
            this.pageCapture.BackColor = SystemColors.Window;
            this.pageCapture.Controls.Add(this.groupBox12);
            this.pageCapture.Controls.Add(this.groupBox3);
            this.pageCapture.Controls.Add(this.groupBox4);
            this.pageCapture.Controls.Add(this.groupBox2);
            this.pageCapture.Location = new Point(4, 0x18);
            this.pageCapture.Margin = new Padding(0);
            this.pageCapture.Name = "pageCapture";
            this.pageCapture.Padding = new Padding(5);
            this.pageCapture.Size = new Size(0x1b7, 0x148);
            this.pageCapture.TabIndex = 4;
            this.pageCapture.Text = "截取设置";
            this.pageCapture.UseVisualStyleBackColor = true;
            this.groupBox12.Controls.Add(this.label16);
            this.groupBox12.Controls.Add(this.chkCC6);
            this.groupBox12.Controls.Add(this.chkCC4);
            this.groupBox12.Controls.Add(this.chkCC2);
            this.groupBox12.Controls.Add(this.chkCC8);
            this.groupBox12.Controls.Add(this.chkCC3);
            this.groupBox12.Controls.Add(this.chkCC1);
            this.groupBox12.Controls.Add(this.chkCC9);
            this.groupBox12.Controls.Add(this.chkCC7);
            this.groupBox12.Location = new Point(0xf9, 0x4c);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new Size(0xb6, 0xd1);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "单击截取";
            this.label16.Location = new Point(5, 0xa9);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0xad, 0x1f);
            this.label16.TabIndex = 8;
            this.label16.Text = "当您点击一下指定的屏幕边缘，即开始截取。";
            this.chkCC6.Appearance = Appearance.Button;
            this.chkCC6.Location = new Point(130, 50);
            this.chkCC6.Name = "chkCC6";
            this.chkCC6.Size = new Size(0x1a, 0x4e);
            this.chkCC6.TabIndex = 7;
            this.chkCC6.UseVisualStyleBackColor = false;
            this.chkCC6.CheckedChanged += new EventHandler(this.chkCC_CheckedChanged);
            this.chkCC4.Appearance = Appearance.Button;
            this.chkCC4.Location = new Point(0x1a, 50);
            this.chkCC4.Name = "chkCC4";
            this.chkCC4.Size = new Size(0x1a, 0x4e);
            this.chkCC4.TabIndex = 6;
            this.chkCC4.UseVisualStyleBackColor = false;
            this.chkCC4.CheckedChanged += new EventHandler(this.chkCC_CheckedChanged);
            this.chkCC2.Appearance = Appearance.Button;
            this.chkCC2.Location = new Point(0x34, 0x80);
            this.chkCC2.Name = "chkCC2";
            this.chkCC2.Size = new Size(0x4e, 0x1a);
            this.chkCC2.TabIndex = 5;
            this.chkCC2.UseVisualStyleBackColor = false;
            this.chkCC2.CheckedChanged += new EventHandler(this.chkCC_CheckedChanged);
            this.chkCC8.Appearance = Appearance.Button;
            this.chkCC8.Location = new Point(0x34, 0x18);
            this.chkCC8.Name = "chkCC8";
            this.chkCC8.Size = new Size(0x4e, 0x1a);
            this.chkCC8.TabIndex = 4;
            this.chkCC8.UseVisualStyleBackColor = false;
            this.chkCC8.CheckedChanged += new EventHandler(this.chkCC_CheckedChanged);
            this.chkCC3.Appearance = Appearance.Button;
            this.chkCC3.Location = new Point(130, 0x80);
            this.chkCC3.Name = "chkCC3";
            this.chkCC3.Size = new Size(0x1a, 0x1a);
            this.chkCC3.TabIndex = 3;
            this.chkCC3.UseVisualStyleBackColor = false;
            this.chkCC3.CheckedChanged += new EventHandler(this.chkCC_CheckedChanged);
            this.chkCC1.Appearance = Appearance.Button;
            this.chkCC1.Location = new Point(0x1a, 0x80);
            this.chkCC1.Name = "chkCC1";
            this.chkCC1.Size = new Size(0x1a, 0x1a);
            this.chkCC1.TabIndex = 2;
            this.chkCC1.UseVisualStyleBackColor = false;
            this.chkCC1.CheckedChanged += new EventHandler(this.chkCC_CheckedChanged);
            this.chkCC9.Appearance = Appearance.Button;
            this.chkCC9.Location = new Point(130, 0x18);
            this.chkCC9.Name = "chkCC9";
            this.chkCC9.Size = new Size(0x1a, 0x1a);
            this.chkCC9.TabIndex = 1;
            this.chkCC9.UseVisualStyleBackColor = false;
            this.chkCC9.CheckedChanged += new EventHandler(this.chkCC_CheckedChanged);
            this.chkCC7.Appearance = Appearance.Button;
            this.chkCC7.Location = new Point(0x1a, 0x18);
            this.chkCC7.Name = "chkCC7";
            this.chkCC7.Size = new Size(0x1a, 0x1a);
            this.chkCC7.TabIndex = 0;
            this.chkCC7.UseVisualStyleBackColor = false;
            this.chkCC7.CheckedChanged += new EventHandler(this.chkCC_CheckedChanged);
            this.groupBox3.Controls.Add(this.rdoDupCapture);
            this.groupBox3.Controls.Add(this.rdoDupNone);
            this.groupBox3.Location = new Point(8, 0xd6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0xeb, 0x47);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "防止双重启动的操作";
            this.rdoDupCapture.AutoSize = true;
            this.rdoDupCapture.Location = new Point(0x10, 0x2a);
            this.rdoDupCapture.Name = "rdoDupCapture";
            this.rdoDupCapture.Size = new Size(0x60, 0x10);
            this.rdoDupCapture.TabIndex = 1;
            this.rdoDupCapture.Text = "截取参考图";
            this.toolTip1.SetToolTip(this.rdoDupCapture, "如果您尝试重复启动SETUNA，则开始截取。");
            this.rdoDupCapture.UseVisualStyleBackColor = true;
            this.rdoDupNone.AutoSize = true;
            this.rdoDupNone.Checked = true;
            this.rdoDupNone.Location = new Point(0x10, 0x16);
            this.rdoDupNone.Name = "rdoDupNone";
            this.rdoDupNone.Size = new Size(0x49, 0x10);
            this.rdoDupNone.TabIndex = 0;
            this.rdoDupNone.TabStop = true;
            this.rdoDupNone.Text = "什么都不做";
            this.toolTip1.SetToolTip(this.rdoDupNone, "如果您尝试重复启动SETUNA，则什么都不做。");
            this.rdoDupNone.UseVisualStyleBackColor = true;
            this.groupBox4.Controls.Add(this.rdoSelLineTypeDotted);
            this.groupBox4.Controls.Add(this.rdoSelLineTypeSolid);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.numSelectAreaTrans);
            this.groupBox4.Controls.Add(this.picSelectAreaBackColor);
            this.groupBox4.Controls.Add(this.picSelectAreaLineColor);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new Point(8, 0x4c);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xeb, 0x84);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "截取时的框选范围";
            this.rdoSelLineTypeDotted.AutoSize = true;
            this.rdoSelLineTypeDotted.Location = new Point(0xa7, 0x2e);
            this.rdoSelLineTypeDotted.Name = "rdoSelLineTypeDotted";
            this.rdoSelLineTypeDotted.Size = new Size(0x2f, 0x10);
            this.rdoSelLineTypeDotted.TabIndex = 3;
            this.rdoSelLineTypeDotted.Text = "虚线";
            this.toolTip1.SetToolTip(this.rdoSelLineTypeDotted, "设置框选范围的边框线的类型。");
            this.rdoSelLineTypeDotted.UseVisualStyleBackColor = true;
            this.rdoSelLineTypeSolid.AutoSize = true;
            this.rdoSelLineTypeSolid.Checked = true;
            this.rdoSelLineTypeSolid.Location = new Point(0x76, 0x2f);
            this.rdoSelLineTypeSolid.Name = "rdoSelLineTypeSolid";
            this.rdoSelLineTypeSolid.Size = new Size(0x2f, 0x10);
            this.rdoSelLineTypeSolid.TabIndex = 2;
            this.rdoSelLineTypeSolid.TabStop = true;
            this.rdoSelLineTypeSolid.Text = "实线";
            this.toolTip1.SetToolTip(this.rdoSelLineTypeSolid, "设置框选范围的边框线的类型。");
            this.rdoSelLineTypeSolid.UseVisualStyleBackColor = true;
            this.label12.AutoSize = true;
            this.label12.Location = new Point(0xa5, 0x61);
            this.label12.Name = "label12";
            this.label12.Size = new Size(11, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "%";
            this.numSelectAreaTrans.Location = new Point(0x76, 0x5f);
            this.numSelectAreaTrans.Name = "numSelectAreaTrans";
            this.numSelectAreaTrans.Size = new Size(0x29, 0x13);
            this.numSelectAreaTrans.TabIndex = 6;
            this.toolTip1.SetToolTip(this.numSelectAreaTrans, "设置框选范围填充颜色的透明度。\n选择透明度100％时可提高响应速度。");
            int[] numArray4 = new int[4];
            numArray4[0] = 100;
            this.numSelectAreaTrans.Value = new decimal(numArray4);
            this.picSelectAreaBackColor.BackColor = Color.AliceBlue;
            this.picSelectAreaBackColor.BorderStyle = BorderStyle.Fixed3D;
            this.picSelectAreaBackColor.Cursor = Cursors.Hand;
            this.picSelectAreaBackColor.Location = new Point(0x76, 70);
            this.picSelectAreaBackColor.Name = "picSelectAreaBackColor";
            this.picSelectAreaBackColor.Size = new Size(0x20, 0x12);
            this.picSelectAreaBackColor.TabIndex = 10;
            this.picSelectAreaBackColor.TabStop = false;
            this.toolTip1.SetToolTip(this.picSelectAreaBackColor, "设置全面填充框选范围的颜色。\n不全面涂抹的情况设置透明度为100％。");
            this.picSelectAreaBackColor.Click += new EventHandler(this.pictureBox_Click);
            this.picSelectAreaLineColor.BackColor = Color.Blue;
            this.picSelectAreaLineColor.BorderStyle = BorderStyle.Fixed3D;
            this.picSelectAreaLineColor.Cursor = Cursors.Hand;
            this.picSelectAreaLineColor.Location = new Point(0x76, 0x16);
            this.picSelectAreaLineColor.Name = "picSelectAreaLineColor";
            this.picSelectAreaLineColor.Size = new Size(0x20, 0x12);
            this.picSelectAreaLineColor.TabIndex = 9;
            this.picSelectAreaLineColor.TabStop = false;
            this.toolTip1.SetToolTip(this.picSelectAreaLineColor, "指定框选范围的边框线的颜色。");
            this.picSelectAreaLineColor.Click += new EventHandler(this.pictureBox_Click);
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0x10, 0x61);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x65, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "框选范围的透明度：";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x10, 0x49);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x4d, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "框选范围的颜色：";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0x10, 0x18);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x4f, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "框选线的颜色∶";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x10, 0x30);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x5b, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "框选线的种类∶";
            this.groupBox2.BackColor = Color.Transparent;
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.hotkeyControl1);
            this.groupBox2.Location = new Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new Padding(10, 7, 3, 3);
            this.groupBox2.Size = new Size(0x1a7, 0x3e);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "快捷键设置";
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(0xf1, 0x1a);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(130, 0x10);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "启用快捷键";
            this.toolTip1.SetToolTip(this.checkBox1, "要启用快捷键，请勾选。");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x10, 0x1b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x34, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "快捷键：";
            this.hotkeyControl1.Hotkey = Keys.None;
            this.hotkeyControl1.Location = new Point(0x4a, 0x18);
            this.hotkeyControl1.Name = "hotkeyControl1";
            this.hotkeyControl1.Size = new Size(150, 0x13);
            this.hotkeyControl1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.hotkeyControl1, "Ctrl键，Shift键和Alt键，各个键的组合来设置截取的快捷键。\n不能使用其他程序设置的快捷键。");
            this.pageScrap.BackColor = Color.White;
            this.pageScrap.Controls.Add(this.flowLayoutPanel1);
            this.pageScrap.Location = new Point(4, 0x18);
            this.pageScrap.Name = "pageScrap";
            this.pageScrap.Padding = new Padding(3);
            this.pageScrap.Size = new Size(0x1b7, 0x148);
            this.pageScrap.TabIndex = 2;
            this.pageScrap.Text = "参考图设置";
            this.pageScrap.UseVisualStyleBackColor = true;
            this.flowLayoutPanel1.BackColor = Color.White;
            this.flowLayoutPanel1.Controls.Add(this.pnlScrapStyle);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(0x1a8, 0x12e);
            this.flowLayoutPanel1.TabIndex = 0;
            this.pnlScrapStyle.Controls.Add(this.cmbWClickStyle);
            this.pnlScrapStyle.Controls.Add(this.label5);
            this.pnlScrapStyle.Controls.Add(this.cmbCreateStyle);
            this.pnlScrapStyle.Controls.Add(this.label4);
            this.pnlScrapStyle.Location = new Point(3, 3);
            this.pnlScrapStyle.Name = "pnlScrapStyle";
            this.pnlScrapStyle.Size = new Size(0x19c, 0x3e);
            this.pnlScrapStyle.TabIndex = 0;
            this.cmbWClickStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbWClickStyle.FormattingEnabled = true;
            this.cmbWClickStyle.Location = new Point(0xa3, 0x26);
            this.cmbWClickStyle.Name = "cmbWClickStyle";
            this.cmbWClickStyle.Size = new Size(0xba, 20);
            this.cmbWClickStyle.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmbWClickStyle, "指定双击参考图时使用的自动操作。");
            this.cmbWClickStyle.SelectionChangeCommitted += new EventHandler(this.cmbWClickStyle_SelectionChangeCommitted);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(20, 0x26);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x3a, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "双击时∶";
            this.cmbCreateStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCreateStyle.FormattingEnabled = true;
            this.cmbCreateStyle.Location = new Point(0xa3, 11);
            this.cmbCreateStyle.Name = "cmbCreateStyle";
            this.cmbCreateStyle.Size = new Size(0xba, 20);
            this.cmbCreateStyle.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cmbCreateStyle, "您可以指定要创建参考图时使用的自动操作。");
            this.cmbCreateStyle.SelectionChangeCommitted += new EventHandler(this.cmbCreateStyle_SelectionChangeCommitted);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(20, 14);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x43, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "基本自动操作：";
            this.panel4.Controls.Add(this.chkScrapImageDrag);
            this.panel4.Controls.Add(this.groupBox11);
            this.panel4.Location = new Point(3, 0x47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(0x19c, 0xd5);
            this.panel4.TabIndex = 0;
            this.chkScrapImageDrag.AutoSize = true;
            this.chkScrapImageDrag.Location = new Point(0x16, 3);
            this.chkScrapImageDrag.Name = "chkScrapImageDrag";
            this.chkScrapImageDrag.Size = new Size(0xd1, 0x10);
            this.chkScrapImageDrag.TabIndex = 0;
            this.chkScrapImageDrag.Text = "拖动图像文件创建一个参考图";
            this.toolTip1.SetToolTip(this.chkScrapImageDrag, "拖动图像文件到参考图可作为参考图查看。");
            this.chkScrapImageDrag.UseVisualStyleBackColor = true;
            this.groupBox11.Controls.Add(this.label15);
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Controls.Add(this.numMouseOverAlpha);
            this.groupBox11.Controls.Add(this.chkMouseOverAlphaChange);
            this.groupBox11.Controls.Add(this.label11);
            this.groupBox11.Controls.Add(this.label6);
            this.groupBox11.Controls.Add(this.numInactiveAlpha);
            this.groupBox11.Controls.Add(this.chkInactiveAlphaChange);
            this.groupBox11.Location = new Point(3, 0x1f);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new Size(0x196, 0x7b);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "非选择时的效果";
            this.label15.AutoSize = true;
            this.label15.Location = new Point(0xfd, 0x56);
            this.label15.Name = "label15";
            this.label15.Size = new Size(11, 12);
            this.label15.TabIndex = 7;
            this.label15.Text = "%";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(0xfd, 0x26);
            this.label13.Name = "label13";
            this.label13.Size = new Size(11, 12);
            this.label13.TabIndex = 3;
            this.label13.Text = "%";
            this.numMouseOverAlpha.Location = new Point(0xd5, 0x52);
            int[] numArray5 = new int[4];
            numArray5[0] = 1;
            this.numMouseOverAlpha.Minimum = new decimal(numArray5);
            this.numMouseOverAlpha.Name = "numMouseOverAlpha";
            this.numMouseOverAlpha.Size = new Size(0x27, 0x13);
            this.numMouseOverAlpha.TabIndex = 6;
            int[] numArray6 = new int[4];
            numArray6[0] = 1;
            this.numMouseOverAlpha.Value = new decimal(numArray6);
            this.chkMouseOverAlphaChange.AutoSize = true;
            this.chkMouseOverAlphaChange.Location = new Point(0x31, 0x55);
            this.chkMouseOverAlphaChange.Name = "chkMouseOverAlphaChange";
            this.chkMouseOverAlphaChange.Size = new Size(0xa2, 0x10);
            this.chkMouseOverAlphaChange.TabIndex = 5;
            this.chkMouseOverAlphaChange.Text = "改变参考图的不透明度";
            this.toolTip1.SetToolTip(this.chkMouseOverAlphaChange, "设置鼠标光标处于参考图上时参考图的透明度。\n如果响应速度很慢请关闭。");
            this.chkMouseOverAlphaChange.UseVisualStyleBackColor = true;
            this.label11.AutoSize = true;
            this.label11.Location = new Point(0x15, 70);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x69, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "鼠标触到时";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x15, 0x17);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x74, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "鼠标没触到时";
            this.numInactiveAlpha.Location = new Point(0xd5, 0x23);
            int[] numArray7 = new int[4];
            numArray7[0] = 1;
            this.numInactiveAlpha.Minimum = new decimal(numArray7);
            this.numInactiveAlpha.Name = "numInactiveAlpha";
            this.numInactiveAlpha.Size = new Size(0x27, 0x13);
            this.numInactiveAlpha.TabIndex = 2;
            int[] numArray8 = new int[4];
            numArray8[0] = 1;
            this.numInactiveAlpha.Value = new decimal(numArray8);
            this.chkInactiveAlphaChange.AutoSize = true;
            this.chkInactiveAlphaChange.Location = new Point(0x31, 0x26);
            this.chkInactiveAlphaChange.Name = "chkInactiveAlphaChange";
            this.chkInactiveAlphaChange.Size = new Size(0xa2, 0x10);
            this.chkInactiveAlphaChange.TabIndex = 1;
            this.chkInactiveAlphaChange.Text = "改变参考图的不透明度";
            this.toolTip1.SetToolTip(this.chkInactiveAlphaChange, "设置鼠标光标离开参考图上后参考图的透明度。\n如果响应速度很慢请关闭。");
            this.chkInactiveAlphaChange.UseVisualStyleBackColor = true;
            this.pageStyle.BackColor = Color.White;
            this.pageStyle.Controls.Add(this.groupBox1);
            this.pageStyle.Location = new Point(4, 0x18);
            this.pageStyle.Margin = new Padding(0);
            this.pageStyle.Name = "pageStyle";
            this.pageStyle.Padding = new Padding(5);
            this.pageStyle.Size = new Size(0x1b7, 0x148);
            this.pageStyle.TabIndex = 0;
            this.pageStyle.Text = "编辑自动操作";
            this.pageStyle.UseVisualStyleBackColor = true;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listStyles);
            this.groupBox1.Controls.Add(this.listKeyItems);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnEditStyle);
            this.groupBox1.Controls.Add(this.listStyleItems);
            this.groupBox1.Controls.Add(this.btnDeleteStyle);
            this.groupBox1.Controls.Add(this.btnNewStyle);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1a7, 0x133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自动操作列表";
            this.button1.Location = new Point(0xe3, 0x12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x3f, 0x1a);
            this.button1.TabIndex = 8;
            this.button1.Text = "复制";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.btnCopy_Click_1);
            this.listStyles.DrawMode = DrawMode.OwnerDrawFixed;
            this.listStyles.Font = new Font("宋体", 9f);
            this.listStyles.FormattingEnabled = true;
            this.listStyles.ItemDragMove = true;
            this.listStyles.ItemHeight = 20;
            this.listStyles.ItemKeyDelete = true;
            this.listStyles.ItemLine = false;
            this.listStyles.ItemLineColor = Color.Gray;
            this.listStyles.LeftSpace = 2;
            this.listStyles.Location = new Point(20, 0x31);
            this.listStyles.Name = "listStyles";
            this.listStyles.Size = new Size(0xc9, 0xf4);
            this.listStyles.TabIndex = 3;
            this.listStyles.SelectedIndexChanged += new EventHandler(this.listStyles_SelectedIndexChanged);
            this.listStyles.DoubleClick += new EventHandler(this.listStyles_DoubleClick);
            this.listKeyItems.BackColor = Color.White;
            this.listKeyItems.ForeColor = SystemColors.WindowText;
            this.listKeyItems.FormattingEnabled = true;
            this.listKeyItems.ItemHeight = 12;
            this.listKeyItems.Location = new Point(0xed, 0xcc);
            this.listKeyItems.Name = "listKeyItems";
            this.listKeyItems.Size = new Size(180, 0x58);
            this.listKeyItems.TabIndex = 7;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0xeb, 0xbc);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x44, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "快捷键分配：";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0xeb, 0x3b);
            this.label1.Name = "label1";
            this.label1.Size = new Size(80, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "自动操作的构成：";
            this.btnEditStyle.Location = new Point(0x59, 0x12);
            this.btnEditStyle.Name = "btnEditStyle";
            this.btnEditStyle.Size = new Size(0x3f, 0x1a);
            this.btnEditStyle.TabIndex = 1;
            this.btnEditStyle.Tag = " ";
            this.btnEditStyle.Text = "编辑";
            this.btnEditStyle.UseVisualStyleBackColor = true;
            this.btnEditStyle.Click += new EventHandler(this.btnEditStyle_Click);
            this.listStyleItems.BackColor = Color.White;
            this.listStyleItems.ForeColor = SystemColors.WindowText;
            this.listStyleItems.FormattingEnabled = true;
            this.listStyleItems.ItemHeight = 12;
            this.listStyleItems.Location = new Point(0xed, 0x4c);
            this.listStyleItems.Name = "listStyleItems";
            this.listStyleItems.Size = new Size(180, 100);
            this.listStyleItems.TabIndex = 5;
            this.btnDeleteStyle.Location = new Point(0x9e, 0x12);
            this.btnDeleteStyle.Name = "btnDeleteStyle";
            this.btnDeleteStyle.Size = new Size(0x3f, 0x1a);
            this.btnDeleteStyle.TabIndex = 2;
            this.btnDeleteStyle.Text = "删除";
            this.btnDeleteStyle.UseVisualStyleBackColor = true;
            this.btnDeleteStyle.Click += new EventHandler(this.btnDeleteStyle_Click);
            this.btnNewStyle.Location = new Point(20, 0x12);
            this.btnNewStyle.Name = "btnNewStyle";
            this.btnNewStyle.Size = new Size(0x3f, 0x1a);
            this.btnNewStyle.TabIndex = 0;
            this.btnNewStyle.Text = "新建";
            this.btnNewStyle.UseVisualStyleBackColor = true;
            this.btnNewStyle.Click += new EventHandler(this.btnNewStyle_Click);
            this.pageScrapMenu.BackColor = Color.White;
            this.pageScrapMenu.Controls.Add(this.btnScrapMenuMove);
            this.pageScrapMenu.Controls.Add(this.groupBox10);
            this.pageScrapMenu.Controls.Add(this.groupBox9);
            this.pageScrapMenu.Controls.Add(this.groupBox8);
            this.pageScrapMenu.Location = new Point(4, 0x18);
            this.pageScrapMenu.Name = "pageScrapMenu";
            this.pageScrapMenu.Padding = new Padding(5);
            this.pageScrapMenu.Size = new Size(0x1b7, 0x148);
            this.pageScrapMenu.TabIndex = 3;
            this.pageScrapMenu.Text = "参考图菜单";
            this.pageScrapMenu.UseVisualStyleBackColor = true;
            this.btnScrapMenuMove.Location = new Point(0xc4, 0x1a);
            this.btnScrapMenuMove.Name = "btnScrapMenuMove";
            this.btnScrapMenuMove.Size = new Size(0x30, 0x117);
            this.btnScrapMenuMove.TabIndex = 2;
            this.btnScrapMenuMove.Text = ">>";
            this.btnScrapMenuMove.UseVisualStyleBackColor = true;
            this.btnScrapMenuMove.Click += new EventHandler(this.btnScrapMenuMove_Click);
            this.groupBox10.Controls.Add(this.listScrapMenuList);
            this.groupBox10.Location = new Point(250, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new Padding(5, 3, 5, 3);
            this.groupBox10.Size = new Size(0xb5, 0x131);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "参考图菜单";
            this.listScrapMenuList.DrawMode = DrawMode.OwnerDrawFixed;
            this.listScrapMenuList.Font = new Font("宋体", 9f);
            this.listScrapMenuList.FormattingEnabled = true;
            this.listScrapMenuList.IntegralHeight = false;
            this.listScrapMenuList.ItemDragMove = true;
            this.listScrapMenuList.ItemHeight = 20;
            this.listScrapMenuList.ItemKeyDelete = true;
            this.listScrapMenuList.ItemLine = false;
            this.listScrapMenuList.ItemLineColor = Color.Gray;
            this.listScrapMenuList.LeftSpace = 2;
            this.listScrapMenuList.Location = new Point(8, 0x12);
            this.listScrapMenuList.Name = "listScrapMenuList";
            this.listScrapMenuList.Size = new Size(0xa5, 0x117);
            this.listScrapMenuList.TabIndex = 0;
            this.toolTip1.SetToolTip(this.listScrapMenuList, "右键单击参考图时显示的菜单结构。");
            this.groupBox9.Controls.Add(this.listScrapMenuItems);
            this.groupBox9.Location = new Point(8, 0xcb);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new Padding(5, 3, 5, 3);
            this.groupBox9.Size = new Size(0xb6, 110);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "其他";
            this.listScrapMenuItems.DrawMode = DrawMode.OwnerDrawFixed;
            this.listScrapMenuItems.Font = new Font("宋体", 9f);
            this.listScrapMenuItems.FormattingEnabled = true;
            this.listScrapMenuItems.ItemDragMove = false;
            this.listScrapMenuItems.ItemHeight = 20;
            this.listScrapMenuItems.ItemKeyDelete = false;
            this.listScrapMenuItems.ItemLine = false;
            this.listScrapMenuItems.ItemLineColor = Color.Gray;
            this.listScrapMenuItems.LeftSpace = 2;
            this.listScrapMenuItems.Location = new Point(8, 0x12);
            this.listScrapMenuItems.Name = "listScrapMenuItems";
            this.listScrapMenuItems.Size = new Size(0xa6, 0x54);
            this.listScrapMenuItems.TabIndex = 0;
            this.listScrapMenuItems.MouseDoubleClick += new MouseEventHandler(this.listScrapMenuItems_MouseDoubleClick);
            this.listScrapMenuItems.Enter += new EventHandler(this.listScrapMenuItems_Enter);
            this.groupBox8.Controls.Add(this.listScrapMenuStyles);
            this.groupBox8.Location = new Point(8, 8);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new Padding(5, 3, 5, 3);
            this.groupBox8.Size = new Size(0xb6, 0xbd);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "自动操作列表";
            this.listScrapMenuStyles.DrawMode = DrawMode.OwnerDrawFixed;
            this.listScrapMenuStyles.Font = new Font("宋体", 9f);
            this.listScrapMenuStyles.FormattingEnabled = true;
            this.listScrapMenuStyles.ItemDragMove = false;
            this.listScrapMenuStyles.ItemHeight = 20;
            this.listScrapMenuStyles.ItemKeyDelete = false;
            this.listScrapMenuStyles.ItemLine = false;
            this.listScrapMenuStyles.ItemLineColor = Color.Gray;
            this.listScrapMenuStyles.LeftSpace = 2;
            this.listScrapMenuStyles.Location = new Point(8, 0x12);
            this.listScrapMenuStyles.Name = "listScrapMenuStyles";
            this.listScrapMenuStyles.Size = new Size(0xa6, 0xa4);
            this.listScrapMenuStyles.TabIndex = 0;
            this.listScrapMenuStyles.MouseDoubleClick += new MouseEventHandler(this.listScrapMenuStyles_MouseDoubleClick);
            this.listScrapMenuStyles.Enter += new EventHandler(this.listScrapMenuStyles_Enter);
            this.panel1.BackColor = Color.FromArgb(0x51, 0xa3, 0xec);
            this.panel1.Controls.Add(this.lblMenuStyle);
            this.panel1.Controls.Add(this.lblMenuCapture);
            this.panel1.Controls.Add(this.lblMenuMenu);
            this.panel1.Controls.Add(this.lblMenuScrap);
            this.panel1.Controls.Add(this.lblMenuAll);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = DockStyle.Left;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x81, 360);
            this.panel1.TabIndex = 1;
            this.lblMenuStyle.BackColor = Color.FromArgb(0x2e, 0x84, 0xd7);
            this.lblMenuStyle.Cursor = Cursors.Hand;
            this.lblMenuStyle.ForeColor = Color.White;
            this.lblMenuStyle.Location = new Point(0x1b, 70);
            this.lblMenuStyle.Name = "lblMenuStyle";
            this.lblMenuStyle.Size = new Size(100, 14);
            this.lblMenuStyle.TabIndex = 2;
            this.lblMenuStyle.Text = "创建自动操作";
            this.lblMenuStyle.MouseLeave += new EventHandler(this.lblMenu_Clear);
            this.lblMenuStyle.Click += new EventHandler(this.lblMenuStyle_Click);
            this.lblMenuStyle.MouseEnter += new EventHandler(this.lblMenuStyle_MouseEnter);
            this.lblMenuCapture.BackColor = Color.FromArgb(0x2e, 0x84, 0xd7);
            this.lblMenuCapture.Cursor = Cursors.Hand;
            this.lblMenuCapture.ForeColor = Color.White;
            this.lblMenuCapture.Location = new Point(12, 30);
            this.lblMenuCapture.Name = "lblMenuCapture";
            this.lblMenuCapture.Size = new Size(100, 14);
            this.lblMenuCapture.TabIndex = 5;
            this.lblMenuCapture.Text = "截取设置";
            this.lblMenuCapture.MouseLeave += new EventHandler(this.lblMenu_Clear);
            this.lblMenuCapture.Click += new EventHandler(this.lblMenuCapture_Click);
            this.lblMenuCapture.MouseEnter += new EventHandler(this.lblMenuCapture_MouseEnter);
            this.lblMenuMenu.BackColor = Color.FromArgb(0x2e, 0x84, 0xd7);
            this.lblMenuMenu.Cursor = Cursors.Hand;
            this.lblMenuMenu.ForeColor = Color.White;
            this.lblMenuMenu.Location = new Point(0x1b, 90);
            this.lblMenuMenu.Name = "lblMenuMenu";
            this.lblMenuMenu.Size = new Size(100, 14);
            this.lblMenuMenu.TabIndex = 3;
            this.lblMenuMenu.Text = "参考图菜单";
            this.lblMenuMenu.MouseLeave += new EventHandler(this.lblMenu_Clear);
            this.lblMenuMenu.Click += new EventHandler(this.lblMenuMenu_Click);
            this.lblMenuMenu.MouseEnter += new EventHandler(this.lblMenuMenu_MouseEnter);
            this.lblMenuScrap.BackColor = Color.FromArgb(0x2e, 0x84, 0xd7);
            this.lblMenuScrap.Cursor = Cursors.Hand;
            this.lblMenuScrap.ForeColor = Color.White;
            this.lblMenuScrap.Location = new Point(12, 50);
            this.lblMenuScrap.Name = "lblMenuScrap";
            this.lblMenuScrap.Size = new Size(100, 14);
            this.lblMenuScrap.TabIndex = 1;
            this.lblMenuScrap.Text = "参考图设置";
            this.lblMenuScrap.MouseLeave += new EventHandler(this.lblMenu_Clear);
            this.lblMenuScrap.Click += new EventHandler(this.lblMenuScrap_Click);
            this.lblMenuScrap.MouseEnter += new EventHandler(this.lblMenuScrap_MouseEnter);
            this.lblMenuAll.BackColor = Color.FromArgb(0x2e, 0x84, 0xd7);
            this.lblMenuAll.Cursor = Cursors.Hand;
            this.lblMenuAll.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, 0x80);
            this.lblMenuAll.ForeColor = Color.White;
            this.lblMenuAll.Location = new Point(12, 10);
            this.lblMenuAll.Name = "lblMenuAll";
            this.lblMenuAll.Size = new Size(100, 15);
            this.lblMenuAll.TabIndex = 0;
            this.lblMenuAll.Text = "常规";
            this.lblMenuAll.MouseLeave += new EventHandler(this.lblMenu_Clear);
            this.lblMenuAll.Click += new EventHandler(this.lblMenuAll_Click);
            this.lblMenuAll.MouseEnter += new EventHandler(this.lblMenuAll_MouseEnter);
            this.pictureBox1.Image = Resources.OptionBG;
            this.pictureBox1.Location = new Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(170, 370);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.toolTip1.IsBalloon = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(580, 400);
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel2);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "OptionForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "选项";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.detailPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.pageAll.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.numDustBox.EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.pageCapture.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.numSelectAreaTrans.EndInit();
            ((ISupportInitialize) this.picSelectAreaBackColor).EndInit();
            ((ISupportInitialize) this.picSelectAreaLineColor).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pageScrap.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlScrapStyle.ResumeLayout(false);
            this.pnlScrapStyle.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.numMouseOverAlpha.EndInit();
            this.numInactiveAlpha.EndInit();
            this.pageStyle.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pageScrapMenu.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }

        private void lblMenu_Clear(object sender, EventArgs e)
        {
            this.lblComment.Text = "";
        }

        private void lblMenuAll_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.pageAll;
        }

        private void lblMenuAll_MouseEnter(object sender, EventArgs e)
        {
            this.lblComment.Text = "SETUNA常规设置。";
        }

        private void lblMenuCapture_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.pageCapture;
        }

        private void lblMenuCapture_MouseEnter(object sender, EventArgs e)
        {
            this.lblComment.Text = "进行有关截取的设置。";
        }

        private void lblMenuMenu_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.pageScrapMenu;
        }

        private void lblMenuMenu_MouseEnter(object sender, EventArgs e)
        {
            this.lblComment.Text = "设置右键单击参考图时的菜单。";
        }

        private void lblMenuScrap_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.pageScrap;
        }

        private void lblMenuScrap_MouseEnter(object sender, EventArgs e)
        {
            this.lblComment.Text = "进行参考图的常规设置。";
        }

        private void lblMenuStyle_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.pageStyle;
        }

        private void lblMenuStyle_MouseEnter(object sender, EventArgs e)
        {
            this.lblComment.Text = "创建一个由自动操作组合而成的自动操作。";
        }

        private void listScrapMenuItems_Enter(object sender, EventArgs e)
        {
            this.listScrapMenuStyles.ClearSelected();
        }

        private void listScrapMenuItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int num = this.listScrapMenuList.Items.Add(this.listScrapMenuItems.SelectedItem);
            this.listScrapMenuList.SelectedIndex = num;
        }

        private void listScrapMenuStyles_Enter(object sender, EventArgs e)
        {
            this.listScrapMenuItems.ClearSelected();
        }

        private void listScrapMenuStyles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int num = this.listScrapMenuList.Items.Add(this.listScrapMenuStyles.SelectedItem);
            this.listScrapMenuList.SelectedIndex = num;
        }

        private void listStyles_DoubleClick(object sender, EventArgs e)
        {
            ListBox box = (ListBox) sender;
            if (box.SelectedItem != null)
            {
                this.EditStyle_ScrapStyle();
            }
        }

        private void listStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectStyle_ScrapStyle();
        }

        private void LoadSetunaOption()
        {
            this.Prepare_SetunaAll();
            this.chkCC7.Checked = this._so.Setuna.ClickCapture7;
            this.chkCC8.Checked = this._so.Setuna.ClickCapture8;
            this.chkCC9.Checked = this._so.Setuna.ClickCapture9;
            this.chkCC4.Checked = this._so.Setuna.ClickCapture4;
            this.chkCC6.Checked = this._so.Setuna.ClickCapture6;
            this.chkCC1.Checked = this._so.Setuna.ClickCapture1;
            this.chkCC2.Checked = this._so.Setuna.ClickCapture2;
            this.chkCC3.Checked = this._so.Setuna.ClickCapture3;
            this.listStyles.BeginUpdate();
            this.listStyles.Items.Clear();
            for (int i = 0; i < this._so.Styles.Count; i++)
            {
                this.listStyles.Items.Add(this._so.Styles[i]);
            }
            this.listStyles.EndUpdate();
            this._createStyleId = this._so.Scrap.CreateStyleID;
            this._wclickStyleId = this._so.Scrap.WClickStyleID;
            this.chkScrapImageDrag.Checked = this._so.Scrap.ImageDrag;
            this.chkInactiveAlphaChange.Checked = this._so.Scrap.InactiveAlphaChange;
            this.numInactiveAlpha.Value = this._so.Scrap.InactiveAlphaValue;
            this.chkMouseOverAlphaChange.Checked = this._so.Scrap.MouseOverAlphaChange;
            this.numMouseOverAlpha.Value = this._so.Scrap.MouseOverAlphaValue;
            this.Prepare_ScrapMenu();
            this.RefreshStyleList_Scrap();
        }

        private void OptionForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PictureBox box = (PictureBox) sender;
                box.BackColor = dialog.Color;
            }
        }

        private void Prepare_ScrapMenu()
        {
            this.listScrapMenuItems.Items.Clear();
            foreach (CStyle style in CPreStyles.GetPreStyleList())
            {
                this.listScrapMenuItems.Items.Add(style);
            }
            this.RefreshScrapMenuList_Menu(this._so.Scrap.SubMenuStyles);
        }

        private void Prepare_SetunaAll()
        {
            this.hotkeyControl1.Hotkey = (Keys) this._so.ScrapHotKey;
            this.checkBox1.Checked = this._so.ScrapHotKeyEnable;
            this.rdoSelLineTypeSolid.Checked = this._so.Setuna.SelectLineSolid;
            this.rdoSelLineTypeDotted.Checked = !this._so.Setuna.SelectLineSolid;
            this.picSelectAreaLineColor.BackColor = this._so.Setuna.SelectLineColor;
            this.picSelectAreaBackColor.BackColor = this._so.Setuna.SelectBackColor;
            this.numSelectAreaTrans.Value = this._so.Setuna.SelectAreaTransparent;
            this.chkDustBox.Checked = this._so.Setuna.DustBoxEnable;
            this.numDustBox.Value = this._so.Setuna.DustBoxCapacity;
            if (this._so.Setuna.AppType == SetunaOption.SetunaOptionData.ApplicationType.ApplicationMode)
            {
                this.rdoExeTypeApp.Checked = true;
            }
            else
            {
                this.rdoExeTypeResident.Checked = true;
            }
            this.chkShowMainWindow.Checked = this._so.Setuna.ShowMainWindow;
            if (this._so.Setuna.DupType == SetunaOption.SetunaOptionData.OpeningType.Normal)
            {
                this.rdoDupNone.Checked = true;
            }
            else
            {
                this.rdoDupCapture.Checked = true;
            }
            this.chkSplash.Checked = this._so.Setuna.ShowSplashWindow;
        }

        private void PrepareStyle()
        {
            this.Refresh_Style_StyleList();
        }

        private void rdoExeTypeResident_CheckedChanged(object sender, EventArgs e)
        {
            this.chkShowMainWindow.Enabled = this.rdoExeTypeResident.Checked;
        }

        private void Refresh_Style_StyleList()
        {
            this.listStyles.BeginUpdate();
            this.listStyles.Items.Clear();
            for (int i = 0; i < this._so.Styles.Count; i++)
            {
                this.listStyles.Items.Add(this._so.Styles[i]);
            }
            this.listStyles.EndUpdate();
        }

        private void RefreshScrapMenuList_Menu(List<int> style_ids)
        {
            this.listScrapMenuList.BeginUpdate();
            this.listScrapMenuList.Items.Clear();
            foreach (int num in style_ids)
            {
                if (num >= 0)
                {
                    foreach (CStyle style in this.listStyles.Items)
                    {
                        if (style.StyleID == num)
                        {
                            this.listScrapMenuList.Items.Add(style);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (CStyle style2 in this.listScrapMenuItems.Items)
                    {
                        if (style2.StyleID == num)
                        {
                            this.listScrapMenuList.Items.Add(style2);
                            break;
                        }
                    }
                }
            }
            this.listScrapMenuList.EndUpdate();
        }

        private void RefreshScrapMenuStyleList_Menu()
        {
            base.SuspendLayout();
            this.SetStyleList_Menu(this.listScrapMenuStyles);
            base.ResumeLayout();
        }

        private void RefreshStyleList_Scrap()
        {
            this.SetStyleList_Scrap(this.cmbCreateStyle, 0);
            this.SetStyleList_Scrap(this.cmbWClickStyle, 0);
            this.cmbCreateStyle.SelectedIndex = this.FindStyle_Scrap(this.cmbCreateStyle, this._createStyleId);
            this.cmbWClickStyle.SelectedIndex = this.FindStyle_Scrap(this.cmbWClickStyle, this._wclickStyleId);
        }

        private void SelectStyle_ScrapStyle()
        {
            this.listStyleItems.Items.Clear();
            this.listKeyItems.Items.Clear();
            if (this.listStyles.SelectedItem != null)
            {
                CStyle selectedItem = (CStyle) this.listStyles.SelectedItem;
                for (int i = 0; i < selectedItem.Items.Length; i++)
                {
                    this.listStyleItems.Items.Add(selectedItem.Items[i]);
                }
                for (int j = 0; j < selectedItem.KeyItems.Length; j++)
                {
                    this.listKeyItems.Items.Add(selectedItem.KeyItems[j]);
                }
            }
        }

        private void SetStyleList_Menu(ListBox list)
        {
            CStyle style = new CStyle {
                StyleID = 0,
                StyleName = ""
            };
            list.BeginUpdate();
            list.Items.Clear();
            for (int i = 0; i < this.listStyles.Items.Count; i++)
            {
                CStyle item = (CStyle) this.listStyles.Items[i];
                list.Items.Add(item);
            }
            list.EndUpdate();
        }

        private void SetStyleList_Scrap(ComboBox combo, int defaultid)
        {
            CStyle item = new CStyle {
                StyleID = 0,
                StyleName = ""
            };
            combo.BeginUpdate();
            combo.Items.Clear();
            combo.Items.Add(item);
            for (int i = 0; i < this.listStyles.Items.Count; i++)
            {
                CStyle style2 = (CStyle) this.listStyles.Items[i];
                combo.Items.Add(style2);
                if (style2.StyleID == defaultid)
                {
                    combo.SelectedIndex = i;
                }
            }
            combo.EndUpdate();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            this.lblMenuAll.Font = new Font(this.lblMenuAll.Font, FontStyle.Regular);
            this.lblMenuCapture.Font = new Font(this.lblMenuMenu.Font, FontStyle.Regular);
            this.lblMenuScrap.Font = new Font(this.lblMenuScrap.Font, FontStyle.Regular);
            this.lblMenuStyle.Font = new Font(this.lblMenuStyle.Font, FontStyle.Regular);
            this.lblMenuMenu.Font = new Font(this.lblMenuMenu.Font, FontStyle.Regular);
            if (this.tabControl1.SelectedTab == this.pageAll)
            {
                this.lblMenuAll.Font = new Font(this.lblMenuAll.Font, FontStyle.Bold);
            }
            if (this.tabControl1.SelectedTab == this.pageCapture)
            {
                this.lblMenuCapture.Font = new Font(this.lblMenuAll.Font, FontStyle.Bold);
            }
            if (this.tabControl1.SelectedTab == this.pageScrap)
            {
                this.lblMenuScrap.Font = new Font(this.lblMenuScrap.Font, FontStyle.Bold);
            }
            if (this.tabControl1.SelectedTab == this.pageStyle)
            {
                this.lblMenuStyle.Font = new Font(this.lblMenuStyle.Font, FontStyle.Bold);
            }
            if (this.tabControl1.SelectedTab == this.pageScrapMenu)
            {
                this.lblMenuMenu.Font = new Font(this.lblMenuMenu.Font, FontStyle.Bold);
                this.RefreshScrapMenuStyleList_Menu();
                this.RefreshScrapMenuList_Menu(this.GetStyleIDList_Menu());
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                base.SuspendLayout();
                TabPage tag = (TabPage) e.Node.Tag;
                this.tabControl1.SelectedTab = tag;
                this.tabControl1.Update();
                base.ResumeLayout();
            }
            catch
            {
            }
        }

        private void WriteSetunaOption()
        {
            this._so.ScrapHotKey = (int) this.hotkeyControl1.Hotkey;
            this._so.ScrapHotKeyEnable = this.checkBox1.Checked;
            if (this.rdoExeTypeApp.Checked)
            {
                this._so.Setuna.AppType = SetunaOption.SetunaOptionData.ApplicationType.ApplicationMode;
            }
            else
            {
                this._so.Setuna.AppType = SetunaOption.SetunaOptionData.ApplicationType.ResidentMode;
            }
            this._so.Setuna.ShowMainWindow = this.chkShowMainWindow.Checked;
            if (this.rdoDupNone.Checked)
            {
                this._so.Setuna.DupType = SetunaOption.SetunaOptionData.OpeningType.Normal;
            }
            else
            {
                this._so.Setuna.DupType = SetunaOption.SetunaOptionData.OpeningType.Capture;
            }
            this._so.Setuna.ShowSplashWindow = this.chkSplash.Checked;
            this._so.Setuna.SelectLineSolid = this.rdoSelLineTypeSolid.Checked;
            this._so.Setuna.SelectLineColorR = this.picSelectAreaLineColor.BackColor.R;
            this._so.Setuna.SelectLineColorG = this.picSelectAreaLineColor.BackColor.G;
            this._so.Setuna.SelectLineColorB = this.picSelectAreaLineColor.BackColor.B;
            this._so.Setuna.SelectBackColorR = this.picSelectAreaBackColor.BackColor.R;
            this._so.Setuna.SelectBackColorG = this.picSelectAreaBackColor.BackColor.G;
            this._so.Setuna.SelectBackColorB = this.picSelectAreaBackColor.BackColor.B;
            this._so.Setuna.SelectAreaTransparent = (int) this.numSelectAreaTrans.Value;
            this._so.Setuna.DustBoxEnable = this.chkDustBox.Checked;
            this._so.Setuna.DustBoxCapacity = (ushort) this.numDustBox.Value;
            this._so.Scrap.CreateStyleID = this._createStyleId;
            this._so.Scrap.WClickStyleID = this._wclickStyleId;
            this._so.Scrap.ImageDrag = this.chkScrapImageDrag.Checked;
            this._so.Scrap.InactiveAlphaChange = this.chkInactiveAlphaChange.Checked;
            this._so.Scrap.InactiveAlphaValue = (sbyte) this.numInactiveAlpha.Value;
            this._so.Scrap.MouseOverAlphaChange = this.chkMouseOverAlphaChange.Checked;
            this._so.Scrap.MouseOverAlphaValue = (sbyte) this.numMouseOverAlpha.Value;
            this._so.Setuna.ClickCapture7 = this.chkCC7.Checked;
            this._so.Setuna.ClickCapture8 = this.chkCC8.Checked;
            this._so.Setuna.ClickCapture9 = this.chkCC9.Checked;
            this._so.Setuna.ClickCapture4 = this.chkCC4.Checked;
            this._so.Setuna.ClickCapture6 = this.chkCC6.Checked;
            this._so.Setuna.ClickCapture1 = this.chkCC1.Checked;
            this._so.Setuna.ClickCapture2 = this.chkCC2.Checked;
            this._so.Setuna.ClickCapture3 = this.chkCC3.Checked;
            this._so.Styles.Clear();
            for (int i = 0; i < this.listStyles.Items.Count; i++)
            {
                this._so.Styles.Add((CStyle) this.listStyles.Items[i]);
            }
            List<int> list = new List<int>();
            foreach (CStyle style in this.listScrapMenuList.Items)
            {
                list.Add(style.StyleID);
            }
            this._so.Scrap.SubMenuStyles = list;
        }

        public SetunaOption Option =>
            this._so;
    }
}

