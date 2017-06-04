namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using System;
    using System.Drawing;

    public class CTimerStyleItem : CStyleItem
    {
        protected uint interval;
        public static uint MAX_INTERVAL = 0xea60;
        public static uint MIN_INTERVAL = 100;

        public CTimerStyleItem()
        {
            this.Interval = 0x3e8;
        }

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            base._waitinterval = (int) this.Interval;
        }

        public override string GetDescription() => 
            "指定的时间内，暂停。";

        public override string GetDisplayName() => 
            "定时器";

        public override Bitmap GetIcon() => 
            null;

        public override string GetName() => 
            "Timer";

        protected override ToolBoxForm GetToolBoxForm() => 
            new TimerStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CTimerStyleItem item = (CTimerStyleItem) newOwn;
            this.interval = item.interval;
        }

        public uint Interval
        {
            get{return  
                this.interval;}
            set
            {
                if (value < MIN_INTERVAL)
                {
                    this.interval = MIN_INTERVAL;
                }
                else if (value > MAX_INTERVAL)
                {
                    this.interval = MAX_INTERVAL;
                }
                else
                {
                    this.interval = value;
                }
            }
        }

        public override string StateText
        {
            get
            {
                string str = "";
                if (this.interval > 0)
                {
                    str = this.Interval.ToString() + "ms";
                }
                return str;
            }
        }
    }
}

