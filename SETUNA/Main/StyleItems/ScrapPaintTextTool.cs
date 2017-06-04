namespace SETUNA.Main.StyleItems
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class ScrapPaintTextTool : Form
    {
        private TextBox _edit;
        private TextTool _texttool;
        private Button btnEditCancel;
        private Button btnEditOK;
        private ComboBox cmbFont;
        private IContainer components;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown numFontSize;
        private Panel pnlEditing;
        private Panel pnlPen;
        private ToolTip toolTip1;

        public ScrapPaintTextTool(TextTool textTool)
        {
            this.InitializeComponent();
            this.pnlEditing.Visible = false;
            this._texttool = textTool;
            this._edit = null;
            this._texttool.Editing += new TextTool.BoolDelegate(this._texttool_Editing);
            this._texttool.ChangedFont += new TextTool.FontDelegate(this.SetFont);
        }

        private void _texttool_Editing(bool value, TextBox edit)
        {
            this.pnlEditing.Visible = value;
            this._edit = edit;
        }

        private void btnEditOK_Click(object sender, EventArgs e)
        {
            this._texttool.EditEnd();
        }

        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pnlEditing.Visible && (this._edit != null))
            {
                this._edit.Font = new Font((string) this.cmbFont.SelectedItem, this._edit.Font.Size);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.pnlPen = new Panel();
            this.cmbFont = new ComboBox();
            this.label5 = new Label();
            this.numFontSize = new NumericUpDown();
            this.label4 = new Label();
            this.label3 = new Label();
            this.toolTip1 = new ToolTip(this.components);
            this.pnlEditing = new Panel();
            this.btnEditOK = new Button();
            this.btnEditCancel = new Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlPen.SuspendLayout();
            this.numFontSize.BeginInit();
            this.pnlEditing.SuspendLayout();
            base.SuspendLayout();
            this.flowLayoutPanel1.Controls.Add(this.pnlPen);
            this.flowLayoutPanel1.Controls.Add(this.pnlEditing);
            this.flowLayoutPanel1.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.Location = new Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(0x1c3, 0x39);
            this.flowLayoutPanel1.TabIndex = 0;
            this.pnlPen.Controls.Add(this.cmbFont);
            this.pnlPen.Controls.Add(this.label5);
            this.pnlPen.Controls.Add(this.numFontSize);
            this.pnlPen.Controls.Add(this.label4);
            this.pnlPen.Controls.Add(this.label3);
            this.pnlPen.Location = new Point(0, 0);
            this.pnlPen.Margin = new Padding(0);
            this.pnlPen.Name = "pnlPen";
            this.pnlPen.Size = new Size(0x116, 0x23);
            this.pnlPen.TabIndex = 0;
            this.cmbFont.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFont.DropDownWidth = 230;
            this.cmbFont.FormattingEnabled = true;
            this.cmbFont.Location = new Point(3, 13);
            this.cmbFont.Name = "cmbFont";
            this.cmbFont.Size = new Size(170, 20);
            this.cmbFont.TabIndex = 14;
            this.cmbFont.SelectedIndexChanged += new EventHandler(this.cmbFont_SelectedIndexChanged);
            this.label5.AutoSize = true;
            this.label5.Font = new Font("宋体", 7f, FontStyle.Regular, GraphicsUnit.Point, 0x80);
            this.label5.Location = new Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x21, 10);
            this.label5.TabIndex = 13;
            this.label5.Text = "字体";
            this.numFontSize.Location = new Point(0xc5, 13);
            int[] bits = new int[4];
            bits[0] = 200;
            this.numFontSize.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 1;
            this.numFontSize.Minimum = new decimal(numArray2);
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new Size(0x36, 0x13);
            this.numFontSize.TabIndex = 10;
            this.numFontSize.TabStop = false;
            this.numFontSize.TextAlign = HorizontalAlignment.Right;
            this.numFontSize.UpDownAlign = LeftRightAlignment.Left;
            int[] numArray3 = new int[4];
            numArray3[0] = 1;
            this.numFontSize.Value = new decimal(numArray3);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0xfc, 0x10);
            this.label4.Name = "label4";
            this.label4.Size = new Size(15, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "pt";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("宋体", 7f, FontStyle.Regular, GraphicsUnit.Point, 0x80);
            this.label3.Location = new Point(0xc3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1c, 10);
            this.label3.TabIndex = 11;
            this.label3.Text = "尺寸";
            this.pnlEditing.Controls.Add(this.btnEditCancel);
            this.pnlEditing.Controls.Add(this.btnEditOK);
            this.pnlEditing.Location = new Point(0x116, 0);
            this.pnlEditing.Margin = new Padding(0);
            this.pnlEditing.Name = "pnlEditing";
            this.pnlEditing.Size = new Size(0x41, 0x23);
            this.pnlEditing.TabIndex = 1;
            this.btnEditOK.Location = new Point(3, 9);
            this.btnEditOK.Name = "btnEditOK";
            this.btnEditOK.Size = new Size(0x1c, 0x17);
            this.btnEditOK.TabIndex = 0;
            this.btnEditOK.Text = "○";
            this.btnEditOK.UseVisualStyleBackColor = true;
            this.btnEditOK.Click += new EventHandler(this.btnEditOK_Click);
            this.btnEditCancel.Location = new Point(0x20, 9);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new Size(0x1c, 0x17);
            this.btnEditCancel.TabIndex = 1;
            this.btnEditCancel.Text = "\x00d7";
            this.btnEditCancel.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1c3, 0x39);
            base.ControlBox = false;
            base.Controls.Add(this.flowLayoutPanel1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new Size(0x124, 0x3b);
            base.Name = "ScrapPaintTextTool";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "文字工具";
            base.TopMost = true;
            base.Shown += new EventHandler(this.ScrapPaintTextTool_Shown);
            base.FormClosing += new FormClosingEventHandler(this.ScrapPaintTextTool_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlPen.ResumeLayout(false);
            this.pnlPen.PerformLayout();
            this.numFontSize.EndInit();
            this.pnlEditing.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void ScrapPaintTextTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void ScrapPaintTextTool_Shown(object sender, EventArgs e)
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                this.cmbFont.Items.Add(family.Name);
            }
        }

        public void SetFont(Font font)
        {
            this.cmbFont.SelectedItem = font.Name;
            this.numFontSize.Value = (decimal) font.Size;
            this._texttool.ReloadCommand();
        }
    }
}

