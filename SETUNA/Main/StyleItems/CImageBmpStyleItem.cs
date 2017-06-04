namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using SETUNA.Properties;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class CImageBmpStyleItem : CImageStyleItem
    {
        public override string GetDescription() => 
            "用BMP格式的图像保存参考图。";

        public override string GetDisplayName() => 
            "保存为BMP格式";

        protected override EncoderParameter[] GetEncoderParams(ref ScrapBase scrap)
        {
            List<EncoderParameter> list = new List<EncoderParameter> {
                new EncoderParameter(Encoder.Quality, 100)
            };
            return list.ToArray();
        }

        public override Bitmap GetIcon() => 
            Resources.Icon_Bmp;

        protected override ImageFormat GetImageFormat() => 
            ImageFormat.Bmp;

        public override string GetName() => 
            "ImageBmp";

        protected override ToolBoxForm GetToolBoxForm() => 
            new ImageBmpStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CImageBmpStyleItem item = (CImageBmpStyleItem) newOwn;
            base.SaveFolder = item.SaveFolder;
            base.HaveMargin = item.HaveMargin;
            base.CopyPath = item.CopyPath;
            base.FileNameType = item.FileNameType;
            base.DupliType = item.DupliType;
            base.FileName = item.FileName;
        }

        protected override string Extension =>
            "bmp";

        protected override string FileFilter =>
            "Bitmap格式 (.bmp)|*.bmp|所有文件 (*.*)|*.*";
    }
}

