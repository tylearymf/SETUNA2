namespace SETUNA.Main.StyleItems
{
    using SETUNA.Resources;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    internal class CompactStyleItemPanel : ToolBoxForm
    {
        private TrackBar barOpacity;
        private ColorMatrix cm;
        private ColorDialog colorDialog1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ImageAttributes ia;
        private System.Drawing.Image imgBackground;
        private System.Drawing.Image imgScrap;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown numOpacity;
        private PictureBox picLineColor;
        private PictureBox picPreview;
        private RadioButton rdoDashed;
        private RadioButton rdoSolid;

        public CompactStyleItemPanel()
        {
        }

        public CompactStyleItemPanel(CCompactStyleItem item) : base(item)
        {
        }

        private void barOpacity_Scroll(object sender, EventArgs e)
        {
            this.numOpacity.Value = this.barOpacity.Value;
        }

        private void barOpacity_ValueChanged(object sender, EventArgs e)
        {
            this.numPreview_ValueChanged();
        }

        protected override object GetStyleFromForm() => 
            new CCompactStyleItem { 
                Opacity = (byte) this.numOpacity.Value,
                LineColor = this.picLineColor.BackColor.ToArgb(),
                SoldLine = this.rdoSolid.Checked
            };

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.rdoDashed = new RadioButton();
            this.rdoSolid = new RadioButton();
            this.picLineColor = new PictureBox();
            this.label3 = new Label();
            this.groupBox2 = new GroupBox();
            this.picPreview = new PictureBox();
            this.barOpacity = new TrackBar();
            this.label2 = new Label();
            this.label1 = new Label();
            this.numOpacity = new NumericUpDown();
            this.colorDialog1 = new ColorDialog();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.picLineColor).BeginInit();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.picPreview).BeginInit();
            this.barOpacity.BeginInit();
            this.numOpacity.BeginInit();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0xed, 0xb1);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x137, 0xb1);
            this.groupBox1.Controls.Add(this.rdoDashed);
            this.groupBox1.Controls.Add(this.rdoSolid);
            this.groupBox1.Controls.Add(this.picLineColor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.barOpacity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numOpacity);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x175, 0xa4);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.rdoDashed.AutoSize = true;
            this.rdoDashed.Location = new Point(0x9d, 100);
            this.rdoDashed.Name = "rdoDashed";
            this.rdoDashed.Size = new Size(0x2f, 0x10);
            this.rdoDashed.TabIndex = 14;
            this.rdoDashed.TabStop = true;
            this.rdoDashed.Text = "虚线";
            this.rdoDashed.UseVisualStyleBackColor = true;
            this.rdoSolid.AutoSize = true;
            this.rdoSolid.Location = new Point(0x68, 100);
            this.rdoSolid.Name = "rdoSolid";
            this.rdoSolid.Size = new Size(0x2f, 0x10);
            this.rdoSolid.TabIndex = 13;
            this.rdoSolid.TabStop = true;
            this.rdoSolid.Text = "实线";
            this.rdoSolid.UseVisualStyleBackColor = true;
            this.rdoSolid.CheckedChanged += new EventHandler(this.rdoSolid_CheckedChanged);
            this.picLineColor.BorderStyle = BorderStyle.Fixed3D;
            this.picLineColor.Cursor = Cursors.Hand;
            this.picLineColor.Location = new Point(0x3e, 0x62);
            this.picLineColor.Name = "picLineColor";
            this.picLineColor.Size = new Size(0x20, 0x13);
            this.picLineColor.TabIndex = 12;
            this.picLineColor.TabStop = false;
            this.picLineColor.Click += new EventHandler(this.picLineColor_Click);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x19, 0x66);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1f, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "边框：";
            this.groupBox2.Controls.Add(this.picPreview);
            this.groupBox2.Location = new Point(0xe2, 0x12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x8a, 0x8a);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            this.picPreview.BorderStyle = BorderStyle.Fixed3D;
            this.picPreview.Location = new Point(6, 0x12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new Size(0x7e, 0x72);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new PaintEventHandler(this.picPreview_Paint);
            this.barOpacity.AutoSize = false;
            this.barOpacity.Location = new Point(0x30, 50);
            this.barOpacity.Maximum = 100;
            this.barOpacity.Minimum = 1;
            this.barOpacity.Name = "barOpacity";
            this.barOpacity.Size = new Size(0x5b, 20);
            this.barOpacity.TabIndex = 2;
            this.barOpacity.TickFrequency = 10;
            this.barOpacity.Value = 1;
            this.barOpacity.ValueChanged += new EventHandler(this.barOpacity_ValueChanged);
            this.barOpacity.Scroll += new EventHandler(this.barOpacity_Scroll);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0xc7, 50);
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
            this.numOpacity.Location = new Point(0x91, 0x30);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new Size(0x30, 0x13);
            this.numOpacity.TabIndex = 3;
            this.numOpacity.ValueChanged += new EventHandler(this.numOpacity_ValueChanged);
            this.numOpacity.Enter += new EventHandler(this.numOpacity_Enter);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x185, 0xd1);
            base.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            base.Name = "CompactStyleItemPanel";
            base.FormClosed += new FormClosedEventHandler(this.OpacityStyleItemPanel_FormClosed);
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize) this.picLineColor).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.picPreview).EndInit();
            this.barOpacity.EndInit();
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
        }

        private void numPreview_ValueChanged()
        {
            if ((this.cm != null) && (this.ia != null))
            {
                this.cm.Matrix33 = (float) (this.numOpacity.Value / 100M);
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
                if (this.imgScrap != null)
                {
                    this.imgScrap.Dispose();
                    this.imgScrap = null;
                }
                GC.Collect();
            }
        }

        private void picLineColor_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = this.picLineColor.BackColor;
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.picLineColor.BackColor = this.colorDialog1.Color;
            }
            this.UpdateLine();
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

        private void rdoSolid_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateLine();
        }

        protected override void SetStyleToForm(object style)
        {
            CCompactStyleItem item = (CCompactStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
            this.numOpacity.Minimum = CCompactStyleItem.OpacityMinValue;
            this.numOpacity.Maximum = CCompactStyleItem.OpacityMaxValue;
            this.numOpacity.Value = item.Opacity;
            this.barOpacity.Minimum = CCompactStyleItem.OpacityMinValue;
            this.barOpacity.Maximum = CCompactStyleItem.OpacityMaxValue;
            this.barOpacity.Value = item.Opacity;
            this.picLineColor.BackColor = Color.FromArgb(item.LineColor);
            this.rdoSolid.Checked = item.SoldLine;
            this.rdoDashed.Checked = !item.SoldLine;
            this.cm = new ColorMatrix();
            this.cm.Matrix00 = 1f;
            this.cm.Matrix11 = 1f;
            this.cm.Matrix22 = 1f;
            this.cm.Matrix33 = (float) (this.numOpacity.Value / 100M);
            this.cm.Matrix44 = 1f;
            this.ia = new ImageAttributes();
            this.ia.SetColorMatrix(this.cm);
            this.imgBackground = new Bitmap(this.picPreview.Width, this.picPreview.Height, PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(this.imgBackground))
            {
                graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), this.imgBackground.Size);
            }
            this.imgScrap = new Bitmap(50, 50, PixelFormat.Format24bppRgb);
            using (Graphics graphics2 = Graphics.FromImage(this.imgScrap))
            {
                graphics2.DrawImageUnscaled(SETUNA.Resources.Image.SampleImage, (this.imgScrap.Width / 2) - (SETUNA.Resources.Image.SampleImage.Width / 2), (this.imgScrap.Height / 2) - (SETUNA.Resources.Image.SampleImage.Height / 2));
            }
            this.UpdateLine();
        }

        private void UpdateLine()
        {
            if (this.imgScrap != null)
            {
                using (Graphics graphics = Graphics.FromImage(this.imgScrap))
                {
                    Pen pen = new Pen(this.picLineColor.BackColor);
                    if (this.rdoDashed.Checked)
                    {
                        pen.DashStyle = DashStyle.Dash;
                        pen.DashPattern = new float[] { 4f, 4f };
                    }
                    graphics.DrawRectangle(new Pen(Color.White), 0, 0, this.imgScrap.Width - 1, this.imgScrap.Height - 1);
                    graphics.DrawRectangle(pen, 0, 0, this.imgScrap.Width - 1, this.imgScrap.Height - 1);
                }
                this.picPreview.Refresh();
            }
        }
    }
}

