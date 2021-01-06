namespace SETUNA.Main
{
	// Token: 0x020000A7 RID: 167
	sealed partial class CaptureInfo
	{
		// Token: 0x0600057A RID: 1402 RVA: 0x0002604A File Offset: 0x0002424A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0002606C File Offset: 0x0002426C
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // CaptureInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(110, 131);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "info";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptureInfo_FormClosing);
            this.Load += new System.EventHandler(this.CaptureInfo_Load);
            this.Shown += new System.EventHandler(this.CaptureInfo_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CaptureInfo_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CaptureInfo_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CaptureInfo_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CaptureInfo_MouseUp);
            this.ResumeLayout(false);

		}

		// Token: 0x04000372 RID: 882
#pragma warning disable CS0649 // 从未对字段“CaptureInfo.components”赋值，字段将一直保持其默认值 null
		private global::System.ComponentModel.IContainer components;
#pragma warning restore CS0649 // 从未对字段“CaptureInfo.components”赋值，字段将一直保持其默认值 null
	}
}
