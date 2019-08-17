using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SETUNA.Main.Other
{
    class DPIUtils
    {
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        const int LOGPIXELSX = 88;
        const int LOGPIXELSY = 90;
        const int DESKTOPVERTRES = 117;
        const int DESKTOPHORZRES = 118;

        public static float defaultDpi1 { private set; get; }
        public static float defaultDpi2 { private set; get; }
        public static float defaultDpi3 { private set; get; }
        public static float defaultDpi4 { private set; get; }

        static public float GetPrimaryDpi()
        {
            return GetDpiByIndex(0);
        }

        static public float GetDpiByIndex(int pIndex)
        {
            switch (pIndex)
            {
                case 0:
                    return Mainform.instance.optSetuna.dpi1;
                case 1:
                    return Mainform.instance.optSetuna.dpi2;
                case 2:
                    return Mainform.instance.optSetuna.dpi3;
                case 3:
                    return Mainform.instance.optSetuna.dpi4;
                default:
                    return 1.0F;
            }
        }

        static public float GetDpiByScreen(Screen pScreen)
        {
            if (!pScreen.Primary)
            {
                for (int i = 0; i < Screen.AllScreens.Length; i++)
                {
                    var tScreen = Screen.AllScreens[i];
                    if (tScreen.DeviceName == pScreen.DeviceName)
                    {
                        return DPIUtils.GetDpiByIndex(i);
                    }
                }
            }
            return GetPrimaryDpi();
        }

        static public void Init()
        {
            var tPrimary = GetDC(IntPtr.Zero);
            defaultDpi1 = GetDeviceCaps(tPrimary, LOGPIXELSX) / 96F;
            defaultDpi2 = defaultDpi3 = defaultDpi4 = 1.0F;
        }
    }
}
