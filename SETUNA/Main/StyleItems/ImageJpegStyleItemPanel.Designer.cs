namespace SETUNA.Main.StyleItems
{
	// Token: 0x02000092 RID: 146
	partial class ImageJpegStyleItemPanel
	{
		// Token: 0x060004D3 RID: 1235 RVA: 0x00021B04 File Offset: 0x0001FD04
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDupli = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoSaveAs = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.rdoScrapName = new System.Windows.Forms.RadioButton();
            this.rdoName = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCopy = new System.Windows.Forms.CheckBox();
            this.chkWindow = new System.Windows.Forms.CheckBox();
            this.chkShowParam = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblQuality = new System.Windows.Forms.Label();
            this.barQuality = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRef = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(249, 329);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(323, 329);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDupli);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdoSaveAs);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.rdoScrapName);
            this.groupBox1.Controls.Add(this.rdoName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkCopy);
            this.groupBox1.Controls.Add(this.chkWindow);
            this.groupBox1.Controls.Add(this.chkShowParam);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblQuality);
            this.groupBox1.Controls.Add(this.barQuality);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRef);
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 314);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // cmbDupli
            // 
            this.cmbDupli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDupli.FormattingEnabled = true;
            this.cmbDupli.Items.AddRange(new object[] {
            "覆盖",
            "追加序号",
            "重复时指定"});
            this.cmbDupli.Location = new System.Drawing.Point(133, 127);
            this.cmbDupli.Name = "cmbDupli";
            this.cmbDupli.Size = new System.Drawing.Size(133, 20);
            this.cmbDupli.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "重复时∶";
            // 
            // rdoSaveAs
            // 
            this.rdoSaveAs.AutoSize = true;
            this.rdoSaveAs.Location = new System.Drawing.Point(86, 66);
            this.rdoSaveAs.Name = "rdoSaveAs";
            this.rdoSaveAs.Size = new System.Drawing.Size(83, 16);
            this.rdoSaveAs.TabIndex = 4;
            this.rdoSaveAs.TabStop = true;
            this.rdoSaveAs.Text = "保存时指定";
            this.rdoSaveAs.UseVisualStyleBackColor = true;
            this.rdoSaveAs.CheckedChanged += new System.EventHandler(this.rdoSaveAs_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(103, 104);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(223, 21);
            this.txtName.TabIndex = 7;
            // 
            // rdoScrapName
            // 
            this.rdoScrapName.AutoSize = true;
            this.rdoScrapName.Location = new System.Drawing.Point(86, 86);
            this.rdoScrapName.Name = "rdoScrapName";
            this.rdoScrapName.Size = new System.Drawing.Size(95, 16);
            this.rdoScrapName.TabIndex = 5;
            this.rdoScrapName.TabStop = true;
            this.rdoScrapName.Text = "使用参考图名";
            this.rdoScrapName.UseVisualStyleBackColor = true;
            this.rdoScrapName.CheckedChanged += new System.EventHandler(this.rdoSaveAs_CheckedChanged);
            // 
            // rdoName
            // 
            this.rdoName.AutoSize = true;
            this.rdoName.Location = new System.Drawing.Point(86, 107);
            this.rdoName.Name = "rdoName";
            this.rdoName.Size = new System.Drawing.Size(14, 13);
            this.rdoName.TabIndex = 6;
            this.rdoName.TabStop = true;
            this.rdoName.UseVisualStyleBackColor = true;
            this.rdoName.CheckedChanged += new System.EventHandler(this.rdoSaveAs_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "文件名∶";
            // 
            // chkCopy
            // 
            this.chkCopy.AutoSize = true;
            this.chkCopy.Location = new System.Drawing.Point(28, 276);
            this.chkCopy.Name = "chkCopy";
            this.chkCopy.Size = new System.Drawing.Size(204, 16);
            this.chkCopy.TabIndex = 17;
            this.chkCopy.Text = "复制到剪贴板上的文件的保存路径";
            this.chkCopy.UseVisualStyleBackColor = true;
            // 
            // chkWindow
            // 
            this.chkWindow.AutoSize = true;
            this.chkWindow.Location = new System.Drawing.Point(28, 258);
            this.chkWindow.Name = "chkWindow";
            this.chkWindow.Size = new System.Drawing.Size(102, 16);
            this.chkWindow.TabIndex = 16;
            this.chkWindow.Text = "包含窗口/边框";
            this.chkWindow.UseVisualStyleBackColor = true;
            // 
            // chkShowParam
            // 
            this.chkShowParam.AutoSize = true;
            this.chkShowParam.Checked = true;
            this.chkShowParam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowParam.Location = new System.Drawing.Point(28, 240);
            this.chkShowParam.Name = "chkShowParam";
            this.chkShowParam.Size = new System.Drawing.Size(132, 16);
            this.chkShowParam.TabIndex = 15;
            this.chkShowParam.Text = "保存图像时设置质量";
            this.chkShowParam.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "0";
            // 
            // lblQuality
            // 
            this.lblQuality.Location = new System.Drawing.Point(299, 179);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(25, 12);
            this.lblQuality.TabIndex = 12;
            this.lblQuality.Text = "100";
            this.lblQuality.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // barQuality
            // 
            this.barQuality.AutoSize = false;
            this.barQuality.Location = new System.Drawing.Point(68, 172);
            this.barQuality.Maximum = 100;
            this.barQuality.Name = "barQuality";
            this.barQuality.Size = new System.Drawing.Size(233, 33);
            this.barQuality.TabIndex = 11;
            this.barQuality.TickFrequency = 10;
            this.barQuality.Value = 100;
            this.barQuality.Scroll += new System.EventHandler(this.barQuality_Scroll);
            this.barQuality.ValueChanged += new System.EventHandler(this.barQuality_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "质量：";
            // 
            // btnRef
            // 
            this.btnRef.Location = new System.Drawing.Point(327, 30);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(22, 23);
            this.btnRef.TabIndex = 2;
            this.btnRef.Text = "...";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(75, 32);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(250, 21);
            this.txtFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "保存路径：";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.ApplicationData;
            // 
            // ImageJpegStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(401, 361);
            this.Controls.Add(this.groupBox1);
            this.Name = "ImageJpegStyleItemPanel";
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barQuality)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x0400030D RID: 781
		private global::System.Windows.Forms.Button btnRef;

		// Token: 0x0400030E RID: 782
		private global::System.Windows.Forms.TextBox txtFolder;

		// Token: 0x0400030F RID: 783
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000310 RID: 784
		private global::System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

		// Token: 0x04000311 RID: 785
		private global::System.Windows.Forms.TrackBar barQuality;

		// Token: 0x04000312 RID: 786
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000313 RID: 787
		private global::System.Windows.Forms.CheckBox chkShowParam;

		// Token: 0x04000314 RID: 788
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000315 RID: 789
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000316 RID: 790
		private global::System.Windows.Forms.Label lblQuality;

		// Token: 0x04000317 RID: 791
		private global::System.Windows.Forms.CheckBox chkWindow;

		// Token: 0x04000318 RID: 792
		private global::System.Windows.Forms.CheckBox chkCopy;

		// Token: 0x04000319 RID: 793
		private global::System.Windows.Forms.ComboBox cmbDupli;

		// Token: 0x0400031A RID: 794
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400031B RID: 795
		private global::System.Windows.Forms.RadioButton rdoSaveAs;

		// Token: 0x0400031C RID: 796
		private global::System.Windows.Forms.TextBox txtName;

		// Token: 0x0400031D RID: 797
		private global::System.Windows.Forms.RadioButton rdoScrapName;

		// Token: 0x0400031E RID: 798
		private global::System.Windows.Forms.RadioButton rdoName;

		// Token: 0x0400031F RID: 799
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000320 RID: 800
		private global::System.Windows.Forms.GroupBox groupBox1;
	}
}
