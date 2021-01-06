namespace SETUNA.Main
{
    // Token: 0x02000042 RID: 66
    public partial class ContextStyleMenuStrip : global::System.Windows.Forms.ContextMenuStrip
    {
        // Token: 0x0600026D RID: 621 RVA: 0x0000D1F3 File Offset: 0x0000B3F3
        public ContextStyleMenuStrip()
        {
            InitializeComponent();
        }

        // Token: 0x0600026E RID: 622 RVA: 0x0000D1FB File Offset: 0x0000B3FB
        public ContextStyleMenuStrip(global::System.ComponentModel.IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        // Token: 0x17000068 RID: 104
        // (get) Token: 0x06000270 RID: 624 RVA: 0x0000D20D File Offset: 0x0000B40D
        // (set) Token: 0x0600026F RID: 623 RVA: 0x0000D204 File Offset: 0x0000B404
        public ScrapBase Scrap
        {
            get => _scrap;
            set => _scrap = value;
        }

        // Token: 0x04000111 RID: 273
        private ScrapBase _scrap;

        private void ContextStyleMenuStrip_Opened(object sender, System.EventArgs e)
        {
            Layer.LayerManager.Instance.SuspendRefresh();
        }

        private void ContextStyleMenuStrip_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
        {
            Layer.LayerManager.Instance.ResumeRefresh();
        }
    }
}
