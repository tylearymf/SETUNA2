namespace SETUNA.Main
{
    using System;

    public interface IScrapRemovedListener
    {
        void ScrapRemoved(object sender, ScrapEventArgs e);
    }
}

