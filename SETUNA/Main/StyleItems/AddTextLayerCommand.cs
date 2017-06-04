namespace SETUNA.Main.StyleItems
{
    using System;

    public class AddTextLayerCommand : AddLayerCommand, ILayer
    {
        private ToolCommand childs;

        public AddTextLayerCommand(string layerName, int insertIndex) : base(layerName, insertIndex)
        {
            this.childs = null;
        }

        public void AddCommand(ToolCommand addCmd)
        {
            this.childs = addCmd;
        }

        public override ScrapPaintLayerItem CreateLayer(int width, int height) => 
            new ScrapPaintTextLayerItem(base.LayerID, width, height);

        public void RefreshLayer()
        {
        }

        public void RemoveCommand(ToolCommand removeCmd)
        {
            if (base.Parent != null)
            {
                base.Parent.RemoveCommand(this);
            }
        }
    }
}

