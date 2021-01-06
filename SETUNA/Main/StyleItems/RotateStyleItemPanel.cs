using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000090 RID: 144
    internal partial class RotateStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060004BE RID: 1214 RVA: 0x00020C61 File Offset: 0x0001EE61
        public RotateStyleItemPanel()
        {
        }

        // Token: 0x060004BF RID: 1215 RVA: 0x00020C69 File Offset: 0x0001EE69
        public RotateStyleItemPanel(CRotateStyleItem item) : base(item)
        {
        }

        // Token: 0x060004C0 RID: 1216 RVA: 0x00020C74 File Offset: 0x0001EE74
        protected override void SetStyleToForm(object style)
        {
            var crotateStyleItem = (CRotateStyleItem)style;
            InitializeComponent();
            Text = crotateStyleItem.GetDisplayName();
            var rotate = crotateStyleItem.Rotate;
            if (rotate != 90)
            {
                if (rotate != 180)
                {
                    if (rotate != 270)
                    {
                        rdoNone.Checked = true;
                    }
                    else
                    {
                        rdoLeft90.Checked = true;
                    }
                }
                else
                {
                    rdo180.Checked = true;
                }
            }
            else
            {
                rdoRight90.Checked = true;
            }
            chkVertical.Checked = crotateStyleItem.VerticalReflection;
            chkHorizon.Checked = crotateStyleItem.HorizonReflection;
            imgBackground = new Bitmap(picPreview.Width, picPreview.Height, PixelFormat.Format24bppRgb);
            using (var graphics = Graphics.FromImage(imgBackground))
            {
                graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), imgBackground.Size);
            }
            imgScrap = (System.Drawing.Image)SETUNA.Resources.Image.SampleImage.Clone();
            RotateSample();
        }

        // Token: 0x060004C1 RID: 1217 RVA: 0x00020D98 File Offset: 0x0001EF98
        protected override object GetStyleFromForm()
        {
            var crotateStyleItem = new CRotateStyleItem();
            if (rdoRight90.Checked)
            {
                crotateStyleItem.Rotate = 90;
            }
            else if (rdo180.Checked)
            {
                crotateStyleItem.Rotate = 180;
            }
            else if (rdoLeft90.Checked)
            {
                crotateStyleItem.Rotate = 270;
            }
            else
            {
                crotateStyleItem.Rotate = 0;
            }
            crotateStyleItem.VerticalReflection = chkVertical.Checked;
            crotateStyleItem.HorizonReflection = chkHorizon.Checked;
            return crotateStyleItem;
        }

        // Token: 0x060004C2 RID: 1218 RVA: 0x00020E20 File Offset: 0x0001F020
        private void RotateStyleItemPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imgBackground != null)
            {
                imgBackground.Dispose();
                imgBackground = null;
                imgScrap.Dispose();
                imgScrap = null;
                GC.Collect();
            }
        }

        // Token: 0x060004C3 RID: 1219 RVA: 0x00020E54 File Offset: 0x0001F054
        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            if (imgBackground != null)
            {
                e.Graphics.DrawImageUnscaled(imgBackground, new Point(0, 0));
            }
            if (imgScrap != null)
            {
                e.Graphics.DrawImage(imgScrap, new Rectangle((imgBackground.Width - imgScrap.Width) / 2, (imgBackground.Height - imgScrap.Height) / 2, imgScrap.Width, imgScrap.Height), new Rectangle(0, 0, imgScrap.Width, imgScrap.Height), GraphicsUnit.Pixel);
            }
        }

        // Token: 0x060004C4 RID: 1220 RVA: 0x00020F08 File Offset: 0x0001F108
        private void RotateSample()
        {
            if (imgScrap != null)
            {
                imgScrap.Dispose();
            }
            imgScrap = (System.Drawing.Image)SETUNA.Resources.Image.SampleImage.Clone();
            if (rdoRight90.Checked)
            {
                imgScrap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            if (rdo180.Checked)
            {
                imgScrap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            if (rdoLeft90.Checked)
            {
                imgScrap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            if (chkHorizon.Checked)
            {
                imgScrap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            if (chkVertical.Checked)
            {
                imgScrap.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            picPreview.Refresh();
        }

        // Token: 0x060004C5 RID: 1221 RVA: 0x00020FC5 File Offset: 0x0001F1C5
        private void rdoNone_CheckedChanged(object sender, EventArgs e)
        {
            RotateSample();
        }

        // Token: 0x040002F9 RID: 761
        private System.Drawing.Image imgBackground;

        // Token: 0x040002FA RID: 762
        private System.Drawing.Image imgScrap;
    }
}
