using System;
using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200009A RID: 154
    public class TextTool : PaintTool
    {
        // Token: 0x14000018 RID: 24
        // (add) Token: 0x06000512 RID: 1298 RVA: 0x000241F3 File Offset: 0x000223F3
        // (remove) Token: 0x06000513 RID: 1299 RVA: 0x0002420C File Offset: 0x0002240C
        public event TextTool.BoolDelegate Editing;

        // Token: 0x14000019 RID: 25
        // (add) Token: 0x06000514 RID: 1300 RVA: 0x00024225 File Offset: 0x00022425
        // (remove) Token: 0x06000515 RID: 1301 RVA: 0x0002423E File Offset: 0x0002243E
        public event TextTool.FontDelegate ChangedFont;

        // Token: 0x06000516 RID: 1302 RVA: 0x00024258 File Offset: 0x00022458
        public TextTool(ScrapPaintWindow parent) : base(parent)
        {
            Text = "";
            TextFont = new Font("Arial", 10f);
            StartPoint = Point.Empty;
            parentCommand = null;
            cmd = null;
            textbox = new TextTool.TextArea();
            ClearCommand();
        }

        // Token: 0x06000517 RID: 1303 RVA: 0x000242B6 File Offset: 0x000224B6
        protected override ToolCommand GetCommand()
        {
            cmd.Parent = parentCommand;
            cmd.Text = textbox.Text;
            cmd.Font = TextFont;
            return cmd;
        }

        // Token: 0x06000518 RID: 1304 RVA: 0x000242F6 File Offset: 0x000224F6
        protected override void ClearCommand()
        {
            if (cmd != null)
            {
                cmd.Dispose();
            }
            cmd = new TextToolCommand(Text, TextFont, StartPoint);
        }

        // Token: 0x06000519 RID: 1305 RVA: 0x00024328 File Offset: 0x00022528
        public override void MouseUp(MouseEventArgs e)
        {
            if (!base.IsActive)
            {
                StartPoint = e.Location;
                textbox.Clear();
                ResetTextBox();
                ClearCommand();
                base.Start();
                parentCommand = new AddTextLayerCommand("文字层", _parent.SelectionLayerIndex());
                _parent.AddLayerCommand(parentCommand);
                textbox.Parent = _parent;
                _parent.Controls.Add(textbox);
                if (Editing != null)
                {
                    Editing(true, textbox);
                }
                textbox.Focus();
                return;
            }
            EditEnd();
        }

        // Token: 0x0600051A RID: 1306 RVA: 0x000243EC File Offset: 0x000225EC
        public void EditEnd()
        {
            if (base.IsActive)
            {
                if (textbox != null)
                {
                    TextFont = textbox.Font;
                }
                base.End();
                if (textbox != null)
                {
                    _parent.Controls.Remove(textbox);
                }
                if (Editing != null)
                {
                    Editing(false, null);
                }
            }
        }

        // Token: 0x0600051B RID: 1307 RVA: 0x00024453 File Offset: 0x00022653
        public override void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                base.End();
                _parent.Controls.Remove(textbox);
            }
        }

        // Token: 0x0600051C RID: 1308 RVA: 0x0002447B File Offset: 0x0002267B
        public void ResetTextBox()
        {
            if (textbox != null)
            {
                textbox.Font = TextFont;
                textbox.Location = StartPoint;
            }
        }

        // Token: 0x0600051D RID: 1309 RVA: 0x000244A7 File Offset: 0x000226A7
        public override void Dispose()
        {
            base.Dispose();
            if (textbox != null)
            {
                _parent.Controls.Remove(textbox);
                textbox.Dispose();
                textbox = null;
            }
            parentCommand = null;
        }

        // Token: 0x170000B7 RID: 183
        // (get) Token: 0x0600051E RID: 1310 RVA: 0x000244E6 File Offset: 0x000226E6
        public override ScrapPaintToolBar.ToolKind GetToolType => ScrapPaintToolBar.ToolKind.文字工具;

        // Token: 0x0600051F RID: 1311 RVA: 0x000244EC File Offset: 0x000226EC
        public override void ShowToolBar(Form parent)
        {
            base.ShowToolBar(parent);
            frm = new ScrapPaintTextTool(this)
            {
                Left = parent.Left
            };
            frm.Top = parent.Top - frm.Height - 20;
            parent.AddOwnedForm(frm);
            frm.Show();
            parent.AddOwnedForm(frm);
        }

        // Token: 0x06000520 RID: 1312 RVA: 0x00024560 File Offset: 0x00022760
        public void SetFont(Font font)
        {
            TextFont = font;
            if (ChangedFont != null)
            {
                ChangedFont(font);
            }
        }

        // Token: 0x04000342 RID: 834
        private string Text;

        // Token: 0x04000343 RID: 835
        private Font TextFont;

        // Token: 0x04000344 RID: 836
        private Point StartPoint;

        // Token: 0x04000345 RID: 837
        private AddTextLayerCommand parentCommand;

        // Token: 0x04000346 RID: 838
        private TextToolCommand cmd;

        // Token: 0x04000347 RID: 839
        private TextTool.TextArea textbox;

        // Token: 0x04000348 RID: 840
        private ScrapPaintTextTool frm;

        // Token: 0x0200009B RID: 155
        // (Invoke) Token: 0x06000522 RID: 1314
        public delegate void BoolDelegate(bool value, TextBox edit);

        // Token: 0x0200009C RID: 156
        // (Invoke) Token: 0x06000526 RID: 1318
        public delegate void FontDelegate(Font font);

        // Token: 0x0200009D RID: 157
        public class TextArea : TextBox
        {
            // Token: 0x06000529 RID: 1321 RVA: 0x0002457D File Offset: 0x0002277D
            public TextArea()
            {
                base.WordWrap = false;
                Multiline = true;
                Text = "";
                AreaResize();
            }

            // Token: 0x0600052A RID: 1322 RVA: 0x000245A4 File Offset: 0x000227A4
            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);
                AreaResize();
            }

            // Token: 0x0600052B RID: 1323 RVA: 0x000245B3 File Offset: 0x000227B3
            protected override void OnFontChanged(EventArgs e)
            {
                base.OnFontChanged(e);
                AreaResize();
            }

            // Token: 0x0600052C RID: 1324 RVA: 0x000245C2 File Offset: 0x000227C2
            private void AreaResize()
            {
                base.SuspendLayout();
                base.Size = base.PreferredSize;
                base.ResumeLayout();
            }
        }
    }
}
