using System;
using System.Drawing;
using System.Windows.Forms;
using SETUNA.Main.Style;

namespace SETUNA.Main
{
    // Token: 0x0200005B RID: 91
    internal class ToolStripStyleButton : ToolStripMenuItem
    {
        // Token: 0x06000330 RID: 816 RVA: 0x00015559 File Offset: 0x00013759
        public ToolStripStyleButton(CStyle style) : base(style.StyleName)
        {
            _style = style;
        }

        // Token: 0x06000331 RID: 817 RVA: 0x0001556E File Offset: 0x0001376E
        public ToolStripStyleButton(CStyle style, Image image) : base(style.StyleName, image)
        {
            _style = style;
            _image = image;
        }

        // Token: 0x06000332 RID: 818 RVA: 0x0001558C File Offset: 0x0001378C
        protected override void OnClick(EventArgs e)
        {
            if (_style != null)
            {
                var scrap = ((ContextStyleMenuStrip)base.Owner).Scrap;
                _style.Apply(ref scrap);
            }
        }

        // Token: 0x06000333 RID: 819 RVA: 0x000155BF File Offset: 0x000137BF
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_image != null)
                {
                    _image.Dispose();
                }
                _image = null;
            }
            base.Dispose(disposing);
        }

        // Token: 0x040001D4 RID: 468
        private CStyle _style;

        // Token: 0x040001D5 RID: 469
        private Image _image;
    }
}
