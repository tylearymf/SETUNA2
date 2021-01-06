namespace SETUNA.Main.StyleItems
{
	// Token: 0x0200007A RID: 122
	partial class CompactStyleItemPanel
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x00019030 File Offset: 0x00017230
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoDashed = new System.Windows.Forms.RadioButton();
            this.rdoSolid = new System.Windows.Forms.RadioButton();
            this.picLineColor = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.barOpacity = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numOpacity = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLineColor)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(237, 177);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(311, 177);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoDashed);
            this.groupBox1.Controls.Add(this.rdoSolid);
            this.groupBox1.Controls.Add(this.picLineColor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.barOpacity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numOpacity);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // rdoDashed
            // 
            this.rdoDashed.AutoSize = true;
            this.rdoDashed.Location = new System.Drawing.Point(157, 100);
            this.rdoDashed.Name = "rdoDashed";
            this.rdoDashed.Size = new System.Drawing.Size(47, 16);
            this.rdoDashed.TabIndex = 14;
            this.rdoDashed.TabStop = true;
            this.rdoDashed.Text = "虚线";
            this.rdoDashed.UseVisualStyleBackColor = true;
            // 
            // rdoSolid
            // 
            this.rdoSolid.AutoSize = true;
            this.rdoSolid.Location = new System.Drawing.Point(104, 100);
            this.rdoSolid.Name = "rdoSolid";
            this.rdoSolid.Size = new System.Drawing.Size(47, 16);
            this.rdoSolid.TabIndex = 13;
            this.rdoSolid.TabStop = true;
            this.rdoSolid.Text = "实线";
            this.rdoSolid.UseVisualStyleBackColor = true;
            this.rdoSolid.CheckedChanged += new System.EventHandler(this.rdoSolid_CheckedChanged);
            // 
            // picLineColor
            // 
            this.picLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picLineColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLineColor.Location = new System.Drawing.Point(62, 98);
            this.picLineColor.Name = "picLineColor";
            this.picLineColor.Size = new System.Drawing.Size(32, 19);
            this.picLineColor.TabIndex = 12;
            this.picLineColor.TabStop = false;
            this.picLineColor.Click += new System.EventHandler(this.picLineColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "边框：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picPreview);
            this.groupBox2.Location = new System.Drawing.Point(226, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 138);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPreview.Location = new System.Drawing.Point(6, 18);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(126, 114);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // barOpacity
            // 
            this.barOpacity.AutoSize = false;
            this.barOpacity.Location = new System.Drawing.Point(48, 50);
            this.barOpacity.Maximum = 100;
            this.barOpacity.Minimum = 1;
            this.barOpacity.Name = "barOpacity";
            this.barOpacity.Size = new System.Drawing.Size(91, 20);
            this.barOpacity.TabIndex = 2;
            this.barOpacity.TickFrequency = 10;
            this.barOpacity.Value = 1;
            this.barOpacity.Scroll += new System.EventHandler(this.barOpacity_Scroll);
            this.barOpacity.ValueChanged += new System.EventHandler(this.barOpacity_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "不透明度：";
            // 
            // numOpacity
            // 
            this.numOpacity.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numOpacity.Location = new System.Drawing.Point(145, 48);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new System.Drawing.Size(48, 21);
            this.numOpacity.TabIndex = 3;
            this.numOpacity.ValueChanged += new System.EventHandler(this.numOpacity_ValueChanged);
            this.numOpacity.Enter += new System.EventHandler(this.numOpacity_Enter);
            // 
            // CompactStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(389, 209);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "CompactStyleItemPanel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OpacityStyleItemPanel_FormClosed);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLineColor)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400025C RID: 604
		private global::System.Windows.Forms.TrackBar barOpacity;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.PictureBox picPreview;

		// Token: 0x0400025F RID: 607
		private global::System.Windows.Forms.NumericUpDown numOpacity;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.RadioButton rdoDashed;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.RadioButton rdoSolid;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.PictureBox picLineColor;

		// Token: 0x04000267 RID: 615
		private global::System.Windows.Forms.ColorDialog colorDialog1;
	}
}
