using System;
using System.Drawing;
using System.IO;

namespace SETUNA.Main
{
    // Token: 0x0200003E RID: 62
    public class ScrapSourcePath : ScrapSource
    {
        // Token: 0x06000261 RID: 609 RVA: 0x0000D139 File Offset: 0x0000B339
        public ScrapSourcePath(string path)
        {
            this.path = path;
        }

        // Token: 0x06000262 RID: 610 RVA: 0x0000D148 File Offset: 0x0000B348
        public override Image GetImage()
        {
            Image result = null;
            FileStream fileStream = null;
            try
            {
                if (File.Exists(path))
                {
                    try
                    {
                        fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                        result = Image.FromStream(fileStream);
                        _name = Path.GetFileNameWithoutExtension(path);
                    }
                    finally
                    {
                        if (fileStream != null)
                        {
                            fileStream.Close();
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("ScrapSourcePath错误∶" + path);
            }
            return result;
        }

        // Token: 0x0400010F RID: 271
        private string path;
    }
}
