using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200008F RID: 143
    internal partial class OpacityStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060004B0 RID: 1200 RVA: 0x0001FD16 File Offset: 0x0001DF16
        public OpacityStyleItemPanel()
        {
        }

        // Token: 0x060004B1 RID: 1201 RVA: 0x0001FD1E File Offset: 0x0001DF1E
        public OpacityStyleItemPanel(COpacityStyleItem item) : base(item)
        {
        }

        // Token: 0x060004B2 RID: 1202 RVA: 0x0001FD28 File Offset: 0x0001DF28
        protected override void SetStyleToForm(object style)
        {
            var copacityStyleItem = (COpacityStyleItem)style;
            InitializeComponent();
            Text = copacityStyleItem.GetDisplayName();
            numOpacity.Minimum = 1m;
            numOpacity.Maximum = 100m;
            numOpacity.Value = 100m;
            barOpacity.Minimum = 1;
            barOpacity.Maximum = 100;
            barOpacity.Value = 100;
            numPreview.Minimum = 1m;
            numPreview.Maximum = 100m;
            numPreview.Value = 100m;
            numOpacity2.Minimum = -99m;
            numOpacity2.Maximum = 99m;
            numOpacity2.Value = 0m;
            barOpacity2.Minimum = -99;
            barOpacity2.Maximum = 99;
            barOpacity2.Value = 0;
            rdoFixed.Checked = copacityStyleItem.Absolute;
            rdoIncrement.Checked = !copacityStyleItem.Absolute;
            if (copacityStyleItem.Absolute)
            {
                numOpacity.Value = copacityStyleItem.Opacity;
                numPreview.Value = copacityStyleItem.Opacity;
            }
            else
            {
                numOpacity2.Value = copacityStyleItem.Opacity;
            }
            rdoFixed_CheckedChanged(this, null);
            cm = new ColorMatrix
            {
                Matrix00 = 1f,
                Matrix11 = 1f,
                Matrix22 = 1f,
                Matrix33 = (float)(numPreview.Value / 100m),
                Matrix44 = 1f
            };
            ia = new ImageAttributes();
            ia.SetColorMatrix(cm);
            imgBackground = new Bitmap(picPreview.Width, picPreview.Height, PixelFormat.Format24bppRgb);
            using (var graphics = Graphics.FromImage(imgBackground))
            {
                graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), imgBackground.Size);
            }
            imgScrap = SETUNA.Resources.Image.SampleImage;
        }

        // Token: 0x060004B3 RID: 1203 RVA: 0x0001FFBC File Offset: 0x0001E1BC
        protected override object GetStyleFromForm()
        {
            var copacityStyleItem = new COpacityStyleItem();
            if (rdoFixed.Checked)
            {
                copacityStyleItem.Opacity = (int)numOpacity.Value;
            }
            else
            {
                copacityStyleItem.Opacity = (int)numOpacity2.Value;
            }
            copacityStyleItem.Absolute = rdoFixed.Checked;
            return copacityStyleItem;
        }

        // Token: 0x060004B4 RID: 1204 RVA: 0x0002001C File Offset: 0x0001E21C
        private void rdoFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFixed.Checked)
            {
                numOpacity.Enabled = true;
                numOpacity2.Enabled = false;
                barOpacity.Enabled = true;
                barOpacity2.Enabled = false;
                numOpacity.Focus();
                btnPreview.Enabled = false;
                numPreview.Enabled = false;
                numPreview.Value = numOpacity.Value;
                return;
            }
            numOpacity.Enabled = false;
            numOpacity2.Enabled = true;
            barOpacity.Enabled = false;
            barOpacity2.Enabled = true;
            numOpacity2.Focus();
            btnPreview.Enabled = true;
            numPreview.Enabled = true;
        }

        // Token: 0x060004B5 RID: 1205 RVA: 0x000200F8 File Offset: 0x0001E2F8
        private void numOpacity_Enter(object sender, EventArgs e)
        {
            var numericUpDown = (NumericUpDown)sender;
            numericUpDown.Select(0, numericUpDown.Value.ToString().Length);
        }

        // Token: 0x060004B6 RID: 1206 RVA: 0x00020126 File Offset: 0x0001E326
        private void OpacityStyleItemPanel_Shown(object sender, EventArgs e)
        {
            if (rdoFixed.Checked)
            {
                numOpacity.Focus();
                return;
            }
            numOpacity2.Focus();
        }

        // Token: 0x060004B7 RID: 1207 RVA: 0x0002014E File Offset: 0x0001E34E
        private void barOpacity_Scroll(object sender, EventArgs e)
        {
            numOpacity.Value = barOpacity.Value;
            numOpacity2.Value = barOpacity2.Value;
        }

        // Token: 0x060004B8 RID: 1208 RVA: 0x00020188 File Offset: 0x0001E388
        private void numOpacity_ValueChanged(object sender, EventArgs e)
        {
            if (barOpacity.Value != (int)numOpacity.Value)
            {
                barOpacity.Value = (int)numOpacity.Value;
            }
            if (barOpacity2.Value != (int)numOpacity2.Value)
            {
                barOpacity2.Value = (int)numOpacity2.Value;
            }
            if (rdoFixed.Checked)
            {
                numPreview.Value = numOpacity.Value;
            }
        }

        // Token: 0x060004B9 RID: 1209 RVA: 0x00020228 File Offset: 0x0001E428
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (numPreview.Value + numOpacity2.Value > numPreview.Maximum)
            {
                numPreview.Value = numPreview.Maximum;
                return;
            }
            if (numPreview.Value + numOpacity2.Value < numPreview.Minimum)
            {
                numPreview.Value = numPreview.Minimum;
                return;
            }
            numPreview.Value += numOpacity2.Value;
        }

        // Token: 0x060004BA RID: 1210 RVA: 0x000202E0 File Offset: 0x0001E4E0
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

        // Token: 0x060004BB RID: 1211 RVA: 0x00020392 File Offset: 0x0001E592
        private void OpacityStyleItemPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imgBackground != null)
            {
                imgBackground.Dispose();
                imgBackground = null;
                GC.Collect();
            }
        }

        // Token: 0x060004BC RID: 1212 RVA: 0x000203B4 File Offset: 0x0001E5B4
        private void numPreview_ValueChanged(object sender, EventArgs e)
        {
            if (cm != null && ia != null)
            {
                cm.Matrix33 = (float)(numPreview.Value / 100m);
                ia.SetColorMatrix(cm);
            }
            Refresh();
        }

        // Token: 0x040002E9 RID: 745
        private System.Drawing.Image imgBackground;

        // Token: 0x040002EA RID: 746
        private System.Drawing.Image imgScrap;

        // Token: 0x040002EB RID: 747
        private ImageAttributes ia;

        // Token: 0x040002EC RID: 748
        private ColorMatrix cm;
    }
}
