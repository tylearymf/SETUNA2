using SETUNA.Main.Option;
using SETUNA.Main.StyleItems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SETUNA.Main.Other
{
    public class LayerInfo : IDisposable
    {
        public LayerInfo(Form pForm)
        {
            mForm = pForm;
            target = pForm;
            handle = pForm.Handle;

            LayerManager.instance.AddInfo(this);
            Update();
        }

        Form mForm;

        public object target { private set; get; }
        public IntPtr handle { private set; get; }
        public int clickCount { private set; get; }

        public void Update()
        {
            clickCount = ++LayerManager.instance.clickCount;
            mForm.TopMost = true;
            LayerManager.instance.Update();
        }

        public void Dispose()
        {
            LayerManager.instance.RemoveInfo(this);
        }
    }

    public class LayerManager
    {
        static readonly LayerManager sInstance = new LayerManager();
        static public LayerManager instance => sInstance;

        List<LayerInfo> mFormList = new List<LayerInfo>();
        public int clickCount { set; get; }
        static List<string> mIgnoreClassNames = new List<string>()
        {
            //QQ
            "TXGuiFoundation",
            //有度
            "ScreenShotWnd",
            //微信
            "SnapshotWnd",
            "CToolBarWnd",
        };

        public void AddInfo(LayerInfo pInfo)
        {
            mFormList.Add(pInfo);
        }

        public void RemoveInfo(LayerInfo pInfo)
        {
            mFormList.Remove(pInfo);
        }

        public void Update()
        {
            var tTopHandler = WindowsAPI.GetForegroundWindow();
            var tTopTitle = WindowsAPI.GetWindowTitle(tTopHandler);
            var tTopModuleName = WindowsAPI.GetModuleName(tTopHandler);
            var tTopClassName = WindowsAPI.GetClassName(tTopHandler);

            //不处理无标题
            if (string.IsNullOrEmpty(tTopTitle)) return;

            //当前正在截图
            if (!string.IsNullOrEmpty(tTopTitle) && tTopTitle == typeof(CaptureForm).Name) return;
            //当前正在保存
            if (!string.IsNullOrEmpty(tTopTitle) && tTopTitle == CImageStyleItem.SaveImageTitle) return;

            //过滤其他截图工具
            if (!string.IsNullOrEmpty(tTopClassName) && mIgnoreClassNames.Contains(tTopClassName))
            {
                return;
            }

            mFormList.Sort((x, y) =>
            {
                return x.clickCount.CompareTo(y.clickCount);
            });

            var tTopOrder = 0;
            WindowsAPI.GetWindowZOrder(tTopHandler, out tTopOrder);

            //先判断当前窗口是否是截图窗口
            var tIsTop = false;
            foreach (var item in this.mFormList)
            {
                if (item.handle == tTopHandler)
                {
                    tIsTop = true;
                    break;
                }
            }
            if (tIsTop) return;

            //再判断顶部窗口的层级跟截图窗口的层级
            tIsTop = false;
            var tOrderList = new List<string>();
            foreach (var item in this.mFormList)
            {
                var tOrder = 0;
                WindowsAPI.GetWindowZOrder(item.handle, out tOrder);

                tOrderList.Add(tOrder.ToString());
                if (tOrder >= tTopOrder)
                {
                    tIsTop = true;
                    break;
                }
            }
            if (tIsTop) return;

            MyConsole.WriteLine("UpdateLayer TopTitle:{0} TopOrder:{1} OrderList:{2} ModuleName:{3} ClassName:{4}",
                              tTopTitle, tTopOrder, string.Join(",", tOrderList.ToArray()), tTopModuleName, tTopClassName);

            //刷新层级
            for (int i = 0, imax = mFormList.Count; i < imax; i++)
            {
                var tTarget = mFormList[i].target;
                var tType = tTarget.GetType();

                if (tTarget is Form)
                {
                    Form tForm = tTarget as Form;
                    tForm.TopMost = true;
                }
                else
                {
                    Console.WriteLine("未实现" + tType.FullName);
                }
            }

        }
    }
}
