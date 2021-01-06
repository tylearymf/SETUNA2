using System.Windows.Forms;

namespace SETUNA.Main.Style
{
    // Token: 0x02000067 RID: 103
    public class CSeparatorStyle : CPreStyle
    {
        // Token: 0x0600039B RID: 923 RVA: 0x0001625A File Offset: 0x0001445A
        public CSeparatorStyle()
        {
            _styleid = -4;
            _stylename = "[分隔符]";
        }

        // Token: 0x0600039C RID: 924 RVA: 0x00016275 File Offset: 0x00014475
        public override ToolStripItem GetToolStrip()
        {
            return new ToolStripSeparator();
        }
    }
}
