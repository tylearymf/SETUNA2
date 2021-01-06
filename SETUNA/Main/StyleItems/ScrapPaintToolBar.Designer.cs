namespace SETUNA.Main.StyleItems
{
	// Token: 0x02000024 RID: 36
	partial class ScrapPaintToolBar
	{
		// Token: 0x06000181 RID: 385 RVA: 0x0000895F File Offset: 0x00006B5F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00008980 File Offset: 0x00006B80
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picColorA = new System.Windows.Forms.PictureBox();
            this.picColorB = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkPen = new System.Windows.Forms.CheckBox();
            this.chkText = new System.Windows.Forms.CheckBox();
            this.chkErase = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColorA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColorB)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.70213F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.29787F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(46, 263);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.picColorA);
            this.panel1.Controls.Add(this.picColorB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 216);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(42, 45);
            this.panel1.TabIndex = 1;
            // 
            // picColorA
            // 
            this.picColorA.BackColor = System.Drawing.Color.White;
            this.picColorA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picColorA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picColorA.Location = new System.Drawing.Point(6, 5);
            this.picColorA.Name = "picColorA";
            this.picColorA.Size = new System.Drawing.Size(26, 26);
            this.picColorA.TabIndex = 0;
            this.picColorA.TabStop = false;
            this.toolTip1.SetToolTip(this.picColorA, "前景色");
            this.picColorA.BackColorChanged += new System.EventHandler(this.picColorA_BackColorChanged);
            this.picColorA.Click += new System.EventHandler(this.picColorA_Click);
            // 
            // picColorB
            // 
            this.picColorB.BackColor = System.Drawing.Color.Black;
            this.picColorB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picColorB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picColorB.Location = new System.Drawing.Point(22, 19);
            this.picColorB.Name = "picColorB";
            this.picColorB.Size = new System.Drawing.Size(26, 26);
            this.picColorB.TabIndex = 1;
            this.picColorB.TabStop = false;
            this.toolTip1.SetToolTip(this.picColorB, "背景色");
            this.picColorB.Click += new System.EventHandler(this.picColorB_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Controls.Add(this.chkPen, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkText, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkErase, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(40, 208);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // chkPen
            // 
            this.chkPen.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPen.AutoCheck = false;
            this.chkPen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkPen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkPen.Image = global::SETUNA.Properties.Resources.pi_pen;
            this.chkPen.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkPen.Location = new System.Drawing.Point(1, 1);
            this.chkPen.Margin = new System.Windows.Forms.Padding(1);
            this.chkPen.Name = "chkPen";
            this.chkPen.Size = new System.Drawing.Size(38, 28);
            this.chkPen.TabIndex = 4;
            this.toolTip1.SetToolTip(this.chkPen, "笔工具");
            this.chkPen.UseVisualStyleBackColor = true;
            this.chkPen.Click += new System.EventHandler(this.chkPen_Click);
            // 
            // chkText
            // 
            this.chkText.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkText.AutoCheck = false;
            this.chkText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkText.Image = global::SETUNA.Properties.Resources.pi_text;
            this.chkText.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkText.Location = new System.Drawing.Point(1, 61);
            this.chkText.Margin = new System.Windows.Forms.Padding(1);
            this.chkText.Name = "chkText";
            this.chkText.Size = new System.Drawing.Size(38, 28);
            this.chkText.TabIndex = 8;
            this.toolTip1.SetToolTip(this.chkText, "文本工具");
            this.chkText.UseVisualStyleBackColor = true;
            this.chkText.Click += new System.EventHandler(this.chkPen_Click);
            // 
            // chkErase
            // 
            this.chkErase.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkErase.AutoCheck = false;
            this.chkErase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkErase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkErase.Image = global::SETUNA.Properties.Resources.pi_erase;
            this.chkErase.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkErase.Location = new System.Drawing.Point(1, 31);
            this.chkErase.Margin = new System.Windows.Forms.Padding(1);
            this.chkErase.Name = "chkErase";
            this.chkErase.Size = new System.Drawing.Size(38, 28);
            this.chkErase.TabIndex = 5;
            this.toolTip1.SetToolTip(this.chkErase, "橡皮擦工具");
            this.chkErase.UseVisualStyleBackColor = true;
            this.chkErase.Click += new System.EventHandler(this.chkPen_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // ScrapPaintToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(50, 288);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(52, 290);
            this.Name = "ScrapPaintToolBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "工具";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScrapPaintToolBar_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picColorA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColorB)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		// Token: 0x040000AB RID: 171
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.CheckBox chkPen;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.PictureBox picColorB;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.PictureBox picColorA;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.ColorDialog colorDialog1;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.CheckBox chkErase;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.CheckBox chkText;
	}
}
