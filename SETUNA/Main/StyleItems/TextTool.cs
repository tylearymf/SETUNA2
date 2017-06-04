namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class TextTool : PaintTool
    {
        private TextToolCommand cmd;
        private ScrapPaintTextTool frm;
        private AddTextLayerCommand parentCommand;
        private Point StartPoint;
        private string Text;
        private TextArea textbox;
        private Font TextFont;

        public event FontDelegate ChangedFont;

        public event BoolDelegate Editing;

        public TextTool(ScrapPaintWindow parent) : base(parent)
        {
            this.Text = "";
            this.TextFont = new Font("Arial", 10f);
            this.StartPoint = Point.Empty;
            this.parentCommand = null;
            this.cmd = null;
            this.textbox = new TextArea();
            this.ClearCommand();
        }

        protected override void ClearCommand()
        {
            if (this.cmd != null)
            {
                this.cmd.Dispose();
            }
            this.cmd = new TextToolCommand(this.Text, this.TextFont, this.StartPoint);
        }

        public override void Dispose()
        {
            base.Dispose();
            if (this.textbox != null)
            {
                base._parent.Controls.Remove(this.textbox);
                this.textbox.Dispose();
                this.textbox = null;
            }
            this.parentCommand = null;
        }

        public void EditEnd()
        {
            if (base.IsActive)
            {
                if (this.textbox != null)
                {
                    this.TextFont = this.textbox.Font;
                }
                base.End();
                if (this.textbox != null)
                {
                    base._parent.Controls.Remove(this.textbox);
                }
                if (this.Editing != null)
                {
                    this.Editing(false, null);
                }
            }
        }

        protected override ToolCommand GetCommand()
        {
            this.cmd.Parent = this.parentCommand;
            this.cmd.Text = this.textbox.Text;
            this.cmd.Font = this.TextFont;
            return this.cmd;
        }

        public override void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.End();
                base._parent.Controls.Remove(this.textbox);
            }
        }

        public override void MouseUp(MouseEventArgs e)
        {
            if (!base.IsActive)
            {
                this.StartPoint = e.Location;
                this.textbox.Clear();
                this.ResetTextBox();
                this.ClearCommand();
                base.Start();
                this.parentCommand = new AddTextLayerCommand("文字层", base._parent.SelectionLayerIndex());
                base._parent.AddLayerCommand(this.parentCommand);
                this.textbox.Parent = base._parent;
                base._parent.Controls.Add(this.textbox);
                if (this.Editing != null)
                {
                    this.Editing(true, this.textbox);
                }
                this.textbox.Focus();
            }
            else
            {
                this.EditEnd();
            }
        }

        public void ResetTextBox()
        {
            if (this.textbox != null)
            {
                this.textbox.Font = this.TextFont;
                this.textbox.Location = this.StartPoint;
            }
        }

        public void SetFont(Font font)
        {
            this.TextFont = font;
            if (this.ChangedFont != null)
            {
                this.ChangedFont(font);
            }
        }

        public override void ShowToolBar(Form parent)
        {
            base.ShowToolBar(parent);
            this.frm = new ScrapPaintTextTool(this);
            this.frm.Left = parent.Left;
            this.frm.Top = (parent.Top - this.frm.Height) - 20;
            parent.AddOwnedForm(this.frm);
            this.frm.Show();
            parent.AddOwnedForm(this.frm);
        }

        public override ScrapPaintToolBar.ToolKind GetToolType =>
            ScrapPaintToolBar.ToolKind.文字工具;

        public delegate void BoolDelegate(bool value, TextBox edit);

        public delegate void FontDelegate(Font font);

        public class TextArea : TextBox
        {
            public TextArea()
            {
                base.WordWrap = false;
                this.Multiline = true;
                this.Text = "";
                this.AreaResize();
            }

            private void AreaResize()
            {
                base.SuspendLayout();
                base.Size = base.PreferredSize;
                base.ResumeLayout();
            }

            protected override void OnFontChanged(EventArgs e)
            {
                base.OnFontChanged(e);
                this.AreaResize();
            }

            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);
                this.AreaResize();
            }
        }
    }
}

