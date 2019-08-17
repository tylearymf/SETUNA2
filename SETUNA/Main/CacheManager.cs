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
        ScrapWeightInfo mWeightInfo;

        public ScrapWeightInfo weightInfo { get => mWeightInfo; private set => mWeightInfo = value; }

        public Image image
        {
            get => weightInfo.image;
        }

        public string name { set; get; }
        public int posX { set; get; }
        public int posY { set; get; }
        public int imageWidth { set; get; }
        public int imageHeight { set; get; }
        public string guid { set; get; }
        public int styleID { set; get; }
        public Point stylePoint { set; get; }

        protected ScrapBaseInfo() { }

        public ScrapBaseInfo(Image pImage, int pPosX, int pPosY, int pImageWidth, int pImageHeight, string pGuid)
        {
            weightInfo = new ScrapWeightInfo(pImage);

            name = string.Empty;
            posX = pPosX;
            posY = pPosY;
            imageWidth = pImageWidth;
            imageHeight = pImageHeight;
            guid = pGuid;
        }

        public void InitWeightInfo(ScrapWeightInfo pInfo)
        {
            weightInfo = pInfo;
        }

        public override string ToString()
        {
            return string.Format("CacheInfo. guid:{0}, posx:{1},posy:{2},width:{3},height:{4}", guid, posX, posY, imageWidth, imageHeight);
        }

        public string GetFileName()
        {
            return CacheManager.cInfoName1 + CacheManager.cExtension;
        }

        public string GetFolderName()
        {
            return Path.Combine(CacheManager.path, guid);
        }
    }

    [Serializable]
    public class ScrapWeightInfo
    {
        [NonSerialized]
        Image mImage;
        Image mSerialImage;

        public ScrapWeightInfo(Image pImage)
        {
            image = pImage;
        }

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

        public void Init()
        {
            if (mSerialImage == null || mImage != null) return;

            mImage = new Bitmap(mSerialImage);
        }

        public string GetFileName()
        {
            return CacheManager.cInfoName2 + CacheManager.cExtension;
        }
    }

    public class CacheManager
    {
        public const string cExtension = ".dat";
        public const string cInfoName1 = "info1";
        public const string cInfoName2 = "info2";

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
            var tDirectories = tInfo.GetDirectories("*", SearchOption.TopDirectoryOnly);
            foreach (var tDirectoryInfo in tDirectories)
            {
                var tFolderName = tDirectoryInfo.FullName;
                var tInfoPath1 = Path.Combine(tFolderName, cInfoName1 + cExtension);
                var tInfoPath2 = Path.Combine(tFolderName, cInfoName2 + cExtension);

                if (File.Exists(tInfoPath1) && File.Exists(tInfoPath2))
                {
                    try
                    {
                        var tInfo1 = Deserialize<ScrapBaseInfo>(tInfoPath1);
                        var tInfo2 = Deserialize<ScrapWeightInfo>(tInfoPath2);

                        tInfo2.Init();
                        tInfo1.InitWeightInfo(tInfo2);
                        MyConsole.WriteLine(tInfo1.ToString());

                        pCallBack(tInfo1);
                    }
                    catch (Exception ex)
                    {
                        MyConsole.WriteLine("加载图片失败：" + ex.ToString());
                    }
                }
            }
        }

        static public void SaveCacheInfo(ScrapBaseInfo pInfo)
        {
            if (pInfo == null || pInfo.image == null) return;

            try
            {
                var tFolderName = pInfo.GetFolderName();
                if (!Directory.Exists(tFolderName))
                {
                    Directory.CreateDirectory(tFolderName);
                }

                var tPath = Path.Combine(tFolderName, pInfo.GetFileName());
                Serialize(pInfo, tPath);

                tPath = Path.Combine(tFolderName, pInfo.weightInfo.GetFileName());
                if (!File.Exists(tPath))
                {
                    Serialize(pInfo.weightInfo, tPath);
                }

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
                var tPath = pInfo.GetFolderName();
                if (Directory.Exists(tPath))
                {
                    Directory.Delete(tPath, true);
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
