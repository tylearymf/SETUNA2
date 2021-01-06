using System;

namespace SETUNA.Main
{
    // Token: 0x0200002C RID: 44
    public class ScrapEventArgs : EventArgs
    {
        // Token: 0x060001A9 RID: 425 RVA: 0x000099DC File Offset: 0x00007BDC
        public ScrapEventArgs()
        {
        }

        // Token: 0x060001AA RID: 426 RVA: 0x000099E4 File Offset: 0x00007BE4
        public ScrapEventArgs(ScrapBase targetscrap)
        {
            scrap = targetscrap;
        }

        // Token: 0x040000C7 RID: 199
        public ScrapBase scrap;
    }
}
