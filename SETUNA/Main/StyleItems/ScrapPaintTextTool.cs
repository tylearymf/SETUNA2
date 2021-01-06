using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000099 RID: 153
    public partial class ScrapPaintTextTool : BaseForm
    {
        // Token: 0x06000509 RID: 1289 RVA: 0x00023964 File Offset: 0x00021B64
        public ScrapPaintTextTool(TextTool textTool)
        {
            InitializeComponent();
            pnlEditing.Visible = false;
            _texttool = textTool;
            _edit = null;
            _texttool.Editing += _texttool_Editing;
            _texttool.ChangedFont += SetFont;
        }

        // Token: 0x0600050A RID: 1290 RVA: 0x000239C5 File Offset: 0x00021BC5
        private void _texttool_Editing(bool value, TextBox edit)
        {
            pnlEditing.Visible = value;
            _edit = edit;
        }

        // Token: 0x0600050B RID: 1291 RVA: 0x000239DC File Offset: 0x00021BDC
        private void ScrapPaintTextTool_Shown(object sender, EventArgs e)
        {
            var installedFontCollection = new InstalledFontCollection();
            foreach (var fontFamily in installedFontCollection.Families)
            {
                cmbFont.Items.Add(fontFamily.Name);
            }
        }

        // Token: 0x0600050C RID: 1292 RVA: 0x00023A1F File Offset: 0x00021C1F
        private void ScrapPaintTextTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        // Token: 0x0600050D RID: 1293 RVA: 0x00023A31 File Offset: 0x00021C31
        private void btnEditOK_Click(object sender, EventArgs e)
        {
            _texttool.EditEnd();
        }

        // Token: 0x0600050E RID: 1294 RVA: 0x00023A40 File Offset: 0x00021C40
        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pnlEditing.Visible)
            {
                return;
            }
            if (_edit != null)
            {
                _edit.Font = new Font((string)cmbFont.SelectedItem, _edit.Font.Size);
            }
        }

        // Token: 0x0600050F RID: 1295 RVA: 0x00023A93 File Offset: 0x00021C93
        public void SetFont(Font font)
        {
            cmbFont.SelectedItem = font.Name;
            numFontSize.Value = (decimal)font.Size;
            _texttool.ReloadCommand();
        }

        // Token: 0x04000334 RID: 820
        private TextTool _texttool;

        // Token: 0x04000335 RID: 821
        private TextBox _edit;
    }
}
