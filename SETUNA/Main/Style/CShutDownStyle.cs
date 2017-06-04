namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using System;

    public class CShutDownStyle : CPreStyle
    {
        public CShutDownStyle()
        {
            base._styleid = -11;
            base._stylename = "退出SETUNA";
        }

        public override void Apply(ref ScrapBase scrap)
        {
            scrap.Manager.BindForm.Close();
        }
    }
}

