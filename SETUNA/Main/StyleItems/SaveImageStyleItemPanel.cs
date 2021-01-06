using System;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x020000B2 RID: 178
    internal partial class SaveImageStyleItemPanel : ToolBoxForm
    {
        // Token: 0x06000599 RID: 1433 RVA: 0x00026ED3 File Offset: 0x000250D3
        public SaveImageStyleItemPanel()
        {
        }

        // Token: 0x0600059A RID: 1434 RVA: 0x00026EDB File Offset: 0x000250DB
        public SaveImageStyleItemPanel(CCopyStyleItem item) : base(item)
        {
        }

        // Token: 0x0600059B RID: 1435 RVA: 0x00026EE4 File Offset: 0x000250E4
        protected override void SetStyleToForm(object style)
        {
            var ccopyStyleItem = (CCopyStyleItem)style;
            InitializeComponent();
            Text = ccopyStyleItem.GetDisplayName();
        }

        // Token: 0x0600059C RID: 1436 RVA: 0x00026F0C File Offset: 0x0002510C
        protected override object GetStyleFromForm()
        {
            return new CCopyStyleItem();
        }

        // Token: 0x0600059D RID: 1437 RVA: 0x00026F20 File Offset: 0x00025120
        private void barJpegQuality_Scroll(object sender, EventArgs e)
        {
        }
    }
}
