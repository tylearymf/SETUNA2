namespace SETUNA.Main.Style
{
    using System;
    using System.Windows.Forms;

    public class CSeparatorStyle : CPreStyle
    {
        public CSeparatorStyle()
        {
            base._styleid = -4;
            base._stylename = "[分隔符]";
        }

        public override ToolStripItem GetToolStrip() => 
            new ToolStripSeparator();
    }
}

