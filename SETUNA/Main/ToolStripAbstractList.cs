using System;
using System.Collections;
using System.Windows.Forms;
using Opulos.Core.UI;

namespace SETUNA.Main
{
    // Token: 0x020000A3 RID: 163
    public class ToolStripAbstractList : ToolStripMenuItem
    {
        public ToolStripAbstractList()
        {
        }

        // Token: 0x06000543 RID: 1347 RVA: 0x00024782 File Offset: 0x00022982
        public ToolStripAbstractList(string text, ScrapBook scrapbook) : base(text)
        {
            _scrapbook = scrapbook;
            base.DropDownItems.Clear();
            base.DropDownItems.Insert(0, new ToolStripMenuItem("无"));

            ToolStripEx.BigButtons(DropDown);
        }

        // Token: 0x06000544 RID: 1348 RVA: 0x000247B4 File Offset: 0x000229B4
        protected void RefreshList()
        {
            if (_createdlist)
            {
                return;
            }
            base.DropDownItems.Clear();
            if (_scrapbook != null)
            {
                foreach (var obj in GetItems())
                {
                    var scrapBase = (ScrapBase)obj;
                    var text = string.Concat(new object[]
                    {
                        scrapBase.Name,
                        "\n",
                        scrapBase.Width,
                        " x ",
                        scrapBase.Height
                    });
                    var toolStripMenuItem = new ToolStripMenuItem(text, scrapBase.GetThumbnail(), new EventHandler(_scrapbook.BindForm.OnActiveScrapInList))
                    {
                        Tag = scrapBase,
                        ImageScaling = ToolStripItemImageScaling.None
                    };
                    OnAddItem(toolStripMenuItem);
                    base.DropDownItems.Insert(0, toolStripMenuItem);
                }
            }
            if (base.DropDownItems.Count == 0)
            {
                base.DropDownItems.Insert(0, new ToolStripMenuItem("无"));
            }
            _createdlist = true;
        }

        // Token: 0x06000545 RID: 1349 RVA: 0x000248E8 File Offset: 0x00022AE8
        protected override void OnMouseHover(EventArgs e)
        {
            RefreshList();
            base.OnMouseHover(e);
        }

        protected override void OnDropDownOpened(EventArgs e)
        {
            Mainform.Instance.MouseWheelCallbackEvent += DropDown_MouseWheel;
            DropDown.MouseWheel += DropDown_MouseWheel;

            base.OnDropDownOpened(e);
        }

        private void DropDown_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                SendKeys.SendWait("{UP}");
            }
            else
            {
                SendKeys.SendWait("{DOWN}");
            }
        }

        // Token: 0x06000546 RID: 1350 RVA: 0x000248F7 File Offset: 0x00022AF7
        protected override void OnDropDownClosed(EventArgs e)
        {
            DropDown.MouseWheel -= DropDown_MouseWheel;
            Mainform.Instance.MouseWheelCallbackEvent -= DropDown_MouseWheel;

            _createdlist = false;
            base.OnDropDownClosed(e);
        }

        // Token: 0x06000547 RID: 1351 RVA: 0x00024907 File Offset: 0x00022B07
        protected virtual void OnAddItem(ToolStripMenuItem addmi)
        {
        }

        // Token: 0x06000548 RID: 1352
        protected virtual bool IsExists()
        {
            return false;
        }

        // Token: 0x06000549 RID: 1353
        protected virtual ArrayList GetItems()
        {
            return null;
        }

        // Token: 0x0400034F RID: 847
        protected ScrapBook _scrapbook;

        // Token: 0x04000350 RID: 848
        private bool _createdlist;
    }
}
