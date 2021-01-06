namespace SETUNA.Main.StyleItems
{
	// Token: 0x02000099 RID: 153
	partial class ScrapPaintTextTool
	{
		// Token: 0x06000510 RID: 1296 RVA: 0x00023AC8 File Offset: 0x00021CC8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00023AE8 File Offset: 0x00021CE8
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPen = new System.Windows.Forms.Panel();
            this.cmbFont = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlEditing = new System.Windows.Forms.Panel();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.btnEditOK = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlPen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.pnlEditing.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlPen);
            this.flowLayoutPanel1.Controls.Add(this.pnlEditing);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(451, 57);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pnlPen
            // 
            this.pnlPen.Controls.Add(this.cmbFont);
            this.pnlPen.Controls.Add(this.label5);
            this.pnlPen.Controls.Add(this.numFontSize);
            this.pnlPen.Controls.Add(this.label4);
            this.pnlPen.Controls.Add(this.label3);
            this.pnlPen.Location = new System.Drawing.Point(0, 0);
            this.pnlPen.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPen.Name = "pnlPen";
            this.pnlPen.Size = new System.Drawing.Size(278, 35);
            this.pnlPen.TabIndex = 0;
            // 
            // cmbFont
            // 
            this.cmbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFont.DropDownWidth = 230;
            this.cmbFont.FormattingEnabled = true;
            this.cmbFont.Location = new System.Drawing.Point(3, 13);
            this.cmbFont.Name = "cmbFont";
            this.cmbFont.Size = new System.Drawing.Size(170, 20);
            this.cmbFont.TabIndex = 14;
            this.cmbFont.SelectedIndexChanged += new System.EventHandler(this.cmbFont_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 10);
            this.label5.TabIndex = 13;
            this.label5.Text = "字体";
            // 
            // numFontSize
            // 
            this.numFontSize.Location = new System.Drawing.Point(197, 13);
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(54, 21);
            this.numFontSize.TabIndex = 10;
            this.numFontSize.TabStop = false;
            this.numFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numFontSize.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "pt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(195, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 10);
            this.label3.TabIndex = 11;
            this.label3.Text = "尺寸";
            // 
            // pnlEditing
            // 
            this.pnlEditing.Controls.Add(this.btnEditCancel);
            this.pnlEditing.Controls.Add(this.btnEditOK);
            this.pnlEditing.Location = new System.Drawing.Point(278, 0);
            this.pnlEditing.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEditing.Name = "pnlEditing";
            this.pnlEditing.Size = new System.Drawing.Size(65, 35);
            this.pnlEditing.TabIndex = 1;
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.Location = new System.Drawing.Point(32, 9);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(28, 23);
            this.btnEditCancel.TabIndex = 1;
            this.btnEditCancel.Text = "×";
            this.btnEditCancel.UseVisualStyleBackColor = true;
            // 
            // btnEditOK
            // 
            this.btnEditOK.Location = new System.Drawing.Point(3, 9);
            this.btnEditOK.Name = "btnEditOK";
            this.btnEditOK.Size = new System.Drawing.Size(28, 23);
            this.btnEditOK.TabIndex = 0;
            this.btnEditOK.Text = "○";
            this.btnEditOK.UseVisualStyleBackColor = true;
            this.btnEditOK.Click += new System.EventHandler(this.btnEditOK_Click);
            // 
            // ScrapPaintTextTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 57);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(292, 59);
            this.Name = "ScrapPaintTextTool";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "文字工具";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScrapPaintTextTool_FormClosing);
            this.Shown += new System.EventHandler(this.ScrapPaintTextTool_Shown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlPen.ResumeLayout(false);
            this.pnlPen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.pnlEditing.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		// Token: 0x04000336 RID: 822
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000337 RID: 823
		private global::System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

		// Token: 0x04000338 RID: 824
		private global::System.Windows.Forms.Panel pnlPen;

		// Token: 0x04000339 RID: 825
		private global::System.Windows.Forms.NumericUpDown numFontSize;

		// Token: 0x0400033A RID: 826
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400033B RID: 827
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400033C RID: 828
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x0400033D RID: 829
		private global::System.Windows.Forms.ComboBox cmbFont;

		// Token: 0x0400033E RID: 830
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400033F RID: 831
		private global::System.Windows.Forms.Panel pnlEditing;

		// Token: 0x04000340 RID: 832
		private global::System.Windows.Forms.Button btnEditCancel;

		// Token: 0x04000341 RID: 833
		private global::System.Windows.Forms.Button btnEditOK;
	}
}
