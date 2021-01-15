namespace SETUNA.Main.Layer
{
    class WindowsFilter : IWindowFilter
    {
        struct FilterInfo
        {
            public string TitleName { set; get; }
            public string ClassName { set; get; }


            public FilterInfo(string className)
            {
                TitleName = null;
                ClassName = className;
            }

            public FilterInfo(string titleName, string className)
            {
                TitleName = titleName;
                ClassName = className;
            }
        }

        static FilterInfo[] filterInfos = new FilterInfo[]
        {
            // QQ
            new FilterInfo(string.Empty, "TXGuiFoundation"),
            // QQ右键菜单
            new FilterInfo("TXMenuWindow","TXGuiFoundation"),
            // 有度
            new FilterInfo("ScreenShotWnd"),
            // 微信
            new FilterInfo("SnapshotWnd"),
            new FilterInfo("CToolBarWnd"),
        };

        bool IWindowFilter.IsFilter(WindowInfo windowInfo)
        {
            var titleName = windowInfo.TitleName;
            var className = windowInfo.ClassName;

            foreach (var item in filterInfos)
            {
                bool? flag1 = null;
                if (item.TitleName != null)
                {
                    flag1 = item.TitleName == titleName;
                }

                bool? flag2 = null;
                if (item.ClassName != null)
                {
                    flag2 = item.ClassName == className;
                }

                if (flag1.HasValue && flag2.HasValue)
                {
                    if (flag1.Value && flag2.Value)
                    {
                        return true;
                    }
                }

                var result = flag1.HasValue ? flag1.Value : flag2.HasValue ? flag2.Value : false;
                if (result)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
