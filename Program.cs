
using com.clearunit;
using SETUNA;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        try
        {
            string[] strArray = RuntimeEnvironment.GetSystemVersion().Trim(new char[] { 'v' }).Split(new char[] { '.' });
            if (strArray.Length > 0)
            {
                int num;
                int.TryParse(strArray[0], out num);
                if (num < 2)
                {
                    MessageBox.Show("需安装 .NET Framework 2.0 或以上版本。");
                    return;
                }
            }
        }
        catch
        {
        }
        SingletonApplication instance = SingletonApplication.GetInstance(Application.ProductVersion, args);
        if (instance.Register())
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Mainform implement = Mainform.instance;
            instance.AddSingletonFormListener(implement);
            implement.CommandRun(args);
            Application.Run(implement);
        }
    }
}
