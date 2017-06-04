namespace SETUNA.Main.KeyItems
{
    using System;
    using System.Collections;
    using System.Windows.Forms;

    public class KeyItemBook
    {
        private Hashtable _keys = new Hashtable();

        public void AddKeyItem(KeyItem key)
        {
            this._keys.Add(key._key, key);
        }

        public void AddKeyItem(KeyItem[] keys)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                this.AddKeyItem(keys[i]);
            }
        }

        public KeyItem FindKeyItem(KeyItem key) => 
            this.FindKeyItem((Keys) key._key);

        public KeyItem FindKeyItem(Keys key) => 
            ((KeyItem) this._keys[(int) key]);
    }
}

