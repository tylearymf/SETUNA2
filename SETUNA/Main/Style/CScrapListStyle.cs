namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using System;
    using System.Windows.Forms;

    public class CScrapListStyle : CPreStyle
    {
        public CScrapListStyle()
        {
            base._styleid = -6;
            base._stylename = "参考图名单";
        }

        public override ToolStripItem GetToolStrip(ScrapBook scrapbook) => 
            new ToolStripScrapList(base.GetDisplayName(), scrapbook);
    }
}

