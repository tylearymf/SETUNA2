namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Drawing;

    public abstract class LayerCommand : ToolCommand
    {
        private long _layerID;
        private string _layerName;

        public LayerCommand(string layerName)
        {
            this._layerName = layerName;
        }

        public abstract void Apply();
        public override void Draw(Graphics g)
        {
        }

        public long LayerID
        {
            get{return  
                this._layerID;}
            protected set
            {
                this._layerID = value;
            }
        }

        public string LayerName =>
            this._layerName;
    }
}

