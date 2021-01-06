namespace SETUNA.Main.StyleItems
{
	// Token: 0x02000003 RID: 3
	partial class MarginStyleItemPanel
	{
		// Token: 0x0600000C RID: 12 RVA: 0x0000230C File Offset: 0x0000050C
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.rdoSolid = new System.Windows.Forms.RadioButton();
            this.rdo3D = new System.Windows.Forms.RadioButton();
            this.rdoWindow = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numMargin = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMargin)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(300, 214);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(376, 214);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkTopMost);
            this.groupBox1.Controls.Add(this.rdoSolid);
            this.groupBox1.Controls.Add(this.rdo3D);
            this.groupBox1.Controls.Add(this.rdoWindow);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numMargin);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new System.Drawing.Point(36, 46);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(120, 16);
            this.chkTopMost.TabIndex = 11;
            this.chkTopMost.Text = "设置为总在最上面";
            this.chkTopMost.UseVisualStyleBackColor = true;
            // 
            // rdoSolid
            // 
            this.rdoSolid.AutoSize = true;
            this.rdoSolid.Location = new System.Drawing.Point(17, 79);
            this.rdoSolid.Name = "rdoSolid";
            this.rdoSolid.Size = new System.Drawing.Size(71, 16);
            this.rdoSolid.TabIndex = 1;
            this.rdoSolid.TabStop = true;
            this.rdoSolid.Text = "单色边框";
            this.rdoSolid.UseVisualStyleBackColor = true;
            this.rdoSolid.CheckedChanged += new System.EventHandler(this.rdoWindow_CheckedChanged);
            // 
            // rdo3D
            // 
            this.rdo3D.AutoSize = true;
            this.rdo3D.Location = new System.Drawing.Point(17, 156);
            this.rdo3D.Name = "rdo3D";
            this.rdo3D.Size = new System.Drawing.Size(71, 16);
            this.rdo3D.TabIndex = 5;
            this.rdo3D.TabStop = true;
            this.rdo3D.Text = "立体边框";
            this.rdo3D.UseVisualStyleBackColor = true;
            this.rdo3D.CheckedChanged += new System.EventHandler(this.rdoWindow_CheckedChanged);
            // 
            // rdoWindow
            // 
            this.rdoWindow.AutoSize = true;
            this.rdoWindow.Location = new System.Drawing.Point(17, 27);
            this.rdoWindow.Name = "rdoWindow";
            this.rdoWindow.Size = new System.Drawing.Size(71, 16);
            this.rdoWindow.TabIndex = 0;
            this.rdoWindow.TabStop = true;
            this.rdoWindow.Text = "窗口边框";
            this.rdoWindow.UseVisualStyleBackColor = true;
            this.rdoWindow.CheckedChanged += new System.EventHandler(this.rdoWindow_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(93, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 19);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "颜色∶";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "宽度：";
            // 
            // numMargin
            // 
            this.numMargin.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numMargin.Location = new System.Drawing.Point(93, 96);
            this.numMargin.Name = "numMargin";
            this.numMargin.Size = new System.Drawing.Size(48, 21);
            this.numMargin.TabIndex = 3;
            this.numMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMargin.ValueChanged += new System.EventHandler(this.rdoWindow_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picPreview);
            this.groupBox2.Location = new System.Drawing.Point(231, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPreview.Location = new System.Drawing.Point(6, 18);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(203, 176);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // MarginStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(454, 246);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MarginStyleItemPanel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MarginStyleItemPanel_FormClosed);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMargin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.ColorDialog colorDialog1;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.PictureBox picPreview;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.NumericUpDown numMargin;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.RadioButton rdoWindow;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.RadioButton rdoSolid;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.RadioButton rdo3D;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.CheckBox chkTopMost;
	}
}
