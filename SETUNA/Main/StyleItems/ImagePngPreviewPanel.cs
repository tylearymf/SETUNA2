using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200000C RID: 12
    internal partial class ImagePngPreviewPanel : ToolBoxForm
    {
        // Token: 0x060000B2 RID: 178 RVA: 0x000053FC File Offset: 0x000035FC
        public ImagePngPreviewPanel()
        {
        }

        // Token: 0x060000B3 RID: 179 RVA: 0x00005404 File Offset: 0x00003604
        public ImagePngPreviewPanel(CImagePngStyleItem item, Image img, ImageCodecInfo icodec) : base(item)
        {
            _img = img;
            _icodec = icodec;
            UpdatePreview();
        }

        // Token: 0x060000B4 RID: 180 RVA: 0x00005424 File Offset: 0x00003624
        protected override void SetStyleToForm(object style)
        {
            var cimagePngStyleItem = (CImagePngStyleItem)style;
            InitializeComponent();
            Text = cimagePngStyleItem.GetDisplayName();
            barQuality.Value = cimagePngStyleItem.Quality;
        }

        // Token: 0x060000B5 RID: 181 RVA: 0x0000545C File Offset: 0x0000365C
        protected override object GetStyleFromForm()
        {
            return new CImagePngStyleItem
            {
                Quality = barQuality.Value
            };
        }

        // Token: 0x060000B6 RID: 182 RVA: 0x00005481 File Offset: 0x00003681
        private void barQuality_Scroll(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        // Token: 0x060000B7 RID: 183 RVA: 0x0000548C File Offset: 0x0000368C
        protected void UpdatePreview()
        {
            if (_icodec == null)
            {
                return;
            }
            lblQuality.Text = barQuality.Value.ToString();
            Stream stream = new MemoryStream();
            var encoderParameters = new EncoderParameters();
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, barQuality.Value);
            _img.Save(stream, _icodec, encoderParameters);
            picPreview.Image = new Bitmap(stream);
            stream.Close();
        }

        // Token: 0x060000B8 RID: 184 RVA: 0x00005514 File Offset: 0x00003714
        private void picPreview_MouseDown(object sender, MouseEventArgs e)
        {
            dragpt = new Point(e.X, e.Y);
            dragpt = picPreview.PointToScreen(dragpt);
            dragpt = panel1.PointToClient(dragpt);
            panel1.Capture = true;
            drag = true;
        }

        // Token: 0x060000B9 RID: 185 RVA: 0x00005579 File Offset: 0x00003779
        private void picPreview_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.Capture = false;
            drag = false;
        }

        // Token: 0x060000BA RID: 186 RVA: 0x00005590 File Offset: 0x00003790
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

        // Token: 0x04000052 RID: 82
        private Image _img;

        // Token: 0x04000055 RID: 85
        private ImageCodecInfo _icodec;

        // Token: 0x04000056 RID: 86
        private bool drag;

        // Token: 0x04000057 RID: 87
        private Point dragpt;
    }
}
