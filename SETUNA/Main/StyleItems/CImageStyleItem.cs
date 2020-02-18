namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;

    public abstract class CImageStyleItem : CStyleItem
    {
        public const string SaveImageTitle = "SETUNA2 - 另存为";
        public bool CopyPath = false;
        public EnumDupliType DupliType = EnumDupliType.OverWrite;
        public string FileName;
        public EnumFileName FileNameType = EnumFileName.SaveAs;
        public bool HaveMargin = false;
        public string SaveFolder;

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            Bitmap bitmap = null;
            string path = "";
            try
            {
                if (this.HaveMargin)
                {
                    bitmap = ((Bitmap) scrap.GetViewImage()).Clone(new Rectangle(0, 0, scrap.Width, scrap.Height), PixelFormat.Format24bppRgb);
                }
                else
                {
                    bitmap = ((Bitmap) scrap.Image).Clone(new Rectangle(0, 0, scrap.Image.Width, scrap.Image.Height), PixelFormat.Format24bppRgb);
                }
                EncoderParameter[] encoderParams = this.GetEncoderParams(ref scrap);
                if (encoderParams != null)
                {
                    path = this.GetSavePath(ref scrap);
                    if (path != "")
                    {
                        EncoderParameters parameters = new EncoderParameters(encoderParams.Length) {
                            Param = encoderParams
                        };
                        ImageCodecInfo imageCodecInfo = this.GetImageCodecInfo();
                        if (imageCodecInfo != null)
                        {
                            try
                            {
                                string directoryName = Path.GetDirectoryName(path);
                                if (!Directory.Exists(directoryName))
                                {
                                    Directory.CreateDirectory(directoryName);
                                }
                                bitmap.Save(path, imageCodecInfo, parameters);
                                if (this.CopyPath)
                                {
                                    Clipboard.SetText(path);
                                }
                            }
                            catch (Exception exception)
                            {
                                throw exception;
                            }
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                MessageBox.Show(path + "\n无法保存。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                throw exception2;
            }
            finally
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
            }
        }

        protected abstract EncoderParameter[] GetEncoderParams(ref ScrapBase scrap);
        protected ImageCodecInfo GetImageCodecInfo()
        {
            ImageFormat imageFormat = this.GetImageFormat();
            ImageCodecInfo info = null;
            foreach (ImageCodecInfo info2 in ImageCodecInfo.GetImageEncoders())
            {
                if (info2.FormatID == imageFormat.Guid)
                {
                    info = info2;
                    break;
                }
            }
            if (info == null)
            {
                MessageBox.Show("因为利用可以的编码器没找到，不能保存图像。", this.GetDisplayName(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return info;
        }

        protected abstract ImageFormat GetImageFormat();
        protected string GetSavePath(ref ScrapBase scrap)
        {
            string name;
            ImageCodecInfo imageCodecInfo = this.GetImageCodecInfo();
            bool flag = false;
            if (imageCodecInfo == null)
            {
                return "";
            }
            string extension = this.Extension;
            string saveFolder = this.SaveFolder;
            switch (this.FileNameType)
            {
                case EnumFileName.SaveAs:
                    name = scrap.Name;
                    flag = true;
                    break;

                case EnumFileName.ScrapName:
                    name = scrap.Name;
                    break;

                case EnumFileName.UseName:
                    name = this.FileName;
                    break;

                default:
                    name = scrap.Name;
                    break;
            }
        Label_0066:
            if (flag)
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    Title = SaveImageTitle,
                    InitialDirectory = saveFolder,
                    FileName = name,
                    DefaultExt = extension,
                    Filter = this.FileFilter,
                    RestoreDirectory = true
                };
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return "";
                }
                return dialog.FileName;
            }
            flag = false;
            if (!Path.HasExtension(name))
            {
                name = Path.ChangeExtension(name, extension);
            }
            string path = Path.Combine(saveFolder, name);
            if (File.Exists(path))
            {
                switch (this.DupliType)
                {
                    case EnumDupliType.Sequence:
                    {
                        int num = 1;
                        extension = Path.GetExtension(name);
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(name);
                        while (num < 0x7fffffff)
                        {
                            name = Path.ChangeExtension(fileNameWithoutExtension + " (" + num.ToString() + ")", extension);
                            path = Path.Combine(saveFolder, name);
                            if (!File.Exists(path))
                            {
                                break;
                            }
                            num++;
                        }
                        if (num != 0x7fffffff)
                        {
                            return path;
                        }
                        return "";
                    }
                    case EnumDupliType.Select:
                    {
                        DialogResult result = MessageBox.Show("相同的文件名已存在。\n覆盖？", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                        if (result != DialogResult.No)
                        {
                            if (result == DialogResult.Cancel)
                            {
                                return "";
                            }
                            return path;
                        }
                        flag = true;
                        goto Label_0066;
                    }
                }
            }
            return path;
        }

        protected virtual string Extension =>
            "";

        protected virtual string FileFilter =>
            "所有文件 (*.*)|*.*";

        public enum EnumDupliType
        {
            OverWrite,
            Sequence,
            Select
        }

        public enum EnumFileName
        {
            SaveAs,
            ScrapName,
            UseName
        }
    }
}

