namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using System;

    public class CShowVersionStyle : CPreStyle
    {
        public CShowVersionStyle()
        {
            base._styleid = -5;
            base._stylename = "版本信息";
        }

        public override void Apply(ref ScrapBase scrap)
        {
            new SplashForm().ShowDialog();
        }
    }
}

