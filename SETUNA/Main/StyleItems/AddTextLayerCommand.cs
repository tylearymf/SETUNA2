namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200009E RID: 158
    public class AddTextLayerCommand : AddLayerCommand, ILayer
    {
        // Token: 0x0600052D RID: 1325 RVA: 0x000245DC File Offset: 0x000227DC
        public AddTextLayerCommand(string layerName, int insertIndex) : base(layerName, insertIndex)
        {
            childs = null;
        }

        // Token: 0x0600052E RID: 1326 RVA: 0x000245ED File Offset: 0x000227ED
        public override ScrapPaintLayerItem CreateLayer(int width, int height)
        {
            return new ScrapPaintTextLayerItem(base.LayerID, width, height);
        }

        // Token: 0x0600052F RID: 1327 RVA: 0x000245FC File Offset: 0x000227FC
        public void AddCommand(ToolCommand addCmd)
        {
            childs = addCmd;
        }

        // Token: 0x06000530 RID: 1328 RVA: 0x00024605 File Offset: 0x00022805
        public void RefreshLayer()
        {
        }

        // Token: 0x06000531 RID: 1329 RVA: 0x00024607 File Offset: 0x00022807
        public void RemoveCommand(ToolCommand removeCmd)
        {
            if (Parent != null)
            {
                Parent.RemoveCommand(this);
            }
        }

        // Token: 0x0400034B RID: 843
        private ToolCommand childs;
    }
}
