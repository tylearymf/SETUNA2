namespace SETUNA.Main
{
    using System;
    using System.Collections;

    public class ToolStripScrapList : ToolStripAbstractList
    {
        public ToolStripScrapList(string text, ScrapBook scrapbook) : base(text, scrapbook)
        {
        }

        protected override ArrayList GetItems()
        {
            ArrayList list = new ArrayList();
            foreach (ScrapBase base2 in base._scrapbook)
            {
                list.Add(base2);
            }
            return list;
        }

        protected override bool IsExists()
        {
            if (base._scrapbook == null)
            {
                return false;
            }
            if (base._scrapbook.ScrapCount <= 0)
            {
                return false;
            }
            return true;
        }
    }
}

