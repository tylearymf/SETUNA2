namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public sealed class ScrapPaintWindow : ScrapDrawForm
    {
        private ScrapPaintLayerItem activeLayer;
        private PaintTool activeTool;
        private List<ToolCommand> historyCommand;
        private bool isToolUse;
        private ScrapPaintLayer layerForm;
        private ScrapPaintToolBar toolFrm;

        public ScrapPaintWindow(ScrapBase scrap) : base(scrap)
        {
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.isToolUse = false;
            this.activeTool = null;
            this.historyCommand = new List<ToolCommand>();
            this.toolFrm = new ScrapPaintToolBar(this);
            this.toolFrm.KeyUp += new KeyEventHandler(this.layerForm_KeyUp);
            this.toolFrm.SelectTool += new ScrapPaintToolBar.SelectToolDelegate(this.toolFrm_SelectTool);
            base.AddOwnedForm(this.toolFrm);
            this.layerForm = new ScrapPaintLayer(this);
            this.layerForm.KeyUp += new KeyEventHandler(this.layerForm_KeyUp);
            this.layerForm.SelectLayer += new ScrapPaintLayerItem.LayerDelegate(this.layerForm_SelectLayer);
            this.layerForm.LayerRefresh += new ScrapPaintLayerItem.LayerDelegate(this.layerForm_LayerRefresh);
            base.AddOwnedForm(this.layerForm);
            this.activeLayer = this.layerForm.SelectionLayer;
        }

        private void activeTool_Finished(ToolCommand command)
        {
            this.isToolUse = false;
            this.historyCommand.Add(command);
            this.activeLayer.AddCommand(command);
        }

        private void activeTool_Started(ToolCommand command)
        {
            this.isToolUse = true;
        }

        public void AddLayerCommand(SETUNA.Main.StyleItems.AddLayerCommand addCmd)
        {
            if (this.layerForm != null)
            {
                this.historyCommand.Add(addCmd);
                if (!addCmd.IsEvent)
                {
                    addCmd.AddLayer += new SETUNA.Main.StyleItems.AddLayerCommand.AddLayerCommandDelegate(this.layerForm.addCmd_AddLayer);
                }
                this.layerForm.AddCommand(addCmd);
            }
        }

        public void DeleteLayerCommand(SETUNA.Main.StyleItems.DeleteLayerCommand delCmd)
        {
            if (this.layerForm != null)
            {
                this.historyCommand.Add(delCmd);
                this.layerForm.AddCommand(delCmd);
            }
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x124, 0x10a);
            base.Name = "ScrapPaintWindow";
            base.ResumeLayout(false);
        }

        private void KeyInput(KeyEventArgs e)
        {
            if (this.isToolUse && (this.Cursor != Cursors.No))
            {
                if (this.activeTool != null)
                {
                    this.activeTool.KeyUp(e);
                }
                this.Refresh();
            }
            else if ((e.KeyCode == Keys.Z) && e.Control)
            {
                this.UndoCommand();
            }
            else if ((e.KeyCode == Keys.N) && e.Control)
            {
                this.layerForm.AddLayer();
            }
            else if (e.KeyCode == Keys.B)
            {
                this.toolFrm.SwitchTool(ScrapPaintToolBar.ToolKind.笔工具);
            }
            else if (e.KeyCode == Keys.E)
            {
                this.toolFrm.SwitchTool(ScrapPaintToolBar.ToolKind.消しゴム工具);
            }
            else if (((e.KeyCode == Keys.X) && (this.activeTool != null)) && !this.activeTool.IsActive)
            {
                this.toolFrm.ChangeColor();
            }
        }

        private void layerForm_KeyUp(object sender, KeyEventArgs e)
        {
            this.KeyInput(e);
        }

        private void layerForm_LayerRefresh(ScrapPaintLayerItem layerCtrl)
        {
            this.Refresh();
        }

        private void layerForm_SelectLayer(ScrapPaintLayerItem layerCtrl)
        {
            this.activeLayer = layerCtrl;
            this.ToolEditCheck();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            this.KeyInput(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.toolFrm.SwitchTool(ScrapPaintToolBar.ToolKind.笔工具);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.Cursor != Cursors.No)
            {
                if (this.activeTool != null)
                {
                    this.activeTool.MouseDown(e);
                }
                this.Refresh();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.Cursor != Cursors.No)
            {
                if (this.activeTool != null)
                {
                    this.activeTool.MouseMove(e);
                }
                this.Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.Cursor != Cursors.No)
            {
                if (this.activeTool != null)
                {
                    this.activeTool.MouseUp(e);
                }
                this.Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImageUnscaled(base._scrap.Image, base.BasePoint);
            this.layerForm.Draw(e.Graphics);
            if (this.activeTool != null)
            {
                this.activeTool.Draw(e.Graphics);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.toolFrm.Top = base.Top;
            this.toolFrm.Left = (base.Left - this.toolFrm.Width) - 20;
            this.toolFrm.Show();
            this.layerForm.Top = base.Bottom - this.layerForm.Height;
            this.layerForm.Left = base.Right + 20;
            this.layerForm.Show();
        }

        public void RenameLayerCommand(SETUNA.Main.StyleItems.RenameLayerCommand renameCmd)
        {
            if (this.layerForm != null)
            {
                this.historyCommand.Add(renameCmd);
                this.layerForm.AddCommand(renameCmd);
            }
        }

        private void ScrapPaintWindow_Shown(object sender, EventArgs e)
        {
        }

        public int SelectionLayerIndex() => 
            this.layerForm.SelectionIndex;

        private void ToolEditCheck()
        {
            if (this.activeLayer != null)
            {
                if (this.activeLayer.IsEditableTool(this.activeTool))
                {
                    this.Cursor = Cursors.Cross;
                }
                else
                {
                    this.Cursor = Cursors.No;
                }
            }
        }

        private void toolFrm_SelectTool(PaintTool tool)
        {
            if (this.activeTool != null)
            {
                this.activeTool.Dispose();
                this.activeTool = null;
            }
            this.activeTool = tool;
            if (this.activeTool != null)
            {
                this.activeTool.Started += new PaintTool.PaintToolDelegate(this.activeTool_Started);
                this.activeTool.Finished += new PaintTool.PaintToolDelegate(this.activeTool_Finished);
            }
            this.ToolEditCheck();
        }

        private void UndoCommand()
        {
            if (this.historyCommand.Count != 0)
            {
                ToolCommand item = this.historyCommand[this.historyCommand.Count - 1];
                this.historyCommand.Remove(item);
                if (item.Parent != null)
                {
                    item.Parent.RemoveCommand(item);
                }
            }
        }
    }
}

