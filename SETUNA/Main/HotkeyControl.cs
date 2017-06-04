namespace SETUNA.Main
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class HotkeyControl : UserControl
    {
        private Container components = new Container();
        private Keys m_hotkey;

        public HotkeyControl()
        {
            base.SetStyle(ControlStyles.UserPaint, false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.BorderStyle = BorderStyle.Fixed3D;
            base.Name = "HotkeyControl";
            base.Size = new Size(0x92, 0x92);
            base.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Hotkey = this.m_hotkey;
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ClassName = "msctls_hotkey32";
                return createParams;
            }
        }

        public Keys Hotkey
        {
            get
            {
                if (!base.IsHandleCreated)
                {
                    return this.m_hotkey;
                }
                int num2 = WinApi.SendMessage(base.Handle, 0x402, IntPtr.Zero, IntPtr.Zero);
                Keys keys = ((Keys) num2) & (Keys.OemClear | Keys.LButton);
                num2 = num2 >> 8;
                if ((num2 & 4) != 0)
                {
                    keys |= Keys.Alt;
                }
                if ((num2 & 2) != 0)
                {
                    keys |= Keys.Control;
                }
                if ((num2 & 1) != 0)
                {
                    keys |= Keys.Shift;
                }
                return keys;
            }
            set
            {
                if (base.IsHandleCreated)
                {
                    int num = 0;
                    if ((value & Keys.Alt) != Keys.None)
                    {
                        num |= 4;
                    }
                    if ((value & Keys.Control) != Keys.None)
                    {
                        num |= 2;
                    }
                    if ((value & Keys.Shift) != Keys.None)
                    {
                        num |= 1;
                    }
                    WinApi.SendMessage(base.Handle, 0x401, (IntPtr) ((num << 8) | (int)(value & Keys.KeyCode)), IntPtr.Zero);
                }
                else
                {
                    this.m_hotkey = value;
                }
            }
        }

        private class WinApi
        {
            public const int HKCOMB_A = 8;
            public const int HKCOMB_C = 4;
            public const int HKCOMB_CA = 0x40;
            public const int HKCOMB_NONE = 1;
            public const int HKCOMB_S = 2;
            public const int HKCOMB_SA = 0x20;
            public const int HKCOMB_SC = 0x10;
            public const int HKCOMB_SCA = 0x80;
            public const int HKM_GETHOTKEY = 0x402;
            public const int HKM_SETHOTKEY = 0x401;
            public const int HKM_SETRULES = 0x403;
            public const int HOTKEYF_ALT = 4;
            public const int HOTKEYF_CONTROL = 2;
            public const int HOTKEYF_EXT = 8;
            public const int HOTKEYF_SHIFT = 1;

            static WinApi()
            {
                InitCommonControls();
            }

            [DllImport("comctl32.dll")]
            public static extern bool InitCommonControls();
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr h, int m, IntPtr w, IntPtr l);
        }
    }
}

