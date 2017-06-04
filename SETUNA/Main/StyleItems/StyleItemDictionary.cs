namespace SETUNA.Main.StyleItems
{
    using System;
    using System.Collections.Generic;

    public class StyleItemDictionary
    {
        protected StyleItemDictionary()
        {
        }

        public static CStyleItem[] GetAllStyleItems()
        {
            List<CStyleItem> list = new List<CStyleItem> {
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
            };
            return list.ToArray();
        }

        public static Type[] GetStyleType()
        {
            List<Type> list = new List<Type>();
            CStyleItem[] allStyleItems = GetAllStyleItems();
            for (int i = 0; i < allStyleItems.Length; i++)
            {
                list.Add(allStyleItems[i].GetType());
            }
            return list.ToArray();
        }
    }
}

