namespace SETUNA.Main
{
    using System;

    public interface IScrapStyleListener
    {
        void ScrapActivated(object sender, ScrapEventArgs e);
        void ScrapCreated(object sender, ScrapEventArgs e);
        void ScrapInactived(object sender, ScrapEventArgs e);
        void ScrapInactiveMouseOut(object sender, ScrapEventArgs e);
        void ScrapInactiveMouseOver(object sender, ScrapEventArgs e);
    }
}

