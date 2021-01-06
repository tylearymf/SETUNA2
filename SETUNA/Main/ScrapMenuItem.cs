namespace SETUNA.Main
{
    // Token: 0x02000069 RID: 105
    public sealed class ScrapMenuItem
    {
        // Token: 0x1700008A RID: 138
        // (get) Token: 0x060003A1 RID: 929 RVA: 0x0001637C File Offset: 0x0001457C
        // (set) Token: 0x060003A0 RID: 928 RVA: 0x00016373 File Offset: 0x00014573
        public ScrapMenuItem.ScrapMenuItemType ItemType
        {
            get => _itemtype;
            set => _itemtype = value;
        }

        // Token: 0x1700008B RID: 139
        // (get) Token: 0x060003A3 RID: 931 RVA: 0x0001638D File Offset: 0x0001458D
        // (set) Token: 0x060003A2 RID: 930 RVA: 0x00016384 File Offset: 0x00014584
        public int ItemId
        {
            get => _itemid;
            set => _itemid = value;
        }

        // Token: 0x040001FB RID: 507
        private ScrapMenuItem.ScrapMenuItemType _itemtype;

        // Token: 0x040001FC RID: 508
        private int _itemid;

        // Token: 0x0200006A RID: 106
        public enum ScrapMenuItemType
        {
            // Token: 0x040001FE RID: 510
            Style,
            // Token: 0x040001FF RID: 511
            Other
        }

        // Token: 0x0200006B RID: 107
        public enum OtherItem
        {
            // Token: 0x04000201 RID: 513
            ScrapClose = -1,
            // Token: 0x04000202 RID: 514
            AllHide = -2,
            // Token: 0x04000203 RID: 515
            AllShow = -3,
            // Token: 0x04000204 RID: 516
            Separator = -4
        }
    }
}
