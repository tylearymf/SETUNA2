namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main.Other;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class MoveStyleItemPanel : ToolBoxForm
    {
        private CheckBox chkDown;
        private CheckBox chkLeft;
        private CheckBox chkRight;
        private CheckBox chkUp;
        private GroupBox groupBox1;
        private NumericUpDown numDown;
        private NumericUpDown numLeft;
        private NumericUpDown numRight;
        private NumericUpDown numUp;
        private LayerInfo mLayerInfo;

        public MoveStyleItemPanel(CStyleItem item) : base(item)
        {
            this.numUp.Maximum = CMoveStyleItem.MAX_MOVE;
            this.numDown.Maximum = CMoveStyleItem.MAX_MOVE;
            this.numLeft.Maximum = CMoveStyleItem.MAX_MOVE;
            this.numRight.Maximum = CMoveStyleItem.MAX_MOVE;
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
        }

        private void chkDown_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkDown.Checked && !this.chkUp.Checked)
            {
                this.chkDown.Checked = true;
            }
            if (this.chkDown.Checked && this.chkUp.Checked)
            {
                this.chkUp.Checked = false;
            }
            if (this.chkDown.Checked)
            {
                this.numDown.Enabled = true;
            }
            else
            {
                this.numDown.Enabled = false;
                this.numDown.Value = 0M;
            }
        }

        private void chkLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkRight.Checked && !this.chkLeft.Checked)
            {
                this.chkLeft.Checked = true;
            }
            if (this.chkRight.Checked && this.chkLeft.Checked)
            {
                this.chkRight.Checked = false;
            }
            if (this.chkLeft.Checked)
            {
                this.numLeft.Enabled = true;
            }
            else
            {
                this.numLeft.Enabled = false;
                this.numLeft.Value = 0M;
            }
        }

        private void chkRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkRight.Checked && !this.chkLeft.Checked)
            {
                this.chkRight.Checked = true;
            }
            if (this.chkRight.Checked && this.chkLeft.Checked)
            {
                this.chkLeft.Checked = false;
            }
            if (this.chkRight.Checked)
            {
                this.numRight.Enabled = true;
            }
            else
            {
                this.numRight.Enabled = false;
                this.numRight.Value = 0M;
            }
        }

        private void chkUp_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkDown.Checked && !this.chkUp.Checked)
            {
                this.chkUp.Checked = true;
            }
            if (this.chkDown.Checked && this.chkUp.Checked)
            {
                this.chkDown.Checked = false;
            }
            if (this.chkUp.Checked)
            {
                this.numUp.Enabled = true;
            }
            else
            {
                this.numUp.Enabled = false;
                this.numUp.Value = 0M;
            }
        }

        protected override object GetStyleFromForm()
        {
            int num;
            int num2;
            CMoveStyleItem item = new CMoveStyleItem();
            if (this.chkUp.Checked)
            {
                num = -((int) this.numUp.Value);
            }
            else
            {
                num = (int) this.numDown.Value;
            }
            if (this.chkLeft.Checked)
            {
                num2 = -((int) this.numLeft.Value);
            }
            else
            {
                num2 = (int) this.numRight.Value;
            }
            item.Top = num;
            item.Left = num2;
            return item;
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.numRight = new NumericUpDown();
            this.numLeft = new NumericUpDown();
            this.numDown = new NumericUpDown();
            this.numUp = new NumericUpDown();
            this.chkLeft = new CheckBox();
            this.chkRight = new CheckBox();
            this.chkUp = new CheckBox();
            this.chkDown = new CheckBox();
            this.groupBox1.SuspendLayout();
            this.numRight.BeginInit();
            this.numLeft.BeginInit();
            this.numDown.BeginInit();
            this.numUp.BeginInit();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0xac, 0xdb);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0xf8, 0xdb);
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.numRight);
            this.groupBox1.Controls.Add(this.numLeft);
            this.groupBox1.Controls.Add(this.numDown);
            this.groupBox1.Controls.Add(this.numUp);
            this.groupBox1.Controls.Add(this.chkLeft);
            this.groupBox1.Controls.Add(this.chkRight);
            this.groupBox1.Controls.Add(this.chkUp);
            this.groupBox1.Controls.Add(this.chkDown);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x138, 0xcb);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.numRight.ImeMode = ImeMode.Off;
            this.numRight.Location = new Point(0xc2, 0x60);
            int[] bits = new int[4];
            bits[0] = 0x3e8;
            this.numRight.Maximum = new decimal(bits);
            this.numRight.Name = "numRight";
            this.numRight.Size = new Size(0x33, 0x13);
            this.numRight.TabIndex = 5;
            this.numLeft.ImeMode = ImeMode.Off;
            this.numLeft.Location = new Point(0x4b, 0x60);
            int[] numArray2 = new int[4];
            numArray2[0] = 0x3e8;
            this.numLeft.Maximum = new decimal(numArray2);
            this.numLeft.Name = "numLeft";
            this.numLeft.Size = new Size(0x33, 0x13);
            this.numLeft.TabIndex = 3;
            this.numDown.ImeMode = ImeMode.Off;
            this.numDown.Location = new Point(0x85, 0x9a);
            int[] numArray3 = new int[4];
            numArray3[0] = 0x3e8;
            this.numDown.Maximum = new decimal(numArray3);
            this.numDown.Name = "numDown";
            this.numDown.Size = new Size(0x33, 0x13);
            this.numDown.TabIndex = 7;
            this.numUp.ImeMode = ImeMode.Off;
            this.numUp.Location = new Point(0x85, 0x27);
            int[] numArray4 = new int[4];
            numArray4[0] = 0x3e8;
            this.numUp.Maximum = new decimal(numArray4);
            this.numUp.Name = "numUp";
            this.numUp.Size = new Size(0x33, 0x13);
            this.numUp.TabIndex = 1;
            this.chkLeft.Location = new Point(0x39, 0x51);
            this.chkLeft.Name = "chkLeft";
            this.chkLeft.Size = new Size(0x49, 0x31);
            this.chkLeft.TabIndex = 2;
            this.chkLeft.Text = "左";
            this.chkLeft.TextAlign = ContentAlignment.TopCenter;
            this.chkLeft.UseVisualStyleBackColor = true;
            this.chkLeft.CheckedChanged += new EventHandler(this.chkLeft_CheckedChanged);
            this.chkRight.Location = new Point(0xb0, 0x51);
            this.chkRight.Name = "chkRight";
            this.chkRight.Size = new Size(0x49, 0x31);
            this.chkRight.TabIndex = 4;
            this.chkRight.Text = "右";
            this.chkRight.TextAlign = ContentAlignment.TopCenter;
            this.chkRight.UseVisualStyleBackColor = true;
            this.chkRight.CheckedChanged += new EventHandler(this.chkRight_CheckedChanged);
            this.chkUp.Location = new Point(0x73, 0x18);
            this.chkUp.Name = "chkUp";
            this.chkUp.Size = new Size(0x49, 0x31);
            this.chkUp.TabIndex = 0;
            this.chkUp.Text = "上";
            this.chkUp.TextAlign = ContentAlignment.TopCenter;
            this.chkUp.UseVisualStyleBackColor = true;
            this.chkUp.CheckedChanged += new EventHandler(this.chkUp_CheckedChanged);
            this.chkDown.Location = new Point(0x73, 0x8b);
            this.chkDown.Name = "chkDown";
            this.chkDown.Size = new Size(0x49, 0x31);
            this.chkDown.TabIndex = 6;
            this.chkDown.Text = "下";
            this.chkDown.TextAlign = ContentAlignment.TopCenter;
            this.chkDown.UseVisualStyleBackColor = true;
            this.chkDown.CheckedChanged += new EventHandler(this.chkDown_CheckedChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(0x146, 0xfb);
            base.Controls.Add(this.groupBox1);
            base.Name = "MoveStyleItemPanel";
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.numRight.EndInit();
            this.numLeft.EndInit();
            this.numDown.EndInit();
            this.numUp.EndInit();
            base.ResumeLayout(false);
        }

        protected override void SetStyleToForm(object style)
        {
            CMoveStyleItem item = (CMoveStyleItem) style;
            this.InitializeComponent();
            this.Text = item.GetDisplayName();
            if (item.Top <= 0)
            {
                this.chkDown.Checked = true;
                this.chkUp.Checked = true;
                this.numUp.Value = Math.Abs(item.Top);
            }
            else
            {
                this.chkUp.Checked = true;
                this.chkDown.Checked = true;
                this.numDown.Value = Math.Abs(item.Top);
            }
            if (item.Left <= 0)
            {
                this.chkRight.Checked = true;
                this.chkLeft.Checked = true;
                this.numLeft.Value = Math.Abs(item.Left);
            }
            else
            {
                this.chkLeft.Checked = true;
                this.chkRight.Checked = true;
                this.numRight.Value = Math.Abs(item.Left);
            }
        }
    }
}

