using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace SETUNA.Main
{
    class Cache
    {
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
        static string mPath = string.Empty;

        static public void SaveImage(string pGuid, Image pImage)
        {
            if (pImage == null) return;
            try
            {
                var tName = pGuid + ".jpeg";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                string tPath = Path.Combine(path, tName);
                if (File.Exists(tPath)) return;
                Console.WriteLine(tPath);
                pImage.Save(tPath, ImageFormat.Jpeg);
                Console.WriteLine("缓存图片成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("保存图片失败：" + ex.ToString());
            }
        }

        static public void DestroyImage(string pGuid)
        {
            try
            {
                var tName = pGuid + ".jpeg";
                string tPath = Path.Combine(path, tName);
                if (File.Exists(tPath)) File.Delete(tPath);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
    }
}
