namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main.Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;

    internal class ImageJpegPreviewPanel : ToolBoxForm
    {
        private ImageCodecInfo _icodec;
        private Image _img;
        private TrackBar barQuality;
        private IContainer components;
        private bool drag;
        private Point dragpt;
        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox1;
        private Label label3;
        private Label label5;
        private Label label6;
        private int lastqvalue;
        private Label lblQuality;
        private Label lblSize;
        private Panel panel1;
        private PictureBox picPreview;
        private string tempimg;
        private Timer timer1;
        private LayerInfo mLayerInfo;

        public ImageJpegPreviewPanel()
        {
            this.tempimg = "";
        }

        public ImageJpegPreviewPanel(CImageJpegStyleItem item, Image img, ImageCodecInfo icodec) : base(item)
        {
            this._img = img;
            this._icodec = icodec;
            this.UpdatePreview();
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
        }

        private void barQuality_Scroll(object sender, EventArgs e)
        {
        }

        ~ImageJpegPreviewPanel()
        {
            if (this._img != null)
            {
                this._img.Dispose();
            }
        }

        protected override object GetStyleFromForm() => 
            new CImageJpegStyleItem { Quality = this.barQuality.Value };

        private void ImageJpegPreviewPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if ((this.tempimg != "") && File.Exists(this.tempimg))
                {
                    File.Delete(this.tempimg);
                }
                this.timer1.Stop();
            }
            catch
            {
                this.tempimg = "";
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.groupBox1 = new GroupBox();
            this.barQuality = new TrackBar();
            this.panel1 = new Panel();
            this.picPreview = new PictureBox();
            this.label6 = new Label();
            this.label5 = new Label();
            this.lblQuality = new Label();
            this.label3 = new Label();
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.lblSize = new Label();
            this.timer1 = new Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.barQuality.BeginInit();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.picPreview).BeginInit();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0xfb, 0x150);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x145, 0x150);
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.barQuality);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblQuality);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x182, 0x141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.barQuality.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.barQuality.AutoSize = false;
            this.barQuality.Location = new Point(0x34, 0x107);
            this.barQuality.Maximum = 100;
            this.barQuality.Name = "barQuality";
            this.barQuality.Size = new Size(0xad, 0x21);
            this.barQuality.TabIndex = 2;
            this.barQuality.TickFrequency = 10;
            this.barQuality.ValueChanged += new EventHandler(this.barQuality_Scroll);
            this.barQuality.Scroll += new EventHandler(this.barQuality_Scroll);
            this.panel1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.panel1.BorderStyle = BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.picPreview);
            this.panel1.Location = new Point(13, 0x12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x169, 0xef);
            this.panel1.TabIndex = 0;
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
            this.label6.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(200, 0x129);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x17, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "100";
            this.label5.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x3d, 0x129);
            this.label5.Name = "label5";
            this.label5.Size = new Size(11, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "0";
            this.lblQuality.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.lblQuality.Location = new Point(0xe0, 0x10c);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new Size(0x18, 12);
            this.lblQuality.TabIndex = 3;
            this.lblQuality.Text = "100";
            this.lblQuality.TextAlign = ContentAlignment.TopRight;
            this.label3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(11, 0x10c);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1f, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "质量：";
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.ApplicationData;
            this.lblSize.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            this.lblSize.Location = new Point(6, 0x150);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new Size(0xef, 0x18);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "120K";
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x193, 0x170);
            base.Controls.Add(this.lblSize);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new Size(290, 280);
            base.Name = "ImageJpegPreviewPanel";
            base.FormClosed += new FormClosedEventHandler(this.ImageJpegPreviewPanel_FormClosed);
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            base.Controls.SetChildIndex(this.lblSize, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.barQuality.EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((ISupportInitialize) this.picPreview).EndInit();
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
            CImageJpegStyleItem item = (CImageJpegStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
            this.barQuality.Value = item.Quality;
            this.lastqvalue = this.barQuality.Value;
            try
            {
                this.tempimg = Path.GetTempFileName();
            }
            catch
            {
                this.tempimg = "";
            }
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.barQuality.Value != this.lastqvalue)
            {
                this.lastqvalue = this.UpdatePreview();
            }
        }

        protected int UpdatePreview()
        {
            int num = this.barQuality.Value;
            if (this._icodec != null)
            {
                this.lblQuality.Text = this.barQuality.Value.ToString();
                Stream stream = new MemoryStream();
                EncoderParameters encoderParams = new EncoderParameters();
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long) num);
                this._img.Save(stream, this._icodec, encoderParams);
                this.picPreview.Image = new Bitmap(stream);
                stream.Close();
                this.lblSize.Text = "";
                if (this.tempimg == "")
                {
                    return num;
                }
                try
                {
                    this._img.Save(this.tempimg, this._icodec, encoderParams);
                    if (!File.Exists(this.tempimg))
                    {
                        throw new Exception("缺少临时文件");
                    }
                    FileInfo info = new FileInfo(this.tempimg);
                    this.lblSize.Text = ((((float) info.Length) / 1024f)).ToString("#,#.0") + " KB";
                    return num;
                }
                catch
                {
                    this.tempimg = "";
                }
            }
            return num;
        }
    }
}

