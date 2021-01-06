using System;
using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000007 RID: 7
    public abstract class CStyleItem : IScrapStyle, ICloneable
    {
        // Token: 0x06000026 RID: 38 RVA: 0x000033A4 File Offset: 0x000015A4
        public CStyleItem()
        {
        }

        // Token: 0x06000027 RID: 39 RVA: 0x000033AC File Offset: 0x000015AC
        public override string ToString()
        {
            return GetDisplayName();
        }

        // Token: 0x17000007 RID: 7
        // (get) Token: 0x06000028 RID: 40 RVA: 0x000033B4 File Offset: 0x000015B4
        public bool IsSetting => !(GetToolBoxForm() is NothingStyleItemPanel);

        // Token: 0x06000029 RID: 41 RVA: 0x000033C8 File Offset: 0x000015C8
        public void StyleItemSetting()
        {
            var toolBoxForm = GetToolBoxForm();
            toolBoxForm.ShowDialog();
            if (toolBoxForm.DialogResult == DialogResult.OK)
            {
                SetTunedStyleItem((CStyleItem)toolBoxForm.StyleItem);
            }
        }

        // Token: 0x0600002A RID: 42 RVA: 0x000033FD File Offset: 0x000015FD
        public void Apply(ref ScrapBase scrap, out int waitinterval, Point clickpoint)
        {
            _waitinterval = 0;
            Apply(ref scrap, clickpoint);
            waitinterval = _waitinterval;
        }

        // Token: 0x17000008 RID: 8
        // (get) Token: 0x0600002B RID: 43 RVA: 0x00003416 File Offset: 0x00001616
        public virtual string StateText => "";

        // Token: 0x17000009 RID: 9
        // (get) Token: 0x0600002C RID: 44 RVA: 0x0000341D File Offset: 0x0000161D
        public virtual string NameAndState
        {
            get
            {
                if (StateText == "")
                {
                    return GetDisplayName();
                }
                return GetDisplayName() + " (" + StateText + ")";
            }
        }

        // Token: 0x1700000A RID: 10
        // (get) Token: 0x0600002D RID: 45 RVA: 0x00003453 File Offset: 0x00001653
        public virtual bool IsTerminate => false;

        // Token: 0x1700000B RID: 11
        // (get) Token: 0x0600002E RID: 46 RVA: 0x00003456 File Offset: 0x00001656
        public virtual bool IsInitApply => true;

        // Token: 0x0600002F RID: 47
        public abstract void Apply(ref ScrapBase scrap, Point clickpoint);

        // Token: 0x06000030 RID: 48
        public abstract string GetName();

        // Token: 0x06000031 RID: 49
        public abstract string GetDisplayName();

        // Token: 0x06000032 RID: 50
        public abstract string GetDescription();

        // Token: 0x06000033 RID: 51
        protected abstract ToolBoxForm GetToolBoxForm();

        // Token: 0x06000034 RID: 52
        protected abstract void SetTunedStyleItem(CStyleItem newOwn);

        // Token: 0x06000035 RID: 53
        public abstract Bitmap GetIcon();

        // Token: 0x06000036 RID: 54 RVA: 0x00003459 File Offset: 0x00001659
        public object Clone()
        {
            return base.MemberwiseClone();
        }

        // Token: 0x04000020 RID: 32
        protected int _waitinterval;
    }
}
