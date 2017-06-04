namespace SETUNA.Main.StyleItems
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;

    internal class ImagePngPreviewPanel : ToolBoxForm
    {
        private ImageCodecInfo _icodec;
        private Image _img;
        private TrackBar barQuality;
        private bool drag;
        private Point dragpt;
        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox1;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label lblQuality;
        private Panel panel1;
        private PictureBox picPreview;

        public ImagePngPreviewPanel()
        {
        }

        public ImagePngPreviewPanel(CImagePngStyleItem item, Image img, ImageCodecInfo icodec) : base(item)
        {
            this._img = img;
            this._icodec = icodec;
            this.UpdatePreview();
        }

        private void barQuality_Scroll(object sender, EventArgs e)
        {
            this.UpdatePreview();
        }

        protected override object GetStyleFromForm() => 
            new CImagePngStyleItem { Quality = this.barQuality.Value };

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.panel1 = new Panel();
            this.picPreview = new PictureBox();
            this.label6 = new Label();
            this.label5 = new Label();
            this.lblQuality = new Label();
            this.barQuality = new TrackBar();
            this.label3 = new Label();
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.picPreview).BeginInit();
            this.barQuality.BeginInit();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0x7c, 0xd6);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0xc6, 0xd6);
            this.groupBox1.Controls.Add(this.barQuality);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblQuality);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x105, 0xc6);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.panel1.BorderStyle = BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.picPreview);
            this.panel1.Location = new Point(13, 0x12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0xe9, 0x77);
            this.panel1.TabIndex = 11;
            this.panel1.MouseMove += new MouseEventHandler(this.picPreview_MouseMove);
            this.panel1.MouseUp += new MouseEventHandler(this.picPreview_MouseUp);
            this.picPreview.Location = new Point(-2, -2);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new Size(0x5e, 0x47);
            this.picPreview.SizeMode = PictureBoxSizeMode.AutoSize;
            this.picPreview.TabIndex = 11;
            this.picPreview.TabStop = false;
            this.picPreview.MouseDown += new MouseEventHandler(this.picPreview_MouseDown);
            this.picPreview.MouseUp += new MouseEventHandler(this.picPreview_MouseUp);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(200, 0xb1);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x17, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "100";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x3d, 0xb1);
            this.label5.Name = "label5";
            this.label5.Size = new Size(11, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "0";
            this.lblQuality.Location = new Point(0xe0, 0x94);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new Size(0x18, 12);
            this.lblQuality.TabIndex = 7;
            this.lblQuality.Text = "100";
            this.lblQuality.TextAlign = ContentAlignment.TopRight;
            this.barQuality.AutoSize = false;
            this.barQuality.Location = new Point(0x34, 0x8f);
            this.barQuality.Maximum = 100;
            this.barQuality.Name = "barQuality";
            this.barQuality.Size = new Size(0xad, 0x21);
            this.barQuality.TabIndex = 6;
            this.barQuality.TickFrequency = 10;
            this.barQuality.ValueChanged += new EventHandler(this.barQuality_Scroll);
            this.barQuality.Scroll += new EventHandler(this.barQuality_Scroll);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(11, 0x94);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1f, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "质量：";
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.ApplicationData;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x114, 0xf6);
            base.Controls.Add(this.groupBox1);
            base.Name = "ImageJpegPreviewPanel";
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((ISupportInitialize) this.picPreview).EndInit();
            this.barQuality.EndInit();
            base.ResumeLayout(false);
        }

        private void picPreview_MouseDown(object sender, MouseEventArgs e)
        {
            this.dragpt = new Point(e.X, e.Y);
            this.dragpt = this.picPreview.PointToScreen(this.dragpt);
            this.dragpt = this.panel1.PointToClient(this.dragpt);
            this.panel1.Capture = true;
            this.drag = true;
        }

        private void picPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                int x = this.picPreview.Location.X - (this.dragpt.X - e.X);
                int y = this.picPreview.Location.Y - (this.dragpt.Y - e.Y);
                this.dragpt = new Point(e.X, e.Y);
                this.picPreview.SetBounds(x, y, 0, 0, BoundsSpecified.Location);
            }
        }

        private void picPreview_MouseUp(object sender, MouseEventArgs e)
        {
            this.panel1.Capture = false;
            this.drag = false;
        }

        protected override void SetStyleToForm(object style)
        {
            CImagePngStyleItem item = (CImagePngStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
            this.barQuality.Value = item.Quality;
        }

        protected void UpdatePreview()
        {
            if (this._icodec != null)
            {
                this.lblQuality.Text = this.barQuality.Value.ToString();
                Stream stream = new MemoryStream();
                EncoderParameters encoderParams = new EncoderParameters();
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long) this.barQuality.Value);
                this._img.Save(stream, this._icodec, encoderParams);
                this.picPreview.Image = new Bitmap(stream);
                stream.Close();
            }
        }
    }
}

