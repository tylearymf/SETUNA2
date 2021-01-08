using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SETUNA.Main
{
    // Token: 0x02000071 RID: 113
    public sealed partial class CaptureSelLine : BaseForm
    {
        // Token: 0x060003B3 RID: 947 RVA: 0x00016470 File Offset: 0x00014670
        public static void AddDashOffset()
        {
            CaptureSelLine.DashOffset++;
            if (CaptureSelLine.DashOffset > 7)
            {
                CaptureSelLine.DashOffset = 0;
            }
        }

        // Token: 0x060003B4 RID: 948 RVA: 0x0001648C File Offset: 0x0001468C
        public CaptureSelLine()
        {
            InitializeComponent();
            base.Width = 1;
            base.Height = 1;
            _linetype = SelLineType.Horizon;
        }

        // Token: 0x060003B5 RID: 949 RVA: 0x000164B0 File Offset: 0x000146B0
        public CaptureSelLine(SelLineType linetype, bool issolid, Color linecolor)
        {
            _linetype = linetype;
            InitializeComponent();
            pat = new float[]
            {
                4f,
                4f
            };
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            penBack = new Pen(new SolidBrush(Color.Fuchsia), 1f);
            penLine = new Pen(linecolor, 1f);
            SetPen(issolid, linecolor);
            base.TransparencyKey = Color.Fuchsia;
            penWhite = new Pen(new SolidBrush(Color.White), 1f);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // 鼠标穿透窗体
                var cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        public bool ShowWhiteBackground { set; get; } = true;


        // Token: 0x060003B6 RID: 950 RVA: 0x00016554 File Offset: 0x00014754
        public void SetPen(bool issolid, Color linecolor)
        {
            if (penLine.Color.ToArgb() != linecolor.ToArgb())
            {
                penLine = new Pen(linecolor, 1f);
            }
            if (!issolid)
            {
                penLine.DashStyle = DashStyle.Dash;
                penLine.DashPattern = pat;
                return;
            }
            penLine.DashStyle = DashStyle.Solid;
        }

        // Token: 0x060003B7 RID: 951 RVA: 0x000165BC File Offset: 0x000147BC
        private void CaptureSelLine_Paint(object sender, PaintEventArgs e)
        {
            if (penLine == null)
            {
                return;
            }
            if (_linetype == SelLineType.Horizon)
            {
                if (ShowWhiteBackground)
                {
                    e.Graphics.DrawLine(penWhite, new Point(ptSel.X, 0), new Point(ptSel.X + szSel.Width - 1, 0));
                }

                e.Graphics.DrawLine(penLine, new Point(ptSel.X + CaptureSelLine.DashOffset, 0), new Point(ptSel.X + szSel.Width - 1, 0));
                if (CaptureSelLine.DashOffset > 4)
                {
                    e.Graphics.DrawLine(penLine, new Point(ptSel.X, 0), new Point(ptSel.X + (CaptureSelLine.DashOffset - 4), 0));
                    return;
                }
            }
            else
            {
                if (ShowWhiteBackground)
                {
                    e.Graphics.DrawLine(penWhite, new Point(0, ptSel.Y), new Point(0, ptSel.Y + szSel.Height - 1));
                }

                e.Graphics.DrawLine(penLine, new Point(0, ptSel.Y + CaptureSelLine.DashOffset), new Point(0, ptSel.Y + szSel.Height - 1));
                if (CaptureSelLine.DashOffset > 4)
                {
                    e.Graphics.DrawLine(penLine, new Point(0, ptSel.Y), new Point(0, ptSel.Y + (CaptureSelLine.DashOffset - 4)));
                }
            }
        }

        // Token: 0x060003B8 RID: 952 RVA: 0x00016778 File Offset: 0x00014978
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        // Token: 0x060003B9 RID: 953 RVA: 0x00016784 File Offset: 0x00014984
        public void SetSelSize(int x, int width)
        {
            if (_linetype == SelLineType.Horizon)
            {
                ptSel.X = x;
                szSel.Width = width;
            }
            else
            {
                ptSel.Y = x;
                szSel.Height = width;
            }
            if (lastx == x && lastw == width)
            {
                return;
            }
            base.Invalidate();
            base.Update();
            lastx = x;
            lastw = width;
        }

        // Token: 0x0400020C RID: 524
        private Point ptSel;

        // Token: 0x0400020D RID: 525
        private Size szSel;

        // Token: 0x0400020E RID: 526
        private SelLineType _linetype;

        // Token: 0x0400020F RID: 527
        private Pen penBack;

        // Token: 0x04000210 RID: 528
        private Pen penLine;

        // Token: 0x04000211 RID: 529
        private Pen penWhite;

        // Token: 0x04000212 RID: 530
        private int lastx;

        // Token: 0x04000213 RID: 531
        private int lastw;

        // Token: 0x04000214 RID: 532
        private float[] pat;

        // Token: 0x04000215 RID: 533
        private static int DashOffset;
    }
}
