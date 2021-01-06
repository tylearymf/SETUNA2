using System.Collections.Generic;

namespace SETUNA.Main.Style
{
    // Token: 0x02000053 RID: 83
    public abstract class CPreStyles
    {
        // Token: 0x0600030D RID: 781 RVA: 0x00015104 File Offset: 0x00013304
        public static List<CStyle> GetPreStyleList()
        {
            return new List<CStyle>
            {
                new CCloseStyle(),
                new CSeparatorStyle(),
                new CShowVersionStyle(),
                new CScrapListStyle(),
                new CDustBoxStyle(),
                new CDustEraseStyle(),
                new CCaptureStyle(),
                new COptionStyle(),
                new CShutDownStyle()
            };
        }

        // Token: 0x0600030E RID: 782 RVA: 0x0001517C File Offset: 0x0001337C
        public static CStyle GetPreStyle(int style_id)
        {
            var preStyleList = CPreStyles.GetPreStyleList();
            foreach (var cstyle in preStyleList)
            {
                if (cstyle.StyleID == style_id)
                {
                    return cstyle;
                }
            }
            return null;
        }
    }
}
