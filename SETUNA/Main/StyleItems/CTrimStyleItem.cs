namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using Properties;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public class CTrimStyleItem : CStyleItem
    {
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            using (TrimWindow window = new TrimWindow(scrap))
            {
                if (window.ShowDialog() == DialogResult.OK)
                {
                    using (Bitmap bitmap = new Bitmap(window.TrimRectangle.Width, window.TrimRectangle.Height, PixelFormat.Format24bppRgb))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.DrawImage(scrap.Image, 0, 0, new Rectangle(window.TrimLeft, window.TrimTop, window.TrimRectangle.Width, window.TrimRectangle.Height), GraphicsUnit.Pixel);
                        }
                        scrap.Image = bitmap;
                        scrap.Left += window.TrimLeft;
                        scrap.Top += window.TrimTop;
                        scrap.Focus();
                    }
                }
            }
            scrap.Refresh();
        }

        public override string GetDescription() => 
            "您可以删除不需要的部分。";

        public override string GetDisplayName() => 
            "修剪";

        public override Bitmap GetIcon() => 
            Resources.Icon_Trim;

        public override string GetName() => 
            "Trim";

        protected override ToolBoxForm GetToolBoxForm() => 
            new NothingStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
        }
    }
}

