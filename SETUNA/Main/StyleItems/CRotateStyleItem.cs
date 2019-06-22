namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using Properties;
    using System;
    using System.Drawing;
    using Image = System.Drawing.Image;

    public class CRotateStyleItem : CStyleItem
    {
        public bool HorizonReflection = false;
        public int Rotate = 0;
        public bool VerticalReflection = false;

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            bool flag = false;
            Image image = scrap.Image;
            switch (this.Rotate)
            {
                case 90:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    flag = true;
                    break;

                case 180:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;

                case 270:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    flag = true;
                    break;
            }
            if (this.VerticalReflection)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            if (this.HorizonReflection)
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            if (flag)
            {
                int width = scrap.ClientSize.Width;
                int height = scrap.ClientSize.Height;
                int num3 = scrap.Location.X + ((width - height) / 2);
                int num4 = scrap.Location.Y + ((height - width) / 2);
                scrap.SuspendLayout();
                scrap.ClientSize = new Size(height, width);
                scrap.Left = num3;
                scrap.Top = num4;
                scrap.ResumeLayout();
            }
            scrap.Refresh();
        }

        public override string GetDescription() => 
            "旋转和翻转参考图。";

        public override string GetDisplayName() => 
            "旋转和翻转";

        public override Bitmap GetIcon() => 
            Resources.Icon_Rotate;

        public override string GetName() => 
            "Rotate";

        protected override ToolBoxForm GetToolBoxForm() => 
            new RotateStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CRotateStyleItem item = (CRotateStyleItem) newOwn;
            this.Rotate = item.Rotate;
            this.VerticalReflection = item.VerticalReflection;
            this.HorizonReflection = item.HorizonReflection;
        }
    }
}

