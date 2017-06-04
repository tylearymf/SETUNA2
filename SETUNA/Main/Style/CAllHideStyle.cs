namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using System;

    public class CAllHideStyle : CPreStyle
    {
        public CAllHideStyle()
        {
            base._styleid = -2;
            base._stylename = "全部隐藏";
        }

        public override void Apply(ref ScrapBase scrap)
        {
            if (scrap.Manager != null)
            {
                scrap.Manager.HideAllScrap();
            }
        }
    }
}

