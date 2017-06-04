namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using System;

    public class CCaptureStyle : CPreStyle
    {
        public CCaptureStyle()
        {
            base._styleid = -9;
            base._stylename = "制作参考图";
        }

        public override void Apply(ref ScrapBase scrap)
        {
            scrap.Manager.BindForm.StartCapture();
        }
    }
}

