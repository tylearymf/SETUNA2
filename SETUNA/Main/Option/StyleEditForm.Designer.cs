namespace SETUNA.Main.Option
{
	// Token: 0x02000081 RID: 129
	partial class StyleEditForm
	{
		// Token: 0x0600043D RID: 1085 RVA: 0x0001AECB File Offset: 0x000190CB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0001AEEC File Offset: 0x000190EC
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStyleName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKeyDelete = new System.Windows.Forms.Button();
            this.listKeys = new System.Windows.Forms.ListBox();
            this.btnKeyEntry = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listStyleItem = new SETUNA.Main.StyleItemListBox();
            this.listAllStyleItem = new SETUNA.Main.StyleItemListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnItemDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnItemDown = new System.Windows.Forms.Button();
            this.btnItemUp = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.hotkey = new SETUNA.Main.HotkeyControl();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(1, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "自动操作名∶";
            // 
            // txtStyleName
            // 
            this.txtStyleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.txtStyleName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStyleName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtStyleName.Location = new System.Drawing.Point(3, 317);
            this.txtStyleName.Name = "txtStyleName";
            this.txtStyleName.Size = new System.Drawing.Size(193, 23);
            this.txtStyleName.TabIndex = 1;
            this.toolTip2.SetToolTip(this.txtStyleName, "您可以对具体自动操作命名。");
            this.txtStyleName.TextChanged += new System.EventHandler(this.txtStyleName_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "aaa";
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.txtStyleName);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(579, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 381);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hotkey);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnKeyDelete);
            this.groupBox1.Controls.Add(this.listKeys);
            this.groupBox1.Controls.Add(this.btnKeyEntry);
            this.groupBox1.Location = new System.Drawing.Point(3, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指定快捷键";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "快捷键分配：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "快捷键：";
            // 
            // btnKeyDelete
            // 
            this.btnKeyDelete.Location = new System.Drawing.Point(133, 179);
            this.btnKeyDelete.Name = "btnKeyDelete";
            this.btnKeyDelete.Size = new System.Drawing.Size(48, 24);
            this.btnKeyDelete.TabIndex = 5;
            this.btnKeyDelete.Text = "删除";
            this.btnKeyDelete.UseVisualStyleBackColor = true;
            this.btnKeyDelete.Click += new System.EventHandler(this.btnKeyDelete_Click);
            // 
            // listKeys
            // 
            this.listKeys.FormattingEnabled = true;
            this.listKeys.IntegralHeight = false;
            this.listKeys.ItemHeight = 12;
            this.listKeys.Location = new System.Drawing.Point(12, 99);
            this.listKeys.Name = "listKeys";
            this.listKeys.Size = new System.Drawing.Size(169, 78);
            this.listKeys.TabIndex = 4;
            this.toolTip2.SetToolTip(this.listKeys, "选择参考图，如果点击分配的快捷键则应用自动操作。");
            // 
            // btnKeyEntry
            // 
            this.btnKeyEntry.Location = new System.Drawing.Point(133, 60);
            this.btnKeyEntry.Name = "btnKeyEntry";
            this.btnKeyEntry.Size = new System.Drawing.Size(48, 24);
            this.btnKeyEntry.TabIndex = 2;
            this.btnKeyEntry.Text = "登记";
            this.btnKeyEntry.UseVisualStyleBackColor = true;
            this.btnKeyEntry.Click += new System.EventHandler(this.btnKeyEntry_Click);
            this.btnKeyEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hotkey_KeyPress);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(3, 344);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(103, 28);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(112, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(579, 381);
            this.panel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listStyleItem);
            this.groupBox2.Controls.Add(this.listAllStyleItem);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnItemDelete);
            this.groupBox2.Controls.Add(this.btnInsert);
            this.groupBox2.Controls.Add(this.btnItemDown);
            this.groupBox2.Controls.Add(this.btnItemUp);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(557, 362);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "自动操作的装配";
            // 
            // listStyleItem
            // 
            this.listStyleItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listStyleItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listStyleItem.Font = new System.Drawing.Font("黑体", 10F);
            this.listStyleItem.FormattingEnabled = true;
            this.listStyleItem.HelpFont = new System.Drawing.Font("黑体", 8F);
            this.listStyleItem.HelpForeColor = System.Drawing.Color.SteelBlue;
            this.listStyleItem.IntegralHeight = false;
            this.listStyleItem.ItemDragMove = true;
            this.listStyleItem.ItemHeight = 39;
            this.listStyleItem.ItemKeyDelete = true;
            this.listStyleItem.ItemLine = true;
            this.listStyleItem.ItemLineColor = System.Drawing.Color.LightSteelBlue;
            this.listStyleItem.Items.AddRange(new object[] {
            "第1项",
            "第2项",
            "第3项"});
            this.listStyleItem.LeftSpace = 34;
            this.listStyleItem.Location = new System.Drawing.Point(296, 40);
            this.listStyleItem.Name = "listStyleItem";
            this.listStyleItem.Size = new System.Drawing.Size(250, 307);
            this.listStyleItem.TabIndex = 4;
            this.listStyleItem.TerminateEnd = true;
            this.toolTip2.SetToolTip(this.listStyleItem, "自上而下依次应用自动操作项目。");
            this.listStyleItem.Click += new System.EventHandler(this.listAllStyleItem_Click);
            this.listStyleItem.DoubleClick += new System.EventHandler(this.listStyleItem_DoubleClick);
            // 
            // listAllStyleItem
            // 
            this.listAllStyleItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listAllStyleItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listAllStyleItem.Font = new System.Drawing.Font("黑体", 10F);
            this.listAllStyleItem.FormattingEnabled = true;
            this.listAllStyleItem.HelpFont = new System.Drawing.Font("黑体", 8F);
            this.listAllStyleItem.HelpForeColor = System.Drawing.Color.SteelBlue;
            this.listAllStyleItem.IntegralHeight = false;
            this.listAllStyleItem.ItemDragMove = false;
            this.listAllStyleItem.ItemHeight = 39;
            this.listAllStyleItem.ItemKeyDelete = false;
            this.listAllStyleItem.ItemLine = true;
            this.listAllStyleItem.ItemLineColor = System.Drawing.Color.LightSteelBlue;
            this.listAllStyleItem.Items.AddRange(new object[] {
            "第1项",
            "第2项",
            "第3项"});
            this.listAllStyleItem.LeftSpace = 34;
            this.listAllStyleItem.Location = new System.Drawing.Point(9, 40);
            this.listAllStyleItem.Name = "listAllStyleItem";
            this.listAllStyleItem.ScrollAlwaysVisible = true;
            this.listAllStyleItem.Size = new System.Drawing.Size(250, 307);
            this.listAllStyleItem.TabIndex = 1;
            this.listAllStyleItem.TerminateEnd = false;
            this.listAllStyleItem.Click += new System.EventHandler(this.listAllStyleItem_Click);
            this.listAllStyleItem.DoubleClick += new System.EventHandler(this.listAllStyleItem_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "登记方式：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "自动操作列表：";
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemDelete.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnItemDelete.Image = global::SETUNA.Properties.Resources.Close;
            this.btnItemDelete.Location = new System.Drawing.Point(517, 14);
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Size = new System.Drawing.Size(29, 23);
            this.btnItemDelete.TabIndex = 7;
            this.toolTip2.SetToolTip(this.btnItemDelete, "删除选定的项目。");
            this.btnItemDelete.UseVisualStyleBackColor = true;
            this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsert.Location = new System.Drawing.Point(265, 51);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(25, 286);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = ">>";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnItemDown
            // 
            this.btnItemDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemDown.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnItemDown.Image = global::SETUNA.Properties.Resources.ArrowDown;
            this.btnItemDown.Location = new System.Drawing.Point(456, 14);
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.Size = new System.Drawing.Size(29, 23);
            this.btnItemDown.TabIndex = 5;
            this.toolTip2.SetToolTip(this.btnItemDown, "更改选定项目的顺序。");
            this.btnItemDown.UseVisualStyleBackColor = true;
            this.btnItemDown.Click += new System.EventHandler(this.btnItemDown_Click);
            // 
            // btnItemUp
            // 
            this.btnItemUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemUp.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnItemUp.Image = global::SETUNA.Properties.Resources.ArrowUp;
            this.btnItemUp.Location = new System.Drawing.Point(484, 14);
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.Size = new System.Drawing.Size(29, 23);
            this.btnItemUp.TabIndex = 6;
            this.toolTip2.SetToolTip(this.btnItemUp, "更改选定项目的顺序。");
            this.btnItemUp.UseVisualStyleBackColor = true;
            this.btnItemUp.Click += new System.EventHandler(this.btnItemUp_Click);
            // 
            // hotkey
            // 
            this.hotkey.Hotkey = global::System.Windows.Forms.Keys.None;
            this.hotkey.Location = new global::System.Drawing.Point(12, 40);
            this.hotkey.Name = "hotkey";
            this.hotkey.Size = new global::System.Drawing.Size(169, 19);
            this.hotkey.TabIndex = 1;
            this.toolTip2.SetToolTip(this.hotkey, "创建应用自动操作的快捷键。");
            this.hotkey.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.hotkey_KeyUp);
            // 
            // StyleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(783, 381);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(692, 415);
            this.Name = "StyleEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StyleEditForm";
            this.Shown += new System.EventHandler(this.StyleEditForm_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		// Token: 0x04000281 RID: 641
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000282 RID: 642
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000283 RID: 643
		private global::System.Windows.Forms.TextBox txtStyleName;

		// Token: 0x04000284 RID: 644
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x04000285 RID: 645
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000286 RID: 646
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000287 RID: 647
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000288 RID: 648
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000289 RID: 649
		private global::System.Windows.Forms.Button btnKeyDelete;

		// Token: 0x0400028B RID: 651
		private global::System.Windows.Forms.ListBox listKeys;

		// Token: 0x0400028C RID: 652
		private global::System.Windows.Forms.Button btnKeyEntry;

		// Token: 0x0400028D RID: 653
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x0400028E RID: 654
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400028F RID: 655
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000290 RID: 656
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000291 RID: 657
		private global::SETUNA.Main.StyleItemListBox listStyleItem;

		// Token: 0x04000292 RID: 658
		private global::SETUNA.Main.StyleItemListBox listAllStyleItem;

		// Token: 0x04000293 RID: 659
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000294 RID: 660
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000295 RID: 661
		private global::System.Windows.Forms.Button btnItemDelete;

		// Token: 0x04000296 RID: 662
		private global::System.Windows.Forms.Button btnInsert;

		// Token: 0x04000297 RID: 663
		private global::System.Windows.Forms.Button btnItemDown;

		// Token: 0x04000298 RID: 664
		private global::System.Windows.Forms.Button btnItemUp;

		// Token: 0x04000299 RID: 665
		private global::System.Windows.Forms.ToolTip toolTip2;
        private HotkeyControl hotkey;
    }
}
