using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200007D RID: 125
    public class CWindowStyleItem : CStyleItem
    {
        // Token: 0x0600041A RID: 1050 RVA: 0x0001A657 File Offset: 0x00018857
        public CWindowStyleItem()
        {
            IsWindow = false;
        }

        // Token: 0x0600041B RID: 1051 RVA: 0x0001A668 File Offset: 0x00018868
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            if (IsWindow)
            {
                if (scrap.FormBorderStyle != FormBorderStyle.FixedDialog)
                {
                    scrap.FormBorderStyle = FormBorderStyle.FixedDialog;
                    scrap.ControlBox = true;
                    scrap.ShowInTaskbar = true;
                    scrap.TopMost = false;
                    scrap.ClientSize = scrap.Size;
                    scrap.Refresh();
                    return;
                }
            }
            else if (scrap.FormBorderStyle != FormBorderStyle.None)
            {
                scrap.FormBorderStyle = FormBorderStyle.None;
                scrap.ControlBox = false;
                scrap.ShowInTaskbar = false;
                scrap.TopMost = true;
                scrap.Refresh();
            }
        }

        // Token: 0x0600041C RID: 1052 RVA: 0x0001A6ED File Offset: 0x000188ED
        public override string GetName()
        {
            return "Window";
        }

        // Token: 0x0600041D RID: 1053 RVA: 0x0001A6F4 File Offset: 0x000188F4
        public override string GetDisplayName()
        {
            return "窗口化";
        }

        // Token: 0x0600041E RID: 1054 RVA: 0x0001A6FB File Offset: 0x000188FB
        public override string GetDescription()
        {
            return "为参考图加上窗口边框。";
        }

        // Token: 0x0600041F RID: 1055 RVA: 0x0001A702 File Offset: 0x00018902
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new WindowStyleItemPanel(this);
        }

        // Token: 0x06000420 RID: 1056 RVA: 0x0001A70C File Offset: 0x0001890C
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var cwindowStyleItem = (CWindowStyleItem)newOwn;
            IsWindow = cwindowStyleItem.IsWindow;
        }

        // Token: 0x170000A0 RID: 160
        // (get) Token: 0x06000421 RID: 1057 RVA: 0x0001A72C File Offset: 0x0001892C
        public override string StateText
        {
            get
            {
                string result;
                if (IsWindow)
                {
                    result = "是";
                }
                else
                {
                    result = "否";
                }
                return result;
            }
        }

        // Token: 0x06000422 RID: 1058 RVA: 0x0001A756 File Offset: 0x00018956
        public override Bitmap GetIcon()
        {
            return null;
        }

        // Token: 0x04000274 RID: 628
        public bool IsWindow;
    }
}
