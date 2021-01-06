using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x0200000D RID: 13
    public class CImagePngStyleItem : CImageStyleItem
    {
        // Token: 0x060000BB RID: 187 RVA: 0x0000561A File Offset: 0x0000381A
        public CImagePngStyleItem()
        {
            Quality = 100;
            ShowPreview = true;
        }

        // Token: 0x060000BC RID: 188 RVA: 0x00005634 File Offset: 0x00003834
        protected override EncoderParameter[] GetEncoderParams(ref ScrapBase scrap)
        {
            return new List<EncoderParameter>
            {
                new EncoderParameter(Encoder.Quality, Quality)
            }.ToArray();
        }

        // Token: 0x060000BD RID: 189 RVA: 0x00005664 File Offset: 0x00003864
        protected override ImageFormat GetImageFormat()
        {
            return ImageFormat.Png;
        }

        // Token: 0x060000BE RID: 190 RVA: 0x0000566B File Offset: 0x0000386B
        public override string GetName()
        {
            return "ImagePng";
        }

        // Token: 0x060000BF RID: 191 RVA: 0x00005672 File Offset: 0x00003872
        public override string GetDisplayName()
        {
            return "保存为PNG格式";
        }

        // Token: 0x060000C0 RID: 192 RVA: 0x00005679 File Offset: 0x00003879
        public override string GetDescription()
        {
            return "用PNG格式的图像保存参考图。";
        }

        // Token: 0x060000C1 RID: 193 RVA: 0x00005680 File Offset: 0x00003880
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new ImagePngStyleItemPanel(this);
        }

        // Token: 0x060000C2 RID: 194 RVA: 0x00005688 File Offset: 0x00003888
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var cimagePngStyleItem = (CImagePngStyleItem)newOwn;
            SaveFolder = cimagePngStyleItem.SaveFolder;
            Quality = cimagePngStyleItem.Quality;
            ShowPreview = cimagePngStyleItem.ShowPreview;
            HaveMargin = cimagePngStyleItem.HaveMargin;
            CopyPath = cimagePngStyleItem.CopyPath;
            FileNameType = cimagePngStyleItem.FileNameType;
            DupliType = cimagePngStyleItem.DupliType;
            FileName = cimagePngStyleItem.FileName;
        }

        // Token: 0x17000038 RID: 56
        // (get) Token: 0x060000C3 RID: 195 RVA: 0x000056FC File Offset: 0x000038FC
        protected override string Extension => "png";

        // Token: 0x17000039 RID: 57
        // (get) Token: 0x060000C4 RID: 196 RVA: 0x00005703 File Offset: 0x00003903
        protected override string FileFilter => "Png格式(.png)|*.png|所有文件 (*.*)|*.*";

        // Token: 0x060000C5 RID: 197 RVA: 0x0000570A File Offset: 0x0000390A
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Png;
        }

        // Token: 0x04000058 RID: 88
        public int Quality;

        // Token: 0x04000059 RID: 89
        public bool ShowPreview;
    }
}
