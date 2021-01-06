using System;

namespace SETUNA.Main
{
    internal static class DateTimeExtensions
    {
        public static string ToCustomString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH-mm-ss-ff");
        }
    }
}
