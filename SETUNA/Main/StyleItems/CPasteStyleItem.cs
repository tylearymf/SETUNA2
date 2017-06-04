namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using SETUNA.Properties;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class CPasteStyleItem : CStyleItem
    {
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            Image img = null;
            if (Clipboard.ContainsImage())
            {
                img = Clipboard.GetImage();
            }
            else if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                if (File.Exists(text))
                {
                    FileStream stream = null;
                    try
                    {
                        stream = new FileStream(text, FileMode.Open, FileAccess.Read);
                        img = (Bitmap) Image.FromStream(stream);
                        stream.Close();
                        stream = null;
                    }
                    catch
                    {
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                    }
                }
            }
            if (img != null)
            {
                scrap.Manager.AddScrap(img, scrap.Left, scrap.Top, img.Width, img.Height);
            }
        }

        public override string GetDescription() => 
            "将剪贴板内的图像作为参考图。";

        public override string GetDisplayName() => 
            "从剪贴板粘贴";

        public override Bitmap GetIcon() => 
            Resources.Icon_Paste;

        public override string GetName() => 
            "Paste";

        protected override ToolBoxForm GetToolBoxForm() => 
            new NothingStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
        }

        public override bool IsInitApply =>
            false;
    }
}

