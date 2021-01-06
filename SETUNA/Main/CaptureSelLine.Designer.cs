namespace SETUNA.Main
{
	// Token: 0x02000071 RID: 113
	sealed partial class CaptureSelLine
	{
		// Token: 0x060003B1 RID: 945 RVA: 0x0001639D File Offset: 0x0001459D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x000163BC File Offset: 0x000145BC
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // CaptureSelLine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1, 1);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "CaptureSelLine";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CaptureSelLine_Paint);
            this.ResumeLayout(false);

		}

		// Token: 0x0400020B RID: 523
#pragma warning disable CS0649 // 从未对字段“CaptureSelLine.components”赋值，字段将一直保持其默认值 null
		private global::System.ComponentModel.IContainer components;
#pragma warning restore CS0649 // 从未对字段“CaptureSelLine.components”赋值，字段将一直保持其默认值 null
	}
}
