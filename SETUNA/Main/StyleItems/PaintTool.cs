using System;
using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000023 RID: 35
    public abstract class PaintTool : IDisposable
    {
        // Token: 0x14000010 RID: 16
        // (add) Token: 0x0600016B RID: 363 RVA: 0x00008830 File Offset: 0x00006A30
        // (remove) Token: 0x0600016C RID: 364 RVA: 0x00008849 File Offset: 0x00006A49
        public event PaintTool.PaintToolDelegate Finished;

        // Token: 0x14000011 RID: 17
        // (add) Token: 0x0600016D RID: 365 RVA: 0x00008862 File Offset: 0x00006A62
        // (remove) Token: 0x0600016E RID: 366 RVA: 0x0000887B File Offset: 0x00006A7B
        public event PaintTool.PaintToolDelegate Started;

        // Token: 0x0600016F RID: 367 RVA: 0x00008894 File Offset: 0x00006A94
        public PaintTool(ScrapPaintWindow parent)
        {
            _active = false;
            _parent = parent;
        }

        // Token: 0x06000170 RID: 368 RVA: 0x000088AC File Offset: 0x00006AAC
        public void Draw(Graphics g)
        {
            var command = GetCommand();
            if (command != null)
            {
                command.Draw(g);
            }
        }

        // Token: 0x06000171 RID: 369 RVA: 0x000088CA File Offset: 0x00006ACA
        public void ChangeColor(Color color)
        {
            _color = color;
            ClearCommand();
        }

        // Token: 0x06000172 RID: 370 RVA: 0x000088D9 File Offset: 0x00006AD9
        public virtual void ShowToolBar(Form parent)
        {
        }

        // Token: 0x06000173 RID: 371 RVA: 0x000088DB File Offset: 0x00006ADB
        private void OnStarted()
        {
            if (Started != null)
            {
                Started(GetCommand());
            }
        }

        // Token: 0x06000174 RID: 372 RVA: 0x000088F6 File Offset: 0x00006AF6
        private void OnFinished()
        {
            if (Finished != null)
            {
                Finished(GetCommand());
                ClearCommand();
            }
        }

        // Token: 0x06000175 RID: 373 RVA: 0x00008917 File Offset: 0x00006B17
        public void ReloadCommand()
        {
            ClearCommand();
        }

        // Token: 0x17000047 RID: 71
        // (get) Token: 0x06000176 RID: 374 RVA: 0x0000891F File Offset: 0x00006B1F
        public bool IsActive => _active;

        // Token: 0x06000177 RID: 375 RVA: 0x00008927 File Offset: 0x00006B27
        public void Start()
        {
            _active = true;
        }

        // Token: 0x06000178 RID: 376 RVA: 0x00008930 File Offset: 0x00006B30
        public void End()
        {
            if (_active)
            {
                _active = false;
                OnFinished();
            }
        }

        // Token: 0x17000048 RID: 72
        // (get) Token: 0x06000179 RID: 377
        public abstract ScrapPaintToolBar.ToolKind GetToolType { get; }

        // Token: 0x0600017A RID: 378
        protected abstract ToolCommand GetCommand();

        // Token: 0x0600017B RID: 379
        protected abstract void ClearCommand();

        // Token: 0x0600017C RID: 380 RVA: 0x00008947 File Offset: 0x00006B47
        public virtual void MouseDown(MouseEventArgs e)
        {
        }

        // Token: 0x0600017D RID: 381 RVA: 0x00008949 File Offset: 0x00006B49
        public virtual void MouseUp(MouseEventArgs e)
        {
        }

        // Token: 0x0600017E RID: 382 RVA: 0x0000894B File Offset: 0x00006B4B
        public virtual void MouseMove(MouseEventArgs e)
        {
        }

        // Token: 0x0600017F RID: 383 RVA: 0x0000894D File Offset: 0x00006B4D
        public virtual void KeyUp(KeyEventArgs e)
        {
        }

        // Token: 0x06000180 RID: 384 RVA: 0x0000894F File Offset: 0x00006B4F
        public virtual void Dispose()
        {
            if (IsActive)
            {
                End();
            }
        }

        // Token: 0x040000A6 RID: 166
        protected Color _color;

        // Token: 0x040000A9 RID: 169
        protected ScrapPaintWindow _parent;

        // Token: 0x040000AA RID: 170
        private bool _active;

        // Token: 0x02000027 RID: 39
        // (Invoke) Token: 0x06000198 RID: 408
        public delegate void PaintToolDelegate(ToolCommand command);
    }
}
