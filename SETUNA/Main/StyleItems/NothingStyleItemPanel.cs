namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200000B RID: 11
    internal partial class NothingStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060000AD RID: 173 RVA: 0x00004C94 File Offset: 0x00002E94
        public NothingStyleItemPanel(CStyleItem item) : base(item)
        {
        }

        // Token: 0x060000AE RID: 174 RVA: 0x00004CA0 File Offset: 0x00002EA0
        protected override void SetStyleToForm(object style)
        {
            var cstyleItem = (CStyleItem)style;
            InitializeComponent();
            Text = cstyleItem.GetDisplayName();
        }

        // Token: 0x060000AF RID: 175 RVA: 0x00004CC6 File Offset: 0x00002EC6
        protected override object GetStyleFromForm()
        {
            return null;
        }
    }
}
