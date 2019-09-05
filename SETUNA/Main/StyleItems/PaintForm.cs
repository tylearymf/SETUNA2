namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main.Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class PaintForm : Form
    {
        private System.Drawing.Image _src;
        private Button button1;
        private IContainer components;
        private LayerInfo mLayerInfo;

        public PaintForm(System.Drawing.Image src)
        {
            this.InitializeComponent();
            this._src = src;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            if (this._src != null)
            {
                this._src.Dispose();
                this._src = null;
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.button1 = new Button();
            base.SuspendLayout();
            this.button1.Location = new Point(0xd4, 0xe7);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x49, 0x1d);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x124, 0x10a);
            base.Controls.Add(this.button1);
            base.Name = "PaintForm";
            this.Text = "PaintForm";
            base.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Gray, 0, 0, base.Width, base.Height);
            if (this._src != null)
            {
                e.Graphics.DrawImageUnscaled(this._src, 0, 0);
            }
        }

        public System.Drawing.Image Image =>
            this._src;

        private abstract class PaintCommand
        {
            private float _opacity;

            protected PaintCommand()
            {
            }

            public abstract void Draw(Graphics g);

            public float Opacity
            {
                get{return  
                    this._opacity;}
                set
                {
                    this._opacity = value;
                }
            }
        }
    }
}

