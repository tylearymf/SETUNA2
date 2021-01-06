using System.Collections;
using System.Windows.Forms;

namespace SETUNA.Main.KeyItems
{
    // Token: 0x02000044 RID: 68
    public class KeyItemBook
    {
        // Token: 0x06000277 RID: 631 RVA: 0x0000D583 File Offset: 0x0000B783
        public KeyItemBook()
        {
            _keys = new Hashtable();
        }

        // Token: 0x06000278 RID: 632 RVA: 0x0000D596 File Offset: 0x0000B796
        public void AddKeyItem(KeyItem key)
        {
            _keys.Add(key._key, key);
        }

        // Token: 0x06000279 RID: 633 RVA: 0x0000D5B0 File Offset: 0x0000B7B0
        public void AddKeyItem(KeyItem[] keys)
        {
            for (var i = 0; i < keys.Length; i++)
            {
                AddKeyItem(keys[i]);
            }
        }

        // Token: 0x0600027A RID: 634 RVA: 0x0000D5D4 File Offset: 0x0000B7D4
        public KeyItem FindKeyItem(Keys key)
        {
            return (KeyItem)_keys[(int)key];
        }

        // Token: 0x0600027B RID: 635 RVA: 0x0000D5EC File Offset: 0x0000B7EC
        public KeyItem FindKeyItem(KeyItem key)
        {
            return FindKeyItem((Keys)key._key);
        }

        // Token: 0x04000117 RID: 279
        private Hashtable _keys;
    }
}
