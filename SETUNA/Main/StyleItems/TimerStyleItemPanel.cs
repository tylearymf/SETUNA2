namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000096 RID: 150
    internal partial class TimerStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060004F5 RID: 1269 RVA: 0x00023490 File Offset: 0x00021690
        public TimerStyleItemPanel(CStyleItem item) : base(item)
        {
        }

        // Token: 0x060004F7 RID: 1271 RVA: 0x00023784 File Offset: 0x00021984
        protected override void SetStyleToForm(object style)
        {
            var ctimerStyleItem = (CTimerStyleItem)style;
            InitializeComponent();
            numInterval.Minimum = CTimerStyleItem.MIN_INTERVAL;
            numInterval.Maximum = CTimerStyleItem.MAX_INTERVAL;
            numInterval.Value = ctimerStyleItem.Interval;
        }

        // Token: 0x060004F8 RID: 1272 RVA: 0x000237E0 File Offset: 0x000219E0
        protected override object GetStyleFromForm()
        {
            return new CTimerStyleItem
            {
                Interval = (uint)numInterval.Value
            };
        }
    }
}
