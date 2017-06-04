namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using SETUNA.Properties;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class CScaleStyleItem : CStyleItem
    {
        protected ScaleSetType _fixed;
        protected System.Drawing.Drawing2D.InterpolationMode _interpolationmode;
        protected int _scalevalue;
        public const System.Drawing.Drawing2D.InterpolationMode DefaultInterpolation = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        public const int FixedScaleDefault = 100;
        public const int FixedScaleMax = 200;
        public const int FixedScaleMin = 10;
        public const int RelativeScaleDefault = 0;
        public const int RelativeScaleMax = 190;
        public const int RelativeScaleMin = -190;

        public CScaleStyleItem()
        {
            this.Value = 100;
        }

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            if (this._fixed == ScaleSetType.Fixed)
            {
                scrap.Scale = this._scalevalue;
            }
            else
            {
                scrap.Scale += this._scalevalue;
            }
            if (this._interpolationmode != System.Drawing.Drawing2D.InterpolationMode.Invalid)
            {
                if (this._interpolationmode != System.Drawing.Drawing2D.InterpolationMode.Low)
                {
                    scrap.InterpolationMode = this._interpolationmode;
                }
                else
                {
                    switch (scrap.InterpolationMode)
                    {
                        case System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear:
                            scrap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            goto Label_0090;

                        case System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic:
                            scrap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                            goto Label_0090;

                        case System.Drawing.Drawing2D.InterpolationMode.High:
                            scrap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                            goto Label_0090;
                    }
                    scrap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                }
            }
        Label_0090:
            scrap.Refresh();
        }

        public override string GetDescription() => 
            "用于缩小/扩大参考图。";

        public override string GetDisplayName() => 
            "缩放参考图";

        public override Bitmap GetIcon() => 
            Resources.Icon_Scale;

        public override string GetName() => 
            "Zoom";

        protected override ToolBoxForm GetToolBoxForm() => 
            new ScaleStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CScaleStyleItem item = (CScaleStyleItem) newOwn;
            this.Value = item.Value;
            this.SetType = item.SetType;
            this.InterpolationMode = item.InterpolationMode;
        }

        public System.Drawing.Drawing2D.InterpolationMode InterpolationMode
        {
            get{return  
                this._interpolationmode;}
            set
            {
                try
                {
                    this._interpolationmode = value;
                }
                catch
                {
                    this._interpolationmode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                }
            }
        }

        public ScaleSetType SetType
        {
            get{return  
                this._fixed;}
            set
            {
                this._fixed = value;
            }
        }

        public override string StateText
        {
            get
            {
                string str = "";
                if (this._fixed == ScaleSetType.Fixed)
                {
                    if (this._scalevalue == 100)
                    {
                        return "原始大小";
                    }
                    return (this._scalevalue.ToString() + "% 固定");
                }
                if (this._scalevalue > 0)
                {
                    str = this._scalevalue.ToString() + "% 扩大";
                }
                if (this._scalevalue < 0)
                {
                    str = Math.Abs(this._scalevalue).ToString() + "% 缩小";
                }
                return str;
            }
        }

        public int Value
        {
            get{return  
                this._scalevalue;}
            set
            {
                this._scalevalue = value;
            }
        }

        public enum ScaleSetType
        {
            Fixed,
            Increment
        }
    }
}

