namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200001E RID: 30
    public class RenameLayerCommand : LayerCommand
    {
        // Token: 0x1400000E RID: 14
        // (add) Token: 0x06000150 RID: 336 RVA: 0x000082BD File Offset: 0x000064BD
        // (remove) Token: 0x06000151 RID: 337 RVA: 0x000082D6 File Offset: 0x000064D6
        public event RenameLayerCommand.RenameLayerCommandDelegate RenameLayer;

        // Token: 0x06000152 RID: 338 RVA: 0x000082EF File Offset: 0x000064EF
        public RenameLayerCommand(long layerID, string layerName) : base(layerName)
        {
            base.LayerID = layerID;
        }

        // Token: 0x06000153 RID: 339 RVA: 0x000082FF File Offset: 0x000064FF
        public override void Apply()
        {
            if (RenameLayer != null)
            {
                RenameLayer(this);
            }
        }

        // Token: 0x0200001F RID: 31
        // (Invoke) Token: 0x06000155 RID: 341
        public delegate void RenameLayerCommandDelegate(RenameLayerCommand sender);
    }
}
