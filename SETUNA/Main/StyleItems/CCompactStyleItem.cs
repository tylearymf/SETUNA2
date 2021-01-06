using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x02000064 RID: 100
    public class CCompactStyleItem : CStyleItem
    {
        // Token: 0x06000389 RID: 905 RVA: 0x00016048 File Offset: 0x00014248
        public CCompactStyleItem()
        {
            Opacity = 100;
            LineColor = Color.Blue.ToArgb();
            SoldLine = false;
        }

        // Token: 0x0600038A RID: 906 RVA: 0x00016080 File Offset: 0x00014280
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            var compactScrap = new CompactScrap(scrap, this, clickpoint);
            compactScrap.Show();
        }

        // Token: 0x0600038B RID: 907 RVA: 0x0001609D File Offset: 0x0001429D
        public override string GetName()
        {
            return "Compact";
        }

        // Token: 0x0600038C RID: 908 RVA: 0x000160A4 File Offset: 0x000142A4
        public override string GetDisplayName()
        {
            return "收缩";
        }

        // Token: 0x0600038D RID: 909 RVA: 0x000160AB File Offset: 0x000142AB
        public override string GetDescription()
        {
            return "将参考图的尺寸收缩。\n之后的自动操作将不被使用。";
        }

        // Token: 0x0600038E RID: 910 RVA: 0x000160B2 File Offset: 0x000142B2
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new CompactStyleItemPanel(this);
        }

        // Token: 0x0600038F RID: 911 RVA: 0x000160BC File Offset: 0x000142BC
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var ccompactStyleItem = (CCompactStyleItem)newOwn;
            Opacity = ccompactStyleItem.Opacity;
            LineColor = ccompactStyleItem.LineColor;
            SoldLine = ccompactStyleItem.SoldLine;
        }

        // Token: 0x17000089 RID: 137
        // (get) Token: 0x06000390 RID: 912 RVA: 0x000160F4 File Offset: 0x000142F4
        public override bool IsTerminate => true;

        // Token: 0x06000391 RID: 913 RVA: 0x000160F7 File Offset: 0x000142F7
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Compact;
        }

        // Token: 0x040001F3 RID: 499
        public static int OpacityMinValue = 10;

        // Token: 0x040001F4 RID: 500
        public static int OpacityMaxValue = 100;

        // Token: 0x040001F5 RID: 501
        public byte Opacity;

        // Token: 0x040001F6 RID: 502
        public int LineColor;

        // Token: 0x040001F7 RID: 503
        public bool SoldLine;
    }
}
