namespace SETUNA.Main.Style
{
    // Token: 0x02000049 RID: 73
    public class CDustEraseStyle : CPreStyle
    {
        // Token: 0x060002BE RID: 702 RVA: 0x0000F520 File Offset: 0x0000D720
        public CDustEraseStyle()
        {
            _styleid = -8;
            _stylename = "清空回收站";
        }

        // Token: 0x060002BF RID: 703 RVA: 0x0000F53B File Offset: 0x0000D73B
        public override void Apply(ref ScrapBase scrap)
        {
            scrap.Manager.EraseDustBox();
        }
    }
}
