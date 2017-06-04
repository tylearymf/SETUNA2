namespace SETUNA.Main
{
    using SETUNA.Main.StyleItems;
    using System;
    using System.Drawing;

    internal class StyleItemEditListBox : SetunaListBox
    {
        protected override void DrawItemString(Graphics g, object item, Font font, Brush brush, Rectangle bounds, StringFormat sf, int index)
        {
            if (index >= 0)
            {
                string nameAndState;
                if (!base.DesignMode)
                {
                    CStyleItem item2 = (CStyleItem) item;
                    nameAndState = item2.NameAndState;
                    item2.GetDescription();
                }
                else
                {
                    nameAndState = item.ToString();
                    item.ToString();
                }
                int terminate = this.GetTerminate();
                if ((index > terminate) && (terminate >= 0))
                {
                    brush = Brushes.Gray;
                }
                base.DrawItemString(g, nameAndState, font, brush, bounds, sf, index);
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
    }
}

