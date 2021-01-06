using System;
using System.Windows.Forms;
using SETUNA.Main.Style;

namespace SETUNA.Main.KeyItems
{
    // Token: 0x02000055 RID: 85
    public class KeyItem
    {
        // Token: 0x14000017 RID: 23
        // (add) Token: 0x06000314 RID: 788 RVA: 0x000151E4 File Offset: 0x000133E4
        // (remove) Token: 0x06000315 RID: 789 RVA: 0x000151FD File Offset: 0x000133FD
        public event KeyItem.ParentMoveHandler ParentMoveEvent;

        // Token: 0x06000316 RID: 790 RVA: 0x00015216 File Offset: 0x00013416
        public KeyItem()
        {
            _keycode = Keys.None;
        }

        // Token: 0x06000317 RID: 791 RVA: 0x00015225 File Offset: 0x00013425
        public KeyItem(Keys key)
        {
            _keycode = key;
        }

        // Token: 0x17000076 RID: 118
        // (get) Token: 0x06000319 RID: 793 RVA: 0x0001523D File Offset: 0x0001343D
        // (set) Token: 0x06000318 RID: 792 RVA: 0x00015234 File Offset: 0x00013434
        public int _key
        {
            get => (int)_keycode;
            set => _keycode = (Keys)value;
        }

        // Token: 0x0600031A RID: 794 RVA: 0x00015245 File Offset: 0x00013445
        public KeyItem(Keys key, CStyle parentStyle)
        {
            _keycode = key;
            _parent = parentStyle;
            addKeyItemListener(parentStyle);
        }

        // Token: 0x17000077 RID: 119
        // (get) Token: 0x0600031B RID: 795 RVA: 0x00015262 File Offset: 0x00013462
        public CStyle ParentStyle => _parent;

        // Token: 0x0600031C RID: 796 RVA: 0x0001526C File Offset: 0x0001346C
        public override string ToString()
        {
            var str = "";
            if ((_keycode & Keys.Control) == Keys.Control)
            {
                str += "Ctrl+";
            }
            if ((_keycode & Keys.Shift) == Keys.Shift)
            {
                str += "Shift+";
            }
            if ((_keycode & Keys.Alt) == Keys.Alt)
            {
                str += "Alt+";
            }
            return str + (_keycode & Keys.KeyCode).ToString();
        }

        // Token: 0x0600031D RID: 797 RVA: 0x000152FA File Offset: 0x000134FA
        public void addKeyItemListener(IKeyItemListener listener)
        {
            ParentMoveEvent = (KeyItem.ParentMoveHandler)Delegate.Combine(ParentMoveEvent, new KeyItem.ParentMoveHandler(listener.ParentMove));
        }

        // Token: 0x0600031E RID: 798 RVA: 0x0001531F File Offset: 0x0001351F
        protected void OnParentMove()
        {
            if (ParentMoveEvent != null)
            {
                ParentMoveEvent(_keycode, new EventArgs());
            }
        }

        // Token: 0x0600031F RID: 799 RVA: 0x00015344 File Offset: 0x00013544
        public void Deparent()
        {
            OnParentMove();
        }

        // Token: 0x040001C7 RID: 455
        protected Keys _keycode;

        // Token: 0x040001C8 RID: 456
        protected CStyle _parent;

        // Token: 0x02000084 RID: 132
        // (Invoke) Token: 0x06000466 RID: 1126
        public delegate void ParentMoveHandler(object sender, EventArgs e);
    }
}
