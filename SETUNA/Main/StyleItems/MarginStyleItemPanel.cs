namespace SETUNA.Main.StyleItems
{
    using Properties;
    using SETUNA.Main.Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    internal class MarginStyleItemPanel : ToolBoxForm
    {
        private CheckBox chkTopMost;
        private ColorDialog colorDialog1;
        private Form frmPrev;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private System.Drawing.Image imgBackground;
        private System.Drawing.Image imgScrap;
        private Label label1;
        private Label label2;
        private NumericUpDown numMargin;
        private PictureBox picPreview;
        private PictureBox picSample;
        private PictureBox pictureBox1;
        private RadioButton rdo3D;
        private RadioButton rdoSolid;
        private RadioButton rdoWindow;
        private LayerInfo mLayerInfo;

        public MarginStyleItemPanel(CMarginStyleItem style) : base(style)
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

        protected override object GetStyleFromForm()
        {
            CMarginStyleItem item = new CMarginStyleItem {
                MarginSize = (int) this.numMargin.Value
            };
            item.SetMarginColor(this.pictureBox1.BackColor);
            if (this.rdoWindow.Checked)
            {
                item.BorderStyle = 2;
            }
            else if (this.rdoSolid.Checked)
            {
                item.BorderStyle = 1;
            }
            else if (this.rdo3D.Checked)
            {
                item.BorderStyle = 0;
            }
            item.TopMost = this.chkTopMost.Checked;
            return item;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.rdoSolid = new RadioButton();
            this.rdo3D = new RadioButton();
            this.rdoWindow = new RadioButton();
            this.pictureBox1 = new PictureBox();
            this.label2 = new Label();
            this.label1 = new Label();
            this.numMargin = new NumericUpDown();
            this.colorDialog1 = new ColorDialog();
            this.groupBox2 = new GroupBox();
            this.picPreview = new PictureBox();
            this.chkTopMost = new CheckBox();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            this.numMargin.BeginInit();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.picPreview).BeginInit();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(300, 0xd6);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x178, 0xd6);
            this.groupBox1.Controls.Add(this.chkTopMost);
            this.groupBox1.Controls.Add(this.rdoSolid);
            this.groupBox1.Controls.Add(this.rdo3D);
            this.groupBox1.Controls.Add(this.rdoWindow);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numMargin);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xcf, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.rdoSolid.AutoSize = true;
            this.rdoSolid.Location = new Point(0x11, 0x4f);
            this.rdoSolid.Name = "rdoSolid";
            this.rdoSolid.Size = new Size(0x3b, 0x10);
            this.rdoSolid.TabIndex = 1;
            this.rdoSolid.TabStop = true;
            this.rdoSolid.Text = "单色边框";
            this.rdoSolid.UseVisualStyleBackColor = true;
            this.rdoSolid.CheckedChanged += new EventHandler(this.rdoWindow_CheckedChanged);
            this.rdo3D.AutoSize = true;
            this.rdo3D.Location = new Point(0x11, 0x9c);
            this.rdo3D.Name = "rdo3D";
            this.rdo3D.Size = new Size(0x3b, 0x10);
            this.rdo3D.TabIndex = 5;
            this.rdo3D.TabStop = true;
            this.rdo3D.Text = "立体边框";
            this.rdo3D.UseVisualStyleBackColor = true;
            this.rdo3D.CheckedChanged += new EventHandler(this.rdoWindow_CheckedChanged);
            this.rdoWindow.AutoSize = true;
            this.rdoWindow.Location = new Point(0x11, 0x1b);
            this.rdoWindow.Name = "rdoWindow";
            this.rdoWindow.Size = new Size(80, 0x10);
            this.rdoWindow.TabIndex = 0;
            this.rdoWindow.TabStop = true;
            this.rdoWindow.Text = "窗口边框";
            this.rdoWindow.UseVisualStyleBackColor = true;
            this.rdoWindow.CheckedChanged += new EventHandler(this.rdoWindow_CheckedChanged);
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = Cursors.Hand;
            this.pictureBox1.Location = new Point(0x5d, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x20, 0x13);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x35, 0x7a);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x22, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "颜色∶";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x35, 0x62);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x13, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "宽度：";
            this.numMargin.ImeMode = ImeMode.Off;
            this.numMargin.Location = new Point(0x5d, 0x60);
            this.numMargin.Name = "numMargin";
            this.numMargin.Size = new Size(0x30, 0x13);
            this.numMargin.TabIndex = 3;
            this.numMargin.TextAlign = HorizontalAlignment.Right;
            this.numMargin.ValueChanged += new EventHandler(this.rdoWindow_CheckedChanged);
            this.groupBox2.Controls.Add(this.picPreview);
            this.groupBox2.Location = new Point(0xe7, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xd7, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            this.picPreview.BorderStyle = BorderStyle.Fixed3D;
            this.picPreview.Location = new Point(6, 0x12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new Size(0xcb, 0xb0);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new PaintEventHandler(this.picPreview_Paint);
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new Point(0x24, 0x2e);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new Size(0x72, 0x10);
            this.chkTopMost.TabIndex = 11;
            this.chkTopMost.Text = "设置为总在最上面";
            this.chkTopMost.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x1c6, 0xf6);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Name = "MarginStyleItemPanel";
            base.FormClosed += new FormClosedEventHandler(this.MarginStyleItemPanel_FormClosed);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            base.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            this.numMargin.EndInit();
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.picPreview).EndInit();
            base.ResumeLayout(false);
        }

        private void MarginStyleItemPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.imgBackground != null)
            {
                this.imgBackground.Dispose();
                this.imgBackground = null;
                GC.Collect();
            }
        }

        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            if (this.imgBackground != null)
            {
                e.Graphics.DrawImageUnscaled(this.imgBackground, new Point(0, 0));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.BackColor = this.colorDialog1.Color;
                this.rdoWindow_CheckedChanged(null, null);
            }
        }

        private void rdoWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoWindow.Checked)
            {
                this.frmPrev.FormBorderStyle = FormBorderStyle.FixedDialog;
            }
            else if (this.rdoSolid.Checked)
            {
                this.frmPrev.FormBorderStyle = FormBorderStyle.None;
            }
            else if (this.rdo3D.Checked)
            {
                this.frmPrev.FormBorderStyle = FormBorderStyle.None;
            }
            this.ResizeSample();
        }

        private void ResizeSample()
        {
            if (this.frmPrev != null)
            {
                this.frmPrev.MinimizeBox = false;
                this.frmPrev.MaximizeBox = false;
                this.frmPrev.ControlBox = false;
                if (this.rdoWindow.Checked)
                {
                    this.frmPrev.ClientSize = new Size(this.picSample.Width + 1, this.picSample.Height + 1);
                    this.frmPrev.BackColor = SystemColors.Control;
                    this.picSample.Left = 0;
                    this.picSample.Top = 0;
                }
                else if (this.rdoSolid.Checked)
                {
                    this.frmPrev.ClientSize = new Size(this.picSample.Width + (((int) this.numMargin.Value) * 2), this.picSample.Height + (((int) this.numMargin.Value) * 2));
                    this.frmPrev.BackColor = this.pictureBox1.BackColor;
                    this.picSample.Left = (int) this.numMargin.Value;
                    this.picSample.Top = (int) this.numMargin.Value;
                }
                else if (this.rdo3D.Checked)
                {
                    this.frmPrev.ClientSize = new Size(this.picSample.Width + 2, this.picSample.Height + 2);
                    this.frmPrev.BackColor = Color.FromArgb(0x19, 0x19, 0x19);
                    this.picSample.Left = 1;
                    this.picSample.Top = 1;
                }
                this.frmPrev.Left = (this.picPreview.Width - this.frmPrev.Width) / 2;
                this.frmPrev.Top = (this.picPreview.Height - this.frmPrev.Height) / 2;
                this.frmPrev.Refresh();
            }
        }

        private void Sample_Paint(object sender, PaintEventArgs e)
        {
            if (this.rdo3D.Checked)
            {
                using (Pen pen = new Pen(Color.FromArgb(0xf3, 0xf3, 0xf3)))
                {
                    e.Graphics.DrawLine(pen, 0, 0, 0, this.frmPrev.Height);
                    e.Graphics.DrawLine(pen, 0, 0, this.frmPrev.Width, 0);
                }
            }
        }

        protected override void SetStyleToForm(object style)
        {
            CMarginStyleItem item = (CMarginStyleItem) style;
            this.InitializeComponent();
            this.imgBackground = new Bitmap(this.picPreview.Width, this.picPreview.Height, PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(this.imgBackground))
            {
                graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), this.imgBackground.Size);
            }
            this.imgScrap = Properties.Image.SampleImage;
            this.picSample = new PictureBox();
            this.picSample.Image = this.imgScrap;
            this.picSample.Size = this.imgScrap.Size;
            this.frmPrev = new Form();
            this.frmPrev.TopLevel = false;
            this.frmPrev.Parent = this.picPreview;
            this.frmPrev.Text = "sample";
            this.frmPrev.Controls.Add(this.picSample);
            this.ResizeSample();
            this.frmPrev.Show();
            this.numMargin.Value = item.MarginSize;
            this.pictureBox1.BackColor = item.GetMarginColor();
            this.chkTopMost.Checked = item.TopMost;
            switch (item.BorderStyle)
            {
                case 0:
                    this.rdo3D.Checked = true;
                    break;

                case 1:
                    this.rdoSolid.Checked = true;
                    break;

                case 2:
                    this.rdoWindow.Checked = true;
                    break;

                default:
                    throw new Exception();
            }
            this.Text = item.GetDisplayName();
            this.rdoWindow_CheckedChanged(null, null);
            this.frmPrev.Paint += new PaintEventHandler(this.Sample_Paint);
        }
    }
}

