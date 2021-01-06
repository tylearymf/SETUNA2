namespace SETUNA.Main.StyleItems
{
	// Token: 0x02000096 RID: 150
	partial class TimerStyleItemPanel
	{
		// Token: 0x060004F6 RID: 1270 RVA: 0x0002349C File Offset: 0x0002169C
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(66, 109);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(142, 109);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numInterval);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ms";
            // 
            // numInterval
            // 
            this.numInterval.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numInterval.Location = new System.Drawing.Point(84, 39);
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(60, 21);
            this.numInterval.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "延迟：";
            // 
            // TimerStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(220, 141);
            this.Controls.Add(this.groupBox1);
            this.Name = "TimerStyleItemPanel";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x04000330 RID: 816
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000331 RID: 817
		private global::System.Windows.Forms.NumericUpDown numInterval;

		// Token: 0x04000332 RID: 818
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000333 RID: 819
		private global::System.Windows.Forms.GroupBox groupBox1;
	}
}
