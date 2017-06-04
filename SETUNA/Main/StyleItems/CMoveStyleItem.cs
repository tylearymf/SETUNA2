namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using SETUNA.Properties;
    using System;
    using System.Drawing;

    public class CMoveStyleItem : CStyleItem
    {
        protected int _left;
        protected int _top;
        public static int MAX_MOVE = 0x3e8;

        public CMoveStyleItem()
        {
            this.Top = 0;
            this.Left = 0;
        }

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            Point point = new Point(scrap.TargetLocation.X, scrap.TargetLocation.Y);
            point.X += this.Left;
            point.Y += this.Top;
            scrap.TargetLocation = point;
        }

        public override string GetDescription() => 
            "上下左右移动参考图。";

        public override string GetDisplayName() => 
            "参考图的移动";

        public override Bitmap GetIcon() => 
            Resources.Icon_Move;

        public override string GetName() => 
            "Move";

        protected override ToolBoxForm GetToolBoxForm() => 
            new MoveStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CMoveStyleItem item = (CMoveStyleItem) newOwn;
            this.Top = item.Top;
            this.Left = item.Left;
        }

        public int Left
        {
            get{return  
                this._left;}
            set
            {
                if (value > MAX_MOVE)
                {
                    this._left = MAX_MOVE;
                }
                else if (value < -MAX_MOVE)
                {
                    this._left = -MAX_MOVE;
                }
                else
                {
                    this._left = value;
                }
            }
        }

        public override string StateText
        {
            get
            {
                string str = "";
                if (this._top < 0)
                {
                    object obj2 = str;
                    str = string.Concat(new object[] { obj2, "上：", Math.Abs(this._top), "px " });
                }
                if (this._top > 0)
                {
                    object obj3 = str;
                    str = string.Concat(new object[] { obj3, "下：", Math.Abs(this._top), "px " });
                }
                if (this._left < 0)
                {
                    object obj4 = str;
                    str = string.Concat(new object[] { obj4, "左：", Math.Abs(this._left), "px " });
                }
                if (this._left > 0)
                {
                    object obj5 = str;
                    str = string.Concat(new object[] { obj5, "右：", Math.Abs(this._left), "px " });
                }
                return str;
            }
        }

        public int Top
        {
            get{return  
                this._top;}
            set
            {
                if (value > MAX_MOVE)
                {
                    this._top = MAX_MOVE;
                }
                else if (value < -MAX_MOVE)
                {
                    this._top = -MAX_MOVE;
                }
                else
                {
                    this._top = value;
                }
            }
        }
    }
}

