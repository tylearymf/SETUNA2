using System.Drawing;
using SETUNA.Main.StyleItems;

namespace SETUNA.Main
{
    // Token: 0x020000AB RID: 171
    internal class StyleItemEditListBox : SetunaListBox
    {
        // Token: 0x06000584 RID: 1412 RVA: 0x000261CC File Offset: 0x000243CC
        protected override void DrawItemString(Graphics g, object item, Font font, Brush brush, Rectangle bounds, StringFormat sf, int index)
        {
            if (index < 0)
            {
                return;
            }
            string item2;
            if (!base.DesignMode)
            {
                var cstyleItem = (CStyleItem)item;
                item2 = cstyleItem.NameAndState;
                cstyleItem.GetDescription();
            }
            else
            {
                item2 = item.ToString();
                item.ToString();
            }
            var terminate = GetTerminate();
            if (index > terminate && terminate >= 0)
            {
                brush = Brushes.Gray;
            }
            base.DrawItemString(g, item2, font, brush, bounds, sf, index);
        }

        // Token: 0x06000585 RID: 1413 RVA: 0x00026234 File Offset: 0x00024434
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
