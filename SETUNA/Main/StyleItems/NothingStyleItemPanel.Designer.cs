namespace SETUNA.Main.StyleItems
{
	// Token: 0x0200000B RID: 11
	partial class NothingStyleItemPanel
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x00004CCC File Offset: 0x00002ECC
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(53, 62);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(129, 62);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "这个项目没有设置";
            // 
            // NothingStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(207, 94);
            this.Controls.Add(this.label1);
            this.Name = "NothingStyleItemPanel";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.Label label1;
	}
}
