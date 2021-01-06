using System;
using System.Collections.Generic;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000068 RID: 104
    public class StyleItemDictionary
    {
        // Token: 0x0600039D RID: 925 RVA: 0x0001627C File Offset: 0x0001447C
        protected StyleItemDictionary()
        {
        }

        // Token: 0x0600039E RID: 926 RVA: 0x00016284 File Offset: 0x00014484
        public static CStyleItem[] GetAllStyleItems()
        {
            return new List<CStyleItem>
            {
                new CMoveStyleItem(),
                new CScaleStyleItem(),
                new CMarginStyleItem(),
                new COpacityStyleItem(),
                new CCloseStyleItem(),
                new CRotateStyleItem(),
                new CCopyStyleItem(),
                new CPasteStyleItem(),
                new CImageBmpStyleItem(),
                new CImageJpegStyleItem(),
                new CImagePngStyleItem(),
                new CCompactStyleItem(),
                new CTrimStyleItem(),
                new CPicasaUploaderStyleItem()
            }.ToArray();
        }

        // Token: 0x0600039F RID: 927 RVA: 0x00016338 File Offset: 0x00014538
        public static Type[] GetStyleType()
        {
            var list = new List<Type>();
            var allStyleItems = StyleItemDictionary.GetAllStyleItems();
            for (var i = 0; i < allStyleItems.Length; i++)
            {
                list.Add(allStyleItems[i].GetType());
            }
            return list.ToArray();
        }

        public static bool CanRestore(Type styleType)
        {
            if (!styleType?.IsSubclassOf(typeof(CStyleItem)) ?? false)
            {
                return false;
            }

            if (styleType == typeof(CScaleStyleItem))
            {
                return true;
            }

            if (styleType == typeof(CMarginStyleItem))
            {
                return true;
            }

            if (styleType == typeof(COpacityStyleItem))
            {
                return true;
            }

            if (styleType == typeof(CRotateStyleItem))
            {
                return true;
            }

            if (styleType == typeof(CCompactStyleItem))
            {
                return true;
            }

            return false;
        }
    }
}
