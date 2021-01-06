using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x0200005D RID: 93
    public class CPasteStyleItem : CStyleItem
    {
        // Token: 0x0600033D RID: 829 RVA: 0x00015674 File Offset: 0x00013874
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            Image image = null;
            if (Clipboard.ContainsImage())
            {
                image = Clipboard.GetImage();
            }
            else if (Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                if (File.Exists(text))
                {
                    FileStream fileStream = null;
                    try
                    {
                        fileStream = new FileStream(text, FileMode.Open, FileAccess.Read);
                        image = (Bitmap)Image.FromStream(fileStream);
                        fileStream.Close();
                        fileStream = null;
                    }
                    catch
                    {
                    }
                    finally
                    {
                        if (fileStream != null)
                        {
                            fileStream.Close();
                        }
                    }
                }
            }
            if (image != null)
            {
                scrap.Manager.AddScrap(image, scrap.Left, scrap.Top, image.Width, image.Height);
            }
        }

        // Token: 0x0600033E RID: 830 RVA: 0x00015720 File Offset: 0x00013920
        public override string GetName()
        {
            return "Paste";
        }

        // Token: 0x0600033F RID: 831 RVA: 0x00015727 File Offset: 0x00013927
        public override string GetDisplayName()
        {
            return "从剪贴板粘贴";
        }

        // Token: 0x06000340 RID: 832 RVA: 0x0001572E File Offset: 0x0001392E
        public override string GetDescription()
        {
            return "将剪贴板内的图像作为参考图。";
        }

        // Token: 0x06000341 RID: 833 RVA: 0x00015735 File Offset: 0x00013935
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new NothingStyleItemPanel(this);
        }

        // Token: 0x06000342 RID: 834 RVA: 0x0001573D File Offset: 0x0001393D
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
        }

        // Token: 0x1700007D RID: 125
        // (get) Token: 0x06000343 RID: 835 RVA: 0x0001573F File Offset: 0x0001393F
        public override bool IsInitApply => false;

        // Token: 0x06000344 RID: 836 RVA: 0x00015742 File Offset: 0x00013942
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Paste;
        }
    }
}
