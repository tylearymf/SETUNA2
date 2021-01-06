namespace SETUNA
{
	// Token: 0x02000045 RID: 69
	partial class ClickCapture
	{
		// Token: 0x06000289 RID: 649 RVA: 0x0000DD3F File Offset: 0x0000BF3F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000DD60 File Offset: 0x0000BF60
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ClickCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(10, 10);
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "ClickCapture";
            this.Opacity = 0.01D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Click += new System.EventHandler(this.ClickCapture_Click);
            this.MouseEnter += new System.EventHandler(this.ClickCapture_MouseEnter);
            this.ResumeLayout(false);

		}

		// Token: 0x04000123 RID: 291
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.Timer timer1;
	}
}
