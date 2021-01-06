using System.Collections;
using System.Windows.Forms;

namespace SETUNA.Main
{
    // Token: 0x020000A2 RID: 162
    public class ToolStripDustboxList : ToolStripAbstractList
    {
        // Token: 0x0600053F RID: 1343 RVA: 0x00024730 File Offset: 0x00022930
        public ToolStripDustboxList(string text, ScrapBook scrapbook) : base(text, scrapbook)
        {
        }

        // Token: 0x06000540 RID: 1344 RVA: 0x0002473A File Offset: 0x0002293A
        protected override bool IsExists()
        {
            return _scrapbook != null && _scrapbook.DustCount > 0;
        }

        // Token: 0x06000541 RID: 1345 RVA: 0x00024757 File Offset: 0x00022957
        protected override ArrayList GetItems()
        {
            return _scrapbook.DustBoxArray;
        }

        // Token: 0x06000542 RID: 1346 RVA: 0x00024764 File Offset: 0x00022964
        protected override void OnAddItem(ToolStripMenuItem addmi)
        {
            addmi.Click += _scrapbook.BindForm.RestoreScrap;
        }
    }
}
