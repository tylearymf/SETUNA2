namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main.Other;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class NothingStyleItemPanel : ToolBoxForm
    {
        private Label label1;
        private LayerInfo mLayerInfo;

        public NothingStyleItemPanel(CStyleItem item) : base(item)
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
            null;

        private void InitializeComponent()
        {
            this.label1 = new Label();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0x35, 0x3e);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x81, 0x3e);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x17, 0x1c);
            this.label1.Name = "label1";
            this.label1.Size = new Size(160, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "这个项目没有设置";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0xcf, 0x5e);
            base.Controls.Add(this.label1);
            base.Name = "NothingStyleItemPanel";
            base.Controls.SetChildIndex(this.label1, 0);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        protected override void SetStyleToForm(object style)
        {
            CStyleItem item = (CStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
        }
    }
}

