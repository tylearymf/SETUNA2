namespace SETUNA.Main.StyleItems
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class LoginInput : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private IContainer components;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private TextBox txtID;
        private TextBox txtPass;

        public LoginInput()
        {
            this.InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtID.TextLength == 0)
            {
                this.txtID.Focus();
            }
            else if (this.txtPass.TextLength == 0)
            {
                this.txtPass.Focus();
            }
            else
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

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.txtID = new TextBox();
            this.label2 = new Label();
            this.label1 = new Label();
            this.txtPass = new TextBox();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x10c, 0x6c);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.txtID.Location = new Point(0x57, 0x1c);
            this.txtID.MaxLength = 100;
            this.txtID.Name = "txtID";
            this.txtID.Size = new Size(0x9d, 0x13);
            this.txtID.TabIndex = 1;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x18, 0x41);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x38, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码:";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x18, 0x1f);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x12, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "帐号：";
            this.txtPass.Location = new Point(0x57, 0x3e);
            this.txtPass.MaxLength = 100;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new Size(0x9d, 0x13);
            this.txtPass.TabIndex = 3;
            this.btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0xcd, 0x7e);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnOK.Location = new Point(0x7c, 0x7e);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x4b, 0x17);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(0x124, 0x9c);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            base.Name = "LoginInput";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "LoginInput";
            base.Shown += new EventHandler(this.LoginInput_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void LoginInput_Shown(object sender, EventArgs e)
        {
            if (this.txtID.TextLength > 0)
            {
                this.txtPass.Focus();
            }
            else
            {
                this.txtID.Focus();
            }
        }

        public string GroupTitle
        {
            set
            {
                this.groupBox1.Text = value;
            }
        }

        public string ID
        {
            get{return  
                this.txtID.Text;}
            set
            {
                this.txtID.Text = value;
            }
        }

        public string Pass
        {
            get{return  
                this.txtPass.Text;}
            set
            {
                this.txtPass.Text = value;
            }
        }
    }
}

