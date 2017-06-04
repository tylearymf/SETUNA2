namespace SETUNA.Main
{
    using System;

    public sealed class ScrapMenuItem
    {
        private int _itemid;
        private ScrapMenuItemType _itemtype;

        public int ItemId
        {
            get{return  
                this._itemid;}
            set
            {
                this._itemid = value;
            }
        }

        public ScrapMenuItemType ItemType
        {
            get{return  
                this._itemtype;}
            set
            {
                this._itemtype = value;
            }
        }

        public enum OtherItem
        {
            AllHide = -2,
            AllShow = -3,
            ScrapClose = -1,
            Separator = -4
        }

        public enum ScrapMenuItemType
        {
            Style,
            Other
        }
    }
}

