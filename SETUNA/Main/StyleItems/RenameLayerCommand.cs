namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Runtime.CompilerServices;

    public class RenameLayerCommand : LayerCommand
    {
        public event RenameLayerCommandDelegate RenameLayer;

        public RenameLayerCommand(long layerID, string layerName) : base(layerName)
        {
            base.LayerID = layerID;
        }

        public override void Apply()
        {
            if (this.RenameLayer != null)
            {
                this.RenameLayer(this);
            }
        }

        public delegate void RenameLayerCommandDelegate(RenameLayerCommand sender);
    }
}

