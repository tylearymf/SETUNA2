namespace SETUNA.Main.KeyItems
{
    using SETUNA.Main.Style;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class KeyItem
    {
        protected Keys _keycode;
        protected CStyle _parent;

        public event ParentMoveHandler ParentMoveEvent;

        public KeyItem()
        {
            this._keycode = Keys.None;
        }

        public KeyItem(Keys key)
        {
            this._keycode = key;
        }

        public KeyItem(Keys key, CStyle parentStyle)
        {
            this._keycode = key;
            this._parent = parentStyle;
            this.addKeyItemListener(parentStyle);
        }

        public void addKeyItemListener(IKeyItemListener listener)
        {
            this.ParentMoveEvent = (ParentMoveHandler) Delegate.Combine(this.ParentMoveEvent, new ParentMoveHandler(listener.ParentMove));
        }

        public void Deparent()
        {
            this.OnParentMove();
        }

        protected void OnParentMove()
        {
            if (this.ParentMoveEvent != null)
            {
                this.ParentMoveEvent(this._keycode, new EventArgs());
            }
        }

        public override string ToString()
        {
            string str = "";
            if ((this._keycode & Keys.Control) == Keys.Control)
            {
                str = str + "Ctrl+";
            }
            if ((this._keycode & Keys.Shift) == Keys.Shift)
            {
                str = str + "Shift+";
            }
            if ((this._keycode & Keys.Alt) == Keys.Alt)
            {
                str = str + "Alt+";
            }
            return (str + ((this._keycode & Keys.KeyCode)).ToString());
        }

        public int _key
        {
            get{return  
                ((int) this._keycode);}
            set
            {
                this._keycode = (Keys) value;
            }
        }

        public CStyle ParentStyle =>
            this._parent;

        public delegate void ParentMoveHandler(object sender, EventArgs e);
    }
}

