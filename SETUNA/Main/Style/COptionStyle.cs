namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using System;

    public class COptionStyle : CPreStyle
    {
        public COptionStyle()
        {
            base._styleid = -10;
            base._stylename = "选项";
        }

        public override void Apply(ref ScrapBase scrap)
        {
            scrap.Manager.BindForm.Option();
        }
    }
}

