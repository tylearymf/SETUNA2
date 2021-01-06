using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Newtonsoft.Json;

namespace SETUNA.Main.Cache
{
    public class CacheItem
    {
        private const string ImageFileName = "Image.png";
        private const string InfoFileName = "Info.json";


        // 创建时间
        public DateTime CreateTime { set; get; }
        // 位置
        public Point Position { set; get; }
        // 样式
        public Style Style { set; get; }
        // 排序值
        public int SortingOrder { set; get; }


        public string FolderPath => Path.Combine(CacheManager.Path, CreateTime.ToCustomString());

        public bool IsValid
        {
            get
            {
                var fullPath = Path.Combine(FolderPath, ImageFileName);
                return File.Exists(fullPath);
            }
        }


        protected CacheItem()
        {
        }


        // 创建缓存
        public static CacheItem Create(DateTime createTime, Image image, Point pos, Style style)
        {
            var item = new CacheItem
            {
                CreateTime = createTime,
                Position = pos,
                Style = style
            };

            item.SaveImage(image);
            item.SaveInfo();

            return item;
        }

        // 读取缓存
        public static CacheItem Read(string cacheItemPath)
        {
            var fullPath = Path.Combine(cacheItemPath, InfoFileName);
            if (File.Exists(fullPath))
            {
                var content = File.ReadAllText(fullPath);
                var item = JsonConvert.DeserializeObject<CacheItem>(content);

                return item;
            }

            return null;
        }


        public Image ReadImage()
        {
            var fullPath = Path.Combine(FolderPath, ImageFileName);
            if (File.Exists(fullPath))
            {
                using (var fs = new FileStream(fullPath, FileMode.Open))
                {
                    return Image.FromStream(fs);
                }
            }

            return null;
        }

        public void SaveImage(Image image)
        {
            if (image == null)
            {
                return;
            }

            var folderPath = FolderPath;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fullPath = Path.Combine(folderPath, ImageFileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            using (var temp = new Bitmap(image))
            {
                temp.Save(fullPath, ImageFormat.Png);
            }
        }

        public void SaveInfo()
        {
            var folderPath = FolderPath;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fullPath = Path.Combine(folderPath, InfoFileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            var item = new
            {
                CreateTime = CreateTime,
                Position = Position,
                Style = Style,
                SortingOrder = SortingOrder,
            };
            var json = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(fullPath, json);
        }

        public void Delete()
        {
            var folderPath = FolderPath;
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }
    }

    public struct Style
    {
        public int ID { set; get; }
        public Point ClickPoint { set; get; }


        public Style(int id, Point point)
        {
            ID = id;
            ClickPoint = point;
        }
    }
}
