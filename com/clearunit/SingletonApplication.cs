namespace com.clearunit
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Ipc;
    using System.Windows.Forms;

    public class SingletonApplication
    {
        private string[] _args;
        private static volatile SingletonApplication _instance = null;
        private string _version;
        private static object lockObj = new object();

        private SingletonApplication()
        {
        }

        public void AddSingletonFormListener(ISingletonForm implement)
        {
            SingletonAppRemoteObject.Event = (SingletonAppRemoteObject.StartupDelegate) Delegate.Combine(SingletonAppRemoteObject.Event, new SingletonAppRemoteObject.StartupDelegate(implement.DetectExternalStartup));
        }

        private void CreateClient()
        {
            try
            {
                string str3;
                string productName = Application.ProductName;
                IpcChannel chnl = new IpcChannel();
                ChannelServices.RegisterChannel(chnl, true);
                string objectUrl = chnl.ChannelName + "://" + productName + "/" + productName + "RemoteObject.rem";
                WellKnownClientTypeEntry entry = new WellKnownClientTypeEntry(typeof(SingletonAppRemoteObject), objectUrl);
                RemotingConfiguration.RegisterWellKnownClientType(entry);
                chnl.CreateMessageSink(objectUrl, null, out str3);
                new SingletonAppRemoteObject().Startup(this._version, this._args);
            }
            catch
            {
                Console.WriteLine("CreateClient Error");
            }
        }

        private bool CreateServer()
        {
            try
            {
                string productName = Application.ProductName;
                IpcChannel chnl = new IpcChannel(productName);
                ChannelServices.RegisterChannel(chnl, true);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(SingletonAppRemoteObject), productName + "RemoteObject.rem", WellKnownObjectMode.Singleton);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static SingletonApplication GetInstance(string version, string[] args)
        {
            if (_instance == null)
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonApplication();
                    }
                }
            }
            _instance._args = args;
            _instance._version = version;
            return _instance;
        }

        public bool Register()
        {
            if (this.CreateServer())
            {
                return true;
            }
            this.CreateClient();
            return false;
        }
    }
}

