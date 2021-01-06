namespace SETUNA.Main.StyleItems
{
	// Token: 0x0200008D RID: 141
	partial class MoveStyleItemPanel
	{
		// Token: 0x060004A1 RID: 1185 RVA: 0x0001DAFC File Offset: 0x0001BCFC
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numRight = new System.Windows.Forms.NumericUpDown();
            this.numLeft = new System.Windows.Forms.NumericUpDown();
            this.numDown = new System.Windows.Forms.NumericUpDown();
            this.numUp = new System.Windows.Forms.NumericUpDown();
            this.chkLeft = new System.Windows.Forms.CheckBox();
            this.chkRight = new System.Windows.Forms.CheckBox();
            this.chkUp = new System.Windows.Forms.CheckBox();
            this.chkDown = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUp)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(172, 219);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(248, 219);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numRight);
            this.groupBox1.Controls.Add(this.numLeft);
            this.groupBox1.Controls.Add(this.numDown);
            this.groupBox1.Controls.Add(this.numUp);
            this.groupBox1.Controls.Add(this.chkLeft);
            this.groupBox1.Controls.Add(this.chkRight);
            this.groupBox1.Controls.Add(this.chkUp);
            this.groupBox1.Controls.Add(this.chkDown);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 203);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // numRight
            // 
            this.numRight.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numRight.Location = new System.Drawing.Point(194, 96);
            this.numRight.Name = "numRight";
            this.numRight.Size = new System.Drawing.Size(51, 21);
            this.numRight.TabIndex = 5;
            // 
            // numLeft
            // 
            this.numLeft.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numLeft.Location = new System.Drawing.Point(75, 96);
            this.numLeft.Name = "numLeft";
            this.numLeft.Size = new System.Drawing.Size(51, 21);
            this.numLeft.TabIndex = 3;
            // 
            // numDown
            // 
            this.numDown.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numDown.Location = new System.Drawing.Point(133, 154);
            this.numDown.Name = "numDown";
            this.numDown.Size = new System.Drawing.Size(51, 21);
            this.numDown.TabIndex = 7;
            // 
            // numUp
            // 
            this.numUp.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numUp.Location = new System.Drawing.Point(133, 39);
            this.numUp.Name = "numUp";
            this.numUp.Size = new System.Drawing.Size(51, 21);
            this.numUp.TabIndex = 1;
            // 
            // chkLeft
            // 
            this.chkLeft.Location = new System.Drawing.Point(57, 81);
            this.chkLeft.Name = "chkLeft";
            this.chkLeft.Size = new System.Drawing.Size(73, 49);
            this.chkLeft.TabIndex = 2;
            this.chkLeft.Text = "左";
            this.chkLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkLeft.UseVisualStyleBackColor = true;
            this.chkLeft.CheckedChanged += new System.EventHandler(this.chkLeft_CheckedChanged);
            // 
            // chkRight
            // 
            this.chkRight.Location = new System.Drawing.Point(176, 81);
            this.chkRight.Name = "chkRight";
            this.chkRight.Size = new System.Drawing.Size(73, 49);
            this.chkRight.TabIndex = 4;
            this.chkRight.Text = "右";
            this.chkRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkRight.UseVisualStyleBackColor = true;
            this.chkRight.CheckedChanged += new System.EventHandler(this.chkRight_CheckedChanged);
            // 
            // chkUp
            // 
            this.chkUp.Location = new System.Drawing.Point(115, 24);
            this.chkUp.Name = "chkUp";
            this.chkUp.Size = new System.Drawing.Size(73, 49);
            this.chkUp.TabIndex = 0;
            this.chkUp.Text = "上";
            this.chkUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkUp.UseVisualStyleBackColor = true;
            this.chkUp.CheckedChanged += new System.EventHandler(this.chkUp_CheckedChanged);
            // 
            // chkDown
            // 
            this.chkDown.Location = new System.Drawing.Point(115, 139);
            this.chkDown.Name = "chkDown";
            this.chkDown.Size = new System.Drawing.Size(73, 49);
            this.chkDown.TabIndex = 6;
            this.chkDown.Text = "下";
            this.chkDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkDown.UseVisualStyleBackColor = true;
            this.chkDown.CheckedChanged += new System.EventHandler(this.chkDown_CheckedChanged);
            // 
            // MoveStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(326, 251);
            this.Controls.Add(this.groupBox1);
            this.Name = "MoveStyleItemPanel";
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUp)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x040002C5 RID: 709
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040002C6 RID: 710
		private global::System.Windows.Forms.NumericUpDown numRight;

		// Token: 0x040002C7 RID: 711
		private global::System.Windows.Forms.NumericUpDown numLeft;

		// Token: 0x040002C8 RID: 712
		private global::System.Windows.Forms.NumericUpDown numDown;

		// Token: 0x040002C9 RID: 713
		private global::System.Windows.Forms.CheckBox chkRight;

		// Token: 0x040002CA RID: 714
		private global::System.Windows.Forms.CheckBox chkLeft;

		// Token: 0x040002CB RID: 715
		private global::System.Windows.Forms.CheckBox chkUp;

		// Token: 0x040002CC RID: 716
		private global::System.Windows.Forms.CheckBox chkDown;

		// Token: 0x040002CD RID: 717
		private global::System.Windows.Forms.NumericUpDown numUp;
	}
}
