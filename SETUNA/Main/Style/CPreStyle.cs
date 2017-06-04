namespace SETUNA.Main.Style
{
    using System;

    public abstract class CPreStyle : CStyle
    {
        protected CPreStyle()
        {
        }

        public override int StyleID
        {
            get { return base._styleid; }
            set
            {
            }
        }
    }
}

