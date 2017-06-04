namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class PenTool : PaintTool
    {
        private int _opacity;
        private PenToolCommand cmd;
        private ScrapPaintPenTool frm;
        public float PenWidth;

        public PenTool(Color color, ScrapPaintWindow parent) : base(parent)
        {
            this.PenWidth = 3f;
            this.Opacity = 0xff;
            base._color = color;
            base.ChangeColor(color);
        }

        protected override void ClearCommand()
        {
            if (this.cmd != null)
            {
                this.cmd.Dispose();
            }
            base._color = Color.FromArgb(this._opacity, base._color);
            this.cmd = new PenToolCommand(base._color, this.PenWidth);
        }

        public override void Dispose()
        {
            base.Dispose();
            if (this.cmd != null)
            {
                this.cmd.Dispose();
                this.cmd = null;
            }
            if (this.frm != null)
            {
                this.frm.Dispose();
                this.frm = null;
            }
        }

        private void DrawPen(Point pt)
        {
            if (base.IsActive)
            {
                this.cmd.AddPoint(pt);
            }
        }

        protected override ToolCommand GetCommand() => 
            this.cmd;

        public override void MouseDown(MouseEventArgs e)
        {
            base.Start();
            this.DrawPen(e.Location);
        }

        public override void MouseMove(MouseEventArgs e)
        {
            this.DrawPen(e.Location);
        }

        public override void MouseUp(MouseEventArgs e)
        {
            this.DrawPen(e.Location);
            base.End();
        }

        public override void ShowToolBar(Form parent)
        {
            base.ShowToolBar(parent);
            this.frm = new ScrapPaintPenTool(this, EraseColor.ToArgb() == this._color.ToArgb());
            this.frm.Left = parent.Left;
            this.frm.Top = (parent.Top - this.frm.Height) - 20;
            parent.AddOwnedForm(this.frm);
            this.frm.Show();
            parent.AddOwnedForm(this.frm);
        }

        public static Color EraseColor =>
            Color.Pink;

        public override ScrapPaintToolBar.ToolKind GetToolType
        {
            get
            {
                if (!this.IsEraseMode)
                {
                    return ScrapPaintToolBar.ToolKind.笔工具;
                }
                return ScrapPaintToolBar.ToolKind.消しゴム工具;
            }
        }

        private bool IsEraseMode =>
            (EraseColor.ToArgb() == this._color.ToArgb());

        public int Opacity
        {
            set
            {
                this._opacity = value;
            }
        }
    }
}

