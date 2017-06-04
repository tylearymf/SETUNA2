namespace SETUNA.Main
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    internal class ContextStyleMenuStrip : ContextMenuStrip
    {
        private ScrapBase _scrap;

        public ContextStyleMenuStrip()
        {
        }

        public ContextStyleMenuStrip(IContainer container) : base(container)
        {
        }

        public ScrapBase Scrap
        {
            get{return  
                this._scrap;}
            set
            {
                this._scrap = value;
            }
        }
    }
}

