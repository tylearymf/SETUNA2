using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SETUNA.Main.Startup
{
    internal static class AutoStartup
    {
        private static string Key = "SETUNA_AutoStartup";

        public static bool Set(bool enabled)
        {
            var registryKey = GetRegistryKey();

            try
            {
                if (enabled)
                {
                    registryKey.SetValue(Key, Application.ExecutablePath.ToString());
                }
                else
                {
                    var value = registryKey.GetValue(Key, null);
                    if (value != null)
                    {
                        registryKey.DeleteValue(Key);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }
        }

        public static bool IsSetup()
        {
            var registryKey = GetRegistryKey();

            try
            {
                var valueNames = registryKey.GetValueNames();
                foreach (var item in valueNames)
                {
                    if (item.Equals(Key, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }
        }

        public static RegistryKey GetRegistryKey()
        {
            return Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
        }
    }
}
