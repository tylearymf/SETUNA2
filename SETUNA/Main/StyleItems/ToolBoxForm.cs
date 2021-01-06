using System;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000002 RID: 2
    public partial class ToolBoxForm : BaseForm
    {
        // Token: 0x06000003 RID: 3 RVA: 0x00002285 File Offset: 0x00000485
        public ToolBoxForm()
        {
            InitializeComponent();
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002293 File Offset: 0x00000493
        public ToolBoxForm(object style)
        {
            InitializeComponent();
            SetStyleToForm(style);
        }

        // Token: 0x06000005 RID: 5 RVA: 0x000022A8 File Offset: 0x000004A8
        private void cmdOK_Click(object sender, EventArgs e)
        {
            var flag = false;
            OKCheck(ref flag);
            if (flag)
            {
                return;
            }
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        // Token: 0x06000006 RID: 6 RVA: 0x000022D0 File Offset: 0x000004D0
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000007 RID: 7 RVA: 0x000022DF File Offset: 0x000004DF
        public object StyleItem => GetStyleFromForm();

        // Token: 0x06000008 RID: 8 RVA: 0x000022E7 File Offset: 0x000004E7
        protected virtual void SetStyleToForm(object style)
        {
            throw new Exception("SetStyleToForm未实现");
        }

        // Token: 0x06000009 RID: 9 RVA: 0x000022F3 File Offset: 0x000004F3
        protected virtual object GetStyleFromForm()
        {
            throw new Exception("GetStyleFromForm未实现");
        }

        // Token: 0x0600000A RID: 10 RVA: 0x000022FF File Offset: 0x000004FF
        protected virtual void OKCheck(ref bool cancel)
        {
        }
    }
}
