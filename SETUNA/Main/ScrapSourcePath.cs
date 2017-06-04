namespace SETUNA.Main
{
    using System;
    using System.Drawing;
    using System.IO;

    public class ScrapSourcePath : ScrapSource
    {
        private string path;

        public ScrapSourcePath(string path)
        {
            this.path = path;
        }

        public override Image GetImage()
        {
            Image image = null;
            FileStream stream = null;
            try
            {
                if (!File.Exists(this.path))
                {
                    return image;
                }
                try
                {
                    stream = new FileStream(this.path, FileMode.Open, FileAccess.Read);
                    image = Image.FromStream(stream);
                    base._name = Path.GetFileNameWithoutExtension(this.path);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }
            catch
            {
                Console.WriteLine("ScrapSourcePath错误∶" + this.path);
            }
            return image;
        }
    }
}

