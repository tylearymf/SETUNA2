using System;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000079 RID: 121
    public partial class LoginInput : BaseForm
    {
        // Token: 0x1700009D RID: 157
        // (get) Token: 0x060003EF RID: 1007 RVA: 0x00018ADA File Offset: 0x00016CDA
        // (set) Token: 0x060003EE RID: 1006 RVA: 0x00018ACC File Offset: 0x00016CCC
        public string ID
        {
            get => txtID.Text;
            set => txtID.Text = value;
        }

        // Token: 0x1700009E RID: 158
        // (get) Token: 0x060003F1 RID: 1009 RVA: 0x00018AF5 File Offset: 0x00016CF5
        // (set) Token: 0x060003F0 RID: 1008 RVA: 0x00018AE7 File Offset: 0x00016CE7
        public string Pass
        {
            get => txtPass.Text;
            set => txtPass.Text = value;
        }

        // Token: 0x1700009F RID: 159
        // (set) Token: 0x060003F2 RID: 1010 RVA: 0x00018B02 File Offset: 0x00016D02
        public string GroupTitle
        {
            set => groupBox1.Text = value;
        }

        // Token: 0x060003F3 RID: 1011 RVA: 0x00018B10 File Offset: 0x00016D10
        public LoginInput()
        {
            InitializeComponent();
        }

        // Token: 0x060003F4 RID: 1012 RVA: 0x00018B20 File Offset: 0x00016D20
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtID.TextLength == 0)
            {
                txtID.Focus();
                return;
            }
            if (txtPass.TextLength == 0)
            {
                txtPass.Focus();
                return;
            }
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        // Token: 0x060003F5 RID: 1013 RVA: 0x00018B6E File Offset: 0x00016D6E
        private void LoginInput_Shown(object sender, EventArgs e)
        {
            if (txtID.TextLength > 0)
            {
                txtPass.Focus();
                return;
            }
            txtID.Focus();
        }
    }
}
