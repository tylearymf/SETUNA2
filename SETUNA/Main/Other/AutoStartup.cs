using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using SETUNA.Main.Other;

namespace SETUNA.Main.Other
{
    static class AutoStartup
    {
        static readonly string sPath = Assembly.GetEntryAssembly().Location;
        static string sKey = "SETUNA_AutoStartup";

        static public bool Set(bool pEnabled)
        {
            var tRegistryKey = GetRegistryKey();

            try
            {
                if (pEnabled)
                {
                    tRegistryKey.SetValue(sKey, Application.ExecutablePath.ToString());
                }
                else
                {
                    tRegistryKey.DeleteValue(sKey);
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
                if (tRegistryKey != null)
                {
                    tRegistryKey.Close();
                }
            }
        }

        static public bool Check()
        {
            var tRegistryKey = GetRegistryKey();

            try
            {
                var tValueNames = tRegistryKey.GetValueNames();
                foreach (var item in tValueNames)
                {
                    if (item.Equals(sKey, StringComparison.OrdinalIgnoreCase))
                        return true;
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
                if (tRegistryKey != null)
                {
                    tRegistryKey.Close();
                }
            }
        }

        static public RegistryKey GetRegistryKey()
        {
            return Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
        }
    }
}
