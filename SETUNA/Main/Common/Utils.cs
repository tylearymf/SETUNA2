using System.Drawing;
using System.Drawing.Drawing2D;

namespace SETUNA.Main
{
    class URLUtils
    {
        public const string OriginURL = "http://www.clearunit.com/clearup/setuna2/";

        public const string NewURL = "https://www.github.com/tylearymf/setuna2/";
    }


    static class BitmapUtils
    {
        public static Bitmap ScaleToSize(this Bitmap bitmap, int width, int height)
        {
            if (bitmap.Width == width && bitmap.Height == height)
            {
                return bitmap;
            }

            var scaledBitmap = new Bitmap(width, height);
            using (var g = Graphics.FromImage(scaledBitmap))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.DrawImage(bitmap, 0, 0, width, height);
            }

            return scaledBitmap;
        }
    }
}
