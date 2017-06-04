namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using SETUNA.Main.StyleItems;
    using System;
    using System.Drawing;

    public class CCloseStyle : CPreStyle
    {
        public CCloseStyle()
        {
            base._styleid = -1;
            base._stylename = "关闭";
        }

        public override void Apply(ref ScrapBase scrap)
        {
            new CCloseStyleItem().Apply(ref scrap, Point.Empty);
        }
    }
}

