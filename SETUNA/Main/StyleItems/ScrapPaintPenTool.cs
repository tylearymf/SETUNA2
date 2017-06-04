namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class ScrapPaintPenTool : Form
    {
        private PenTool _pentool;
        private ComboBox cmbStart;
        private IContainer components;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown numOpacity;
        private NumericUpDown numPenSize;
        private PenButton penButton1;
        private PenButton penButton2;
        private PenButton penButton3;
        private PenButton penButton4;
        private PenButton penButton5;
        private List<PenButton> penButtons;
        private Panel pnlCap;
        private Panel pnlOpacity;
        private Panel pnlPen;
        private ToolTip toolTip1;

        public ScrapPaintPenTool(PenTool penTool)
        {
            this.InitializeComponent();
            this.penButtons = new List<PenButton>();
            this.penButtons.Add(this.penButton1);
            this.penButtons.Add(this.penButton2);
            this.penButtons.Add(this.penButton3);
            this.penButtons.Add(this.penButton4);
            this.penButtons.Add(this.penButton5);
            foreach (LineCap cap in Enum.GetValues(typeof(LineCap)))
            {
                this.cmbStart.Items.Add(cap);
            }
            this.cmbStart.SelectedItem = LineCap.NoAnchor;
            this._pentool = penTool;
            this.penButton1_Click(this.penButton2, null);
        }

        public ScrapPaintPenTool(PenTool penTool, bool erasemode) : this(penTool)
        {
            if (erasemode)
            {
                this.Text = "橡皮擦工具";
                this.pnlOpacity.Visible = false;
                this.pnlCap.Visible = false;
                foreach (PenButton button in this.penButtons)
                {
                    button.ButtonColor = Color.FromArgb(0x5f, 0xa8, 0xef);
                }
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
            this.numPenSize = new NumericUpDown();
            this.label4 = new Label();
            this.label3 = new Label();
            this.pnlOpacity = new Panel();
            this.numOpacity = new NumericUpDown();
            this.label1 = new Label();
            this.label2 = new Label();
            this.pnlCap = new Panel();
            this.cmbStart = new ComboBox();
            this.toolTip1 = new ToolTip(this.components);
            this.penButton5 = new PenButton();
            this.penButton4 = new PenButton();
            this.penButton3 = new PenButton();
            this.penButton2 = new PenButton();
            this.penButton1 = new PenButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlPen.SuspendLayout();
            this.numPenSize.BeginInit();
            this.pnlOpacity.SuspendLayout();
            this.numOpacity.BeginInit();
            this.pnlCap.SuspendLayout();
            base.SuspendLayout();
            this.flowLayoutPanel1.Controls.Add(this.pnlPen);
            this.flowLayoutPanel1.Controls.Add(this.pnlOpacity);
            this.flowLayoutPanel1.Controls.Add(this.pnlCap);
            this.flowLayoutPanel1.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.Location = new Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new Size(0x1ce, 0x39);
            this.flowLayoutPanel1.TabIndex = 0;
            this.pnlPen.Controls.Add(this.numPenSize);
            this.pnlPen.Controls.Add(this.label4);
            this.pnlPen.Controls.Add(this.label3);
            this.pnlPen.Controls.Add(this.penButton5);
            this.pnlPen.Controls.Add(this.penButton4);
            this.pnlPen.Controls.Add(this.penButton3);
            this.pnlPen.Controls.Add(this.penButton2);
            this.pnlPen.Controls.Add(this.penButton1);
            this.pnlPen.Location = new Point(0, 0);
            this.pnlPen.Margin = new Padding(0);
            this.pnlPen.Name = "pnlPen";
            this.pnlPen.Size = new Size(0xd9, 0x23);
            this.pnlPen.TabIndex = 0;
            this.numPenSize.Location = new Point(0xa1, 13);
            int[] bits = new int[4];
            bits[0] = 200;
            this.numPenSize.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 1;
            this.numPenSize.Minimum = new decimal(numArray2);
            this.numPenSize.Name = "numPenSize";
            this.numPenSize.Size = new Size(0x24, 0x13);
            this.numPenSize.TabIndex = 10;
            this.numPenSize.TabStop = false;
            this.numPenSize.TextAlign = HorizontalAlignment.Right;
            this.numPenSize.UpDownAlign = LeftRightAlignment.Left;
            int[] numArray3 = new int[4];
            numArray3[0] = 1;
            this.numPenSize.Value = new decimal(numArray3);
            this.numPenSize.ValueChanged += new EventHandler(this.numPenSize_ValueChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0xc6, 0x10);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x11, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "px";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("宋体", 7f, FontStyle.Regular, GraphicsUnit.Point, 0x80);
            this.label3.Location = new Point(160, 2);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1c, 10);
            this.label3.TabIndex = 11;
            this.label3.Text = "尺寸";
            this.pnlOpacity.Controls.Add(this.numOpacity);
            this.pnlOpacity.Controls.Add(this.label1);
            this.pnlOpacity.Controls.Add(this.label2);
            this.pnlOpacity.Location = new Point(0xd9, 0);
            this.pnlOpacity.Margin = new Padding(0);
            this.pnlOpacity.Name = "pnlOpacity";
            this.pnlOpacity.Size = new Size(0x3a, 0x23);
            this.pnlOpacity.TabIndex = 1;
            this.numOpacity.Location = new Point(3, 13);
            int[] numArray4 = new int[4];
            numArray4[0] = 1;
            this.numOpacity.Minimum = new decimal(numArray4);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new Size(40, 0x13);
            this.numOpacity.TabIndex = 0;
            this.numOpacity.TabStop = false;
            this.numOpacity.TextAlign = HorizontalAlignment.Right;
            this.numOpacity.UpDownAlign = LeftRightAlignment.Left;
            int[] numArray5 = new int[4];
            numArray5[0] = 100;
            this.numOpacity.Value = new decimal(numArray5);
            this.numOpacity.ValueChanged += new EventHandler(this.numOpacity_ValueChanged);
            this.label1.AutoSize = true;
            this.label1.Font = new Font("宋体", 7f, FontStyle.Regular, GraphicsUnit.Point, 0x80);
            this.label1.Location = new Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2d, 10);
            this.label1.TabIndex = 1;
            this.label1.Text = "不透明度";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x2c, 0x11);
            this.label2.Name = "label2";
            this.label2.Size = new Size(11, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            this.pnlCap.Controls.Add(this.cmbStart);
            this.pnlCap.Location = new Point(0x113, 0);
            this.pnlCap.Margin = new Padding(0);
            this.pnlCap.Name = "pnlCap";
            this.pnlCap.Size = new Size(0x9f, 0x23);
            this.pnlCap.TabIndex = 2;
            this.cmbStart.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStart.FormattingEnabled = true;
            this.cmbStart.Location = new Point(3, 13);
            this.cmbStart.Name = "cmbStart";
            this.cmbStart.Size = new Size(0x74, 20);
            this.cmbStart.TabIndex = 0;
            this.cmbStart.TabStop = false;
            this.penButton5.Appearance = Appearance.Button;
            this.penButton5.AutoCheck = false;
            this.penButton5.ButtonColor = Color.Black;
            this.penButton5.Location = new Point(0x7f, 4);
            this.penButton5.Name = "penButton5";
            this.penButton5.PenSize = 20;
            this.penButton5.Size = new Size(0x1f, 0x1d);
            this.penButton5.TabIndex = 9;
            this.toolTip1.SetToolTip(this.penButton5, "20px");
            this.penButton5.UseVisualStyleBackColor = true;
            this.penButton5.Click += new EventHandler(this.penButton1_Click);
            this.penButton4.Appearance = Appearance.Button;
            this.penButton4.AutoCheck = false;
            this.penButton4.ButtonColor = Color.Black;
            this.penButton4.Location = new Point(0x60, 4);
            this.penButton4.Name = "penButton4";
            this.penButton4.PenSize = 15;
            this.penButton4.Size = new Size(0x1f, 0x1d);
            this.penButton4.TabIndex = 8;
            this.toolTip1.SetToolTip(this.penButton4, "15px");
            this.penButton4.UseVisualStyleBackColor = true;
            this.penButton4.Click += new EventHandler(this.penButton1_Click);
            this.penButton3.Appearance = Appearance.Button;
            this.penButton3.AutoCheck = false;
            this.penButton3.ButtonColor = Color.Black;
            this.penButton3.Location = new Point(0x41, 4);
            this.penButton3.Name = "penButton3";
            this.penButton3.PenSize = 10;
            this.penButton3.Size = new Size(0x1f, 0x1d);
            this.penButton3.TabIndex = 7;
            this.toolTip1.SetToolTip(this.penButton3, "10px");
            this.penButton3.UseVisualStyleBackColor = true;
            this.penButton3.Click += new EventHandler(this.penButton1_Click);
            this.penButton2.Appearance = Appearance.Button;
            this.penButton2.AutoCheck = false;
            this.penButton2.ButtonColor = Color.Black;
            this.penButton2.Location = new Point(0x22, 4);
            this.penButton2.Name = "penButton2";
            this.penButton2.PenSize = 5;
            this.penButton2.Size = new Size(0x1f, 0x1d);
            this.penButton2.TabIndex = 6;
            this.toolTip1.SetToolTip(this.penButton2, "5px");
            this.penButton2.UseVisualStyleBackColor = true;
            this.penButton2.Click += new EventHandler(this.penButton1_Click);
            this.penButton1.Appearance = Appearance.Button;
            this.penButton1.AutoCheck = false;
            this.penButton1.ButtonColor = Color.Black;
            this.penButton1.Location = new Point(3, 4);
            this.penButton1.Name = "penButton1";
            this.penButton1.PenSize = 1;
            this.penButton1.Size = new Size(0x1f, 0x1d);
            this.penButton1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.penButton1, "1px");
            this.penButton1.UseVisualStyleBackColor = true;
            this.penButton1.Click += new EventHandler(this.penButton1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1ce, 0x39);
            base.ControlBox = false;
            base.Controls.Add(this.flowLayoutPanel1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new Size(0x124, 0x3b);
            base.Name = "ScrapPaintPenTool";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "笔工具";
            base.TopMost = true;
            base.FormClosing += new FormClosingEventHandler(this.ScrapPaintPenTool_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlPen.ResumeLayout(false);
            this.pnlPen.PerformLayout();
            this.numPenSize.EndInit();
            this.pnlOpacity.ResumeLayout(false);
            this.pnlOpacity.PerformLayout();
            this.numOpacity.EndInit();
            this.pnlCap.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void numOpacity_ValueChanged(object sender, EventArgs e)
        {
            int num = (0xff * ((int) this.numOpacity.Value)) / 100;
            this._pentool.Opacity = num;
            this._pentool.ReloadCommand();
        }

        private void numPenSize_ValueChanged(object sender, EventArgs e)
        {
            this._pentool.PenWidth = (float) this.numPenSize.Value;
            this._pentool.ReloadCommand();
            foreach (PenButton button in this.penButtons)
            {
                if (button.PenSize == ((int) this.numPenSize.Value))
                {
                    button.Checked = true;
                }
                else
                {
                    button.Checked = false;
                }
            }
        }

        private void penButton1_Click(object sender, EventArgs e)
        {
            PenButton button = (PenButton) sender;
            this.numPenSize.Value = button.PenSize;
        }

        private void ScrapPaintPenTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
    }
}

