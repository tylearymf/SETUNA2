namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    internal class PicasaStyleItemPanel : ToolBoxForm
    {
        private Button button1;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel1;
        private TextBox txtID;
        private TextBox txtPass;

        public PicasaStyleItemPanel()
        {
        }

        public PicasaStyleItemPanel(CPicasaUploaderStyleItem item) : base(item)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.linkLabel1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    this.txtID.Enabled = true;
                    this.txtPass.Enabled = true;
                    return;

                case 1:
                    this.txtID.Enabled = true;
                    this.txtPass.Enabled = false;
                    return;

                case 2:
                    this.txtID.Enabled = false;
                    this.txtPass.Enabled = false;
                    return;
            }
        }

        protected override object GetStyleFromForm()
        {
            CPicasaUploaderStyleItem item = new CPicasaUploaderStyleItem();
            if (this.comboBox1.SelectedIndex == 1)
            {
                this.txtPass.Text = "";
            }
            if (this.comboBox1.SelectedIndex == 2)
            {
                this.txtID.Text = "";
                this.txtPass.Text = "";
            }
            item.ID = PicasaBar.Encrypto(this.txtID.Text);
            item.Pass = PicasaBar.Encrypto(this.txtPass.Text);
            item.Manage = (byte) this.comboBox1.SelectedIndex;
            return item;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.linkLabel1 = new LinkLabel();
            this.label4 = new Label();
            this.label3 = new Label();
            this.comboBox1 = new ComboBox();
            this.txtPass = new TextBox();
            this.txtID = new TextBox();
            this.label2 = new Label();
            this.label1 = new Label();
            this.button1 = new Button();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0x88, 0xea);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(210, 0xea);
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x112, 0xd9);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new Point(0x12, 0xb8);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(0x9e, 12);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://picasaweb.google.com/";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.label4.Location = new Point(0x12, 0x99);
            this.label4.Name = "label4";
            this.label4.Size = new Size(250, 0x1d);
            this.label4.TabIndex = 6;
            this.label4.Text = "请在使用服务前访问 Picasa 的网站，以确认使用条款。";
            this.label3.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, 0x80);
            this.label3.Location = new Point(6, 0x88);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x106, 0x10);
            this.label3.TabIndex = 5;
            this.label3.Text = "※如果这是你第一次使用 Picasa 网络相册";
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "保存帐号和密码", "只保存帐号", "全部不保存" });
            this.comboBox1.Location = new Point(0x1b, 0x61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0xdb, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.txtPass.Location = new Point(0x58, 0x3e);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new Size(0x9e, 0x13);
            this.txtPass.TabIndex = 3;
            this.txtID.Location = new Point(0x58, 0x1c);
            this.txtID.Name = "txtID";
            this.txtID.Size = new Size(0x9e, 0x13);
            this.txtID.TabIndex = 2;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x19, 0x41);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x38, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x19, 0x1f);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x39, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "谷歌帐号：";
            this.button1.Location = new Point(0xb6, 0xb3);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x40, 0x17);
            this.button1.TabIndex = 8;
            this.button1.Text = "复制网址";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x120, 0x10a);
            base.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            base.Name = "PicasaStyleItemPanel";
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(this.linkLabel1.Text);
        }

        protected override void OKCheck(ref bool cancel)
        {
            base.OKCheck(ref cancel);
            if ((this.comboBox1.SelectedIndex == 0) && ((this.txtID.TextLength == 0) || (this.txtPass.TextLength == 0)))
            {
                cancel = true;
                MessageBox.Show("请输入帐号和密码。");
            }
            else if ((this.comboBox1.SelectedIndex == 0) && (this.txtID.TextLength == 0))
            {
                cancel = true;
                MessageBox.Show("请输入帐号。");
            }
        }

        protected override void SetStyleToForm(object style)
        {
            string str2;
            CPicasaUploaderStyleItem item = (CPicasaUploaderStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
            string str = str2 = "";
            if (item.ID.Length > 0)
            {
                str = PicasaBar.Decrypto(item.ID);
            }
            if (item.Pass.Length > 0)
            {
                str2 = PicasaBar.Decrypto(item.Pass);
            }
            this.txtID.Text = str;
            this.txtPass.Text = str2;
            this.comboBox1.SelectedIndex = item.Manage;
        }
    }
}

