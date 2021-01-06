using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000024 RID: 36
    public partial class ScrapPaintToolBar : BaseForm
    {
        // Token: 0x14000012 RID: 18
        // (add) Token: 0x06000183 RID: 387 RVA: 0x0000922E File Offset: 0x0000742E
        // (remove) Token: 0x06000184 RID: 388 RVA: 0x00009247 File Offset: 0x00007447
        public event ScrapPaintToolBar.SelectToolDelegate SelectTool;

        // Token: 0x17000049 RID: 73
        // (get) Token: 0x06000186 RID: 390 RVA: 0x0000926E File Offset: 0x0000746E
        // (set) Token: 0x06000185 RID: 389 RVA: 0x00009260 File Offset: 0x00007460
        public Color ColorA
        {
            get => picColorA.BackColor;
            set => picColorA.BackColor = value;
        }

        // Token: 0x1700004A RID: 74
        // (get) Token: 0x06000188 RID: 392 RVA: 0x00009289 File Offset: 0x00007489
        // (set) Token: 0x06000187 RID: 391 RVA: 0x0000927B File Offset: 0x0000747B
        public Color ColorB
        {
            get => picColorB.BackColor;
            set => picColorB.BackColor = value;
        }

        // Token: 0x06000189 RID: 393 RVA: 0x00009298 File Offset: 0x00007498
        public ScrapPaintToolBar(ScrapPaintWindow parent)
        {
            _parent = parent;
            InitializeComponent();
            activeTool = null;
            tools = new List<CheckBox>
            {
                chkPen,
                chkErase,
                chkText
            };
        }

        // Token: 0x0600018A RID: 394 RVA: 0x00009300 File Offset: 0x00007500
        public void SwitchTool(ScrapPaintToolBar.ToolKind kind)
        {
            switch (kind)
            {
                case ScrapPaintToolBar.ToolKind.笔工具:
                    chkPen_Click(chkPen, null);
                    return;
                case ScrapPaintToolBar.ToolKind.消しゴム工具:
                    chkPen_Click(chkErase, null);
                    return;
                case ScrapPaintToolBar.ToolKind.文字工具:
                    chkPen_Click(chkText, null);
                    return;
                default:
                    return;
            }
        }

        // Token: 0x0600018B RID: 395 RVA: 0x0000934C File Offset: 0x0000754C
        private void SelecionTool()
        {
            if (chkPen.Checked)
            {
                OnSelectTool(new PenTool(ColorA, _parent));
                return;
            }
            if (chkErase.Checked)
            {
                OnSelectTool(new PenTool(PenTool.EraseColor, _parent));
                return;
            }
            if (chkText.Checked)
            {
                OnSelectTool(new TextTool(_parent));
                return;
            }
            OnSelectTool(null);
        }

        // Token: 0x0600018C RID: 396 RVA: 0x000093C8 File Offset: 0x000075C8
        private void OnSelectTool(PaintTool tool)
        {
            activeTool = tool;
            if (activeTool != null)
            {
                activeTool.ShowToolBar(_parent);
                _parent.Activate();
            }
            if (SelectTool != null)
            {
                SelectTool(tool);
            }
        }

        // Token: 0x0600018D RID: 397 RVA: 0x00009414 File Offset: 0x00007614
        private void chkPen_Click(object sender, EventArgs e)
        {
            CheckBox obj = null;
            foreach (var checkBox in tools)
            {
                if (checkBox.Checked)
                {
                    obj = checkBox;
                    break;
                }
            }
            CheckBox checkBox2 = null;
            foreach (var checkBox3 in tools)
            {
                if (checkBox3.Equals(sender))
                {
                    checkBox3.Checked = true;
                    checkBox2 = checkBox3;
                }
                else
                {
                    checkBox3.Checked = false;
                }
            }
            if (checkBox2 != null && !checkBox2.Equals(obj))
            {
                SelecionTool();
            }
        }

        // Token: 0x0600018E RID: 398 RVA: 0x000094DC File Offset: 0x000076DC
        private void picColorA_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = picColorA.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                picColorA.BackColor = colorDialog1.Color;
            }
        }

        // Token: 0x0600018F RID: 399 RVA: 0x00009518 File Offset: 0x00007718
        private void picColorB_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = picColorB.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                picColorB.BackColor = colorDialog1.Color;
            }
        }

        // Token: 0x06000190 RID: 400 RVA: 0x00009554 File Offset: 0x00007754
        public void ChangeColor()
        {
            var backColor = picColorA.BackColor;
            picColorA.BackColor = picColorB.BackColor;
            picColorB.BackColor = backColor;
        }

        // Token: 0x06000191 RID: 401 RVA: 0x0000958F File Offset: 0x0000778F
        private void picColorA_BackColorChanged(object sender, EventArgs e)
        {
            if (activeTool != null)
            {
                activeTool.ChangeColor(ColorA);
            }
        }

        // Token: 0x06000192 RID: 402 RVA: 0x000095AA File Offset: 0x000077AA
        private void ScrapPaintToolBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        // Token: 0x040000B7 RID: 183
        private ScrapPaintWindow _parent;

        // Token: 0x040000B8 RID: 184
        private List<CheckBox> tools;

        // Token: 0x040000B9 RID: 185
        private PaintTool activeTool;

        // Token: 0x02000025 RID: 37
        // (Invoke) Token: 0x06000194 RID: 404
        public delegate void SelectToolDelegate(PaintTool tool);

        // Token: 0x02000026 RID: 38
        public enum ToolKind
        {
            // Token: 0x040000BB RID: 187
            笔工具,
            // Token: 0x040000BC RID: 188
            消しゴム工具,
            // Token: 0x040000BD RID: 189
            文字工具
        }
    }
}
