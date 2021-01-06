using System.Windows.Forms;

namespace SETUNA.Main.Style
{
    // Token: 0x02000049 RID: 73
    public class CDustScrapStyle : CPreStyle
    {
        // Token: 0x060002BE RID: 702 RVA: 0x0000F520 File Offset: 0x0000D720
        public CDustScrapStyle()
        {
            _styleid = -12;
            _stylename = "关闭所有截图";
        }

        // Token: 0x060002BF RID: 703 RVA: 0x0000F53B File Offset: 0x0000D73B
        public override void Apply(ref ScrapBase scrap)
        {
            Layer.LayerManager.Instance.SuspendRefresh();
            var result = MessageBox.Show(Mainform.Instance, "是否关闭所有截图", "提示", MessageBoxButtons.YesNo);
            Layer.LayerManager.Instance.ResumeRefresh();

            if (result == DialogResult.Yes)
            {
                scrap.Manager.CloseAllScrap();
            }
        }
    }
}
