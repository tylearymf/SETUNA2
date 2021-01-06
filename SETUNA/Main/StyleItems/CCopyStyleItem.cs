using System;
using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x02000013 RID: 19
    public class CCopyStyleItem : CStyleItem
    {
        // Token: 0x060000DC RID: 220 RVA: 0x000068BC File Offset: 0x00004ABC
        public CCopyStyleItem()
        {
            CopyFromSource = false;
        }

        // Token: 0x060000DD RID: 221 RVA: 0x000068CC File Offset: 0x00004ACC
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            Image image = null;
            try
            {
                if (CopyFromSource)
                {
                    image = (Image)scrap.Image.Clone();
                }
                else
                {
                    image = scrap.GetViewImage();
                }
                Clipboard.Clear();
                for (var i = 0; i < 5; i++)
                {
                    Clipboard.SetImage(image);
                    if (Clipboard.ContainsImage())
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CStyleItem Apply Exception:" + ex.Message);
            }
            finally
            {
                if (image != null)
                {
                    image.Dispose();
                }
            }
        }

        // Token: 0x060000DE RID: 222 RVA: 0x00006960 File Offset: 0x00004B60
        public override string GetName()
        {
            return "Copy";
        }

        // Token: 0x060000DF RID: 223 RVA: 0x00006967 File Offset: 0x00004B67
        public override string GetDisplayName()
        {
            return "复制到剪贴板";
        }

        // Token: 0x060000E0 RID: 224 RVA: 0x0000696E File Offset: 0x00004B6E
        public override string GetDescription()
        {
            return "将参考图作为图像复制到剪贴板里。";
        }

        // Token: 0x060000E1 RID: 225 RVA: 0x00006975 File Offset: 0x00004B75
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new CopyStyleItemPanel(this);
        }

        // Token: 0x060000E2 RID: 226 RVA: 0x00006980 File Offset: 0x00004B80
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var ccopyStyleItem = (CCopyStyleItem)newOwn;
            CopyFromSource = ccopyStyleItem.CopyFromSource;
        }

        // Token: 0x060000E3 RID: 227 RVA: 0x000069A0 File Offset: 0x00004BA0
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Copy;
        }

        // Token: 0x04000078 RID: 120
        public bool CopyFromSource;
    }
}
