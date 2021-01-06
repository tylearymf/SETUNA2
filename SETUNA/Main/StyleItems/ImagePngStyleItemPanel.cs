using System;
using System.IO;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200000F RID: 15
    internal partial class ImagePngStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060000CF RID: 207 RVA: 0x00006329 File Offset: 0x00004529
        public ImagePngStyleItemPanel()
        {
        }

        // Token: 0x060000D0 RID: 208 RVA: 0x00006331 File Offset: 0x00004531
        public ImagePngStyleItemPanel(CImagePngStyleItem item) : base(item)
        {
        }

        // Token: 0x060000D1 RID: 209 RVA: 0x0000633C File Offset: 0x0000453C
        protected override void SetStyleToForm(object style)
        {
            var cimagePngStyleItem = (CImagePngStyleItem)style;
            InitializeComponent();
            Text = cimagePngStyleItem.GetDisplayName();
            txtFolder.Text = cimagePngStyleItem.SaveFolder;
            chkWindow.Checked = cimagePngStyleItem.HaveMargin;
            chkCopy.Checked = cimagePngStyleItem.CopyPath;
            switch (cimagePngStyleItem.FileNameType)
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
            cmbDupli.SelectedIndex = (int)cimagePngStyleItem.DupliType;
            txtName.Text = cimagePngStyleItem.FileName;
        }

        // Token: 0x060000D2 RID: 210 RVA: 0x000063FC File Offset: 0x000045FC
        protected override object GetStyleFromForm()
        {
            var cimagePngStyleItem = new CImagePngStyleItem
            {
                SaveFolder = txtFolder.Text,
                HaveMargin = chkWindow.Checked,
                CopyPath = chkCopy.Checked
            };
            if (rdoSaveAs.Checked)
            {
                cimagePngStyleItem.FileNameType = CImageStyleItem.EnumFileName.SaveAs;
            }
            else if (rdoScrapName.Checked)
            {
                cimagePngStyleItem.FileNameType = CImageStyleItem.EnumFileName.ScrapName;
            }
            else
            {
                cimagePngStyleItem.FileNameType = CImageStyleItem.EnumFileName.UseName;
            }
            cimagePngStyleItem.DupliType = (CImageStyleItem.EnumDupliType)cmbDupli.SelectedIndex;
            cimagePngStyleItem.FileName = txtName.Text;
            return cimagePngStyleItem;
        }

        // Token: 0x060000D3 RID: 211 RVA: 0x00006498 File Offset: 0x00004698
        private void barQuality_Scroll(object sender, EventArgs e)
        {
        }

        // Token: 0x060000D4 RID: 212 RVA: 0x0000649C File Offset: 0x0000469C
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

        // Token: 0x060000D5 RID: 213 RVA: 0x000064F8 File Offset: 0x000046F8
        private void btnRef_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.SelectedPath = txtFolder.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        // Token: 0x060000D6 RID: 214 RVA: 0x0000654C File Offset: 0x0000474C
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
