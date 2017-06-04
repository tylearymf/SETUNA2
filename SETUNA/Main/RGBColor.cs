namespace SETUNA.Main
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RGBColor
    {
        private byte _red;
        private byte _green;
        private byte _blue;
        public RGBColor(byte red, byte green, byte blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        public RGBColor(Color color)
        {
            this._red = color.R;
            this._green = color.G;
            this._blue = color.B;
        }

        public byte R
        {
            get{return  
                this._red;}
            set
            {
                this._red = value;
            }
        }
        public byte G
        {
            get{return  
                this._green;}
            set
            {
                this._green = value;
            }
        }
        public byte B
        {
            get{return  
                this._green;}
            set
            {
                this._green = value;
            }
        }
        public Color GetColor() => 
            Color.FromArgb(this.R, this.G, this.B);
    }
}

