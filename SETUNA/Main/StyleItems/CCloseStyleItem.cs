using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x02000063 RID: 99
    public class CCloseStyleItem : CStyleItem
    {
        // Token: 0x06000380 RID: 896 RVA: 0x0001600D File Offset: 0x0001420D
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            scrap.Close();
        }

        // Token: 0x06000381 RID: 897 RVA: 0x00016016 File Offset: 0x00014216
        public override string GetName()
        {
            return "Close";
        }

        // Token: 0x06000382 RID: 898 RVA: 0x0001601D File Offset: 0x0001421D
        public override string GetDisplayName()
        {
            return "关闭";
        }

        // Token: 0x06000383 RID: 899 RVA: 0x00016024 File Offset: 0x00014224
        public override string GetDescription()
        {
            return "关闭参考图。\n之后的自动操作将不被使用。";
        }

        // Token: 0x06000384 RID: 900 RVA: 0x0001602B File Offset: 0x0001422B
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new NothingStyleItemPanel(this);
        }

        // Token: 0x06000385 RID: 901 RVA: 0x00016033 File Offset: 0x00014233
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
        }

        // Token: 0x17000088 RID: 136
        // (get) Token: 0x06000386 RID: 902 RVA: 0x00016035 File Offset: 0x00014235
        public override bool IsTerminate => true;

        // Token: 0x06000387 RID: 903 RVA: 0x00016038 File Offset: 0x00014238
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Close;
        }
    }
}
