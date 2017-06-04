namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using SETUNA.Properties;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class CImagePngStyleItem : CImageStyleItem
    {
        public int Quality = 100;
        public bool ShowPreview = true;

        public override string GetDescription() => 
            "用PNG格式的图像保存参考图。";

        public override string GetDisplayName() => 
            "保存为PNG格式";

        protected override EncoderParameter[] GetEncoderParams(ref ScrapBase scrap)
        {
            List<EncoderParameter> list = new List<EncoderParameter> {
                new EncoderParameter(Encoder.Quality, (long) this.Quality)
            };
            return list.ToArray();
        }

        public override Bitmap GetIcon() => 
            Resources.Icon_Png;

        protected override ImageFormat GetImageFormat() => 
            ImageFormat.Png;

        public override string GetName() => 
            "ImagePng";

        protected override ToolBoxForm GetToolBoxForm() => 
            new ImagePngStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CImagePngStyleItem item = (CImagePngStyleItem) newOwn;
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
            "png";

        protected override string FileFilter =>
            "Png格式(.png)|*.png|所有文件 (*.*)|*.*";
    }
}

