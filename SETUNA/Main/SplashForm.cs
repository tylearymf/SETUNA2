using System;
using System.Windows.Forms;

namespace SETUNA.Main
{
    // Token: 0x02000043 RID: 67
    public partial class SplashForm : BaseForm
    {
        // Token: 0x06000273 RID: 627 RVA: 0x0000D537 File Offset: 0x0000B737
        public SplashForm()
        {
            InitializeComponent();

            lblVer.Text = base.ProductName + " " + Application.ProductVersion;
            label1.Text = URLUtils.NewURL;
        }

        // Token: 0x06000274 RID: 628 RVA: 0x0000D565 File Offset: 0x0000B765
        private void SplashForm_Load(object sender, EventArgs e)
        {
        }

        // Token: 0x06000275 RID: 629 RVA: 0x0000D567 File Offset: 0x0000B767
        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            base.Close();
        }

        // Token: 0x06000276 RID: 630 RVA: 0x0000D56F File Offset: 0x0000B76F
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SplashTimer.Enabled = false;
            base.Close();
        }
    }
}
