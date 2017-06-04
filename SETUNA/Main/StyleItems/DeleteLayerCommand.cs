namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Runtime.CompilerServices;

    public class DeleteLayerCommand : LayerCommand
    {
        public event DeleteLayerCommandDelegate DeleteLayer;

        public DeleteLayerCommand(long layerID) : base("")
        {
            base.LayerID = layerID;
        }

        public override void Apply()
        {
            if (this.DeleteLayer != null)
            {
                this.DeleteLayer(this);
            }
        }

        public delegate void DeleteLayerCommandDelegate(DeleteLayerCommand sender);
    }
}

