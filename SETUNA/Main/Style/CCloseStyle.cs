using System.Drawing;
using SETUNA.Main.StyleItems;

namespace SETUNA.Main.Style
{
    // Token: 0x02000085 RID: 133
    public class CCloseStyle : CPreStyle
    {
        // Token: 0x06000469 RID: 1129 RVA: 0x0001C9CC File Offset: 0x0001ABCC
        public CCloseStyle()
        {
            _styleid = -1;
            _stylename = "关闭";
        }

        // Token: 0x0600046A RID: 1130 RVA: 0x0001C9E8 File Offset: 0x0001ABE8
        public override void Apply(ref ScrapBase scrap)
        {
            var ccloseStyleItem = new CCloseStyleItem();
            ccloseStyleItem.Apply(ref scrap, Point.Empty);
        }
    }
}
