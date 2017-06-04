namespace SETUNA.Main
{
    using System;

    public class ScrapEventArgs : EventArgs
    {
        public ScrapBase scrap;

        public ScrapEventArgs()
        {
        }

        public ScrapEventArgs(ScrapBase targetscrap)
        {
            this.scrap = targetscrap;
        }
    }
}

