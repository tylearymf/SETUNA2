using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SETUNA.Main
{
    // Token: 0x02000080 RID: 128
    internal class SetunaListBox : ListBox
    {
        // Token: 0x170000A3 RID: 163
        // (get) Token: 0x0600042D RID: 1069 RVA: 0x0001A937 File Offset: 0x00018B37
        // (set) Token: 0x0600042C RID: 1068 RVA: 0x0001A92E File Offset: 0x00018B2E
        [Description("アイテムの区切り線を表示するかどうかの値を取得または設定します。")]
        [Browsable(true)]
        public bool ItemLine { get; set; }

        // Token: 0x170000A4 RID: 164
        // (get) Token: 0x0600042F RID: 1071 RVA: 0x0001A948 File Offset: 0x00018B48
        // (set) Token: 0x0600042E RID: 1070 RVA: 0x0001A93F File Offset: 0x00018B3F
        [Description("アイテムの区切り線の色を設定します。")]
        public Color ItemLineColor { get; set; }

        // Token: 0x170000A5 RID: 165
        // (get) Token: 0x06000431 RID: 1073 RVA: 0x0001A959 File Offset: 0x00018B59
        // (set) Token: 0x06000430 RID: 1072 RVA: 0x0001A950 File Offset: 0x00018B50
        [Description("アイテムの左のスペースを指定します。")]
        public int LeftSpace { get; set; }

        // Token: 0x06000432 RID: 1074 RVA: 0x0001A964 File Offset: 0x00018B64
        public SetunaListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DoubleBuffered = true;
            ItemHeight = 20;
            Font = new Font(Font.FontFamily, 10f);
            IsDrag = false;
            _mouseDrag = default(Point);
            _mouseLocate = default(Point);
            _dragmove = false;
            _delkeyitem = false;
            LeftSpace = 2;
            ItemLine = false;
            ItemLineColor = Color.Gray;
        }

        // Token: 0x170000A6 RID: 166
        // (get) Token: 0x06000433 RID: 1075 RVA: 0x0001A9EE File Offset: 0x00018BEE
        // (set) Token: 0x06000434 RID: 1076 RVA: 0x0001A9F6 File Offset: 0x00018BF6
        [Browsable(true)]
        [Description("アイテムをドラッグして並び替えが行えるかを取得、設定します。")]
        public bool ItemDragMove
        {
            get => _dragmove;
            set => _dragmove = value;
        }

        // Token: 0x170000A7 RID: 167
        // (get) Token: 0x06000436 RID: 1078 RVA: 0x0001AA08 File Offset: 0x00018C08
        // (set) Token: 0x06000435 RID: 1077 RVA: 0x0001A9FF File Offset: 0x00018BFF
        [Browsable(true)]
        [Description("Deleteキーでアイテムの削除を行えるかを取得、設定します。")]
        public bool ItemKeyDelete
        {
            get => _delkeyitem;
            set => _delkeyitem = value;
        }

        // Token: 0x06000437 RID: 1079 RVA: 0x0001AA10 File Offset: 0x00018C10
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            if (base.Items.Count <= 0)
            {
                return;
            }
            e.DrawBackground();
            var bounds = new Rectangle(e.Bounds.Location, e.Bounds.Size);
            bounds.Y += 2;
            bounds.X += LeftSpace;
            bounds.Width -= bounds.X + 2;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if ((e.State & DrawItemState.Focus) != DrawItemState.Focus)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(239, 247, 252)), e.Bounds);
                }
                else if (IsDrag)
                {
                    e.Graphics.FillRectangle(Brushes.Moccasin, e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(206, 230, 247)), e.Bounds);
                }
            }
            var genericDefault = StringFormat.GenericDefault;
            genericDefault.FormatFlags = StringFormatFlags.NoWrap;
            if (ItemLine)
            {
                e.Graphics.DrawLine(new Pen(Color.AliceBlue), new Point(e.Bounds.Left - 1, e.Bounds.Top), new Point(e.Bounds.Right, e.Bounds.Top));
                e.Graphics.DrawLine(new Pen(ItemLineColor), new Point(e.Bounds.Left - 1, e.Bounds.Bottom - 1), new Point(e.Bounds.Right, e.Bounds.Bottom - 1));
            }
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            DrawItemString(e.Graphics, base.Items[e.Index], e.Font, Brushes.Black, bounds, genericDefault, e.Index);
        }

        // Token: 0x06000438 RID: 1080 RVA: 0x0001AC59 File Offset: 0x00018E59
        protected virtual void DrawItemString(Graphics g, object item, Font font, Brush brush, Rectangle bounds, StringFormat sf, int index)
        {
            g.DrawString(item.ToString(), font, brush, bounds, sf);
        }

        // Token: 0x06000439 RID: 1081 RVA: 0x0001AC74 File Offset: 0x00018E74
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && ItemDragMove)
            {
                if (base.IndexFromPoint(e.Location) >= 0)
                {
                    _mouseDrag = new Point(e.X, e.Y);
                    return;
                }
            }
            else
            {
                IsDrag = false;
                _mouseDrag = Point.Empty;
            }
        }

        // Token: 0x0600043A RID: 1082 RVA: 0x0001ACD6 File Offset: 0x00018ED6
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            IsDrag = false;
            _mouseDrag = Point.Empty;
        }

        // Token: 0x0600043B RID: 1083 RVA: 0x0001ACF4 File Offset: 0x00018EF4
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_mouseDrag != Point.Empty)
            {
                var rectangle = new Rectangle(_mouseDrag.X - SystemInformation.DragSize.Width / 2, _mouseDrag.Y - SystemInformation.DragSize.Height / 2, SystemInformation.DragSize.Width, SystemInformation.DragSize.Height);
                if (!rectangle.Contains(e.X, e.Y))
                {
                    _idxDragItem = base.IndexFromPoint(_mouseDrag);
                    if (_idxDragItem < 0)
                    {
                        return;
                    }
                    _objDragItem = base.Items[_idxDragItem];
                    IsDrag = true;
                    _mouseDrag = Point.Empty;
                    Cursor = Cursors.HSplit;
                }
            }
            if (IsDrag)
            {
                var num = base.IndexFromPoint(e.Location);
                if (num >= 0 && num != _idxDragItem)
                {
                    base.BeginUpdate();
                    base.Items.RemoveAt(_idxDragItem);
                    base.Items.Insert(num, _objDragItem);
                    SelectedIndex = num;
                    base.EndUpdate();
                    _idxDragItem = num;
                    return;
                }
            }
            else if (Cursor != Cursors.Default)
            {
                Cursor = Cursors.Default;
            }
        }

        // Token: 0x0600043C RID: 1084 RVA: 0x0001AE58 File Offset: 0x00019058
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (SelectedIndex >= 0 && !IsDrag && ItemKeyDelete && e.KeyCode == Keys.Delete)
            {
                var selectedIndex = SelectedIndex;
                base.Items.RemoveAt(SelectedIndex);
                if (selectedIndex < base.Items.Count)
                {
                    SelectedIndex = selectedIndex;
                    return;
                }
                if (selectedIndex > 0)
                {
                    SelectedIndex = selectedIndex - 1;
                    return;
                }
            }
            else
            {
                base.OnKeyUp(e);
            }
        }

        // Token: 0x04000277 RID: 631
        protected bool IsDrag;

        // Token: 0x04000278 RID: 632
        protected Point _mouseDrag;

        // Token: 0x04000279 RID: 633
        protected Point _mouseLocate;

        // Token: 0x0400027A RID: 634
        protected int _idxDragItem;

        // Token: 0x0400027B RID: 635
        protected object _objDragItem;

        // Token: 0x0400027C RID: 636
        protected bool _dragmove;

        // Token: 0x0400027D RID: 637
        protected bool _delkeyitem;
    }
}
