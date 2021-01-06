namespace SETUNA.Main.StyleItems
{
	// Token: 0x0200000C RID: 12
	partial class ImagePngPreviewPanel
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x00004E0C File Offset: 0x0000300C
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.barQuality = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblQuality = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barQuality)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(124, 214);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(198, 214);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.barQuality);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblQuality);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 198);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // barQuality
            // 
            this.barQuality.AutoSize = false;
            this.barQuality.Location = new System.Drawing.Point(52, 143);
            this.barQuality.Maximum = 100;
            this.barQuality.Name = "barQuality";
            this.barQuality.Size = new System.Drawing.Size(173, 33);
            this.barQuality.TabIndex = 6;
            this.barQuality.TickFrequency = 10;
            this.barQuality.Scroll += new System.EventHandler(this.barQuality_Scroll);
            this.barQuality.ValueChanged += new System.EventHandler(this.barQuality_Scroll);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.picPreview);
            this.panel1.Location = new System.Drawing.Point(13, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 119);
            this.panel1.TabIndex = 11;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picPreview_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPreview_MouseUp);
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(-2, -2);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(94, 71);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPreview.TabIndex = 11;
            this.picPreview.TabStop = false;
            this.picPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPreview_MouseDown);
            this.picPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPreview_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "0";
            // 
            // lblQuality
            // 
            this.lblQuality.Location = new System.Drawing.Point(224, 148);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(24, 12);
            this.lblQuality.TabIndex = 7;
            this.lblQuality.Text = "100";
            this.lblQuality.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "质量：";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.ApplicationData;
            // 
            // ImagePngPreviewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(276, 246);
            this.Controls.Add(this.groupBox1);
            this.Name = "ImagePngPreviewPanel";
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barQuality)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.TrackBar barQuality;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Label lblQuality;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.PictureBox picPreview;
	}
}
