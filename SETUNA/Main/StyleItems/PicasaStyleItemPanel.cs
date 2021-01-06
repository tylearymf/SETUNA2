using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000093 RID: 147
    internal partial class PicasaStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060004DD RID: 1245 RVA: 0x00023130 File Offset: 0x00021330
        public PicasaStyleItemPanel()
        {
        }

        // Token: 0x060004DE RID: 1246 RVA: 0x00023138 File Offset: 0x00021338
        public PicasaStyleItemPanel(CPicasaUploaderStyleItem item) : base(item)
        {
        }

        // Token: 0x060004DF RID: 1247 RVA: 0x00023144 File Offset: 0x00021344
        protected override void SetStyleToForm(object style)
        {
            var cpicasaUploaderStyleItem = (CPicasaUploaderStyleItem)style;
            InitializeComponent();
            Text = cpicasaUploaderStyleItem.GetDisplayName();
            string text2;
            var text = text2 = "";
            if (cpicasaUploaderStyleItem.ID.Length > 0)
            {
                text2 = PicasaBar.Decrypto(cpicasaUploaderStyleItem.ID);
            }
            if (cpicasaUploaderStyleItem.Pass.Length > 0)
            {
                text = PicasaBar.Decrypto(cpicasaUploaderStyleItem.Pass);
            }
            txtID.Text = text2;
            txtPass.Text = text;
            comboBox1.SelectedIndex = cpicasaUploaderStyleItem.Manage;
        }

        // Token: 0x060004E0 RID: 1248 RVA: 0x000231CC File Offset: 0x000213CC
        protected override void OKCheck(ref bool cancel)
        {
            base.OKCheck(ref cancel);
            if (comboBox1.SelectedIndex == 0 && (txtID.TextLength == 0 || txtPass.TextLength == 0))
            {
                cancel = true;
                MessageBox.Show("请输入帐号和密码。");
                return;
            }
            if (comboBox1.SelectedIndex == 0 && txtID.TextLength == 0)
            {
                cancel = true;
                MessageBox.Show("请输入帐号。");
            }
        }

        // Token: 0x060004E1 RID: 1249 RVA: 0x00023240 File Offset: 0x00021440
        protected override object GetStyleFromForm()
        {
            var cpicasaUploaderStyleItem = new CPicasaUploaderStyleItem();
            if (comboBox1.SelectedIndex == 1)
            {
                txtPass.Text = "";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                txtID.Text = "";
                txtPass.Text = "";
            }
            cpicasaUploaderStyleItem.ID = PicasaBar.Encrypto(txtID.Text);
            cpicasaUploaderStyleItem.Pass = PicasaBar.Encrypto(txtPass.Text);
            cpicasaUploaderStyleItem.Manage = (byte)comboBox1.SelectedIndex;
            return cpicasaUploaderStyleItem;
        }

        // Token: 0x060004E2 RID: 1250 RVA: 0x000232E0 File Offset: 0x000214E0
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    txtID.Enabled = true;
                    txtPass.Enabled = true;
                    return;
                case 1:
                    txtID.Enabled = true;
                    txtPass.Enabled = false;
                    return;
                case 2:
                    txtID.Enabled = false;
                    txtPass.Enabled = false;
                    return;
                default:
                    return;
            }
        }

        // Token: 0x060004E3 RID: 1251 RVA: 0x00023356 File Offset: 0x00021556
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Text);
        }

        // Token: 0x060004E4 RID: 1252 RVA: 0x00023369 File Offset: 0x00021569
        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(linkLabel1.Text);
        }
    }
}
