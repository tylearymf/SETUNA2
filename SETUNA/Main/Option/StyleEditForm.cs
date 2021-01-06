using System;
using System.Drawing;
using System.Windows.Forms;
using SETUNA.Main.KeyItems;
using SETUNA.Main.Style;
using SETUNA.Main.StyleItems;

namespace SETUNA.Main.Option
{
    // Token: 0x02000081 RID: 129
    public partial class StyleEditForm : BaseForm
    {
        // Token: 0x0600043F RID: 1087 RVA: 0x0001C0F4 File Offset: 0x0001A2F4
        public StyleEditForm(CStyle trgStyle, KeyItemBook keybook)
        {
            InitializeComponent();
            base.ResizeRedraw = true;
            _trgStyle = trgStyle;
            _keybook = keybook;
            cmKey = Keys.None;
            if (_trgStyle == null)
            {
                _trgStyle = new CStyle();
            }
            txtStyleName.Text = _trgStyle.GetName();
            RefreshStyleItemList();
            RefreshAllStyleItemList();
            RefreshKeyItemList();
            txtStyleName_TextChanged(txtStyleName, new EventArgs());
        }

        // Token: 0x170000A8 RID: 168
        // (get) Token: 0x06000440 RID: 1088 RVA: 0x0001C175 File Offset: 0x0001A375
        public CStyle Style => _trgStyle;

        // Token: 0x06000441 RID: 1089 RVA: 0x0001C180 File Offset: 0x0001A380
        private void RefreshStyleItemList()
        {
            var selectedIndex = listStyleItem.SelectedIndex;
            listStyleItem.Items.Clear();
            for (var i = 0; i < _trgStyle.Items.Length; i++)
            {
                listStyleItem.Items.Add(_trgStyle.Items[i]);
            }
            listStyleItem.SelectedIndex = selectedIndex;
        }

        // Token: 0x06000442 RID: 1090 RVA: 0x0001C1EC File Offset: 0x0001A3EC
        private void RefreshAllStyleItemList()
        {
            var allStyleItems = StyleItemDictionary.GetAllStyleItems();
            listAllStyleItem.BeginUpdate();
            listAllStyleItem.Items.Clear();
            for (var i = 0; i < allStyleItems.Length; i++)
            {
                listAllStyleItem.Items.Add(allStyleItems[i]);
            }
            listAllStyleItem.EndUpdate();
        }

        // Token: 0x06000443 RID: 1091 RVA: 0x0001C248 File Offset: 0x0001A448
        private void RefreshKeyItemList()
        {
            listKeys.Items.Clear();
            for (var i = 0; i < _trgStyle.KeyItems.Length; i++)
            {
                listKeys.Items.Add(_trgStyle.KeyItems[i]);
            }
        }

        // Token: 0x06000444 RID: 1092 RVA: 0x0001C29C File Offset: 0x0001A49C
        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            if (listStyleItem.SelectedItem != null)
            {
                var selectedIndex = listStyleItem.SelectedIndex;
                listStyleItem.Items.Remove(listStyleItem.SelectedItem);
                if (selectedIndex <= listStyleItem.Items.Count - 1)
                {
                    listStyleItem.SelectedIndex = selectedIndex;
                    return;
                }
                listStyleItem.SelectedIndex = listStyleItem.Items.Count - 1;
            }
        }

