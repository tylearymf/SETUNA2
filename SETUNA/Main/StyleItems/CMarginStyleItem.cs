namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using SETUNA.Properties;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class CMarginStyleItem : CStyleItem
    {
        public int BorderStyle;
        public byte MarginColorBlue;
        public byte MarginColorGreen;
        public byte MarginColorRed;
        public int MarginSize = 1;
        public bool TopMost = true;

        public CMarginStyleItem()
        {
            this.SetMarginColor(Color.DarkGray);
            this.BorderStyle = 1;
        }

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            Padding padding = scrap.Padding;
            switch (this.BorderStyle)
            {
                case 0:
                    scrap.FormBorderStyle = FormBorderStyle.None;
                    scrap.SolidFrame = false;
                    padding.All = 1;
                    scrap.BackColor = Color.FromArgb(0x19, 0x19, 0x19);
                    scrap.ActiveMargin = padding.All;
                    scrap.ShowInTaskbar = false;
                    scrap.TopMost = true;
                    break;

                case 1:
                    scrap.FormBorderStyle = FormBorderStyle.None;
                    scrap.SolidFrame = true;
                    padding.All = this.MarginSize;
                    scrap.BackColor = this.GetMarginColor();
                    scrap.ActiveMargin = padding.All;
                    scrap.ShowInTaskbar = false;
                    scrap.TopMost = true;
                    return;

                case 2:
                    if (scrap.FormBorderStyle == FormBorderStyle.FixedDialog)
                    {
                        break;
                    }
                    scrap.FormBorderStyle = FormBorderStyle.FixedDialog;
                    scrap.SolidFrame = true;
                    padding.All = 0;
                    scrap.BackColor = Color.Black;
                    scrap.ActiveMargin = padding.All;
                    scrap.ShowInTaskbar = true;
                    scrap.TopMost = this.TopMost;
                    return;

                default:
                    return;
            }
        }

        public override string GetDescription() => 
            "设置参考图的边框的种类。";

        public override string GetDisplayName() => 
            "边框";

        public override Bitmap GetIcon() => 
            Resources.Icon_Frame;

        public Color GetMarginColor() => 
            Color.FromArgb(this.MarginColorRed, this.MarginColorGreen, this.MarginColorBlue);

        public override string GetName() => 
            "Frame";

        protected override ToolBoxForm GetToolBoxForm() => 
            new MarginStyleItemPanel(this);

        public void SetMarginColor(Color color)
        {
            this.MarginColorRed = color.R;
            this.MarginColorGreen = color.G;
            this.MarginColorBlue = color.B;
        }

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CMarginStyleItem item = (CMarginStyleItem) newOwn;
            this.MarginSize = item.MarginSize;
            this.BorderStyle = item.BorderStyle;
            this.SetMarginColor(item.GetMarginColor());
            this.TopMost = item.TopMost;
        }

        public override string StateText
        {
            get
            {
                switch (this.BorderStyle)
                {
                    case 0:
                        return "立体边框";

                    case 1:
                        return "单色边框";

                    case 2:
                        return "窗口";
                }
                return "";
            }
        }

        public enum EnumBorderStyle
        {
            Bevel,
            Solid,
            Window
        }
    }
}

