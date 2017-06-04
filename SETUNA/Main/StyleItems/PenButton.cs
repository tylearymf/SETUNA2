namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class PenButton : RadioButton
    {
        private Color _penColor;
        private int _pensize;

        public PenButton()
        {
            this.ButtonColor = Color.Black;
            base.Appearance = Appearance.Button;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.FillEllipse(new SolidBrush(this._penColor), new Rectangle(((base.Width - this.PenSize) / 2) - 1, ((base.Height - this.PenSize) - 1) / 2, this.PenSize, this.PenSize + 1));
        }

        public Color ButtonColor
        {
            get{return  
                this._penColor;}
            set
            {
                this._penColor = value;
            }
        }

        public int PenSize
        {
            get{return  
                this._pensize;}
            set
            {
                this._pensize = value;
                this.Refresh();
            }
        }
    }
}

