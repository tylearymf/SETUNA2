namespace SETUNA.Main
{
    using SETUNA;
    using SETUNA.Main.Style;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ScrapBook
    {
        protected Queue<ScrapBase> _dustbox = null;
        protected short _dustcap = 0;
        private Mainform _mainform;
        protected ArrayList _scraps = new ArrayList();

        public event KeyPressHandler KeyPress;

        public event ScrapAddedHandler ScrapAdded;

        public event ScrapRemovedHandler ScrapRemoved;

        public ScrapBook(Mainform mainform)
        {
            this._mainform = mainform;
        }

        public void AddDragImageFileName(string path)
        {
            this._mainform.AddImageList(new ScrapSourcePath(path));
        }

        public void addKeyPressListener(IScrapKeyPressEventListener listener)
        {
            this.KeyPress = (KeyPressHandler)Delegate.Combine(this.KeyPress, new KeyPressHandler(listener.ScrapKeyPress));
        }

        public void AddScrap(ScrapBase newScrap)
        {
            newScrap.Manager = this;
            this._scraps.Add(newScrap);
            newScrap.OnScrapCreated();
            if (this.ScrapAdded != null)
            {
                this.ScrapAdded(this, new ScrapEventArgs(newScrap));
            }
        }

        public void AddScrap(Image img, int x, int y, int width, int height, string pGuid = null)
        {
            this.AddScrap(img, x, y, width, height, "", pGuid);
        }

        public void AddScrap(Image img, int x, int y, int width, int height, string scrapname, string pGuid = null)
        {
            ScrapBase newScrap = new ScrapBase();
            newScrap.addScrapStyleEvent(this._mainform);
            newScrap.addScrapMenuEvent(this._mainform);
            if (scrapname != "")
            {
                newScrap.Name = scrapname;
            }
            newScrap.Image = img;
            newScrap.SaveImg(img, pGuid);
            newScrap.SetBounds(x, y, img.Width, img.Height, BoundsSpecified.All);
            newScrap.Refresh();
            newScrap.Show();
            this.AddScrap(newScrap);
        }

        public void addScrapAddedListener(IScrapAddedListener listener)
        {
            this.ScrapAdded = (ScrapAddedHandler)Delegate.Combine(this.ScrapAdded, new ScrapAddedHandler(listener.ScrapAdded));
        }

        public void addScrapRemovedListener(IScrapRemovedListener listener)
        {
            this.ScrapRemoved = (ScrapRemovedHandler)Delegate.Combine(this.ScrapRemoved, new ScrapRemovedHandler(listener.ScrapRemoved));
        }

        public void CloseAllScrap()
        {
            foreach (ScrapBase base2 in this._scraps)
            {
                base2.Close();
            }
        }

        public void EraseDustBox()
        {
            if (this._dustbox != null)
            {
                foreach (ScrapBase base2 in this._dustbox)
                {
                    base2.ScrapClose();
                }
                this._dustbox.Clear();
            }
            GC.Collect();
        }

        ~ScrapBook()
        {
            foreach (ScrapBase base2 in this._scraps)
            {
                base2.ScrapClose();
            }
            this._scraps.Clear();
            this.EraseDustBox();
        }

        public ScrapBase GetDummyScrap() =>
            new ScrapBase { Manager = this };

        public IEnumerator<ScrapBase> GetEnumerator()
        {
            IEnumerator enumerator = this._scraps.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ScrapBase current = (ScrapBase)enumerator.Current;
                yield return current;
            }
        }

        public void HideAllScrap()
        {
            foreach (ScrapBase base2 in this._scraps)
            {
                base2.Hide();
            }
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (this.KeyPress != null)
            {
                ScrapKeyPressEventArgs args = new ScrapKeyPressEventArgs
                {
                    key = e.KeyCode | e.Modifiers
                };
                Console.WriteLine(args.key.ToString());
                this.KeyPress(sender, args);
            }
        }

        public void ScrapClose(object sender, ScrapEventArgs e)
        {
            ScrapBase base2 = (ScrapBase)sender;
            this._scraps.Remove(base2);
            if ((this._dustbox != null) && (this._dustcap > 0))
            {
                if (this._dustbox.Count == this._dustcap)
                {
                    this._dustbox.Dequeue().ScrapClose();
                }
                this._dustbox.Enqueue(base2);
                base2.Hide();
                Cache.DestroyImage(base2.instanceId);
            }
            else
            {
                base2.ScrapClose();
            }
            if (this.ScrapRemoved != null)
            {
                this.ScrapRemoved(this, new ScrapEventArgs());
            }
        }

        public void ShowAllScrap()
        {
            foreach (ScrapBase base2 in this._scraps)
            {
                base2.Show();
            }
        }

        public void WClickStyle(ScrapBase scrap, Point clickpoint)
        {
            int wClickStyleID = this._mainform.optSetuna.Scrap.WClickStyleID;
            if (wClickStyleID != 0)
            {
                CStyle style = this._mainform.optSetuna.FindStyle(wClickStyleID);
                if (style != null)
                {
                    style.Apply(ref scrap, clickpoint);
                }
            }
        }

        public Mainform BindForm =>
            this._mainform;

        public Queue<ScrapBase> DustBox
        {
            get
            {
                return
                this._dustbox;
            }
            set
            {
                this._dustbox = value;
            }
        }

        public ArrayList DustBoxArray =>
            new ArrayList(this._dustbox.ToArray());

        public short DustBoxCapacity
        {
            get
            {
                return
                this._dustcap;
            }
            set
            {
                this._dustcap = value;
                while (this._dustcap < this._dustbox.Count)
                {
                    this._dustbox.Dequeue().ScrapClose();
                }
            }
        }

        public int DustCount =>
            (int)this._dustbox?.Count;

        public bool IsImageDrag =>
            this._mainform.optSetuna.Scrap.ImageDrag;

        public int ScrapCount =>
            (int)this._scraps?.Count;


        public delegate void KeyPressHandler(object sender, ScrapKeyPressEventArgs e);

        public delegate void ScrapAddedHandler(object sender, ScrapEventArgs e);

        public delegate void ScrapRemovedHandler(object sender, ScrapEventArgs e);
    }
}

