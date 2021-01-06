namespace SETUNA.Main.StyleItems
{
	// Token: 0x0200007C RID: 124
	partial class WindowStyleItemPanel
	{
		// Token: 0x06000419 RID: 1049 RVA: 0x0001A354 File Offset: 0x00018554
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoIncrement = new System.Windows.Forms.RadioButton();
            this.rdoFixed = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(36, 92);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(112, 92);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 80);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoIncrement);
            this.panel1.Controls.Add(this.rdoFixed);
            this.panel1.Location = new System.Drawing.Point(6, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 51);
            this.panel1.TabIndex = 8;
            // 
            // rdoIncrement
            // 
            this.rdoIncrement.AutoSize = true;
            this.rdoIncrement.Location = new System.Drawing.Point(3, 30);
            this.rdoIncrement.Name = "rdoIncrement";
            this.rdoIncrement.Size = new System.Drawing.Size(71, 16);
            this.rdoIncrement.TabIndex = 1;
            this.rdoIncrement.Text = "窗口类型";
            this.rdoIncrement.UseVisualStyleBackColor = true;
            // 
            // rdoFixed
            // 
            this.rdoFixed.AutoSize = true;
            this.rdoFixed.Checked = true;
            this.rdoFixed.Location = new System.Drawing.Point(3, 8);
            this.rdoFixed.Name = "rdoFixed";
            this.rdoFixed.Size = new System.Drawing.Size(83, 16);
            this.rdoFixed.TabIndex = 0;
            this.rdoFixed.TabStop = true;
            this.rdoFixed.Text = "参考图类型";
            this.rdoFixed.UseVisualStyleBackColor = true;
            // 
            // WindowStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(190, 124);
            this.Controls.Add(this.groupBox1);
            this.Name = "WindowStyleItemPanel";
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		// Token: 0x04000270 RID: 624
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.RadioButton rdoIncrement;

		// Token: 0x04000272 RID: 626
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.RadioButton rdoFixed;
	}
}
