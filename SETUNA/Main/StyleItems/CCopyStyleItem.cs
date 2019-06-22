namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using Properties;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Image = System.Drawing.Image;

    public class CCopyStyleItem : CStyleItem
    {
        public bool CopyFromSource = false;

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            Image viewImage = null;
            try
            {
                if (this.CopyFromSource)
                {
                    viewImage = (Image) scrap.Image.Clone();
                }
                else
                {
                    viewImage = scrap.GetViewImage();
                }
                Clipboard.Clear();
                for (int i = 0; i < 5; i++)
                {
                    Clipboard.SetImage(viewImage);
                    if (Clipboard.ContainsImage())
                    {
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("CStyleItem Apply Exception:" + exception.Message);
            }
            finally
            {
                if (viewImage != null)
                {
                    viewImage.Dispose();
                }
            }
        }

        public override string GetDescription() => 
            "将参考图作为图像复制到剪贴板里。";

        public override string GetDisplayName() => 
            "复制到剪贴板";

        public override Bitmap GetIcon() => 
            Resources.Icon_Copy;

        public override string GetName() => 
            "Copy";

        protected override ToolBoxForm GetToolBoxForm() => 
            new CopyStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CCopyStyleItem item = (CCopyStyleItem) newOwn;
            this.CopyFromSource = item.CopyFromSource;
        }
    }
}

