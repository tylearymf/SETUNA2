using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000091 RID: 145
    internal partial class ImageJpegPreviewPanel : ToolBoxForm
    {
        // Token: 0x060004C7 RID: 1223 RVA: 0x0002170F File Offset: 0x0001F90F
        public ImageJpegPreviewPanel()
        {
            tempimg = "";
        }

        // Token: 0x060004C8 RID: 1224 RVA: 0x00021724 File Offset: 0x0001F924
        ~ImageJpegPreviewPanel()
        {
            if (_img != null)
            {
                _img.Dispose();
            }
        }

        // Token: 0x060004C9 RID: 1225 RVA: 0x00021760 File Offset: 0x0001F960
        public ImageJpegPreviewPanel(CImageJpegStyleItem item, Image img, ImageCodecInfo icodec) : base(item)
        {
            _img = img;
            _icodec = icodec;
            UpdatePreview();
        }

        // Token: 0x060004CA RID: 1226 RVA: 0x00021780 File Offset: 0x0001F980
        protected override void SetStyleToForm(object style)
        {
            var cimageJpegStyleItem = (CImageJpegStyleItem)style;
            InitializeComponent();
            Text = cimageJpegStyleItem.GetDisplayName();
            barQuality.Value = cimageJpegStyleItem.Quality;
            lastqvalue = barQuality.Value;
            try
            {
                tempimg = Path.GetTempFileName();
            }
            catch
            {
                tempimg = "";
            }
            timer1.Start();
        }

        // Token: 0x060004CB RID: 1227 RVA: 0x00021800 File Offset: 0x0001FA00
        protected override object GetStyleFromForm()
        {
            return new CImageJpegStyleItem
            {
                Quality = barQuality.Value
            };
        }

        // Token: 0x060004CC RID: 1228 RVA: 0x00021825 File Offset: 0x0001FA25
        private void barQuality_Scroll(object sender, EventArgs e)
        {
        }

        // Token: 0x060004CD RID: 1229 RVA: 0x00021828 File Offset: 0x0001FA28
        protected int UpdatePreview()
        {
            var value = barQuality.Value;
            if (_icodec == null)
            {
                return value;
            }
            lblQuality.Text = barQuality.Value.ToString();
            Stream stream = new MemoryStream();
            var encoderParameters = new EncoderParameters();
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, value);
            _img.Save(stream, _icodec, encoderParameters);
            picPreview.Image = new Bitmap(stream);
            stream.Close();
            lblSize.Text = "";
            if (tempimg != "")
            {
                try
                {
                    _img.Save(tempimg, _icodec, encoderParameters);
                    if (!File.Exists(tempimg))
                    {
                        throw new Exception("缺少临时文件");
                    }
                    var fileInfo = new FileInfo(tempimg);
                    lblSize.Text = (fileInfo.Length / 1024f).ToString("#,#.0") + " KB";
                }
                catch
                {
                    tempimg = "";
                }
            }
            return value;
        }

        // Token: 0x060004CE RID: 1230 RVA: 0x00021968 File Offset: 0x0001FB68
        private void picPreview_MouseDown(object sender, MouseEventArgs e)
        {
            dragpt = new Point(e.X, e.Y);
            dragpt = picPreview.PointToScreen(dragpt);
            dragpt = panel1.PointToClient(dragpt);
            panel1.Capture = true;
            drag = true;
        }

        // Token: 0x060004CF RID: 1231 RVA: 0x000219CD File Offset: 0x0001FBCD
        private void picPreview_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            drag = false;
        }

        // Token: 0x060004D0 RID: 1232 RVA: 0x000219E4 File Offset: 0x0001FBE4
        private void picPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                var x = picPreview.Location.X - (dragpt.X - e.X);
                var y = picPreview.Location.Y - (dragpt.Y - e.Y);
                dragpt = new Point(e.X, e.Y);
                picPreview.SetBounds(x, y, 0, 0, BoundsSpecified.Location);
            }
        }

        // Token: 0x060004D1 RID: 1233 RVA: 0x00021A70 File Offset: 0x0001FC70
        private void ImageJpegPreviewPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (tempimg != "" && File.Exists(tempimg))
                {
                    File.Delete(tempimg);
                }
                timer1.Stop();
            }
            catch
            {
                tempimg = "";
            }
        }

        // Token: 0x060004D2 RID: 1234 RVA: 0x00021AD4 File Offset: 0x0001FCD4
        private void timer1_Tick(object sender, EventArgs e)
        {
            var value = barQuality.Value;
            if (value != lastqvalue)
            {
                lastqvalue = UpdatePreview();
            }
        }

        // Token: 0x04000302 RID: 770
        private Image _img;

        // Token: 0x04000305 RID: 773
        private ImageCodecInfo _icodec;

        // Token: 0x04000306 RID: 774
        private bool drag;

        // Token: 0x04000307 RID: 775
        private Point dragpt;

        // Token: 0x0400030B RID: 779
        private string tempimg;

        // Token: 0x0400030C RID: 780
        private int lastqvalue;
    }
}
