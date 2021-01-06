namespace SETUNA.Main.Style
{
    // Token: 0x0200004A RID: 74
    public class CCaptureStyle : CPreStyle
    {
        // Token: 0x060002C0 RID: 704 RVA: 0x0000F549 File Offset: 0x0000D749
        public CCaptureStyle()
        {
            _styleid = -9;
            _stylename = "制作参考图";
        }

        // Token: 0x060002C1 RID: 705 RVA: 0x0000F564 File Offset: 0x0000D764
        public override void Apply(ref ScrapBase scrap)
        {
            var bindForm = scrap.Manager.BindForm;
            bindForm.StartCapture();
        }
    }
}
