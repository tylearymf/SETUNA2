namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using System;
    using System.Drawing;

    public class CPaintStyleItem : CStyleItem
    {
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            using (ScrapPaintWindow window = new ScrapPaintWindow(scrap))
            {
                window.ShowDialog();
            }
            scrap.Refresh();
        }

        public override string GetDescription() => 
            "可以直接在参考图上绘制。";

        public override string GetDisplayName() => 
            "绘制";

        public override Bitmap GetIcon() => 
            null;

        public override string GetName() => 
            "Paint";

        protected override ToolBoxForm GetToolBoxForm() => 
            new NothingStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
        }
    }
}

