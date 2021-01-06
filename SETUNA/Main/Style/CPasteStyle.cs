using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SETUNA.Main.Style
{
    // Token: 0x02000049 RID: 73
    public class CPasteStyle : CPreStyle
    {
        // Token: 0x060002BE RID: 702 RVA: 0x0000F520 File Offset: 0x0000D720
        public CPasteStyle()
        {
            _styleid = -13;
            _stylename = "从剪贴板中粘贴截图";
        }

        // Token: 0x060002BF RID: 703 RVA: 0x0000F53B File Offset: 0x0000D73B
        public override void Apply(ref ScrapBase scrap)
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
    }
}
