using System.ComponentModel;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000028 RID: 40
    public partial class LayerRenameWindow : BaseForm
    {
        // Token: 0x1700004B RID: 75
        // (get) Token: 0x0600019C RID: 412 RVA: 0x000095CA File Offset: 0x000077CA
        // (set) Token: 0x0600019B RID: 411 RVA: 0x000095BC File Offset: 0x000077BC
        public string LayerName
        {
            get => txtLayerName.Text;
            set => txtLayerName.Text = value;
        }

        // Token: 0x0600019D RID: 413 RVA: 0x000095D7 File Offset: 0x000077D7
        public LayerRenameWindow()
        {
            InitializeComponent();
        }

        // Token: 0x0600019E RID: 414 RVA: 0x000095E5 File Offset: 0x000077E5
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (txtLayerName.TextLength == 0)
            {
                errorProvider1.SetIconAlignment(txtLayerName, ErrorIconAlignment.TopLeft);
                errorProvider1.SetError(txtLayerName, "没有输入图层名");
            }
        }
    }
}
