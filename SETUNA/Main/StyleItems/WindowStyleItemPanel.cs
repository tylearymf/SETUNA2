namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class WindowStyleItemPanel : ToolBoxForm
    {
        private GroupBox groupBox1;
        private Panel panel1;
        private RadioButton rdoFixed;
        private RadioButton rdoIncrement;

        public WindowStyleItemPanel(CWindowStyleItem style) : base(style)
        {
        }

        protected override object GetStyleFromForm() => 
            new CWindowStyleItem { IsWindow = !this.rdoFixed.Checked };

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.rdoIncrement = new RadioButton();
            this.rdoFixed = new RadioButton();
            this.panel1 = new Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0x24, 0x5c);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x70, 0x5c);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xab, 80);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.rdoIncrement.AutoSize = true;
            this.rdoIncrement.Location = new Point(3, 30);
            this.rdoIncrement.Name = "rdoIncrement";
            this.rdoIncrement.Size = new Size(0x5e, 0x10);
            this.rdoIncrement.TabIndex = 1;
            this.rdoIncrement.Text = "窗口类型";
            this.rdoIncrement.UseVisualStyleBackColor = true;
            this.rdoFixed.AutoSize = true;
            this.rdoFixed.Checked = true;
            this.rdoFixed.Location = new Point(3, 8);
            this.rdoFixed.Name = "rdoFixed";
            this.rdoFixed.Size = new Size(90, 0x10);
            this.rdoFixed.TabIndex = 0;
            this.rdoFixed.TabStop = true;
            this.rdoFixed.Text = "参考图类型";
            this.rdoFixed.UseVisualStyleBackColor = true;
            this.panel1.Controls.Add(this.rdoIncrement);
            this.panel1.Controls.Add(this.rdoFixed);
            this.panel1.Location = new Point(6, 0x12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x9c, 0x33);
            this.panel1.TabIndex = 8;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(190, 0x7c);
            base.Controls.Add(this.groupBox1);
            base.Name = "WindowStyleItemPanel";
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        protected override void SetStyleToForm(object style)
        {
            CWindowStyleItem item = (CWindowStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
            this.rdoFixed.Checked = !item.IsWindow;
            this.rdoIncrement.Checked = item.IsWindow;
        }
    }
}

