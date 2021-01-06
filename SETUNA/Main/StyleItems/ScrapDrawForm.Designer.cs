namespace SETUNA.Main.StyleItems
{
	// Token: 0x02000022 RID: 34
	partial class ScrapDrawForm
	{
		// Token: 0x06000160 RID: 352 RVA: 0x00008371 File Offset: 0x00006571
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			if (this._baseimg != null)
			{
				this._baseimg.Dispose();
				this._baseimg = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x000083AC File Offset: 0x000065AC
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // ScrapDrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScrapDrawForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TrimWindow";
            this.TopMost = true;
            this.ResumeLayout(false);

		}

		// Token: 0x040000A2 RID: 162
#pragma warning disable CS0649 // 从未对字段“ScrapDrawForm.components”赋值，字段将一直保持其默认值 null
		private global::System.ComponentModel.IContainer components;
#pragma warning restore CS0649 // 从未对字段“ScrapDrawForm.components”赋值，字段将一直保持其默认值 null

		// Token: 0x040000A3 RID: 163
		protected global::System.Drawing.Image _baseimg;
	}
}
