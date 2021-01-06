using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SETUNA.Main.KeyItems;
using SETUNA.Main.StyleItems;

namespace SETUNA.Main.Style
{
    // Token: 0x0200003B RID: 59
    public class CStyle : IScrapStyle, ICloneable, IKeyItemListener, IStyleMenu
    {
        // Token: 0x17000058 RID: 88
        // (get) Token: 0x06000223 RID: 547 RVA: 0x0000B8C8 File Offset: 0x00009AC8
        // (set) Token: 0x06000222 RID: 546 RVA: 0x0000B894 File Offset: 0x00009A94
        public CStyleItem[] Items
        {
            get
            {
                var array = new CStyleItem[_styles.Count];
                for (var i = 0; i < _styles.Count; i++)
                {
                    array[i] = _styles[i];
                }
                return array;
            }
            set
            {
                _styles.Clear();
                for (var i = 0; i < value.Length; i++)
                {
                    _styles.Add(value[i]);
                }
            }
        }

        // Token: 0x17000059 RID: 89
        // (get) Token: 0x06000225 RID: 549 RVA: 0x0000B948 File Offset: 0x00009B48
        // (set) Token: 0x06000224 RID: 548 RVA: 0x0000B90C File Offset: 0x00009B0C
        public KeyItem[] KeyItems
        {
            get
            {
                var array = new KeyItem[_keys.Count];
                for (var i = 0; i < _keys.Count; i++)
                {
                    array[i] = new KeyItem(_keys[i], this);
                }
                return array;
            }
            set
            {
                _keys.Clear();
                for (var i = 0; i < value.Length; i++)
                {
                    _keys.Add((Keys)value[i]._key);
                }
            }
        }

        // Token: 0x1700005A RID: 90
        // (get) Token: 0x06000227 RID: 551 RVA: 0x0000B99B File Offset: 0x00009B9B
        // (set) Token: 0x06000226 RID: 550 RVA: 0x0000B992 File Offset: 0x00009B92
        public string StyleName
        {
            get => _stylename;
            set => _stylename = value;
        }

        // Token: 0x1700005B RID: 91
        // (get) Token: 0x06000229 RID: 553 RVA: 0x0000B9BA File Offset: 0x00009BBA
        // (set) Token: 0x06000228 RID: 552 RVA: 0x0000B9A3 File Offset: 0x00009BA3
        public virtual int StyleID
        {
            get => _styleid;
            set
            {
                _styleid = value;
                if (CStyle.makestyleid < value)
                {
                    CStyle.makestyleid = value;
                }
            }
        }

        // Token: 0x0600022A RID: 554 RVA: 0x0000B9C2 File Offset: 0x00009BC2
        public CStyle()
        {
            _styles = new List<CStyleItem>();
            _keys = new List<Keys>();
        }

