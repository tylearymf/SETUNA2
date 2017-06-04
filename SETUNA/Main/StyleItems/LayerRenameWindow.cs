namespace SETUNA.Main.StyleItems
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class LayerRenameWindow : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private IContainer components;
        private ErrorProvider errorProvider1;
        private Label label1;
        private TextBox txtLayerName;

        public LayerRenameWindow()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.btnOK = new Button();
            this.txtLayerName = new TextBox();
            this.label1 = new Label();
            this.btnCancel = new Button();
            this.errorProvider1 = new ErrorProvider(this.components);
            ((ISupportInitialize) this.errorProvider1).BeginInit();
            base.SuspendLayout();
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(0x62, 0x33);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x40, 0x17);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.txtLayerName.Location = new Point(80, 0x12);
            this.txtLayerName.MaxLength = 50;
            this.txtLayerName.Name = "txtLayerName";
            this.txtLayerName.Size = new Size(0x8d, 0x13);
            this.txtLayerName.TabIndex = 0;
            this.txtLayerName.Validating += new CancelEventHandler(this.textBox1_Validating);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 0x15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3d, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图层名称：";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0xa4, 0x33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x40, 0x17);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.errorProvider1.ContainerControl = this;
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(240, 0x56);
            base.ControlBox = false;
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.txtLayerName);
            base.Controls.Add(this.btnOK);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "LayerRenameWindow";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "更改图层名称";
            base.TopMost = true;
            ((ISupportInitialize) this.errorProvider1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtLayerName.TextLength == 0)
            {
                this.errorProvider1.SetIconAlignment(this.txtLayerName, ErrorIconAlignment.TopLeft);
                this.errorProvider1.SetError(this.txtLayerName, "没有输入图层名");
            }
        }

        public string LayerName
        {
            get{return  
                this.txtLayerName.Text;}
            set
            {
                this.txtLayerName.Text = value;
            }
        }
    }
}

