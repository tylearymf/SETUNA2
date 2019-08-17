using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SETUNA.Main.Other
{
    class WindowsAPI
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static public extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static public extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static public extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static public extern int GetWindowTextLength(IntPtr hWnd);

        static public bool GetWindowZOrder(IntPtr hwnd, out int zOrder)
        {
            const uint GW_HWNDPREV = 3;
            const uint GW_HWNDLAST = 1;

            var lowestHwnd = GetWindow(hwnd, GW_HWNDLAST);

            var z = 0;
            var hwndTmp = lowestHwnd;
            while (hwndTmp != IntPtr.Zero)
            {
                if (hwnd == hwndTmp)
                {
                    zOrder = z;
                    return true;
                }

                hwndTmp = GetWindow(hwndTmp, GW_HWNDPREV);
                z++;
            }

            zOrder = int.MinValue;
            return false;
        }

        static public string GetWindowTItle(IntPtr hwnd)
        {

            int length = GetWindowTextLength(hwnd);
            if (length == 0) return string.Empty;

            var builder = new StringBuilder(length);
            GetWindowText(hwnd, builder, length + 1);

            return builder.ToString();

        }
    }
}