        // Token: 0x0600022B RID: 555 RVA: 0x0000B9E0 File Offset: 0x00009BE0
        public virtual void Apply(ref ScrapBase scrap)
        {
            try
            {
                scrap.ApplyStyles(StyleID, Items, Point.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CStyle Apply Exception:" + ex.Message);
            }
        }

        // Token: 0x0600022C RID: 556 RVA: 0x0000BA2C File Offset: 0x00009C2C
        public virtual void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            try
            {
                scrap.ApplyStyles(StyleID, Items, clickpoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CStyle Apply Exception:" + ex.Message);
            }
        }

        // Token: 0x0600022D RID: 557 RVA: 0x0000BA74 File Offset: 0x00009C74
        public string GetName()
        {
            return _stylename;
        }

        // Token: 0x0600022E RID: 558 RVA: 0x0000BA7C File Offset: 0x00009C7C
        public string GetDisplayName()
        {
            return _stylename;
        }

        // Token: 0x0600022F RID: 559 RVA: 0x0000BA84 File Offset: 0x00009C84
        public string GetDescription()
        {
            return "";
        }

        // Token: 0x06000230 RID: 560 RVA: 0x0000BA8B File Offset: 0x00009C8B
        public object Clone()
        {
            return base.MemberwiseClone();
        }

        // Token: 0x06000231 RID: 561 RVA: 0x0000BA93 File Offset: 0x00009C93
        public override string ToString()
        {
            return _stylename;
        }

        // Token: 0x06000232 RID: 562 RVA: 0x0000BA9C File Offset: 0x00009C9C
        public CStyle DeepCopy()
        {
            var cstyle = (CStyle)base.MemberwiseClone();
            cstyle._keys = new List<Keys>();
            cstyle._styles = new List<CStyleItem>();
            for (var i = 0; i < _keys.Count; i++)
            {
                cstyle._keys.Add(_keys[i]);
            }
            for (var j = 0; j < _styles.Count; j++)
            {
                cstyle._styles.Add((CStyleItem)_styles[j].Clone());
            }
            return cstyle;
        }

        // Token: 0x06000233 RID: 563 RVA: 0x0000BB30 File Offset: 0x00009D30
        public void MakeStyleID()
        {
            _styleid = ++CStyle.makestyleid;
        }

        // Token: 0x06000234 RID: 564 RVA: 0x0000BB45 File Offset: 0x00009D45
        public void AddStyle(CStyleItem newCi)
        {
            _styles.Add(newCi);
        }

        // Token: 0x06000235 RID: 565 RVA: 0x0000BB54 File Offset: 0x00009D54
        public IEnumerable<CStyleItem> NextStyle()
        {
            foreach (object ci in _styles)
            {
                yield return (CStyleItem)ci;
            }
            yield break;
        }

        // Token: 0x06000236 RID: 566 RVA: 0x0000BB71 File Offset: 0x00009D71
        public void ClearStyle()
        {
            _styles.Clear();
        }

        // Token: 0x06000237 RID: 567 RVA: 0x0000BB7E File Offset: 0x00009D7E
        public void RemoveStyle(short i)
        {
            _styles.RemoveAt(i);
        }

        // Token: 0x06000238 RID: 568 RVA: 0x0000BB8C File Offset: 0x00009D8C
        public void RemoveStyle(CStyleItem removeCi)
        {
            _styles.Remove(removeCi);
        }

        // Token: 0x06000239 RID: 569 RVA: 0x0000BB9C File Offset: 0x00009D9C
        public void ReplaceStyle(CStyleItem target, CStyleItem newitem)
        {
            var num = _styles.IndexOf(target);
            if (num >= 0)
            {
                _styles[num] = newitem;
            }
        }

        // Token: 0x0600023A RID: 570 RVA: 0x0000BBC7 File Offset: 0x00009DC7
        public void AddKeyItem(Keys newKey)
        {
            _keys.Add(newKey);
        }

        // Token: 0x0600023B RID: 571 RVA: 0x0000BBD5 File Offset: 0x00009DD5
        public void RemoveKeyItem(Keys removeKey)
        {
            _keys.Remove(removeKey);
        }

        // Token: 0x0600023C RID: 572 RVA: 0x0000BBE4 File Offset: 0x00009DE4
        public void ClearKey()
        {
            _keys.Clear();
        }

        // Token: 0x0600023D RID: 573 RVA: 0x0000BBF1 File Offset: 0x00009DF1
        public void ParentMove(object sender, EventArgs e)
        {
            _keys.Remove((Keys)sender);
        }

        // Token: 0x0600023E RID: 574 RVA: 0x0000BC05 File Offset: 0x00009E05
        public virtual ToolStripItem GetToolStrip()
        {
            return new ToolStripStyleButton(this);
        }

        // Token: 0x0600023F RID: 575 RVA: 0x0000BC0D File Offset: 0x00009E0D
        public virtual ToolStripItem GetToolStrip(ScrapBook scrapbook)
        {
            return GetToolStrip();
        }

        // Token: 0x040000EC RID: 236
        protected List<CStyleItem> _styles;

        // Token: 0x040000ED RID: 237
        protected List<Keys> _keys;

        // Token: 0x040000EE RID: 238
        protected string _stylename;

        // Token: 0x040000EF RID: 239
        protected int _styleid;

        // Token: 0x040000F0 RID: 240
        protected static int makestyleid;

        // Token: 0x040000F1 RID: 241
        protected Timer timApply;

        // Token: 0x040000F2 RID: 242
        protected int _appliidx;

        // Token: 0x040000F3 RID: 243
        protected ScrapBase _scrap;
    }
}
