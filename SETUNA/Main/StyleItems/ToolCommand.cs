namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Drawing;

    public abstract class ToolCommand : IDisposable
    {
        public ILayer Parent = null;

        public virtual void Dispose()
        {
        }

        public abstract void Draw(Graphics g);
    }
}

