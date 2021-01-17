using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200000E RID: 14
    public abstract class CImageStyleItem : CStyleItem
    {
        static PixelFormat[] indexedPixelFormats = { PixelFormat.Undefined, PixelFormat.DontCare, PixelFormat.Format16bppArgb1555, PixelFormat.Format1bppIndexed, PixelFormat.Format4bppIndexed, PixelFormat.Format8bppIndexed };

        // Token: 0x060000C6 RID: 198 RVA: 0x00005711 File Offset: 0x00003911
        public CImageStyleItem()
        {
            HaveMargin = false;
            CopyPath = false;
            FileNameType = CImageStyleItem.EnumFileName.SaveAs;
            DupliType = CImageStyleItem.EnumDupliType.OverWrite;
        }

        // Token: 0x060000C7 RID: 199 RVA: 0x00005738 File Offset: 0x00003938
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            Bitmap bitmap = null;
            Graphics graphics = null;
            var text = "";
            try
            {
                if (HaveMargin)
                {
                    bitmap = new Bitmap(scrap.Width, scrap.Height, PixelFormat.Format24bppRgb);
                    graphics = Graphics.FromImage(bitmap);
                    graphics.DrawImage(scrap.GetViewImage(), 0, 0, scrap.Width, scrap.Height);
                }
                else
                {
                    var pixelFormat = scrap.Image.PixelFormat;
                    if (Array.IndexOf(indexedPixelFormats, pixelFormat) != -1)
                    {
                        pixelFormat = PixelFormat.Format24bppRgb;
                    }

                    bitmap = new Bitmap(scrap.Image.Width, scrap.Image.Height, pixelFormat);
                    graphics = Graphics.FromImage(bitmap);
                    graphics.DrawImage(scrap.Image, 0, 0, scrap.Image.Width, scrap.Image.Height);
                }
                var encoderParams = GetEncoderParams(ref scrap);
                if (encoderParams != null)
                {
                    text = GetSavePath(ref scrap);
                    Layer.LayerManager.Instance.ResumeRefresh();

                    if (!(text == ""))
                    {
                        var encoderParameters = new EncoderParameters(encoderParams.Length)
                        {
                            Param = encoderParams
                        };
                        var imageCodecInfo = GetImageCodecInfo();
                        if (imageCodecInfo != null)
                        {
                            try
                            {
                                var directoryName = Path.GetDirectoryName(text);
                                if (!Directory.Exists(directoryName))
                                {
                                    Directory.CreateDirectory(directoryName);
                                }
                                bitmap.Save(text, imageCodecInfo, encoderParameters);
                                if (CopyPath)
                                {
                                    Clipboard.SetText(text);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(text + "\n无法保存。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                throw ex2;
            }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                }

                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
            }
        }

        // Token: 0x060000C8 RID: 200 RVA: 0x000058B4 File Offset: 0x00003AB4
        protected string GetSavePath(ref ScrapBase scrap)
        {
            var imageCodecInfo = GetImageCodecInfo();
            var flag = false;
            if (imageCodecInfo == null)
            {
                return "";
            }
            var extension = Extension;
            var saveFolder = SaveFolder;
            string text;
            switch (FileNameType)
            {
                case CImageStyleItem.EnumFileName.SaveAs:
                    text = scrap.Name;
                    flag = true;
                    break;
                case CImageStyleItem.EnumFileName.ScrapName:
                    text = scrap.Name;
                    break;
                case CImageStyleItem.EnumFileName.UseName:
                    text = FileName;
                    break;
                default:
                    text = scrap.Name;
                    break;
            }
            while (!flag)
            {
                if (!Path.HasExtension(text))
                {
                    text = Path.ChangeExtension(text, extension);
                }
                var text2 = Path.Combine(saveFolder, text);
                if (File.Exists(text2))
                {
                    switch (DupliType)
                    {
                        case CImageStyleItem.EnumDupliType.Sequence:
                            {
                                var i = 1;
                                extension = Path.GetExtension(text);
                                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
                                while (i < 2147483647)
                                {
                                    text = fileNameWithoutExtension + " (" + i.ToString() + ")";
                                    text = Path.ChangeExtension(text, extension);
                                    text2 = Path.Combine(saveFolder, text);
                                    if (!File.Exists(text2))
                                    {
                                        break;
                                    }
                                    i++;
                                }
                                if (i == 2147483647)
                                {
                                    return "";
                                }
                                break;
                            }
                        case CImageStyleItem.EnumDupliType.Select:
                            {
                                var dialogResult = MessageBox.Show("相同的文件名已存在。\n覆盖？", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                                if (dialogResult == DialogResult.No)
                                {
                                    flag = true;
                                    continue;
                                }
                                if (dialogResult == DialogResult.Cancel)
                                {
                                    return "";
                                }
                                break;
                            }
                    }
                }
                return text2;
            }
            var saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = saveFolder,
                FileName = text,
                DefaultExt = extension,
                Filter = FileFilter,
                RestoreDirectory = true
            };

            Layer.LayerManager.Instance.SuspendRefresh();
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return "";
            }

            return saveFileDialog.FileName;
        }

        // Token: 0x060000C9 RID: 201 RVA: 0x00005A5C File Offset: 0x00003C5C
        protected ImageCodecInfo GetImageCodecInfo()
        {
            var imageFormat = GetImageFormat();
            ImageCodecInfo imageCodecInfo = null;
            foreach (var imageCodecInfo2 in ImageCodecInfo.GetImageEncoders())
            {
                if (imageCodecInfo2.FormatID == imageFormat.Guid)
                {
                    imageCodecInfo = imageCodecInfo2;
                    break;
                }
            }
            if (imageCodecInfo == null)
            {
                MessageBox.Show("因为利用可以的编码器没找到，不能保存图像。", GetDisplayName(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return imageCodecInfo;
        }

        // Token: 0x1700003A RID: 58
        // (get) Token: 0x060000CA RID: 202 RVA: 0x00005ABE File Offset: 0x00003CBE
        protected virtual string Extension => "";

        // Token: 0x1700003B RID: 59
        // (get) Token: 0x060000CB RID: 203 RVA: 0x00005AC5 File Offset: 0x00003CC5
        protected virtual string FileFilter => "所有文件 (*.*)|*.*";

        // Token: 0x060000CC RID: 204
        protected abstract EncoderParameter[] GetEncoderParams(ref ScrapBase scrap);

        // Token: 0x060000CD RID: 205
        protected abstract ImageFormat GetImageFormat();

        // Token: 0x0400005A RID: 90
        public string SaveFolder;

        // Token: 0x0400005B RID: 91
        public bool HaveMargin;

        // Token: 0x0400005C RID: 92
        public bool CopyPath;

        // Token: 0x0400005D RID: 93
        public CImageStyleItem.EnumFileName FileNameType;

        // Token: 0x0400005E RID: 94
        public CImageStyleItem.EnumDupliType DupliType;

        // Token: 0x0400005F RID: 95
        public string FileName;

        // Token: 0x02000010 RID: 16
        public enum EnumFileName
        {
            // Token: 0x0400006F RID: 111
            SaveAs,
            // Token: 0x04000070 RID: 112
            ScrapName,
            // Token: 0x04000071 RID: 113
            UseName
        }

        // Token: 0x02000011 RID: 17
        public enum EnumDupliType
        {
            // Token: 0x04000073 RID: 115
            OverWrite,
            // Token: 0x04000074 RID: 116
            Sequence,
            // Token: 0x04000075 RID: 117
            Select
        }
    }
}
