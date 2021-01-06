using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000019 RID: 25
    public abstract class LayerCommand : ToolCommand
    {
        // Token: 0x17000042 RID: 66
        // (get) Token: 0x06000137 RID: 311 RVA: 0x000081F6 File Offset: 0x000063F6
        public string LayerName => _layerName;

        // Token: 0x17000043 RID: 67
        // (get) Token: 0x06000139 RID: 313 RVA: 0x00008207 File Offset: 0x00006407
        // (set) Token: 0x06000138 RID: 312 RVA: 0x000081FE File Offset: 0x000063FE
        public long LayerID
        {
            get => _layerID;
            protected set => _layerID = value;
        }

        // Token: 0x0600013A RID: 314 RVA: 0x0000820F File Offset: 0x0000640F
        public LayerCommand(string layerName)
        {
            _layerName = layerName;
        }

        // Token: 0x0600013B RID: 315 RVA: 0x0000821E File Offset: 0x0000641E
        public override void Draw(Graphics g)
        {
        }

        // Token: 0x0600013C RID: 316
        public abstract void Apply();

        // Token: 0x04000099 RID: 153
        private string _layerName;

        // Token: 0x0400009A RID: 154
        private long _layerID;
    }
}
