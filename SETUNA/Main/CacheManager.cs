using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using SETUNA.Main.StyleItems;
using SETUNA.Main.Style;
using SETUNA.Main.Other;

namespace SETUNA.Main
{
    [Serializable]
    public class ScrapBaseInfo
    {
        [NonSerialized]
        Image mImage;
        Image mSerialImage;

        public string name { set; get; }
        public Image image
        {
            private set
            {
                mImage = value;
                mSerialImage = new Bitmap(value);
            }
            get
            {
                return mImage;
            }
        }
        public int posX { set; get; }
        public int posY { set; get; }
        public int imageWidth { private set; get; }
        public int imageHeight { private set; get; }
        public string guid { private set; get; }
        public int styleID { set; get; }
        public Point stylePoint { set; get; }

        protected ScrapBaseInfo() { }

        public ScrapBaseInfo(Image pImage, int pPosX, int pPosY, int pImageWidth, int pImageHeight, string pGuid)
        {
            name = string.Empty;
            image = pImage;
            posX = pPosX;
            posY = pPosY;
            imageWidth = pImageWidth;
            imageHeight = pImageHeight;
            guid = pGuid;
        }

        public void Init()
        {
            if (mSerialImage == null || mImage != null) return;

            mImage = new Bitmap(mSerialImage);
        }

        public override string ToString()
        {
            return string.Format("CacheInfo. guid:{0}, posx:{1},posy:{2},width:{3},height:{4}", guid, posX, posY, imageWidth, imageHeight);
        }

        public string GetFileName()
        {
            return guid + CacheManager.cExtension;
        }

        public string GetFullName()
        {
            return Path.Combine(CacheManager.path, GetFileName());
        }
    }

    public class CacheManager
    {
        public const string cExtension = ".dat";

        static string mPath;
        static public string path
        {
            get
            {
                if (string.IsNullOrEmpty(mPath))
                {
                    mPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SETUNA2");
                }
                return mPath;
            }
        }

        static public void Init(Action<ScrapBaseInfo> pCallBack)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var tInfo = new DirectoryInfo(path);
            var tFiles = tInfo.GetFiles("*" + cExtension);
            foreach (var tFileInfo in tFiles)
            {
                try
                {
                    var tCacheInfo = Deserialize<ScrapBaseInfo>(tFileInfo.FullName);
                    if (tCacheInfo == null) continue;
                    tCacheInfo.Init();
                    MyConsole.WriteLine(tCacheInfo.ToString());

                    pCallBack(tCacheInfo);
                }
                catch (Exception ex)
                {
                    MyConsole.WriteLine("加载图片失败：" + ex.ToString());
                }
            }
        }

        static public void SaveCacheInfo(ScrapBaseInfo pInfo)
        {
            if (pInfo == null || pInfo.image == null) return;

            try
            {
                Serialize(pInfo, pInfo.GetFullName());

                MyConsole.WriteLine("缓存图片成功. {0}", pInfo.ToString());
            }
            catch (Exception ex)
            {
                MyConsole.WriteLine("缓存图片失败. {0}\n{1}", pInfo.ToString(), ex.ToString());
            }
        }

        static public void DeleteCacheInfo(ScrapBaseInfo pInfo)
        {
            try
            {
                var tPath = pInfo.GetFullName();
                if (File.Exists(tPath))
                {
                    File.Delete(tPath);
                }
                MyConsole.WriteLine("删除图片成功. {0}", pInfo.ToString());
            }
            catch (Exception ex)
            {
                MyConsole.WriteLine("删除图片失败. {0}\n{1|", pInfo.ToString(), ex.ToString());
            }
        }

        static void Serialize<T>(T pObject, string pPath) where T : class
        {
            if (pObject == null) return;

            try
            {
                if (File.Exists(pPath)) File.Delete(pPath);

                using (var tStream = new FileStream(pPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    var tFormater = new BinaryFormatter();
                    tFormater.Serialize(tStream, pObject);
                    tStream.Close();
                }
            }
            catch (Exception ex)
            {
                MyConsole.WriteLine(ex.ToString());
            }
        }

        static T Deserialize<T>(string pPath) where T : class
        {
            if (!File.Exists(pPath)) return null;

            object tInfo = null;
            try
            {
                using (var tStream = new MemoryStream(File.ReadAllBytes(pPath)))
                {
                    if (tStream.Length != 0)
                    {
                        var tFormater = new BinaryFormatter();
                        tInfo = tFormater.Deserialize(tStream);
                        tStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MyConsole.WriteLine(ex.ToString());
            }

            return tInfo as T;
        }

        static public void CleanAll()
        {
            if (Directory.Exists(path))
            {
                foreach (var item in new DirectoryInfo(path).GetFiles())
                {
                    item.Delete();
                }
            }
        }
    }
}
