namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using System;

    public class CAllShowStyle : CPreStyle
    {
        public CAllShowStyle()
        {
            base._styleid = -3;
            base._stylename = "全部显示";
        }

        public override void Apply(ref ScrapBase scrap)
        {
            if (scrap.Manager != null)
            {
                scrap.Manager.ShowAllScrap();
            }
        }
    }
}

