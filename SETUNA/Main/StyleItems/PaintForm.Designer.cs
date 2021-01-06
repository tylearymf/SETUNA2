namespace SETUNA.Main.StyleItems
{
	// Token: 0x020000B3 RID: 179
	partial class PaintForm
	{
		// Token: 0x0600059E RID: 1438 RVA: 0x00026F22 File Offset: 0x00025122
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			if (this._src != null)
			{
				this._src.Dispose();
				this._src = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x00026F5C File Offset: 0x0002515C
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.button1);
            this.Name = "PaintForm";
            this.Text = "PaintForm";
            this.ResumeLayout(false);

		}

		// Token: 0x04000394 RID: 916
#pragma warning disable CS0649 // 从未对字段“PaintForm.components”赋值，字段将一直保持其默认值 null
		private global::System.ComponentModel.IContainer components;
#pragma warning restore CS0649 // 从未对字段“PaintForm.components”赋值，字段将一直保持其默认值 null

		// Token: 0x04000395 RID: 917
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000396 RID: 918
		private global::System.Drawing.Image _src;
	}
}
