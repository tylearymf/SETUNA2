namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ScrapPaintLayer : Form, ILayer
    {
        private List<ScrapPaintLayerItem> _layers;
        private ScrapPaintWindow _parent;
        private ScrapPaintLayerItem _select;
        private Button btnDel;
        private Button btnLayerAdd;
        private IContainer components;
        private List<ToolCommand> HistoryCommands;
        private List<LayerCommand> LayerCommands;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;

        public event ScrapPaintLayerItem.LayerDelegate LayerRefresh;

        public event ScrapPaintLayerItem.LayerDelegate SelectLayer;

        public ScrapPaintLayer(ScrapPaintWindow parent)
        {
            this.InitializeComponent();
            this._select = null;
            this._parent = parent;
            this.LayerCommands = new List<LayerCommand>();
            this.HistoryCommands = new List<ToolCommand>();
            this._layers = new List<ScrapPaintLayerItem>();
        }

        public void addCmd_AddLayer(AddLayerCommand sender)
        {
            foreach (ScrapPaintLayerItem item in this._layers)
            {
                if (item.LayerID == sender.LayerID)
                {
                    item.Visible = true;
                    item.LayerName = sender.LayerName;
                    item.IsAlive = true;
                    return;
                }
            }
            ScrapPaintLayerItem item2 = sender.CreateLayer(this._parent.Width, this._parent.Height);
            item2.LayerName = sender.LayerName;
            item2.IsAlive = true;
            item2.SelectLayer += new ScrapPaintLayerItem.LayerDelegate(this.layer_SelectLayer);
            item2.LayerChanged += new ScrapPaintLayerItem.LayerDelegate(this.layer_LayerChanged);
            item2.Rename += new ScrapPaintLayerItem.LayerRenameDelegate(this.layer_Rename);
            this._layers.Insert(sender.InsertIndex, item2);
            this.SelectionIndex = sender.InsertIndex;
        }

        public void AddCommand(ToolCommand addCmd)
        {
            this.LayerCommands.Add((LayerCommand) addCmd);
            addCmd.Parent = this;
            this.RefreshLayer();
        }

        public void AddLayer()
        {
            int num = this._layers.Count + 1;
            AddLayerCommand addCmd = new AddLayerCommand("层" + num.ToString(), this.SelectionIndex);
            addCmd.AddLayer += new AddLayerCommand.AddLayerCommandDelegate(this.addCmd_AddLayer);
            this._parent.AddLayerCommand(addCmd);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.DeleteLayer();
        }

        private void btnLayerAdd_Click(object sender, EventArgs e)
        {
            this.AddLayer();
        }

        private void delCmd_DeleteLayer(DeleteLayerCommand sender)
        {
            foreach (ScrapPaintLayerItem item in this._layers)
            {
                if (item.LayerID == sender.LayerID)
                {
                    item.Visible = false;
                    item.IsAlive = true;
                    break;
                }
            }
        }

        private void DeleteLayer()
        {
            if ((this._select != null) && (MessageBox.Show(this._select.LayerName + "我如何删除？", base.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
            {
                DeleteLayerCommand delCmd = new DeleteLayerCommand(this.SelectionLayer.LayerID);
                delCmd.DeleteLayer += new DeleteLayerCommand.DeleteLayerCommandDelegate(this.delCmd_DeleteLayer);
                this._parent.DeleteLayerCommand(delCmd);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            this._parent = null;
            this._select = null;
            if (this.LayerCommands != null)
            {
                foreach (ToolCommand command in this.LayerCommands)
                {
                    command.Dispose();
                }
                this.LayerCommands.Clear();
                this.LayerCommands = null;
            }
            base.Dispose(disposing);
        }

        public void Draw(Graphics g)
        {
            this._layers.Reverse();
            foreach (ScrapPaintLayerItem item in this._layers)
            {
                if (item.Visible)
                {
                    item.Draw(g);
                }
            }
            this._layers.Reverse();
        }

        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.btnDel = new Button();
            this.btnLayerAdd = new Button();
            this.panel2 = new Panel();
            this.panel3 = new Panel();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnLayerAdd);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(0, 0xf7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x94, 0x13);
            this.panel1.TabIndex = 0;
            this.btnDel.Location = new Point(0x51, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new Size(0x22, 0x13);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new EventHandler(this.btnDel_Click);
            this.btnLayerAdd.Location = new Point(0x72, 0);
            this.btnLayerAdd.Name = "btnLayerAdd";
            this.btnLayerAdd.Size = new Size(0x22, 0x13);
            this.btnLayerAdd.TabIndex = 0;
            this.btnLayerAdd.Text = "Add";
            this.btnLayerAdd.UseVisualStyleBackColor = true;
            this.btnLayerAdd.Click += new EventHandler(this.btnLayerAdd_Click);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x94, 0x1a);
            this.panel2.TabIndex = 1;
            this.panel3.AutoScroll = true;
            this.panel3.BorderStyle = BorderStyle.Fixed3D;
            this.panel3.Dock = DockStyle.Fill;
            this.panel3.Location = new Point(0, 0x1a);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x94, 0xdd);
            this.panel3.TabIndex = 2;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x94, 0x10a);
            base.ControlBox = false;
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.KeyPreview = true;
            base.Name = "ScrapPaintLayer";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "层";
            base.TopMost = true;
            base.Shown += new EventHandler(this.ScrapPaintLayer_Shown);
            base.FormClosing += new FormClosingEventHandler(this.ScrapPaintLayer_FormClosing);
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void layer_LayerChanged(ScrapPaintLayerItem layerCtrl)
        {
            if (this.LayerRefresh != null)
            {
                this.LayerRefresh(null);
            }
        }

        private void layer_Rename(ScrapPaintLayerItem layerCtrl, string newLayerName)
        {
            RenameLayerCommand renameCmd = new RenameLayerCommand(layerCtrl.LayerID, newLayerName);
            renameCmd.RenameLayer += new RenameLayerCommand.RenameLayerCommandDelegate(this.renameCmd_RenameLayer);
            this._parent.RenameLayerCommand(renameCmd);
        }

        private void layer_SelectLayer(ScrapPaintLayerItem layerCtrl)
        {
            if (!layerCtrl.Equals(this._select))
            {
                this._select = layerCtrl;
                foreach (ScrapPaintLayerItem item in this._layers)
                {
                    if (item.Equals(layerCtrl))
                    {
                        item.BackColor = Color.SkyBlue;
                    }
                    else
                    {
                        item.BackColor = SystemColors.Control;
                    }
                }
                if (this.SelectLayer != null)
                {
                    this.SelectLayer(layerCtrl);
                }
            }
        }

        public void RefreshLayer()
        {
            foreach (ScrapPaintLayerItem item in this._layers)
            {
                item.IsAlive = false;
            }
            foreach (LayerCommand command in this.LayerCommands)
            {
                command.Apply();
            }
            List<ScrapPaintLayerItem> list = new List<ScrapPaintLayerItem>();
            foreach (ScrapPaintLayerItem item2 in this._layers)
            {
                if (!item2.IsAlive)
                {
                    list.Add(item2);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                this._layers.Remove(list[i]);
                list[i].Dispose();
            }
            list.Clear();
            list = null;
            this.RefreshLayerItem();
            if (this.LayerRefresh != null)
            {
                this.LayerRefresh(null);
            }
        }

        private void RefreshLayerItem()
        {
            base.SuspendLayout();
            int selectionIndex = this.SelectionIndex;
            List<ScrapPaintLayerItem> list = new List<ScrapPaintLayerItem>();
            foreach (ScrapPaintLayerItem item in this.panel3.Controls)
            {
                list.Add(item);
            }
            int num2 = 0;
            new List<ScrapPaintLayerItem>();
            foreach (ScrapPaintLayerItem item2 in this._layers)
            {
                if (item2.Visible)
                {
                    item2.Top = num2;
                    num2 += item2.Height;
                    if (this.panel3.Controls.IndexOf(item2) == -1)
                    {
                        this.panel3.Controls.Add(item2);
                    }
                    else
                    {
                        list.Remove(item2);
                    }
                }
            }
            foreach (ScrapPaintLayerItem item3 in list)
            {
                this.panel3.Controls.Remove(item3);
            }
            this.SelectionIndex = selectionIndex;
            base.ResumeLayout();
        }

        public void RemoveCommand(ToolCommand removeCmd)
        {
            this.LayerCommands.Remove((LayerCommand) removeCmd);
            this.RefreshLayer();
        }

        private void renameCmd_RenameLayer(RenameLayerCommand sender)
        {
            foreach (ScrapPaintLayerItem item in this._layers)
            {
                if (item.LayerID == sender.LayerID)
                {
                    item.LayerName = sender.LayerName;
                    item.IsAlive = true;
                    break;
                }
            }
        }

        private void ScrapPaintLayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void ScrapPaintLayer_Shown(object sender, EventArgs e)
        {
            int num = this._layers.Count + 1;
            AddLayerCommand addCmd = new AddLayerCommand("层" + num.ToString(), this.SelectionIndex);
            addCmd.AddLayer += new AddLayerCommand.AddLayerCommandDelegate(this.addCmd_AddLayer);
            this.AddCommand(addCmd);
            this.layer_SelectLayer(this._layers[0]);
        }

        private int LayerCount =>
            this._layers.Count;

        public int SelectionIndex
        {
            get
            {
                int num = 0;
                while (num < this._layers.Count)
                {
                    if (this._layers[num].Equals(this._select))
                    {
                        return num;
                    }
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
                if (value > (this._layers.Count - 1))
                {
                    value = this._layers.Count - 1;
                }
                if (this.LayerCount > 0)
                {
                    this.layer_SelectLayer(this._layers[value]);
                }
            }
        }

        public ScrapPaintLayerItem SelectionLayer =>
            this._select;
    }
}

