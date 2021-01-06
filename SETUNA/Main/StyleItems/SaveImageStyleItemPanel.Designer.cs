namespace SETUNA.Main.StyleItems
{
	// Token: 0x020000B2 RID: 178
	partial class SaveImageStyleItemPanel
	{
		// Token: 0x06000598 RID: 1432 RVA: 0x0002658C File Offset: 0x0002478C
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPng = new System.Windows.Forms.TabPage();
            this.tabJpeg = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblJpegQuality = new System.Windows.Forms.Label();
            this.barJpegQuality = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tabBmp = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabJpeg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barJpegQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(205, 227);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(279, 227);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 214);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(10, 189);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(132, 16);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "指定保存时的文件名";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 173);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 16);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "保存时的格式、质量等设置";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(314, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 21);
            this.textBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "目的地：";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPng);
            this.tabControl1.Controls.Add(this.tabJpeg);
            this.tabControl1.Controls.Add(this.tabBmp);
            this.tabControl1.Location = new System.Drawing.Point(79, 43);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(256, 124);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPng
            // 
            this.tabPng.Location = new System.Drawing.Point(4, 25);
            this.tabPng.Name = "tabPng";
            this.tabPng.Padding = new System.Windows.Forms.Padding(3);
            this.tabPng.Size = new System.Drawing.Size(248, 95);
            this.tabPng.TabIndex = 0;
            this.tabPng.Text = "PNG";
            this.tabPng.UseVisualStyleBackColor = true;
            // 
            // tabJpeg
            // 
            this.tabJpeg.Controls.Add(this.label5);
            this.tabJpeg.Controls.Add(this.label4);
            this.tabJpeg.Controls.Add(this.lblJpegQuality);
            this.tabJpeg.Controls.Add(this.barJpegQuality);
            this.tabJpeg.Controls.Add(this.label2);
            this.tabJpeg.Location = new System.Drawing.Point(4, 25);
            this.tabJpeg.Name = "tabJpeg";
            this.tabJpeg.Padding = new System.Windows.Forms.Padding(3);
            this.tabJpeg.Size = new System.Drawing.Size(248, 95);
            this.tabJpeg.TabIndex = 1;
            this.tabJpeg.Text = "JPEG";
            this.tabJpeg.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "高";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "低";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblJpegQuality
            // 
            this.lblJpegQuality.Location = new System.Drawing.Point(216, 26);
            this.lblJpegQuality.Name = "lblJpegQuality";
            this.lblJpegQuality.Size = new System.Drawing.Size(26, 12);
            this.lblJpegQuality.TabIndex = 2;
            this.lblJpegQuality.Text = "100";
            this.lblJpegQuality.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // barJpegQuality
            // 
            this.barJpegQuality.Location = new System.Drawing.Point(43, 20);
            this.barJpegQuality.Maximum = 100;
            this.barJpegQuality.Name = "barJpegQuality";
            this.barJpegQuality.Size = new System.Drawing.Size(175, 45);
            this.barJpegQuality.TabIndex = 1;
            this.barJpegQuality.TickFrequency = 10;
            this.barJpegQuality.Scroll += new System.EventHandler(this.barJpegQuality_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "质量：";
            // 
            // tabBmp
            // 
            this.tabBmp.Location = new System.Drawing.Point(4, 25);
            this.tabBmp.Name = "tabBmp";
            this.tabBmp.Size = new System.Drawing.Size(248, 95);
            this.tabBmp.TabIndex = 2;
            this.tabBmp.Text = "BMP";
            this.tabBmp.UseVisualStyleBackColor = true;
            // 
            // SaveImageStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(357, 259);
            this.Controls.Add(this.groupBox1);
            this.Name = "SaveImageStyleItemPanel";
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabJpeg.ResumeLayout(false);
            this.tabJpeg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barJpegQuality)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x04000385 RID: 901
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000386 RID: 902
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x04000387 RID: 903
		private global::System.Windows.Forms.TabPage tabPng;

		// Token: 0x04000388 RID: 904
		private global::System.Windows.Forms.TabPage tabJpeg;

		// Token: 0x04000389 RID: 905
		private global::System.Windows.Forms.TabPage tabBmp;

		// Token: 0x0400038A RID: 906
		private global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x0400038B RID: 907
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400038C RID: 908
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x0400038D RID: 909
		private global::System.Windows.Forms.Label lblJpegQuality;

		// Token: 0x0400038E RID: 910
		private global::System.Windows.Forms.TrackBar barJpegQuality;

		// Token: 0x0400038F RID: 911
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000390 RID: 912
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000391 RID: 913
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000392 RID: 914
		private global::System.Windows.Forms.CheckBox checkBox2;

		// Token: 0x04000393 RID: 915
		private global::System.Windows.Forms.GroupBox groupBox1;
	}
}
