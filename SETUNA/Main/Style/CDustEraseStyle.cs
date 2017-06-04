namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using System;

    public class CDustEraseStyle : CPreStyle
    {
        public CDustEraseStyle()
        {
            base._styleid = -8;
            base._stylename = "清空回收站";
        }

        public override void Apply(ref ScrapBase scrap)
        {
            scrap.Manager.EraseDustBox();
        }
    }
}

