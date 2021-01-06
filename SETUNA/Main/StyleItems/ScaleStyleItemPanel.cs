using System;
using System.Drawing.Drawing2D;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200008E RID: 142
    internal partial class ScaleStyleItemPanel : ToolBoxForm
    {
        // Token: 0x060004A8 RID: 1192 RVA: 0x0001E574 File Offset: 0x0001C774
        public ScaleStyleItemPanel(CScaleStyleItem item) : base(item)
        {
        }

        // Token: 0x060004AA RID: 1194 RVA: 0x0001EE58 File Offset: 0x0001D058
        protected override void SetStyleToForm(object style)
        {
            var cscaleStyleItem = (CScaleStyleItem)style;
            InitializeComponent();
            cmbInterpolation.Items.Clear();
            cmbInterpolation.Items.Add(new ScaleStyleItemPanel.ComboItem<InterpolationMode>("不要更改", InterpolationMode.Invalid));
            cmbInterpolation.Items.Add(new ScaleStyleItemPanel.ComboItem<InterpolationMode>("最近邻法", InterpolationMode.NearestNeighbor));
            cmbInterpolation.Items.Add(new ScaleStyleItemPanel.ComboItem<InterpolationMode>("标准", InterpolationMode.High));
            cmbInterpolation.Items.Add(new ScaleStyleItemPanel.ComboItem<InterpolationMode>("双线性", InterpolationMode.HighQualityBilinear));
            cmbInterpolation.Items.Add(new ScaleStyleItemPanel.ComboItem<InterpolationMode>("两次立方", InterpolationMode.HighQualityBicubic));
            Text = cscaleStyleItem.GetDisplayName();
            numFixedScale.Minimum = 10m;
            numFixedScale.Maximum = 200m;
            barFixed.Minimum = 10;
            barFixed.Maximum = 200;
            numRelativeScale.Minimum = -190m;
            numRelativeScale.Maximum = 190m;
            barRelative.Minimum = -190;
            barRelative.Maximum = 190;
            numFixedScale.Value = 100m;
            barFixed.Value = 100;
            numRelativeScale.Value = 0m;
            barRelative.Value = 0;
            rdoFixed.Checked = (cscaleStyleItem.SetType == CScaleStyleItem.ScaleSetType.Fixed);
            rdoIncrement.Checked = (cscaleStyleItem.SetType == CScaleStyleItem.ScaleSetType.Increment);
            rdoFixed_CheckedChanged(this, null);
            if (rdoFixed.Checked)
            {
                numFixedScale.Value = cscaleStyleItem.Value;
            }
            else
            {
                numRelativeScale.Value = cscaleStyleItem.Value;
            }
            cmbInterpolation.SelectedIndex = 0;
            foreach (var obj in cmbInterpolation.Items)
            {
                var comboItem = (ScaleStyleItemPanel.ComboItem<InterpolationMode>)obj;
                if (comboItem.Item == cscaleStyleItem.InterpolationMode)
                {
                    cmbInterpolation.SelectedItem = comboItem;
                }
            }
        }

        // Token: 0x060004AB RID: 1195 RVA: 0x0001F0C8 File Offset: 0x0001D2C8
        protected override object GetStyleFromForm()
        {
            var cscaleStyleItem = new CScaleStyleItem();
            if (rdoFixed.Checked)
            {
                cscaleStyleItem.Value = (int)numFixedScale.Value;
            }
            else
            {
                cscaleStyleItem.Value = (int)numRelativeScale.Value;
            }
            cscaleStyleItem.SetType = (rdoFixed.Checked ? CScaleStyleItem.ScaleSetType.Fixed : CScaleStyleItem.ScaleSetType.Increment);
            cscaleStyleItem.InterpolationMode = ((ScaleStyleItemPanel.ComboItem<InterpolationMode>)cmbInterpolation.SelectedItem).Item;
            return cscaleStyleItem;
        }

        // Token: 0x060004AC RID: 1196 RVA: 0x0001F14C File Offset: 0x0001D34C
        private void rdoFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFixed.Checked)
            {
                barFixed.Enabled = true;
                numFixedScale.Enabled = true;
                barRelative.Enabled = false;
                numRelativeScale.Enabled = false;
                return;
            }
            barFixed.Enabled = false;
            numFixedScale.Enabled = false;
            barRelative.Enabled = true;
            numRelativeScale.Enabled = true;
        }

        // Token: 0x060004AD RID: 1197 RVA: 0x0001F1C8 File Offset: 0x0001D3C8
        private void numFixedScale_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                barFixed.Value = (int)numFixedScale.Value;
                barRelative.Value = (int)numRelativeScale.Value;
            }
            catch
            {
            }
        }

        // Token: 0x060004AE RID: 1198 RVA: 0x0001F220 File Offset: 0x0001D420
        private void barFixed_Scroll(object sender, EventArgs e)
        {
            if (barFixed.Value != numFixedScale.Value)
            {
                numFixedScale.Value = barFixed.Value;
            }
            if (barRelative.Value != numRelativeScale.Value)
            {
                numRelativeScale.Value = barRelative.Value;
            }
        }

        // Token: 0x02000094 RID: 148
        private class ComboItem<T>
        {
            // Token: 0x060004E5 RID: 1253 RVA: 0x0002337B File Offset: 0x0002157B
            public ComboItem(string name, T item)
            {
                _item = item;
                _name = name;
            }

            // Token: 0x170000B4 RID: 180
            // (get) Token: 0x060004E7 RID: 1255 RVA: 0x0002339A File Offset: 0x0002159A
            // (set) Token: 0x060004E6 RID: 1254 RVA: 0x00023391 File Offset: 0x00021591
            public T Item
            {
                get => _item;
                set => _item = value;
            }

            // Token: 0x060004E8 RID: 1256 RVA: 0x000233A2 File Offset: 0x000215A2
            public override string ToString()
            {
                return _name;
            }

            // Token: 0x0400032B RID: 811
            protected T _item;

            // Token: 0x0400032C RID: 812
            protected string _name;
        }
    }
}
