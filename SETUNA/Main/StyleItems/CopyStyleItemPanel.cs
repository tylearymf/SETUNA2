namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000012 RID: 18
    internal partial class CopyStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060000D8 RID: 216 RVA: 0x00006847 File Offset: 0x00004A47
        public CopyStyleItemPanel()
        {
        }

        // Token: 0x060000D9 RID: 217 RVA: 0x0000684F File Offset: 0x00004A4F
        public CopyStyleItemPanel(CCopyStyleItem item) : base(item)
        {
        }

        // Token: 0x060000DA RID: 218 RVA: 0x00006858 File Offset: 0x00004A58
        protected override void SetStyleToForm(object style)
        {
            var ccopyStyleItem = (CCopyStyleItem)style;
            InitializeComponent();
            Text = ccopyStyleItem.GetDisplayName();
            chkWindow.Checked = !ccopyStyleItem.CopyFromSource;
        }

        // Token: 0x060000DB RID: 219 RVA: 0x00006894 File Offset: 0x00004A94
        protected override object GetStyleFromForm()
        {
            return new CCopyStyleItem
            {
                CopyFromSource = !chkWindow.Checked
            };
        }
    }
}
