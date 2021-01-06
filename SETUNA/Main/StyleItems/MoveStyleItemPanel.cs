using System;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200008D RID: 141
    internal partial class MoveStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060004A0 RID: 1184 RVA: 0x0001DA94 File Offset: 0x0001BC94
        public MoveStyleItemPanel(CStyleItem item) : base(item)
        {
            numUp.Maximum = CMoveStyleItem.MAX_MOVE;
            numDown.Maximum = CMoveStyleItem.MAX_MOVE;
            numLeft.Maximum = CMoveStyleItem.MAX_MOVE;
            numRight.Maximum = CMoveStyleItem.MAX_MOVE;
        }

        // Token: 0x060004A2 RID: 1186 RVA: 0x0001E1A4 File Offset: 0x0001C3A4
        protected override void SetStyleToForm(object style)
        {
            var cmoveStyleItem = (CMoveStyleItem)style;
            InitializeComponent();
            Text = cmoveStyleItem.GetDisplayName();
            if (cmoveStyleItem.Top <= 0)
            {
                chkDown.Checked = true;
                chkUp.Checked = true;
                numUp.Value = Math.Abs(cmoveStyleItem.Top);
            }
            else
            {
                chkUp.Checked = true;
                chkDown.Checked = true;
                numDown.Value = Math.Abs(cmoveStyleItem.Top);
            }
            if (cmoveStyleItem.Left <= 0)
            {
                chkRight.Checked = true;
                chkLeft.Checked = true;
                numLeft.Value = Math.Abs(cmoveStyleItem.Left);
                return;
            }
            chkLeft.Checked = true;
            chkRight.Checked = true;
            numRight.Value = Math.Abs(cmoveStyleItem.Left);
        }

        // Token: 0x060004A3 RID: 1187 RVA: 0x0001E2AC File Offset: 0x0001C4AC
        protected override object GetStyleFromForm()
        {
            var cmoveStyleItem = new CMoveStyleItem();
            int top;
            if (chkUp.Checked)
            {
                top = -(int)numUp.Value;
            }
            else
            {
                top = (int)numDown.Value;
            }
            int left;
            if (chkLeft.Checked)
            {
                left = -(int)numLeft.Value;
            }
            else
            {
                left = (int)numRight.Value;
            }
            cmoveStyleItem.Top = top;
            cmoveStyleItem.Left = left;
            return cmoveStyleItem;
        }

        // Token: 0x060004A4 RID: 1188 RVA: 0x0001E334 File Offset: 0x0001C534
        private void chkUp_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDown.Checked && !chkUp.Checked)
            {
                chkUp.Checked = true;
            }
            if (chkDown.Checked && chkUp.Checked)
            {
                chkDown.Checked = false;
            }
            if (chkUp.Checked)
            {
                numUp.Enabled = true;
                return;
            }
            numUp.Enabled = false;
            numUp.Value = 0m;
        }

        // Token: 0x060004A5 RID: 1189 RVA: 0x0001E3C4 File Offset: 0x0001C5C4
        private void chkDown_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDown.Checked && !chkUp.Checked)
            {
                chkDown.Checked = true;
            }
            if (chkDown.Checked && chkUp.Checked)
            {
                chkUp.Checked = false;
            }
            if (chkDown.Checked)
            {
                numDown.Enabled = true;
                return;
            }
            numDown.Enabled = false;
            numDown.Value = 0m;
        }

        // Token: 0x060004A6 RID: 1190 RVA: 0x0001E454 File Offset: 0x0001C654
        private void chkLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkRight.Checked && !chkLeft.Checked)
            {
                chkLeft.Checked = true;
            }
            if (chkRight.Checked && chkLeft.Checked)
            {
                chkRight.Checked = false;
            }
            if (chkLeft.Checked)
            {
                numLeft.Enabled = true;
                return;
            }
            numLeft.Enabled = false;
            numLeft.Value = 0m;
        }

        // Token: 0x060004A7 RID: 1191 RVA: 0x0001E4E4 File Offset: 0x0001C6E4
        private void chkRight_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkRight.Checked && !chkLeft.Checked)
            {
                chkRight.Checked = true;
            }
            if (chkRight.Checked && chkLeft.Checked)
            {
                chkLeft.Checked = false;
            }
            if (chkRight.Checked)
            {
                numRight.Enabled = true;
                return;
            }
            numRight.Enabled = false;
            numRight.Value = 0m;
        }
    }
}
