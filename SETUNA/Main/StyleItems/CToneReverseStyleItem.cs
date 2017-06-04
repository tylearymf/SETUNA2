namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class CToneReverseStyleItem : CStyleItem
    {
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            using (Graphics graphics = Graphics.FromImage(scrap.Image))
            {
                ColorMatrix newColorMatrix = new ColorMatrix {
                    Matrix00 = -1f,
                    Matrix11 = -1f,
                    Matrix22 = -1f
                };
                ImageAttributes imageAttr = new ImageAttributes();
                imageAttr.SetColorMatrix(newColorMatrix);
                graphics.DrawImage(scrap.Image, new Rectangle(0, 0, scrap.Image.Width, scrap.Image.Height), 0, 0, scrap.Image.Width, scrap.Image.Height, GraphicsUnit.Pixel, imageAttr);
            }
            scrap.Refresh();
        }

        public override string GetDescription() => 
            "进行灰度等级翻转。";

        public override string GetDisplayName() => 
            "灰度等级翻转";

        public override Bitmap GetIcon() => 
            null;

        public override string GetName() => 
            "ToneReverse";

        protected override ToolBoxForm GetToolBoxForm() => 
            new NothingStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
        }
    }
}

