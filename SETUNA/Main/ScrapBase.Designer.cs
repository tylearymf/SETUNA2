namespace SETUNA.Main
{
	// Token: 0x02000008 RID: 8
	sealed partial class ScrapBase
	{
		// Token: 0x06000053 RID: 83 RVA: 0x000037E4 File Offset: 0x000019E4
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.timOpacity = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timOpacity
            // 
            this.timOpacity.Interval = 15;
            this.timOpacity.Tick += new System.EventHandler(this.timOpacity_Tick);
            // 
            // ScrapBase
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "ScrapBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.ScrapBase_Activated);
            this.Deactivate += new System.EventHandler(this.ScrapBase_Deactivate);
            this.SizeChanged += new System.EventHandler(this.ScrapBase_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ScrapBase_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ScrapBase_DragEnter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScrapBase_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScrapBase_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ScrapBase_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlImg_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ScrapBase_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ScrapBase_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlImg_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlImg_MouseUp);
            this.ResumeLayout(false);

		}

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.Timer timOpacity;

		// Token: 0x0400002E RID: 46
		private global::System.ComponentModel.IContainer components;
	}
}
