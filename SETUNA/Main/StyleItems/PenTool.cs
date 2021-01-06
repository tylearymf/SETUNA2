using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x020000A4 RID: 164
    public class PenTool : PaintTool
    {
        // Token: 0x170000BB RID: 187
        // (set) Token: 0x0600054A RID: 1354 RVA: 0x00024909 File Offset: 0x00022B09
        public int Opacity
        {
            set => _opacity = value;
        }

        // Token: 0x170000BC RID: 188
        // (get) Token: 0x0600054B RID: 1355 RVA: 0x00024912 File Offset: 0x00022B12
        public static Color EraseColor => Color.Pink;

        // Token: 0x0600054C RID: 1356 RVA: 0x00024919 File Offset: 0x00022B19
        public PenTool(Color color, ScrapPaintWindow parent) : base(parent)
        {
            PenWidth = 3f;
            Opacity = 255;
            _color = color;
            base.ChangeColor(color);
        }

        // Token: 0x0600054D RID: 1357 RVA: 0x00024946 File Offset: 0x00022B46
        public override void MouseDown(MouseEventArgs e)
        {
            base.Start();
            DrawPen(e.Location);
        }

        // Token: 0x0600054E RID: 1358 RVA: 0x0002495A File Offset: 0x00022B5A
        public override void MouseUp(MouseEventArgs e)
        {
            DrawPen(e.Location);
            base.End();
        }

        // Token: 0x0600054F RID: 1359 RVA: 0x0002496E File Offset: 0x00022B6E
        public override void MouseMove(MouseEventArgs e)
        {
            DrawPen(e.Location);
        }

        // Token: 0x06000550 RID: 1360 RVA: 0x0002497C File Offset: 0x00022B7C
        private void DrawPen(Point pt)
        {
            if (base.IsActive)
            {
                cmd.AddPoint(pt);
            }
        }

        // Token: 0x06000551 RID: 1361 RVA: 0x00024994 File Offset: 0x00022B94
        public override void ShowToolBar(Form parent)
        {
            base.ShowToolBar(parent);
            frm = new ScrapPaintPenTool(this, PenTool.EraseColor.ToArgb() == _color.ToArgb())
            {
                Left = parent.Left
            };
            frm.Top = parent.Top - frm.Height - 20;
            parent.AddOwnedForm(frm);
            frm.Show();
            parent.AddOwnedForm(frm);
        }

        // Token: 0x06000552 RID: 1362 RVA: 0x00024A22 File Offset: 0x00022C22
        protected override ToolCommand GetCommand()
        {
            return cmd;
        }

        // Token: 0x06000553 RID: 1363 RVA: 0x00024A2C File Offset: 0x00022C2C
        protected override void ClearCommand()
        {
            if (cmd != null)
            {
                cmd.Dispose();
            }
            _color = Color.FromArgb(_opacity, _color);
            cmd = new PenToolCommand(_color, PenWidth);
        }

        // Token: 0x06000554 RID: 1364 RVA: 0x00024A7A File Offset: 0x00022C7A
        public override void Dispose()
        {
            base.Dispose();
            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }
            if (frm != null)
            {
                frm.Dispose();
                frm = null;
            }
        }

        // Token: 0x170000BD RID: 189
        // (get) Token: 0x06000555 RID: 1365 RVA: 0x00024AB8 File Offset: 0x00022CB8
        private bool IsEraseMode => PenTool.EraseColor.ToArgb() == _color.ToArgb();

        // Token: 0x170000BE RID: 190
        // (get) Token: 0x06000556 RID: 1366 RVA: 0x00024ADF File Offset: 0x00022CDF
        public override ScrapPaintToolBar.ToolKind GetToolType
        {
            get
            {
                if (!IsEraseMode)
                {
                    return ScrapPaintToolBar.ToolKind.笔工具;
                }
                return ScrapPaintToolBar.ToolKind.消しゴム工具;
            }
        }

        // Token: 0x04000351 RID: 849
        private PenToolCommand cmd;

        // Token: 0x04000352 RID: 850
        private ScrapPaintPenTool frm;

        // Token: 0x04000353 RID: 851
        public float PenWidth;

        // Token: 0x04000354 RID: 852
        private int _opacity;
    }
}
