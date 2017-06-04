namespace SETUNA.Main.Style
{
    using System;
    using System.Collections.Generic;

    public abstract class CPreStyles
    {
        protected CPreStyles()
        {
        }

        public static CStyle GetPreStyle(int style_id)
        {
            foreach (CStyle style in GetPreStyleList())
            {
                if (style.StyleID == style_id)
                {
                    return style;
                }
            }
            return null;
        }

        public static List<CStyle> GetPreStyleList() => 
            new List<CStyle> { 
                new CCloseStyle(),
                new CSeparatorStyle(),
                new CShowVersionStyle(),
                new CScrapListStyle(),
                new CDustBoxStyle(),
                new CDustEraseStyle(),
                new CCaptureStyle(),
                new COptionStyle(),
                new CShutDownStyle()
            };
    }
}

