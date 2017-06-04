namespace SETUNA.Main
{
    using System;
    using System.Drawing;

    public class ScrapSourceImage : ScrapSource
    {
        private Image img;
        private Point position;

        public ScrapSourceImage(Image img)
        {
            this.img = (Image) img.Clone();
            this.position = Point.Empty;
        }

        public ScrapSourceImage(Image img, Point position)
        {
            this.img = (Image) img.Clone();
            this.position = position;
        }

        public override void Dispose()
        {
            base.Dispose();
            if (this.img != null)
            {
                this.img.Dispose();
                this.img = null;
            }
        }

        public override Image GetImage() => 
            this.img;

        public override Point GetPosition() => 
            this.position;
    }
}

