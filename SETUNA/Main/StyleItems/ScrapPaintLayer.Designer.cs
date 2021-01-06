namespace SETUNA.Main.StyleItems
{
	// Token: 0x02000016 RID: 22
	partial class ScrapPaintLayer
	{
		// Token: 0x06000104 RID: 260 RVA: 0x00007260 File Offset: 0x00005460
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			this._parent = null;
			this._select = null;
			if (this.LayerCommands != null)
			{
				foreach (global::SETUNA.Main.StyleItems.ToolCommand toolCommand in this.LayerCommands)
				{
					toolCommand.Dispose();
				}
				this.LayerCommands.Clear();
				this.LayerCommands = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000072F8 File Offset: 0x000054F8
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnLayerAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnLayerAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 19);
            this.panel1.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(81, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(34, 19);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnLayerAdd
            // 
            this.btnLayerAdd.Location = new System.Drawing.Point(114, 0);
            this.btnLayerAdd.Name = "btnLayerAdd";
            this.btnLayerAdd.Size = new System.Drawing.Size(34, 19);
            this.btnLayerAdd.TabIndex = 0;
            this.btnLayerAdd.Text = "Add";
            this.btnLayerAdd.UseVisualStyleBackColor = true;
            this.btnLayerAdd.Click += new System.EventHandler(this.btnLayerAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 26);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(148, 221);
            this.panel3.TabIndex = 2;
            // 
            // ScrapPaintLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(148, 266);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "ScrapPaintLayer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "层";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScrapPaintLayer_FormClosing);
            this.Shown += new System.EventHandler(this.ScrapPaintLayer_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		// Token: 0x0400007A RID: 122
		private global::SETUNA.Main.StyleItems.ScrapPaintWindow _parent;

		// Token: 0x0400007C RID: 124
		private global::SETUNA.Main.StyleItems.ScrapPaintLayerItem _select;

		// Token: 0x0400007D RID: 125
		private global::System.Collections.Generic.List<global::SETUNA.Main.StyleItems.LayerCommand> LayerCommands;

		// Token: 0x04000081 RID: 129
#pragma warning disable CS0649 // 从未对字段“ScrapPaintLayer.components”赋值，字段将一直保持其默认值 null
		private global::System.ComponentModel.IContainer components;
#pragma warning restore CS0649 // 从未对字段“ScrapPaintLayer.components”赋值，字段将一直保持其默认值 null

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.Button btnLayerAdd;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.Button btnDel;
	}
}
