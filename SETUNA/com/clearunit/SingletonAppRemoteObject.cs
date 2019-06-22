namespace com.clearunit
{
    using System;
    using System.Runtime.CompilerServices;

    internal class SingletonAppRemoteObject : MarshalByRefObject
    {
        public static StartupDelegate Event;

        public void Startup(string version, string[] args)
        {
            if (Event != null)
            {
                Event(version, args);
            }
        }

        public delegate void StartupDelegate(string version, string[] args);
    }
}