        // Token: 0x06000445 RID: 1093 RVA: 0x0001C31C File Offset: 0x0001A51C
        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertStyleItem();
        }

        // Token: 0x06000446 RID: 1094 RVA: 0x0001C324 File Offset: 0x0001A524
        private void listAllStyleItem_DoubleClick(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            if (listBox.SelectedItem != null)
            {
                InsertStyleItem();
            }
        }

        // Token: 0x06000447 RID: 1095 RVA: 0x0001C348 File Offset: 0x0001A548
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtStyleName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入自动操作名。", Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtStyleName.Focus();
                return;
            }
            WriteValue();
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        // Token: 0x06000448 RID: 1096 RVA: 0x0001C3A0 File Offset: 0x0001A5A0
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        // Token: 0x06000449 RID: 1097 RVA: 0x0001C3B0 File Offset: 0x0001A5B0
        private void WriteValue()
        {
            _trgStyle.StyleName = txtStyleName.Text.Trim();
            _trgStyle.ClearStyle();
            for (var i = 0; i < listStyleItem.Items.Count; i++)
            {
                _trgStyle.AddStyle((CStyleItem)listStyleItem.Items[i]);
            }
            _trgStyle.ClearKey();
            for (var j = 0; j < listKeys.Items.Count; j++)
            {
                var key = (Keys)((KeyItem)listKeys.Items[j])._key;
                var keyItem = _keybook.FindKeyItem(key);
                if (keyItem != null)
                {
                    keyItem.Deparent();
                }
                _trgStyle.AddKeyItem(key);
            }
        }

        // Token: 0x0600044A RID: 1098 RVA: 0x0001C484 File Offset: 0x0001A684
        private void InsertStyleItem()
        {
            if (listAllStyleItem.SelectedItem != null)
            {
                var cstyleItem = (CStyleItem)((CStyleItem)listAllStyleItem.SelectedItem).Clone();
                if (cstyleItem.IsSetting)
                {
                    cstyleItem.StyleItemSetting();
                }
                if (listStyleItem.SelectedIndex == -1)
                {
                    listStyleItem.Items.Add(cstyleItem);
                    listStyleItem.SelectedIndex = listStyleItem.Items.Count - 1;
                    return;
                }
                listStyleItem.Items.Insert(listStyleItem.SelectedIndex + 1, cstyleItem);
                listStyleItem.SelectedIndex++;
            }
        }

        // Token: 0x0600044B RID: 1099 RVA: 0x0001C539 File Offset: 0x0001A739
        private void listStyleItem_DoubleClick(object sender, EventArgs e)
        {
            if (listStyleItem.SelectedItem != null)
            {
                ((CStyleItem)listStyleItem.SelectedItem).StyleItemSetting();
            }
        }

        // Token: 0x0600044C RID: 1100 RVA: 0x0001C560 File Offset: 0x0001A760
        private void btnItemUp_Click(object sender, EventArgs e)
        {
            if (listStyleItem.SelectedItem != null && listStyleItem.SelectedIndex > 0)
            {
                var selectedIndex = listStyleItem.SelectedIndex;
                var value = (CStyleItem)listStyleItem.SelectedItem;
                listStyleItem.Items[selectedIndex] = listStyleItem.Items[selectedIndex - 1];
                listStyleItem.Items[selectedIndex - 1] = value;
                listStyleItem.SelectedIndex = selectedIndex - 1;
            }
        }

        // Token: 0x0600044D RID: 1101 RVA: 0x0001C5EC File Offset: 0x0001A7EC
        private void btnItemDown_Click(object sender, EventArgs e)
        {
            if (listStyleItem.SelectedItem != null && listStyleItem.SelectedIndex + 1 < listStyleItem.Items.Count)
            {
                var selectedIndex = listStyleItem.SelectedIndex;
                var value = (CStyleItem)listStyleItem.SelectedItem;
                listStyleItem.Items[selectedIndex] = listStyleItem.Items[selectedIndex + 1];
                listStyleItem.Items[selectedIndex + 1] = value;
                listStyleItem.SelectedIndex = selectedIndex + 1;
            }
        }

        // Token: 0x0600044E RID: 1102 RVA: 0x0001C68C File Offset: 0x0001A88C
        private void btnKeyEntry_Click(object sender, EventArgs e)
        {
            if (hotkey.Hotkey != Keys.None)
            {
                var item = new KeyItem(hotkey.Hotkey);
                listKeys.Items.Add(item);
                toolTip1.Hide(label5);
            }
        }

        // Token: 0x0600044F RID: 1103 RVA: 0x0001C6DA File Offset: 0x0001A8DA
        private void btnKeyDelete_Click(object sender, EventArgs e)
        {
            if (listKeys.SelectedIndex >= 0)
            {
                listKeys.Items.RemoveAt(listKeys.SelectedIndex);
            }
        }

        // Token: 0x06000450 RID: 1104 RVA: 0x0001C705 File Offset: 0x0001A905
        private void StyleEditForm_Shown(object sender, EventArgs e)
        {
            txtStyleName.Focus();
        }

        // Token: 0x06000451 RID: 1105 RVA: 0x0001C713 File Offset: 0x0001A913
        private void hotkey_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        // Token: 0x06000452 RID: 1106 RVA: 0x0001C715 File Offset: 0x0001A915
        private void listAllStyleItem_Click(object sender, EventArgs e)
        {
            var setunaListBox = (SetunaListBox)sender;
        }

        // Token: 0x06000453 RID: 1107 RVA: 0x0001C71E File Offset: 0x0001A91E
        private void hotkey_Validated(object sender, EventArgs e)
        {
        }

        // Token: 0x06000454 RID: 1108 RVA: 0x0001C720 File Offset: 0x0001A920
        private void hotkey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        // Token: 0x06000455 RID: 1109 RVA: 0x0001C722 File Offset: 0x0001A922
        private void hotkey_KeyDown(object sender, KeyEventArgs e)
        {
        }

        // Token: 0x06000456 RID: 1110 RVA: 0x0001C724 File Offset: 0x0001A924
        private void hotkey_KeyUp(object sender, KeyEventArgs e)
        {
            toolTip1.Active = false;
            if (cmKey != e.KeyData)
            {
                cmKey = e.KeyData;
                var keys = hotkey.Hotkey;
                if (keys != Keys.None)
                {
                    var keyItem = _keybook.FindKeyItem(keys);
                    if (keyItem != null)
                    {
                        var text = "「登记」，然后按目前的分配方式。";
                        hotkey.PointToScreen(new Point(0, 0));
                        toolTip1.Active = true;
                        toolTip1.ToolTipTitle = "「" + keyItem.ParentStyle.StyleName + "」被分配。";
                        toolTip1.Show(text, label5);
                    }
                }
            }
        }

        // Token: 0x06000457 RID: 1111 RVA: 0x0001C7D5 File Offset: 0x0001A9D5
        private void txtStyleName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = (txtStyleName.TextLength > 0);
        }

        // Token: 0x0400029A RID: 666
        protected CStyle _trgStyle;

        // Token: 0x0400029B RID: 667
        protected KeyItemBook _keybook;

        // Token: 0x0400029C RID: 668
        private Keys cmKey;
    }
}
