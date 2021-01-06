using System;
using System.IO;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000092 RID: 146
    internal partial class ImageJpegStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060004D4 RID: 1236 RVA: 0x0002270A File Offset: 0x0002090A
        public ImageJpegStyleItemPanel()
        {
        }

        // Token: 0x060004D5 RID: 1237 RVA: 0x00022712 File Offset: 0x00020912
        public ImageJpegStyleItemPanel(CImageJpegStyleItem item) : base(item)
        {
        }

        // Token: 0x060004D6 RID: 1238 RVA: 0x0002271C File Offset: 0x0002091C
        protected override void SetStyleToForm(object style)
        {
            var cimageJpegStyleItem = (CImageJpegStyleItem)style;
            InitializeComponent();
            Text = cimageJpegStyleItem.GetDisplayName();
            txtFolder.Text = cimageJpegStyleItem.SaveFolder;
            barQuality.Value = cimageJpegStyleItem.Quality;
            chkShowParam.Checked = cimageJpegStyleItem.ShowPreview;
            chkWindow.Checked = cimageJpegStyleItem.HaveMargin;
            chkCopy.Checked = cimageJpegStyleItem.CopyPath;
            switch (cimageJpegStyleItem.FileNameType)
            {
                case CImageStyleItem.EnumFileName.SaveAs:
                    rdoSaveAs.Checked = true;
                    break;
                case CImageStyleItem.EnumFileName.ScrapName:
                    rdoScrapName.Checked = true;
                    break;
                case CImageStyleItem.EnumFileName.UseName:
                    rdoName.Checked = true;
                    break;
            }
            cmbDupli.SelectedIndex = (int)cimageJpegStyleItem.DupliType;
            txtName.Text = cimageJpegStyleItem.FileName;
        }

        // Token: 0x060004D7 RID: 1239 RVA: 0x000227FC File Offset: 0x000209FC
        protected override object GetStyleFromForm()
        {
            var cimageJpegStyleItem = new CImageJpegStyleItem
            {
                SaveFolder = txtFolder.Text,
                Quality = barQuality.Value,
                ShowPreview = chkShowParam.Checked,
                HaveMargin = chkWindow.Checked,
                CopyPath = chkCopy.Checked
            };
            if (rdoSaveAs.Checked)
            {
                cimageJpegStyleItem.FileNameType = CImageStyleItem.EnumFileName.SaveAs;
            }
            else if (rdoScrapName.Checked)
            {
                cimageJpegStyleItem.FileNameType = CImageStyleItem.EnumFileName.ScrapName;
            }
            else
            {
                cimageJpegStyleItem.FileNameType = CImageStyleItem.EnumFileName.UseName;
            }
            cimageJpegStyleItem.DupliType = (CImageStyleItem.EnumDupliType)cmbDupli.SelectedIndex;
            cimageJpegStyleItem.FileName = txtName.Text;
            return cimageJpegStyleItem;
        }

        // Token: 0x060004D8 RID: 1240 RVA: 0x000228BC File Offset: 0x00020ABC
        private void barQuality_Scroll(object sender, EventArgs e)
        {
            lblQuality.Text = barQuality.Value.ToString();
        }

        // Token: 0x060004D9 RID: 1241 RVA: 0x000228E8 File Offset: 0x00020AE8
        private void rdoSaveAs_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSaveAs.Checked)
            {
                cmbDupli.Enabled = false;
            }
            else
            {
                cmbDupli.Enabled = true;
            }
            if (rdoName.Checked)
            {
                txtName.Enabled = true;
                return;
            }
            txtName.Enabled = false;
        }

        // Token: 0x060004DA RID: 1242 RVA: 0x00022944 File Offset: 0x00020B44
        private void btnRef_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.SelectedPath = txtFolder.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        // Token: 0x060004DB RID: 1243 RVA: 0x00022998 File Offset: 0x00020B98
        protected override void OKCheck(ref bool cancel)
        {
            cancel = true;
            if (txtFolder.Text != "")
            {
                try
                {
                    Path.GetFullPath(txtFolder.Text);
                }
                catch
                {
                    MessageBox.Show("文件夹名无效。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFolder.Focus();
                    return;
                }
            }
            if (!rdoSaveAs.Checked && rdoName.Checked)
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("没有指定文件名。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Focus();
                    return;
                }
                var invalidFileNameChars = Path.GetInvalidFileNameChars();
                foreach (var value in invalidFileNameChars)
                {
                    if (txtName.Text.IndexOf(value) > -1)
                    {
                        MessageBox.Show("文件名无效。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtName.Focus();
                        return;
                    }
                }
            }
            cancel = false;
        }
    }
}
