using System.Drawing;

namespace SETUNA.Main
{
    // Token: 0x0200003E RID: 62
    public class ScrapSourceUrl : ScrapSource
    {
        // Token: 0x06000261 RID: 609 RVA: 0x0000D139 File Offset: 0x0000B339
        public ScrapSourceUrl(string url, Point point, int width = 0, int height = 0)
        {
            this.url = url;
            this.point = point;
            BitmapUtils.DownloadImage(url, image =>
            {
                if (width != 0 && height != 0)
                {
                    image = image.ScaleToSize(width, height);
                }

                this.image = image;

                IsDone = true;
            });
        }

        // Token: 0x06000262 RID: 610 RVA: 0x0000D148 File Offset: 0x0000B348
        public override Image GetImage()
        {
            return image;
        }

        public override Point GetPosition()
        {
            return point;   
        }

        // Token: 0x0400010F RID: 271
        private string url;

        private Image image;

        private Point point;
    }
}
