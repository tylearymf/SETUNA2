using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x02000060 RID: 96
    public class CScaleStyleItem : CStyleItem
    {
        // Token: 0x06000359 RID: 857 RVA: 0x00015A3B File Offset: 0x00013C3B
        public CScaleStyleItem()
        {
            Value = 100;
        }

        // Token: 0x17000080 RID: 128
        // (get) Token: 0x0600035B RID: 859 RVA: 0x00015A54 File Offset: 0x00013C54
        // (set) Token: 0x0600035A RID: 858 RVA: 0x00015A4B File Offset: 0x00013C4B
        public int Value
        {
            get => _scalevalue;
            set => _scalevalue = value;
        }

        // Token: 0x17000081 RID: 129
        // (get) Token: 0x0600035D RID: 861 RVA: 0x00015A65 File Offset: 0x00013C65
        // (set) Token: 0x0600035C RID: 860 RVA: 0x00015A5C File Offset: 0x00013C5C
        public CScaleStyleItem.ScaleSetType SetType
        {
            get => _fixed;
            set => _fixed = value;
        }

        // Token: 0x17000082 RID: 130
        // (get) Token: 0x0600035F RID: 863 RVA: 0x00015AA0 File Offset: 0x00013CA0
        // (set) Token: 0x0600035E RID: 862 RVA: 0x00015A70 File Offset: 0x00013C70
        public InterpolationMode InterpolationMode
        {
            get => _interpolationmode;
            set
            {
                try
                {
                    _interpolationmode = value;
                }
                catch
                {
                    _interpolationmode = InterpolationMode.HighQualityBicubic;
                }
            }
        }

        // Token: 0x06000360 RID: 864 RVA: 0x00015AA8 File Offset: 0x00013CA8
        public override string GetName()
        {
            return "Zoom";
        }

        // Token: 0x06000361 RID: 865 RVA: 0x00015AAF File Offset: 0x00013CAF
        public override string GetDisplayName()
        {
            return "缩放参考图";
        }

        // Token: 0x06000362 RID: 866 RVA: 0x00015AB6 File Offset: 0x00013CB6
        public override string GetDescription()
        {
            return "用于缩小/扩大参考图。";
        }

        // Token: 0x06000363 RID: 867 RVA: 0x00015AC0 File Offset: 0x00013CC0
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            if (_fixed == CScaleStyleItem.ScaleSetType.Fixed)
            {
                scrap.Scale = _scalevalue;
            }
            else
            {
                scrap.Scale += _scalevalue;
            }
            if (_interpolationmode != InterpolationMode.Invalid)
            {
                if (_interpolationmode != InterpolationMode.Low)
                {
                    scrap.InterpolationMode = _interpolationmode;
                }
                else
                {
                    var interpolationMode = scrap.InterpolationMode;
                    if (interpolationMode != InterpolationMode.High)
                    {
                        switch (interpolationMode)
                        {
                            case InterpolationMode.HighQualityBilinear:
                                scrap.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                break;
                            case InterpolationMode.HighQualityBicubic:
                                scrap.InterpolationMode = InterpolationMode.NearestNeighbor;
                                break;
                            default:
                                scrap.InterpolationMode = InterpolationMode.High;
                                break;
                        }
                    }
                    else
                    {
                        scrap.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    }
                }
            }
            scrap.Refresh();
        }

        // Token: 0x06000364 RID: 868 RVA: 0x00015B64 File Offset: 0x00013D64
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new ScaleStyleItemPanel(this);
        }

        // Token: 0x06000365 RID: 869 RVA: 0x00015B6C File Offset: 0x00013D6C
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var cscaleStyleItem = (CScaleStyleItem)newOwn;
            Value = cscaleStyleItem.Value;
            SetType = cscaleStyleItem.SetType;
            InterpolationMode = cscaleStyleItem.InterpolationMode;
        }

        // Token: 0x17000083 RID: 131
        // (get) Token: 0x06000366 RID: 870 RVA: 0x00015BA4 File Offset: 0x00013DA4
        public override string StateText
        {
            get
            {
                var result = "";
                if (_fixed == CScaleStyleItem.ScaleSetType.Fixed)
                {
                    if (_scalevalue == 100)
                    {
                        result = "原始大小";
                    }
                    else
                    {
                        result = _scalevalue.ToString() + "% 固定";
                    }
                }
                else
                {
                    if (_scalevalue > 0)
                    {
                        result = _scalevalue.ToString() + "% 扩大";
                    }
                    if (_scalevalue < 0)
                    {
                        result = Math.Abs(_scalevalue).ToString() + "% 缩小";
                    }
                }
                return result;
            }
        }

        // Token: 0x06000367 RID: 871 RVA: 0x00015C30 File Offset: 0x00013E30
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Scale;
        }

        // Token: 0x040001DE RID: 478
        public const int FixedScaleMin = 10;

        // Token: 0x040001DF RID: 479
        public const int FixedScaleMax = 200;

        // Token: 0x040001E0 RID: 480
        public const int FixedScaleDefault = 100;

        // Token: 0x040001E1 RID: 481
        public const int RelativeScaleMin = -190;

        // Token: 0x040001E2 RID: 482
        public const int RelativeScaleMax = 190;

        // Token: 0x040001E3 RID: 483
        public const int RelativeScaleDefault = 0;

        // Token: 0x040001E4 RID: 484
        public const InterpolationMode DefaultInterpolation = InterpolationMode.HighQualityBicubic;

        // Token: 0x040001E5 RID: 485
        protected int _scalevalue;

        // Token: 0x040001E6 RID: 486
        protected CScaleStyleItem.ScaleSetType _fixed;

        // Token: 0x040001E7 RID: 487
        protected InterpolationMode _interpolationmode;

        // Token: 0x02000066 RID: 102
        public enum ScaleSetType
        {
            // Token: 0x040001F9 RID: 505
            Fixed,
            // Token: 0x040001FA RID: 506
            Increment
        }
    }
}
