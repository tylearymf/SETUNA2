namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main.Other;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class CopyStyleItemPanel : ToolBoxForm
    {
        private CheckBox chkWindow;
        private GroupBox groupBox1;
        private LayerInfo mLayerInfo;

        public CopyStyleItemPanel()
        {
        }

        public CopyStyleItemPanel(CCopyStyleItem item) : base(item)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
        }

        protected override object GetStyleFromForm() => 
            new CCopyStyleItem { CopyFromSource = !this.chkWindow.Checked };

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.chkWindow = new CheckBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0x24, 0x4d);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(110, 0x4d);
            this.groupBox1.Controls.Add(this.chkWindow);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xac, 0x3e);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.chkWindow.AutoSize = true;
            this.chkWindow.Location = new Point(0x17, 0x1c);
            this.chkWindow.Name = "chkWindow";
            this.chkWindow.Size = new Size(0x7f, 0x10);
            this.chkWindow.TabIndex = 0;
            this.chkWindow.Text = "包含窗口/边框";
            this.chkWindow.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0xbc, 0x6d);
            base.Controls.Add(this.groupBox1);
            base.Name = "CopyStyleItemPanel";
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        protected override void SetStyleToForm(object style)
        {
            CCopyStyleItem item = (CCopyStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
            this.chkWindow.Checked = !item.CopyFromSource;
        }
    }
}

