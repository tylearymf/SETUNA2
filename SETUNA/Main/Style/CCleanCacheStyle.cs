namespace SETUNA.Main.Style
{
    using SETUNA.Main;
    using System;

    public class CCleanCacheStyle : CPreStyle
    {
        public CCleanCacheStyle()
        {
            base._styleid = -12;
            base._stylename = "清空缓存图片";
        }

        public override void Apply(ref ScrapBase scrap)
        {
            CacheManager.CleanAll();
        }
    }
}

