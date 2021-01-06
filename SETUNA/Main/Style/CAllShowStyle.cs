namespace SETUNA.Main.Style
{
    // Token: 0x020000AF RID: 175
    public class CAllShowStyle : CPreStyle
    {
        // Token: 0x06000594 RID: 1428 RVA: 0x0002654F File Offset: 0x0002474F
        public CAllShowStyle()
        {
            _styleid = -3;
            _stylename = "全部显示";
        }

        // Token: 0x06000595 RID: 1429 RVA: 0x0002656A File Offset: 0x0002476A
        public override void Apply(ref ScrapBase scrap)
        {
            if (scrap.Manager != null)
            {
                scrap.Manager.ShowAllScrap();
            }
        }
    }
}
