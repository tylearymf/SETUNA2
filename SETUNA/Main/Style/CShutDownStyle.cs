namespace SETUNA.Main.Style
{
    // Token: 0x0200004D RID: 77
    public class CShutDownStyle : CPreStyle
    {
        // Token: 0x060002C6 RID: 710 RVA: 0x0000F5F8 File Offset: 0x0000D7F8
        public CShutDownStyle()
        {
            _styleid = -11;
            _stylename = "退出SETUNA";
        }

        // Token: 0x060002C7 RID: 711 RVA: 0x0000F614 File Offset: 0x0000D814
        public override void Apply(ref ScrapBase scrap)
        {
            var bindForm = scrap.Manager.BindForm;
            bindForm.Close();
        }
    }
}
