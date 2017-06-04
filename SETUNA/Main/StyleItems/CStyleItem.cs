namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public abstract class CStyleItem : IScrapStyle, ICloneable
    {
        protected int _waitinterval;

        public abstract void Apply(ref ScrapBase scrap, Point clickpoint);
        public void Apply(ref ScrapBase scrap, out int waitinterval, Point clickpoint)
        {
            this._waitinterval = 0;
            this.Apply(ref scrap, clickpoint);
            waitinterval = this._waitinterval;
        }

        public object Clone() => 
            base.MemberwiseClone();

        public abstract string GetDescription();
        public abstract string GetDisplayName();
        public abstract Bitmap GetIcon();
        public abstract string GetName();
        protected abstract ToolBoxForm GetToolBoxForm();
        protected abstract void SetTunedStyleItem(CStyleItem newOwn);
        public void StyleItemSetting()
        {
            ToolBoxForm toolBoxForm = this.GetToolBoxForm();
            toolBoxForm.ShowDialog();
            if (toolBoxForm.DialogResult == DialogResult.OK)
            {
                this.SetTunedStyleItem((CStyleItem) toolBoxForm.StyleItem);
            }
        }

        public override string ToString() => 
            this.GetDisplayName();

        public virtual bool IsInitApply =>
            true;

        public bool IsSetting
        {
            get
            {
                if (this.GetToolBoxForm() is NothingStyleItemPanel)
                {
                    return false;
                }
                return true;
            }
        }

        public virtual bool IsTerminate =>
            false;

        public virtual string NameAndState
        {
            get
            {
                if (this.StateText == "")
                {
                    return this.GetDisplayName();
                }
                return (this.GetDisplayName() + " (" + this.StateText + ")");
            }
        }

        public virtual string StateText =>
            "";
    }
}

