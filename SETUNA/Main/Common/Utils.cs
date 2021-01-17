using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media.Imaging;
using Svg;

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

        public static Bitmap FromPath(string path)
        {
            if (File.Exists(path))
            {

                byte[] buffer = null;
                MemoryStream stream = null;
                Bitmap bitmap = null;

                try
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        buffer = new byte[fs.Length];
                        stream = new MemoryStream(buffer);
                        fs.CopyTo(stream);
                        stream.Seek(0, SeekOrigin.Begin);
                    }

                    var imageType = ImageUtils.GetImageType(buffer);
                    switch (imageType)
                    {
                        case ImageType.PNG:
                            bitmap = new Bitmap(stream);
                            break;
                        case ImageType.WEBP:
                            using (var webp = new WebPWrapper.WebP())
                            {
                                bitmap = webp.Decode(buffer);
                            }
                            break;
                        case ImageType.SVG:
                            bitmap = SvgDocument.Open<SvgDocument>(stream).Draw();
                            break;
                        case ImageType.PSD:
                            var psdFile = new System.Drawing.PSD.PsdFile();
                            psdFile.Load(path);
                            bitmap = System.Drawing.PSD.ImageDecoder.DecodeImage(psdFile);
                            break;
                        case ImageType.ICO:
                            using (var icon = new Icon(path))
                            {
                                bitmap = icon.ToBitmap();
                            }
                            break;
                        case ImageType.TGA:
                            using (var reader = new BinaryReader(stream))
                            {
                                var image = new TgaLib.TgaImage(reader);
                                bitmap = image.GetBitmap().ToBitmap();
                            }
                            break;
                        default:
                            bitmap = new Bitmap(stream);
                            break;
                    }

                    return bitmap;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Dispose();
                    }
                }
            }

            return null;
        }

        public static void DownloadImage(string url, Action<Bitmap> finished)
        {
            var filePath = Path.Combine(Cache.CacheManager.Path, string.Format("TEMP_{0}_{1}.png", DateTime.Now.Ticks, Math.Abs(url.GetHashCode())));
            var client = new WebClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            client.DownloadFileCompleted += (s, e) =>
            {
                Bitmap bitmap = null;

                if (e.Error == null)
                {
                    try
                    {
                        bitmap = BitmapUtils.FromPath(filePath);
                    }
                    catch { }
                }

                try
                {
                    File.Delete(filePath);
                }
                catch { }

                finished?.Invoke(bitmap);
            };
            client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.141 Safari/537.36";
            client.DownloadFileAsync(new Uri(url), filePath);
        }

        public static Bitmap ToBitmap(this BitmapSource source)
        {
            Bitmap bitmap;
            using (var outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(source));
                enc.Save(outStream);
                bitmap = new Bitmap(outStream);
            }
            return bitmap;
        }
    }

    static class NetUtils
    {
        public static void Init()
        {
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
        }

        static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }
    }

    static class ImageUtils
    {
        public static ImageType GetImageType(byte[] imageBuffer)
        {
            if (imageBuffer.Length > 3 &&
                imageBuffer[1] == 0x50 &&
                imageBuffer[2] == 0x4E &&
                imageBuffer[3] == 0x47)
            {
                return ImageType.PNG;
            }
            else if (imageBuffer.Length > 9 &&
                imageBuffer[6] == 0x4A &&
                imageBuffer[7] == 0x46 &&
                imageBuffer[8] == 0x49 &&
                imageBuffer[9] == 0x46)
            {
                return ImageType.JPEG;
            }
            else if (imageBuffer.Length > 10 &&
                imageBuffer[8] == 0x57 &&
                imageBuffer[9] == 0x45 &&
                imageBuffer[10] == 0x42)
            {
                return ImageType.WEBP;
            }
            else if (imageBuffer.Length > 2 &&
               imageBuffer[0] == 0x47 &&
               imageBuffer[1] == 0x49 &&
               imageBuffer[2] == 0x46)
            {
                return ImageType.GIF;
            }
            else if (imageBuffer.Length > 2 &&
               imageBuffer[1] == 0x73 &&
               imageBuffer[2] == 0x76 &&
               imageBuffer[3] == 0x67)
            {
                return ImageType.SVG;
            }
            else if (imageBuffer.Length > 2 &&
               imageBuffer[0] == 0x38 &&
               imageBuffer[1] == 0x42 &&
               imageBuffer[2] == 0x50 &&
               imageBuffer[3] == 0x53)
            {
                return ImageType.PSD;
            }
            else if (imageBuffer.Length > 5 &&
              imageBuffer[0] == 0x00 &&
              imageBuffer[1] == 0x00 &&
              imageBuffer[2] == 0x01 &&
              imageBuffer[3] == 0x00 &&
              imageBuffer[4] == 0x01 &&
              imageBuffer[5] == 0x00)
            {
                return ImageType.ICO;
            }
            else if (TGAUtils.IsTGA(imageBuffer))
            {
                return ImageType.TGA;
            }

            return ImageType.Unknown;
        }
    }

    static class TGAUtils
    {
        public static bool IsTGA(byte[] imageBuffer)
        {
            if (imageBuffer.Length > 16)
            {
                var imageType = imageBuffer[2];
                var colorMapDepth = imageBuffer[7];
                var pixelDepth = imageBuffer[16];

                switch (imageType)
                {
                    case 1:
                    case 9:
                        if (colorMapDepth - 15 <= 1 || colorMapDepth == 24 || colorMapDepth == 32)
                        {
                            return true;
                        }
                        break;
                    case 2:
                    case 10:
                        if (pixelDepth - 15 <= 1 || pixelDepth == 24 || pixelDepth == 32)
                        {
                            return true;
                        }
                        break;
                    case 3:
                    case 11:
                        if (pixelDepth == 8)
                        {
                            return true;
                        }
                        break;
                }
            }

            return false;
        }
    }

    public enum ImageType
    {
        Unknown,
        JPEG,
        PNG,
        WEBP,
        GIF,
        SVG,
        PSD,
        ICO,
        TGA,
    }
}

