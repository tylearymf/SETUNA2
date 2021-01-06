using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x020000A6 RID: 166
    public partial class ScrapPaintPenTool : BaseForm
    {
        // Token: 0x0600055D RID: 1373 RVA: 0x0002577C File Offset: 0x0002397C
        public ScrapPaintPenTool(PenTool penTool)
        {
            InitializeComponent();
            penButtons = new List<PenButton>
            {
                penButton1,
                penButton2,
                penButton3,
                penButton4,
                penButton5
            };
            foreach (var obj in Enum.GetValues(typeof(LineCap)))
            {
                var lineCap = (LineCap)obj;
                cmbStart.Items.Add(lineCap);
            }
            cmbStart.SelectedItem = LineCap.NoAnchor;
            _pentool = penTool;
            penButton1_Click(penButton2, null);
        }

        // Token: 0x0600055E RID: 1374 RVA: 0x00025880 File Offset: 0x00023A80
        public ScrapPaintPenTool(PenTool penTool, bool erasemode) : this(penTool)
        {
            if (erasemode)
            {
                Text = "橡皮擦工具";
                pnlOpacity.Visible = false;
                pnlCap.Visible = false;
                foreach (var penButton in penButtons)
                {
                    penButton.ButtonColor = Color.FromArgb(95, 168, 239);
                }
            }
        }

        // Token: 0x0600055F RID: 1375 RVA: 0x00025910 File Offset: 0x00023B10
        private void numOpacity_ValueChanged(object sender, EventArgs e)
        {
            var opacity = 255 * (int)numOpacity.Value / 100;
            _pentool.Opacity = opacity;
            _pentool.ReloadCommand();
        }

        // Token: 0x06000560 RID: 1376 RVA: 0x00025950 File Offset: 0x00023B50
        private void penButton1_Click(object sender, EventArgs e)
        {
            var penButton = (PenButton)sender;
            numPenSize.Value = penButton.PenSize;
        }

        // Token: 0x06000561 RID: 1377 RVA: 0x0002597C File Offset: 0x00023B7C
        private void numPenSize_ValueChanged(object sender, EventArgs e)
        {
            _pentool.PenWidth = (float)numPenSize.Value;
            _pentool.ReloadCommand();
            foreach (var penButton in penButtons)
            {
                if (penButton.PenSize == (int)numPenSize.Value)
                {
                    penButton.Checked = true;
                }
                else
                {
                    penButton.Checked = false;
                }
            }
        }

        // Token: 0x06000562 RID: 1378 RVA: 0x00025A18 File Offset: 0x00023C18
        private void ScrapPaintPenTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        // Token: 0x04000369 RID: 873
        private PenTool _pentool;

        // Token: 0x0400036A RID: 874
        private List<PenButton> penButtons;
    }
}
