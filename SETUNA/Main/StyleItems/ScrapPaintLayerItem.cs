using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000018 RID: 24
    public class ScrapPaintLayerItem : UserControl, ILayer
    {
        // Token: 0x0600011D RID: 285 RVA: 0x00007C08 File Offset: 0x00005E08
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            if (_img != null)
            {
                _img.Dispose();
                _img = null;
            }
            if (Commands != null)
            {
                foreach (var toolCommand in Commands)
                {
                    toolCommand.Dispose();
                }
                Commands.Clear();
                Commands = null;
            }
            base.Dispose(disposing);
        }

        // Token: 0x0600011E RID: 286 RVA: 0x00007CAC File Offset: 0x00005EAC
        private void InitializeComponent()
        {
            checkBox1 = new System.Windows.Forms.CheckBox();
            picThumb = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(picThumb)).BeginInit();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(3, 13);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(15, 14);
            checkBox1.TabIndex = 0;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // picThumb
            // 
            picThumb.BackColor = System.Drawing.Color.White;
            picThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picThumb.Location = new System.Drawing.Point(23, 6);
            picThumb.Name = "picThumb";
            picThumb.Size = new System.Drawing.Size(35, 31);
            picThumb.TabIndex = 1;
            picThumb.TabStop = false;
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(64, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(84, 43);
            label1.TabIndex = 2;
            label1.Text = "label1";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScrapPaintLayerItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Controls.Add(label1);
            Controls.Add(picThumb);
            Controls.Add(checkBox1);
            Name = "ScrapPaintLayerItem";
            Size = new System.Drawing.Size(146, 43);
            ((System.ComponentModel.ISupportInitialize)(picThumb)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        // Token: 0x1400000A RID: 10
        // (add) Token: 0x0600011F RID: 287 RVA: 0x00007EF3 File Offset: 0x000060F3
        // (remove) Token: 0x06000120 RID: 288 RVA: 0x00007F0C File Offset: 0x0000610C
        public event ScrapPaintLayerItem.LayerDelegate SelectLayer;

        // Token: 0x1400000B RID: 11
        // (add) Token: 0x06000121 RID: 289 RVA: 0x00007F25 File Offset: 0x00006125
        // (remove) Token: 0x06000122 RID: 290 RVA: 0x00007F3E File Offset: 0x0000613E
        public event ScrapPaintLayerItem.LayerDelegate LayerChanged;

        // Token: 0x1400000C RID: 12
        // (add) Token: 0x06000123 RID: 291 RVA: 0x00007F57 File Offset: 0x00006157
        // (remove) Token: 0x06000124 RID: 292 RVA: 0x00007F70 File Offset: 0x00006170
        public event ScrapPaintLayerItem.LayerRenameDelegate Rename;

        // Token: 0x1700003F RID: 63
        // (get) Token: 0x06000125 RID: 293 RVA: 0x00007F89 File Offset: 0x00006189
        public long LayerID => _id;

        // Token: 0x17000040 RID: 64
        // (get) Token: 0x06000127 RID: 295 RVA: 0x00007F9F File Offset: 0x0000619F
        // (set) Token: 0x06000126 RID: 294 RVA: 0x00007F91 File Offset: 0x00006191
        public string LayerName
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        // Token: 0x17000041 RID: 65
        // (get) Token: 0x06000129 RID: 297 RVA: 0x00007FB5 File Offset: 0x000061B5
        // (set) Token: 0x06000128 RID: 296 RVA: 0x00007FAC File Offset: 0x000061AC
        public bool IsAlive
        {
            get => _isalive;
            set => _isalive = value;
        }

        // Token: 0x0600012A RID: 298 RVA: 0x00007FBD File Offset: 0x000061BD
        public ScrapPaintLayerItem()
        {
            InitializeComponent();
        }

        // Token: 0x0600012B RID: 299 RVA: 0x00007FCB File Offset: 0x000061CB
        public ScrapPaintLayerItem(long layerID, int width, int height) : this()
        {
            _id = layerID;
            _img = new Bitmap(width, height);
            Commands = new List<ToolCommand>();
        }

        // Token: 0x0600012C RID: 300 RVA: 0x00007FF2 File Offset: 0x000061F2
        private void ScrapPaintLayerItem_Click(object sender, EventArgs e)
        {
            if (SelectLayer != null)
            {
                SelectLayer(this);
            }
        }

        // Token: 0x0600012D RID: 301 RVA: 0x00008008 File Offset: 0x00006208
        protected virtual void Rasterize()
        {
            using (var graphics = Graphics.FromImage(_img))
            {
                graphics.FillRectangle(Brushes.Pink, 0, 0, _img.Width, _img.Height);
                foreach (var toolCommand in Commands)
                {
                    toolCommand.Draw(graphics);
                }
            }
            _img.MakeTransparent(Color.Pink);
            DrawThumbnail();
            Refresh();
        }

        // Token: 0x0600012E RID: 302 RVA: 0x000080C0 File Offset: 0x000062C0
        protected virtual void DrawThumbnail()
        {
            picThumb.Image = _img.GetThumbnailImage(picThumb.Width, picThumb.Height, () => false, IntPtr.Zero);
        }

        // Token: 0x0600012F RID: 303 RVA: 0x0000811B File Offset: 0x0000631B
        public void Draw(Graphics g)
        {
            if (_img != null)
            {
                g.DrawImage(_img, 0, 0);
            }
        }

        // Token: 0x06000130 RID: 304 RVA: 0x00008133 File Offset: 0x00006333
        public void AddCommand(ToolCommand addCmd)
        {
            Commands.Add(addCmd);
            if (addCmd.Parent == null)
            {
                addCmd.Parent = this;
            }
            Rasterize();
        }

        // Token: 0x06000131 RID: 305 RVA: 0x00008156 File Offset: 0x00006356
        public void RefreshLayer()
        {
            if (LayerChanged != null)
            {
                LayerChanged(this);
            }
        }

        // Token: 0x06000132 RID: 306 RVA: 0x0000816C File Offset: 0x0000636C
        public void RemoveCommand(ToolCommand removeCmd)
        {
            Commands.Remove(removeCmd);
            Rasterize();
            RefreshLayer();
        }

        // Token: 0x06000133 RID: 307 RVA: 0x00008187 File Offset: 0x00006387
        private void label1_DoubleClick(object sender, EventArgs e)
        {
            RenameLayer();
        }

        // Token: 0x06000134 RID: 308 RVA: 0x00008190 File Offset: 0x00006390
        protected virtual void RenameLayer()
        {
            using (var layerRenameWindow = new LayerRenameWindow())
            {
                layerRenameWindow.LayerName = LayerName;
                if (layerRenameWindow.ShowDialog() == DialogResult.OK && Rename != null)
                {
                    Rename(this, layerRenameWindow.LayerName);
                }
            }
        }

        // Token: 0x06000135 RID: 309 RVA: 0x000081F0 File Offset: 0x000063F0
        public virtual bool IsEditableTool(PaintTool tool)
        {
            return true;
        }

        // Token: 0x0400008D RID: 141
#pragma warning disable CS0649 // 从未对字段“ScrapPaintLayerItem.components”赋值，字段将一直保持其默认值 null
        private IContainer components;
#pragma warning restore CS0649 // 从未对字段“ScrapPaintLayerItem.components”赋值，字段将一直保持其默认值 null

        // Token: 0x0400008E RID: 142
        private CheckBox checkBox1;

        // Token: 0x0400008F RID: 143
        private Label label1;

        // Token: 0x04000090 RID: 144
        protected PictureBox picThumb;

        // Token: 0x04000094 RID: 148
        private long _id;

        // Token: 0x04000095 RID: 149
        protected Bitmap _img;

        // Token: 0x04000096 RID: 150
        private bool _isalive;

        // Token: 0x04000097 RID: 151
        protected List<ToolCommand> Commands;

        // Token: 0x0200001A RID: 26
        // (Invoke) Token: 0x0600013E RID: 318
        public delegate void LayerDelegate(ScrapPaintLayerItem layerCtrl);

        // Token: 0x0200001D RID: 29
        // (Invoke) Token: 0x0600014D RID: 333
        public delegate void LayerRenameDelegate(ScrapPaintLayerItem layerCtrl, string newLayerName);
    }
}
