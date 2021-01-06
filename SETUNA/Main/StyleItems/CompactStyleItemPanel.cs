using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200007A RID: 122
    internal partial class CompactStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060003F9 RID: 1017 RVA: 0x00019836 File Offset: 0x00017A36
        public CompactStyleItemPanel()
        {
        }

        // Token: 0x060003FA RID: 1018 RVA: 0x0001983E File Offset: 0x00017A3E
        public CompactStyleItemPanel(CCompactStyleItem item) : base(item)
        {
        }

        // Token: 0x060003FB RID: 1019 RVA: 0x00019848 File Offset: 0x00017A48
        protected override void SetStyleToForm(object style)
        {
            var ccompactStyleItem = (CCompactStyleItem)style;
            InitializeComponent();
            Text = ccompactStyleItem.GetDisplayName();
            numOpacity.Minimum = CCompactStyleItem.OpacityMinValue;
            numOpacity.Maximum = CCompactStyleItem.OpacityMaxValue;
            numOpacity.Value = ccompactStyleItem.Opacity;
            barOpacity.Minimum = CCompactStyleItem.OpacityMinValue;
            barOpacity.Maximum = CCompactStyleItem.OpacityMaxValue;
            barOpacity.Value = ccompactStyleItem.Opacity;
            picLineColor.BackColor = Color.FromArgb(ccompactStyleItem.LineColor);
            rdoSolid.Checked = ccompactStyleItem.SoldLine;
            rdoDashed.Checked = !ccompactStyleItem.SoldLine;
            cm = new ColorMatrix
            {
                Matrix00 = 1f,
                Matrix11 = 1f,
                Matrix22 = 1f,
                Matrix33 = (float)(numOpacity.Value / 100m),
                Matrix44 = 1f
            };
            ia = new ImageAttributes();
            ia.SetColorMatrix(cm);
            imgBackground = new Bitmap(picPreview.Width, picPreview.Height, PixelFormat.Format24bppRgb);
            using (var graphics = Graphics.FromImage(imgBackground))
            {
                graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), imgBackground.Size);
            }
            imgScrap = new Bitmap(50, 50, PixelFormat.Format24bppRgb);
            using (var graphics2 = Graphics.FromImage(imgScrap))
            {
                graphics2.DrawImageUnscaled(SETUNA.Resources.Image.SampleImage, imgScrap.Width / 2 - SETUNA.Resources.Image.SampleImage.Width / 2, imgScrap.Height / 2 - SETUNA.Resources.Image.SampleImage.Height / 2);
            }
            UpdateLine();
        }

        // Token: 0x060003FC RID: 1020 RVA: 0x00019A94 File Offset: 0x00017C94
        protected override object GetStyleFromForm()
        {
            return new CCompactStyleItem
            {
                Opacity = (byte)numOpacity.Value,
                LineColor = picLineColor.BackColor.ToArgb(),
                SoldLine = rdoSolid.Checked
            };
        }

        // Token: 0x060003FD RID: 1021 RVA: 0x00019AE8 File Offset: 0x00017CE8
        private void numOpacity_Enter(object sender, EventArgs e)
        {
            var numericUpDown = (NumericUpDown)sender;
            numericUpDown.Select(0, numericUpDown.Value.ToString().Length);
        }

        // Token: 0x060003FE RID: 1022 RVA: 0x00019B16 File Offset: 0x00017D16
        private void barOpacity_Scroll(object sender, EventArgs e)
        {
            numOpacity.Value = barOpacity.Value;
        }

        // Token: 0x060003FF RID: 1023 RVA: 0x00019B33 File Offset: 0x00017D33
        private void numOpacity_ValueChanged(object sender, EventArgs e)
        {
            if (barOpacity.Value != (int)numOpacity.Value)
            {
                barOpacity.Value = (int)numOpacity.Value;
            }
        }

        // Token: 0x06000400 RID: 1024 RVA: 0x00019B70 File Offset: 0x00017D70
        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            if (imgBackground != null)
            {
                e.Graphics.DrawImageUnscaled(imgBackground, new Point(0, 0));
            }
            if (imgScrap != null)
            {
                e.Graphics.DrawImage(imgScrap, new Rectangle((imgBackground.Width - imgScrap.Width) / 2, (imgBackground.Height - imgScrap.Height) / 2, imgScrap.Width, imgScrap.Height), 0, 0, imgScrap.Width, imgScrap.Height, GraphicsUnit.Pixel, ia);
            }
        }

        // Token: 0x06000401 RID: 1025 RVA: 0x00019C22 File Offset: 0x00017E22
        private void OpacityStyleItemPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imgBackground != null)
            {
                imgBackground.Dispose();
                imgBackground = null;
                if (imgScrap != null)
                {
                    imgScrap.Dispose();
                    imgScrap = null;
                }
                GC.Collect();
            }
        }

        // Token: 0x06000402 RID: 1026 RVA: 0x00019C60 File Offset: 0x00017E60
        private void numPreview_ValueChanged()
        {
            if (cm != null && ia != null)
            {
                cm.Matrix33 = (float)(numOpacity.Value / 100m);
                ia.SetColorMatrix(cm);
            }
            Refresh();
        }

        // Token: 0x06000403 RID: 1027 RVA: 0x00019CBC File Offset: 0x00017EBC
        private void picLineColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = picLineColor.BackColor;
            var dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                picLineColor.BackColor = colorDialog1.Color;
            }
            UpdateLine();
        }

        // Token: 0x06000404 RID: 1028 RVA: 0x00019D0B File Offset: 0x00017F0B
        private void barOpacity_ValueChanged(object sender, EventArgs e)
        {
            numPreview_ValueChanged();
        }

        // Token: 0x06000405 RID: 1029 RVA: 0x00019D14 File Offset: 0x00017F14
        private void UpdateLine()
        {
            if (imgScrap == null)
            {
                return;
            }
            using (var graphics = Graphics.FromImage(imgScrap))
            {
                var pen = new Pen(picLineColor.BackColor);
                if (rdoDashed.Checked)
                {
                    pen.DashStyle = DashStyle.Dash;
                    pen.DashPattern = new float[]
                    {
                        4f,
                        4f
                    };
                }
                graphics.DrawRectangle(new Pen(Color.White), 0, 0, imgScrap.Width - 1, imgScrap.Height - 1);
                graphics.DrawRectangle(pen, 0, 0, imgScrap.Width - 1, imgScrap.Height - 1);
            }
            picPreview.Refresh();
        }

        // Token: 0x06000406 RID: 1030 RVA: 0x00019DF0 File Offset: 0x00017FF0
        private void rdoSolid_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLine();
        }

        // Token: 0x04000260 RID: 608
        private System.Drawing.Image imgBackground;

        // Token: 0x04000261 RID: 609
        private System.Drawing.Image imgScrap;

        // Token: 0x04000262 RID: 610
        private ImageAttributes ia;

        // Token: 0x04000268 RID: 616
        private ColorMatrix cm;
    }
}
