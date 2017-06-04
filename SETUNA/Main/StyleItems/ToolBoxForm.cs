namespace SETUNA.Main.StyleItems
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ToolBoxForm : Form
    {
        protected Button cmdCancel;
        protected Button cmdOK;
        private IContainer components;

        public ToolBoxForm()
        {
            this.InitializeComponent();
        }

        public ToolBoxForm(object style)
        {
            this.InitializeComponent();
            this.SetStyleToForm(style);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            bool cancel = false;
            this.OKCheck(ref cancel);
            if (!cancel)
            {
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

        protected virtual object GetStyleFromForm()
        {
            throw new Exception("GetStyleFromForm未实现");
        }

        private void InitializeComponent()
        {
            this.cmdOK = new Button();
            this.cmdCancel = new Button();
            base.SuspendLayout();
            this.cmdOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.cmdOK.Location = new Point(0xa5, 0xd6);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new Size(70, 0x18);
            this.cmdOK.TabIndex = 0x3e6;
            this.cmdOK.Text = "确定";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new EventHandler(this.cmdOK_Click);
            this.cmdCancel.Anchor = AnchorStyles.None;
            this.cmdCancel.DialogResult = DialogResult.Cancel;
            this.cmdCancel.Location = new Point(0xf1, 0xd6);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new Size(70, 0x18);
            this.cmdCancel.TabIndex = 0x3e7;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new EventHandler(this.cmdCancel_Click);
            base.AcceptButton = this.cmdOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.cmdCancel;
            base.ClientSize = new Size(0x13f, 0xf6);
            base.Controls.Add(this.cmdCancel);
            base.Controls.Add(this.cmdOK);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ToolBoxForm";
            base.Padding = new Padding(5);
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "ToolBoxForm1";
            base.ResumeLayout(false);
        }

        protected virtual void OKCheck(ref bool cancel)
        {
        }

        protected virtual void SetStyleToForm(object style)
        {
            throw new Exception("SetStyleToForm未实现");
        }

        public object StyleItem =>
            this.GetStyleFromForm();
    }
}

