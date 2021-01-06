using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000098 RID: 152
    public class CPaintStyleItem : CStyleItem
    {
        // Token: 0x06000501 RID: 1281 RVA: 0x000238F4 File Offset: 0x00021AF4
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            using (var scrapPaintWindow = new ScrapPaintWindow(scrap))
            {
                scrapPaintWindow.ShowDialog();
            }
            scrap.Refresh();
        }

        // Token: 0x06000502 RID: 1282 RVA: 0x00023938 File Offset: 0x00021B38
        public override string GetName()
        {
            return "Paint";
        }

        // Token: 0x06000503 RID: 1283 RVA: 0x0002393F File Offset: 0x00021B3F
        public override string GetDisplayName()
        {
            return "绘制";
        }

        // Token: 0x06000504 RID: 1284 RVA: 0x00023946 File Offset: 0x00021B46
        public override string GetDescription()
        {
            return "可以直接在参考图上绘制。";
        }

        // Token: 0x06000505 RID: 1285 RVA: 0x0002394D File Offset: 0x00021B4D
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new NothingStyleItemPanel(this);
        }

        // Token: 0x06000506 RID: 1286 RVA: 0x00023955 File Offset: 0x00021B55
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
        }

        // Token: 0x06000507 RID: 1287 RVA: 0x00023957 File Offset: 0x00021B57
        public override Bitmap GetIcon()
        {
            return null;
        }
    }
}
