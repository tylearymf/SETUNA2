namespace SETUNA.Main
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    internal class SetunaListBox : ListBox
    {
        protected bool _delkeyitem;
        protected bool _dragmove;
        protected int _idxDragItem;
        protected Point _mouseDrag;
        protected Point _mouseLocate;
        protected object _objDragItem;
        protected bool IsDrag;

        public SetunaListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DoubleBuffered = true;
            this.ItemHeight = 20;
            this.Font = new Font(this.Font.FontFamily, 10f);
            this.IsDrag = false;
            this._mouseDrag = new Point();
            this._mouseLocate = new Point();
            this._dragmove = false;
            this._delkeyitem = false;
            this.LeftSpace = 2;
            this.ItemLine = false;
            this.ItemLineColor = Color.Gray;
        }

        protected virtual void DrawItemString(Graphics g, object item, Font font, Brush brush, Rectangle bounds, StringFormat sf, int index)
        {
            g.DrawString(item.ToString(), font, brush, bounds, sf);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.Index >= 0) && (base.Items.Count > 0))
            {
                e.DrawBackground();
                Rectangle bounds = new Rectangle(e.Bounds.Location, e.Bounds.Size);
                bounds.Y += 2;
                bounds.X += this.LeftSpace;
                bounds.Width -= bounds.X + 2;
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    if ((e.State & DrawItemState.Focus) != DrawItemState.Focus)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0xef, 0xf7, 0xfc)), e.Bounds);
                    }
                    else if (this.IsDrag)
                    {
                        e.Graphics.FillRectangle(Brushes.Moccasin, e.Bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0xce, 230, 0xf7)), e.Bounds);
                    }
                }
                StringFormat genericDefault = StringFormat.GenericDefault;
                genericDefault.FormatFlags = StringFormatFlags.NoWrap;
                if (this.ItemLine)
                {
                    e.Graphics.DrawLine(new Pen(Color.AliceBlue), new Point(e.Bounds.Left - 1, e.Bounds.Top), new Point(e.Bounds.Right, e.Bounds.Top));
                    e.Graphics.DrawLine(new Pen(this.ItemLineColor), new Point(e.Bounds.Left - 1, e.Bounds.Bottom - 1), new Point(e.Bounds.Right, e.Bounds.Bottom - 1));
                }
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                this.DrawItemString(e.Graphics, base.Items[e.Index], e.Font, Brushes.Black, bounds, genericDefault, e.Index);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (((this.SelectedIndex >= 0) && !this.IsDrag) && (this.ItemKeyDelete && (e.KeyCode == Keys.Delete)))
            {
                int selectedIndex = this.SelectedIndex;
                base.Items.RemoveAt(this.SelectedIndex);
                if (selectedIndex < base.Items.Count)
                {
                    this.SelectedIndex = selectedIndex;
                }
                else if (selectedIndex > 0)
                {
                    this.SelectedIndex = selectedIndex - 1;
                }
            }
            else
            {
                base.OnKeyUp(e);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button == MouseButtons.Left) && this.ItemDragMove)
            {
                if (base.IndexFromPoint(e.Location) >= 0)
                {
                    this._mouseDrag = new Point(e.X, e.Y);
                }
            }
            else
            {
                this.IsDrag = false;
                this._mouseDrag = Point.Empty;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this._mouseDrag != Point.Empty)
            {
                Rectangle rectangle = new Rectangle(this._mouseDrag.X - (SystemInformation.DragSize.Width / 2), this._mouseDrag.Y - (SystemInformation.DragSize.Height / 2), SystemInformation.DragSize.Width, SystemInformation.DragSize.Height);
                if (!rectangle.Contains(e.X, e.Y))
                {
                    this._idxDragItem = base.IndexFromPoint(this._mouseDrag);
                    if (this._idxDragItem < 0)
                    {
                        return;
                    }
                    this._objDragItem = base.Items[this._idxDragItem];
                    this.IsDrag = true;
                    this._mouseDrag = Point.Empty;
                    this.Cursor = Cursors.HSplit;
                }
            }
            if (this.IsDrag)
            {
                int index = base.IndexFromPoint(e.Location);
                if ((index >= 0) && (index != this._idxDragItem))
                {
                    base.BeginUpdate();
                    base.Items.RemoveAt(this._idxDragItem);
                    base.Items.Insert(index, this._objDragItem);
                    this.SelectedIndex = index;
                    base.EndUpdate();
                    this._idxDragItem = index;
                }
            }
            else if (this.Cursor != Cursors.Default)
            {
                this.Cursor = Cursors.Default;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.IsDrag = false;
            this._mouseDrag = Point.Empty;
        }

        [Browsable(true), Description("アイテムをドラッグして並び替えが行えるかを取得、設定します。")]
        public bool ItemDragMove
        {
            get{return  
                this._dragmove;}
            set
            {
                this._dragmove = value;
            }
        }

        [Browsable(true), Description("Deleteキーでアイテムの削除を行えるかを取得、設定します。")]
        public bool ItemKeyDelete
        {
            get{return  
                this._delkeyitem;}
            set
            {
                this._delkeyitem = value;
            }
        }

        [Description("アイテムの区切り線を表示するかどうかの値を取得または設定します。"), Browsable(true)]
        public bool ItemLine { get; set; }

        [Description("アイテムの区切り線の色を設定します。")]
        public Color ItemLineColor { get; set; }

        [Description("アイテムの左のスペースを指定します。")]
        public int LeftSpace { get; set; }
    }
}

