using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x02000004 RID: 4
    public class CMarginStyleItem : CStyleItem
    {
        // Token: 0x06000015 RID: 21 RVA: 0x000030C0 File Offset: 0x000012C0
        public CMarginStyleItem()
        {
            MarginSize = 1;
            TopMost = true;
            SetMarginColor(Color.DarkGray);
            BorderStyle = 1;
        }

        // Token: 0x06000016 RID: 22 RVA: 0x000030E8 File Offset: 0x000012E8
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            var padding = scrap.Padding;
            switch (BorderStyle)
            {
                case 0:
                    scrap.FormBorderStyle = FormBorderStyle.None;
                    scrap.SolidFrame = false;
                    padding.All = 1;
                    scrap.BackColor = Color.FromArgb(25, 25, 25);
                    scrap.ActiveMargin = padding.All;
                    scrap.ShowInTaskbar = false;
                    scrap.TopMost = true;
                    break;
                case 1:
                    scrap.FormBorderStyle = FormBorderStyle.None;
                    scrap.SolidFrame = true;
                    padding.All = MarginSize;
                    scrap.BackColor = GetMarginColor();
                    scrap.ActiveMargin = padding.All;
                    scrap.ShowInTaskbar = false;
                    scrap.TopMost = true;
                    return;
                case 2:
                    if (scrap.FormBorderStyle != FormBorderStyle.FixedDialog)
                    {
                        scrap.FormBorderStyle = FormBorderStyle.FixedDialog;
                        scrap.SolidFrame = true;
                        padding.All = 0;
                        scrap.BackColor = Color.Black;
                        scrap.ActiveMargin = padding.All;
                        scrap.ShowInTaskbar = true;
                        scrap.TopMost = TopMost;
                        return;
                    }
                    break;
                default:
                    return;
            }
        }

        // Token: 0x06000017 RID: 23 RVA: 0x000031FD File Offset: 0x000013FD
        public void SetMarginColor(Color color)
        {
            MarginColorRed = color.R;
            MarginColorGreen = color.G;
            MarginColorBlue = color.B;
        }

        // Token: 0x06000018 RID: 24 RVA: 0x00003228 File Offset: 0x00001428
        public Color GetMarginColor()
        {
            return Color.FromArgb(MarginColorRed, MarginColorGreen, MarginColorBlue);
        }

        // Token: 0x06000019 RID: 25 RVA: 0x0000324E File Offset: 0x0000144E
        public override string GetName()
        {
            return "Frame";
        }

        // Token: 0x0600001A RID: 26 RVA: 0x00003255 File Offset: 0x00001455
        public override string GetDisplayName()
        {
            return "边框";
        }

        // Token: 0x0600001B RID: 27 RVA: 0x0000325C File Offset: 0x0000145C
        public override string GetDescription()
        {
            return "设置参考图的边框的种类。";
        }

        // Token: 0x0600001C RID: 28 RVA: 0x00003263 File Offset: 0x00001463
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new MarginStyleItemPanel(this);
        }

        // Token: 0x0600001D RID: 29 RVA: 0x0000326C File Offset: 0x0000146C
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var cmarginStyleItem = (CMarginStyleItem)newOwn;
            MarginSize = cmarginStyleItem.MarginSize;
            BorderStyle = cmarginStyleItem.BorderStyle;
            SetMarginColor(cmarginStyleItem.GetMarginColor());
            TopMost = cmarginStyleItem.TopMost;
        }

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x0600001E RID: 30 RVA: 0x000032B0 File Offset: 0x000014B0
        public override string StateText
        {
            get
            {
                var result = "";
                switch (BorderStyle)
                {
                    case 0:
                        result = "立体边框";
                        break;
                    case 1:
                        result = "单色边框";
                        break;
                    case 2:
                        result = "窗口";
                        break;
                }
                return result;
            }
        }

        // Token: 0x0600001F RID: 31 RVA: 0x000032F5 File Offset: 0x000014F5
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Frame;
        }

        // Token: 0x04000014 RID: 20
        public int MarginSize;

        // Token: 0x04000015 RID: 21
        public byte MarginColorRed;

        // Token: 0x04000016 RID: 22
        public byte MarginColorGreen;

        // Token: 0x04000017 RID: 23
        public byte MarginColorBlue;

        // Token: 0x04000018 RID: 24
        public int BorderStyle;

        // Token: 0x04000019 RID: 25
        public bool TopMost;

        // Token: 0x02000005 RID: 5
        public enum EnumBorderStyle
        {
            // Token: 0x0400001B RID: 27
            Bevel,
            // Token: 0x0400001C RID: 28
            Solid,
            // Token: 0x0400001D RID: 29
            Window
        }
    }
}
