using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main
{
    // Token: 0x0200002F RID: 47
    public class ScrapBook
    {
        // Token: 0x1700004C RID: 76
        // (get) Token: 0x060001B2 RID: 434 RVA: 0x00009A1A File Offset: 0x00007C1A
        // (set) Token: 0x060001B1 RID: 433 RVA: 0x00009A11 File Offset: 0x00007C11
        public Queue<ScrapBase> DustBox
        {
            get => _dustbox;
            set => _dustbox = value;
        }

        // Token: 0x1700004D RID: 77
        // (get) Token: 0x060001B3 RID: 435 RVA: 0x00009A22 File Offset: 0x00007C22
        public ArrayList DustBoxArray => new ArrayList(_dustbox.ToArray());

        // Token: 0x1700004E RID: 78
        // (get) Token: 0x060001B5 RID: 437 RVA: 0x00009A6F File Offset: 0x00007C6F
        // (set) Token: 0x060001B4 RID: 436 RVA: 0x00009A34 File Offset: 0x00007C34
        public short DustBoxCapacity
        {
            get => _dustcap;
            set
            {
                _dustcap = value;
                while (_dustcap < _dustbox.Count)
                {
                    var scrapBase = _dustbox.Dequeue();
                    scrapBase.ScrapClose();
                }
            }
        }

        // Token: 0x1700004F RID: 79
        // (get) Token: 0x060001B6 RID: 438 RVA: 0x00009A77 File Offset: 0x00007C77
        public Mainform BindForm => _mainform;

        // Token: 0x14000013 RID: 19
        // (add) Token: 0x060001B7 RID: 439 RVA: 0x00009A7F File Offset: 0x00007C7F
        // (remove) Token: 0x060001B8 RID: 440 RVA: 0x00009A98 File Offset: 0x00007C98
        public event ScrapBook.KeyPressHandler KeyPress;

        // Token: 0x14000014 RID: 20
        // (add) Token: 0x060001B9 RID: 441 RVA: 0x00009AB1 File Offset: 0x00007CB1
        // (remove) Token: 0x060001BA RID: 442 RVA: 0x00009ACA File Offset: 0x00007CCA
        public event ScrapBook.ScrapAddedHandler ScrapAdded;

        // Token: 0x14000015 RID: 21
        // (add) Token: 0x060001BB RID: 443 RVA: 0x00009AE3 File Offset: 0x00007CE3
        // (remove) Token: 0x060001BC RID: 444 RVA: 0x00009AFC File Offset: 0x00007CFC
        public event ScrapBook.ScrapRemovedHandler ScrapRemoved;

        // Token: 0x060001BD RID: 445 RVA: 0x00009B15 File Offset: 0x00007D15
        public ScrapBook(Mainform mainform)
        {
            _scraps = new ArrayList();
            _dustbox = null;
            _dustcap = 0;
            _mainform = mainform;
        }

        // Token: 0x060001BE RID: 446 RVA: 0x00009B40 File Offset: 0x00007D40
        ~ScrapBook()
        {
            try
            {
                foreach (var obj in _scraps)
                {
                    var scrapBase = (ScrapBase)obj;
                    scrapBase.ScrapClose();
                }
                _scraps.Clear();
                EraseDustBox();
            }
            finally
            {

            }
        }

        // Token: 0x060001BF RID: 447 RVA: 0x00009BC0 File Offset: 0x00007DC0
        public void EraseDustBox()
        {
            if (_dustbox != null)
            {
                foreach (var scrapBase in _dustbox)
                {
                    scrapBase.ScrapClose();
                }
                _dustbox.Clear();
            }
            GC.Collect();
        }

        // Token: 0x060001C0 RID: 448 RVA: 0x00009C2C File Offset: 0x00007E2C
        public IEnumerator<ScrapBase> GetEnumerator()
        {
            foreach (var obj in _scraps)
            {
                var scrap = (ScrapBase)obj;
                yield return scrap;
            }
            yield break;
        }

        // Token: 0x060001C1 RID: 449 RVA: 0x00009C48 File Offset: 0x00007E48
        public void AddScrap(Image img, int x, int y, int width, int height)
        {
            AddScrap(img, x, y, width, height, "");
        }

        // Token: 0x060001C2 RID: 450 RVA: 0x00009C5C File Offset: 0x00007E5C
        public void AddScrap(Image img, int x, int y, int width, int height, string scrapname)
        {
            var scrapBase = new ScrapBase();
            if (scrapname != "")
            {
                scrapBase.Name = scrapname;
            }
            scrapBase.Image = img;
            scrapBase.SetBounds(x, y, img.Width, img.Height, BoundsSpecified.All);

            AddScrapThenShow(scrapBase);
        }

        public void AddScrapFromCache(Cache.CacheItem cacheItem, Action initFinished = null)
        {
            var image = cacheItem.ReadImage();
            var pos = cacheItem.Position;
            var style = cacheItem.Style;

            var scrapBase = new ScrapBase
            {
                DateTime = cacheItem.CreateTime,
                Name = cacheItem.CreateTime.ToCustomString(),
                Image = image
            };
            scrapBase.SetBounds(pos.X, pos.Y, image.Width, image.Height, BoundsSpecified.All);

            var cstyle = _mainform.optSetuna.FindStyle(style.ID);
            if (cstyle != null)
            {
                scrapBase.ApplyStylesFromCache(cstyle, style.ClickPoint, initFinished);
            }

            // 设置所有参数再设置缓存对象
            scrapBase.CacheItem = cacheItem;

            AddScrapThenShow(scrapBase);

            if (cstyle == null)
            {
                initFinished?.Invoke();
            }
        }

        // Token: 0x060001C3 RID: 451 RVA: 0x00009CCD File Offset: 0x00007ECD
        public void AddScrapThenShow(ScrapBase newScrap)
        {
            newScrap.addScrapStyleEvent(_mainform);
            newScrap.addScrapMenuEvent(_mainform);

            newScrap.addScrapLocationChangedEvent(Cache.CacheManager.Instance);
            newScrap.addScrapImageChangedEvent(Cache.CacheManager.Instance);
            newScrap.addScrapStyleAppliedEvent(Cache.CacheManager.Instance);
            newScrap.addScrapStyleRemovedEvent(Cache.CacheManager.Instance);

            newScrap.Manager = this;
            _scraps.Add(newScrap);
            newScrap.OnScrapCreated();
            if (ScrapAdded != null)
            {
                ScrapAdded(this, new ScrapEventArgs(newScrap));
            }

            newScrap.Refresh();
            newScrap.Show();
        }

        // Token: 0x060001C4 RID: 452 RVA: 0x00009D04 File Offset: 0x00007F04
        public ScrapBase GetDummyScrap()
        {
            return new ScrapBase
            {
                Manager = this
            };
        }

        // Token: 0x060001C5 RID: 453 RVA: 0x00009D20 File Offset: 0x00007F20
        public void ScrapClose(object sender, ScrapEventArgs e)
        {
            var scrapBase = e.scrap;
            _scraps.Remove(scrapBase);
            if (_dustbox != null && _dustcap > 0)
            {
                if (_dustbox.Count == _dustcap)
                {
                    var scrapBase2 = _dustbox.Dequeue();
                    scrapBase2.ScrapClose();
                }
                _dustbox.Enqueue(scrapBase);
                scrapBase.Hide();
            }
            else
            {
                scrapBase.ScrapClose();
            }
            if (ScrapRemoved != null)
            {
                ScrapRemoved(this, e);
            }
        }

        // Token: 0x060001C6 RID: 454 RVA: 0x00009DAC File Offset: 0x00007FAC
        public void ShowAllScrap()
        {
            foreach (var obj in _scraps)
            {
                var scrapBase = (ScrapBase)obj;
                scrapBase.Show();
            }
        }

        // Token: 0x060001C7 RID: 455 RVA: 0x00009E04 File Offset: 0x00008004
        public void HideAllScrap()
        {
            foreach (var obj in _scraps)
            {
                var scrapBase = (ScrapBase)obj;
                scrapBase.Hide();
            }
        }

        // Token: 0x060001C8 RID: 456 RVA: 0x00009E5C File Offset: 0x0000805C
        public void CloseAllScrap()
        {
            var list = _scraps.ToArray();
            foreach (var obj in list)
            {
                var scrapBase = (ScrapBase)obj;
                scrapBase.Close();
            }
        }

        // Token: 0x17000050 RID: 80
        // (get) Token: 0x060001C9 RID: 457 RVA: 0x00009EB4 File Offset: 0x000080B4
        public int ScrapCount
        {
            get
            {
                if (_scraps == null)
                {
                    return 0;
                }
                return _scraps.Count;
            }
        }

        // Token: 0x17000051 RID: 81
        // (get) Token: 0x060001CA RID: 458 RVA: 0x00009ECB File Offset: 0x000080CB
        public int DustCount
        {
            get
            {
                if (_dustbox == null)
                {
                    return 0;
                }
                return _dustbox.Count;
            }
        }

        // Token: 0x060001CB RID: 459 RVA: 0x00009EE4 File Offset: 0x000080E4
        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (KeyPress != null)
            {
                var scrapKeyPressEventArgs = new ScrapKeyPressEventArgs
                {
                    key = (e.KeyCode | e.Modifiers)
                };
                Console.WriteLine(scrapKeyPressEventArgs.key.ToString());
                KeyPress(sender, scrapKeyPressEventArgs);
            }
        }

        // Token: 0x060001CC RID: 460 RVA: 0x00009F34 File Offset: 0x00008134
        public void addKeyPressListener(IScrapKeyPressEventListener listener)
        {
            KeyPress = (ScrapBook.KeyPressHandler)Delegate.Combine(KeyPress, new ScrapBook.KeyPressHandler(listener.ScrapKeyPress));
        }

        // Token: 0x060001CD RID: 461 RVA: 0x00009F59 File Offset: 0x00008159
        public void addScrapAddedListener(IScrapAddedListener listener)
        {
            ScrapAdded = (ScrapBook.ScrapAddedHandler)Delegate.Combine(ScrapAdded, new ScrapBook.ScrapAddedHandler(listener.ScrapAdded));
        }

        // Token: 0x060001CE RID: 462 RVA: 0x00009F7E File Offset: 0x0000817E
        public void addScrapRemovedListener(IScrapRemovedListener listener)
        {
            ScrapRemoved = (ScrapBook.ScrapRemovedHandler)Delegate.Combine(ScrapRemoved, new ScrapBook.ScrapRemovedHandler(listener.ScrapRemoved));
        }

        // Token: 0x060001CF RID: 463 RVA: 0x00009FA4 File Offset: 0x000081A4
        public void WClickStyle(ScrapBase scrap, Point clickpoint)
        {
            var wclickStyleID = _mainform.optSetuna.Scrap.WClickStyleID;
            if (wclickStyleID != 0)
            {
                var cstyle = _mainform.optSetuna.FindStyle(wclickStyleID);
                if (cstyle != null)
                {
                    cstyle.Apply(ref scrap, clickpoint);
                }
            }
        }

        // Token: 0x060001D0 RID: 464 RVA: 0x00009FE8 File Offset: 0x000081E8
        public void AddDragImageFileName(string path)
        {
            _mainform.AddImageList(new ScrapSourcePath(path));
        }

        // Token: 0x17000052 RID: 82
        // (get) Token: 0x060001D1 RID: 465 RVA: 0x00009FFB File Offset: 0x000081FB
        public bool IsImageDrag => _mainform.optSetuna.Scrap.ImageDrag;

        // Token: 0x040000CA RID: 202
        private Mainform _mainform;

        // Token: 0x040000CB RID: 203
        protected Queue<ScrapBase> _dustbox;

        // Token: 0x040000CC RID: 204
        protected short _dustcap;

        // Token: 0x040000D0 RID: 208
        protected ArrayList _scraps;

        // Token: 0x02000032 RID: 50
        // (Invoke) Token: 0x060001D9 RID: 473
        public delegate void KeyPressHandler(object sender, ScrapKeyPressEventArgs e);

        // Token: 0x02000034 RID: 52
        // (Invoke) Token: 0x060001DE RID: 478
        public delegate void ScrapAddedHandler(object sender, ScrapEventArgs e);

        // Token: 0x02000035 RID: 53
        // (Invoke) Token: 0x060001E2 RID: 482
        public delegate void ScrapRemovedHandler(object sender, ScrapEventArgs e);
    }
}
