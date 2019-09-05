namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main.Other;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    internal class ScaleStyleItemPanel : ToolBoxForm
    {
        private TrackBar barFixed;
        private TrackBar barRelative;
        private ComboBox cmbInterpolation;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblInterpolation;
        private NumericUpDown numFixedScale;
        private NumericUpDown numRelativeScale;
        private RadioButton rdoFixed;
        private RadioButton rdoIncrement;
        private LayerInfo mLayerInfo;

        public ScaleStyleItemPanel(CScaleStyleItem item) : base(item)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
        }

        private void barFixed_Scroll(object sender, EventArgs e)
        {
            if (this.barFixed.Value != this.numFixedScale.Value)
            {
                this.numFixedScale.Value = this.barFixed.Value;
            }
            if (this.barRelative.Value != this.numRelativeScale.Value)
            {
                this.numRelativeScale.Value = this.barRelative.Value;
            }
        }

        protected override object GetStyleFromForm()
        {
            CScaleStyleItem item = new CScaleStyleItem();
            if (this.rdoFixed.Checked)
            {
                item.Value = (int) this.numFixedScale.Value;
            }
            else
            {
                item.Value = (int) this.numRelativeScale.Value;
            }
            item.SetType = this.rdoFixed.Checked ? CScaleStyleItem.ScaleSetType.Fixed : CScaleStyleItem.ScaleSetType.Increment;
            item.InterpolationMode = ((ComboItem<InterpolationMode>) this.cmbInterpolation.SelectedItem).Item;
            return item;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.lblInterpolation = new Label();
            this.cmbInterpolation = new ComboBox();
            this.label3 = new Label();
            this.numRelativeScale = new NumericUpDown();
            this.barRelative = new TrackBar();
            this.label2 = new Label();
            this.barFixed = new TrackBar();
            this.rdoIncrement = new RadioButton();
            this.rdoFixed = new RadioButton();
            this.label1 = new Label();
            this.numFixedScale = new NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.numRelativeScale.BeginInit();
            this.barRelative.BeginInit();
            this.barFixed.BeginInit();
            this.numFixedScale.BeginInit();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0xc5, 0xbd);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x111, 0xbd);
            this.groupBox1.Controls.Add(this.lblInterpolation);
            this.groupBox1.Controls.Add(this.cmbInterpolation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numRelativeScale);
            this.groupBox1.Controls.Add(this.barRelative);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.barFixed);
            this.groupBox1.Controls.Add(this.rdoIncrement);
            this.groupBox1.Controls.Add(this.rdoFixed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numFixedScale);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x14f, 0xad);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.lblInterpolation.AccessibleDescription = "";
            this.lblInterpolation.AutoSize = true;
            this.lblInterpolation.Location = new Point(0x1c, 0x7f);
            this.lblInterpolation.Name = "lblInterpolation";
            this.lblInterpolation.Size = new Size(0x37, 12);
            this.lblInterpolation.TabIndex = 9;
            this.lblInterpolation.Text = "插值方法：";
            this.cmbInterpolation.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbInterpolation.FormattingEnabled = true;
            this.cmbInterpolation.Location = new Point(0x6b, 0x7c);
            this.cmbInterpolation.Name = "cmbInterpolation";
            this.cmbInterpolation.Size = new Size(0xb1, 20);
            this.cmbInterpolation.TabIndex = 10;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(290, 0x52);
            this.label3.Name = "label3";
            this.label3.Size = new Size(11, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "%";
            this.numRelativeScale.ImeMode = ImeMode.Off;
            this.numRelativeScale.Location = new Point(0xec, 80);
            int[] bits = new int[4];
            bits[0] = 200;
            this.numRelativeScale.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 200;
            numArray2[3] = -2147483648;
            this.numRelativeScale.Minimum = new decimal(numArray2);
            this.numRelativeScale.Name = "numRelativeScale";
            this.numRelativeScale.Size = new Size(0x30, 0x13);
            this.numRelativeScale.TabIndex = 7;
            this.numRelativeScale.ValueChanged += new EventHandler(this.numFixedScale_ValueChanged);
            this.barRelative.AutoSize = false;
            this.barRelative.Location = new Point(0x6b, 80);
            this.barRelative.Maximum = 190;
            this.barRelative.Minimum = -190;
            this.barRelative.Name = "barRelative";
            this.barRelative.Size = new Size(0x7b, 20);
            this.barRelative.TabIndex = 6;
            this.barRelative.TickFrequency = 20;
            this.barRelative.Scroll += new EventHandler(this.barFixed_Scroll);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(290, 0x34);
            this.label2.Name = "label2";
            this.label2.Size = new Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "%";
            this.barFixed.AutoSize = false;
            this.barFixed.Location = new Point(0x6b, 50);
            this.barFixed.Maximum = 200;
            this.barFixed.Minimum = 10;
            this.barFixed.Name = "barFixed";
            this.barFixed.Size = new Size(0x7b, 20);
            this.barFixed.TabIndex = 2;
            this.barFixed.TickFrequency = 10;
            this.barFixed.Value = 100;
            this.barFixed.Scroll += new EventHandler(this.barFixed_Scroll);
            this.rdoIncrement.AutoSize = true;
            this.rdoIncrement.Location = new Point(0x2a, 80);
            this.rdoIncrement.Name = "rdoIncrement";
            this.rdoIncrement.Size = new Size(0x3b, 0x10);
            this.rdoIncrement.TabIndex = 5;
            this.rdoIncrement.Text = "相对值";
            this.rdoIncrement.UseVisualStyleBackColor = true;
            this.rdoIncrement.CheckedChanged += new EventHandler(this.rdoFixed_CheckedChanged);
            this.rdoFixed.AutoSize = true;
            this.rdoFixed.Checked = true;
            this.rdoFixed.Location = new Point(0x2a, 50);
            this.rdoFixed.Name = "rdoFixed";
            this.rdoFixed.Size = new Size(0x3b, 0x10);
            this.rdoFixed.TabIndex = 1;
            this.rdoFixed.TabStop = true;
            this.rdoFixed.Text = "绝对值";
            this.rdoFixed.UseVisualStyleBackColor = true;
            this.rdoFixed.CheckedChanged += new EventHandler(this.rdoFixed_CheckedChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x1c, 0x1f);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2d, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "尺度∶";
            this.numFixedScale.ImeMode = ImeMode.Off;
            this.numFixedScale.Location = new Point(0xec, 50);
            int[] numArray3 = new int[4];
            numArray3[0] = 200;
            this.numFixedScale.Maximum = new decimal(numArray3);
            int[] numArray4 = new int[4];
            numArray4[0] = 200;
            numArray4[3] = -2147483648;
            this.numFixedScale.Minimum = new decimal(numArray4);
            this.numFixedScale.Name = "numFixedScale";
            this.numFixedScale.Size = new Size(0x30, 0x13);
            this.numFixedScale.TabIndex = 3;
            this.numFixedScale.ValueChanged += new EventHandler(this.numFixedScale_ValueChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x15f, 0xdd);
            base.Controls.Add(this.groupBox1);
            base.Name = "ScaleStyleItemPanel";
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.numRelativeScale.EndInit();
            this.barRelative.EndInit();
            this.barFixed.EndInit();
            this.numFixedScale.EndInit();
            base.ResumeLayout(false);
        }

        private void numFixedScale_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.barFixed.Value = (int) this.numFixedScale.Value;
                this.barRelative.Value = (int) this.numRelativeScale.Value;
            }
            catch
            {
            }
        }

        private void rdoFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoFixed.Checked)
            {
                this.barFixed.Enabled = true;
                this.numFixedScale.Enabled = true;
                this.barRelative.Enabled = false;
                this.numRelativeScale.Enabled = false;
            }
            else
            {
                this.barFixed.Enabled = false;
                this.numFixedScale.Enabled = false;
                this.barRelative.Enabled = true;
                this.numRelativeScale.Enabled = true;
            }
        }

        protected override void SetStyleToForm(object style)
        {
            CScaleStyleItem item = (CScaleStyleItem) style;
            this.InitializeComponent();
            this.cmbInterpolation.Items.Clear();
            this.cmbInterpolation.Items.Add(new ComboItem<InterpolationMode>("不要更改", InterpolationMode.Invalid));
            this.cmbInterpolation.Items.Add(new ComboItem<InterpolationMode>("最近邻法", InterpolationMode.NearestNeighbor));
            this.cmbInterpolation.Items.Add(new ComboItem<InterpolationMode>("标准", InterpolationMode.High));
            this.cmbInterpolation.Items.Add(new ComboItem<InterpolationMode>("双线性", InterpolationMode.HighQualityBilinear));
            this.cmbInterpolation.Items.Add(new ComboItem<InterpolationMode>("两次立方", InterpolationMode.HighQualityBicubic));
            this.Text = item.GetDisplayName();
            this.numFixedScale.Minimum = 10M;
            this.numFixedScale.Maximum = 200M;
            this.barFixed.Minimum = 10;
            this.barFixed.Maximum = 200;
            this.numRelativeScale.Minimum = -190M;
            this.numRelativeScale.Maximum = 190M;
            this.barRelative.Minimum = -190;
            this.barRelative.Maximum = 190;
            this.numFixedScale.Value = 100M;
            this.barFixed.Value = 100;
            this.numRelativeScale.Value = 0M;
            this.barRelative.Value = 0;
            this.rdoFixed.Checked = item.SetType == CScaleStyleItem.ScaleSetType.Fixed;
            this.rdoIncrement.Checked = item.SetType == CScaleStyleItem.ScaleSetType.Increment;
            this.rdoFixed_CheckedChanged(this, null);
            if (this.rdoFixed.Checked)
            {
                this.numFixedScale.Value = item.Value;
            }
            else
            {
                this.numRelativeScale.Value = item.Value;
            }
            this.cmbInterpolation.SelectedIndex = 0;
            foreach (ComboItem<InterpolationMode> item2 in this.cmbInterpolation.Items)
            {
                if (((InterpolationMode) item2.Item) == item.InterpolationMode)
                {
                    this.cmbInterpolation.SelectedItem = item2;
                }
            }
        }

        private class ComboItem<T>
        {
            protected T _item;
            protected string _name;

            public ComboItem(string name, T item)
            {
                this._item = item;
                this._name = name;
            }

            public override string ToString() => 
                this._name;

            public T Item
            {
                get{return  
                    this._item;}
                set
                {
                    this._item = value;
                }
            }
        }
    }
}

