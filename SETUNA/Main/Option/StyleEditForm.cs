namespace SETUNA.Main.Option
{
    using SETUNA.Main;
    using SETUNA.Main.KeyItems;
    using SETUNA.Main.Style;
    using SETUNA.Main.StyleItems;
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Image = System.Drawing.Image;
    using SETUNA.Main.Other;

    public class StyleEditForm : Form
    {
        protected KeyItemBook _keybook;
        protected CStyle _trgStyle;
        private Button btnCancel;
        private Button btnInsert;
        private Button btnItemDelete;
        private Button btnItemDown;
        private Button btnItemUp;
        private Button btnKeyDelete;
        private Button btnKeyEntry;
        private Button btnOk;
        private Keys cmKey;
        private IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private HotkeyControl hotkey;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private StyleItemListBox listAllStyleItem;
        private ListBox listKeys;
        private StyleItemListBox listStyleItem;
        private Panel panel2;
        private Panel panel3;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private TextBox txtStyleName;
        private LayerInfo mLayerInfo;

        public StyleEditForm(CStyle trgStyle, KeyItemBook keybook)
        {
            this.InitializeComponent();
            base.ResizeRedraw = true;
            this._trgStyle = trgStyle;
            this._keybook = keybook;
            this.cmKey = Keys.None;
            if (this._trgStyle == null)
            {
                this._trgStyle = new CStyle();
            }
            this.txtStyleName.Text = this._trgStyle.GetName();
            this.RefreshStyleItemList();
            this.RefreshAllStyleItemList();
            this.RefreshKeyItemList();
            this.txtStyleName_TextChanged(this.txtStyleName, new EventArgs());
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.InsertStyleItem();
        }

        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            if (this.listStyleItem.SelectedItem != null)
            {
                int selectedIndex = this.listStyleItem.SelectedIndex;
                this.listStyleItem.Items.Remove(this.listStyleItem.SelectedItem);
                if (selectedIndex <= (this.listStyleItem.Items.Count - 1))
                {
                    this.listStyleItem.SelectedIndex = selectedIndex;
                }
                else
                {
                    this.listStyleItem.SelectedIndex = this.listStyleItem.Items.Count - 1;
                }
            }
        }

        private void btnItemDown_Click(object sender, EventArgs e)
        {
            if ((this.listStyleItem.SelectedItem != null) && ((this.listStyleItem.SelectedIndex + 1) < this.listStyleItem.Items.Count))
            {
                int selectedIndex = this.listStyleItem.SelectedIndex;
                CStyleItem selectedItem = (CStyleItem) this.listStyleItem.SelectedItem;
                this.listStyleItem.Items[selectedIndex] = this.listStyleItem.Items[selectedIndex + 1];
                this.listStyleItem.Items[selectedIndex + 1] = selectedItem;
                this.listStyleItem.SelectedIndex = selectedIndex + 1;
            }
        }

        private void btnItemUp_Click(object sender, EventArgs e)
        {
            if ((this.listStyleItem.SelectedItem != null) && (this.listStyleItem.SelectedIndex > 0))
            {
                int selectedIndex = this.listStyleItem.SelectedIndex;
                CStyleItem selectedItem = (CStyleItem) this.listStyleItem.SelectedItem;
                this.listStyleItem.Items[selectedIndex] = this.listStyleItem.Items[selectedIndex - 1];
                this.listStyleItem.Items[selectedIndex - 1] = selectedItem;
                this.listStyleItem.SelectedIndex = selectedIndex - 1;
            }
        }

        private void btnKeyDelete_Click(object sender, EventArgs e)
        {
            if (this.listKeys.SelectedIndex >= 0)
            {
                this.listKeys.Items.RemoveAt(this.listKeys.SelectedIndex);
            }
        }

        private void btnKeyEntry_Click(object sender, EventArgs e)
        {
            if (this.hotkey.Hotkey != Keys.None)
            {
                KeyItem item = new KeyItem(this.hotkey.Hotkey);
                this.listKeys.Items.Add(item);
                this.toolTip1.Hide(this.label5);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.txtStyleName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入自动操作名。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtStyleName.Focus();
            }
            else
            {
                this.WriteValue();
                base.DialogResult = DialogResult.OK;
                base.Close();
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

        private void hotkey_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void hotkey_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void hotkey_KeyUp(object sender, KeyEventArgs e)
        {
            this.toolTip1.Active = false;
            if (this.cmKey != e.KeyData)
            {
                this.cmKey = e.KeyData;
                Keys hotkey = this.hotkey.Hotkey;
                if (hotkey != Keys.None)
                {
                    KeyItem item = this._keybook.FindKeyItem(hotkey);
                    if (item != null)
                    {
                        string text = "「登记」，然后按目前的分配方式。";
                        this.hotkey.PointToScreen(new Point(0, 0));
                        this.toolTip1.Active = true;
                        this.toolTip1.ToolTipTitle = "「" + item.ParentStyle.StyleName + "」被分配。";
                        this.toolTip1.Show(text, this.label5);
                    }
                }
            }
        }

        private void hotkey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void hotkey_Validated(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStyleName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKeyDelete = new System.Windows.Forms.Button();
            this.hotkey = new SETUNA.Main.HotkeyControl();
            this.listKeys = new System.Windows.Forms.ListBox();
            this.btnKeyEntry = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listStyleItem = new SETUNA.Main.StyleItemListBox();
            this.listAllStyleItem = new SETUNA.Main.StyleItemListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnItemDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnItemDown = new System.Windows.Forms.Button();
            this.btnItemUp = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(2, 682);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "自动操作名∶";
            // 
            // txtStyleName
            // 
            this.txtStyleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.txtStyleName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStyleName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtStyleName.Location = new System.Drawing.Point(7, 713);
            this.txtStyleName.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtStyleName.Name = "txtStyleName";
            this.txtStyleName.Size = new System.Drawing.Size(445, 42);
            this.txtStyleName.TabIndex = 1;
            this.toolTip2.SetToolTip(this.txtStyleName, "您可以对具体自动操作命名。");
            this.txtStyleName.TextChanged += new System.EventHandler(this.txtStyleName_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "aaa";
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.txtStyleName);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1351, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 857);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnKeyDelete);
            this.groupBox1.Controls.Add(this.hotkey);
            this.groupBox1.Controls.Add(this.listKeys);
            this.groupBox1.Controls.Add(this.btnKeyEntry);
            this.groupBox1.Location = new System.Drawing.Point(7, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.groupBox1.Size = new System.Drawing.Size(450, 477);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指定快捷键";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 184);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 27);
            this.label5.TabIndex = 3;
            this.label5.Text = "快捷键分配：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "快捷键：";
            // 
            // btnKeyDelete
            // 
            this.btnKeyDelete.Location = new System.Drawing.Point(310, 403);
            this.btnKeyDelete.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnKeyDelete.Name = "btnKeyDelete";
            this.btnKeyDelete.Size = new System.Drawing.Size(112, 54);
            this.btnKeyDelete.TabIndex = 5;
            this.btnKeyDelete.Text = "删除";
            this.btnKeyDelete.UseVisualStyleBackColor = true;
            this.btnKeyDelete.Click += new System.EventHandler(this.btnKeyDelete_Click);
            // 
            // hotkey
            // 
            this.hotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.hotkey.Location = new System.Drawing.Point(28, 90);
            this.hotkey.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.hotkey.Name = "hotkey";
            this.hotkey.Size = new System.Drawing.Size(394, 43);
            this.hotkey.TabIndex = 1;
            this.toolTip2.SetToolTip(this.hotkey, "创建应用自动操作的快捷键。");
            this.hotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.hotkey_KeyUp);
            // 
            // listKeys
            // 
            this.listKeys.FormattingEnabled = true;
            this.listKeys.IntegralHeight = false;
            this.listKeys.ItemHeight = 27;
            this.listKeys.Location = new System.Drawing.Point(28, 223);
            this.listKeys.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.listKeys.Name = "listKeys";
            this.listKeys.Size = new System.Drawing.Size(389, 170);
            this.listKeys.TabIndex = 4;
            this.toolTip2.SetToolTip(this.listKeys, "选择参考图，如果点击分配的快捷键则应用自动操作。");
            // 
            // btnKeyEntry
            // 
            this.btnKeyEntry.Location = new System.Drawing.Point(310, 135);
            this.btnKeyEntry.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnKeyEntry.Name = "btnKeyEntry";
            this.btnKeyEntry.Size = new System.Drawing.Size(112, 54);
            this.btnKeyEntry.TabIndex = 2;
            this.btnKeyEntry.Text = "登记";
            this.btnKeyEntry.UseVisualStyleBackColor = true;
            this.btnKeyEntry.Click += new System.EventHandler(this.btnKeyEntry_Click);
            this.btnKeyEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hotkey_KeyPress);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(7, 774);
            this.btnOk.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(240, 63);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(261, 774);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(196, 63);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1351, 857);
            this.panel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listStyleItem);
            this.groupBox2.Controls.Add(this.listAllStyleItem);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnItemDelete);
            this.groupBox2.Controls.Add(this.btnInsert);
            this.groupBox2.Controls.Add(this.btnItemDown);
            this.groupBox2.Controls.Add(this.btnItemUp);
            this.groupBox2.Location = new System.Drawing.Point(28, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(14, 14, 14, 14);
            this.groupBox2.Size = new System.Drawing.Size(1300, 814);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "自动操作的装配";
            // 
            // listStyleItem
            // 
            this.listStyleItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listStyleItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listStyleItem.Font = new System.Drawing.Font("黑体", 10F);
            this.listStyleItem.FormattingEnabled = true;
            this.listStyleItem.HelpFont = new System.Drawing.Font("黑体", 8F);
            this.listStyleItem.HelpForeColor = System.Drawing.Color.SteelBlue;
            this.listStyleItem.IntegralHeight = false;
            this.listStyleItem.ItemDragMove = true;
            this.listStyleItem.ItemHeight = 39;
            this.listStyleItem.ItemKeyDelete = true;
            this.listStyleItem.ItemLine = true;
            this.listStyleItem.ItemLineColor = System.Drawing.Color.LightSteelBlue;
            this.listStyleItem.Items.AddRange(new object[] {
            "第1项",
            "第2项",
            "第3项"});
            this.listStyleItem.LeftSpace = 34;
            this.listStyleItem.Location = new System.Drawing.Point(691, 90);
            this.listStyleItem.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.listStyleItem.Name = "listStyleItem";
            this.listStyleItem.Size = new System.Drawing.Size(578, 686);
            this.listStyleItem.TabIndex = 4;
            this.listStyleItem.TerminateEnd = true;
            this.toolTip2.SetToolTip(this.listStyleItem, "自上而下依次应用自动操作项目。");
            this.listStyleItem.Click += new System.EventHandler(this.listAllStyleItem_Click);
            this.listStyleItem.DoubleClick += new System.EventHandler(this.listStyleItem_DoubleClick);
            // 
            // listAllStyleItem
            // 
            this.listAllStyleItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listAllStyleItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listAllStyleItem.Font = new System.Drawing.Font("黑体", 10F);
            this.listAllStyleItem.FormattingEnabled = true;
            this.listAllStyleItem.HelpFont = new System.Drawing.Font("黑体", 8F);
            this.listAllStyleItem.HelpForeColor = System.Drawing.Color.SteelBlue;
            this.listAllStyleItem.IntegralHeight = false;
            this.listAllStyleItem.ItemDragMove = false;
            this.listAllStyleItem.ItemHeight = 39;
            this.listAllStyleItem.ItemKeyDelete = false;
            this.listAllStyleItem.ItemLine = true;
            this.listAllStyleItem.ItemLineColor = System.Drawing.Color.LightSteelBlue;
            this.listAllStyleItem.Items.AddRange(new object[] {
            "第1项",
            "第2项",
            "第3项"});
            this.listAllStyleItem.LeftSpace = 34;
            this.listAllStyleItem.Location = new System.Drawing.Point(21, 90);
            this.listAllStyleItem.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.listAllStyleItem.Name = "listAllStyleItem";
            this.listAllStyleItem.ScrollAlwaysVisible = true;
            this.listAllStyleItem.Size = new System.Drawing.Size(578, 686);
            this.listAllStyleItem.TabIndex = 1;
            this.listAllStyleItem.TerminateEnd = false;
            this.listAllStyleItem.Click += new System.EventHandler(this.listAllStyleItem_Click);
            this.listAllStyleItem.DoubleClick += new System.EventHandler(this.listAllStyleItem_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(686, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "登记方式：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "自动操作列表：";
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemDelete.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnItemDelete.Image = global::Properties.Resources.Close;
            this.btnItemDelete.Location = new System.Drawing.Point(1206, 32);
            this.btnItemDelete.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Size = new System.Drawing.Size(68, 52);
            this.btnItemDelete.TabIndex = 7;
            this.toolTip2.SetToolTip(this.btnItemDelete, "删除选定的项目。");
            this.btnItemDelete.UseVisualStyleBackColor = true;
            this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsert.Location = new System.Drawing.Point(618, 115);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(58, 644);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = ">>";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnItemDown
            // 
            this.btnItemDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemDown.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnItemDown.Image = global::Properties.Resources.ArrowDown;
            this.btnItemDown.Location = new System.Drawing.Point(1064, 32);
            this.btnItemDown.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.Size = new System.Drawing.Size(68, 52);
            this.btnItemDown.TabIndex = 5;
            this.toolTip2.SetToolTip(this.btnItemDown, "更改选定项目的顺序。");
            this.btnItemDown.UseVisualStyleBackColor = true;
            this.btnItemDown.Click += new System.EventHandler(this.btnItemDown_Click);
            // 
            // btnItemUp
            // 
            this.btnItemUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemUp.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnItemUp.Image = global::Properties.Resources.ArrowUp;
            this.btnItemUp.Location = new System.Drawing.Point(1129, 32);
            this.btnItemUp.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.Size = new System.Drawing.Size(68, 52);
            this.btnItemUp.TabIndex = 6;
            this.toolTip2.SetToolTip(this.btnItemUp, "更改选定项目的顺序。");
            this.btnItemUp.UseVisualStyleBackColor = true;
            this.btnItemUp.Click += new System.EventHandler(this.btnItemUp_Click);
            // 
            // StyleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1827, 857);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1577, 835);
            this.Name = "StyleEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StyleEditForm";
            this.Shown += new System.EventHandler(this.StyleEditForm_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InsertStyleItem()
        {
            if (this.listAllStyleItem.SelectedItem != null)
            {
                CStyleItem item = (CStyleItem) ((CStyleItem) this.listAllStyleItem.SelectedItem).Clone();
                if (item.IsSetting)
                {
                    item.StyleItemSetting();
                }
                if (this.listStyleItem.SelectedIndex == -1)
                {
                    this.listStyleItem.Items.Add(item);
                    this.listStyleItem.SelectedIndex = this.listStyleItem.Items.Count - 1;
                }
                else
                {
                    this.listStyleItem.Items.Insert(this.listStyleItem.SelectedIndex + 1, item);
                    this.listStyleItem.SelectedIndex++;
                }
            }
        }

        private void listAllStyleItem_Click(object sender, EventArgs e)
        {
            SetunaListBox box1 = (SetunaListBox) sender;
        }

        private void listAllStyleItem_DoubleClick(object sender, EventArgs e)
        {
            ListBox box = (ListBox) sender;
            if (box.SelectedItem != null)
            {
                this.InsertStyleItem();
            }
        }

        private void listStyleItem_DoubleClick(object sender, EventArgs e)
        {
            if (this.listStyleItem.SelectedItem != null)
            {
                ((CStyleItem) this.listStyleItem.SelectedItem).StyleItemSetting();
            }
        }

        private void RefreshAllStyleItemList()
        {
            CStyleItem[] allStyleItems = StyleItemDictionary.GetAllStyleItems();
            this.listAllStyleItem.BeginUpdate();
            this.listAllStyleItem.Items.Clear();
            for (int i = 0; i < allStyleItems.Length; i++)
            {
                this.listAllStyleItem.Items.Add(allStyleItems[i]);
            }
            this.listAllStyleItem.EndUpdate();
        }

        private void RefreshKeyItemList()
        {
            this.listKeys.Items.Clear();
            for (int i = 0; i < this._trgStyle.KeyItems.Length; i++)
            {
                this.listKeys.Items.Add(this._trgStyle.KeyItems[i]);
            }
        }

        private void RefreshStyleItemList()
        {
            int selectedIndex = this.listStyleItem.SelectedIndex;
            this.listStyleItem.Items.Clear();
            for (int i = 0; i < this._trgStyle.Items.Length; i++)
            {
                this.listStyleItem.Items.Add(this._trgStyle.Items[i]);
            }
            this.listStyleItem.SelectedIndex = selectedIndex;
        }

        private void StyleEditForm_Shown(object sender, EventArgs e)
        {
            this.txtStyleName.Focus();
        }

        private void txtStyleName_TextChanged(object sender, EventArgs e)
        {
            this.btnOk.Enabled = this.txtStyleName.TextLength > 0;
        }

        private void WriteValue()
        {
            this._trgStyle.StyleName = this.txtStyleName.Text.Trim();
            this._trgStyle.ClearStyle();
            for (int i = 0; i < this.listStyleItem.Items.Count; i++)
            {
                this._trgStyle.AddStyle((CStyleItem) this.listStyleItem.Items[i]);
            }
            this._trgStyle.ClearKey();
            for (int j = 0; j < this.listKeys.Items.Count; j++)
            {
                Keys key = (Keys) ((KeyItem) this.listKeys.Items[j])._key;
                KeyItem item = this._keybook.FindKeyItem(key);
                if (item != null)
                {
                    item.Deparent();
                }
                this._trgStyle.AddKeyItem(key);
            }
        }

        public CStyle Style =>
            this._trgStyle;
    }
}

