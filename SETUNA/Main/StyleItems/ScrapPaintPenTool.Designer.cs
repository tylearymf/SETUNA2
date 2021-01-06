namespace SETUNA.Main.StyleItems
{
	// Token: 0x020000A6 RID: 166
	partial class ScrapPaintPenTool
	{
		// Token: 0x0600055B RID: 1371 RVA: 0x00024B5B File Offset: 0x00022D5B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00024B7C File Offset: 0x00022D7C
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPen = new System.Windows.Forms.Panel();
            this.numPenSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.penButton5 = new SETUNA.Main.StyleItems.PenButton();
            this.penButton4 = new SETUNA.Main.StyleItems.PenButton();
            this.penButton3 = new SETUNA.Main.StyleItems.PenButton();
            this.penButton2 = new SETUNA.Main.StyleItems.PenButton();
            this.penButton1 = new SETUNA.Main.StyleItems.PenButton();
            this.pnlOpacity = new System.Windows.Forms.Panel();
            this.numOpacity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCap = new System.Windows.Forms.Panel();
            this.cmbStart = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlPen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPenSize)).BeginInit();
            this.pnlOpacity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).BeginInit();
            this.pnlCap.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlPen);
            this.flowLayoutPanel1.Controls.Add(this.pnlOpacity);
            this.flowLayoutPanel1.Controls.Add(this.pnlCap);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(462, 57);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pnlPen
            // 
            this.pnlPen.Controls.Add(this.numPenSize);
            this.pnlPen.Controls.Add(this.label4);
            this.pnlPen.Controls.Add(this.label3);
            this.pnlPen.Controls.Add(this.penButton5);
            this.pnlPen.Controls.Add(this.penButton4);
            this.pnlPen.Controls.Add(this.penButton3);
            this.pnlPen.Controls.Add(this.penButton2);
            this.pnlPen.Controls.Add(this.penButton1);
            this.pnlPen.Location = new System.Drawing.Point(0, 0);
            this.pnlPen.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPen.Name = "pnlPen";
            this.pnlPen.Size = new System.Drawing.Size(217, 35);
            this.pnlPen.TabIndex = 0;
            // 
            // numPenSize
            // 
            this.numPenSize.Location = new System.Drawing.Point(161, 13);
            this.numPenSize.Name = "numPenSize";
            this.numPenSize.Size = new System.Drawing.Size(36, 21);
            this.numPenSize.TabIndex = 10;
            this.numPenSize.TabStop = false;
            this.numPenSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPenSize.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numPenSize.ValueChanged += new System.EventHandler(this.numPenSize_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "px";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(160, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 10);
            this.label3.TabIndex = 11;
            this.label3.Text = "尺寸";
            // 
            // penButton5
            // 
            this.penButton5.Appearance = System.Windows.Forms.Appearance.Button;
            this.penButton5.AutoCheck = false;
            this.penButton5.ButtonColor = System.Drawing.Color.Black;
            this.penButton5.Location = new System.Drawing.Point(127, 4);
            this.penButton5.Name = "penButton5";
            this.penButton5.PenSize = 20;
            this.penButton5.Size = new System.Drawing.Size(31, 29);
            this.penButton5.TabIndex = 9;
            this.toolTip1.SetToolTip(this.penButton5, "20px");
            this.penButton5.UseVisualStyleBackColor = true;
            this.penButton5.Click += new System.EventHandler(this.penButton1_Click);
            // 
            // penButton4
            // 
            this.penButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.penButton4.AutoCheck = false;
            this.penButton4.ButtonColor = System.Drawing.Color.Black;
            this.penButton4.Location = new System.Drawing.Point(96, 4);
            this.penButton4.Name = "penButton4";
            this.penButton4.PenSize = 15;
            this.penButton4.Size = new System.Drawing.Size(31, 29);
            this.penButton4.TabIndex = 8;
            this.toolTip1.SetToolTip(this.penButton4, "15px");
            this.penButton4.UseVisualStyleBackColor = true;
            this.penButton4.Click += new System.EventHandler(this.penButton1_Click);
            // 
            // penButton3
            // 
            this.penButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.penButton3.AutoCheck = false;
            this.penButton3.ButtonColor = System.Drawing.Color.Black;
            this.penButton3.Location = new System.Drawing.Point(65, 4);
            this.penButton3.Name = "penButton3";
            this.penButton3.PenSize = 10;
            this.penButton3.Size = new System.Drawing.Size(31, 29);
            this.penButton3.TabIndex = 7;
            this.toolTip1.SetToolTip(this.penButton3, "10px");
            this.penButton3.UseVisualStyleBackColor = true;
            this.penButton3.Click += new System.EventHandler(this.penButton1_Click);
            // 
            // penButton2
            // 
            this.penButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.penButton2.AutoCheck = false;
            this.penButton2.ButtonColor = System.Drawing.Color.Black;
            this.penButton2.Location = new System.Drawing.Point(34, 4);
            this.penButton2.Name = "penButton2";
            this.penButton2.PenSize = 5;
            this.penButton2.Size = new System.Drawing.Size(31, 29);
            this.penButton2.TabIndex = 6;
            this.toolTip1.SetToolTip(this.penButton2, "5px");
            this.penButton2.UseVisualStyleBackColor = true;
            this.penButton2.Click += new System.EventHandler(this.penButton1_Click);
            // 
            // penButton1
            // 
            this.penButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.penButton1.AutoCheck = false;
            this.penButton1.ButtonColor = System.Drawing.Color.Black;
            this.penButton1.Location = new System.Drawing.Point(3, 4);
            this.penButton1.Name = "penButton1";
            this.penButton1.PenSize = 1;
            this.penButton1.Size = new System.Drawing.Size(31, 29);
            this.penButton1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.penButton1, "1px");
            this.penButton1.UseVisualStyleBackColor = true;
            this.penButton1.Click += new System.EventHandler(this.penButton1_Click);
            // 
            // pnlOpacity
            // 
            this.pnlOpacity.Controls.Add(this.numOpacity);
            this.pnlOpacity.Controls.Add(this.label1);
            this.pnlOpacity.Controls.Add(this.label2);
            this.pnlOpacity.Location = new System.Drawing.Point(217, 0);
            this.pnlOpacity.Margin = new System.Windows.Forms.Padding(0);
            this.pnlOpacity.Name = "pnlOpacity";
            this.pnlOpacity.Size = new System.Drawing.Size(58, 35);
            this.pnlOpacity.TabIndex = 1;
            // 
            // numOpacity
            // 
            this.numOpacity.Location = new System.Drawing.Point(3, 13);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new System.Drawing.Size(40, 21);
            this.numOpacity.TabIndex = 0;
            this.numOpacity.TabStop = false;
            this.numOpacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numOpacity.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numOpacity.ValueChanged += new System.EventHandler(this.numOpacity_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 10);
            this.label1.TabIndex = 1;
            this.label1.Text = "不透明度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // pnlCap
            // 
            this.pnlCap.Controls.Add(this.cmbStart);
            this.pnlCap.Location = new System.Drawing.Point(275, 0);
            this.pnlCap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCap.Name = "pnlCap";
            this.pnlCap.Size = new System.Drawing.Size(159, 35);
            this.pnlCap.TabIndex = 2;
            // 
            // cmbStart
            // 
            this.cmbStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStart.FormattingEnabled = true;
            this.cmbStart.Location = new System.Drawing.Point(3, 13);
            this.cmbStart.Name = "cmbStart";
            this.cmbStart.Size = new System.Drawing.Size(116, 20);
            this.cmbStart.TabIndex = 0;
            this.cmbStart.TabStop = false;
            // 
            // ScrapPaintPenTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 57);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(292, 59);
            this.Name = "ScrapPaintPenTool";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "笔工具";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScrapPaintPenTool_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlPen.ResumeLayout(false);
            this.pnlPen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPenSize)).EndInit();
            this.pnlOpacity.ResumeLayout(false);
            this.pnlOpacity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).EndInit();
            this.pnlCap.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		// Token: 0x04000357 RID: 855
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000358 RID: 856
		private global::System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

		// Token: 0x04000359 RID: 857
		private global::System.Windows.Forms.Panel pnlPen;

		// Token: 0x0400035A RID: 858
		private global::System.Windows.Forms.Panel pnlOpacity;

		// Token: 0x0400035B RID: 859
		private global::System.Windows.Forms.NumericUpDown numOpacity;

		// Token: 0x0400035C RID: 860
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400035D RID: 861
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400035E RID: 862
		private global::System.Windows.Forms.Panel pnlCap;

		// Token: 0x0400035F RID: 863
		private global::System.Windows.Forms.ComboBox cmbStart;

		// Token: 0x04000360 RID: 864
		private global::SETUNA.Main.StyleItems.PenButton penButton1;

		// Token: 0x04000361 RID: 865
		private global::SETUNA.Main.StyleItems.PenButton penButton5;

		// Token: 0x04000362 RID: 866
		private global::SETUNA.Main.StyleItems.PenButton penButton4;

		// Token: 0x04000363 RID: 867
		private global::SETUNA.Main.StyleItems.PenButton penButton3;

		// Token: 0x04000364 RID: 868
		private global::SETUNA.Main.StyleItems.PenButton penButton2;

		// Token: 0x04000365 RID: 869
		private global::System.Windows.Forms.NumericUpDown numPenSize;

		// Token: 0x04000366 RID: 870
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000367 RID: 871
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000368 RID: 872
		private global::System.Windows.Forms.ToolTip toolTip1;
	}
}
