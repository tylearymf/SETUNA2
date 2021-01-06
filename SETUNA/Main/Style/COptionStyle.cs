namespace SETUNA.Main.Style
{
    // Token: 0x0200004C RID: 76
    public class COptionStyle : CPreStyle
    {
        // Token: 0x060002C4 RID: 708 RVA: 0x0000F5BA File Offset: 0x0000D7BA
        public COptionStyle()
        {
            _styleid = -10;
            _stylename = "选项";
        }

        // Token: 0x060002C5 RID: 709 RVA: 0x0000F5D8 File Offset: 0x0000D7D8
        public override void Apply(ref ScrapBase scrap)
        {
            var bindForm = scrap.Manager.BindForm;
            bindForm.Option();
        }
    }
}
