namespace SETUNA.Main.Option
{
    using SETUNA.Main;
    using SETUNA.Main.KeyItems;
    using SETUNA.Main.Other;
    using SETUNA.Main.Style;
    using SETUNA.Main.StyleItems;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class SetunaOption : ICloneable
    {
        protected bool blHotKey = false;
        private const string ConfigFileName = "SetunaConfig.xml";
        public bool Difficult = false;
        protected Keys hkScrap = Keys.None;
        public const int HOTKEY_ID = 1;
        protected IntPtr ipParentHandle = IntPtr.Zero;
        private const int MOD_ALT = 1;
        private const int MOD_CONTROL = 2;
        private const int MOD_SHIFT = 4;
        public ScrapOptionData Scrap = new ScrapOptionData();
        public SetunaOptionData Setuna = new SetunaOptionData();
        public List<CStyle> Styles = new List<CStyle>();
        public const int WM_HOTKEY = 0x312;
        private float mDpi1;
        private float mDpi2;
        private float mDpi3;
        private float mDpi4;

        public object Clone()
        {
            SetunaOption option = new SetunaOption
            {
                Difficult = this.Difficult,
                hkScrap = this.hkScrap,
                blHotKey = this.blHotKey,
                ipParentHandle = this.ipParentHandle,
                Setuna = this.Setuna,
                Scrap = this.Scrap,
                dpi1 = this.dpi1,
                dpi2 = this.dpi2,
                dpi3 = this.dpi3,
                dpi4 = this.dpi4,
            };
            for (int i = 0; i < this.Styles.Count; i++)
            {
                option.Styles.Add(this.Styles[i].DeepCopy());
            }
            return option;
        }

        public CStyle FindStyle(int styleId)
        {
            if (styleId == 0)
            {
                return null;
            }
            foreach (CStyle style2 in this.Styles)
            {
                if (style2.StyleID == styleId)
                {
                    return style2;
                }
            }
            return null;
        }

        public static System.Type[] GetAllType()
        {
            System.Type[] styleType = StyleItemDictionary.GetStyleType();
            ArrayList list = new ArrayList {
                typeof(SetunaOption),
                typeof(CStyle),
                typeof(Color)
            };
            for (int i = 0; i < styleType.Length; i++)
            {
                list.Add(styleType[i]);
            }
            System.Type[] typeArray2 = new System.Type[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                typeArray2[j] = (System.Type)list[j];
            }
            return typeArray2;
        }

        public static SetunaOption GetDefaultOption()
        {
            SetunaOption option = new SetunaOption();
            int num = 1;
            option.Setuna.AppType = SetunaOptionData.ApplicationType.ApplicationMode;
            option.Setuna.ShowMainWindow = true;
            option.Setuna.DupType = SetunaOptionData.OpeningType.Normal;
            option.Setuna.DustBoxCapacity = 5;
            option.Setuna.DustBoxEnable = true;
            option.Setuna.SelectAreaTransparent = 80;
            option.Setuna.SelectBackColorR = 0;
            option.Setuna.SelectBackColorG = 0;
            option.Setuna.SelectBackColorB = 0x8b;
            option.Setuna.SelectLineColorR = 0;
            option.Setuna.SelectLineColorG = 0;
            option.Setuna.SelectLineColorB = 0;
            option.Setuna.ShowSplashWindow = true;
            option.Setuna.SelectLineSolid = false;
            option.ScrapHotKeyData = Keys.Control | Keys.Alt | Keys.A;
            option.ScrapHotKeyEnable = true;
            option.Scrap.InactiveAlphaChange = true;
            option.Scrap.InactiveAlphaValue = 10;
            option.Scrap.MouseOverAlphaChange = true;
            option.Scrap.MouseOverAlphaValue = 90;

            option.mDpi1 = DPIUtils.defaultDpi1;
            option.mDpi2 = 1.0F;
            option.mDpi3 = 1.0F;
            option.mDpi4 = 1.0F;

            CStyle style = new CStyle
            {
                StyleID = num++,
                StyleName = "复制"
            };
            CCopyStyleItem newCi = new CCopyStyleItem
            {
                CopyFromSource = true
            };
            style.AddStyle(newCi);
            style.AddKeyItem(Keys.Control | Keys.C);
            int styleID = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "复制（有边框）"
            };
            CCopyStyleItem item2 = new CCopyStyleItem
            {
                CopyFromSource = false
            };
            style.AddStyle(item2);
            style.AddKeyItem(Keys.Control | Keys.Shift | Keys.C);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "剪切"
            };
            CCopyStyleItem item3 = new CCopyStyleItem
            {
                CopyFromSource = true
            };
            style.AddStyle(item3);
            style.AddStyle(new CCloseStyleItem());
            style.AddKeyItem(Keys.Control | Keys.X);
            int item = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "剪切（有边框）"
            };
            CCopyStyleItem item4 = new CCopyStyleItem
            {
                CopyFromSource = false
            };
            style.AddStyle(item4);
            style.AddStyle(new CCloseStyleItem());
            style.AddKeyItem(Keys.Control | Keys.Shift | Keys.X);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "粘贴"
            };
            CPasteStyleItem item5 = new CPasteStyleItem();
            style.AddStyle(item5);
            style.AddKeyItem(Keys.Control | Keys.V);
            int num5 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "保存"
            };
            CImageJpegStyleItem item6 = new CImageJpegStyleItem
            {
                Quality = 100,
                ShowPreview = true,
                FileNameType = CImageStyleItem.EnumFileName.SaveAs,
                HaveMargin = false
            };
            style.AddStyle(item6);
            style.AddKeyItem(Keys.Control | Keys.S);
            int num6 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "保存（有边框）"
            };
            CImageJpegStyleItem item7 = new CImageJpegStyleItem
            {
                Quality = 100,
                ShowPreview = true,
                FileNameType = CImageStyleItem.EnumFileName.SaveAs,
                HaveMargin = true
            };
            style.AddStyle(item7);
            style.AddKeyItem(Keys.Control | Keys.Shift | Keys.S);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "旋转90度"
            };
            CRotateStyleItem item8 = new CRotateStyleItem
            {
                Rotate = 90
            };
            style.AddStyle(item8);
            style.AddKeyItem(Keys.R);
            int num12 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "垂直翻转"
            };
            CRotateStyleItem item9 = new CRotateStyleItem
            {
                VerticalReflection = true
            };
            style.AddStyle(item9);
            style.AddKeyItem(Keys.Alt | Keys.V);
            int num13 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "水平翻转"
            };
            CRotateStyleItem item10 = new CRotateStyleItem
            {
                HorizonReflection = true
            };
            style.AddStyle(item10);
            style.AddKeyItem(Keys.Alt | Keys.H);
            int num14 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "扩大"
            };
            CScaleStyleItem item11 = new CScaleStyleItem
            {
                Value = 10,
                SetType = CScaleStyleItem.ScaleSetType.Increment
            };
            style.AddStyle(item11);
            style.AddKeyItem(Keys.Alt | Keys.Up);
            int num11 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "扩大（微调）"
            };
            CScaleStyleItem item12 = new CScaleStyleItem
            {
                Value = 1,
                SetType = CScaleStyleItem.ScaleSetType.Increment
            };
            style.AddStyle(item12);
            style.AddKeyItem(Keys.Alt | Keys.Shift | Keys.Up);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "缩小"
            };
            CScaleStyleItem item13 = new CScaleStyleItem
            {
                Value = -10,
                SetType = CScaleStyleItem.ScaleSetType.Increment
            };
            style.AddStyle(item13);
            style.AddKeyItem(Keys.Alt | Keys.Down);
            int num10 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "缩小（微调）"
            };
            CScaleStyleItem item14 = new CScaleStyleItem
            {
                Value = -1,
                SetType = CScaleStyleItem.ScaleSetType.Increment
            };
            style.AddStyle(item14);
            style.AddKeyItem(Keys.Alt | Keys.Shift | Keys.Down);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "增加透明度"
            };
            COpacityStyleItem item15 = new COpacityStyleItem
            {
                Absolute = false,
                Opacity = 10
            };
            style.AddStyle(item15);
            style.AddKeyItem(Keys.Alt | Keys.Left);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "增加透明度（微调）"
            };
            COpacityStyleItem item16 = new COpacityStyleItem
            {
                Absolute = false,
                Opacity = 1
            };
            style.AddStyle(item16);
            style.AddKeyItem(Keys.Alt | Keys.Shift | Keys.Left);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "降低透明度"
            };
            COpacityStyleItem item17 = new COpacityStyleItem
            {
                Absolute = false,
                Opacity = -10
            };
            style.AddStyle(item17);
            style.AddKeyItem(Keys.Alt | Keys.Right);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "降低透明度（微调）"
            };
            COpacityStyleItem item18 = new COpacityStyleItem
            {
                Absolute = false,
                Opacity = -1
            };
            style.AddStyle(item18);
            style.AddKeyItem(Keys.Alt | Keys.Shift | Keys.Right);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "向上移动"
            };
            CMoveStyleItem item19 = new CMoveStyleItem
            {
                Top = -50
            };
            style.AddStyle(item19);
            style.AddKeyItem(Keys.Shift | Keys.Up);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "向上移动（微调）"
            };
            CMoveStyleItem item20 = new CMoveStyleItem
            {
                Top = -1
            };
            style.AddStyle(item20);
            style.AddKeyItem(Keys.Up);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "向下移动"
            };
            CMoveStyleItem item21 = new CMoveStyleItem
            {
                Top = 50
            };
            style.AddStyle(item21);
            style.AddKeyItem(Keys.Shift | Keys.Down);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "向下移动（微调）"
            };
            CMoveStyleItem item22 = new CMoveStyleItem
            {
                Top = 1
            };
            style.AddStyle(item22);
            style.AddKeyItem(Keys.Down);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "向左移动"
            };
            CMoveStyleItem item23 = new CMoveStyleItem
            {
                Left = -50
            };
            style.AddStyle(item23);
            style.AddKeyItem(Keys.Shift | Keys.Left);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "向左移动（微调）"
            };
            CMoveStyleItem item24 = new CMoveStyleItem
            {
                Left = -1
            };
            style.AddStyle(item24);
            style.AddKeyItem(Keys.Left);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "向右移动"
            };
            CMoveStyleItem item25 = new CMoveStyleItem
            {
                Left = 50
            };
            style.AddStyle(item25);
            style.AddKeyItem(Keys.Shift | Keys.Right);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "向右移动（微调）"
            };
            CMoveStyleItem item26 = new CMoveStyleItem
            {
                Left = 1
            };
            style.AddStyle(item26);
            style.AddKeyItem(Keys.Right);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "缩放为50%"
            };
            CScaleStyleItem item27 = new CScaleStyleItem
            {
                SetType = CScaleStyleItem.ScaleSetType.Fixed,
                Value = 50
            };
            style.AddStyle(item27);
            style.AddKeyItem(Keys.D5);
            int num8 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "缩放为60%"
            };
            CScaleStyleItem item28 = new CScaleStyleItem
            {
                SetType = CScaleStyleItem.ScaleSetType.Fixed,
                Value = 60
            };
            style.AddStyle(item28);
            style.AddKeyItem(Keys.D6);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "缩放为70%"
            };
            CScaleStyleItem item29 = new CScaleStyleItem
            {
                SetType = CScaleStyleItem.ScaleSetType.Fixed,
                Value = 70
            };
            style.AddStyle(item29);
            style.AddKeyItem(Keys.D7);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "缩放为80%"
            };
            CScaleStyleItem item30 = new CScaleStyleItem
            {
                SetType = CScaleStyleItem.ScaleSetType.Fixed,
                Value = 80
            };
            style.AddStyle(item30);
            style.AddKeyItem(Keys.D8);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "缩放为90%"
            };
            CScaleStyleItem item31 = new CScaleStyleItem
            {
                SetType = CScaleStyleItem.ScaleSetType.Fixed,
                Value = 90
            };
            style.AddStyle(item31);
            style.AddKeyItem(Keys.D9);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "缩放为100%"
            };
            CScaleStyleItem item32 = new CScaleStyleItem
            {
                SetType = CScaleStyleItem.ScaleSetType.Fixed,
                Value = 100
            };
            style.AddStyle(item32);
            style.AddKeyItem(Keys.D0);
            int num7 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "缩放为150%"
            };
            CScaleStyleItem item33 = new CScaleStyleItem
            {
                SetType = CScaleStyleItem.ScaleSetType.Fixed,
                Value = 150
            };
            style.AddStyle(item33);
            int num9 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "立体边框"
            };
            CMarginStyleItem item34 = new CMarginStyleItem
            {
                BorderStyle = 0
            };
            style.AddStyle(item34);
            style.AddKeyItem(Keys.D1);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "单色边框"
            };
            CMarginStyleItem item35 = new CMarginStyleItem
            {
                BorderStyle = 1,
                MarginColorRed = 0xff,
                MarginColorGreen = 0x80,
                MarginColorBlue = 0x40,
                MarginSize = 1
            };
            style.AddStyle(item35);
            style.AddKeyItem(Keys.D2);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "窗口化"
            };
            CMarginStyleItem item36 = new CMarginStyleItem
            {
                BorderStyle = 2
            };
            style.AddStyle(item36);
            style.AddKeyItem(Keys.D3);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "无边框"
            };
            CMarginStyleItem item37 = new CMarginStyleItem
            {
                BorderStyle = 1,
                MarginSize = 0
            };
            style.AddStyle(item37);
            style.AddKeyItem(Keys.L);
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "关闭"
            };
            CCloseStyleItem item38 = new CCloseStyleItem();
            style.AddStyle(item38);
            style.AddKeyItem(Keys.Q);
            int num2 = style.StyleID;
            option.Styles.Add(style);
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "基本自动操作"
            };
            CMarginStyleItem item39 = new CMarginStyleItem
            {
                BorderStyle = 0
            };
            style.AddStyle(item39);
            COpacityStyleItem item40 = new COpacityStyleItem
            {
                Absolute = true,
                Opacity = 0x5f
            };
            style.AddStyle(item40);
            option.Styles.Add(style);
            option.Scrap.CreateStyleID = style.StyleID;
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "收缩"
            };
            CCompactStyleItem item41 = new CCompactStyleItem
            {
                Opacity = 80,
                SoldLine = false,
                LineColor = Color.Blue.ToArgb()
            };
            style.AddStyle(item41);
            option.Styles.Add(style);
            option.Scrap.WClickStyleID = style.StyleID;
            style = new CStyle
            {
                StyleID = num++,
                StyleName = "修剪"
            };
            CTrimStyleItem item42 = new CTrimStyleItem();
            style.AddStyle(item42);
            style.AddKeyItem(Keys.T);
            option.Styles.Add(style);
            option.Scrap.SubMenuStyles.Add(num2);
            option.Scrap.SubMenuStyles.Add(new CSeparatorStyle().StyleID);
            option.Scrap.SubMenuStyles.Add(new CScrapListStyle().StyleID);
            option.Scrap.SubMenuStyles.Add(new CDustBoxStyle().StyleID);
            option.Scrap.SubMenuStyles.Add(new CDustEraseStyle().StyleID);
            option.Scrap.SubMenuStyles.Add(new COptionStyle().StyleID);
            option.Scrap.SubMenuStyles.Add(new CShowVersionStyle().StyleID);
            option.Scrap.SubMenuStyles.Add(new CSeparatorStyle().StyleID);
            option.Scrap.SubMenuStyles.Add(styleID);
            option.Scrap.SubMenuStyles.Add(item);
            option.Scrap.SubMenuStyles.Add(num5);
            option.Scrap.SubMenuStyles.Add(num6);
            option.Scrap.SubMenuStyles.Add(new CSeparatorStyle().StyleID);
            option.Scrap.SubMenuStyles.Add(num8);
            option.Scrap.SubMenuStyles.Add(num7);
            option.Scrap.SubMenuStyles.Add(num9);
            option.Scrap.SubMenuStyles.Add(num10);
            option.Scrap.SubMenuStyles.Add(num11);
            option.Scrap.SubMenuStyles.Add(new CSeparatorStyle().StyleID);
            option.Scrap.SubMenuStyles.Add(num12);
            option.Scrap.SubMenuStyles.Add(num13);
            option.Scrap.SubMenuStyles.Add(num14);
            return option;
        }

        public KeyItemBook GetKeyItemBook()
        {
            KeyItemBook book = new KeyItemBook();
            for (int i = 0; i < this.Styles.Count; i++)
            {
                CStyle style = this.Styles[i];
                book.AddKeyItem(style.KeyItems);
            }
            return book;
        }

        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(IntPtr hWnd, int ID, int MOD_KEY, int KEY);
        public bool RegistHotKey(IntPtr handle)
        {
            if (this.ipParentHandle != IntPtr.Zero)
            {
                this.UnregistHotKey();
            }
            if ((this.hkScrap != Keys.None) && this.blHotKey)
            {
                this.ipParentHandle = handle;
                int num = 0;
                if ((this.hkScrap & Keys.Shift) == Keys.Shift)
                {
                    num |= 4;
                }
                if ((this.hkScrap & Keys.Alt) == Keys.Alt)
                {
                    num |= 1;
                }
                if ((this.hkScrap & Keys.Control) == Keys.Control)
                {
                    num |= 2;
                }
                Keys keys = this.hkScrap & Keys.KeyCode;
                if (RegisterHotKey(this.ipParentHandle, 1, num, (int)keys) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(IntPtr hWnd, int ID);
        public void UnregistHotKey()
        {
            if (this.ipParentHandle != IntPtr.Zero)
            {
                UnregisterHotKey(this.ipParentHandle, 1);
                this.ipParentHandle = IntPtr.Zero;
            }
        }

        public string ApplicationPath
        {
            get
            {
                return
                Application.ExecutablePath;
            }
            set
            {
                Console.WriteLine(this.ApplicationPath);
            }
        }

        public string ApplicationVersion
        {
            get
            {
                return
                Application.ProductVersion;
            }
            set
            {
                Console.WriteLine(this.ApplicationVersion);
            }
        }

        public static string ConfigFile
        {
            get
            {
                string fullPath = Path.GetFullPath(Path.Combine(Application.StartupPath, ""));
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
                return Path.Combine(fullPath, "SetunaConfig.xml");
            }
        }

        public string OptionVersion
        {
            get
            {
                return
                "1.0";
            }
            set
            {
                Console.WriteLine(this.OptionVersion);
            }
        }

        public int ScrapHotKey
        {
            get
            {
                return
                ((int)this.ScrapHotKeyData);
            }
            set
            {
                this.ScrapHotKeyData = (Keys)value;
            }
        }

        protected Keys ScrapHotKeyData
        {
            get
            {
                return
                this.hkScrap;
            }
            set
            {
                this.hkScrap = value;
            }
        }

        public bool ScrapHotKeyEnable
        {
            get
            {
                return
                this.blHotKey;
            }
            set
            {
                this.blHotKey = value;
            }
        }

        public float dpi1
        {
            set { mDpi1 = value; }
            get
            {
                if (mDpi1 == 0)
                {
                    mDpi1 = DPIUtils.defaultDpi1;
                }
                return mDpi1;
            }
        }

        public float dpi2
        {
            set { mDpi2 = value; }
            get
            {
                if (mDpi2 == 0)
                {
                    mDpi2 = DPIUtils.defaultDpi2;
                }
                return mDpi2;
            }
        }

        public float dpi3
        {
            set { mDpi3 = value; }
            get
            {
                if (mDpi3 == 0)
                {
                    mDpi3 = DPIUtils.defaultDpi3;
                }
                return mDpi3;
            }
        }

        public float dpi4
        {
            set { mDpi4 = value; }
            get
            {
                if (mDpi4 == 0)
                {
                    mDpi4 = DPIUtils.defaultDpi4;
                }
                return mDpi4;
            }
        }

        public class ScrapOptionData
        {
            private sbyte _InactiveAlphaValue;
            private sbyte _InactiveLineValue;
            private sbyte _MouseOverAlphaValue;
            private sbyte _MouseOverLineValue;
            public int CreateStyleID = 0;
            public bool ImageDrag = true;
            public bool InactiveAlphaChange = true;
            public bool InactiveLineChange;
            public RGBColor InactiveLineColor;
            public bool MouseOverAlphaChange;
            public bool MouseOverLineChange;
            public RGBColor MouseOverLineColor;
            public List<int> SubMenuStyles;
            public int WClickStyleID = 0;

            public ScrapOptionData()
            {
                this.InactiveAlphaValue = 90;
                this.InactiveLineChange = false;
                this.InactiveLineValue = 1;
                this.InactiveLineColor = new RGBColor(0, 0, 0);
                this.MouseOverAlphaChange = true;
                this.MouseOverAlphaValue = 10;
                this.MouseOverLineChange = false;
                this.MouseOverLineValue = 1;
                this.MouseOverLineColor = new RGBColor(0, 0, 0);
                this.SubMenuStyles = new List<int>();
            }

            public sbyte InactiveAlphaValue
            {
                get
                {
                    if (this._InactiveAlphaValue > 100)
                    {
                        return 100;
                    }
                    if (this._InactiveAlphaValue < 1)
                    {
                        return 1;
                    }
                    return this._InactiveAlphaValue;
                }
                set
                {
                    if (value > 100)
                    {
                        this._InactiveAlphaValue = 100;
                    }
                    else if (value < 1)
                    {
                        this._InactiveAlphaValue = 1;
                    }
                    else
                    {
                        this._InactiveAlphaValue = value;
                    }
                }
            }

            public sbyte InactiveLineValue
            {
                get
                {
                    if (this._InactiveLineValue > 10)
                    {
                        return 10;
                    }
                    return this._InactiveLineValue;
                }
                set
                {
                    if (value > 10)
                    {
                        this._InactiveLineValue = 10;
                    }
                    else
                    {
                        this._InactiveLineValue = value;
                    }
                }
            }

            public sbyte MouseOverAlphaValue
            {
                get
                {
                    if (this._MouseOverAlphaValue > 100)
                    {
                        return 100;
                    }
                    if (this._MouseOverAlphaValue < 1)
                    {
                        return 1;
                    }
                    return this._MouseOverAlphaValue;
                }
                set
                {
                    if (value > 100)
                    {
                        this._MouseOverAlphaValue = 100;
                    }
                    else if (value < 1)
                    {
                        this._MouseOverAlphaValue = 1;
                    }
                    else
                    {
                        this._MouseOverAlphaValue = value;
                    }
                }
            }

            public sbyte MouseOverLineValue
            {
                get
                {
                    if (this._MouseOverLineValue > 10)
                    {
                        return 10;
                    }
                    return this._MouseOverLineValue;
                }
                set
                {
                    if (value > 10)
                    {
                        this._MouseOverLineValue = 10;
                    }
                    else
                    {
                        this._MouseOverLineValue = value;
                    }
                }
            }
        }

        public class SetunaOptionData
        {
            public ApplicationType AppType = ApplicationType.ApplicationMode;
            public bool ClickCapture1 = false;
            public bool ClickCapture2 = false;
            public bool ClickCapture3 = false;
            public bool ClickCapture4 = false;
            public bool ClickCapture6 = false;
            public bool ClickCapture7 = false;
            public bool ClickCapture8 = false;
            public bool ClickCapture9 = false;
            public OpeningType DupType;
            public ushort DustBoxCapacity = 5;
            public bool DustBoxEnable = true;
            public int SelectAreaTransparent = 80;
            public byte SelectBackColorB = Color.DarkBlue.B;
            public byte SelectBackColorG = Color.DarkBlue.G;
            public byte SelectBackColorR = Color.DarkBlue.R;
            public byte SelectLineColorB = Color.Blue.B;
            public byte SelectLineColorG = Color.Blue.G;
            public byte SelectLineColorR = Color.Blue.R;
            public bool SelectLineSolid = true;
            public bool ShowMainWindow = true;
            public bool ShowSplashWindow = true;

            public bool ClickCapture =>
                (((((((this.ClickCapture7 | this.ClickCapture8) | this.ClickCapture9) | this.ClickCapture4) | this.ClickCapture6) | this.ClickCapture1) | this.ClickCapture2) | this.ClickCapture3);

            public bool[] ClickCaptureValue =>
                new bool[] { false, this.ClickCapture1, this.ClickCapture2, this.ClickCapture3, this.ClickCapture4, false, this.ClickCapture6, this.ClickCapture7, this.ClickCapture8, this.ClickCapture9 };

            public Color SelectBackColor =>
                Color.FromArgb(this.SelectBackColorR, this.SelectBackColorG, this.SelectBackColorB);

            public Color SelectLineColor =>
                Color.FromArgb(this.SelectLineColorR, this.SelectLineColorG, this.SelectLineColorB);

            public enum ApplicationType
            {
                ApplicationMode = 1,
                ResidentMode = 0x10
            }

            public enum OpeningType
            {
                Normal,
                Capture
            }
        }
    }
}

