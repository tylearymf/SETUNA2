namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Drawing;

    public class TextToolCommand : ToolCommand
    {
        private System.Drawing.Font _font;
        private Point _location;
        private string _text;

        public TextToolCommand(string text, System.Drawing.Font font, Point location) : this(text, font, location.X, location.Y)
        {
        }

        public TextToolCommand(string text, System.Drawing.Font font, int x, int y)
        {
            this._text = text;
            this._font = font;
            this._location = new Point(x, y);
        }

        public override void Draw(Graphics g)
        {
            g.DrawString(this._text, this._font, Brushes.SkyBlue, (PointF) this._location);
        }

        public System.Drawing.Font Font
        {
            get{return  
                this._font;}
            set
            {
                this._font = value;
            }
        }

        public string Text
        {
            get{return  
                this._text;}
            set
            {
                this._text = value;
            }
        }
    }
}

