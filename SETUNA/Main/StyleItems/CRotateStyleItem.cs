using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x0200005F RID: 95
    public class CRotateStyleItem : CStyleItem
    {
        // Token: 0x06000351 RID: 849 RVA: 0x000158BD File Offset: 0x00013ABD
        public CRotateStyleItem()
        {
            Rotate = 0;
            VerticalReflection = false;
            HorizonReflection = false;
        }

        // Token: 0x06000352 RID: 850 RVA: 0x000158DC File Offset: 0x00013ADC
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            var flag = false;
            var image = scrap.Image;
            var rotate = Rotate;
            if (rotate != 90)
            {
                if (rotate != 180)
                {
                    if (rotate == 270)
                    {
                        image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        flag = true;
                    }
                }
                else
                {
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
            }
            else
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                flag = true;
            }
            if (VerticalReflection)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            if (HorizonReflection)
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            if (flag)
            {
                var width = scrap.ClientSize.Width;
                var height = scrap.ClientSize.Height;
                var left = scrap.Location.X + (width - height) / 2;
                var top = scrap.Location.Y + (height - width) / 2;
                scrap.SuspendLayout();
                scrap.ClientSize = new Size(height, width);
                scrap.Left = left;
                scrap.Top = top;
                scrap.ResumeLayout();
            }
            scrap.Refresh();
        }

        // Token: 0x06000353 RID: 851 RVA: 0x000159DD File Offset: 0x00013BDD
        public override string GetName()
        {
            return "Rotate";
        }

        // Token: 0x06000354 RID: 852 RVA: 0x000159E4 File Offset: 0x00013BE4
        public override string GetDisplayName()
        {
            return "旋转和翻转";
        }

        // Token: 0x06000355 RID: 853 RVA: 0x000159EB File Offset: 0x00013BEB
        public override string GetDescription()
        {
            return "旋转和翻转参考图。";
        }

        // Token: 0x06000356 RID: 854 RVA: 0x000159F2 File Offset: 0x00013BF2
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new RotateStyleItemPanel(this);
        }

        // Token: 0x06000357 RID: 855 RVA: 0x000159FC File Offset: 0x00013BFC
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var crotateStyleItem = (CRotateStyleItem)newOwn;
            Rotate = crotateStyleItem.Rotate;
            VerticalReflection = crotateStyleItem.VerticalReflection;
            HorizonReflection = crotateStyleItem.HorizonReflection;
        }

        // Token: 0x06000358 RID: 856 RVA: 0x00015A34 File Offset: 0x00013C34
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Rotate;
        }

        // Token: 0x040001DB RID: 475
        public int Rotate;

        // Token: 0x040001DC RID: 476
        public bool VerticalReflection;

        // Token: 0x040001DD RID: 477
        public bool HorizonReflection;
    }
}
