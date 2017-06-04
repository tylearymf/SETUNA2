namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class SaveImageStyleItemPanel : ToolBoxForm
    {
        private TrackBar barJpegQuality;
        private Button button1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label lblJpegQuality;
        private TabPage tabBmp;
        private TabControl tabControl1;
        private TabPage tabJpeg;
        private TabPage tabPng;
        private TextBox textBox1;

        public SaveImageStyleItemPanel()
        {
        }

        public SaveImageStyleItemPanel(CCopyStyleItem item) : base(item)
        {
        }

        private void barJpegQuality_Scroll(object sender, EventArgs e)
        {
        }

        protected override object GetStyleFromForm() => 
            new CCopyStyleItem();

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.checkBox1 = new CheckBox();
            this.button1 = new Button();
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.tabControl1 = new TabControl();
            this.tabPng = new TabPage();
            this.tabJpeg = new TabPage();
            this.label5 = new Label();
            this.label4 = new Label();
            this.lblJpegQuality = new Label();
            this.barJpegQuality = new TrackBar();
            this.label2 = new Label();
            this.tabBmp = new TabPage();
            this.checkBox2 = new CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabJpeg.SuspendLayout();
            this.barJpegQuality.BeginInit();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0xcd, 0xe3);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x117, 0xe3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x157, 0xd6);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(10, 0xad);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0xbd, 0x10);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "保存时的格式、质量等设置";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.button1.Location = new Point(0x13a, 14);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x15, 0x17);
            this.button1.TabIndex = 12;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.textBox1.Location = new Point(0x3e, 0x10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0xf6, 0x13);
            this.textBox1.TabIndex = 11;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 0x13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2b, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "目的地：";
            this.tabControl1.Appearance = TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPng);
            this.tabControl1.Controls.Add(this.tabJpeg);
            this.tabControl1.Controls.Add(this.tabBmp);
            this.tabControl1.Location = new Point(0x4f, 0x2b);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x100, 0x7c);
            this.tabControl1.TabIndex = 9;
            this.tabPng.Location = new Point(4, 0x18);
            this.tabPng.Name = "tabPng";
            this.tabPng.Padding = new Padding(3);
            this.tabPng.Size = new Size(0x141, 0x60);
            this.tabPng.TabIndex = 0;
            this.tabPng.Text = "PNG";
            this.tabPng.UseVisualStyleBackColor = true;
            this.tabJpeg.Controls.Add(this.label5);
            this.tabJpeg.Controls.Add(this.label4);
            this.tabJpeg.Controls.Add(this.lblJpegQuality);
            this.tabJpeg.Controls.Add(this.barJpegQuality);
            this.tabJpeg.Controls.Add(this.label2);
            this.tabJpeg.Location = new Point(4, 0x18);
            this.tabJpeg.Name = "tabJpeg";
            this.tabJpeg.Padding = new Padding(3);
            this.tabJpeg.Size = new Size(0xf8, 0x60);
            this.tabJpeg.TabIndex = 1;
            this.tabJpeg.Text = "JPEG";
            this.tabJpeg.UseVisualStyleBackColor = true;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0xc5, 7);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x11, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "高";
            this.label5.TextAlign = ContentAlignment.BottomLeft;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x31, 7);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x11, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "低";
            this.label4.TextAlign = ContentAlignment.BottomLeft;
            this.lblJpegQuality.Location = new Point(0xd8, 0x1a);
            this.lblJpegQuality.Name = "lblJpegQuality";
            this.lblJpegQuality.Size = new Size(0x1a, 12);
            this.lblJpegQuality.TabIndex = 2;
            this.lblJpegQuality.Text = "100";
            this.lblJpegQuality.TextAlign = ContentAlignment.TopRight;
            this.barJpegQuality.Location = new Point(0x2b, 20);
            this.barJpegQuality.Maximum = 100;
            this.barJpegQuality.Name = "barJpegQuality";
            this.barJpegQuality.Size = new Size(0xaf, 0x2d);
            this.barJpegQuality.TabIndex = 1;
            this.barJpegQuality.TickFrequency = 10;
            this.barJpegQuality.Scroll += new EventHandler(this.barJpegQuality_Scroll);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 0x1a);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1f, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "质量：";
            this.tabBmp.Location = new Point(4, 0x18);
            this.tabBmp.Name = "tabBmp";
            this.tabBmp.Size = new Size(0x141, 0x60);
            this.tabBmp.TabIndex = 2;
            this.tabBmp.Text = "BMP";
            this.tabBmp.UseVisualStyleBackColor = true;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new Point(10, 0xbd);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(0xa7, 0x10);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "指定保存时的文件名";
            this.checkBox2.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x165, 0x103);
            base.Controls.Add(this.groupBox1);
            base.Name = "SaveImageStyleItemPanel";
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabJpeg.ResumeLayout(false);
            this.tabJpeg.PerformLayout();
            this.barJpegQuality.EndInit();
            base.ResumeLayout(false);
        }

        protected override void SetStyleToForm(object style)
        {
            CCopyStyleItem item = (CCopyStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
        }
    }
}

