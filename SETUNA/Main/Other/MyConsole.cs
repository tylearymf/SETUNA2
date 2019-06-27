using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SETUNA.Main.Other
{
    class MyConsole
    {
        [Conditional("DEBUG")]
        static public void WriteLine(string pMsg, params object[] pArgs)
        {
            var tMsg = string.Format(pMsg, pArgs);
            Console.WriteLine(string.Format("{0}\n{1}", tMsg, Environment.StackTrace));
        }
    }
}
