using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000016 RID: 22
    public partial class ScrapPaintLayer : BaseForm, ILayer
    {
        // Token: 0x14000008 RID: 8
        // (add) Token: 0x060000EA RID: 234 RVA: 0x000069B8 File Offset: 0x00004BB8
        // (remove) Token: 0x060000EB RID: 235 RVA: 0x000069D1 File Offset: 0x00004BD1
        public event ScrapPaintLayerItem.LayerDelegate SelectLayer;

        // Token: 0x14000009 RID: 9
        // (add) Token: 0x060000EC RID: 236 RVA: 0x000069EA File Offset: 0x00004BEA
        // (remove) Token: 0x060000ED RID: 237 RVA: 0x00006A03 File Offset: 0x00004C03
        public event ScrapPaintLayerItem.LayerDelegate LayerRefresh;

        // Token: 0x1700003C RID: 60
        // (get) Token: 0x060000EE RID: 238 RVA: 0x00006A1C File Offset: 0x00004C1C
        public ScrapPaintLayerItem SelectionLayer => _select;

        // Token: 0x1700003D RID: 61
        // (get) Token: 0x060000EF RID: 239 RVA: 0x00006A24 File Offset: 0x00004C24
        // (set) Token: 0x060000F0 RID: 240 RVA: 0x00006A64 File Offset: 0x00004C64
        public int SelectionIndex
        {
            get
            {
                var num = 0;
                while (num < _layers.Count && !_layers[num].Equals(_select))
                {
                    num++;
                }
                return num;
            }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > _layers.Count - 1)
                {
                    value = _layers.Count - 1;
                }
                if (LayerCount > 0)
                {
                    layer_SelectLayer(_layers[value]);
                }
            }
        }

        // Token: 0x1700003E RID: 62
        // (get) Token: 0x060000F1 RID: 241 RVA: 0x00006AB2 File Offset: 0x00004CB2
        private int LayerCount => _layers.Count;

        // Token: 0x060000F2 RID: 242 RVA: 0x00006ABF File Offset: 0x00004CBF
        public ScrapPaintLayer(ScrapPaintWindow parent)
        {
            InitializeComponent();
            _select = null;
            _parent = parent;
            LayerCommands = new List<LayerCommand>();
            HistoryCommands = new List<ToolCommand>();
            _layers = new List<ScrapPaintLayerItem>();
        }

        // Token: 0x060000F3 RID: 243 RVA: 0x00006AFC File Offset: 0x00004CFC
        private void ScrapPaintLayer_Shown(object sender, EventArgs e)
        {
            var addLayerCommand = new AddLayerCommand("层" + (_layers.Count + 1).ToString(), SelectionIndex);
            addLayerCommand.AddLayer += addCmd_AddLayer;
            AddCommand(addLayerCommand);
            layer_SelectLayer(_layers[0]);
        }

        // Token: 0x060000F4 RID: 244 RVA: 0x00006B60 File Offset: 0x00004D60
        public void AddLayer()
        {
            var addLayerCommand = new AddLayerCommand("层" + (_layers.Count + 1).ToString(), SelectionIndex);
            addLayerCommand.AddLayer += addCmd_AddLayer;
            _parent.AddLayerCommand(addLayerCommand);
        }

        // Token: 0x060000F5 RID: 245 RVA: 0x00006BB8 File Offset: 0x00004DB8
        public void addCmd_AddLayer(AddLayerCommand sender)
        {
            foreach (var scrapPaintLayerItem in _layers)
            {
                if (scrapPaintLayerItem.LayerID == sender.LayerID)
                {
                    scrapPaintLayerItem.Visible = true;
                    scrapPaintLayerItem.LayerName = sender.LayerName;
                    scrapPaintLayerItem.IsAlive = true;
                    return;
                }
            }
            var scrapPaintLayerItem2 = sender.CreateLayer(_parent.Width, _parent.Height);
            scrapPaintLayerItem2.LayerName = sender.LayerName;
            scrapPaintLayerItem2.IsAlive = true;
            scrapPaintLayerItem2.SelectLayer += layer_SelectLayer;
            scrapPaintLayerItem2.LayerChanged += layer_LayerChanged;
            scrapPaintLayerItem2.Rename += layer_Rename;
            _layers.Insert(sender.InsertIndex, scrapPaintLayerItem2);
            SelectionIndex = sender.InsertIndex;
        }

        // Token: 0x060000F6 RID: 246 RVA: 0x00006CB8 File Offset: 0x00004EB8
        private void layer_Rename(ScrapPaintLayerItem layerCtrl, string newLayerName)
        {
            var renameLayerCommand = new RenameLayerCommand(layerCtrl.LayerID, newLayerName);
            renameLayerCommand.RenameLayer += renameCmd_RenameLayer;
            _parent.RenameLayerCommand(renameLayerCommand);
        }

        // Token: 0x060000F7 RID: 247 RVA: 0x00006CF0 File Offset: 0x00004EF0
        private void renameCmd_RenameLayer(RenameLayerCommand sender)
        {
            foreach (var scrapPaintLayerItem in _layers)
            {
                if (scrapPaintLayerItem.LayerID == sender.LayerID)
                {
                    scrapPaintLayerItem.LayerName = sender.LayerName;
                    scrapPaintLayerItem.IsAlive = true;
                    break;
                }
            }
        }

        // Token: 0x060000F8 RID: 248 RVA: 0x00006D60 File Offset: 0x00004F60
        private void DeleteLayer()
        {
            if (_select != null && MessageBox.Show(_select.LayerName + "我如何删除？", base.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var deleteLayerCommand = new DeleteLayerCommand(SelectionLayer.LayerID);
                deleteLayerCommand.DeleteLayer += delCmd_DeleteLayer;
                _parent.DeleteLayerCommand(deleteLayerCommand);
            }
        }

        // Token: 0x060000F9 RID: 249 RVA: 0x00006DD0 File Offset: 0x00004FD0
        private void delCmd_DeleteLayer(DeleteLayerCommand sender)
        {
            foreach (var scrapPaintLayerItem in _layers)
            {
                if (scrapPaintLayerItem.LayerID == sender.LayerID)
                {
                    scrapPaintLayerItem.Visible = false;
                    scrapPaintLayerItem.IsAlive = true;
                    break;
                }
            }
        }

        // Token: 0x060000FA RID: 250 RVA: 0x00006E3C File Offset: 0x0000503C
        private void RefreshLayerItem()
        {
            base.SuspendLayout();
            var selectionIndex = SelectionIndex;
            var list = new List<ScrapPaintLayerItem>();
            foreach (var obj in panel3.Controls)
            {
                var item = (ScrapPaintLayerItem)obj;
                list.Add(item);
            }
            var num = 0;
            new List<ScrapPaintLayerItem>();
            foreach (var scrapPaintLayerItem in _layers)
            {
                if (scrapPaintLayerItem.Visible)
                {
                    scrapPaintLayerItem.Top = num;
                    num += scrapPaintLayerItem.Height;
                    if (panel3.Controls.IndexOf(scrapPaintLayerItem) == -1)
                    {
                        panel3.Controls.Add(scrapPaintLayerItem);
                    }
                    else
                    {
                        list.Remove(scrapPaintLayerItem);
                    }
                }
            }
            foreach (var value in list)
            {
                panel3.Controls.Remove(value);
            }
            SelectionIndex = selectionIndex;
            base.ResumeLayout();
        }

        // Token: 0x060000FB RID: 251 RVA: 0x00006FA0 File Offset: 0x000051A0
        private void layer_SelectLayer(ScrapPaintLayerItem layerCtrl)
        {
            if (layerCtrl.Equals(_select))
            {
                return;
            }
            _select = layerCtrl;
            foreach (var scrapPaintLayerItem in _layers)
            {
                if (scrapPaintLayerItem.Equals(layerCtrl))
                {
                    scrapPaintLayerItem.BackColor = Color.SkyBlue;
                }
                else
                {
                    scrapPaintLayerItem.BackColor = SystemColors.Control;
                }
            }
            if (SelectLayer != null)
            {
                SelectLayer(layerCtrl);
            }
        }

        // Token: 0x060000FC RID: 252 RVA: 0x00007038 File Offset: 0x00005238
        private void layer_LayerChanged(ScrapPaintLayerItem layerCtrl)
        {
            if (LayerRefresh != null)
            {
                LayerRefresh(null);
            }
        }

        // Token: 0x060000FD RID: 253 RVA: 0x00007050 File Offset: 0x00005250
        public void Draw(Graphics g)
        {
            _layers.Reverse();
            foreach (var scrapPaintLayerItem in _layers)
            {
                if (scrapPaintLayerItem.Visible)
                {
                    scrapPaintLayerItem.Draw(g);
                }
            }
            _layers.Reverse();
        }

        // Token: 0x060000FE RID: 254 RVA: 0x000070C4 File Offset: 0x000052C4
        private void btnLayerAdd_Click(object sender, EventArgs e)
        {
            AddLayer();
        }

        // Token: 0x060000FF RID: 255 RVA: 0x000070CC File Offset: 0x000052CC
        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteLayer();
        }

        // Token: 0x06000100 RID: 256 RVA: 0x000070D4 File Offset: 0x000052D4
        public void AddCommand(ToolCommand addCmd)
        {
            LayerCommands.Add((LayerCommand)addCmd);
            addCmd.Parent = this;
            RefreshLayer();
        }

        // Token: 0x06000101 RID: 257 RVA: 0x000070F4 File Offset: 0x000052F4
        public void RefreshLayer()
        {
            foreach (var scrapPaintLayerItem in _layers)
            {
                scrapPaintLayerItem.IsAlive = false;
            }
            foreach (var layerCommand in LayerCommands)
            {
                layerCommand.Apply();
            }
            var list = new List<ScrapPaintLayerItem>();
            foreach (var scrapPaintLayerItem2 in _layers)
            {
                if (!scrapPaintLayerItem2.IsAlive)
                {
                    list.Add(scrapPaintLayerItem2);
                }
            }
            for (var i = 0; i < list.Count; i++)
            {
                _layers.Remove(list[i]);
                list[i].Dispose();
            }
            list.Clear();
            list = null;
            RefreshLayerItem();
            if (LayerRefresh != null)
            {
                LayerRefresh(null);
            }
        }

        // Token: 0x06000102 RID: 258 RVA: 0x00007234 File Offset: 0x00005434
        public void RemoveCommand(ToolCommand removeCmd)
        {
            LayerCommands.Remove((LayerCommand)removeCmd);
            RefreshLayer();
        }

        // Token: 0x06000103 RID: 259 RVA: 0x0000724E File Offset: 0x0000544E
        private void ScrapPaintLayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        // Token: 0x0400007B RID: 123
        private List<ScrapPaintLayerItem> _layers;

        // Token: 0x0400007E RID: 126
        private List<ToolCommand> HistoryCommands;
    }
}
