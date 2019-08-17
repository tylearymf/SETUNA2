namespace SETUNA.Main.Option
{
    using com.clearunit;
    using SETUNA.Main;
    using SETUNA.Main.KeyItems;
    using SETUNA.Main.Other;
    using SETUNA.Main.Style;
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
        private Button btnOK;
        private IContainer components;
        private Panel detailPanel;
        private Label lblComment;
        private Label lblMenuAll;
        private Label lblMenuCapture;
        private Label lblMenuMenu;
        private Label lblMenuScrap;
        private Label lblMenuStyle;
        private Label lblMenuDPI;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private WithoutTabControl tabControl1;
        private TabPage pageAll;
        private GroupBox groupBox13;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private GroupBox groupBox7;
        private CheckBox checkBox2;
        private CheckBox chkSplash;
        private GroupBox groupBox5;
        private CheckBox chkDustBox;
        private Label label14;
        private NumericUpDown numDustBox;
        private Button btnInitialize;
        private GroupBox groupBox6;
        private CheckBox chkShowMainWindow;
        private RadioButton rdoExeTypeResident;
        private RadioButton rdoExeTypeApp;
        private TabPage pageCapture;
        private GroupBox groupBox12;
        private Label label16;
        private CheckBox chkCC6;
        private CheckBox chkCC4;
        private CheckBox chkCC2;
        private CheckBox chkCC8;
        private CheckBox chkCC3;
        private CheckBox chkCC1;
        private CheckBox chkCC9;
        private CheckBox chkCC7;
        private GroupBox groupBox3;
        private RadioButton rdoDupCapture;
        private RadioButton rdoDupNone;
        private GroupBox groupBox4;
        private RadioButton rdoSelLineTypeDotted;
        private RadioButton rdoSelLineTypeSolid;
        private Label label12;
        private NumericUpDown numSelectAreaTrans;
        private PictureBox picSelectAreaBackColor;
        private PictureBox picSelectAreaLineColor;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private GroupBox groupBox2;
        private CheckBox checkBox1;
        private Label label3;
        private HotkeyControl hotkeyControl1;
        private TabPage pageScrap;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pnlScrapStyle;
        private ComboBox cmbWClickStyle;
        private Label label5;
        private ComboBox cmbCreateStyle;
        private Label label4;
        private Panel panel4;
        private CheckBox chkScrapImageDrag;
        private GroupBox groupBox11;
        private Label label15;
        private Label label13;
        private NumericUpDown numMouseOverAlpha;
        private CheckBox chkMouseOverAlphaChange;
        private Label label11;
        private Label label6;
        private NumericUpDown numInactiveAlpha;
        private CheckBox chkInactiveAlphaChange;
        private TabPage pageStyle;
        private GroupBox groupBox1;
        private Button button1;
        private SetunaListBox listStyles;
        private ListBox listKeyItems;
        private Label label2;
        private Label label1;
        private Button btnEditStyle;
        private ListBox listStyleItems;
        private Button btnDeleteStyle;
        private Button btnNewStyle;
        private TabPage pageScrapMenu;
        private Button btnScrapMenuMove;
        private GroupBox groupBox10;
        private SetunaListBox listScrapMenuList;
        private GroupBox groupBox9;
        private SetunaListBox listScrapMenuItems;
        private GroupBox groupBox8;
        private SetunaListBox listScrapMenuStyles;
        private ToolTip toolTip1;
        private GroupBox groupBox14;
        private Label label17;
        private GroupBox groupBox15;
        private Label label18;
        private Label label19;
        private TextBox Dpi1Txt;
        private TextBox Dpi4Txt;
        private Label label22;
        private TextBox Dpi3Txt;
        private Label label21;
        private TextBox Dpi2Txt;
        private Label label20;
        private TabPage pageDPISetting;
        private CheckBox checkBox3;
        private LayerInfo mLayerInfo;


        public OptionForm(SetunaOption opt)
        {
            this.InitializeComponent();
            this._pageStyle = this.pageStyle;
            this._pageScrapMenu = this.pageScrapMenu;
            this._so = opt;
            this.TopMost = true;
            this.LoadSetunaOption();
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
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
                CStyle trgStyle = ((CStyle)this.listStyles.SelectedItem).DeepCopy();
                trgStyle.StyleName = "";
                trgStyle.ClearKey();
                StyleEditForm form = new StyleEditForm(trgStyle, book)
                {
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
                int styleID = ((CStyle)this.listStyles.SelectedItem).StyleID;
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
                AutoStartup.Set(false);
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
                CheckBox box = (CheckBox)sender;
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
            CStyle selectedItem = (CStyle)this.cmbCreateStyle.SelectedItem;
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
            CStyle selectedItem = (CStyle)this.cmbWClickStyle.SelectedItem;
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
                StyleEditForm form = new StyleEditForm((CStyle)this.listStyles.SelectedItem, book)
                {
                    Text = ((CStyle)this.listStyles.SelectedItem).StyleName + "的相关编辑"
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
                    CStyle style = (CStyle)combo.Items[i];
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
                CStyle style = (CStyle)this.listStyles.Items[i];
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblComment = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.detailPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new com.clearunit.WithoutTabControl();
            this.pageAll = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chkSplash = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkDustBox = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numDustBox = new System.Windows.Forms.NumericUpDown();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkShowMainWindow = new System.Windows.Forms.CheckBox();
            this.rdoExeTypeResident = new System.Windows.Forms.RadioButton();
            this.rdoExeTypeApp = new System.Windows.Forms.RadioButton();
            this.pageCapture = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkCC6 = new System.Windows.Forms.CheckBox();
            this.chkCC4 = new System.Windows.Forms.CheckBox();
            this.chkCC2 = new System.Windows.Forms.CheckBox();
            this.chkCC8 = new System.Windows.Forms.CheckBox();
            this.chkCC3 = new System.Windows.Forms.CheckBox();
            this.chkCC1 = new System.Windows.Forms.CheckBox();
            this.chkCC9 = new System.Windows.Forms.CheckBox();
            this.chkCC7 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoDupCapture = new System.Windows.Forms.RadioButton();
            this.rdoDupNone = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoSelLineTypeDotted = new System.Windows.Forms.RadioButton();
            this.rdoSelLineTypeSolid = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.numSelectAreaTrans = new System.Windows.Forms.NumericUpDown();
            this.picSelectAreaBackColor = new System.Windows.Forms.PictureBox();
            this.picSelectAreaLineColor = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hotkeyControl1 = new SETUNA.Main.HotkeyControl();
            this.pageScrap = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlScrapStyle = new System.Windows.Forms.Panel();
            this.cmbWClickStyle = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCreateStyle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkScrapImageDrag = new System.Windows.Forms.CheckBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.numMouseOverAlpha = new System.Windows.Forms.NumericUpDown();
            this.chkMouseOverAlphaChange = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numInactiveAlpha = new System.Windows.Forms.NumericUpDown();
            this.chkInactiveAlphaChange = new System.Windows.Forms.CheckBox();
            this.pageStyle = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listStyles = new SETUNA.Main.SetunaListBox();
            this.listKeyItems = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditStyle = new System.Windows.Forms.Button();
            this.listStyleItems = new System.Windows.Forms.ListBox();
            this.btnDeleteStyle = new System.Windows.Forms.Button();
            this.btnNewStyle = new System.Windows.Forms.Button();
            this.pageScrapMenu = new System.Windows.Forms.TabPage();
            this.btnScrapMenuMove = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.listScrapMenuList = new SETUNA.Main.SetunaListBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.listScrapMenuItems = new SETUNA.Main.SetunaListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.listScrapMenuStyles = new SETUNA.Main.SetunaListBox();
            this.pageDPISetting = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.Dpi4Txt = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.Dpi3Txt = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.Dpi2Txt = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.Dpi1Txt = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMenuStyle = new System.Windows.Forms.Label();
            this.lblMenuCapture = new System.Windows.Forms.Label();
            this.lblMenuMenu = new System.Windows.Forms.Label();
            this.lblMenuScrap = new System.Windows.Forms.Label();
            this.lblMenuDPI = new System.Windows.Forms.Label();
            this.lblMenuAll = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.detailPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.pageAll.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDustBox)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.pageCapture.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectAreaTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectAreaBackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectAreaLineColor)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pageScrap.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlScrapStyle.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseOverAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInactiveAlpha)).BeginInit();
            this.pageStyle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pageScrapMenu.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.pageDPISetting.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblComment);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 630);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1052, 70);
            this.panel2.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(22, 11);
            this.lblComment.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(649, 40);
            this.lblComment.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(864, 11);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(170, 47);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(682, 11);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(170, 47);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.detailPanel);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1052, 630);
            this.panel3.TabIndex = 2;
            // 
            // detailPanel
            // 
            this.detailPanel.BackColor = System.Drawing.Color.White;
            this.detailPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.detailPanel.Controls.Add(this.tabControl1);
            this.detailPanel.Location = new System.Drawing.Point(234, 0);
            this.detailPanel.Margin = new System.Windows.Forms.Padding(0);
            this.detailPanel.Name = "detailPanel";
            this.detailPanel.Size = new System.Drawing.Size(815, 627);
            this.detailPanel.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.pageAll);
            this.tabControl1.Controls.Add(this.pageCapture);
            this.tabControl1.Controls.Add(this.pageScrap);
            this.tabControl1.Controls.Add(this.pageStyle);
            this.tabControl1.Controls.Add(this.pageScrapMenu);
            this.tabControl1.Controls.Add(this.pageDPISetting);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(811, 623);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // pageAll
            // 
            this.pageAll.BackColor = System.Drawing.Color.White;
            this.pageAll.Controls.Add(this.groupBox13);
            this.pageAll.Controls.Add(this.groupBox7);
            this.pageAll.Controls.Add(this.groupBox5);
            this.pageAll.Controls.Add(this.btnInitialize);
            this.pageAll.Controls.Add(this.groupBox6);
            this.pageAll.Location = new System.Drawing.Point(4, 34);
            this.pageAll.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pageAll.Name = "pageAll";
            this.pageAll.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.pageAll.Size = new System.Drawing.Size(803, 585);
            this.pageAll.TabIndex = 1;
            this.pageAll.Text = "常规";
            this.pageAll.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.linkLabel2);
            this.groupBox13.Controls.Add(this.linkLabel1);
            this.groupBox13.Location = new System.Drawing.Point(15, 411);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox13.Size = new System.Drawing.Size(768, 89);
            this.groupBox13.TabIndex = 11;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "信息";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(25, 30);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(220, 21);
            this.linkLabel2.TabIndex = 2;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "官方版本（地址已挂）";
            this.toolTip1.SetToolTip(this.linkLabel2, "http://www.clearunit.com/clearup/setuna2");
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(25, 63);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(237, 21);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "优化版本 by tylearymf";
            this.toolTip1.SetToolTip(this.linkLabel1, "https://github.com/tylearymf/SETUNA2");
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox3);
            this.groupBox7.Controls.Add(this.checkBox2);
            this.groupBox7.Controls.Add(this.chkSplash);
            this.groupBox7.Location = new System.Drawing.Point(15, 311);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox7.Size = new System.Drawing.Size(768, 89);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "其他";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(302, 39);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(120, 25);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "开机启动";
            this.toolTip1.SetToolTip(this.checkBox2, "开机时自动启动该软件");
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // chkSplash
            // 
            this.chkSplash.AutoSize = true;
            this.chkSplash.Location = new System.Drawing.Point(29, 39);
            this.chkSplash.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkSplash.Name = "chkSplash";
            this.chkSplash.Size = new System.Drawing.Size(162, 25);
            this.chkSplash.TabIndex = 7;
            this.chkSplash.Text = "显示启动界面";
            this.toolTip1.SetToolTip(this.chkSplash, "将在启动SETUNA时的几秒钟内显示标志。");
            this.chkSplash.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkDustBox);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.numDustBox);
            this.groupBox5.Location = new System.Drawing.Point(15, 179);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox5.Size = new System.Drawing.Size(768, 123);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "回收站的设置";
            // 
            // chkDustBox
            // 
            this.chkDustBox.AutoSize = true;
            this.chkDustBox.Location = new System.Drawing.Point(29, 39);
            this.chkDustBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkDustBox.Name = "chkDustBox";
            this.chkDustBox.Size = new System.Drawing.Size(141, 25);
            this.chkDustBox.TabIndex = 4;
            this.chkDustBox.Text = "使用回收站";
            this.toolTip1.SetToolTip(this.chkDustBox, "使用回收站的话，参考图将暂时储存在回收站里。\n可以根据情况需要从回收站中取出。");
            this.chkDustBox.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(131, 75);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 21);
            this.label14.TabIndex = 6;
            this.label14.Text = "张为上限";
            // 
            // numDustBox
            // 
            this.numDustBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numDustBox.Location = new System.Drawing.Point(67, 70);
            this.numDustBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.numDustBox.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numDustBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDustBox.Name = "numDustBox";
            this.numDustBox.Size = new System.Drawing.Size(64, 31);
            this.numDustBox.TabIndex = 5;
            this.numDustBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.numDustBox, "指定在回收站中放入的最大张数。\n超过限额将丢弃旧的参考图。");
            this.numDustBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(452, 527);
            this.btnInitialize.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(331, 47);
            this.btnInitialize.TabIndex = 8;
            this.btnInitialize.Text = "设置全部恢复为默认状态";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkShowMainWindow);
            this.groupBox6.Controls.Add(this.rdoExeTypeResident);
            this.groupBox6.Controls.Add(this.rdoExeTypeApp);
            this.groupBox6.Location = new System.Drawing.Point(15, 14);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox6.Size = new System.Drawing.Size(768, 154);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "操作类型";
            // 
            // chkShowMainWindow
            // 
            this.chkShowMainWindow.AutoSize = true;
            this.chkShowMainWindow.Location = new System.Drawing.Point(61, 105);
            this.chkShowMainWindow.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkShowMainWindow.Name = "chkShowMainWindow";
            this.chkShowMainWindow.Size = new System.Drawing.Size(141, 25);
            this.chkShowMainWindow.TabIndex = 2;
            this.chkShowMainWindow.Text = "显示主窗口";
            this.chkShowMainWindow.UseVisualStyleBackColor = true;
            // 
            // rdoExeTypeResident
            // 
            this.rdoExeTypeResident.AutoSize = true;
            this.rdoExeTypeResident.Location = new System.Drawing.Point(29, 68);
            this.rdoExeTypeResident.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdoExeTypeResident.Name = "rdoExeTypeResident";
            this.rdoExeTypeResident.Size = new System.Drawing.Size(140, 25);
            this.rdoExeTypeResident.TabIndex = 1;
            this.rdoExeTypeResident.Text = "常驻任务栏";
            this.toolTip1.SetToolTip(this.rdoExeTypeResident, "在任务栏上显示图标。");
            this.rdoExeTypeResident.UseVisualStyleBackColor = true;
            this.rdoExeTypeResident.CheckedChanged += new System.EventHandler(this.rdoExeTypeResident_CheckedChanged);
            // 
            // rdoExeTypeApp
            // 
            this.rdoExeTypeApp.AutoSize = true;
            this.rdoExeTypeApp.Checked = true;
            this.rdoExeTypeApp.Location = new System.Drawing.Point(29, 33);
            this.rdoExeTypeApp.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdoExeTypeApp.Name = "rdoExeTypeApp";
            this.rdoExeTypeApp.Size = new System.Drawing.Size(119, 25);
            this.rdoExeTypeApp.TabIndex = 0;
            this.rdoExeTypeApp.TabStop = true;
            this.rdoExeTypeApp.Text = "应用软件";
            this.toolTip1.SetToolTip(this.rdoExeTypeApp, "显示主窗口、最小化到任务栏上");
            this.rdoExeTypeApp.UseVisualStyleBackColor = true;
            // 
            // pageCapture
            // 
            this.pageCapture.BackColor = System.Drawing.SystemColors.Window;
            this.pageCapture.Controls.Add(this.groupBox12);
            this.pageCapture.Controls.Add(this.groupBox3);
            this.pageCapture.Controls.Add(this.groupBox4);
            this.pageCapture.Controls.Add(this.groupBox2);
            this.pageCapture.Location = new System.Drawing.Point(4, 34);
            this.pageCapture.Margin = new System.Windows.Forms.Padding(0);
            this.pageCapture.Name = "pageCapture";
            this.pageCapture.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.pageCapture.Size = new System.Drawing.Size(803, 585);
            this.pageCapture.TabIndex = 4;
            this.pageCapture.Text = "截取设置";
            this.pageCapture.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label16);
            this.groupBox12.Controls.Add(this.chkCC6);
            this.groupBox12.Controls.Add(this.chkCC4);
            this.groupBox12.Controls.Add(this.chkCC2);
            this.groupBox12.Controls.Add(this.chkCC8);
            this.groupBox12.Controls.Add(this.chkCC3);
            this.groupBox12.Controls.Add(this.chkCC1);
            this.groupBox12.Controls.Add(this.chkCC9);
            this.groupBox12.Controls.Add(this.chkCC7);
            this.groupBox12.Location = new System.Drawing.Point(452, 133);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox12.Size = new System.Drawing.Size(331, 366);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "单击截取";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(9, 296);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(314, 54);
            this.label16.TabIndex = 8;
            this.label16.Text = "当您点击一下指定的屏幕边缘，即开始截取。";
            // 
            // chkCC6
            // 
            this.chkCC6.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCC6.Location = new System.Drawing.Point(236, 87);
            this.chkCC6.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkCC6.Name = "chkCC6";
            this.chkCC6.Size = new System.Drawing.Size(47, 137);
            this.chkCC6.TabIndex = 7;
            this.chkCC6.UseVisualStyleBackColor = false;
            this.chkCC6.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // chkCC4
            // 
            this.chkCC4.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCC4.Location = new System.Drawing.Point(47, 87);
            this.chkCC4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkCC4.Name = "chkCC4";
            this.chkCC4.Size = new System.Drawing.Size(47, 137);
            this.chkCC4.TabIndex = 6;
            this.chkCC4.UseVisualStyleBackColor = false;
            this.chkCC4.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // chkCC2
            // 
            this.chkCC2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCC2.Location = new System.Drawing.Point(94, 224);
            this.chkCC2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkCC2.Name = "chkCC2";
            this.chkCC2.Size = new System.Drawing.Size(142, 45);
            this.chkCC2.TabIndex = 5;
            this.chkCC2.UseVisualStyleBackColor = false;
            this.chkCC2.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // chkCC8
            // 
            this.chkCC8.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCC8.Location = new System.Drawing.Point(94, 42);
            this.chkCC8.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkCC8.Name = "chkCC8";
            this.chkCC8.Size = new System.Drawing.Size(142, 45);
            this.chkCC8.TabIndex = 4;
            this.chkCC8.UseVisualStyleBackColor = false;
            this.chkCC8.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // chkCC3
            // 
            this.chkCC3.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCC3.Location = new System.Drawing.Point(236, 224);
            this.chkCC3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkCC3.Name = "chkCC3";
            this.chkCC3.Size = new System.Drawing.Size(47, 45);
            this.chkCC3.TabIndex = 3;
            this.chkCC3.UseVisualStyleBackColor = false;
            this.chkCC3.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // chkCC1
            // 
            this.chkCC1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCC1.Location = new System.Drawing.Point(47, 224);
            this.chkCC1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkCC1.Name = "chkCC1";
            this.chkCC1.Size = new System.Drawing.Size(47, 45);
            this.chkCC1.TabIndex = 2;
            this.chkCC1.UseVisualStyleBackColor = false;
            this.chkCC1.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // chkCC9
            // 
            this.chkCC9.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCC9.Location = new System.Drawing.Point(236, 42);
            this.chkCC9.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkCC9.Name = "chkCC9";
            this.chkCC9.Size = new System.Drawing.Size(47, 45);
            this.chkCC9.TabIndex = 1;
            this.chkCC9.UseVisualStyleBackColor = false;
            this.chkCC9.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // chkCC7
            // 
            this.chkCC7.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCC7.Location = new System.Drawing.Point(47, 42);
            this.chkCC7.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkCC7.Name = "chkCC7";
            this.chkCC7.Size = new System.Drawing.Size(47, 45);
            this.chkCC7.TabIndex = 0;
            this.chkCC7.UseVisualStyleBackColor = false;
            this.chkCC7.CheckedChanged += new System.EventHandler(this.chkCC_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoDupCapture);
            this.groupBox3.Controls.Add(this.rdoDupNone);
            this.groupBox3.Location = new System.Drawing.Point(15, 375);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox3.Size = new System.Drawing.Size(426, 124);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "防止双重启动的操作";
            // 
            // rdoDupCapture
            // 
            this.rdoDupCapture.AutoSize = true;
            this.rdoDupCapture.Location = new System.Drawing.Point(29, 73);
            this.rdoDupCapture.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdoDupCapture.Name = "rdoDupCapture";
            this.rdoDupCapture.Size = new System.Drawing.Size(140, 25);
            this.rdoDupCapture.TabIndex = 1;
            this.rdoDupCapture.Text = "截取参考图";
            this.toolTip1.SetToolTip(this.rdoDupCapture, "如果您尝试重复启动SETUNA，则开始截取。");
            this.rdoDupCapture.UseVisualStyleBackColor = true;
            // 
            // rdoDupNone
            // 
            this.rdoDupNone.AutoSize = true;
            this.rdoDupNone.Checked = true;
            this.rdoDupNone.Location = new System.Drawing.Point(29, 39);
            this.rdoDupNone.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdoDupNone.Name = "rdoDupNone";
            this.rdoDupNone.Size = new System.Drawing.Size(140, 25);
            this.rdoDupNone.TabIndex = 0;
            this.rdoDupNone.TabStop = true;
            this.rdoDupNone.Text = "什么都不做";
            this.toolTip1.SetToolTip(this.rdoDupNone, "如果您尝试重复启动SETUNA，则什么都不做。");
            this.rdoDupNone.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
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
            this.groupBox4.Location = new System.Drawing.Point(15, 133);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox4.Size = new System.Drawing.Size(426, 231);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "截取时的框选范围";
            // 
            // rdoSelLineTypeDotted
            // 
            this.rdoSelLineTypeDotted.AutoSize = true;
            this.rdoSelLineTypeDotted.Location = new System.Drawing.Point(303, 81);
            this.rdoSelLineTypeDotted.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdoSelLineTypeDotted.Name = "rdoSelLineTypeDotted";
            this.rdoSelLineTypeDotted.Size = new System.Drawing.Size(77, 25);
            this.rdoSelLineTypeDotted.TabIndex = 3;
            this.rdoSelLineTypeDotted.Text = "虚线";
            this.toolTip1.SetToolTip(this.rdoSelLineTypeDotted, "设置框选范围的边框线的类型。");
            this.rdoSelLineTypeDotted.UseVisualStyleBackColor = true;
            // 
            // rdoSelLineTypeSolid
            // 
            this.rdoSelLineTypeSolid.AutoSize = true;
            this.rdoSelLineTypeSolid.Checked = true;
            this.rdoSelLineTypeSolid.Location = new System.Drawing.Point(214, 82);
            this.rdoSelLineTypeSolid.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rdoSelLineTypeSolid.Name = "rdoSelLineTypeSolid";
            this.rdoSelLineTypeSolid.Size = new System.Drawing.Size(77, 25);
            this.rdoSelLineTypeSolid.TabIndex = 2;
            this.rdoSelLineTypeSolid.TabStop = true;
            this.rdoSelLineTypeSolid.Text = "实线";
            this.toolTip1.SetToolTip(this.rdoSelLineTypeSolid, "设置框选范围的边框线的类型。");
            this.rdoSelLineTypeSolid.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(299, 170);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 21);
            this.label12.TabIndex = 7;
            this.label12.Text = "%";
            // 
            // numSelectAreaTrans
            // 
            this.numSelectAreaTrans.Location = new System.Drawing.Point(214, 166);
            this.numSelectAreaTrans.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.numSelectAreaTrans.Name = "numSelectAreaTrans";
            this.numSelectAreaTrans.Size = new System.Drawing.Size(75, 31);
            this.numSelectAreaTrans.TabIndex = 6;
            this.toolTip1.SetToolTip(this.numSelectAreaTrans, "设置框选范围填充颜色的透明度。\n选择透明度100％时可提高响应速度。");
            this.numSelectAreaTrans.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // picSelectAreaBackColor
            // 
            this.picSelectAreaBackColor.BackColor = System.Drawing.Color.AliceBlue;
            this.picSelectAreaBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSelectAreaBackColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSelectAreaBackColor.Location = new System.Drawing.Point(214, 123);
            this.picSelectAreaBackColor.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.picSelectAreaBackColor.Name = "picSelectAreaBackColor";
            this.picSelectAreaBackColor.Size = new System.Drawing.Size(55, 29);
            this.picSelectAreaBackColor.TabIndex = 10;
            this.picSelectAreaBackColor.TabStop = false;
            this.toolTip1.SetToolTip(this.picSelectAreaBackColor, "设置全面填充框选范围的颜色。\n不全面涂抹的情况设置透明度为100％。");
            this.picSelectAreaBackColor.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // picSelectAreaLineColor
            // 
            this.picSelectAreaLineColor.BackColor = System.Drawing.Color.Blue;
            this.picSelectAreaLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSelectAreaLineColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSelectAreaLineColor.Location = new System.Drawing.Point(214, 39);
            this.picSelectAreaLineColor.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.picSelectAreaLineColor.Name = "picSelectAreaLineColor";
            this.picSelectAreaLineColor.Size = new System.Drawing.Size(55, 29);
            this.picSelectAreaLineColor.TabIndex = 9;
            this.picSelectAreaLineColor.TabStop = false;
            this.toolTip1.SetToolTip(this.picSelectAreaLineColor, "指定框选范围的边框线的颜色。");
            this.picSelectAreaLineColor.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 170);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 21);
            this.label10.TabIndex = 5;
            this.label10.Text = "框选范围的透明度：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 128);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 21);
            this.label9.TabIndex = 4;
            this.label9.Text = "框选范围的颜色：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "框选线的颜色∶";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "框选线的种类∶";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.hotkeyControl1);
            this.groupBox2.Location = new System.Drawing.Point(15, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(18, 12, 5, 5);
            this.groupBox2.Size = new System.Drawing.Size(768, 109);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "快捷键设置";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(437, 45);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(141, 25);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "启用快捷键";
            this.toolTip1.SetToolTip(this.checkBox1, "要启用快捷键，请勾选。");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "快捷键：";
            // 
            // hotkeyControl1
            // 
            this.hotkeyControl1.Hotkey = System.Windows.Forms.Keys.None;
            this.hotkeyControl1.Location = new System.Drawing.Point(135, 42);
            this.hotkeyControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.hotkeyControl1.Name = "hotkeyControl1";
            this.hotkeyControl1.Size = new System.Drawing.Size(272, 33);
            this.hotkeyControl1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.hotkeyControl1, "Ctrl键，Shift键和Alt键，各个键的组合来设置截取的快捷键。\n不能使用其他程序设置的快捷键。");
            // 
            // pageScrap
            // 
            this.pageScrap.BackColor = System.Drawing.Color.White;
            this.pageScrap.Controls.Add(this.flowLayoutPanel1);
            this.pageScrap.Location = new System.Drawing.Point(4, 34);
            this.pageScrap.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pageScrap.Name = "pageScrap";
            this.pageScrap.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pageScrap.Size = new System.Drawing.Size(803, 585);
            this.pageScrap.TabIndex = 2;
            this.pageScrap.Text = "参考图设置";
            this.pageScrap.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.pnlScrapStyle);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(769, 529);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pnlScrapStyle
            // 
            this.pnlScrapStyle.Controls.Add(this.cmbWClickStyle);
            this.pnlScrapStyle.Controls.Add(this.label5);
            this.pnlScrapStyle.Controls.Add(this.cmbCreateStyle);
            this.pnlScrapStyle.Controls.Add(this.label4);
            this.pnlScrapStyle.Location = new System.Drawing.Point(5, 5);
            this.pnlScrapStyle.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pnlScrapStyle.Name = "pnlScrapStyle";
            this.pnlScrapStyle.Size = new System.Drawing.Size(747, 109);
            this.pnlScrapStyle.TabIndex = 0;
            // 
            // cmbWClickStyle
            // 
            this.cmbWClickStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWClickStyle.FormattingEnabled = true;
            this.cmbWClickStyle.Location = new System.Drawing.Point(296, 67);
            this.cmbWClickStyle.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbWClickStyle.Name = "cmbWClickStyle";
            this.cmbWClickStyle.Size = new System.Drawing.Size(335, 29);
            this.cmbWClickStyle.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmbWClickStyle, "指定双击参考图时使用的自动操作。");
            this.cmbWClickStyle.SelectionChangeCommitted += new System.EventHandler(this.cmbWClickStyle_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "双击时∶";
            // 
            // cmbCreateStyle
            // 
            this.cmbCreateStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreateStyle.FormattingEnabled = true;
            this.cmbCreateStyle.Location = new System.Drawing.Point(296, 19);
            this.cmbCreateStyle.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbCreateStyle.Name = "cmbCreateStyle";
            this.cmbCreateStyle.Size = new System.Drawing.Size(335, 29);
            this.cmbCreateStyle.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cmbCreateStyle, "您可以指定要创建参考图时使用的自动操作。");
            this.cmbCreateStyle.SelectionChangeCommitted += new System.EventHandler(this.cmbCreateStyle_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "基本自动操作：";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkScrapImageDrag);
            this.panel4.Controls.Add(this.groupBox11);
            this.panel4.Location = new System.Drawing.Point(5, 124);
            this.panel4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(747, 373);
            this.panel4.TabIndex = 0;
            // 
            // chkScrapImageDrag
            // 
            this.chkScrapImageDrag.AutoSize = true;
            this.chkScrapImageDrag.Location = new System.Drawing.Point(40, 5);
            this.chkScrapImageDrag.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkScrapImageDrag.Name = "chkScrapImageDrag";
            this.chkScrapImageDrag.Size = new System.Drawing.Size(309, 25);
            this.chkScrapImageDrag.TabIndex = 0;
            this.chkScrapImageDrag.Text = "拖动图像文件创建一个参考图";
            this.toolTip1.SetToolTip(this.chkScrapImageDrag, "拖动图像文件到参考图可作为参考图查看。");
            this.chkScrapImageDrag.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label15);
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Controls.Add(this.numMouseOverAlpha);
            this.groupBox11.Controls.Add(this.chkMouseOverAlphaChange);
            this.groupBox11.Controls.Add(this.label11);
            this.groupBox11.Controls.Add(this.label6);
            this.groupBox11.Controls.Add(this.numInactiveAlpha);
            this.groupBox11.Controls.Add(this.chkInactiveAlphaChange);
            this.groupBox11.Location = new System.Drawing.Point(5, 54);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox11.Size = new System.Drawing.Size(737, 215);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "非选择时的效果";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(459, 151);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 21);
            this.label15.TabIndex = 7;
            this.label15.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(459, 67);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 21);
            this.label13.TabIndex = 3;
            this.label13.Text = "%";
            // 
            // numMouseOverAlpha
            // 
            this.numMouseOverAlpha.Location = new System.Drawing.Point(387, 143);
            this.numMouseOverAlpha.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.numMouseOverAlpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMouseOverAlpha.Name = "numMouseOverAlpha";
            this.numMouseOverAlpha.Size = new System.Drawing.Size(71, 31);
            this.numMouseOverAlpha.TabIndex = 6;
            this.numMouseOverAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkMouseOverAlphaChange
            // 
            this.chkMouseOverAlphaChange.AutoSize = true;
            this.chkMouseOverAlphaChange.Location = new System.Drawing.Point(89, 149);
            this.chkMouseOverAlphaChange.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkMouseOverAlphaChange.Name = "chkMouseOverAlphaChange";
            this.chkMouseOverAlphaChange.Size = new System.Drawing.Size(246, 25);
            this.chkMouseOverAlphaChange.TabIndex = 5;
            this.chkMouseOverAlphaChange.Text = "改变参考图的不透明度";
            this.toolTip1.SetToolTip(this.chkMouseOverAlphaChange, "设置鼠标光标处于参考图上时参考图的透明度。\n如果响应速度很慢请关闭。");
            this.chkMouseOverAlphaChange.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 123);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 21);
            this.label11.TabIndex = 4;
            this.label11.Text = "鼠标触到时";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "鼠标没触到时";
            // 
            // numInactiveAlpha
            // 
            this.numInactiveAlpha.Location = new System.Drawing.Point(387, 61);
            this.numInactiveAlpha.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.numInactiveAlpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInactiveAlpha.Name = "numInactiveAlpha";
            this.numInactiveAlpha.Size = new System.Drawing.Size(71, 31);
            this.numInactiveAlpha.TabIndex = 2;
            this.numInactiveAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkInactiveAlphaChange
            // 
            this.chkInactiveAlphaChange.AutoSize = true;
            this.chkInactiveAlphaChange.Location = new System.Drawing.Point(89, 67);
            this.chkInactiveAlphaChange.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkInactiveAlphaChange.Name = "chkInactiveAlphaChange";
            this.chkInactiveAlphaChange.Size = new System.Drawing.Size(246, 25);
            this.chkInactiveAlphaChange.TabIndex = 1;
            this.chkInactiveAlphaChange.Text = "改变参考图的不透明度";
            this.toolTip1.SetToolTip(this.chkInactiveAlphaChange, "设置鼠标光标离开参考图上后参考图的透明度。\n如果响应速度很慢请关闭。");
            this.chkInactiveAlphaChange.UseVisualStyleBackColor = true;
            // 
            // pageStyle
            // 
            this.pageStyle.BackColor = System.Drawing.Color.White;
            this.pageStyle.Controls.Add(this.groupBox1);
            this.pageStyle.Location = new System.Drawing.Point(4, 34);
            this.pageStyle.Margin = new System.Windows.Forms.Padding(0);
            this.pageStyle.Name = "pageStyle";
            this.pageStyle.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.pageStyle.Size = new System.Drawing.Size(803, 585);
            this.pageStyle.TabIndex = 0;
            this.pageStyle.Text = "编辑自动操作";
            this.pageStyle.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listStyles);
            this.groupBox1.Controls.Add(this.listKeyItems);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnEditStyle);
            this.groupBox1.Controls.Add(this.listStyleItems);
            this.groupBox1.Controls.Add(this.btnDeleteStyle);
            this.groupBox1.Controls.Add(this.btnNewStyle);
            this.groupBox1.Location = new System.Drawing.Point(15, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(768, 537);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自动操作列表";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(412, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "复制";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCopy_Click_1);
            // 
            // listStyles
            // 
            this.listStyles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listStyles.Font = new System.Drawing.Font("宋体", 9F);
            this.listStyles.FormattingEnabled = true;
            this.listStyles.ItemDragMove = true;
            this.listStyles.ItemHeight = 40;
            this.listStyles.ItemKeyDelete = true;
            this.listStyles.ItemLine = false;
            this.listStyles.ItemLineColor = System.Drawing.Color.Gray;
            this.listStyles.LeftSpace = 2;
            this.listStyles.Location = new System.Drawing.Point(37, 86);
            this.listStyles.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listStyles.Name = "listStyles";
            this.listStyles.Size = new System.Drawing.Size(362, 404);
            this.listStyles.TabIndex = 3;
            this.listStyles.SelectedIndexChanged += new System.EventHandler(this.listStyles_SelectedIndexChanged);
            this.listStyles.DoubleClick += new System.EventHandler(this.listStyles_DoubleClick);
            // 
            // listKeyItems
            // 
            this.listKeyItems.BackColor = System.Drawing.Color.White;
            this.listKeyItems.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listKeyItems.FormattingEnabled = true;
            this.listKeyItems.ItemHeight = 21;
            this.listKeyItems.Location = new System.Drawing.Point(430, 357);
            this.listKeyItems.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listKeyItems.Name = "listKeyItems";
            this.listKeyItems.Size = new System.Drawing.Size(324, 151);
            this.listKeyItems.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 329);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "快捷键分配：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "自动操作的构成：";
            // 
            // btnEditStyle
            // 
            this.btnEditStyle.Location = new System.Drawing.Point(162, 31);
            this.btnEditStyle.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnEditStyle.Name = "btnEditStyle";
            this.btnEditStyle.Size = new System.Drawing.Size(114, 45);
            this.btnEditStyle.TabIndex = 1;
            this.btnEditStyle.Tag = " ";
            this.btnEditStyle.Text = "编辑";
            this.btnEditStyle.UseVisualStyleBackColor = true;
            this.btnEditStyle.Click += new System.EventHandler(this.btnEditStyle_Click);
            // 
            // listStyleItems
            // 
            this.listStyleItems.BackColor = System.Drawing.Color.White;
            this.listStyleItems.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listStyleItems.FormattingEnabled = true;
            this.listStyleItems.ItemHeight = 21;
            this.listStyleItems.Location = new System.Drawing.Point(430, 133);
            this.listStyleItems.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listStyleItems.Name = "listStyleItems";
            this.listStyleItems.Size = new System.Drawing.Size(324, 172);
            this.listStyleItems.TabIndex = 5;
            // 
            // btnDeleteStyle
            // 
            this.btnDeleteStyle.Location = new System.Drawing.Point(287, 31);
            this.btnDeleteStyle.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnDeleteStyle.Name = "btnDeleteStyle";
            this.btnDeleteStyle.Size = new System.Drawing.Size(114, 45);
            this.btnDeleteStyle.TabIndex = 2;
            this.btnDeleteStyle.Text = "删除";
            this.btnDeleteStyle.UseVisualStyleBackColor = true;
            this.btnDeleteStyle.Click += new System.EventHandler(this.btnDeleteStyle_Click);
            // 
            // btnNewStyle
            // 
            this.btnNewStyle.Location = new System.Drawing.Point(37, 31);
            this.btnNewStyle.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnNewStyle.Name = "btnNewStyle";
            this.btnNewStyle.Size = new System.Drawing.Size(114, 45);
            this.btnNewStyle.TabIndex = 0;
            this.btnNewStyle.Text = "新建";
            this.btnNewStyle.UseVisualStyleBackColor = true;
            this.btnNewStyle.Click += new System.EventHandler(this.btnNewStyle_Click);
            // 
            // pageScrapMenu
            // 
            this.pageScrapMenu.BackColor = System.Drawing.Color.White;
            this.pageScrapMenu.Controls.Add(this.btnScrapMenuMove);
            this.pageScrapMenu.Controls.Add(this.groupBox10);
            this.pageScrapMenu.Controls.Add(this.groupBox9);
            this.pageScrapMenu.Controls.Add(this.groupBox8);
            this.pageScrapMenu.Location = new System.Drawing.Point(4, 34);
            this.pageScrapMenu.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pageScrapMenu.Name = "pageScrapMenu";
            this.pageScrapMenu.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.pageScrapMenu.Size = new System.Drawing.Size(803, 585);
            this.pageScrapMenu.TabIndex = 3;
            this.pageScrapMenu.Text = "参考图菜单";
            this.pageScrapMenu.UseVisualStyleBackColor = true;
            // 
            // btnScrapMenuMove
            // 
            this.btnScrapMenuMove.Location = new System.Drawing.Point(355, 45);
            this.btnScrapMenuMove.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnScrapMenuMove.Name = "btnScrapMenuMove";
            this.btnScrapMenuMove.Size = new System.Drawing.Size(87, 488);
            this.btnScrapMenuMove.TabIndex = 2;
            this.btnScrapMenuMove.Text = ">>";
            this.btnScrapMenuMove.UseVisualStyleBackColor = true;
            this.btnScrapMenuMove.Click += new System.EventHandler(this.btnScrapMenuMove_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.listScrapMenuList);
            this.groupBox10.Location = new System.Drawing.Point(453, 14);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.groupBox10.Size = new System.Drawing.Size(328, 534);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "参考图菜单";
            // 
            // listScrapMenuList
            // 
            this.listScrapMenuList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listScrapMenuList.Font = new System.Drawing.Font("宋体", 9F);
            this.listScrapMenuList.FormattingEnabled = true;
            this.listScrapMenuList.IntegralHeight = false;
            this.listScrapMenuList.ItemDragMove = true;
            this.listScrapMenuList.ItemHeight = 40;
            this.listScrapMenuList.ItemKeyDelete = true;
            this.listScrapMenuList.ItemLine = false;
            this.listScrapMenuList.ItemLineColor = System.Drawing.Color.Gray;
            this.listScrapMenuList.LeftSpace = 2;
            this.listScrapMenuList.Location = new System.Drawing.Point(15, 31);
            this.listScrapMenuList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listScrapMenuList.Name = "listScrapMenuList";
            this.listScrapMenuList.Size = new System.Drawing.Size(296, 485);
            this.listScrapMenuList.TabIndex = 0;
            this.toolTip1.SetToolTip(this.listScrapMenuList, "右键单击参考图时显示的菜单结构。");
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.listScrapMenuItems);
            this.groupBox9.Location = new System.Drawing.Point(15, 355);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.groupBox9.Size = new System.Drawing.Size(331, 193);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "其他";
            // 
            // listScrapMenuItems
            // 
            this.listScrapMenuItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listScrapMenuItems.Font = new System.Drawing.Font("宋体", 9F);
            this.listScrapMenuItems.FormattingEnabled = true;
            this.listScrapMenuItems.ItemDragMove = false;
            this.listScrapMenuItems.ItemHeight = 40;
            this.listScrapMenuItems.ItemKeyDelete = false;
            this.listScrapMenuItems.ItemLine = false;
            this.listScrapMenuItems.ItemLineColor = System.Drawing.Color.Gray;
            this.listScrapMenuItems.LeftSpace = 2;
            this.listScrapMenuItems.Location = new System.Drawing.Point(15, 31);
            this.listScrapMenuItems.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listScrapMenuItems.Name = "listScrapMenuItems";
            this.listScrapMenuItems.Size = new System.Drawing.Size(298, 124);
            this.listScrapMenuItems.TabIndex = 0;
            this.listScrapMenuItems.Enter += new System.EventHandler(this.listScrapMenuItems_Enter);
            this.listScrapMenuItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listScrapMenuItems_MouseDoubleClick);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.listScrapMenuStyles);
            this.groupBox8.Location = new System.Drawing.Point(15, 14);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.groupBox8.Size = new System.Drawing.Size(331, 331);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "自动操作列表";
            // 
            // listScrapMenuStyles
            // 
            this.listScrapMenuStyles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listScrapMenuStyles.Font = new System.Drawing.Font("宋体", 9F);
            this.listScrapMenuStyles.FormattingEnabled = true;
            this.listScrapMenuStyles.ItemDragMove = false;
            this.listScrapMenuStyles.ItemHeight = 40;
            this.listScrapMenuStyles.ItemKeyDelete = false;
            this.listScrapMenuStyles.ItemLine = false;
            this.listScrapMenuStyles.ItemLineColor = System.Drawing.Color.Gray;
            this.listScrapMenuStyles.LeftSpace = 2;
            this.listScrapMenuStyles.Location = new System.Drawing.Point(15, 31);
            this.listScrapMenuStyles.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listScrapMenuStyles.Name = "listScrapMenuStyles";
            this.listScrapMenuStyles.Size = new System.Drawing.Size(298, 284);
            this.listScrapMenuStyles.TabIndex = 0;
            this.listScrapMenuStyles.Enter += new System.EventHandler(this.listScrapMenuStyles_Enter);
            this.listScrapMenuStyles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listScrapMenuStyles_MouseDoubleClick);
            // 
            // pageDPISetting
            // 
            this.pageDPISetting.BackColor = System.Drawing.Color.White;
            this.pageDPISetting.Controls.Add(this.groupBox15);
            this.pageDPISetting.Controls.Add(this.groupBox14);
            this.pageDPISetting.Location = new System.Drawing.Point(4, 34);
            this.pageDPISetting.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pageDPISetting.Name = "pageDPISetting";
            this.pageDPISetting.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.pageDPISetting.Size = new System.Drawing.Size(803, 585);
            this.pageDPISetting.TabIndex = 3;
            this.pageDPISetting.Text = "显示器DPI设置";
            this.pageDPISetting.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.Dpi4Txt);
            this.groupBox15.Controls.Add(this.label22);
            this.groupBox15.Controls.Add(this.Dpi3Txt);
            this.groupBox15.Controls.Add(this.label21);
            this.groupBox15.Controls.Add(this.Dpi2Txt);
            this.groupBox15.Controls.Add(this.label20);
            this.groupBox15.Controls.Add(this.label19);
            this.groupBox15.Controls.Add(this.Dpi1Txt);
            this.groupBox15.Controls.Add(this.label18);
            this.groupBox15.Location = new System.Drawing.Point(15, 178);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox15.Size = new System.Drawing.Size(768, 291);
            this.groupBox15.TabIndex = 12;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "DPI配置";
            // 
            // Dpi4Txt
            // 
            this.Dpi4Txt.Location = new System.Drawing.Point(252, 235);
            this.Dpi4Txt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dpi4Txt.Name = "Dpi4Txt";
            this.Dpi4Txt.Size = new System.Drawing.Size(135, 31);
            this.Dpi4Txt.TabIndex = 8;
            this.Dpi4Txt.Text = "1.0";
            this.Dpi4Txt.Validated += new System.EventHandler(this.Dpi4Txt_Validated);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(27, 239);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(207, 26);
            this.label22.TabIndex = 7;
            this.label22.Text = "第四显示器DPI：";
            // 
            // Dpi3Txt
            // 
            this.Dpi3Txt.Location = new System.Drawing.Point(252, 184);
            this.Dpi3Txt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dpi3Txt.Name = "Dpi3Txt";
            this.Dpi3Txt.Size = new System.Drawing.Size(135, 31);
            this.Dpi3Txt.TabIndex = 6;
            this.Dpi3Txt.Text = "1.0";
            this.Dpi3Txt.Validated += new System.EventHandler(this.Dpi3Txt_Validated);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(27, 188);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(207, 26);
            this.label21.TabIndex = 5;
            this.label21.Text = "第三显示器DPI：";
            // 
            // Dpi2Txt
            // 
            this.Dpi2Txt.Location = new System.Drawing.Point(252, 138);
            this.Dpi2Txt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dpi2Txt.Name = "Dpi2Txt";
            this.Dpi2Txt.Size = new System.Drawing.Size(135, 31);
            this.Dpi2Txt.TabIndex = 4;
            this.Dpi2Txt.Text = "1.0";
            this.Dpi2Txt.Validated += new System.EventHandler(this.Dpi2Txt_Validated);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(27, 142);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(207, 26);
            this.label20.TabIndex = 3;
            this.label20.Text = "第二显示器DPI：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(28, 30);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(631, 42);
            this.label19.TabIndex = 2;
            this.label19.Text = "填写说明：1.0 <= DPI数值 <= 5.0（例如缩放250%，则填写2.5）\r\n如果分不清是哪台显示器，打开Windows设置->系统->显示";
            // 
            // Dpi1Txt
            // 
            this.Dpi1Txt.Location = new System.Drawing.Point(252, 92);
            this.Dpi1Txt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dpi1Txt.Name = "Dpi1Txt";
            this.Dpi1Txt.Size = new System.Drawing.Size(135, 31);
            this.Dpi1Txt.TabIndex = 1;
            this.Dpi1Txt.Text = "1.0";
            this.Dpi1Txt.Validated += new System.EventHandler(this.Dpi1Txt_Validated);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(27, 96);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(181, 26);
            this.label18.TabIndex = 0;
            this.label18.Text = "主显示器DPI：";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label17);
            this.groupBox14.Location = new System.Drawing.Point(15, 14);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox14.Size = new System.Drawing.Size(768, 153);
            this.groupBox14.TabIndex = 11;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "说明";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label17.Location = new System.Drawing.Point(28, 37);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(547, 105);
            this.label17.TabIndex = 12;
            this.label17.Text = "由于获取其他显示器（不是主显示器）DPI需要以下条件：\r\n    1、Win10周年更新以上\r\n    2、.Net Framework 4.7以上\r\n\r\n所以直" +
    "接改成手动配置DPI\r\n";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(163)))), ((int)(((byte)(236)))));
            this.panel1.Controls.Add(this.lblMenuStyle);
            this.panel1.Controls.Add(this.lblMenuCapture);
            this.panel1.Controls.Add(this.lblMenuMenu);
            this.panel1.Controls.Add(this.lblMenuScrap);
            this.panel1.Controls.Add(this.lblMenuDPI);
            this.panel1.Controls.Add(this.lblMenuAll);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 630);
            this.panel1.TabIndex = 1;
            // 
            // lblMenuStyle
            // 
            this.lblMenuStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(215)))));
            this.lblMenuStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuStyle.ForeColor = System.Drawing.Color.White;
            this.lblMenuStyle.Location = new System.Drawing.Point(49, 123);
            this.lblMenuStyle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMenuStyle.Name = "lblMenuStyle";
            this.lblMenuStyle.Size = new System.Drawing.Size(181, 25);
            this.lblMenuStyle.TabIndex = 2;
            this.lblMenuStyle.Text = "创建自动操作";
            this.lblMenuStyle.Click += new System.EventHandler(this.lblMenuStyle_Click);
            this.lblMenuStyle.MouseEnter += new System.EventHandler(this.lblMenuStyle_MouseEnter);
            this.lblMenuStyle.MouseLeave += new System.EventHandler(this.lblMenu_Clear);
            // 
            // lblMenuCapture
            // 
            this.lblMenuCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(215)))));
            this.lblMenuCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuCapture.ForeColor = System.Drawing.Color.White;
            this.lblMenuCapture.Location = new System.Drawing.Point(22, 53);
            this.lblMenuCapture.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMenuCapture.Name = "lblMenuCapture";
            this.lblMenuCapture.Size = new System.Drawing.Size(181, 25);
            this.lblMenuCapture.TabIndex = 5;
            this.lblMenuCapture.Text = "截取设置";
            this.lblMenuCapture.Click += new System.EventHandler(this.lblMenuCapture_Click);
            this.lblMenuCapture.MouseEnter += new System.EventHandler(this.lblMenuCapture_MouseEnter);
            this.lblMenuCapture.MouseLeave += new System.EventHandler(this.lblMenu_Clear);
            // 
            // lblMenuMenu
            // 
            this.lblMenuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(215)))));
            this.lblMenuMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuMenu.ForeColor = System.Drawing.Color.White;
            this.lblMenuMenu.Location = new System.Drawing.Point(49, 157);
            this.lblMenuMenu.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMenuMenu.Name = "lblMenuMenu";
            this.lblMenuMenu.Size = new System.Drawing.Size(181, 25);
            this.lblMenuMenu.TabIndex = 3;
            this.lblMenuMenu.Text = "参考图菜单";
            this.lblMenuMenu.Click += new System.EventHandler(this.lblMenuMenu_Click);
            this.lblMenuMenu.MouseEnter += new System.EventHandler(this.lblMenuMenu_MouseEnter);
            this.lblMenuMenu.MouseLeave += new System.EventHandler(this.lblMenu_Clear);
            // 
            // lblMenuScrap
            // 
            this.lblMenuScrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(215)))));
            this.lblMenuScrap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuScrap.ForeColor = System.Drawing.Color.White;
            this.lblMenuScrap.Location = new System.Drawing.Point(22, 87);
            this.lblMenuScrap.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMenuScrap.Name = "lblMenuScrap";
            this.lblMenuScrap.Size = new System.Drawing.Size(181, 25);
            this.lblMenuScrap.TabIndex = 1;
            this.lblMenuScrap.Text = "参考图设置";
            this.lblMenuScrap.Click += new System.EventHandler(this.lblMenuScrap_Click);
            this.lblMenuScrap.MouseEnter += new System.EventHandler(this.lblMenuScrap_MouseEnter);
            this.lblMenuScrap.MouseLeave += new System.EventHandler(this.lblMenu_Clear);
            // 
            // lblMenuDPI
            // 
            this.lblMenuDPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(215)))));
            this.lblMenuDPI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuDPI.ForeColor = System.Drawing.Color.White;
            this.lblMenuDPI.Location = new System.Drawing.Point(22, 191);
            this.lblMenuDPI.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMenuDPI.Name = "lblMenuDPI";
            this.lblMenuDPI.Size = new System.Drawing.Size(181, 25);
            this.lblMenuDPI.TabIndex = 4;
            this.lblMenuDPI.Text = "显示器DPI设置";
            this.lblMenuDPI.Click += new System.EventHandler(this.lblMenuDPI_Click);
            this.lblMenuDPI.MouseEnter += new System.EventHandler(this.lblMenuDPI_MouseEnter);
            this.lblMenuDPI.MouseLeave += new System.EventHandler(this.lblMenu_Clear);
            // 
            // lblMenuAll
            // 
            this.lblMenuAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(132)))), ((int)(((byte)(215)))));
            this.lblMenuAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMenuAll.ForeColor = System.Drawing.Color.White;
            this.lblMenuAll.Location = new System.Drawing.Point(22, 17);
            this.lblMenuAll.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMenuAll.Name = "lblMenuAll";
            this.lblMenuAll.Size = new System.Drawing.Size(181, 26);
            this.lblMenuAll.TabIndex = 0;
            this.lblMenuAll.Text = "常规";
            this.lblMenuAll.Click += new System.EventHandler(this.lblMenuAll_Click);
            this.lblMenuAll.MouseEnter += new System.EventHandler(this.lblMenuAll_MouseEnter);
            this.lblMenuAll.MouseLeave += new System.EventHandler(this.lblMenu_Clear);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 630);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(547, 39);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(5);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(162, 25);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "截图始终置顶";
            this.toolTip1.SetToolTip(this.checkBox3, "截图会一直保持置顶，如果不需要始终置顶，单击任务栏图标也会置顶一次截图");
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1052, 700);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选项";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.detailPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.pageAll.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDustBox)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.pageCapture.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectAreaTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectAreaBackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectAreaLineColor)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.numMouseOverAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInactiveAlpha)).EndInit();
            this.pageStyle.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pageScrapMenu.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.pageDPISetting.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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

        private void lblMenuDPI_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.pageDPISetting;
        }

        private void lblMenuDPI_MouseEnter(object sender, EventArgs e)
        {
            this.lblComment.Text = "设置多台不同DPI的显示器的参数值。";
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
            ListBox box = (ListBox)sender;
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
                PictureBox box = (PictureBox)sender;
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
            this.hotkeyControl1.Hotkey = (Keys)this._so.ScrapHotKey;
            this.checkBox1.Checked = this._so.ScrapHotKeyEnable;
            this.checkBox2.Checked = AutoStartup.Check();
            this.checkBox3.Checked = this._so.alwaysTopMost;
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

            InitDpiValue();
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
                CStyle selectedItem = (CStyle)this.listStyles.SelectedItem;
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
            CStyle style = new CStyle
            {
                StyleID = 0,
                StyleName = ""
            };
            list.BeginUpdate();
            list.Items.Clear();
            for (int i = 0; i < this.listStyles.Items.Count; i++)
            {
                CStyle item = (CStyle)this.listStyles.Items[i];
                list.Items.Add(item);
            }
            list.EndUpdate();
        }

        private void SetStyleList_Scrap(ComboBox combo, int defaultid)
        {
            CStyle item = new CStyle
            {
                StyleID = 0,
                StyleName = ""
            };
            combo.BeginUpdate();
            combo.Items.Clear();
            combo.Items.Add(item);
            for (int i = 0; i < this.listStyles.Items.Count; i++)
            {
                CStyle style2 = (CStyle)this.listStyles.Items[i];
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
            this.lblMenuDPI.Font = new Font(this.lblMenuDPI.Font, FontStyle.Regular);
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
            if (this.tabControl1.SelectedTab == this.pageDPISetting)
            {
                this.lblMenuDPI.Font = new Font(this.lblMenuDPI.Font, FontStyle.Bold);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                base.SuspendLayout();
                TabPage tag = (TabPage)e.Node.Tag;
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
            this._so.ScrapHotKey = (int)this.hotkeyControl1.Hotkey;
            this._so.ScrapHotKeyEnable = this.checkBox1.Checked;
            AutoStartup.Set(this.checkBox2.Checked);
            this._so.alwaysTopMost = this.checkBox3.Checked;
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
            this._so.Setuna.SelectAreaTransparent = (int)this.numSelectAreaTrans.Value;
            this._so.Setuna.DustBoxEnable = this.chkDustBox.Checked;
            this._so.Setuna.DustBoxCapacity = (ushort)this.numDustBox.Value;
            this._so.Scrap.CreateStyleID = this._createStyleId;
            this._so.Scrap.WClickStyleID = this._wclickStyleId;
            this._so.Scrap.ImageDrag = this.chkScrapImageDrag.Checked;
            this._so.Scrap.InactiveAlphaChange = this.chkInactiveAlphaChange.Checked;
            this._so.Scrap.InactiveAlphaValue = (sbyte)this.numInactiveAlpha.Value;
            this._so.Scrap.MouseOverAlphaChange = this.chkMouseOverAlphaChange.Checked;
            this._so.Scrap.MouseOverAlphaValue = (sbyte)this.numMouseOverAlpha.Value;
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
                this._so.Styles.Add((CStyle)this.listStyles.Items[i]);
            }
            List<int> list = new List<int>();
            foreach (CStyle style in this.listScrapMenuList.Items)
            {
                list.Add(style.StyleID);
            }
            this._so.Scrap.SubMenuStyles = list;

            try
            {
                _so.dpi1 = float.Parse(Dpi1Txt.Text);
                _so.dpi2 = float.Parse(Dpi2Txt.Text);
                _so.dpi3 = float.Parse(Dpi3Txt.Text);
                _so.dpi4 = float.Parse(Dpi4Txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存DPI配置失败：\n" + ex.ToString());
            }
        }

        public SetunaOption Option =>
            this._so;

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            e.Link.Visited = true;
            System.Diagnostics.Process.Start("http://www.clearunit.com/clearup/setuna2");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            e.Link.Visited = true;
            System.Diagnostics.Process.Start("https://github.com/tylearymf/SETUNA2");
        }

        private void Dpi1Txt_Validated(object sender, EventArgs e)
        {
            ValidateDPIText(Dpi1Txt, _so.dpi1);
        }

        private void Dpi2Txt_Validated(object sender, EventArgs e)
        {
            ValidateDPIText(Dpi2Txt, _so.dpi2);
        }

        private void Dpi3Txt_Validated(object sender, EventArgs e)
        {
            ValidateDPIText(Dpi3Txt, _so.dpi3);
        }

        private void Dpi4Txt_Validated(object sender, EventArgs e)
        {
            ValidateDPIText(Dpi4Txt, _so.dpi4);
        }

        void ValidateDPIText(TextBox pTextBox, float pDefaultValue)
        {
            var tDpi = pDefaultValue;
            if (!float.TryParse(pTextBox.Text, out tDpi))
            {
                tDpi = pDefaultValue;
                MessageBox.Show("参数类型错误！");
            }

            if (tDpi < 1.0 || tDpi > 5.0)
            {
                MessageBox.Show("参数超出范围");
            }

            pTextBox.Text = tDpi.ToString("F2");
        }

        void InitDpiValue()
        {
            var tDpiTxts = new TextBox[] { Dpi1Txt, Dpi2Txt, Dpi3Txt, Dpi4Txt };
            var tDpiValues = new float[] { _so.dpi1, _so.dpi2, _so.dpi3, _so.dpi4 };
            for (int i = 0; i < tDpiTxts.Length; i++)
            {
                tDpiTxts[i].Text = tDpiValues[i].ToString("F2");
            }

            var tIndex = Screen.AllScreens.Length;
            for (; tIndex < tDpiTxts.Length; tIndex++)
            {
                tDpiTxts[tIndex].ReadOnly = true;
            }
        }

        static public implicit operator bool(OptionForm pForm)
        {
            return pForm != null && !pForm.IsDisposed;
        }
    }
}

