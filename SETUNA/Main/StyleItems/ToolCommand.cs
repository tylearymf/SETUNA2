using System;
using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000015 RID: 21
    public abstract class ToolCommand : IDisposable
    {
        // Token: 0x060000E7 RID: 231 RVA: 0x000069A7 File Offset: 0x00004BA7
        public ToolCommand()
        {
            Parent = null;
        }

        // Token: 0x060000E8 RID: 232
        public abstract void Draw(Graphics g);

        // Token: 0x060000E9 RID: 233 RVA: 0x000069B6 File Offset: 0x00004BB6
        public virtual void Dispose()
        {
        }

        // Token: 0x04000079 RID: 121
        public ILayer Parent;
    }
}
