using System;
using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x020000B3 RID: 179
    public partial class PaintForm : BaseForm
    {
        // Token: 0x170000C7 RID: 199
        // (get) Token: 0x060005A0 RID: 1440 RVA: 0x00027056 File Offset: 0x00025256
        public Image Image => _src;

        // Token: 0x060005A1 RID: 1441 RVA: 0x0002705E File Offset: 0x0002525E
        public PaintForm(Image src)
        {
            InitializeComponent();
            _src = src;
        }

        // Token: 0x060005A2 RID: 1442 RVA: 0x00027073 File Offset: 0x00025273
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Gray, 0, 0, base.Width, base.Height);
            if (_src != null)
            {
                e.Graphics.DrawImageUnscaled(_src, 0, 0);
            }
        }

        // Token: 0x060005A3 RID: 1443 RVA: 0x000270AE File Offset: 0x000252AE
        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        // Token: 0x020000B4 RID: 180
        private abstract class PaintCommand
        {
            // Token: 0x170000C8 RID: 200
            // (get) Token: 0x060005A5 RID: 1445 RVA: 0x000270BF File Offset: 0x000252BF
            // (set) Token: 0x060005A4 RID: 1444 RVA: 0x000270B6 File Offset: 0x000252B6
            public float Opacity
            {
                get => _opacity;
                set => _opacity = value;
            }

            // Token: 0x060005A6 RID: 1446
            public abstract void Draw(Graphics g);

            // Token: 0x04000397 RID: 919
            private float _opacity;
        }
    }
}
