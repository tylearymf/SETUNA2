namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000020 RID: 32
    public class DeleteLayerCommand : LayerCommand
    {
        // Token: 0x1400000F RID: 15
        // (add) Token: 0x06000158 RID: 344 RVA: 0x00008315 File Offset: 0x00006515
        // (remove) Token: 0x06000159 RID: 345 RVA: 0x0000832E File Offset: 0x0000652E
        public event DeleteLayerCommand.DeleteLayerCommandDelegate DeleteLayer;

        // Token: 0x0600015A RID: 346 RVA: 0x00008347 File Offset: 0x00006547
        public DeleteLayerCommand(long layerID) : base("")
        {
            base.LayerID = layerID;
        }

        // Token: 0x0600015B RID: 347 RVA: 0x0000835B File Offset: 0x0000655B
        public override void Apply()
        {
            if (DeleteLayer != null)
            {
                DeleteLayer(this);
            }
        }

        // Token: 0x02000021 RID: 33
        // (Invoke) Token: 0x0600015D RID: 349
        public delegate void DeleteLayerCommandDelegate(DeleteLayerCommand sender);
    }
}
