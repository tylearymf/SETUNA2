using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SETUNA.Main.Layer.Tests
{
    [TestClass()]
    public class LayerManagerTests
    {
        [TestMethod()]
        public void OptimizeLayerCounterTest()
        {
            var dic = new Dictionary<IntPtr, FormData>();
            var rangeCount = 1000000;
            var range = new Random().Next(0, rangeCount);
            for (var i = 0; i < range; i++)
            {
                dic.Add(new IntPtr(i), new FormData(null, new Random().Next(0, new Random().Next(new Random().Next(rangeCount)))));
            }
            if (dic.Count % 2 != 0)
            {
                dic.Add(new IntPtr(rangeCount), new FormData(null, rangeCount));
            }

            var maxSortingOrder = range;
            OptimizeLayerCounter(dic, out maxSortingOrder);

            var list = dic.Values.ToList();
            list.Sort((x, y) => x.SortingOrder.CompareTo(y.SortingOrder));
            for (var i = 0; i < list.Count; i += 2)
            {
                var cur = list[i];
                var next = list[i + 1];
                Assert.IsTrue(next.SortingOrder - cur.SortingOrder <= 1);
            }

            var last = list[list.Count - 1];
            Assert.IsTrue(last.SortingOrder == maxSortingOrder);
        }

        void OptimizeLayerCounter(Dictionary<IntPtr, FormData> formDic, out int maxSortingOrder)
        {
            var forms = new List<FormData>(formDic.Values);
            forms.Sort((x, y) => x.SortingOrder.CompareTo(y.SortingOrder));

            var noDuplicates = new List<FormData>(forms);
            for (var i = 0; i < noDuplicates.Count; i++)
            {
                var item = noDuplicates[i];
                var removeCount = noDuplicates.RemoveAll(x => x.SortingOrder == item.SortingOrder && x != item);
            }
            maxSortingOrder = noDuplicates.Count - 1;

            var sortingValueDic = new Dictionary<int, int>(noDuplicates.Count);
            for (var i = 0; i < noDuplicates.Count; i++)
            {
                sortingValueDic.Add(noDuplicates[i].SortingOrder, i);
            }

            foreach (var item in forms)
            {
                item.SortingOrder = sortingValueDic[item.SortingOrder];
            }
        }
    }

    class Compare : IEqualityComparer<FormData>
    {
        bool IEqualityComparer<FormData>.Equals(FormData x, FormData y)
        {
            return x.SortingOrder == y.SortingOrder;
        }

        int IEqualityComparer<FormData>.GetHashCode(FormData obj)
        {
            return obj.GetHashCode();
        }
    }
}