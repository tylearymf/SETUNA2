namespace SETUNA.Main
{
    using SETUNA.Main.StyleItems;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Runtime.CompilerServices;

    internal class StyleItemListBox : SetunaListBox
    {
        public StyleItemListBox()
        {
            this.ItemHeight = 0x27;
            base.LeftSpace = 0x22;
            this.TerminateEnd = false;
            this.HelpFont = new Font(this.Font, FontStyle.Regular);
            this.HelpForeColor = Color.Gray;
        }

        protected override void DrawItemString(Graphics g, object item, Font font, Brush brush, Rectangle bounds, StringFormat sf, int index)
        {
            if (index >= 0)
            {
                string displayName;
                string description;
                Rectangle rectangle = bounds;
                if (!base.DesignMode)
                {
                    CStyleItem item2 = (CStyleItem) item;
                    displayName = item2.GetDisplayName();
                    description = item2.GetDescription();
                    Bitmap icon = item2.GetIcon();
                    if (icon != null)
                    {
                        g.DrawImage(icon, 2, rectangle.Top + 2);
                    }
                }
                else
                {
                    displayName = item.ToString();
                    description = item.ToString();
                }
                if (this.TerminateEnd && !base.DesignMode)
                {
                    int terminate = this.GetTerminate();
                    if ((index > terminate) && (terminate >= 0))
                    {
                        brush = Brushes.Gray;
                    }
                }
                base.DrawItemString(g, displayName, this.Font, brush, bounds, sf, index);
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                sf.FormatFlags -= 0x1000;
                bounds.Y += ((int) this.Font.GetHeight()) + 2;
                bounds.Height = this.ItemHeight - ((((int) this.Font.GetHeight()) + 2) + 2);
                base.DrawItemString(g, description, this.HelpFont, new SolidBrush(this.HelpForeColor), bounds, sf, index);
            }
        }

        protected int GetTerminate()
        {
            for (int i = 0; i < base.Items.Count; i++)
            {
                CStyleItem item = (CStyleItem) base.Items[i];
                if (item.IsTerminate)
                {
                    return i;
                }
            }
            return -1;
        }

        [Browsable(true), Description("アイテム説明用のフォントです。")]
        public Font HelpFont { get; set; }

        [Description("アイテム説明用フォント色です。"), Browsable(true)]
        public Color HelpForeColor { get; set; }

        [Browsable(true), Description("終端アイテムで表示を無効にするか。")]
        public bool TerminateEnd { get; set; }
    }
}

