namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using System;
    using System.Drawing;

    internal interface IScrapStyle
    {
        void Apply(ref ScrapBase scrap, Point clickpoint);
        string GetDescription();
        string GetDisplayName();
        string GetName();
    }
}

