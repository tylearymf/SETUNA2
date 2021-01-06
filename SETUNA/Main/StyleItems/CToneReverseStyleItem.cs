using System.Drawing;
using System.Drawing.Imaging;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000097 RID: 151
    public class CToneReverseStyleItem : CStyleItem
    {
        // Token: 0x060004F9 RID: 1273 RVA: 0x0002380C File Offset: 0x00021A0C
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            using (var graphics = Graphics.FromImage(scrap.Image))
            {
                var colorMatrix = new ColorMatrix
                {
                    Matrix00 = -1f,
                    Matrix11 = -1f,
                    Matrix22 = -1f
                };
                var imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix);
                graphics.DrawImage(scrap.Image, new Rectangle(0, 0, scrap.Image.Width, scrap.Image.Height), 0, 0, scrap.Image.Width, scrap.Image.Height, GraphicsUnit.Pixel, imageAttributes);
            }
            scrap.Refresh();
        }

        // Token: 0x060004FA RID: 1274 RVA: 0x000238C8 File Offset: 0x00021AC8
        public override string GetName()
        {
            return "ToneReverse";
        }

        // Token: 0x060004FB RID: 1275 RVA: 0x000238CF File Offset: 0x00021ACF
        public override string GetDisplayName()
        {
            return "灰度等级翻转";
        }

        // Token: 0x060004FC RID: 1276 RVA: 0x000238D6 File Offset: 0x00021AD6
        public override string GetDescription()
        {
            return "进行灰度等级翻转。";
        }

        // Token: 0x060004FD RID: 1277 RVA: 0x000238DD File Offset: 0x00021ADD
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new NothingStyleItemPanel(this);
        }

        // Token: 0x060004FE RID: 1278 RVA: 0x000238E5 File Offset: 0x00021AE5
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
        }

        // Token: 0x060004FF RID: 1279 RVA: 0x000238E7 File Offset: 0x00021AE7
        public override Bitmap GetIcon()
        {
            return null;
        }
    }
}
