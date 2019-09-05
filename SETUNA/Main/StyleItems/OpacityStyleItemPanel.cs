namespace SETUNA.Main.StyleItems
{
    using Properties;
    using SETUNA.Main.Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    internal class OpacityStyleItemPanel : ToolBoxForm
    {
        private TrackBar barOpacity;
        private TrackBar barOpacity2;
        private Button btnPreview;
        private ColorMatrix cm;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ImageAttributes ia;
        private System.Drawing.Image imgBackground;
        private System.Drawing.Image imgScrap;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown numOpacity;
        private NumericUpDown numOpacity2;
        private NumericUpDown numPreview;
        private PictureBox picPreview;
        private RadioButton rdoFixed;
        private RadioButton rdoIncrement;
        private LayerInfo mLayerInfo;

        public OpacityStyleItemPanel()
        {
        }

        public OpacityStyleItemPanel(COpacityStyleItem item) : base(item)
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

        private void barOpacity_Scroll(object sender, EventArgs e)
        {
            this.numOpacity.Value = this.barOpacity.Value;
            this.numOpacity2.Value = this.barOpacity2.Value;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if ((this.numPreview.Value + this.numOpacity2.Value) > this.numPreview.Maximum)
            {
                this.numPreview.Value = this.numPreview.Maximum;
            }
            else if ((this.numPreview.Value + this.numOpacity2.Value) < this.numPreview.Minimum)
            {
                this.numPreview.Value = this.numPreview.Minimum;
            }
            else
            {
                this.numPreview.Value += this.numOpacity2.Value;
            }
        }

        protected override object GetStyleFromForm()
        {
            COpacityStyleItem item = new COpacityStyleItem();
            if (this.rdoFixed.Checked)
            {
                item.Opacity = (int) this.numOpacity.Value;
            }
            else
            {
                item.Opacity = (int) this.numOpacity2.Value;
            }
            item.Absolute = this.rdoFixed.Checked;
            return item;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.groupBox2 = new GroupBox();
            this.label4 = new Label();
            this.numPreview = new NumericUpDown();
            this.btnPreview = new Button();
            this.picPreview = new PictureBox();
            this.barOpacity2 = new TrackBar();
            this.barOpacity = new TrackBar();
            this.label3 = new Label();
            this.numOpacity2 = new NumericUpDown();
            this.rdoIncrement = new RadioButton();
            this.rdoFixed = new RadioButton();
            this.label2 = new Label();
            this.label1 = new Label();
            this.numOpacity = new NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.numPreview.BeginInit();
            ((ISupportInitialize) this.picPreview).BeginInit();
            this.barOpacity2.BeginInit();
            this.barOpacity.BeginInit();
            this.numOpacity2.BeginInit();
            this.numOpacity.BeginInit();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0x179, 0xde);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x1c3, 0xde);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.barOpacity2);
            this.groupBox1.Controls.Add(this.barOpacity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numOpacity2);
            this.groupBox1.Controls.Add(this.rdoIncrement);
            this.groupBox1.Controls.Add(this.rdoFixed);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numOpacity);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x201, 0xd0);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numPreview);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Controls.Add(this.picPreview);
            this.groupBox2.Location = new Point(0x148, 0x12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xb3, 0xb5);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0xa2, 0x9d);
            this.label4.Name = "label4";
            this.label4.Size = new Size(11, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "%";
            this.numPreview.ImeMode = ImeMode.Off;
            this.numPreview.Location = new Point(0x6c, 0x9b);
            this.numPreview.Name = "numPreview";
            this.numPreview.Size = new Size(0x30, 0x13);
            this.numPreview.TabIndex = 1;
            this.numPreview.ValueChanged += new EventHandler(this.numPreview_ValueChanged);
            this.btnPreview.Location = new Point(6, 0x98);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new Size(0x60, 0x17);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "应用相对值";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new EventHandler(this.btnPreview_Click);
            this.picPreview.BorderStyle = BorderStyle.Fixed3D;
            this.picPreview.Location = new Point(6, 0x12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new Size(0xa7, 0x83);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new PaintEventHandler(this.picPreview_Paint);
            this.barOpacity2.AutoSize = false;
            this.barOpacity2.Location = new Point(0x6b, 0x4f);
            this.barOpacity2.Name = "barOpacity2";
            this.barOpacity2.Size = new Size(0x7b, 20);
            this.barOpacity2.TabIndex = 6;
            this.barOpacity2.TickFrequency = 10;
            this.barOpacity2.Scroll += new EventHandler(this.barOpacity_Scroll);
            this.barOpacity.AutoSize = false;
            this.barOpacity.Location = new Point(0x6b, 50);
            this.barOpacity.Maximum = 100;
            this.barOpacity.Minimum = 1;
            this.barOpacity.Name = "barOpacity";
            this.barOpacity.Size = new Size(0x7b, 20);
            this.barOpacity.TabIndex = 2;
            this.barOpacity.TickFrequency = 10;
            this.barOpacity.Value = 1;
            this.barOpacity.Scroll += new EventHandler(this.barOpacity_Scroll);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(290, 0x4f);
            this.label3.Name = "label3";
            this.label3.Size = new Size(11, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "%";
            this.numOpacity2.ImeMode = ImeMode.Off;
            this.numOpacity2.Location = new Point(0xec, 0x4d);
            this.numOpacity2.Name = "numOpacity2";
            this.numOpacity2.Size = new Size(0x30, 0x13);
            this.numOpacity2.TabIndex = 7;
            this.numOpacity2.ValueChanged += new EventHandler(this.numOpacity_ValueChanged);
            this.numOpacity2.Enter += new EventHandler(this.numOpacity_Enter);
            this.rdoIncrement.AutoSize = true;
            this.rdoIncrement.Location = new Point(0x2a, 0x4d);
            this.rdoIncrement.Name = "rdoIncrement";
            this.rdoIncrement.Size = new Size(0x3b, 0x10);
            this.rdoIncrement.TabIndex = 5;
            this.rdoIncrement.Text = "相对值";
            this.rdoIncrement.UseVisualStyleBackColor = true;
            this.rdoFixed.AutoSize = true;
            this.rdoFixed.Checked = true;
            this.rdoFixed.Location = new Point(0x2a, 0x31);
            this.rdoFixed.Name = "rdoFixed";
            this.rdoFixed.Size = new Size(0x3b, 0x10);
            this.rdoFixed.TabIndex = 1;
            this.rdoFixed.TabStop = true;
            this.rdoFixed.Text = "绝对值";
            this.rdoFixed.UseVisualStyleBackColor = true;
            this.rdoFixed.CheckedChanged += new EventHandler(this.rdoFixed_CheckedChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(290, 0x33);
            this.label2.Name = "label2";
            this.label2.Size = new Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "%";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x19, 0x1f);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x37, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "不透明度：";
            this.numOpacity.ImeMode = ImeMode.Off;
            this.numOpacity.Location = new Point(0xec, 0x31);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new Size(0x30, 0x13);
            this.numOpacity.TabIndex = 3;
            this.numOpacity.ValueChanged += new EventHandler(this.numOpacity_ValueChanged);
            this.numOpacity.Enter += new EventHandler(this.numOpacity_Enter);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x211, 0xfe);
            base.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            base.Name = "OpacityStyleItemPanel";
            base.Shown += new EventHandler(this.OpacityStyleItemPanel_Shown);
            base.FormClosed += new FormClosedEventHandler(this.OpacityStyleItemPanel_FormClosed);
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.numPreview.EndInit();
            ((ISupportInitialize) this.picPreview).EndInit();
            this.barOpacity2.EndInit();
            this.barOpacity.EndInit();
            this.numOpacity2.EndInit();
            this.numOpacity.EndInit();
            base.ResumeLayout(false);
        }

        private void numOpacity_Enter(object sender, EventArgs e)
        {
            NumericUpDown down = (NumericUpDown) sender;
            down.Select(0, down.Value.ToString().Length);
        }

        private void numOpacity_ValueChanged(object sender, EventArgs e)
        {
            if (this.barOpacity.Value != ((int) this.numOpacity.Value))
            {
                this.barOpacity.Value = (int) this.numOpacity.Value;
            }
            if (this.barOpacity2.Value != ((int) this.numOpacity2.Value))
            {
                this.barOpacity2.Value = (int) this.numOpacity2.Value;
            }
            if (this.rdoFixed.Checked)
            {
                this.numPreview.Value = this.numOpacity.Value;
            }
        }

        private void numPreview_ValueChanged(object sender, EventArgs e)
        {
            if ((this.cm != null) && (this.ia != null))
            {
                this.cm.Matrix33 = (float) (this.numPreview.Value / 100M);
                this.ia.SetColorMatrix(this.cm);
            }
            this.Refresh();
        }

        private void OpacityStyleItemPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.imgBackground != null)
            {
                this.imgBackground.Dispose();
                this.imgBackground = null;
                GC.Collect();
            }
        }

        private void OpacityStyleItemPanel_Shown(object sender, EventArgs e)
        {
            if (this.rdoFixed.Checked)
            {
                this.numOpacity.Focus();
            }
            else
            {
                this.numOpacity2.Focus();
            }
        }

        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            if (this.imgBackground != null)
            {
                e.Graphics.DrawImageUnscaled(this.imgBackground, new Point(0, 0));
            }
            if (this.imgScrap != null)
            {
                e.Graphics.DrawImage(this.imgScrap, new Rectangle((this.imgBackground.Width - this.imgScrap.Width) / 2, (this.imgBackground.Height - this.imgScrap.Height) / 2, this.imgScrap.Width, this.imgScrap.Height), 0, 0, this.imgScrap.Width, this.imgScrap.Height, GraphicsUnit.Pixel, this.ia);
            }
        }

        private void rdoFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoFixed.Checked)
            {
                this.numOpacity.Enabled = true;
                this.numOpacity2.Enabled = false;
                this.barOpacity.Enabled = true;
                this.barOpacity2.Enabled = false;
                this.numOpacity.Focus();
                this.btnPreview.Enabled = false;
                this.numPreview.Enabled = false;
                this.numPreview.Value = this.numOpacity.Value;
            }
            else
            {
                this.numOpacity.Enabled = false;
                this.numOpacity2.Enabled = true;
                this.barOpacity.Enabled = false;
                this.barOpacity2.Enabled = true;
                this.numOpacity2.Focus();
                this.btnPreview.Enabled = true;
                this.numPreview.Enabled = true;
            }
        }

        protected override void SetStyleToForm(object style)
        {
            COpacityStyleItem item = (COpacityStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
            this.numOpacity.Minimum = 1M;
            this.numOpacity.Maximum = 100M;
            this.numOpacity.Value = 100M;
            this.barOpacity.Minimum = 1;
            this.barOpacity.Maximum = 100;
            this.barOpacity.Value = 100;
            this.numPreview.Minimum = 1M;
            this.numPreview.Maximum = 100M;
            this.numPreview.Value = 100M;
            this.numOpacity2.Minimum = -99M;
            this.numOpacity2.Maximum = 99M;
            this.numOpacity2.Value = 0M;
            this.barOpacity2.Minimum = -99;
            this.barOpacity2.Maximum = 0x63;
            this.barOpacity2.Value = 0;
            this.rdoFixed.Checked = item.Absolute;
            this.rdoIncrement.Checked = !item.Absolute;
            if (item.Absolute)
            {
                this.numOpacity.Value = item.Opacity;
                this.numPreview.Value = item.Opacity;
            }
            else
            {
                this.numOpacity2.Value = item.Opacity;
            }
            this.rdoFixed_CheckedChanged(this, null);
            this.cm = new ColorMatrix();
            this.cm.Matrix00 = 1f;
            this.cm.Matrix11 = 1f;
            this.cm.Matrix22 = 1f;
            this.cm.Matrix33 = (float) (this.numPreview.Value / 100M);
            this.cm.Matrix44 = 1f;
            this.ia = new ImageAttributes();
            this.ia.SetColorMatrix(this.cm);
            this.imgBackground = new Bitmap(this.picPreview.Width, this.picPreview.Height, PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(this.imgBackground))
            {
                graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), this.imgBackground.Size);
            }
            this.imgScrap = Properties.Image.SampleImage;
        }
    }
}

