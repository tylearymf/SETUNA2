using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x0200008B RID: 139
    public class CImageBmpStyleItem : CImageStyleItem
    {
        // Token: 0x06000481 RID: 1153 RVA: 0x0001D84C File Offset: 0x0001BA4C
        protected override EncoderParameter[] GetEncoderParams(ref ScrapBase scrap)
        {
            return new List<EncoderParameter>
            {
                new EncoderParameter(Encoder.Quality, 100)
            }.ToArray();
        }

        // Token: 0x06000482 RID: 1154 RVA: 0x0001D877 File Offset: 0x0001BA77
        protected override ImageFormat GetImageFormat()
        {
            return ImageFormat.Bmp;
        }

        // Token: 0x06000483 RID: 1155 RVA: 0x0001D87E File Offset: 0x0001BA7E
        public override string GetName()
        {
            return "ImageBmp";
        }

        // Token: 0x06000484 RID: 1156 RVA: 0x0001D885 File Offset: 0x0001BA85
        public override string GetDisplayName()
        {
            return "保存为BMP格式";
        }

        // Token: 0x06000485 RID: 1157 RVA: 0x0001D88C File Offset: 0x0001BA8C
        public override string GetDescription()
        {
            return "用BMP格式的图像保存参考图。";
        }

        // Token: 0x06000486 RID: 1158 RVA: 0x0001D893 File Offset: 0x0001BA93
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new ImageBmpStyleItemPanel(this);
        }

        // Token: 0x06000487 RID: 1159 RVA: 0x0001D89C File Offset: 0x0001BA9C
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var cimageBmpStyleItem = (CImageBmpStyleItem)newOwn;
            SaveFolder = cimageBmpStyleItem.SaveFolder;
            HaveMargin = cimageBmpStyleItem.HaveMargin;
            CopyPath = cimageBmpStyleItem.CopyPath;
            FileNameType = cimageBmpStyleItem.FileNameType;
            DupliType = cimageBmpStyleItem.DupliType;
            FileName = cimageBmpStyleItem.FileName;
        }

        // Token: 0x170000AC RID: 172
        // (get) Token: 0x06000488 RID: 1160 RVA: 0x0001D8F8 File Offset: 0x0001BAF8
        protected override string Extension => "bmp";

        // Token: 0x170000AD RID: 173
        // (get) Token: 0x06000489 RID: 1161 RVA: 0x0001D8FF File Offset: 0x0001BAFF
        protected override string FileFilter => "Bitmap格式 (.bmp)|*.bmp|所有文件 (*.*)|*.*";

        // Token: 0x0600048A RID: 1162 RVA: 0x0001D906 File Offset: 0x0001BB06
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Bmp;
        }
    }
}
