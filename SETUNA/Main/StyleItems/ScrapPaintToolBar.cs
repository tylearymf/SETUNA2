namespace SETUNA.Main.StyleItems
{
    using Properties;
    using SETUNA.Main.Other;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ScrapPaintToolBar : Form
    {
        private ScrapPaintWindow _parent;
        private PaintTool activeTool;
        private CheckBox chkErase;
        private CheckBox chkPen;
        private CheckBox chkText;
        private ColorDialog colorDialog1;
        private IContainer components;
        private Panel panel1;
        private PictureBox picColorA;
        private PictureBox picColorB;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private List<CheckBox> tools;
        private ToolTip toolTip1;
        private LayerInfo mLayerInfo;

        public event SelectToolDelegate SelectTool;

        public ScrapPaintToolBar(ScrapPaintWindow parent)
        {
            this._parent = parent;
            this.InitializeComponent();
            this.activeTool = null;
            this.tools = new List<CheckBox>();
            this.tools.Add(this.chkPen);
            this.tools.Add(this.chkErase);
            this.tools.Add(this.chkText);
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
        }

        public void ChangeColor()
        {
            Color backColor = this.picColorA.BackColor;
            this.picColorA.BackColor = this.picColorB.BackColor;
            this.picColorB.BackColor = backColor;
        }

        private void chkPen_Click(object sender, EventArgs e)
        {
            CheckBox box = null;
            foreach (CheckBox box2 in this.tools)
            {
                if (box2.Checked)
                {
                    box = box2;
                    break;
                }
            }
            CheckBox box3 = null;
            foreach (CheckBox box4 in this.tools)
            {
                if (box4.Equals(sender))
                {
                    box4.Checked = true;
                    box3 = box4;
                }
                else
                {
                    box4.Checked = false;
                }
            }
            if ((box3 != null) && !box3.Equals(box))
            {
                this.SelecionTool();
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
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.panel1 = new Panel();
            this.picColorA = new PictureBox();
            this.picColorB = new PictureBox();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.chkPen = new CheckBox();
            this.chkText = new CheckBox();
            this.chkErase = new CheckBox();
            this.toolTip1 = new ToolTip(this.components);
            this.colorDialog1 = new ColorDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.picColorA).BeginInit();
            ((ISupportInitialize) this.picColorB).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            base.SuspendLayout();
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 81.70213f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.29787f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel1.Size = new Size(0x2e, 0x107);
            this.tableLayoutPanel1.TabIndex = 0;
            this.panel1.BorderStyle = BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.picColorA);
            this.panel1.Controls.Add(this.picColorB);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(2, 0xd8);
            this.panel1.Margin = new Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x2a, 0x2d);
            this.panel1.TabIndex = 1;
            this.picColorA.BackColor = Color.White;
            this.picColorA.BorderStyle = BorderStyle.FixedSingle;
            this.picColorA.Cursor = Cursors.Hand;
            this.picColorA.Location = new Point(6, 5);
            this.picColorA.Name = "picColorA";
            this.picColorA.Size = new Size(0x1a, 0x1a);
            this.picColorA.TabIndex = 0;
            this.picColorA.TabStop = false;
            this.toolTip1.SetToolTip(this.picColorA, "前景色");
            this.picColorA.BackColorChanged += new EventHandler(this.picColorA_BackColorChanged);
            this.picColorA.Click += new EventHandler(this.picColorA_Click);
            this.picColorB.BackColor = Color.Black;
            this.picColorB.BorderStyle = BorderStyle.FixedSingle;
            this.picColorB.Cursor = Cursors.Hand;
            this.picColorB.Location = new Point(0x16, 0x13);
            this.picColorB.Name = "picColorB";
            this.picColorB.Size = new Size(0x1a, 0x1a);
            this.picColorB.TabIndex = 1;
            this.picColorB.TabStop = false;
            this.toolTip1.SetToolTip(this.picColorB, "背景色");
            this.picColorB.Click += new EventHandler(this.picColorB_Click);
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28f));
            this.tableLayoutPanel2.Controls.Add(this.chkPen, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkText, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkErase, 0, 1);
            this.tableLayoutPanel2.Dock = DockStyle.Fill;
            this.tableLayoutPanel2.Location = new Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel2.Size = new Size(40, 0xd0);
            this.tableLayoutPanel2.TabIndex = 2;
            this.chkPen.Appearance = Appearance.Button;
            this.chkPen.AutoCheck = false;
            this.chkPen.Dock = DockStyle.Fill;
            this.chkPen.FlatStyle = FlatStyle.Popup;
            this.chkPen.Image = Resources.pi_pen;
            this.chkPen.ImageAlign = ContentAlignment.BottomCenter;
            this.chkPen.Location = new Point(1, 1);
            this.chkPen.Margin = new Padding(1);
            this.chkPen.Name = "chkPen";
            this.chkPen.Size = new Size(0x26, 0x1c);
            this.chkPen.TabIndex = 4;
            this.toolTip1.SetToolTip(this.chkPen, "笔工具");
            this.chkPen.UseVisualStyleBackColor = true;
            this.chkPen.Click += new EventHandler(this.chkPen_Click);
            this.chkText.Appearance = Appearance.Button;
            this.chkText.AutoCheck = false;
            this.chkText.Dock = DockStyle.Fill;
            this.chkText.FlatStyle = FlatStyle.Popup;
            this.chkText.Image = Resources.pi_text;
            this.chkText.ImageAlign = ContentAlignment.BottomCenter;
            this.chkText.Location = new Point(1, 0x3d);
            this.chkText.Margin = new Padding(1);
            this.chkText.Name = "chkText";
            this.chkText.Size = new Size(0x26, 0x1c);
            this.chkText.TabIndex = 8;
            this.toolTip1.SetToolTip(this.chkText, "文本工具");
            this.chkText.UseVisualStyleBackColor = true;
            this.chkText.Click += new EventHandler(this.chkPen_Click);
            this.chkErase.Appearance = Appearance.Button;
            this.chkErase.AutoCheck = false;
            this.chkErase.Dock = DockStyle.Fill;
            this.chkErase.FlatStyle = FlatStyle.Popup;
            this.chkErase.Image = Resources.pi_erase;
            this.chkErase.ImageAlign = ContentAlignment.BottomCenter;
            this.chkErase.Location = new Point(1, 0x1f);
            this.chkErase.Margin = new Padding(1);
            this.chkErase.Name = "chkErase";
            this.chkErase.Size = new Size(0x26, 0x1c);
            this.chkErase.TabIndex = 5;
            this.toolTip1.SetToolTip(this.chkErase, "橡皮擦工具");
            this.chkErase.UseVisualStyleBackColor = true;
            this.chkErase.Click += new EventHandler(this.chkPen_Click);
            this.colorDialog1.FullOpen = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(50, 0x120);
            base.ControlBox = false;
            base.Controls.Add(this.tableLayoutPanel1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.KeyPreview = true;
            this.MinimumSize = new Size(0x34, 290);
            base.Name = "ScrapPaintToolBar";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "工具";
            base.TopMost = true;
            base.FormClosing += new FormClosingEventHandler(this.ScrapPaintToolBar_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((ISupportInitialize) this.picColorA).EndInit();
            ((ISupportInitialize) this.picColorB).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void OnSelectTool(PaintTool tool)
        {
            this.activeTool = tool;
            if (this.activeTool != null)
            {
                this.activeTool.ShowToolBar(this._parent);
                this._parent.Activate();
            }
            if (this.SelectTool != null)
            {
                this.SelectTool(tool);
            }
        }

        private void picColorA_BackColorChanged(object sender, EventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ChangeColor(this.ColorA);
            }
        }

        private void picColorA_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = this.picColorA.BackColor;
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.picColorA.BackColor = this.colorDialog1.Color;
            }
        }

        private void picColorB_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = this.picColorB.BackColor;
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.picColorB.BackColor = this.colorDialog1.Color;
            }
        }

        private void ScrapPaintToolBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void SelecionTool()
        {
            if (this.chkPen.Checked)
            {
                this.OnSelectTool(new PenTool(this.ColorA, this._parent));
            }
            else if (this.chkErase.Checked)
            {
                this.OnSelectTool(new PenTool(PenTool.EraseColor, this._parent));
            }
            else if (this.chkText.Checked)
            {
                this.OnSelectTool(new TextTool(this._parent));
            }
            else
            {
                this.OnSelectTool(null);
            }
        }

        public void SwitchTool(ToolKind kind)
        {
            switch (kind)
            {
                case ToolKind.笔工具:
                    this.chkPen_Click(this.chkPen, null);
                    return;

                case ToolKind.消しゴム工具:
                    this.chkPen_Click(this.chkErase, null);
                    return;

                case ToolKind.文字工具:
                    this.chkPen_Click(this.chkText, null);
                    return;
            }
        }

        public Color ColorA
        {
            get{return  
                this.picColorA.BackColor;}
            set
            {
                this.picColorA.BackColor = value;
            }
        }

        public Color ColorB
        {
            get{return  
                this.picColorB.BackColor;}
            set
            {
                this.picColorB.BackColor = value;
            }
        }

        public delegate void SelectToolDelegate(PaintTool tool);

        public enum ToolKind
        {
            笔工具,
            消しゴム工具,
            文字工具
        }
    }
}

