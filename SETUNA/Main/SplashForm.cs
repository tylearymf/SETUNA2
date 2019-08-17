namespace SETUNA.Main
{
    using Properties;
    using SETUNA.Main.Other;
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
            this.components = new System.ComponentModel.Container();
            this.SplashTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SplashTimer
            // 
            this.SplashTimer.Interval = 3000;
            this.SplashTimer.Tick += new System.EventHandler(this.SplashTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Properties.Resources.Logo;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(923, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(189, 337);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "https://github.com/tylearymf/SETUNA2";
            // 
            // lblVer
            // 
            this.lblVer.ForeColor = System.Drawing.Color.Gray;
            this.lblVer.Location = new System.Drawing.Point(28, 290);
            this.lblVer.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(854, 40);
            this.lblVer.TabIndex = 4;
            this.lblVer.Text = "SETUNA 2.0α";
            this.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 379);
            this.ControlBox = false;
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SplashForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        LayerInfo mLayerInfo;
        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
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

