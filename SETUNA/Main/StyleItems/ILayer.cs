namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000014 RID: 20
    public interface ILayer
    {
        // Token: 0x060000E4 RID: 228
        void AddCommand(ToolCommand addCmd);

        // Token: 0x060000E5 RID: 229
        void RefreshLayer();

        // Token: 0x060000E6 RID: 230
        void RemoveCommand(ToolCommand removeCmd);
    }
}
