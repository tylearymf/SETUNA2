using System.Windows.Forms;

namespace com.clearunit
{
    // Token: 0x0200007E RID: 126
    internal class WithoutTabControl : TabControl
    {
        // Token: 0x06000423 RID: 1059 RVA: 0x0001A759 File Offset: 0x00018959
        public WithoutTabControl()
        {
            base.Appearance = TabAppearance.Buttons;
            base.SizeMode = TabSizeMode.Fixed;
        }

        // Token: 0x06000424 RID: 1060 RVA: 0x0001A770 File Offset: 0x00018970
        protected override void InitLayout()
        {
            base.InitLayout();
            if (!base.DesignMode)
            {
                var itemSize = base.ItemSize;
                itemSize.Width = 0;
                itemSize.Height = 1;
                base.ItemSize = itemSize;
            }
        }
    }
}
