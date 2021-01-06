namespace SETUNA.Main.StyleItems
{
	// Token: 0x0200007B RID: 123
	partial class CompactScrap
	{
		// Token: 0x06000414 RID: 1044 RVA: 0x0001A173 File Offset: 0x00018373
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0001A194 File Offset: 0x00018394
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // CompactScrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.ClientSize = new System.Drawing.Size(50, 50);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(50, 50);
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "CompactScrap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CompactScrap";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompactScrap_FormClosed);
            this.Load += new System.EventHandler(this.CompactScrap_Load);
            this.DoubleClick += new System.EventHandler(this.CompactScrap_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompactScrap_KeyDown);
            this.Leave += new System.EventHandler(this.CompactScrap_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CompactScrap_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CompactScrap_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CompactScrap_MouseUp);
            this.ResumeLayout(false);

		}

		// Token: 0x0400026F RID: 623
#pragma warning disable CS0649 // 从未对字段“CompactScrap.components”赋值，字段将一直保持其默认值 null
		private global::System.ComponentModel.IContainer components;
#pragma warning restore CS0649 // 从未对字段“CompactScrap.components”赋值，字段将一直保持其默认值 null
	}
}
