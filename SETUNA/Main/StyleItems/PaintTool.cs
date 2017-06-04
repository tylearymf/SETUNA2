namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public abstract class PaintTool : IDisposable
    {
        private bool _active = false;
        protected Color _color;
        protected ScrapPaintWindow _parent;

        public event PaintToolDelegate Finished;

        public event PaintToolDelegate Started;

        public PaintTool(ScrapPaintWindow parent)
        {
            this._parent = parent;
        }

        public void ChangeColor(Color color)
        {
            this._color = color;
            this.ClearCommand();
        }

        protected abstract void ClearCommand();
        public virtual void Dispose()
        {
            if (this.IsActive)
            {
                this.End();
            }
        }

        public void Draw(Graphics g)
        {
            ToolCommand command = this.GetCommand();
            if (command != null)
            {
                command.Draw(g);
            }
        }

        public void End()
        {
            if (this._active)
            {
                this._active = false;
                this.OnFinished();
            }
        }

        protected abstract ToolCommand GetCommand();
        public virtual void KeyUp(KeyEventArgs e)
        {
        }

        public virtual void MouseDown(MouseEventArgs e)
        {
        }

        public virtual void MouseMove(MouseEventArgs e)
        {
        }

        public virtual void MouseUp(MouseEventArgs e)
        {
        }

        private void OnFinished()
        {
            if (this.Finished != null)
            {
                this.Finished(this.GetCommand());
                this.ClearCommand();
            }
        }

        private void OnStarted()
        {
            if (this.Started != null)
            {
                this.Started(this.GetCommand());
            }
        }

        public void ReloadCommand()
        {
            this.ClearCommand();
        }

        public virtual void ShowToolBar(Form parent)
        {
        }

        public void Start()
        {
            this._active = true;
        }

        public abstract ScrapPaintToolBar.ToolKind GetToolType { get; }

        public bool IsActive =>
            this._active;

        public delegate void PaintToolDelegate(ToolCommand command);
    }
}

