using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using SETUNA.Main.StyleItems;

namespace SETUNA.Main
{
    // Token: 0x02000083 RID: 131
    internal class StyleItemListBox : SetunaListBox
    {
        // Token: 0x170000A9 RID: 169
        // (get) Token: 0x0600045D RID: 1117 RVA: 0x0001C809 File Offset: 0x0001AA09
        // (set) Token: 0x0600045C RID: 1116 RVA: 0x0001C800 File Offset: 0x0001AA00
        [Browsable(true)]
        [Description("アイテム説明用のフォントです。")]
        public Font HelpFont { get; set; }

        // Token: 0x170000AA RID: 170
        // (get) Token: 0x0600045F RID: 1119 RVA: 0x0001C81A File Offset: 0x0001AA1A
        // (set) Token: 0x0600045E RID: 1118 RVA: 0x0001C811 File Offset: 0x0001AA11
        [Description("アイテム説明用フォント色です。")]
        [Browsable(true)]
        public Color HelpForeColor { get; set; }

        // Token: 0x170000AB RID: 171
        // (get) Token: 0x06000461 RID: 1121 RVA: 0x0001C82B File Offset: 0x0001AA2B
        // (set) Token: 0x06000460 RID: 1120 RVA: 0x0001C822 File Offset: 0x0001AA22
        [Browsable(true)]
        [Description("終端アイテムで表示を無効にするか。")]
        public bool TerminateEnd { get; set; }

        // Token: 0x06000462 RID: 1122 RVA: 0x0001C833 File Offset: 0x0001AA33
        public StyleItemListBox()
        {
            ItemHeight = 39;
            base.LeftSpace = 34;
            TerminateEnd = false;
            HelpFont = new Font(Font, FontStyle.Regular);
            HelpForeColor = Color.Gray;
        }

        // Token: 0x06000463 RID: 1123 RVA: 0x0001C870 File Offset: 0x0001AA70
        protected override void DrawItemString(Graphics g, object item, Font font, Brush brush, Rectangle bounds, StringFormat sf, int index)
        {
            if (index < 0)
            {
                return;
            }
            var rectangle = bounds;
            string item2;
            string item3;
            if (!base.DesignMode)
            {
                var cstyleItem = (CStyleItem)item;
                item2 = cstyleItem.GetDisplayName();
                item3 = cstyleItem.GetDescription();
                var icon = cstyleItem.GetIcon();
                if (icon != null)
                {
                    g.DrawImage(icon, 2, rectangle.Top + 2);
                }
            }
            else
            {
                item2 = item.ToString();
                item3 = item.ToString();
            }
            if (TerminateEnd && !base.DesignMode)
            {
                var terminate = GetTerminate();
                if (index > terminate && terminate >= 0)
                {
                    brush = Brushes.Gray;
                }
            }
            base.DrawItemString(g, item2, Font, brush, bounds, sf, index);
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            sf.FormatFlags -= 4096;
            bounds.Y += (int)Font.GetHeight() + 2;
            bounds.Height = ItemHeight - ((int)Font.GetHeight() + 2 + 2);
            base.DrawItemString(g, item3, HelpFont, new SolidBrush(HelpForeColor), bounds, sf, index);
        }

        // Token: 0x06000464 RID: 1124 RVA: 0x0001C988 File Offset: 0x0001AB88
        protected int GetTerminate()
        {
            var result = -1;
            for (var i = 0; i < base.Items.Count; i++)
            {
                var cstyleItem = (CStyleItem)base.Items[i];
                if (cstyleItem.IsTerminate)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
}
