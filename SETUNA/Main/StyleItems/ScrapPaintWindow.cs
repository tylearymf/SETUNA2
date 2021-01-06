using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000017 RID: 23
    public sealed partial class ScrapPaintWindow : ScrapDrawForm
    {
        // Token: 0x06000106 RID: 262 RVA: 0x00007664 File Offset: 0x00005864
        public ScrapPaintWindow(ScrapBase scrap) : base(scrap)
        {
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            isToolUse = false;
            activeTool = null;
            historyCommand = new List<ToolCommand>();
            toolFrm = new ScrapPaintToolBar(this);
            toolFrm.KeyUp += layerForm_KeyUp;
            toolFrm.SelectTool += toolFrm_SelectTool;
            base.AddOwnedForm(toolFrm);
            layerForm = new ScrapPaintLayer(this);
            layerForm.KeyUp += layerForm_KeyUp;
            layerForm.SelectLayer += layerForm_SelectLayer;
            layerForm.LayerRefresh += layerForm_LayerRefresh;
            base.AddOwnedForm(layerForm);
            activeLayer = layerForm.SelectionLayer;
        }

        // Token: 0x06000107 RID: 263 RVA: 0x00007759 File Offset: 0x00005959
        private void ScrapPaintWindow_Shown(object sender, EventArgs e)
        {
        }

        // Token: 0x06000108 RID: 264 RVA: 0x0000775B File Offset: 0x0000595B
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            toolFrm.SwitchTool(ScrapPaintToolBar.ToolKind.笔工具);
        }

        // Token: 0x06000109 RID: 265 RVA: 0x00007770 File Offset: 0x00005970
        private void toolFrm_SelectTool(PaintTool tool)
        {
            if (activeTool != null)
            {
                activeTool.Dispose();
                activeTool = null;
            }
            activeTool = tool;
            if (activeTool != null)
            {
                activeTool.Started += activeTool_Started;
                activeTool.Finished += activeTool_Finished;
            }
            ToolEditCheck();
        }

        // Token: 0x0600010A RID: 266 RVA: 0x000077DA File Offset: 0x000059DA
        private void layerForm_SelectLayer(ScrapPaintLayerItem layerCtrl)
        {
            activeLayer = layerCtrl;
            ToolEditCheck();
        }

        // Token: 0x0600010B RID: 267 RVA: 0x000077E9 File Offset: 0x000059E9
        private void layerForm_LayerRefresh(ScrapPaintLayerItem layerCtrl)
        {
            Refresh();
        }

        // Token: 0x0600010C RID: 268 RVA: 0x000077F1 File Offset: 0x000059F1
        private void activeTool_Started(ToolCommand command)
        {
            isToolUse = true;
        }

        // Token: 0x0600010D RID: 269 RVA: 0x000077FA File Offset: 0x000059FA
        private void activeTool_Finished(ToolCommand command)
        {
            isToolUse = false;
            historyCommand.Add(command);
            activeLayer.AddCommand(command);
        }

        // Token: 0x0600010E RID: 270 RVA: 0x0000781B File Offset: 0x00005A1B
        private void ToolEditCheck()
        {
            if (activeLayer != null)
            {
                if (activeLayer.IsEditableTool(activeTool))
                {
                    Cursor = Cursors.Cross;
                    return;
                }
                Cursor = Cursors.No;
            }
        }

        // Token: 0x0600010F RID: 271 RVA: 0x00007850 File Offset: 0x00005A50
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImageUnscaled(_scrap.Image, base.BasePoint);
            layerForm.Draw(e.Graphics);
            if (activeTool != null)
            {
                activeTool.Draw(e.Graphics);
            }
        }

        // Token: 0x06000110 RID: 272 RVA: 0x000078AC File Offset: 0x00005AAC
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            toolFrm.Top = base.Top;
            toolFrm.Left = base.Left - toolFrm.Width - 20;
            toolFrm.Show();
            layerForm.Top = base.Bottom - layerForm.Height;
            layerForm.Left = base.Right + 20;
            layerForm.Show();
        }

        // Token: 0x06000111 RID: 273 RVA: 0x00007938 File Offset: 0x00005B38
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (Cursor != Cursors.No)
            {
                if (activeTool != null)
                {
                    activeTool.MouseDown(e);
                }
                Refresh();
            }
        }

        // Token: 0x06000112 RID: 274 RVA: 0x0000796D File Offset: 0x00005B6D
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (Cursor != Cursors.No)
            {
                if (activeTool != null)
                {
                    activeTool.MouseUp(e);
                }
                Refresh();
            }
        }

        // Token: 0x06000113 RID: 275 RVA: 0x000079A2 File Offset: 0x00005BA2
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cursor != Cursors.No)
            {
                if (activeTool != null)
                {
                    activeTool.MouseMove(e);
                }
                Refresh();
            }
        }

        // Token: 0x06000114 RID: 276 RVA: 0x000079D7 File Offset: 0x00005BD7
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            KeyInput(e);
        }

        // Token: 0x06000115 RID: 277 RVA: 0x000079E7 File Offset: 0x00005BE7
        private void layerForm_KeyUp(object sender, KeyEventArgs e)
        {
            KeyInput(e);
        }

        // Token: 0x06000116 RID: 278 RVA: 0x000079F0 File Offset: 0x00005BF0
        private void KeyInput(KeyEventArgs e)
        {
            if (isToolUse && Cursor != Cursors.No)
            {
                if (activeTool != null)
                {
                    activeTool.KeyUp(e);
                }
                Refresh();
                return;
            }
            if (e.KeyCode == Keys.Z && e.Control)
            {
                UndoCommand();
                return;
            }
            if (e.KeyCode == Keys.N && e.Control)
            {
                layerForm.AddLayer();
                return;
            }
            if (e.KeyCode == Keys.B)
            {
                toolFrm.SwitchTool(ScrapPaintToolBar.ToolKind.笔工具);
                return;
            }
            if (e.KeyCode == Keys.E)
            {
                toolFrm.SwitchTool(ScrapPaintToolBar.ToolKind.消しゴム工具);
                return;
            }
            if (e.KeyCode == Keys.X && activeTool != null && !activeTool.IsActive)
            {
                toolFrm.ChangeColor();
            }
        }

        // Token: 0x06000117 RID: 279 RVA: 0x00007AC4 File Offset: 0x00005CC4
        private void UndoCommand()
        {
            if (historyCommand.Count == 0)
            {
                return;
            }
            var toolCommand = historyCommand[historyCommand.Count - 1];
            historyCommand.Remove(toolCommand);
            if (toolCommand.Parent != null)
            {
                toolCommand.Parent.RemoveCommand(toolCommand);
            }
        }

        // Token: 0x06000119 RID: 281 RVA: 0x00007B6B File Offset: 0x00005D6B
        public int SelectionLayerIndex()
        {
            return layerForm.SelectionIndex;
        }

        // Token: 0x0600011A RID: 282 RVA: 0x00007B78 File Offset: 0x00005D78
        public void AddLayerCommand(AddLayerCommand addCmd)
        {
            if (layerForm != null)
            {
                historyCommand.Add(addCmd);
                if (!addCmd.IsEvent)
                {
                    addCmd.AddLayer += layerForm.addCmd_AddLayer;
                }
                layerForm.AddCommand(addCmd);
            }
        }

        // Token: 0x0600011B RID: 283 RVA: 0x00007BC4 File Offset: 0x00005DC4
        public void DeleteLayerCommand(DeleteLayerCommand delCmd)
        {
            if (layerForm != null)
            {
                historyCommand.Add(delCmd);
                layerForm.AddCommand(delCmd);
            }
        }

        // Token: 0x0600011C RID: 284 RVA: 0x00007BE6 File Offset: 0x00005DE6
        public void RenameLayerCommand(RenameLayerCommand renameCmd)
        {
            if (layerForm != null)
            {
                historyCommand.Add(renameCmd);
                layerForm.AddCommand(renameCmd);
            }
        }

        // Token: 0x04000087 RID: 135
        private PaintTool activeTool;

        // Token: 0x04000088 RID: 136
        private ScrapPaintToolBar toolFrm;

        // Token: 0x04000089 RID: 137
        private ScrapPaintLayer layerForm;

        // Token: 0x0400008A RID: 138
        private ScrapPaintLayerItem activeLayer;

        // Token: 0x0400008B RID: 139
        private List<ToolCommand> historyCommand;

        // Token: 0x0400008C RID: 140
        private bool isToolUse;
    }
}
