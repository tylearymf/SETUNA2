namespace SETUNA.Main
{
    using System;
    using System.Windows.Forms;

    public class ScrapMenuArgs : EventArgs
    {
        public ContextMenuStrip menu;
        public ScrapBase scrap;

        public ScrapMenuArgs()
        {
        }

        public ScrapMenuArgs(ScrapBase targetscrap, ContextMenuStrip targetmenu)
        {
            this.scrap = targetscrap;
            this.menu = targetmenu;
        }
    }
}

