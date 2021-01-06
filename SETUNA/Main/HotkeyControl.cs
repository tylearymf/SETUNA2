using System;
using System.Windows.Forms;

namespace SETUNA.Main
{
    public partial class HotkeyControl : UserControl
    {
        private System.Windows.Forms.Keys m_hotkey;

        public HotkeyControl()
        {
            InitializeComponent();

            SetStyle(System.Windows.Forms.ControlStyles.UserPaint, false);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var baseParams = base.CreateParams;
                baseParams.ClassName = "msctls_hotkey32";
                return baseParams;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Hotkey = m_hotkey;
        }

        public System.Windows.Forms.Keys Hotkey
        {
            get
            {
                if (IsHandleCreated)
                {
                    var num = WindowsAPI.SendMessage(Handle, 1026, System.IntPtr.Zero, System.IntPtr.Zero);
                    var num2 = num;
                    var keys = (System.Windows.Forms.Keys)(num2 & 255);
                    num2 >>= 8;
                    if ((num2 & 4) != 0)
                    {
                        keys |= System.Windows.Forms.Keys.Alt;
                    }
                    if ((num2 & 2) != 0)
                    {
                        keys |= System.Windows.Forms.Keys.Control;
                    }
                    if ((num2 & 1) != 0)
                    {
                        keys |= System.Windows.Forms.Keys.Shift;
                    }
                    return keys;
                }
                return m_hotkey;
            }
            set
            {
                if (IsHandleCreated)
                {
                    var num = 0;
                    if ((value & System.Windows.Forms.Keys.Alt) != System.Windows.Forms.Keys.None)
                    {
                        num |= 4;
                    }
                    if ((value & System.Windows.Forms.Keys.Control) != System.Windows.Forms.Keys.None)
                    {
                        num |= 2;
                    }
                    if ((value & System.Windows.Forms.Keys.Shift) != System.Windows.Forms.Keys.None)
                    {
                        num |= 1;
                    }
                    WindowsAPI.SendMessage(Handle, 1025, (System.IntPtr)(num << 8 | (int)(value & System.Windows.Forms.Keys.KeyCode)), System.IntPtr.Zero);
                    return;
                }
                m_hotkey = value;
            }
        }
    }
}
