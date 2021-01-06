using System;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200001B RID: 27
    public class AddLayerCommand : LayerCommand
    {
        // Token: 0x1400000D RID: 13
        // (add) Token: 0x06000141 RID: 321 RVA: 0x00008220 File Offset: 0x00006420
        // (remove) Token: 0x06000142 RID: 322 RVA: 0x00008239 File Offset: 0x00006439
        public event AddLayerCommand.AddLayerCommandDelegate AddLayer;

        // Token: 0x17000044 RID: 68
        // (get) Token: 0x06000143 RID: 323 RVA: 0x00008252 File Offset: 0x00006452
        public int InsertIndex => _insertIndex;

        // Token: 0x06000144 RID: 324 RVA: 0x0000825C File Offset: 0x0000645C
        public AddLayerCommand(string layerName, int insertIndex) : base(layerName)
        {
            base.LayerID = DateTime.Now.ToBinary();
            _insertIndex = insertIndex;
        }

        // Token: 0x06000145 RID: 325 RVA: 0x0000828A File Offset: 0x0000648A
        public override void Apply()
        {
            if (AddLayer != null)
            {
                AddLayer(this);
            }
        }

        // Token: 0x17000045 RID: 69
        // (get) Token: 0x06000146 RID: 326 RVA: 0x000082A0 File Offset: 0x000064A0
        public bool IsEvent => AddLayer != null;

        // Token: 0x06000147 RID: 327 RVA: 0x000082AE File Offset: 0x000064AE
        public virtual ScrapPaintLayerItem CreateLayer(int width, int height)
        {
            return new ScrapPaintLayerItem(base.LayerID, width, height);
        }

        // Token: 0x0400009C RID: 156
        private int _insertIndex;

        // Token: 0x0200001C RID: 28
        // (Invoke) Token: 0x06000149 RID: 329
        public delegate void AddLayerCommandDelegate(AddLayerCommand sender);
    }
}
