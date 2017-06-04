namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    internal class ImageBmpStyleItemPanel : ToolBoxForm
    {
        private Button btnRef;
        private CheckBox chkCopy;
        private CheckBox chkWindow;
        private ComboBox cmbDupli;
        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton rdoName;
        private RadioButton rdoSaveAs;
        private RadioButton rdoScrapName;
        private TextBox txtFolder;
        private TextBox txtName;

        public ImageBmpStyleItemPanel()
        {
        }

        public ImageBmpStyleItemPanel(CImageBmpStyleItem item) : base(item)
        {
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = this.txtFolder.Text;
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtFolder.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        protected override object GetStyleFromForm()
        {
            CImageBmpStyleItem item = new CImageBmpStyleItem {
                SaveFolder = this.txtFolder.Text,
                HaveMargin = this.chkWindow.Checked,
                CopyPath = this.chkCopy.Checked
            };
            if (this.rdoSaveAs.Checked)
            {
                item.FileNameType = CImageStyleItem.EnumFileName.SaveAs;
            }
            else if (this.rdoScrapName.Checked)
            {
                item.FileNameType = CImageStyleItem.EnumFileName.ScrapName;
            }
            else
            {
                item.FileNameType = CImageStyleItem.EnumFileName.UseName;
            }
            item.DupliType = (CImageStyleItem.EnumDupliType) this.cmbDupli.SelectedIndex;
            item.FileName = this.txtName.Text;
            return item;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.cmbDupli = new ComboBox();
            this.label3 = new Label();
            this.rdoSaveAs = new RadioButton();
            this.txtName = new TextBox();
            this.rdoScrapName = new RadioButton();
            this.rdoName = new RadioButton();
            this.label2 = new Label();
            this.chkCopy = new CheckBox();
            this.chkWindow = new CheckBox();
            this.btnRef = new Button();
            this.txtFolder = new TextBox();
            this.label1 = new Label();
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0xf9, 0xe4);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x143, 0xe4);
            this.groupBox1.Controls.Add(this.cmbDupli);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdoSaveAs);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.rdoScrapName);
            this.groupBox1.Controls.Add(this.rdoName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkCopy);
            this.groupBox1.Controls.Add(this.chkWindow);
            this.groupBox1.Controls.Add(this.btnRef);
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x182, 0xd4);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.cmbDupli.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDupli.FormattingEnabled = true;
            this.cmbDupli.Items.AddRange(new object[] { "覆盖", "追加序号", "重复时指定" });
            this.cmbDupli.Location = new Point(130, 0x7e);
            this.cmbDupli.Name = "cmbDupli";
            this.cmbDupli.Size = new Size(0x85, 20);
            this.cmbDupli.TabIndex = 9;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x51, 0x81);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x2b, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "重复时∶";
            this.rdoSaveAs.AutoSize = true;
            this.rdoSaveAs.Location = new Point(0x53, 0x41);
            this.rdoSaveAs.Name = "rdoSaveAs";
            this.rdoSaveAs.Size = new Size(0x6f, 0x10);
            this.rdoSaveAs.TabIndex = 4;
            this.rdoSaveAs.TabStop = true;
            this.rdoSaveAs.Text = "保存时指定";
            this.rdoSaveAs.UseVisualStyleBackColor = true;
            this.rdoSaveAs.CheckedChanged += new EventHandler(this.rdoSaveAs_CheckedChanged);
            this.txtName.Location = new Point(100, 0x67);
            this.txtName.MaxLength = 0xff;
            this.txtName.Name = "txtName";
            this.txtName.Size = new Size(0xdf, 0x13);
            this.txtName.TabIndex = 7;
            this.rdoScrapName.AutoSize = true;
            this.rdoScrapName.Location = new Point(0x53, 0x55);
            this.rdoScrapName.Name = "rdoScrapName";
            this.rdoScrapName.Size = new Size(0x80, 0x10);
            this.rdoScrapName.TabIndex = 5;
            this.rdoScrapName.TabStop = true;
            this.rdoScrapName.Text = "使用参考图名字";
            this.rdoScrapName.UseVisualStyleBackColor = true;
            this.rdoScrapName.CheckedChanged += new EventHandler(this.rdoSaveAs_CheckedChanged);
            this.rdoName.AutoSize = true;
            this.rdoName.Location = new Point(0x53, 0x6a);
            this.rdoName.Name = "rdoName";
            this.rdoName.Size = new Size(14, 13);
            this.rdoName.TabIndex = 6;
            this.rdoName.TabStop = true;
            this.rdoName.UseVisualStyleBackColor = true;
            this.rdoName.CheckedChanged += new EventHandler(this.rdoSaveAs_CheckedChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x18, 0x43);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件名∶";
            this.chkCopy.AutoSize = true;
            this.chkCopy.Location = new Point(0x13, 0xb5);
            this.chkCopy.Name = "chkCopy";
            this.chkCopy.Size = new Size(0xea, 0x10);
            this.chkCopy.TabIndex = 11;
            this.chkCopy.Text = "复制到剪贴板上的文件的保存路径";
            this.chkCopy.UseVisualStyleBackColor = true;
            this.chkWindow.AutoSize = true;
            this.chkWindow.Location = new Point(0x13, 0xa3);
            this.chkWindow.Name = "chkWindow";
            this.chkWindow.Size = new Size(0x7f, 0x10);
            this.chkWindow.TabIndex = 10;
            this.chkWindow.Text = "包含窗口/边框";
            this.chkWindow.UseVisualStyleBackColor = true;
            this.btnRef.Location = new Point(0x145, 0x1d);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new Size(0x16, 0x17);
            this.btnRef.TabIndex = 2;
            this.btnRef.Text = "...";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new EventHandler(this.btnRef_Click);
            this.txtFolder.Location = new Point(0x49, 0x1f);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new Size(250, 0x13);
            this.txtFolder.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x18, 0x22);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2b, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目的地：";
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.ApplicationData;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x191, 260);
            base.Controls.Add(this.groupBox1);
            base.Name = "ImageBmpStyleItemPanel";
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        protected override void OKCheck(ref bool cancel)
        {
            cancel = true;
            if (this.txtFolder.Text != "")
            {
                try
                {
                    Path.GetFullPath(this.txtFolder.Text);
                }
                catch
                {
                    MessageBox.Show("文件夹名无效。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtFolder.Focus();
                    return;
                }
            }
            if (!this.rdoSaveAs.Checked && this.rdoName.Checked)
            {
                if (this.txtName.Text == "")
                {
                    MessageBox.Show("没有指定文件名。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtName.Focus();
                    return;
                }
                foreach (char ch in Path.GetInvalidFileNameChars())
                {
                    if (this.txtName.Text.IndexOf(ch) > -1)
                    {
                        MessageBox.Show("文件名无效。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtName.Focus();
                        return;
                    }
                }
            }
            cancel = false;
        }

        private void rdoSaveAs_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoSaveAs.Checked)
            {
                this.cmbDupli.Enabled = false;
            }
            else
            {
                this.cmbDupli.Enabled = true;
            }
            if (this.rdoName.Checked)
            {
                this.txtName.Enabled = true;
            }
            else
            {
                this.txtName.Enabled = false;
            }
        }

        protected override void SetStyleToForm(object style)
        {
            CImageBmpStyleItem item = (CImageBmpStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
            this.txtFolder.Text = item.SaveFolder;
            this.chkWindow.Checked = item.HaveMargin;
            this.chkCopy.Checked = item.CopyPath;
            switch (item.FileNameType)
            {
                case CImageStyleItem.EnumFileName.SaveAs:
                    this.rdoSaveAs.Checked = true;
                    break;

                case CImageStyleItem.EnumFileName.ScrapName:
                    this.rdoScrapName.Checked = true;
                    break;

                case CImageStyleItem.EnumFileName.UseName:
                    this.rdoName.Checked = true;
                    break;
            }
            this.cmbDupli.SelectedIndex = (int) item.DupliType;
            this.txtName.Text = item.FileName;
        }
    }
}

