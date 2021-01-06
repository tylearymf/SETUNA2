using System.Collections;

namespace SETUNA.Main
{
    // Token: 0x020000A1 RID: 161
    public class ToolStripScrapList : ToolStripAbstractList
    {
        // Token: 0x0600053C RID: 1340 RVA: 0x000246B1 File Offset: 0x000228B1
        public ToolStripScrapList(string text, ScrapBook scrapbook) : base(text, scrapbook)
        {
        }

        // Token: 0x0600053D RID: 1341 RVA: 0x000246BB File Offset: 0x000228BB
        protected override bool IsExists()
        {
            return _scrapbook != null && _scrapbook.ScrapCount > 0;
        }

        // Token: 0x0600053E RID: 1342 RVA: 0x000246D8 File Offset: 0x000228D8
        protected override ArrayList GetItems()
        {
            var arrayList = new ArrayList();
            foreach (var value in _scrapbook)
            {
                arrayList.Add(value);
            }
            return arrayList;
        }
    }
}
