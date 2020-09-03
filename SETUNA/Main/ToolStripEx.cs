using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Opulos.Core.UI
{
    //https://stackoverflow.com/questions/29083903/contextmenustrip-scroll-up-or-down-button
    ///<summary>Extension class to increase the size of the scroll up-down arrows on a drop down context menu or tool strip menu. The default up-down arrows are only 5 pixels high.</summary>
    public static class ToolStripEx
    {
        public delegate void Action();
        private static Hashtable htData = new Hashtable();

        private class Data
        {
            public bool needsUpdate = true;
            public bool disposeLastImage = false;
            public ToolStrip toolStrip = null;
            public List<Image> currentImages = new List<Image>();
        }

        public static void BigButtons(ToolStrip toolStrip)
        {
            htData[toolStrip] = new Data() { toolStrip = toolStrip };
            toolStrip.VisibleChanged += toolStrip_VisibleChanged;
            toolStrip.ForeColorChanged += toolStrip_ForeColorChanged;
            toolStrip.Disposed += toolStrip_Disposed;
        }

        static void toolStrip_Disposed(object sender, EventArgs e)
        {
            Data d = (Data)htData[sender];
            if (d != null && d.currentImages != null)
            {
                foreach (var img in d.currentImages)
                    img.Dispose();
                d.currentImages = null;
                htData.Remove(sender);
            }
        }

        static void toolStrip_ForeColorChanged(object sender, EventArgs e)
        {
            Data d = (Data)htData[sender];
            d.needsUpdate = true;
            UpdateImages(d);
        }

        static void toolStrip_VisibleChanged(object sender, EventArgs e)
        {
            Data d = (Data)htData[sender];
            UpdateImages(d);
        }

        private static void UpdateImages(Data d)
        {
            if (!d.needsUpdate)
                return;

            Action a = () =>
            {
                try
                {
                    var list = GetChildWindows(d.toolStrip.Handle);
                    if (list.Count == 0)
                        return;

                    List<Image> newImages = new List<Image>();
                    int k = 0;

                    foreach (var i in list)
                    {
                        var c = Control.FromHandle(i) as Label;
                        if (c != null && d.needsUpdate)
                        {
                            String glyph = (k == 0 ? "t" : "u");
                            using (Font f = new System.Drawing.Font("Marlett", 20f))
                            {
                                Size s = TextRenderer.MeasureText("t", f);
                                var oldImage = c.Image;
                                c.Image = new Bitmap(s.Width, s.Height);
                                newImages.Add(c.Image);
                                // avoid disposing the default image
                                // might cause problems, not sure
                                if (d.disposeLastImage)
                                    oldImage.Dispose();
                                using (Graphics g = Graphics.FromImage(c.Image))
                                {
                                    using (Brush b = new SolidBrush(d.toolStrip.ForeColor))
                                        g.DrawString(glyph, f, b, 0, 0);
                                }
                                c.AutoSize = true;
                            }
                            k++;
                        }
                    }
                    if (newImages.Count > 0)
                    {
                        d.needsUpdate = false;
                        d.disposeLastImage = true;
                        d.currentImages = newImages;
                    }
                }
                catch { } // protect against crash (just in case)
            };

            d.toolStrip.BeginInvoke(a);
        }

        private static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumChildWindows(parent, enumProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        private delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);
        private static EnumChildProc enumProc = new EnumChildProc(CallChildEnumProc);
        private static bool CallChildEnumProc(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gch = GCHandle.FromIntPtr(lParam);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");

            list.Add(hWnd);
            return true;
        }

        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);
    }
}