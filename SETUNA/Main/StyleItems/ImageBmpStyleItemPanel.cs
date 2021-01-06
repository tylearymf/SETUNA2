using System;
using System.IO;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200008A RID: 138
    internal partial class ImageBmpStyleItemPanel : ToolBoxForm
    {
        // Token: 0x0600047A RID: 1146 RVA: 0x0001D515 File Offset: 0x0001B715
        public ImageBmpStyleItemPanel()
        {
        }

        // Token: 0x0600047B RID: 1147 RVA: 0x0001D51D File Offset: 0x0001B71D
        public ImageBmpStyleItemPanel(CImageBmpStyleItem item) : base(item)
        {
        }

        // Token: 0x0600047C RID: 1148 RVA: 0x0001D528 File Offset: 0x0001B728
        protected override void SetStyleToForm(object style)
        {
            var cimageBmpStyleItem = (CImageBmpStyleItem)style;
            InitializeComponent();
            Text = cimageBmpStyleItem.GetDisplayName();
            txtFolder.Text = cimageBmpStyleItem.SaveFolder;
            chkWindow.Checked = cimageBmpStyleItem.HaveMargin;
            chkCopy.Checked = cimageBmpStyleItem.CopyPath;
            switch (cimageBmpStyleItem.FileNameType)
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
            cmbDupli.SelectedIndex = (int)cimageBmpStyleItem.DupliType;
            txtName.Text = cimageBmpStyleItem.FileName;
        }

        // Token: 0x0600047D RID: 1149 RVA: 0x0001D5E8 File Offset: 0x0001B7E8
        protected override object GetStyleFromForm()
        {
            var cimageBmpStyleItem = new CImageBmpStyleItem
            {
                SaveFolder = txtFolder.Text,
                HaveMargin = chkWindow.Checked,
                CopyPath = chkCopy.Checked
            };
            if (rdoSaveAs.Checked)
            {
                cimageBmpStyleItem.FileNameType = CImageStyleItem.EnumFileName.SaveAs;
            }
            else if (rdoScrapName.Checked)
            {
                cimageBmpStyleItem.FileNameType = CImageStyleItem.EnumFileName.ScrapName;
            }
            else
            {
                cimageBmpStyleItem.FileNameType = CImageStyleItem.EnumFileName.UseName;
            }
            cimageBmpStyleItem.DupliType = (CImageStyleItem.EnumDupliType)cmbDupli.SelectedIndex;
            cimageBmpStyleItem.FileName = txtName.Text;
            return cimageBmpStyleItem;
        }

        // Token: 0x0600047E RID: 1150 RVA: 0x0001D684 File Offset: 0x0001B884
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

        // Token: 0x0600047F RID: 1151 RVA: 0x0001D6E0 File Offset: 0x0001B8E0
        private void btnRef_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.SelectedPath = txtFolder.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        // Token: 0x06000480 RID: 1152 RVA: 0x0001D734 File Offset: 0x0001B934
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
