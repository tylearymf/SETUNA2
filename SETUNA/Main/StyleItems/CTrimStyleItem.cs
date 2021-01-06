using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x02000065 RID: 101
    public class CTrimStyleItem : CStyleItem
    {
        // Token: 0x06000393 RID: 915 RVA: 0x00016110 File Offset: 0x00014310
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            using (var trimWindow = new TrimWindow(scrap))
            {
                if (trimWindow.ShowDialog() == DialogResult.OK)
                {
                    using (var bitmap = new Bitmap(trimWindow.TrimRectangle.Width, trimWindow.TrimRectangle.Height, PixelFormat.Format24bppRgb))
                    {
                        using (var graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.DrawImage(scrap.Image, 0, 0, new Rectangle(trimWindow.TrimLeft, trimWindow.TrimTop, trimWindow.TrimRectangle.Width, trimWindow.TrimRectangle.Height), GraphicsUnit.Pixel);
                        }
                        scrap.Image = bitmap;
                        scrap.Left += trimWindow.TrimLeft;
                        scrap.Top += trimWindow.TrimTop;
                        scrap.Focus();
                    }
                }
            }
            scrap.Refresh();
        }

        // Token: 0x06000394 RID: 916 RVA: 0x0001622C File Offset: 0x0001442C
        public override string GetName()
        {
            return "Trim";
        }

        // Token: 0x06000395 RID: 917 RVA: 0x00016233 File Offset: 0x00014433
        public override string GetDisplayName()
        {
            return "修剪";
        }

        // Token: 0x06000396 RID: 918 RVA: 0x0001623A File Offset: 0x0001443A
        public override string GetDescription()
        {
            return "您可以删除不需要的部分。";
        }

        // Token: 0x06000397 RID: 919 RVA: 0x00016241 File Offset: 0x00014441
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new NothingStyleItemPanel(this);
        }

        // Token: 0x06000398 RID: 920 RVA: 0x00016249 File Offset: 0x00014449
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
        }

        // Token: 0x06000399 RID: 921 RVA: 0x0001624B File Offset: 0x0001444B
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Trim;
        }
    }
}
