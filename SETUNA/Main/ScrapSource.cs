using System;
using System.Drawing;

namespace SETUNA.Main
{
    // Token: 0x0200003F RID: 63
    public abstract class ScrapSource : IDisposable
    {
        // Token: 0x17000067 RID: 103
        // (get) Token: 0x06000263 RID: 611 RVA: 0x0000D1D0 File Offset: 0x0000B3D0
        public string Name => _name;

        // Token: 0x06000264 RID: 612
        public abstract Image GetImage();

        // Token: 0x06000265 RID: 613 RVA: 0x0000D1D8 File Offset: 0x0000B3D8
        public virtual Point GetPosition()
        {
            return Point.Empty;
        }

        // Token: 0x06000266 RID: 614 RVA: 0x0000D1DF File Offset: 0x0000B3DF
        public virtual void Dispose()
        {
            Console.WriteLine("ScrapSource Dispose");
        }

        // Token: 0x04000110 RID: 272
        protected string _name;
    }
}
