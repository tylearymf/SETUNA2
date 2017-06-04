namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using SETUNA.Properties;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public class CImageJpegStyleItem : CImageStyleItem
    {
        public int Quality = 100;
        public bool ShowPreview = true;

        public override string GetDescription() => 
            "用JPEG格式的图像保存参考图。";

        public override string GetDisplayName() => 
            "保存为JPEG格式";

        protected override EncoderParameter[] GetEncoderParams(ref ScrapBase scrap)
        {
            List<EncoderParameter> list = new List<EncoderParameter>();
            if (this.ShowPreview)
            {
                ImageJpegPreviewPanel panel;
                if (base.HaveMargin)
                {
                    panel = new ImageJpegPreviewPanel(this, scrap.GetViewImage(), base.GetImageCodecInfo());
                }
                else
                {
                    panel = new ImageJpegPreviewPanel(this, (Bitmap) scrap.Image.Clone(), base.GetImageCodecInfo());
                }
                if (panel.ShowDialog(scrap) != DialogResult.OK)
                {
                    return null;
                }
                CImageJpegStyleItem styleItem = (CImageJpegStyleItem) panel.StyleItem;
                list.Add(new EncoderParameter(Encoder.Quality, (long) styleItem.Quality));
            }
            else
            {
                list.Add(new EncoderParameter(Encoder.Quality, (long) this.Quality));
            }
            return list.ToArray();
        }

        public override Bitmap GetIcon() => 
            Resources.Icon_Jpeg;

        protected override ImageFormat GetImageFormat() => 
            ImageFormat.Jpeg;

        public override string GetName() => 
            "ImageJpeg";

        protected override ToolBoxForm GetToolBoxForm() => 
            new ImageJpegStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CImageJpegStyleItem item = (CImageJpegStyleItem) newOwn;
            base.SaveFolder = item.SaveFolder;
            this.Quality = item.Quality;
            this.ShowPreview = item.ShowPreview;
            base.HaveMargin = item.HaveMargin;
            base.CopyPath = item.CopyPath;
            base.FileNameType = item.FileNameType;
            base.DupliType = item.DupliType;
            base.FileName = item.FileName;
        }

        protected override string Extension =>
            "jpg";

        protected override string FileFilter =>
            "Jpeg格式 (.jpg)|*.jpg|所有文件 (*.*)|*.*";
    }
}

