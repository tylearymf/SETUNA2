namespace SETUNA.Main.StyleItems
{
	// Token: 0x0200000F RID: 15
	partial class ImagePngStyleItemPanel
	{
		// Token: 0x060000CE RID: 206 RVA: 0x00005ACC File Offset: 0x00003CCC
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDupli = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoSaveAs = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.rdoScrapName = new System.Windows.Forms.RadioButton();
            this.rdoName = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCopy = new System.Windows.Forms.CheckBox();
            this.chkWindow = new System.Windows.Forms.CheckBox();
            this.btnRef = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(249, 231);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(323, 231);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDupli);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdoSaveAs);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.rdoScrapName);
            this.groupBox1.Controls.Add(this.rdoName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkCopy);
            this.groupBox1.Controls.Add(this.chkWindow);
            this.groupBox1.Controls.Add(this.btnRef);
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 217);
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
            this.cmbDupli.Location = new System.Drawing.Point(129, 127);
            this.cmbDupli.Name = "cmbDupli";
            this.cmbDupli.Size = new System.Drawing.Size(133, 20);
            this.cmbDupli.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "重复时∶";
            // 
            // rdoSaveAs
            // 
            this.rdoSaveAs.AutoSize = true;
            this.rdoSaveAs.Location = new System.Drawing.Point(82, 66);
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
            this.txtName.Location = new System.Drawing.Point(99, 104);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(223, 21);
            this.txtName.TabIndex = 7;
            // 
            // rdoScrapName
            // 
            this.rdoScrapName.AutoSize = true;
            this.rdoScrapName.Location = new System.Drawing.Point(82, 86);
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
            this.rdoName.Location = new System.Drawing.Point(82, 107);
            this.rdoName.Name = "rdoName";
            this.rdoName.Size = new System.Drawing.Size(14, 13);
            this.rdoName.TabIndex = 6;
            this.rdoName.TabStop = true;
            this.rdoName.UseVisualStyleBackColor = true;
            this.rdoName.CheckedChanged += new System.EventHandler(this.rdoSaveAs_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件名∶";
            // 
            // chkCopy
            // 
            this.chkCopy.AutoSize = true;
            this.chkCopy.Location = new System.Drawing.Point(25, 182);
            this.chkCopy.Name = "chkCopy";
            this.chkCopy.Size = new System.Drawing.Size(204, 16);
            this.chkCopy.TabIndex = 11;
            this.chkCopy.Text = "复制到剪贴板上的文件的保存路径";
            this.chkCopy.UseVisualStyleBackColor = true;
            // 
            // chkWindow
            // 
            this.chkWindow.AutoSize = true;
            this.chkWindow.Location = new System.Drawing.Point(25, 164);
            this.chkWindow.Name = "chkWindow";
            this.chkWindow.Size = new System.Drawing.Size(102, 16);
            this.chkWindow.TabIndex = 10;
            this.chkWindow.Text = "包含窗口/边框";
            this.chkWindow.UseVisualStyleBackColor = true;
            // 
            // btnRef
            // 
            this.btnRef.Location = new System.Drawing.Point(324, 30);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(22, 23);
            this.btnRef.TabIndex = 2;
            this.btnRef.Text = "...";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(72, 32);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(250, 21);
            this.txtFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目的地：";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.ApplicationData;
            // 
            // ImagePngStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(401, 263);
            this.Controls.Add(this.groupBox1);
            this.Name = "ImagePngStyleItemPanel";
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.Button btnRef;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.TextBox txtFolder;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.CheckBox chkWindow;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.CheckBox chkCopy;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.ComboBox cmbDupli;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.RadioButton rdoSaveAs;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.TextBox txtName;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.RadioButton rdoScrapName;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.RadioButton rdoName;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.GroupBox groupBox1;
	}
}
