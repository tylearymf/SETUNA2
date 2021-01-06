using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x02000061 RID: 97
    public class COpacityStyleItem : CStyleItem
    {
        // Token: 0x06000368 RID: 872 RVA: 0x00015C37 File Offset: 0x00013E37
        public COpacityStyleItem()
        {
            Opacity = 100;
            Absolute = true;
        }

        // Token: 0x17000084 RID: 132
        // (get) Token: 0x0600036A RID: 874 RVA: 0x00015C62 File Offset: 0x00013E62
        // (set) Token: 0x06000369 RID: 873 RVA: 0x00015C4E File Offset: 0x00013E4E
        public int Opacity
        {
            get => (int)(_opacity * 100.0);
            set => _opacity = value / 100.0;
        }

        // Token: 0x0600036B RID: 875 RVA: 0x00015C78 File Offset: 0x00013E78
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            if (Absolute)
            {
                if (_opacity > 1.0)
                {
                    scrap.ActiveOpacity = 1.0;
                    return;
                }
                if (_opacity < 0.01)
                {
                    scrap.ActiveOpacity = 0.01;
                    return;
                }
                scrap.ActiveOpacity = _opacity;
                return;
            }
            else
            {
                if (scrap.ActiveOpacity + _opacity > 1.0)
                {
                    scrap.ActiveOpacity = 1.0;
                    return;
                }
                if (scrap.ActiveOpacity + _opacity < 0.01)
                {
                    scrap.ActiveOpacity = 0.01;
                    return;
                }
                scrap.ActiveOpacity += _opacity;
                return;
            }
        }

        // Token: 0x0600036C RID: 876 RVA: 0x00015D47 File Offset: 0x00013F47
        public override string GetName()
        {
            return "Opacity";
        }

        // Token: 0x0600036D RID: 877 RVA: 0x00015D4E File Offset: 0x00013F4E
        public override string GetDisplayName()
        {
            return "不透明度";
        }

        // Token: 0x0600036E RID: 878 RVA: 0x00015D55 File Offset: 0x00013F55
        public override string GetDescription()
        {
            return "设置不透明的参考图。";
        }

        // Token: 0x0600036F RID: 879 RVA: 0x00015D5C File Offset: 0x00013F5C
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new OpacityStyleItemPanel(this);
        }

        // Token: 0x06000370 RID: 880 RVA: 0x00015D64 File Offset: 0x00013F64
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var copacityStyleItem = (COpacityStyleItem)newOwn;
            Opacity = copacityStyleItem.Opacity;
            Absolute = copacityStyleItem.Absolute;
        }

        // Token: 0x06000371 RID: 881 RVA: 0x00015D90 File Offset: 0x00013F90
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Opacoty;
        }

        // Token: 0x040001E8 RID: 488
        public const int OpacityRelativeMin = -99;

        // Token: 0x040001E9 RID: 489
        public const int OpacityRelativeMax = 99;

        // Token: 0x040001EA RID: 490
        public const int OpacityRelativeDefault = 0;

        // Token: 0x040001EB RID: 491
        public const int OpacityFixedMin = 1;

        // Token: 0x040001EC RID: 492
        public const int OpacityFixedMax = 100;

        // Token: 0x040001ED RID: 493
        public const int OpacityFixedDefault = 100;

        // Token: 0x040001EE RID: 494
        protected double _opacity;

        // Token: 0x040001EF RID: 495
        public bool Absolute;
    }
}
