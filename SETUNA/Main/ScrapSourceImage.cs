using System.Drawing;

namespace SETUNA.Main
{
    // Token: 0x02000057 RID: 87
    public class ScrapSourceImage : ScrapSource
    {
        // Token: 0x06000320 RID: 800 RVA: 0x0001534C File Offset: 0x0001354C
        public ScrapSourceImage(Image img)
        {
            this.img = (Image)img.Clone();
            position = Point.Empty;
        }

        // Token: 0x06000321 RID: 801 RVA: 0x00015370 File Offset: 0x00013570
        public ScrapSourceImage(Image img, Point position)
        {
            this.img = (Image)img.Clone();
            this.position = position;
        }

        // Token: 0x06000322 RID: 802 RVA: 0x00015390 File Offset: 0x00013590
        public override Image GetImage()
        {
            return img;
        }

        // Token: 0x06000323 RID: 803 RVA: 0x00015398 File Offset: 0x00013598
        public override Point GetPosition()
        {
            return position;
        }

        // Token: 0x06000324 RID: 804 RVA: 0x000153A0 File Offset: 0x000135A0
        public override void Dispose()
        {
            base.Dispose();
            if (img != null)
            {
                img.Dispose();
                img = null;
            }
        }

        // Token: 0x040001CC RID: 460
        private Image img;

        // Token: 0x040001CD RID: 461
        private Point position;
    }
}
