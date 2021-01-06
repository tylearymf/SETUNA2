namespace SETUNA.Main
{
    // Token: 0x02000030 RID: 48
    public interface IScrapStyleListener
    {
        // Token: 0x060001D2 RID: 466
        void ScrapCreated(object sender, ScrapEventArgs e);

        // Token: 0x060001D3 RID: 467
        void ScrapInactived(object sender, ScrapEventArgs e);

        // Token: 0x060001D4 RID: 468
        void ScrapActivated(object sender, ScrapEventArgs e);

        // Token: 0x060001D5 RID: 469
        void ScrapInactiveMouseOver(object sender, ScrapEventArgs e);

        // Token: 0x060001D6 RID: 470
        void ScrapInactiveMouseOut(object sender, ScrapEventArgs e);
    }
}
