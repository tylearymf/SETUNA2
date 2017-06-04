namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;
    using System;
    using System.Drawing;

    public class ScrapPaintTextLayerItem : ScrapPaintLayerItem
    {
        public ScrapPaintTextLayerItem(long layerID, int width, int height) : base(layerID, width, height)
        {
            base.picThumb.Image = new Bitmap(base.picThumb.Width, base.picThumb.Height);
            using (Graphics graphics = Graphics.FromImage(base.picThumb.Image))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, base.picThumb.Image.Width, base.picThumb.Image.Height);
                graphics.DrawImage(Resources.pi_text, (int) ((base.picThumb.Image.Width - Resources.pi_text.Width) / 2), (int) ((base.picThumb.Image.Height - Resources.pi_text.Height) / 2));
            }
        }

        protected override void DrawThumbnail()
        {
        }

        public Font GetCommandFont()
        {
            if (base.Commands.Count > 0)
            {
                TextToolCommand command = (TextToolCommand) base.Commands[base.Commands.Count - 1];
                return command.Font;
            }
            return new Font("Arial", 10f);
        }

        public override bool IsEditableTool(PaintTool tool)
        {
            if (tool.GetToolType == ScrapPaintToolBar.ToolKind.文字工具)
            {
                ((TextTool) tool).SetFont(this.GetCommandFont());
                return true;
            }
            return false;
        }

        protected override void Rasterize()
        {
            using (Graphics graphics = Graphics.FromImage(base._img))
            {
                graphics.FillRectangle(Brushes.Pink, 0, 0, base._img.Width, base._img.Height);
                if (base.Commands.Count > 0)
                {
                    base.Commands[base.Commands.Count - 1].Draw(graphics);
                }
            }
            base._img.MakeTransparent(Color.Pink);
            this.Refresh();
        }
    }
}

