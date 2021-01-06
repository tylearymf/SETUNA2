namespace SETUNA.Main.Style
{
    // Token: 0x020000AE RID: 174
    public class CAllHideStyle : CPreStyle
    {
        // Token: 0x06000592 RID: 1426 RVA: 0x0002651D File Offset: 0x0002471D
        public CAllHideStyle()
        {
            _styleid = -2;
            _stylename = "全部隐藏";
        }

        // Token: 0x06000593 RID: 1427 RVA: 0x00026538 File Offset: 0x00024738
        public override void Apply(ref ScrapBase scrap)
        {
            if (scrap.Manager != null)
            {
                scrap.Manager.HideAllScrap();
            }
        }
    }
}
