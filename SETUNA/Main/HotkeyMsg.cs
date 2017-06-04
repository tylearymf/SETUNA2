namespace SETUNA.Main
{
    using SETUNA.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class HotkeyMsg : Form
    {
        private Keys _key;
        private Button btnClose;
        private IContainer components;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblKey;
        private PictureBox pictureBox1;

        public HotkeyMsg()
        {
            this.InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
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
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.btnClose = new Button();
            this.lblKey = new Label();
            this.pictureBox1 = new PictureBox();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, 0x80);
            this.label1.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.label1.Location = new Point(0x3f, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xcd, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "禁用快捷键设置";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x4b, 0x3d);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x175, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "因为被其他软件使用，禁用SETUNA的快捷键设置。";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x4b, 0x4c);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x181, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "您可以重新指定启用另一个键，请打开选项设置。";
            this.btnClose.DialogResult = DialogResult.Cancel;
            this.btnClose.Location = new Point(0x197, 0x68);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x62, 0x17);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Point, 0x80);
            this.lblKey.Location = new Point(0x58, 40);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new Size(0x3d, 12);
            this.lblKey.TabIndex = 4;
            this.lblKey.Text = "Ctrl + D1";
            this.pictureBox1.Image = Resources.icon;
            this.pictureBox1.Location = new Point(9, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x30, 0x30);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.CancelButton = this.btnClose;
            base.ClientSize = new Size(0x205, 0x8b);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.lblKey);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "HotkeyMsg";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SETUNA快捷键设置";
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public Keys HotKey
        {
            set
            {
                this._key = value;
                string str = "";
                if ((this._key & Keys.Control) == Keys.Control)
                {
                    str = str + "Ctrl + ";
                }
                if ((this._key & Keys.Shift) == Keys.Shift)
                {
                    str = str + "Shift + ";
                }
                if ((this._key & Keys.Alt) == Keys.Alt)
                {
                    str = str + "Alt + ";
                }
                str = str + ((this._key & Keys.KeyCode)).ToString();
                this.lblKey.Text = str;
            }
        }
    }
}

