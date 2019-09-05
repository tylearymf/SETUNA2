namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main.Other;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class TimerStyleItemPanel : ToolBoxForm
    {
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private NumericUpDown numInterval;
        private LayerInfo mLayerInfo;

        public TimerStyleItemPanel(CStyleItem item) : base(item)
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

        protected override object GetStyleFromForm() => 
            new CTimerStyleItem { Interval = (uint) this.numInterval.Value };

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.label2 = new Label();
            this.numInterval = new NumericUpDown();
            this.label1 = new Label();
            this.groupBox1.SuspendLayout();
            this.numInterval.BeginInit();
            base.SuspendLayout();
            base.cmdOK.Location = new Point(0x42, 0x6d);
            base.cmdCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            base.cmdCancel.Location = new Point(0x8e, 0x6d);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numInterval);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xcd, 0x5d);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x93, 0x29);
            this.label2.Name = "label2";
            this.label2.Size = new Size(20, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ms";
            this.numInterval.ImeMode = ImeMode.Off;
            this.numInterval.Location = new Point(0x54, 0x27);
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new Size(60, 0x13);
            this.numInterval.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x1a, 0x29);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x34, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "延迟：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(220, 0x8d);
            base.Controls.Add(this.groupBox1);
            base.Name = "TimerStyleItemPanel";
            base.Controls.SetChildIndex(this.groupBox1, 0);
            base.Controls.SetChildIndex(base.cmdOK, 0);
            base.Controls.SetChildIndex(base.cmdCancel, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.numInterval.EndInit();
            base.ResumeLayout(false);
        }

        protected override void SetStyleToForm(object style)
        {
            CTimerStyleItem item = (CTimerStyleItem) style;
            this.InitializeComponent();
            this.numInterval.Minimum = CTimerStyleItem.MIN_INTERVAL;
            this.numInterval.Maximum = CTimerStyleItem.MAX_INTERVAL;
            this.numInterval.Value = item.Interval;
        }
    }
}

