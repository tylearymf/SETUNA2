using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x020000AD RID: 173
    public class ScrapPaintTextLayerItem : ScrapPaintLayerItem
    {
        // Token: 0x0600058D RID: 1421 RVA: 0x00026324 File Offset: 0x00024524
        public ScrapPaintTextLayerItem(long layerID, int width, int height) : base(layerID, width, height)
        {
            picThumb.Image = new Bitmap(picThumb.Width, picThumb.Height);
            using (var graphics = Graphics.FromImage(picThumb.Image))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, picThumb.Image.Width, picThumb.Image.Height);
                graphics.DrawImage(Resources.pi_text, (picThumb.Image.Width - Resources.pi_text.Width) / 2, (picThumb.Image.Height - Resources.pi_text.Height) / 2);
            }
        }

        // Token: 0x0600058E RID: 1422 RVA: 0x00026400 File Offset: 0x00024600
        public override bool IsEditableTool(PaintTool tool)
        {
            var getToolType = tool.GetToolType;
            if (getToolType == ScrapPaintToolBar.ToolKind.文字工具)
            {
                var textTool = (TextTool)tool;
                textTool.SetFont(GetCommandFont());
                return true;
            }
            return false;
        }

        // Token: 0x0600058F RID: 1423 RVA: 0x0002642E File Offset: 0x0002462E
        protected override void DrawThumbnail()
        {
        }

        // Token: 0x06000590 RID: 1424 RVA: 0x00026430 File Offset: 0x00024630
        protected override void Rasterize()
        {
            using (var graphics = Graphics.FromImage(_img))
            {
                graphics.FillRectangle(Brushes.Pink, 0, 0, _img.Width, _img.Height);
                if (Commands.Count > 0)
                {
                    Commands[Commands.Count - 1].Draw(graphics);
                }
            }
            _img.MakeTransparent(Color.Pink);
            Refresh();
        }

        // Token: 0x06000591 RID: 1425 RVA: 0x000264CC File Offset: 0x000246CC
        public Font GetCommandFont()
        {
            if (Commands.Count > 0)
            {
                var textToolCommand = (TextToolCommand)Commands[Commands.Count - 1];
                return textToolCommand.Font;
            }
            return new Font("Arial", 10f);
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(picThumb)).BeginInit();
            SuspendLayout();
            // 
            // ScrapPaintTextLayerItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            Name = "ScrapPaintTextLayerItem";
            ((System.ComponentModel.ISupportInitialize)(picThumb)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
