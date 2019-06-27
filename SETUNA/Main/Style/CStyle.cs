namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using SETUNA.Main.KeyItems;
    using SETUNA.Main.StyleItems;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class CStyle : IScrapStyle, ICloneable, IKeyItemListener, IStyleMenu
    {
        protected int _appliidx;
        protected List<Keys> _keys = new List<Keys>();
        protected ScrapBase _scrap;
        protected int _styleid;
        protected string _stylename;
        protected List<CStyleItem> _styles = new List<CStyleItem>();
        protected static int makestyleid;
        protected System.Windows.Forms.Timer timApply;

        public void AddKeyItem(Keys newKey)
        {
            this._keys.Add(newKey);
        }

        public void AddStyle(CStyleItem newCi)
        {
            this._styles.Add(newCi);
        }

        public virtual void Apply(ref ScrapBase scrap)
        {
            try
            {
                scrap.ApplyStyles(this, Point.Empty);
            }
            catch (Exception exception)
            {
                Console.WriteLine("CStyle Apply Exception:" + exception.Message);
            }
        }

        public virtual void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            try
            {
                scrap.ApplyStyles(this, clickpoint);
            }
            catch (Exception exception)
            {
                Console.WriteLine("CStyle Apply Exception:" + exception.Message);
            }
        }

        public void ClearKey()
        {
            this._keys.Clear();
        }

        public void ClearStyle()
        {
            this._styles.Clear();
        }

        public object Clone() => 
            base.MemberwiseClone();

        public CStyle DeepCopy()
        {
            CStyle style = (CStyle) base.MemberwiseClone();
            style._keys = new List<Keys>();
            style._styles = new List<CStyleItem>();
            for (int i = 0; i < this._keys.Count; i++)
            {
                style._keys.Add(this._keys[i]);
            }
            for (int j = 0; j < this._styles.Count; j++)
            {
                style._styles.Add((CStyleItem) this._styles[j].Clone());
            }
            return style;
        }

        public string GetDescription() => 
            "";

        public string GetDisplayName() => 
            this._stylename;

        public string GetName() => 
            this._stylename;

        public virtual ToolStripItem GetToolStrip() => 
            new ToolStripStyleButton(this);

        public virtual ToolStripItem GetToolStrip(ScrapBook scrapbook) => 
            this.GetToolStrip();

        public void MakeStyleID()
        {
            this._styleid = ++makestyleid;
        }

        public IEnumerable<CStyleItem> NextStyle()
        {
            foreach (object iteratorVariable0 in this._styles)
            {
                yield return (CStyleItem) iteratorVariable0;
            }
        }

        public void ParentMove(object sender, EventArgs e)
        {
            this._keys.Remove((Keys) sender);
        }

        public void RemoveKeyItem(Keys removeKey)
        {
            this._keys.Remove(removeKey);
        }

        public void RemoveStyle(CStyleItem removeCi)
        {
            this._styles.Remove(removeCi);
        }

        public void RemoveStyle(short i)
        {
            this._styles.RemoveAt(i);
        }

        public void ReplaceStyle(CStyleItem target, CStyleItem newitem)
        {
            int index = this._styles.IndexOf(target);
            if (index >= 0)
            {
                this._styles[index] = newitem;
            }
        }

        public override string ToString() => 
            this._stylename;

        public CStyleItem[] Items
        {
            get
            {
                CStyleItem[] itemArray = new CStyleItem[this._styles.Count];
                for (int i = 0; i < this._styles.Count; i++)
                {
                    itemArray[i] = this._styles[i];
                }
                return itemArray;
            }
            set
            {
                this._styles.Clear();
                for (int i = 0; i < value.Length; i++)
                {
                    this._styles.Add(value[i]);
                }
            }
        }

        public KeyItem[] KeyItems
        {
            get
            {
                KeyItem[] itemArray = new KeyItem[this._keys.Count];
                for (int i = 0; i < this._keys.Count; i++)
                {
                    itemArray[i] = new KeyItem(this._keys[i], this);
                }
                return itemArray;
            }
            set
            {
                this._keys.Clear();
                for (int i = 0; i < value.Length; i++)
                {
                    this._keys.Add((Keys) value[i]._key);
                }
            }
        }

        public virtual int StyleID
        {
            get{return  
                this._styleid;}
            set
            {
                this._styleid = value;
                if (makestyleid < value)
                {
                    makestyleid = value;
                }
            }
        }

        public string StyleName
        {
            get{return  
                this._stylename;}
            set
            {
                this._stylename = value;
            }
        }

    }
}

