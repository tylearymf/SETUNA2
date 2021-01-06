using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SETUNA.Main.KeyItems;
using SETUNA.Main.Style;

namespace SETUNA.Main.Option
{
    // Token: 0x02000050 RID: 80
    public partial class OptionForm : BaseForm
    {
        // Token: 0x060002D3 RID: 723 RVA: 0x000136BA File Offset: 0x000118BA
        public OptionForm(SetunaOption opt)
        {
            InitializeComponent();
            _pageStyle = pageStyle;
            _pageScrapMenu = pageScrapMenu;
            _so = opt;
            LoadSetunaOption();

            linkLabel1.Text = "官方版本（地址已挂）";
            linkLabel1.Links.Add(0, linkLabel1.Text.Length, URLUtils.OriginURL);
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
            toolTip1.SetToolTip(linkLabel1, URLUtils.OriginURL);

            linkLabel2.Text = $"优化版本 by tylearymf. Version: {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
            linkLabel2.Links.Add(0, linkLabel2.Text.Length, URLUtils.NewURL);
            linkLabel2.LinkClicked += LinkLabel2_LinkClicked;
            toolTip1.SetToolTip(linkLabel2, URLUtils.NewURL);
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel2.Links[0].LinkData.ToString());
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Links[0].LinkData.ToString());
        }

        // Token: 0x060002D4 RID: 724 RVA: 0x000136F0 File Offset: 0x000118F0
        private void LoadSetunaOption()
        {
            Prepare_SetunaAll();
            chkCC7.Checked = _so.Setuna.ClickCapture7;
            chkCC8.Checked = _so.Setuna.ClickCapture8;
            chkCC9.Checked = _so.Setuna.ClickCapture9;
            chkCC4.Checked = _so.Setuna.ClickCapture4;
            chkCC6.Checked = _so.Setuna.ClickCapture6;
            chkCC1.Checked = _so.Setuna.ClickCapture1;
            chkCC2.Checked = _so.Setuna.ClickCapture2;
            chkCC3.Checked = _so.Setuna.ClickCapture3;
            listStyles.BeginUpdate();
            listStyles.Items.Clear();
            for (var i = 0; i < _so.Styles.Count; i++)
            {
                listStyles.Items.Add(_so.Styles[i]);
            }
            listStyles.EndUpdate();
            _createStyleId = _so.Scrap.CreateStyleID;
            _wclickStyleId = _so.Scrap.WClickStyleID;
            chkScrapImageDrag.Checked = _so.Scrap.ImageDrag;
            chkInactiveAlphaChange.Checked = _so.Scrap.InactiveAlphaChange;
            numInactiveAlpha.Value = _so.Scrap.InactiveAlphaValue;
            chkMouseOverAlphaChange.Checked = _so.Scrap.MouseOverAlphaChange;
            numMouseOverAlpha.Value = _so.Scrap.MouseOverAlphaValue;
            Prepare_ScrapMenu();
            RefreshStyleList_Scrap();

            checkBox_topMost.Checked = _so.Setuna.TopMostEnabled;
            checkBox_autoStartup.Checked = Startup.AutoStartup.IsSetup();
        }

        // Token: 0x060002D5 RID: 725 RVA: 0x00013908 File Offset: 0x00011B08
        private void WriteSetunaOption()
        {
            _so.ScrapHotKeys[0] = hotkeyControl1.Hotkey;
            _so.ScrapHotKeys[1] = hotkeyControl2.Hotkey;
            _so.ScrapHotKeyEnable = checkBox1.Checked;
            if (rdoExeTypeApp.Checked)
            {
                _so.Setuna.AppType = SetunaOption.SetunaOptionData.ApplicationType.ApplicationMode;
            }
            else
            {
                _so.Setuna.AppType = SetunaOption.SetunaOptionData.ApplicationType.ResidentMode;
            }
            _so.Setuna.ShowMainWindow = chkShowMainWindow.Checked;
            if (rdoDupNone.Checked)
            {
                _so.Setuna.DupType = SetunaOption.SetunaOptionData.OpeningType.Normal;
            }
            else
            {
                _so.Setuna.DupType = SetunaOption.SetunaOptionData.OpeningType.Capture;
            }
            _so.Setuna.ShowSplashWindow = chkSplash.Checked;
            _so.Setuna.SelectLineSolid = rdoSelLineTypeSolid.Checked;
            _so.Setuna.SelectLineColorR = picSelectAreaLineColor.BackColor.R;
            _so.Setuna.SelectLineColorG = picSelectAreaLineColor.BackColor.G;
            _so.Setuna.SelectLineColorB = picSelectAreaLineColor.BackColor.B;
            _so.Setuna.SelectBackColorR = picSelectAreaBackColor.BackColor.R;
            _so.Setuna.SelectBackColorG = picSelectAreaBackColor.BackColor.G;
            _so.Setuna.SelectBackColorB = picSelectAreaBackColor.BackColor.B;
            _so.Setuna.SelectAreaTransparent = (int)numSelectAreaTrans.Value;
            _so.Setuna.DustBoxEnable = chkDustBox.Checked;
            _so.Setuna.DustBoxCapacity = (ushort)numDustBox.Value;
            _so.Scrap.CreateStyleID = _createStyleId;
            _so.Scrap.WClickStyleID = _wclickStyleId;
            _so.Scrap.ImageDrag = chkScrapImageDrag.Checked;
            _so.Scrap.InactiveAlphaChange = chkInactiveAlphaChange.Checked;
            _so.Scrap.InactiveAlphaValue = (sbyte)numInactiveAlpha.Value;
            _so.Scrap.MouseOverAlphaChange = chkMouseOverAlphaChange.Checked;
            _so.Scrap.MouseOverAlphaValue = (sbyte)numMouseOverAlpha.Value;
            _so.Setuna.ClickCapture7 = chkCC7.Checked;
            _so.Setuna.ClickCapture8 = chkCC8.Checked;
            _so.Setuna.ClickCapture9 = chkCC9.Checked;
            _so.Setuna.ClickCapture4 = chkCC4.Checked;
            _so.Setuna.ClickCapture6 = chkCC6.Checked;
            _so.Setuna.ClickCapture1 = chkCC1.Checked;
            _so.Setuna.ClickCapture2 = chkCC2.Checked;
            _so.Setuna.ClickCapture3 = chkCC3.Checked;
            _so.Styles.Clear();
            for (var i = 0; i < listStyles.Items.Count; i++)
            {
                _so.Styles.Add((CStyle)listStyles.Items[i]);
            }
            var list = new List<int>();
            foreach (var obj in listScrapMenuList.Items)
            {
                var cstyle = (CStyle)obj;
                list.Add(cstyle.StyleID);
            }
            _so.Scrap.SubMenuStyles = list;

            _so.Setuna.TopMostEnabled = checkBox_topMost.Checked;
        }

        // Token: 0x060002D6 RID: 726 RVA: 0x00013D84 File Offset: 0x00011F84
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                base.SuspendLayout();
                var selectedTab = (TabPage)e.Node.Tag;
                tabControl1.SelectedTab = selectedTab;
                tabControl1.Update();
                base.ResumeLayout();
            }
            catch
            {
            }
        }

        // Token: 0x060002D7 RID: 727 RVA: 0x00013DDC File Offset: 0x00011FDC
        private void Prepare_SetunaAll()
        {
            hotkeyControl1.Hotkey = _so.ScrapHotKeys[0];
            hotkeyControl2.Hotkey = _so.ScrapHotKeys[1];
            checkBox1.Checked = _so.ScrapHotKeyEnable;
            rdoSelLineTypeSolid.Checked = _so.Setuna.SelectLineSolid;
            rdoSelLineTypeDotted.Checked = !_so.Setuna.SelectLineSolid;
            picSelectAreaLineColor.BackColor = _so.Setuna.SelectLineColor;
            picSelectAreaBackColor.BackColor = _so.Setuna.SelectBackColor;
            numSelectAreaTrans.Value = _so.Setuna.SelectAreaTransparent;
            chkDustBox.Checked = _so.Setuna.DustBoxEnable;
            numDustBox.Value = _so.Setuna.DustBoxCapacity;
            if (_so.Setuna.AppType == SetunaOption.SetunaOptionData.ApplicationType.ApplicationMode)
            {
                rdoExeTypeApp.Checked = true;
            }
            else
            {
                rdoExeTypeResident.Checked = true;
            }
            chkShowMainWindow.Checked = _so.Setuna.ShowMainWindow;
            if (_so.Setuna.DupType == SetunaOption.SetunaOptionData.OpeningType.Normal)
            {
                rdoDupNone.Checked = true;
            }
            else
            {
                rdoDupCapture.Checked = true;
            }
            chkSplash.Checked = _so.Setuna.ShowSplashWindow;
        }

        // Token: 0x060002D8 RID: 728 RVA: 0x00013F70 File Offset: 0x00012170
        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            lblMenuAll.Font = new Font(lblMenuAll.Font, FontStyle.Regular);
            lblMenuCapture.Font = new Font(lblMenuMenu.Font, FontStyle.Regular);
            lblMenuScrap.Font = new Font(lblMenuScrap.Font, FontStyle.Regular);
            lblMenuStyle.Font = new Font(lblMenuStyle.Font, FontStyle.Regular);
            lblMenuMenu.Font = new Font(lblMenuMenu.Font, FontStyle.Regular);
            if (tabControl1.SelectedTab == pageAll)
            {
                lblMenuAll.Font = new Font(lblMenuAll.Font, FontStyle.Bold);
            }
            if (tabControl1.SelectedTab == pageCapture)
            {
                lblMenuCapture.Font = new Font(lblMenuAll.Font, FontStyle.Bold);
            }
            if (tabControl1.SelectedTab == pageScrap)
            {
                lblMenuScrap.Font = new Font(lblMenuScrap.Font, FontStyle.Bold);
            }
            if (tabControl1.SelectedTab == pageStyle)
            {
                lblMenuStyle.Font = new Font(lblMenuStyle.Font, FontStyle.Bold);
            }
            if (tabControl1.SelectedTab == pageScrapMenu)
            {
                lblMenuMenu.Font = new Font(lblMenuMenu.Font, FontStyle.Bold);
                RefreshScrapMenuStyleList_Menu();
                RefreshScrapMenuList_Menu(GetStyleIDList_Menu());
            }
        }

        // Token: 0x060002D9 RID: 729 RVA: 0x00014108 File Offset: 0x00012308
        private void SetStyleList_Scrap(ComboBox combo, int defaultid)
        {
            var cstyle = new CStyle
            {
                StyleID = 0,
                StyleName = ""
            };
            combo.BeginUpdate();
            combo.Items.Clear();
            combo.Items.Add(cstyle);
            for (var i = 0; i < listStyles.Items.Count; i++)
            {
                var cstyle2 = (CStyle)listStyles.Items[i];
                combo.Items.Add(cstyle2);
                if (cstyle2.StyleID == defaultid)
                {
                    combo.SelectedIndex = i;
                }
            }
            combo.EndUpdate();
        }

        // Token: 0x060002DA RID: 730 RVA: 0x000141A0 File Offset: 0x000123A0
        private int FindStyle_Scrap(ComboBox combo, int styleId)
        {
            var result = 0;
            if (styleId != 0)
            {
                for (var i = 0; i < combo.Items.Count; i++)
                {
                    var cstyle = (CStyle)combo.Items[i];
                    if (cstyle.StyleID == styleId)
                    {
                        result = i;
                        break;
                    }
                }
            }
            return result;
        }

        // Token: 0x060002DB RID: 731 RVA: 0x000141E8 File Offset: 0x000123E8
        private void RefreshStyleList_Scrap()
        {
            SetStyleList_Scrap(cmbCreateStyle, 0);
            SetStyleList_Scrap(cmbWClickStyle, 0);
            cmbCreateStyle.SelectedIndex = FindStyle_Scrap(cmbCreateStyle, _createStyleId);
            cmbWClickStyle.SelectedIndex = FindStyle_Scrap(cmbWClickStyle, _wclickStyleId);
        }

        // Token: 0x060002DC RID: 732 RVA: 0x0001424C File Offset: 0x0001244C
        private void cmbCreateStyle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var cstyle = (CStyle)cmbCreateStyle.SelectedItem;
            if (cstyle.StyleName != "")
            {
                _createStyleId = cstyle.StyleID;
                return;
            }
            _createStyleId = 0;
        }

        // Token: 0x060002DD RID: 733 RVA: 0x00014290 File Offset: 0x00012490
        private void cmbWClickStyle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var cstyle = (CStyle)cmbWClickStyle.SelectedItem;
            if (cstyle.StyleName != "")
            {
                _wclickStyleId = cstyle.StyleID;
                return;
            }
            _wclickStyleId = 0;
        }

        // Token: 0x060002DE RID: 734 RVA: 0x000142D4 File Offset: 0x000124D4
        private void PrepareStyle()
        {
            Refresh_Style_StyleList();
        }

        // Token: 0x060002DF RID: 735 RVA: 0x000142DC File Offset: 0x000124DC
        private void Refresh_Style_StyleList()
        {
            listStyles.BeginUpdate();
            listStyles.Items.Clear();
            for (var i = 0; i < _so.Styles.Count; i++)
            {
                listStyles.Items.Add(_so.Styles[i]);
            }
            listStyles.EndUpdate();
        }

        // Token: 0x060002E0 RID: 736 RVA: 0x0001434C File Offset: 0x0001254C
        private void EditStyle_ScrapStyle()
        {
            if (listStyles.SelectedItem != null)
            {
                GetKeyItemBook_ScrapStyle(out var keybook);
                var selectedIndex = listStyles.SelectedIndex;
                var styleEditForm = new StyleEditForm((CStyle)listStyles.SelectedItem, keybook)
                {
                    Text = ((CStyle)listStyles.SelectedItem).StyleName + "的相关编辑"
                };
                var dialogResult = styleEditForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    listStyles.Items[selectedIndex] = styleEditForm.Style;
                    RefreshStyleList_Scrap();
                }
            }
        }

        // Token: 0x060002E1 RID: 737 RVA: 0x000143E0 File Offset: 0x000125E0
        private void SelectStyle_ScrapStyle()
        {
            listStyleItems.Items.Clear();
            listKeyItems.Items.Clear();
            if (listStyles.SelectedItem != null)
            {
                var cstyle = (CStyle)listStyles.SelectedItem;
                for (var i = 0; i < cstyle.Items.Length; i++)
                {
                    listStyleItems.Items.Add(cstyle.Items[i]);
                }
                for (var j = 0; j < cstyle.KeyItems.Length; j++)
                {
                    listKeyItems.Items.Add(cstyle.KeyItems[j]);
                }
            }
        }

        // Token: 0x060002E2 RID: 738 RVA: 0x00014484 File Offset: 0x00012684
        private void GetKeyItemBook_ScrapStyle(out KeyItemBook keybook)
        {
            keybook = new KeyItemBook();
            for (var i = 0; i < listStyles.Items.Count; i++)
            {
                var cstyle = (CStyle)listStyles.Items[i];
                keybook.AddKeyItem(cstyle.KeyItems);
            }
        }

        // Token: 0x060002E3 RID: 739 RVA: 0x000144D8 File Offset: 0x000126D8
        private void btnNewStyle_Click(object sender, EventArgs e)
        {
            GetKeyItemBook_ScrapStyle(out var keybook);
            var cstyle = new CStyle();
            StyleEditForm styleEditForm2;
            var styleEditForm = styleEditForm2 = new StyleEditForm(cstyle, keybook);
            try
            {
                styleEditForm.Text = "新建自动操作";
                var dialogResult = styleEditForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    cstyle.MakeStyleID();
                    listStyles.Items.Add(cstyle);
                    RefreshStyleList_Scrap();
                }
            }
            finally
            {
                if (styleEditForm2 != null)
                {
                    ((IDisposable)styleEditForm2).Dispose();
                }
            }
        }

        // Token: 0x060002E4 RID: 740 RVA: 0x00014550 File Offset: 0x00012750
        private void btnCopy_Click_1(object sender, EventArgs e)
        {
            if (listStyles.SelectedItem != null)
            {
                GetKeyItemBook_ScrapStyle(out var keybook);
                var cstyle = ((CStyle)listStyles.SelectedItem).DeepCopy();
                cstyle.StyleName = "";
                cstyle.ClearKey();
                var dialogResult = new StyleEditForm(cstyle, keybook)
                {
                    Text = "新建自动操作"
                }.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    cstyle.MakeStyleID();
                    listStyles.Items.Add(cstyle);
                }
            }
        }

        // Token: 0x060002E5 RID: 741 RVA: 0x000145CF File Offset: 0x000127CF
        private void btnEditStyle_Click(object sender, EventArgs e)
        {
            EditStyle_ScrapStyle();
        }

        // Token: 0x060002E6 RID: 742 RVA: 0x000145D8 File Offset: 0x000127D8
        private void btnDeleteStyle_Click(object sender, EventArgs e)
        {
            if (listStyles.SelectedItem != null)
            {
                var styleID = ((CStyle)listStyles.SelectedItem).StyleID;
                listStyles.Items.Remove(listStyles.SelectedItem);
                if (_createStyleId == styleID)
                {
                    _createStyleId = 0;
                }
                if (_activeStyleId == styleID)
                {
                    _activeStyleId = 0;
                }
                if (_inactiveStyleId == styleID)
                {
                    _inactiveStyleId = 0;
                }
                RefreshStyleList_Scrap();
            }
        }

        // Token: 0x060002E7 RID: 743 RVA: 0x0001465C File Offset: 0x0001285C
        private void listStyles_DoubleClick(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            if (listBox.SelectedItem != null)
            {
                EditStyle_ScrapStyle();
            }
        }

        // Token: 0x060002E8 RID: 744 RVA: 0x0001467E File Offset: 0x0001287E
        private void listStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectStyle_ScrapStyle();
        }

        // Token: 0x060002E9 RID: 745 RVA: 0x00014686 File Offset: 0x00012886
        private void btnOK_Click(object sender, EventArgs e)
        {
            WriteSetunaOption();
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        // Token: 0x060002EA RID: 746 RVA: 0x0001469B File Offset: 0x0001289B
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        // Token: 0x060002EB RID: 747 RVA: 0x000146AC File Offset: 0x000128AC
        private void pictureBox_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            var dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var pictureBox = (PictureBox)sender;
                pictureBox.BackColor = colorDialog.Color;
            }
        }

        // Token: 0x060002EC RID: 748 RVA: 0x000146E0 File Offset: 0x000128E0
        private void Prepare_ScrapMenu()
        {
            listScrapMenuItems.Items.Clear();
            foreach (var item in CPreStyles.GetPreStyleList())
            {
                listScrapMenuItems.Items.Add(item);
            }
            RefreshScrapMenuList_Menu(_so.Scrap.SubMenuStyles);
        }

        // Token: 0x060002ED RID: 749 RVA: 0x00014764 File Offset: 0x00012964
        private void RefreshScrapMenuStyleList_Menu()
        {
            base.SuspendLayout();
            SetStyleList_Menu(listScrapMenuStyles);
            base.ResumeLayout();
        }

        // Token: 0x060002EE RID: 750 RVA: 0x00014780 File Offset: 0x00012980
        private void RefreshScrapMenuList_Menu(List<int> style_ids)
        {
            listScrapMenuList.BeginUpdate();
            listScrapMenuList.Items.Clear();
            foreach (var num in style_ids)
            {
                if (num >= 0)
                {
                    var enumerator2 = listStyles.Items.GetEnumerator();
                    {
                        while (enumerator2.MoveNext())
                        {
                            var obj = enumerator2.Current;
                            var cstyle = (CStyle)obj;
                            if (cstyle.StyleID == num)
                            {
                                listScrapMenuList.Items.Add(cstyle);
                                break;
                            }
                        }
                        continue;
                    }
                }
                foreach (var obj2 in listScrapMenuItems.Items)
                {
                    var cstyle2 = (CStyle)obj2;
                    if (cstyle2.StyleID == num)
                    {
                        listScrapMenuList.Items.Add(cstyle2);
                        break;
                    }
                }
            }
            listScrapMenuList.EndUpdate();
        }

        // Token: 0x060002EF RID: 751 RVA: 0x000148CC File Offset: 0x00012ACC
        private List<int> GetStyleIDList_Menu()
        {
            var list = new List<int>();
            foreach (var obj in listScrapMenuList.Items)
            {
                var cstyle = (CStyle)obj;
                list.Add(cstyle.StyleID);
            }
            return list;
        }

        // Token: 0x060002F0 RID: 752 RVA: 0x00014938 File Offset: 0x00012B38
        private void SetStyleList_Menu(ListBox list)
        {
            var cstyle = new CStyle
            {
                StyleID = 0,
                StyleName = ""
            };
            list.BeginUpdate();
            list.Items.Clear();
            for (var i = 0; i < listStyles.Items.Count; i++)
            {
                var item = (CStyle)listStyles.Items[i];
                list.Items.Add(item);
            }
            list.EndUpdate();
        }

        // Token: 0x060002F1 RID: 753 RVA: 0x000149B3 File Offset: 0x00012BB3
        private void listScrapMenuStyles_Enter(object sender, EventArgs e)
        {
            listScrapMenuItems.ClearSelected();
        }

        // Token: 0x060002F2 RID: 754 RVA: 0x000149C0 File Offset: 0x00012BC0
        private void listScrapMenuItems_Enter(object sender, EventArgs e)
        {
            listScrapMenuStyles.ClearSelected();
        }

        // Token: 0x060002F3 RID: 755 RVA: 0x000149CD File Offset: 0x00012BCD
        private void btnScrapMenuMove_Click(object sender, EventArgs e)
        {
            if (listScrapMenuStyles.SelectedIndex >= 0)
            {
                listScrapMenuStyles_MouseDoubleClick(null, null);
                return;
            }
            if (listScrapMenuItems.SelectedIndex >= 0)
            {
                listScrapMenuItems_MouseDoubleClick(null, null);
            }
        }

        // Token: 0x060002F4 RID: 756 RVA: 0x000149FC File Offset: 0x00012BFC
        private void listScrapMenuStyles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedIndex = listScrapMenuList.Items.Add(listScrapMenuStyles.SelectedItem);
            listScrapMenuList.SelectedIndex = selectedIndex;
        }

        // Token: 0x060002F5 RID: 757 RVA: 0x00014A34 File Offset: 0x00012C34
        private void listScrapMenuItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedIndex = listScrapMenuList.Items.Add(listScrapMenuItems.SelectedItem);
            listScrapMenuList.SelectedIndex = selectedIndex;
        }

        // Token: 0x060002F6 RID: 758 RVA: 0x00014A69 File Offset: 0x00012C69
        private void button1_Click(object sender, EventArgs e)
        {
        }

        // Token: 0x060002F7 RID: 759 RVA: 0x00014A6C File Offset: 0x00012C6C
        private void btnInitialize_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("进行设置内容的初始化。", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.OK)
            {
                _so = SetunaOption.GetDefaultOption();
                LoadSetunaOption();
            }
        }

        // Token: 0x17000074 RID: 116
        // (get) Token: 0x060002F8 RID: 760 RVA: 0x00014AA6 File Offset: 0x00012CA6
        public SetunaOption Option => _so;

        // Token: 0x060002F9 RID: 761 RVA: 0x00014AAE File Offset: 0x00012CAE
        private void rdoExeTypeResident_CheckedChanged(object sender, EventArgs e)
        {
            chkShowMainWindow.Enabled = rdoExeTypeResident.Checked;
        }

        // Token: 0x060002FA RID: 762 RVA: 0x00014AC6 File Offset: 0x00012CC6
        private void lblMenuAll_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = pageAll;
        }

        // Token: 0x060002FB RID: 763 RVA: 0x00014AD9 File Offset: 0x00012CD9
        private void lblMenuCapture_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = pageCapture;
        }

        // Token: 0x060002FC RID: 764 RVA: 0x00014AEC File Offset: 0x00012CEC
        private void lblMenuScrap_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = pageScrap;
        }

        // Token: 0x060002FD RID: 765 RVA: 0x00014AFF File Offset: 0x00012CFF
        private void lblMenuStyle_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = pageStyle;
        }

        // Token: 0x060002FE RID: 766 RVA: 0x00014B12 File Offset: 0x00012D12
        private void lblMenuMenu_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = pageScrapMenu;
        }

        // Token: 0x060002FF RID: 767 RVA: 0x00014B25 File Offset: 0x00012D25
        private void lblMenu_Clear(object sender, EventArgs e)
        {
            lblComment.Text = "";
        }

        // Token: 0x06000300 RID: 768 RVA: 0x00014B37 File Offset: 0x00012D37
        private void lblMenuAll_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = "SETUNA常规设置。";
        }

        // Token: 0x06000301 RID: 769 RVA: 0x00014B49 File Offset: 0x00012D49
        private void lblMenuCapture_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = "进行有关截取的设置。";
        }

        // Token: 0x06000302 RID: 770 RVA: 0x00014B5B File Offset: 0x00012D5B
        private void lblMenuScrap_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = "进行参考图的常规设置。";
        }

        // Token: 0x06000303 RID: 771 RVA: 0x00014B6D File Offset: 0x00012D6D
        private void lblMenuStyle_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = "创建一个由自动操作组合而成的自动操作。";
        }

        // Token: 0x06000304 RID: 772 RVA: 0x00014B7F File Offset: 0x00012D7F
        private void lblMenuMenu_MouseEnter(object sender, EventArgs e)
        {
            lblComment.Text = "设置右键单击参考图时的菜单。";
        }

        // Token: 0x06000305 RID: 773 RVA: 0x00014B91 File Offset: 0x00012D91
        private void OptionForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
        }

        // Token: 0x06000306 RID: 774 RVA: 0x00014B94 File Offset: 0x00012D94
        private void chkCC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var checkBox = (CheckBox)sender;
                if (checkBox.Checked)
                {
                    checkBox.BackColor = Color.FromArgb(223, 241, 255);
                }
                else
                {
                    checkBox.BackColor = SystemColors.Window;
                }
            }
            catch
            {
            }
        }

        // Token: 0x040001B4 RID: 436
        private SetunaOption _so;

        // Token: 0x040001B5 RID: 437
        private int _createStyleId;

        // Token: 0x040001B6 RID: 438
        private int _wclickStyleId;

        // Token: 0x040001B7 RID: 439
        private int _activeStyleId;

        // Token: 0x040001B8 RID: 440
        private int _inactiveStyleId;

        // Token: 0x040001B9 RID: 441
        private TabPage _pageStyle;

        // Token: 0x040001BA RID: 442
        private TabPage _pageScrapMenu;

        private void OptionForm_Shown(object sender, EventArgs e)
        {
            TopMost = true;

            Layer.LayerManager.Instance.SuspendRefresh();
        }

        private void OptionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Layer.LayerManager.Instance.ResumeRefresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Cache.CacheManager.Path);
        }
    }
}
