namespace SETUNA.Main.StyleItems
{
    using Properties;
    using SETUNA.Main;
    using System;
    using System.Drawing;

    public class CCloseStyleItem : CStyleItem
    {
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            scrap.Close();
        }

        public override string GetDescription() => 
            "关闭参考图。\n之后的自动操作将不被使用。";

        public override string GetDisplayName() => 
            "关闭";

        public override Bitmap GetIcon() => 
            Resources.Icon_Close;

        public override string GetName() => 
            "Close";

        protected override ToolBoxForm GetToolBoxForm() => 
            new NothingStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
        }

        public override bool IsTerminate =>
            true;
    }
}

