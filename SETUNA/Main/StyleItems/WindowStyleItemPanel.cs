namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200007C RID: 124
    internal partial class WindowStyleItemPanel : ToolBoxForm
    {
        // Token: 0x06000416 RID: 1046 RVA: 0x0001A2D6 File Offset: 0x000184D6
        public WindowStyleItemPanel(CWindowStyleItem style) : base(style)
        {
        }

        // Token: 0x06000417 RID: 1047 RVA: 0x0001A2E0 File Offset: 0x000184E0
        protected override void SetStyleToForm(object style)
        {
            var cwindowStyleItem = (CWindowStyleItem)style;
            InitializeComponent();
            Text = cwindowStyleItem.GetDisplayName();
            rdoFixed.Checked = !cwindowStyleItem.IsWindow;
            rdoIncrement.Checked = cwindowStyleItem.IsWindow;
        }

        // Token: 0x06000418 RID: 1048 RVA: 0x0001A32C File Offset: 0x0001852C
        protected override object GetStyleFromForm()
        {
            return new CWindowStyleItem
            {
                IsWindow = !rdoFixed.Checked
            };
        }
    }
}
