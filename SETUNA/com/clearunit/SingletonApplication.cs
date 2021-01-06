using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Windows.Forms;

namespace com.clearunit
{
    // Token: 0x02000087 RID: 135
    public class SingletonApplication
    {
        // Token: 0x0600046C RID: 1132 RVA: 0x0001CABC File Offset: 0x0001ACBC
        private SingletonApplication()
        {
        }

        // Token: 0x0600046D RID: 1133 RVA: 0x0001CAC4 File Offset: 0x0001ACC4
        public static SingletonApplication GetInstance(string version, string[] args)
        {
            if (SingletonApplication._instance == null)
            {
                lock (SingletonApplication.lockObj)
                {
                    if (SingletonApplication._instance == null)
                    {
                        SingletonApplication._instance = new SingletonApplication();
                    }
                }
            }
            SingletonApplication._instance._args = args;
            SingletonApplication._instance._version = version;
            return SingletonApplication._instance;
        }

        // Token: 0x0600046E RID: 1134 RVA: 0x0001CB38 File Offset: 0x0001AD38
        public void AddSingletonFormListener(ISingletonForm implement)
        {
            SingletonAppRemoteObject.Event = (SingletonAppRemoteObject.StartupDelegate)Delegate.Combine(SingletonAppRemoteObject.Event, new SingletonAppRemoteObject.StartupDelegate(implement.DetectExternalStartup));
        }

        // Token: 0x0600046F RID: 1135 RVA: 0x0001CB5B File Offset: 0x0001AD5B
        public bool Register()
        {
            if (CreateServer())
            {
                return true;
            }
            CreateClient();
            return false;
        }

        // Token: 0x06000470 RID: 1136 RVA: 0x0001CB70 File Offset: 0x0001AD70
        private bool CreateServer()
        {
            bool result;
            try
            {
                var productName = Application.ProductName;
                var chnl = new IpcChannel(productName);
                ChannelServices.RegisterChannel(chnl, true);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(SingletonAppRemoteObject), productName + "RemoteObject.rem", WellKnownObjectMode.Singleton);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        // Token: 0x06000471 RID: 1137 RVA: 0x0001CBC8 File Offset: 0x0001ADC8
        private void CreateClient()
        {
            try
            {
                var productName = Application.ProductName;
                var ipcChannel = new IpcChannel();
                ChannelServices.RegisterChannel(ipcChannel, true);
                var text = string.Concat(new string[]
                {
                    ipcChannel.ChannelName,
                    "://",
                    productName,
                    "/",
                    productName,
                    "RemoteObject.rem"
                });
                var entry = new WellKnownClientTypeEntry(typeof(SingletonAppRemoteObject), text);
                RemotingConfiguration.RegisterWellKnownClientType(entry);
                ipcChannel.CreateMessageSink(text, null, out var text2);
                var singletonAppRemoteObject = new SingletonAppRemoteObject();
                singletonAppRemoteObject.Startup(_version, _args);
            }
            catch
            {
                Console.WriteLine("CreateClient Error");
            }
        }

        // Token: 0x040002AF RID: 687
        private static volatile SingletonApplication _instance = null;

        // Token: 0x040002B0 RID: 688
        private static object lockObj = new object();

        // Token: 0x040002B1 RID: 689
        private string[] _args;

        // Token: 0x040002B2 RID: 690
        private string _version;
    }
}
