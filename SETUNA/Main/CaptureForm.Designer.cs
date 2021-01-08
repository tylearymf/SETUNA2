namespace SETUNA.Main
{
	// Token: 0x02000046 RID: 70
	sealed partial class CaptureForm
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x0000F33E File Offset: 0x0000D53E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000F360 File Offset: 0x0000D560
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 332);
            this.ControlBox = false;
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CaptureForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CaptureForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptureForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CaptureForm_FormClosed);
            this.Shown += new System.EventHandler(this.CaptureForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CaptureForm_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CaptureForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CaptureForm_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CaptureForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CaptureForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CaptureForm_MouseUp);
            this.ResumeLayout(false);

		}

        // Token: 0x0400013E RID: 318
        private global::System.ComponentModel.IContainer components;
    }
}
