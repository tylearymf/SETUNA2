namespace SETUNA.Main.StyleItems
{
    using Properties;
    using SETUNA.Main.Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    internal class RotateStyleItemPanel : ToolBoxForm
    {
        private CheckBox chkHorizon;
        private CheckBox chkVertical;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private System.Drawing.Image imgBackground;
        private System.Drawing.Image imgScrap;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private PictureBox picPreview;
        private RadioButton rdo180;
        private RadioButton rdoLeft90;
        private RadioButton rdoNone;
        private RadioButton rdoRight90;
        private LayerInfo mLayerInfo;

        public RotateStyleItemPanel()
        {
        }

        public RotateStyleItemPanel(CRotateStyleItem item) : base(item)
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
            CRotateStyleItem item = new CRotateStyleItem();
            if (this.rdoRight90.Checked)
            {
                item.Rotate = 90;
            }
            else if (this.rdo180.Checked)
            {
                item.Rotate = 180;
            }
            else if (this.rdoLeft90.Checked)
            {
                item.Rotate = 270;
            }
            else
            {
                item.Rotate = 0;
            }
            item.VerticalReflection = this.chkVertical.Checked;
            item.HorizonReflection = this.chkHorizon.Checked;
            return item;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.chkHorizon = new CheckBox();
            this.chkVertical = new CheckBox();
            this.label2 = new Label();
            this.panel1 = new Panel();
            this.rdo180 = new RadioButton();
            this.rdoLeft90 = new RadioButton();
            this.rdoRight90 = new RadioButton();
            this.rdoNone = new RadioButton();
            this.label1 = new Label();
            this.groupBox2 = new GroupBox();
            this.picPreview = new PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.picPreview).BeginInit();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0x12b, 0xae);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x178, 0xae);
            this.groupBox1.Controls.Add(this.chkHorizon);
            this.groupBox1.Controls.Add(this.chkVertical);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xf7, 0x9d);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.chkHorizon.AutoSize = true;
            this.chkHorizon.Location = new Point(0x84, 60);
            this.chkHorizon.Name = "chkHorizon";
            this.chkHorizon.Size = new Size(0x69, 0x10);
            this.chkHorizon.TabIndex = 11;
            this.chkHorizon.Text = "水平翻转";
            this.chkHorizon.UseVisualStyleBackColor = true;
            this.chkHorizon.CheckedChanged += new EventHandler(this.rdoNone_CheckedChanged);
            this.chkVertical.AutoSize = true;
            this.chkVertical.Location = new Point(0x84, 0x2b);
            this.chkVertical.Name = "chkVertical";
            this.chkVertical.Size = new Size(0x69, 0x10);
            this.chkVertical.TabIndex = 10;
            this.chkVertical.Text = "垂直翻转";
            this.chkVertical.UseVisualStyleBackColor = true;
            this.chkVertical.CheckedChanged += new EventHandler(this.rdoNone_CheckedChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x72, 0x19);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x52, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "翻转参考图∶";
            this.panel1.Controls.Add(this.rdo180);
            this.panel1.Controls.Add(this.rdoLeft90);
            this.panel1.Controls.Add(this.rdoRight90);
            this.panel1.Controls.Add(this.rdoNone);
            this.panel1.Location = new Point(0x16, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x56, 0x61);
            this.panel1.TabIndex = 1;
            this.rdo180.AutoSize = true;
            this.rdo180.Location = new Point(3, 0x4a);
            this.rdo180.Name = "rdo180";
            this.rdo180.Size = new Size(0x35, 0x10);
            this.rdo180.TabIndex = 3;
            this.rdo180.Text = "180度";
            this.rdo180.UseVisualStyleBackColor = true;
            this.rdo180.CheckedChanged += new EventHandler(this.rdoNone_CheckedChanged);
            this.rdoLeft90.AutoSize = true;
            this.rdoLeft90.Location = new Point(3, 0x34);
            this.rdoLeft90.Name = "rdoLeft90";
            this.rdoLeft90.Size = new Size(0x44, 0x10);
            this.rdoLeft90.TabIndex = 2;
            this.rdoLeft90.Text = "左转90度";
            this.rdoLeft90.UseVisualStyleBackColor = true;
            this.rdoLeft90.CheckedChanged += new EventHandler(this.rdoNone_CheckedChanged);
            this.rdoRight90.AutoSize = true;
            this.rdoRight90.Location = new Point(3, 30);
            this.rdoRight90.Name = "rdoRight90";
            this.rdoRight90.Size = new Size(0x44, 0x10);
            this.rdoRight90.TabIndex = 1;
            this.rdoRight90.Text = "右转90度";
            this.rdoRight90.UseVisualStyleBackColor = true;
            this.rdoRight90.CheckedChanged += new EventHandler(this.rdoNone_CheckedChanged);
            this.rdoNone.AutoSize = true;
            this.rdoNone.Checked = true;
            this.rdoNone.Location = new Point(3, 8);
            this.rdoNone.Name = "rdoNone";
            this.rdoNone.Size = new Size(0x2a, 0x10);
            this.rdoNone.TabIndex = 0;
            this.rdoNone.TabStop = true;
            this.rdoNone.Text = "无";
            this.rdoNone.UseVisualStyleBackColor = true;
            this.rdoNone.CheckedChanged += new EventHandler(this.rdoNone_CheckedChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 0x19);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x52, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "旋转参考图：";
            this.groupBox2.Controls.Add(this.picPreview);
            this.groupBox2.Location = new Point(0x105, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xb3, 0x9d);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            this.picPreview.BorderStyle = BorderStyle.Fixed3D;
            this.picPreview.Location = new Point(6, 0x12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new Size(0xa7, 0x83);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new PaintEventHandler(this.picPreview_Paint);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x1c5, 0xce);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Name = "RotateStyleItemPanel";
            base.FormClosed += new FormClosedEventHandler(this.RotateStyleItemPanel_FormClosed);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            base.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.picPreview).EndInit();
            base.ResumeLayout(false);
        }

        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            if (this.imgBackground != null)
            {
                e.Graphics.DrawImageUnscaled(this.imgBackground, new Point(0, 0));
            }
            if (this.imgScrap != null)
            {
                e.Graphics.DrawImage(this.imgScrap, new Rectangle((this.imgBackground.Width - this.imgScrap.Width) / 2, (this.imgBackground.Height - this.imgScrap.Height) / 2, this.imgScrap.Width, this.imgScrap.Height), new Rectangle(0, 0, this.imgScrap.Width, this.imgScrap.Height), GraphicsUnit.Pixel);
            }
        }

        private void rdoNone_CheckedChanged(object sender, EventArgs e)
        {
            this.RotateSample();
        }

        private void RotateSample()
        {
            if (this.imgScrap != null)
            {
                this.imgScrap.Dispose();
            }
            this.imgScrap = (System.Drawing.Image) Properties.Image.SampleImage.Clone();
            if (this.rdoRight90.Checked)
            {
                this.imgScrap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            if (this.rdo180.Checked)
            {
                this.imgScrap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            if (this.rdoLeft90.Checked)
            {
                this.imgScrap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            if (this.chkHorizon.Checked)
            {
                this.imgScrap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            if (this.chkVertical.Checked)
            {
                this.imgScrap.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            this.picPreview.Refresh();
        }

        private void RotateStyleItemPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.imgBackground != null)
            {
                this.imgBackground.Dispose();
                this.imgBackground = null;
                this.imgScrap.Dispose();
                this.imgScrap = null;
                GC.Collect();
            }
        }

        protected override void SetStyleToForm(object style)
        {
            CRotateStyleItem item = (CRotateStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
            switch (item.Rotate)
            {
                case 90:
                    this.rdoRight90.Checked = true;
                    break;

                case 180:
                    this.rdo180.Checked = true;
                    break;

                case 270:
                    this.rdoLeft90.Checked = true;
                    break;

                default:
                    this.rdoNone.Checked = true;
                    break;
            }
            this.chkVertical.Checked = item.VerticalReflection;
            this.chkHorizon.Checked = item.HorizonReflection;
            this.imgBackground = new Bitmap(this.picPreview.Width, this.picPreview.Height, PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(this.imgBackground))
            {
                graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), this.imgBackground.Size);
            }
            this.imgScrap = (System.Drawing.Image) Properties.Image.SampleImage.Clone();
            this.RotateSample();
        }
    }
}

