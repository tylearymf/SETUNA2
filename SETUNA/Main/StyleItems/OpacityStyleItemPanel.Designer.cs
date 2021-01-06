namespace SETUNA.Main.StyleItems
{
	// Token: 0x0200008F RID: 143
	partial class OpacityStyleItemPanel
	{
		// Token: 0x060004AF RID: 1199 RVA: 0x0001F2A8 File Offset: 0x0001D4A8
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numPreview = new System.Windows.Forms.NumericUpDown();
            this.btnPreview = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.barOpacity2 = new System.Windows.Forms.TrackBar();
            this.barOpacity = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.numOpacity2 = new System.Windows.Forms.NumericUpDown();
            this.rdoIncrement = new System.Windows.Forms.RadioButton();
            this.rdoFixed = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numOpacity = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(377, 222);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(451, 222);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.barOpacity2);
            this.groupBox1.Controls.Add(this.barOpacity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numOpacity2);
            this.groupBox1.Controls.Add(this.rdoIncrement);
            this.groupBox1.Controls.Add(this.rdoFixed);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numOpacity);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numPreview);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Controls.Add(this.picPreview);
            this.groupBox2.Location = new System.Drawing.Point(328, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 181);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "%";
            // 
            // numPreview
            // 
            this.numPreview.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numPreview.Location = new System.Drawing.Point(108, 155);
            this.numPreview.Name = "numPreview";
            this.numPreview.Size = new System.Drawing.Size(48, 21);
            this.numPreview.TabIndex = 1;
            this.numPreview.ValueChanged += new System.EventHandler(this.numPreview_ValueChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(6, 152);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(96, 23);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "应用相对值";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPreview.Location = new System.Drawing.Point(6, 18);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(167, 131);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // barOpacity2
            // 
            this.barOpacity2.AutoSize = false;
            this.barOpacity2.Location = new System.Drawing.Point(107, 79);
            this.barOpacity2.Name = "barOpacity2";
            this.barOpacity2.Size = new System.Drawing.Size(123, 20);
            this.barOpacity2.TabIndex = 6;
            this.barOpacity2.TickFrequency = 10;
            this.barOpacity2.Scroll += new System.EventHandler(this.barOpacity_Scroll);
            // 
            // barOpacity
            // 
            this.barOpacity.AutoSize = false;
            this.barOpacity.Location = new System.Drawing.Point(107, 50);
            this.barOpacity.Maximum = 100;
            this.barOpacity.Minimum = 1;
            this.barOpacity.Name = "barOpacity";
            this.barOpacity.Size = new System.Drawing.Size(123, 20);
            this.barOpacity.TabIndex = 2;
            this.barOpacity.TickFrequency = 10;
            this.barOpacity.Value = 1;
            this.barOpacity.Scroll += new System.EventHandler(this.barOpacity_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "%";
            // 
            // numOpacity2
            // 
            this.numOpacity2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numOpacity2.Location = new System.Drawing.Point(236, 77);
            this.numOpacity2.Name = "numOpacity2";
            this.numOpacity2.Size = new System.Drawing.Size(48, 21);
            this.numOpacity2.TabIndex = 7;
            this.numOpacity2.ValueChanged += new System.EventHandler(this.numOpacity_ValueChanged);
            this.numOpacity2.Enter += new System.EventHandler(this.numOpacity_Enter);
            // 
            // rdoIncrement
            // 
            this.rdoIncrement.AutoSize = true;
            this.rdoIncrement.Location = new System.Drawing.Point(42, 77);
            this.rdoIncrement.Name = "rdoIncrement";
            this.rdoIncrement.Size = new System.Drawing.Size(59, 16);
            this.rdoIncrement.TabIndex = 5;
            this.rdoIncrement.Text = "相对值";
            this.rdoIncrement.UseVisualStyleBackColor = true;
            // 
            // rdoFixed
            // 
            this.rdoFixed.AutoSize = true;
            this.rdoFixed.Checked = true;
            this.rdoFixed.Location = new System.Drawing.Point(42, 49);
            this.rdoFixed.Name = "rdoFixed";
            this.rdoFixed.Size = new System.Drawing.Size(59, 16);
            this.rdoFixed.TabIndex = 1;
            this.rdoFixed.TabStop = true;
            this.rdoFixed.Text = "绝对值";
            this.rdoFixed.UseVisualStyleBackColor = true;
            this.rdoFixed.CheckedChanged += new System.EventHandler(this.rdoFixed_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 51);
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
            this.numOpacity.Location = new System.Drawing.Point(236, 49);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new System.Drawing.Size(48, 21);
            this.numOpacity.TabIndex = 3;
            this.numOpacity.ValueChanged += new System.EventHandler(this.numOpacity_ValueChanged);
            this.numOpacity.Enter += new System.EventHandler(this.numOpacity_Enter);
            // 
            // OpacityStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(529, 254);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "OpacityStyleItemPanel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OpacityStyleItemPanel_FormClosed);
            this.Shown += new System.EventHandler(this.OpacityStyleItemPanel_Shown);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x040002DA RID: 730
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040002DB RID: 731
		private global::System.Windows.Forms.RadioButton rdoIncrement;

		// Token: 0x040002DC RID: 732
		private global::System.Windows.Forms.RadioButton rdoFixed;

		// Token: 0x040002DD RID: 733
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002DE RID: 734
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002DF RID: 735
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002E0 RID: 736
		private global::System.Windows.Forms.NumericUpDown numOpacity2;

		// Token: 0x040002E1 RID: 737
		private global::System.Windows.Forms.TrackBar barOpacity;

		// Token: 0x040002E2 RID: 738
		private global::System.Windows.Forms.TrackBar barOpacity2;

		// Token: 0x040002E3 RID: 739
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040002E4 RID: 740
		private global::System.Windows.Forms.Button btnPreview;

		// Token: 0x040002E5 RID: 741
		private global::System.Windows.Forms.PictureBox picPreview;

		// Token: 0x040002E6 RID: 742
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040002E7 RID: 743
		private global::System.Windows.Forms.NumericUpDown numPreview;

		// Token: 0x040002E8 RID: 744
		private global::System.Windows.Forms.NumericUpDown numOpacity;
	}
}
