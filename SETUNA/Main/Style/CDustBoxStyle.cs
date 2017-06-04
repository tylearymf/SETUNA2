namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using System;
    using System.Windows.Forms;

    public class CDustBoxStyle : CPreStyle
    {
        public CDustBoxStyle()
        {
            base._styleid = -7;
            base._stylename = "回收站";
        }

        public override ToolStripItem GetToolStrip(ScrapBook scrapbook) => 
            new ToolStripDustboxList(base.GetDisplayName(), scrapbook);
    }
}

