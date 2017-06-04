namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class CWindowStyleItem : CStyleItem
    {
        public bool IsWindow = false;

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            if (this.IsWindow)
            {
                if (scrap.FormBorderStyle != FormBorderStyle.FixedDialog)
                {
                    scrap.FormBorderStyle = FormBorderStyle.FixedDialog;
                    scrap.ControlBox = true;
                    scrap.ShowInTaskbar = true;
                    scrap.TopMost = false;
                    scrap.ClientSize = scrap.Size;
                    scrap.Refresh();
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

        public override string GetDescription() => 
            "为参考图加上窗口边框。";

        public override string GetDisplayName() => 
            "窗口化";

        public override Bitmap GetIcon() => 
            null;

        public override string GetName() => 
            "Window";

        protected override ToolBoxForm GetToolBoxForm() => 
            new WindowStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CWindowStyleItem item = (CWindowStyleItem) newOwn;
            this.IsWindow = item.IsWindow;
        }

        public override string StateText
        {
            get
            {
                if (this.IsWindow)
                {
                    return "是";
                }
                return "否";
            }
        }
    }
}

