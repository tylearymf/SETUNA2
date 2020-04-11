namespace SETUNA.Main
{
    using Opulos.Core.UI;
    using System;
    using System.Collections;
    using System.Windows.Forms;

    public abstract class ToolStripAbstractList : ToolStripMenuItem
    {
        private bool _createdlist;
        protected ScrapBook _scrapbook;

        public ToolStripAbstractList(string text, ScrapBook scrapbook) : base(text)
        {
            this._scrapbook = scrapbook;
            base.DropDownItems.Clear();
            base.DropDownItems.Insert(0, new ToolStripMenuItem("无"));

            ToolStripEx.BigButtons(this.DropDown);
        }

        protected abstract ArrayList GetItems();
        protected abstract bool IsExists();
        protected virtual void OnAddItem(ToolStripMenuItem addmi)
        {
        }

        protected override void OnDropDownOpened(EventArgs e)
        {
            Mainform.instance.MouseWheelCallbackEvent += DropDown_MouseWheel;
            this.DropDown.MouseWheel += DropDown_MouseWheel;

            base.OnDropDownOpened(e);
        }

        private void DropDown_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) SendKeys.SendWait("{UP}");
            else SendKeys.SendWait("{DOWN}");
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            this.DropDown.MouseWheel -= DropDown_MouseWheel;
            Mainform.instance.MouseWheelCallbackEvent -= DropDown_MouseWheel;

            this._createdlist = false;
            base.OnDropDownClosed(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            this.RefreshList();
            base.OnMouseHover(e);
        }

        protected void RefreshList()
        {
            if (!this._createdlist)
            {
                base.DropDownItems.Clear();
                if (this._scrapbook != null)
                {
                    foreach (ScrapBase base2 in this.GetItems())
                    {
                        ToolStripMenuItem addmi = new ToolStripMenuItem(string.Concat(new object[] { base2.Name, "\n", base2.Width, " x ", base2.Height }), base2.GetThumbnail(), new EventHandler(this._scrapbook.BindForm.OnActiveScrapInList))
                        {
                            Tag = base2,
                            ImageScaling = ToolStripItemImageScaling.None
                        };
                        this.OnAddItem(addmi);
                        base.DropDownItems.Insert(0, addmi);
                    }
                }
                if (base.DropDownItems.Count == 0)
                {
                    base.DropDownItems.Insert(0, new ToolStripMenuItem("无"));
                }
                this._createdlist = true;
            }
        }
    }
}

