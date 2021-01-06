using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000095 RID: 149
    public class CTimerStyleItem : CStyleItem
    {
        // Token: 0x170000B5 RID: 181
        // (get) Token: 0x060004EA RID: 1258 RVA: 0x000233DB File Offset: 0x000215DB
        // (set) Token: 0x060004E9 RID: 1257 RVA: 0x000233AA File Offset: 0x000215AA
        public uint Interval
        {
            get => interval;
            set
            {
                if (value < CTimerStyleItem.MIN_INTERVAL)
                {
                    interval = CTimerStyleItem.MIN_INTERVAL;
                    return;
                }
                if (value > CTimerStyleItem.MAX_INTERVAL)
                {
                    interval = CTimerStyleItem.MAX_INTERVAL;
                    return;
                }
                interval = value;
            }
        }

        // Token: 0x060004EB RID: 1259 RVA: 0x000233E3 File Offset: 0x000215E3
        public CTimerStyleItem()
        {
            Interval = 1000U;
        }

        // Token: 0x060004EC RID: 1260 RVA: 0x000233F6 File Offset: 0x000215F6
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            _waitinterval = (int)Interval;
        }

        // Token: 0x060004ED RID: 1261 RVA: 0x00023404 File Offset: 0x00021604
        public override string GetName()
        {
            return "Timer";
        }

        // Token: 0x060004EE RID: 1262 RVA: 0x0002340B File Offset: 0x0002160B
        public override string GetDisplayName()
        {
            return "定时器";
        }

        // Token: 0x060004EF RID: 1263 RVA: 0x00023412 File Offset: 0x00021612
        public override string GetDescription()
        {
            return "指定的时间内，暂停。";
        }

        // Token: 0x060004F0 RID: 1264 RVA: 0x00023419 File Offset: 0x00021619
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new TimerStyleItemPanel(this);
        }

        // Token: 0x060004F1 RID: 1265 RVA: 0x00023424 File Offset: 0x00021624
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var ctimerStyleItem = (CTimerStyleItem)newOwn;
            interval = ctimerStyleItem.interval;
        }

        // Token: 0x170000B6 RID: 182
        // (get) Token: 0x060004F2 RID: 1266 RVA: 0x00023444 File Offset: 0x00021644
        public override string StateText
        {
            get
            {
                var result = "";
                if (interval > 0U)
                {
                    result = Interval.ToString() + "ms";
                }
                return result;
            }
        }

        // Token: 0x060004F3 RID: 1267 RVA: 0x0002347A File Offset: 0x0002167A
        public override Bitmap GetIcon()
        {
            return null;
        }

        // Token: 0x0400032D RID: 813
        public static uint MIN_INTERVAL = 100U;

        // Token: 0x0400032E RID: 814
        public static uint MAX_INTERVAL = 60000U;

        // Token: 0x0400032F RID: 815
        protected uint interval;
    }
}
