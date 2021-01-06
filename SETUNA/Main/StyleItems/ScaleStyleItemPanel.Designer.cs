namespace SETUNA.Main.StyleItems
{
	// Token: 0x0200008E RID: 142
	partial class ScaleStyleItemPanel
	{
		// Token: 0x060004A9 RID: 1193 RVA: 0x0001E580 File Offset: 0x0001C780
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInterpolation = new System.Windows.Forms.Label();
            this.cmbInterpolation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numRelativeScale = new System.Windows.Forms.NumericUpDown();
            this.barRelative = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.barFixed = new System.Windows.Forms.TrackBar();
            this.rdoIncrement = new System.Windows.Forms.RadioButton();
            this.rdoFixed = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numFixedScale = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRelativeScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barRelative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barFixed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFixedScale)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(197, 189);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(273, 189);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInterpolation);
            this.groupBox1.Controls.Add(this.cmbInterpolation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numRelativeScale);
            this.groupBox1.Controls.Add(this.barRelative);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.barFixed);
            this.groupBox1.Controls.Add(this.rdoIncrement);
            this.groupBox1.Controls.Add(this.rdoFixed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numFixedScale);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // lblInterpolation
            // 
            this.lblInterpolation.AccessibleDescription = "";
            this.lblInterpolation.AutoSize = true;
            this.lblInterpolation.Location = new System.Drawing.Point(28, 127);
            this.lblInterpolation.Name = "lblInterpolation";
            this.lblInterpolation.Size = new System.Drawing.Size(65, 12);
            this.lblInterpolation.TabIndex = 9;
            this.lblInterpolation.Text = "插值方法：";
            // 
            // cmbInterpolation
            // 
            this.cmbInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterpolation.FormattingEnabled = true;
            this.cmbInterpolation.Location = new System.Drawing.Point(107, 124);
            this.cmbInterpolation.Name = "cmbInterpolation";
            this.cmbInterpolation.Size = new System.Drawing.Size(177, 20);
            this.cmbInterpolation.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "%";
            // 
            // numRelativeScale
            // 
            this.numRelativeScale.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numRelativeScale.Location = new System.Drawing.Point(236, 80);
            this.numRelativeScale.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numRelativeScale.Name = "numRelativeScale";
            this.numRelativeScale.Size = new System.Drawing.Size(48, 21);
            this.numRelativeScale.TabIndex = 7;
            this.numRelativeScale.ValueChanged += new System.EventHandler(this.numFixedScale_ValueChanged);
            // 
            // barRelative
            // 
            this.barRelative.AutoSize = false;
            this.barRelative.Location = new System.Drawing.Point(107, 80);
            this.barRelative.Maximum = 190;
            this.barRelative.Minimum = -190;
            this.barRelative.Name = "barRelative";
            this.barRelative.Size = new System.Drawing.Size(123, 20);
            this.barRelative.TabIndex = 6;
            this.barRelative.TickFrequency = 20;
            this.barRelative.Scroll += new System.EventHandler(this.barFixed_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "%";
            // 
            // barFixed
            // 
            this.barFixed.AutoSize = false;
            this.barFixed.Location = new System.Drawing.Point(107, 50);
            this.barFixed.Maximum = 200;
            this.barFixed.Minimum = 10;
            this.barFixed.Name = "barFixed";
            this.barFixed.Size = new System.Drawing.Size(123, 20);
            this.barFixed.TabIndex = 2;
            this.barFixed.TickFrequency = 10;
            this.barFixed.Value = 100;
            this.barFixed.Scroll += new System.EventHandler(this.barFixed_Scroll);
            // 
            // rdoIncrement
            // 
            this.rdoIncrement.AutoSize = true;
            this.rdoIncrement.Location = new System.Drawing.Point(42, 80);
            this.rdoIncrement.Name = "rdoIncrement";
            this.rdoIncrement.Size = new System.Drawing.Size(59, 16);
            this.rdoIncrement.TabIndex = 5;
            this.rdoIncrement.Text = "相对值";
            this.rdoIncrement.UseVisualStyleBackColor = true;
            this.rdoIncrement.CheckedChanged += new System.EventHandler(this.rdoFixed_CheckedChanged);
            // 
            // rdoFixed
            // 
            this.rdoFixed.AutoSize = true;
            this.rdoFixed.Checked = true;
            this.rdoFixed.Location = new System.Drawing.Point(42, 50);
            this.rdoFixed.Name = "rdoFixed";
            this.rdoFixed.Size = new System.Drawing.Size(59, 16);
            this.rdoFixed.TabIndex = 1;
            this.rdoFixed.TabStop = true;
            this.rdoFixed.Text = "绝对值";
            this.rdoFixed.UseVisualStyleBackColor = true;
            this.rdoFixed.CheckedChanged += new System.EventHandler(this.rdoFixed_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "尺度∶";
            // 
            // numFixedScale
            // 
            this.numFixedScale.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numFixedScale.Location = new System.Drawing.Point(236, 50);
            this.numFixedScale.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numFixedScale.Name = "numFixedScale";
            this.numFixedScale.Size = new System.Drawing.Size(48, 21);
            this.numFixedScale.TabIndex = 3;
            this.numFixedScale.ValueChanged += new System.EventHandler(this.numFixedScale_ValueChanged);
            // 
            // ScaleStyleItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(351, 221);
            this.Controls.Add(this.groupBox1);
            this.Name = "ScaleStyleItemPanel";
            this.Controls.SetChildIndex(this.cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRelativeScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barRelative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barFixed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFixedScale)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x040002CE RID: 718
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040002CF RID: 719
		private global::System.Windows.Forms.RadioButton rdoIncrement;

		// Token: 0x040002D0 RID: 720
		private global::System.Windows.Forms.RadioButton rdoFixed;

		// Token: 0x040002D1 RID: 721
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002D2 RID: 722
		private global::System.Windows.Forms.TrackBar barFixed;

		// Token: 0x040002D3 RID: 723
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040002D4 RID: 724
		private global::System.Windows.Forms.TrackBar barRelative;

		// Token: 0x040002D5 RID: 725
		private global::System.Windows.Forms.Label lblInterpolation;

		// Token: 0x040002D6 RID: 726
		private global::System.Windows.Forms.ComboBox cmbInterpolation;

		// Token: 0x040002D7 RID: 727
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040002D8 RID: 728
		private global::System.Windows.Forms.NumericUpDown numRelativeScale;

		// Token: 0x040002D9 RID: 729
		private global::System.Windows.Forms.NumericUpDown numFixedScale;
	}
}
