namespace SETUNA.Main
{
    using System;
    using System.Collections;
    using System.Windows.Forms;

    public class ToolStripDustboxList : ToolStripAbstractList
    {
        public ToolStripDustboxList(string text, ScrapBook scrapbook) : base(text, scrapbook)
        {
        }

        protected override ArrayList GetItems() => 
            base._scrapbook.DustBoxArray;

        protected override bool IsExists()
        {
            if (base._scrapbook == null)
            {
                return false;
            }
            if (base._scrapbook.DustCount <= 0)
            {
                return false;
            }
            return true;
        }

        protected override void OnAddItem(ToolStripMenuItem addmi)
        {
            addmi.Click += new EventHandler(base._scrapbook.BindForm.RestoreScrap);
        }
    }
}

