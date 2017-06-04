namespace SETUNA.Main
{
    using SETUNA.Main.Style;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class ToolStripStyleButton : ToolStripMenuItem
    {
        private Image _image;
        private CStyle _style;

        public ToolStripStyleButton(CStyle style) : base(style.StyleName)
        {
            this._style = style;
        }

        public ToolStripStyleButton(CStyle style, Image image) : base(style.StyleName, image)
        {
            this._style = style;
            this._image = image;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._image != null)
                {
                    this._image.Dispose();
                }
                this._image = null;
            }
            base.Dispose(disposing);
        }

        protected override void OnClick(EventArgs e)
        {
            if (this._style != null)
            {
                ScrapBase scrap = ((ContextStyleMenuStrip) base.Owner).Scrap;
                this._style.Apply(ref scrap);
            }
        }
    }
}

