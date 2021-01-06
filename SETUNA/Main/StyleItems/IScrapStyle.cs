using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200000A RID: 10
    internal interface IScrapStyle
    {
        // Token: 0x060000A9 RID: 169
        void Apply(ref ScrapBase scrap, Point clickpoint);

        // Token: 0x060000AA RID: 170
        string GetName();

        // Token: 0x060000AB RID: 171
        string GetDisplayName();

        // Token: 0x060000AC RID: 172
        string GetDescription();
    }
}
