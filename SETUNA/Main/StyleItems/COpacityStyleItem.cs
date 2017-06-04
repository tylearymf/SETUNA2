namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using SETUNA.Properties;
    using System;
    using System.Drawing;

    public class COpacityStyleItem : CStyleItem
    {
        protected double _opacity;
        public bool Absolute;
        public const int OpacityFixedDefault = 100;
        public const int OpacityFixedMax = 100;
        public const int OpacityFixedMin = 1;
        public const int OpacityRelativeDefault = 0;
        public const int OpacityRelativeMax = 0x63;
        public const int OpacityRelativeMin = -99;

        public COpacityStyleItem()
        {
            this.Opacity = 100;
            this.Absolute = true;
        }

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            if (this.Absolute)
            {
                if (this._opacity > 1.0)
                {
                    scrap.ActiveOpacity = 1.0;
                }
                else if (this._opacity < 0.01)
                {
                    scrap.ActiveOpacity = 0.01;
                }
                else
                {
                    scrap.ActiveOpacity = this._opacity;
                }
            }
            else if ((scrap.ActiveOpacity + this._opacity) > 1.0)
            {
                scrap.ActiveOpacity = 1.0;
            }
            else if ((scrap.ActiveOpacity + this._opacity) < 0.01)
            {
                scrap.ActiveOpacity = 0.01;
            }
            else
            {
                scrap.ActiveOpacity += this._opacity;
            }
        }

        public override string GetDescription() => 
            "设置不透明的参考图。";

        public override string GetDisplayName() => 
            "不透明度";

        public override Bitmap GetIcon() => 
            Resources.Icon_Opacoty;

        public override string GetName() => 
            "Opacity";

        protected override ToolBoxForm GetToolBoxForm() => 
            new OpacityStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            COpacityStyleItem item = (COpacityStyleItem) newOwn;
            this.Opacity = item.Opacity;
            this.Absolute = item.Absolute;
        }

        public int Opacity
        {
            get{return  
                ((int) (this._opacity * 100.0));}
            set
            {
                this._opacity = ((double) value) / 100.0;
            }
        }
    }
}

