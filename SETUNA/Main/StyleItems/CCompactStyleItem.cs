namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using SETUNA.Properties;
    using System;
    using System.Drawing;

    public class CCompactStyleItem : CStyleItem
    {
        public int LineColor = Color.Blue.ToArgb();
        public byte Opacity = 100;
        public static int OpacityMaxValue = 100;
        public static int OpacityMinValue = 10;
        public bool SoldLine = false;

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            new CompactScrap(scrap, this, clickpoint).Show();
        }

        public override string GetDescription() => 
            "将参考图的尺寸收缩。\n之后的自动操作将不被使用。";

        public override string GetDisplayName() => 
            "收缩";

        public override Bitmap GetIcon() => 
            Resources.Icon_Compact;

        public override string GetName() => 
            "Compact";

        protected override ToolBoxForm GetToolBoxForm() => 
            new CompactStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CCompactStyleItem item = (CCompactStyleItem) newOwn;
            this.Opacity = item.Opacity;
            this.LineColor = item.LineColor;
            this.SoldLine = item.SoldLine;
        }

        public override bool IsTerminate =>
            true;
    }
}

