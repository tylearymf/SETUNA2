namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Runtime.CompilerServices;

    public class AddLayerCommand : LayerCommand
    {
        private int _insertIndex;

        public event AddLayerCommandDelegate AddLayer;

        public AddLayerCommand(string layerName, int insertIndex) : base(layerName)
        {
            base.LayerID = DateTime.Now.ToBinary();
            this._insertIndex = insertIndex;
        }

        public override void Apply()
        {
            if (this.AddLayer != null)
            {
                this.AddLayer(this);
            }
        }

        public virtual ScrapPaintLayerItem CreateLayer(int width, int height) => 
            new ScrapPaintLayerItem(base.LayerID, width, height);

        public int InsertIndex =>
            this._insertIndex;

        public bool IsEvent =>
            (this.AddLayer != null);

        public delegate void AddLayerCommandDelegate(AddLayerCommand sender);
    }
}

