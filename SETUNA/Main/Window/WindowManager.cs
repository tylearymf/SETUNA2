
using System;
using System.Drawing;

namespace SETUNA.Main
{
    internal class WindowManager
    {
        public delegate void WindowHandler(object sender, WindowInfo windowInfo);

        public static event WindowHandler WindowActived;
        public static event WindowHandler TopMostChanged;


        public static readonly WindowManager Instance = new WindowManager();

        public WindowInfo CurrentForegroundWindow => foregroundWindow;
        public WindowInfo TopMostWindow => topMostWindow;

        WindowInfo foregroundWindow;
        WindowInfo topMostWindow;


        public void Update()
        {
            var hwnd = WindowsAPI.GetForegroundWindow();
            if (foregroundWindow.Handle != hwnd)
            {
                var windowInfo = GetWindowInfo(hwnd);
                foregroundWindow = windowInfo;
            }

            hwnd = WindowsAPI.GetTopMostWindow(IntPtr.Zero);
            if (topMostWindow.Handle != hwnd)
            {
                var windowInfo = GetWindowInfo(hwnd);
                topMostWindow = windowInfo;
            }

            WindowActived?.Invoke(this, foregroundWindow);
            TopMostChanged?.Invoke(this, topMostWindow);
        }

        public WindowInfo GetWindowInfo(IntPtr hwnd)
        {
            var titleName = WindowsAPI.GetWindowTitle(hwnd);
            var className = WindowsAPI.GetClassName(hwnd);
            WindowsAPI.GetWindowZOrder(hwnd, out var zOrder);

            var rect = new Rect();
            WindowsAPI.GetWindowRect(hwnd, ref rect);

            return new WindowInfo()
            {
                Handle = hwnd,
                TitleName = titleName,
                ClassName = className,
                Rect = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top),
                ZOrder = zOrder,
            };
        }
    }

    public struct WindowInfo
    {
        public static WindowInfo Empty { get; internal set; }


        public IntPtr Handle { set; get; }
        public string TitleName { set; get; }
        public string ClassName { set; get; }
        public int ZOrder { set; get; }
        public Rectangle Rect { set; get; }


        public override string ToString()
        {
            return string.Format(
                $"{nameof(Handle)}:{Handle}," +
                $"{nameof(TitleName)}:{TitleName}," +
                $"{nameof(ClassName)}:{ClassName}," +
                $"{nameof(Rect)}:(X:{Rect.X},Y:{Rect.Y},W:{Rect.Width},H:{Rect.Height})," +
                $"{nameof(ZOrder)}:{ZOrder}");
        }

        public override int GetHashCode()
        {
            return ~(int)Handle;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(WindowInfo lhs, WindowInfo rhs)
        {
            return lhs.Handle == rhs.Handle;
        }
        public static bool operator !=(WindowInfo lhs, WindowInfo rhs)
        {
            return lhs.Handle != rhs.Handle;
        }
    }
}
