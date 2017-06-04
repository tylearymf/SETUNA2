namespace SETUNA.Main.Option
{
    using SETUNA.Main;
    using SETUNA.Main.KeyItems;
    using SETUNA.Main.Style;
    using SETUNA.Main.StyleItems;
    using SETUNA.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

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
            this.components = new Container();
            this.label1 = new Label();
            this.txtStyleName = new TextBox();
            this.toolTip1 = new ToolTip(this.components);
            this.panel2 = new Panel();
            this.groupBox1 = new GroupBox();
            this.label5 = new Label();
            this.label4 = new Label();
            this.btnKeyDelete = new Button();
            this.hotkey = new HotkeyControl();
            this.listKeys = new ListBox();
            this.btnKeyEntry = new Button();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.panel3 = new Panel();
            this.groupBox2 = new GroupBox();
            this.listStyleItem = new StyleItemListBox();
            this.listAllStyleItem = new StyleItemListBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.btnItemDelete = new Button();
            this.btnInsert = new Button();
            this.btnItemDown = new Button();
            this.btnItemUp = new Button();
            this.toolTip2 = new ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, 0x80);
            this.label1.ForeColor = SystemColors.ControlText;
            this.label1.Location = new Point(1, 0x12f);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3d, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "自动操作名∶";
            this.txtStyleName.BackColor = Color.FromArgb(0xce, 230, 0xf7);
            this.txtStyleName.Font = new Font("宋体", 10f, FontStyle.Regular, GraphicsUnit.Point, 0x80);
            this.txtStyleName.ImeMode = ImeMode.On;
            this.txtStyleName.Location = new Point(3, 0x13d);
            this.txtStyleName.Name = "txtStyleName";
            this.txtStyleName.Size = new Size(0xc1, 0x15);
            this.txtStyleName.TabIndex = 1;
            this.toolTip2.SetToolTip(this.txtStyleName, "您可以对具体自动操作命名。");
            this.txtStyleName.TextChanged += new EventHandler(this.txtStyleName_TextChanged);
            this.toolTip1.Active = false;
            this.toolTip1.AutoPopDelay = 0x1388;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "aaa";
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.txtStyleName);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = DockStyle.Right;
            this.panel2.Location = new Point(0x243, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0xcc, 0x17d);
            this.panel2.TabIndex = 2;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnKeyDelete);
            this.groupBox1.Controls.Add(this.hotkey);
            this.groupBox1.Controls.Add(this.listKeys);
            this.groupBox1.Controls.Add(this.btnKeyEntry);
            this.groupBox1.Location = new Point(3, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xc1, 0xd4);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指定快捷键";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(10, 0x52);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x44, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "快捷键分配：";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(10, 0x17);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x1b, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "快捷键：";
            this.btnKeyDelete.Location = new Point(0x85, 0xb3);
            this.btnKeyDelete.Name = "btnKeyDelete";
            this.btnKeyDelete.Size = new Size(0x30, 0x18);
            this.btnKeyDelete.TabIndex = 5;
            this.btnKeyDelete.Text = "删除";
            this.btnKeyDelete.UseVisualStyleBackColor = true;
            this.btnKeyDelete.Click += new EventHandler(this.btnKeyDelete_Click);
            this.hotkey.Hotkey = Keys.None;
            this.hotkey.Location = new Point(12, 40);
            this.hotkey.Name = "hotkey";
            this.hotkey.Size = new Size(0xa9, 0x13);
            this.hotkey.TabIndex = 1;
            this.toolTip2.SetToolTip(this.hotkey, "创建应用自动操作的快捷键。");
            this.hotkey.KeyUp += new KeyEventHandler(this.hotkey_KeyUp);
            this.listKeys.FormattingEnabled = true;
            this.listKeys.IntegralHeight = false;
            this.listKeys.ItemHeight = 12;
            this.listKeys.Location = new Point(12, 0x63);
            this.listKeys.Name = "listKeys";
            this.listKeys.Size = new Size(0xa9, 0x4e);
            this.listKeys.TabIndex = 4;
            this.toolTip2.SetToolTip(this.listKeys, "选择参考图，如果点击分配的快捷键则应用自动操作。");
            this.btnKeyEntry.Location = new Point(0x85, 60);
            this.btnKeyEntry.Name = "btnKeyEntry";
            this.btnKeyEntry.Size = new Size(0x30, 0x18);
            this.btnKeyEntry.TabIndex = 2;
            this.btnKeyEntry.Text = "登记";
            this.btnKeyEntry.UseVisualStyleBackColor = true;
            this.btnKeyEntry.Click += new EventHandler(this.btnKeyEntry_Click);
            this.btnKeyEntry.KeyPress += new KeyPressEventHandler(this.hotkey_KeyPress);
            this.btnOk.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnOk.Location = new Point(3, 0x158);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(0x67, 0x1c);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.btnCancel.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x70, 0x158);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x54, 0x1c);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = DockStyle.Fill;
            this.panel3.Location = new Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x243, 0x17d);
            this.panel3.TabIndex = 1;
            this.groupBox2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.listStyleItem);
            this.groupBox2.Controls.Add(this.listAllStyleItem);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnItemDelete);
            this.groupBox2.Controls.Add(this.btnInsert);
            this.groupBox2.Controls.Add(this.btnItemDown);
            this.groupBox2.Controls.Add(this.btnItemUp);
            this.groupBox2.Location = new Point(12, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new Padding(6);
            this.groupBox2.Size = new Size(0x22d, 0x16a);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "自动操作的装配";
            this.listStyleItem.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.listStyleItem.DrawMode = DrawMode.OwnerDrawFixed;
            this.listStyleItem.Font = new Font("黑体", 10f);
            this.listStyleItem.FormattingEnabled = true;
            this.listStyleItem.HelpFont = new Font("黑体", 8f);
            this.listStyleItem.HelpForeColor = Color.SteelBlue;
            this.listStyleItem.IntegralHeight = false;
            this.listStyleItem.ItemDragMove = true;
            this.listStyleItem.ItemHeight = 0x27;
            this.listStyleItem.ItemKeyDelete = true;
            this.listStyleItem.ItemLine = true;
            this.listStyleItem.ItemLineColor = Color.LightSteelBlue;
            this.listStyleItem.Items.AddRange(new object[] { "第1项", "第2项", "第3项" });
            this.listStyleItem.LeftSpace = 0x22;
            this.listStyleItem.Location = new Point(0x128, 40);
            this.listStyleItem.Name = "listStyleItem";
            this.listStyleItem.Size = new Size(250, 0x133);
            this.listStyleItem.TabIndex = 4;
            this.listStyleItem.TerminateEnd = true;
            this.toolTip2.SetToolTip(this.listStyleItem, "自上而下依次应用自动操作项目。");
            this.listStyleItem.DoubleClick += new EventHandler(this.listStyleItem_DoubleClick);
            this.listStyleItem.Click += new EventHandler(this.listAllStyleItem_Click);
            this.listAllStyleItem.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.listAllStyleItem.DrawMode = DrawMode.OwnerDrawFixed;
            this.listAllStyleItem.Font = new Font("黑体", 10f);
            this.listAllStyleItem.FormattingEnabled = true;
            this.listAllStyleItem.HelpFont = new Font("黑体", 8f);
            this.listAllStyleItem.HelpForeColor = Color.SteelBlue;
            this.listAllStyleItem.IntegralHeight = false;
            this.listAllStyleItem.ItemDragMove = false;
            this.listAllStyleItem.ItemHeight = 0x27;
            this.listAllStyleItem.ItemKeyDelete = false;
            this.listAllStyleItem.ItemLine = true;
            this.listAllStyleItem.ItemLineColor = Color.LightSteelBlue;
            this.listAllStyleItem.Items.AddRange(new object[] { "第1项", "第2项", "第3项" });
            this.listAllStyleItem.LeftSpace = 0x22;
            this.listAllStyleItem.Location = new Point(9, 40);
            this.listAllStyleItem.Name = "listAllStyleItem";
            this.listAllStyleItem.ScrollAlwaysVisible = true;
            this.listAllStyleItem.Size = new Size(250, 0x133);
            this.listAllStyleItem.TabIndex = 1;
            this.listAllStyleItem.TerminateEnd = false;
            this.listAllStyleItem.DoubleClick += new EventHandler(this.listAllStyleItem_DoubleClick);
            this.listAllStyleItem.Click += new EventHandler(this.listAllStyleItem_Click);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x126, 0x19);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x55, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "登记方式：";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(9, 0x19);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x43, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "自动操作列表：";
            this.btnItemDelete.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnItemDelete.Font = new Font("宋体", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0x80);
            this.btnItemDelete.Image = Resources.Close;
            this.btnItemDelete.Location = new Point(0x205, 14);
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Size = new Size(0x1d, 0x17);
            this.btnItemDelete.TabIndex = 7;
            this.toolTip2.SetToolTip(this.btnItemDelete, "删除选定的项目。");
            this.btnItemDelete.UseVisualStyleBackColor = true;
            this.btnItemDelete.Click += new EventHandler(this.btnItemDelete_Click);
            this.btnInsert.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.btnInsert.Location = new Point(0x109, 0x33);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new Size(0x19, 0x11e);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = ">>";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new EventHandler(this.btnInsert_Click);
            this.btnItemDown.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnItemDown.Font = new Font("宋体", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0x80);
            this.btnItemDown.Image = Resources.ArrowDown;
            this.btnItemDown.Location = new Point(0x1c8, 14);
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.Size = new Size(0x1d, 0x17);
            this.btnItemDown.TabIndex = 5;
            this.toolTip2.SetToolTip(this.btnItemDown, "更改选定项目的顺序。");
            this.btnItemDown.UseVisualStyleBackColor = true;
            this.btnItemDown.Click += new EventHandler(this.btnItemDown_Click);
            this.btnItemUp.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btnItemUp.Font = new Font("宋体", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0x80);
            this.btnItemUp.Image = Resources.ArrowUp;
            this.btnItemUp.Location = new Point(0x1e4, 14);
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.Size = new Size(0x1d, 0x17);
            this.btnItemUp.TabIndex = 6;
            this.toolTip2.SetToolTip(this.btnItemUp, "更改选定项目的顺序。");
            this.btnItemUp.UseVisualStyleBackColor = true;
            this.btnItemUp.Click += new EventHandler(this.btnItemUp_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(0x30f, 0x17d);
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            this.MinimumSize = new Size(0x2b4, 0x19f);
            base.Name = "StyleEditForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "StyleEditForm";
            base.Shown += new EventHandler(this.StyleEditForm_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
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

