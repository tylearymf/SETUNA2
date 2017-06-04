namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ScrapPaintLayerItem : UserControl, ILayer
    {
        private long _id;
        protected Bitmap _img;
        private bool _isalive;
        private CheckBox checkBox1;
        protected List<ToolCommand> Commands;
        private IContainer components;
        private Label label1;
        protected PictureBox picThumb;

        public event LayerDelegate LayerChanged;

        public event LayerRenameDelegate Rename;

        public event LayerDelegate SelectLayer;

        public ScrapPaintLayerItem()
        {
            this.InitializeComponent();
        }

        public ScrapPaintLayerItem(long layerID, int width, int height) : this()
        {
            this._id = layerID;
            this._img = new Bitmap(width, height);
            this.Commands = new List<ToolCommand>();
        }

        public void AddCommand(ToolCommand addCmd)
        {
            this.Commands.Add(addCmd);
            if (addCmd.Parent == null)
            {
                addCmd.Parent = this;
            }
            this.Rasterize();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            if (this._img != null)
            {
                this._img.Dispose();
                this._img = null;
            }
            if (this.Commands != null)
            {
                foreach (ToolCommand command in this.Commands)
                {
                    command.Dispose();
                }
                this.Commands.Clear();
                this.Commands = null;
            }
            base.Dispose(disposing);
        }

        public void Draw(Graphics g)
        {
            if (this._img != null)
            {
                g.DrawImage(this._img, 0, 0);
            }
        }

        protected virtual void DrawThumbnail()
        {
            this.picThumb.Image = this._img.GetThumbnailImage(this.picThumb.Width, this.picThumb.Height, () => false, IntPtr.Zero);
        }

        private void InitializeComponent()
        {
            this.checkBox1 = new CheckBox();
            this.picThumb = new PictureBox();
            this.label1 = new Label();
            ((ISupportInitialize) this.picThumb).BeginInit();
            base.SuspendLayout();
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(3, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(15, 14);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.picThumb.BackColor = Color.White;
            this.picThumb.BorderStyle = BorderStyle.FixedSingle;
            this.picThumb.Location = new Point(0x17, 6);
            this.picThumb.Name = "picThumb";
            this.picThumb.Size = new Size(0x23, 0x1f);
            this.picThumb.TabIndex = 1;
            this.picThumb.TabStop = false;
            this.picThumb.Click += new EventHandler(this.ScrapPaintLayerItem_Click);
            this.label1.Location = new Point(0x40, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x54, 0x2b);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.label1.DoubleClick += new EventHandler(this.label1_DoubleClick);
            this.label1.Click += new EventHandler(this.ScrapPaintLayerItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.BorderStyle = BorderStyle.Fixed3D;
            base.Controls.Add(this.label1);
            base.Controls.Add(this.picThumb);
            base.Controls.Add(this.checkBox1);
            base.Name = "ScrapPaintLayerItem";
            base.Size = new Size(0x92, 0x2b);
            base.Click += new EventHandler(this.ScrapPaintLayerItem_Click);
            ((ISupportInitialize) this.picThumb).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public virtual bool IsEditableTool(PaintTool tool) => 
            true;

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            this.RenameLayer();
        }

        protected virtual void Rasterize()
        {
            using (Graphics graphics = Graphics.FromImage(this._img))
            {
                graphics.FillRectangle(Brushes.Pink, 0, 0, this._img.Width, this._img.Height);
                foreach (ToolCommand command in this.Commands)
                {
                    command.Draw(graphics);
                }
            }
            this._img.MakeTransparent(Color.Pink);
            this.DrawThumbnail();
            this.Refresh();
        }

        public void RefreshLayer()
        {
            if (this.LayerChanged != null)
            {
                this.LayerChanged(this);
            }
        }

        public void RemoveCommand(ToolCommand removeCmd)
        {
            this.Commands.Remove(removeCmd);
            this.Rasterize();
            this.RefreshLayer();
        }

        protected virtual void RenameLayer()
        {
            using (LayerRenameWindow window = new LayerRenameWindow())
            {
                window.LayerName = this.LayerName;
                if ((window.ShowDialog() == DialogResult.OK) && (this.Rename != null))
                {
                    this.Rename(this, window.LayerName);
                }
            }
        }

        private void ScrapPaintLayerItem_Click(object sender, EventArgs e)
        {
            if (this.SelectLayer != null)
            {
                this.SelectLayer(this);
            }
        }

        public bool IsAlive
        {
            get{return  
                this._isalive;}
            set
            {
                this._isalive = value;
            }
        }

        public long LayerID =>
            this._id;

        public string LayerName
        {
            get{return  
                this.label1.Text;}
            set
            {
                this.label1.Text = value;
            }
        }

        public delegate void LayerDelegate(ScrapPaintLayerItem layerCtrl);

        public delegate void LayerRenameDelegate(ScrapPaintLayerItem layerCtrl, string newLayerName);
    }
}

