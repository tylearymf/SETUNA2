using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SETUNA.Resources
{
    // Token: 0x02000006 RID: 6
    [CompilerGenerated]
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [DebuggerNonUserCode]
    internal class Image
    {
        // Token: 0x06000020 RID: 32 RVA: 0x000032FC File Offset: 0x000014FC
        internal Image()
        {
        }

        // Token: 0x17000003 RID: 3
        // (get) Token: 0x06000021 RID: 33 RVA: 0x00003304 File Offset: 0x00001504
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(Image.resourceMan, null))
                {
                    ResourceManager resourceManager = new ResourceManager("SETUNA.Resources.Image", typeof(Image).Assembly);
                    Image.resourceMan = resourceManager;
                }
                return Image.resourceMan;
            }
        }

        // Token: 0x17000004 RID: 4
        // (get) Token: 0x06000022 RID: 34 RVA: 0x00003343 File Offset: 0x00001543
        // (set) Token: 0x06000023 RID: 35 RVA: 0x0000334A File Offset: 0x0000154A
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return Image.resourceCulture;
            }
            set
            {
                Image.resourceCulture = value;
            }
        }

        // Token: 0x17000005 RID: 5
        // (get) Token: 0x06000024 RID: 36 RVA: 0x00003354 File Offset: 0x00001554
        internal static Bitmap Crypt
        {
            get
            {
                object @object = Image.ResourceManager.GetObject("Crypt", Image.resourceCulture);
                return (Bitmap)@object;
            }
        }

        // Token: 0x17000006 RID: 6
        // (get) Token: 0x06000025 RID: 37 RVA: 0x0000337C File Offset: 0x0000157C
        internal static Bitmap SampleImage
        {
            get
            {
                object @object = Image.ResourceManager.GetObject("SampleImage", Image.resourceCulture);
                return (Bitmap)@object;
            }
        }

        // Token: 0x0400001E RID: 30
        private static ResourceManager resourceMan;

        // Token: 0x0400001F RID: 31
        private static CultureInfo resourceCulture;
    }
}
