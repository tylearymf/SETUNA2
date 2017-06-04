namespace SETUNA.Main
{
    using SETUNA.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class SplashForm : Form
    {
        private IContainer components;
        private Label label1;
        private Label lblVer;
        private PictureBox pictureBox1;
        public Timer SplashTimer;

        public SplashForm()
        {
            this.InitializeComponent();
            this.lblVer.Text = base.ProductName + " " + Application.ProductVersion;
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
            this.SplashTimer = new Timer(this.components);
            this.pictureBox1 = new PictureBox();
            this.label1 = new Label();
            this.lblVer = new Label();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.SplashTimer.Interval = 0xbb8;
            this.SplashTimer.Tick += new EventHandler(this.SplashTimer_Tick);
            this.pictureBox1.Image = Resources.Logo;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new Point(-1, -1);
            this.pictureBox1.Margin = new Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(400, 0x7e);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
            this.label1.AutoSize = true;
            this.label1.Cursor = Cursors.Hand;
            this.label1.ForeColor = Color.Gray;
            this.label1.Location = new Point(0x51, 150);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xe3, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "http://www.clearunit.com/clearup/setuna2/";
            this.lblVer.ForeColor = Color.Gray;
            this.lblVer.Location = new Point(12, 0x81);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new Size(0x16e, 0x12);
            this.lblVer.TabIndex = 4;
            this.lblVer.Text = "SETUNA 2.0α";
            this.lblVer.TextAlign = ContentAlignment.MiddleCenter;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x18d, 0xa2);
            base.ControlBox = false;
            base.Controls.Add(this.lblVer);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "SplashForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            base.TopMost = true;
            base.Load += new EventHandler(this.SplashForm_Load);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.SplashTimer.Enabled = false;
            base.Close();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
        }

        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

