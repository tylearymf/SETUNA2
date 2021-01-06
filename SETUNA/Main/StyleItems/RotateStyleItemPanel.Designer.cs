namespace SETUNA.Main.StyleItems
{
	// Token: 0x02000090 RID: 144
	partial class RotateStyleItemPanel
	{
		// Token: 0x060004BD RID: 1213 RVA: 0x00020410 File Offset: 0x0001E610
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkHorizon = new System.Windows.Forms.CheckBox();
            this.chkVertical = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdo180 = new System.Windows.Forms.RadioButton();
            this.rdoLeft90 = new System.Windows.Forms.RadioButton();
            this.rdoRight90 = new System.Windows.Forms.RadioButton();
            this.rdoNone = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(299, 174);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(376, 174);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkHorizon);
            this.groupBox1.Controls.Add(this.chkVertical);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // chkHorizon
            // 
            this.chkHorizon.AutoSize = true;
            this.chkHorizon.Location = new System.Drawing.Point(132, 60);
            this.chkHorizon.Name = "chkHorizon";
            this.chkHorizon.Size = new System.Drawing.Size(72, 16);
            this.chkHorizon.TabIndex = 11;
            this.chkHorizon.Text = "水平翻转";
            this.chkHorizon.UseVisualStyleBackColor = true;
            this.chkHorizon.CheckedChanged += new System.EventHandler(this.rdoNone_CheckedChanged);
            // 
            // chkVertical
            // 
            this.chkVertical.AutoSize = true;
            this.chkVertical.Location = new System.Drawing.Point(132, 43);
            this.chkVertical.Name = "chkVertical";
            this.chkVertical.Size = new System.Drawing.Size(72, 16);
            this.chkVertical.TabIndex = 10;
            this.chkVertical.Text = "垂直翻转";
            this.chkVertical.UseVisualStyleBackColor = true;
            this.chkVertical.CheckedChanged += new System.EventHandler(this.rdoNone_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "翻转参考图∶";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdo180);
            this.panel1.Controls.Add(this.rdoLeft90);
            this.panel1.Controls.Add(this.rdoRight90);
            this.panel1.Controls.Add(this.rdoNone);
            this.panel1.Location = new System.Drawing.Point(22, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(86, 97);
            this.panel1.TabIndex = 1;
            // 
            // rdo180
            // 
            this.rdo180.AutoSize = true;
            this.rdo180.Location = new System.Drawing.Point(3, 74);
            this.rdo180.Name = "rdo180";
            this.rdo180.Size = new System.Drawing.Size(53, 16);
            this.rdo180.TabIndex = 3;
            this.rdo180.Text = "180度";
            this.rdo180.UseVisualStyleBackColor = true;
            this.rdo180.CheckedChanged += new System.EventHandler(this.rdoNone_CheckedChanged);
            // 
            // rdoLeft90
            // 
            this.rdoLeft90.AutoSize = true;
            this.rdoLeft90.Location = new System.Drawing.Point(3, 52);
            this.rdoLeft90.Name = "rdoLeft90";
            this.rdoLeft90.Size = new System.Drawing.Size(71, 16);
            this.rdoLeft90.TabIndex = 2;
            this.rdoLeft90.Text = "左转90度";
            this.rdoLeft90.UseVisualStyleBackColor = true;
            this.rdoLeft90.CheckedChanged += new System.EventHandler(this.rdoNone_CheckedChanged);
            // 
            // rdoRight90
            // 
            this.rdoRight90.AutoSize = true;
            this.rdoRight90.Location = new System.Drawing.Point(3, 30);
            this.rdoRight90.Name = "rdoRight90";
            this.rdoRight90.Size = new System.Drawing.Size(71, 16);
            this.rdoRight90.TabIndex = 1;
            this.rdoRight90.Text = "右转90度";
            this.rdoRight90.UseVisualStyleBackColor = true;
            this.rdoRight90.CheckedChanged += new System.EventHandler(this.rdoNone_CheckedChanged);
            // 
            // rdoNone
            // 
            this.rdoNone.AutoSize = true;
            this.rdoNone.Checked = true;
            this.rdoNone.Location = new System.Drawing.Point(3, 8);
            this.rdoNone.Name = "rdoNone";
            this.rdoNone.Size = new System.Drawing.Size(35, 16);
            this.rdoNone.TabIndex = 0;
            this.rdoNone.TabStop = true;
            this.rdoNone.Text = "无";
            this.rdoNone.UseVisualStyleBackColor = true;
            this.rdoNone.CheckedChanged += new System.EventHandler(this.rdoNone_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "旋转参考图：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picPreview);
            this.groupBox2.Location = new System.Drawing.Point(261, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 157);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
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
            // RotateStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(453, 206);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RotateStyleItemPanel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RotateStyleItemPanel_FormClosed);
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x040002ED RID: 749
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040002EE RID: 750
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040002EF RID: 751
		private global::System.Windows.Forms.RadioButton rdoRight90;

		// Token: 0x040002F0 RID: 752
		private global::System.Windows.Forms.RadioButton rdoNone;

		// Token: 0x040002F1 RID: 753
		private global::System.Windows.Forms.RadioButton rdo180;

		// Token: 0x040002F2 RID: 754
		private global::System.Windows.Forms.RadioButton rdoLeft90;

		// Token: 0x040002F3 RID: 755
		private global::System.Windows.Forms.CheckBox chkHorizon;

		// Token: 0x040002F4 RID: 756
		private global::System.Windows.Forms.CheckBox chkVertical;

		// Token: 0x040002F5 RID: 757
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040002F7 RID: 759
		private global::System.Windows.Forms.PictureBox picPreview;

		// Token: 0x040002F8 RID: 760
		private global::System.Windows.Forms.Label label1;
	}
}
