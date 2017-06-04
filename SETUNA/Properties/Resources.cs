namespace SETUNA.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        internal static Bitmap ArrowDown =>
            ((Bitmap) ResourceManager.GetObject("ArrowDown", resourceCulture));

        internal static Bitmap ArrowUp =>
            ((Bitmap) ResourceManager.GetObject("ArrowUp", resourceCulture));

        internal static Bitmap Close =>
            ((Bitmap) ResourceManager.GetObject("Close", resourceCulture));

        internal static string ConfigFile =>
            ResourceManager.GetString("ConfigFile", resourceCulture);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get{return  
                resourceCulture;}
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap icon =>
            ((Bitmap) ResourceManager.GetObject("icon", resourceCulture));

        internal static Bitmap Icon_Bmp =>
            ((Bitmap) ResourceManager.GetObject("Icon_Bmp", resourceCulture));

        internal static Bitmap Icon_Close =>
            ((Bitmap) ResourceManager.GetObject("Icon_Close", resourceCulture));

        internal static Bitmap Icon_Compact =>
            ((Bitmap) ResourceManager.GetObject("Icon_Compact", resourceCulture));

        internal static Bitmap Icon_Copy =>
            ((Bitmap) ResourceManager.GetObject("Icon_Copy", resourceCulture));

        internal static Bitmap Icon_Frame =>
            ((Bitmap) ResourceManager.GetObject("Icon_Frame", resourceCulture));

        internal static Bitmap Icon_Jpeg =>
            ((Bitmap) ResourceManager.GetObject("Icon_Jpeg", resourceCulture));

        internal static Bitmap Icon_Move =>
            ((Bitmap) ResourceManager.GetObject("Icon_Move", resourceCulture));

        internal static Bitmap Icon_Opacoty =>
            ((Bitmap) ResourceManager.GetObject("Icon_Opacoty", resourceCulture));

        internal static Bitmap Icon_Paste =>
            ((Bitmap) ResourceManager.GetObject("Icon_Paste", resourceCulture));

        internal static Bitmap Icon_Picasa =>
            ((Bitmap) ResourceManager.GetObject("Icon_Picasa", resourceCulture));

        internal static Bitmap Icon_Png =>
            ((Bitmap) ResourceManager.GetObject("Icon_Png", resourceCulture));

        internal static Bitmap Icon_Rotate =>
            ((Bitmap) ResourceManager.GetObject("Icon_Rotate", resourceCulture));

        internal static Bitmap Icon_Scale =>
            ((Bitmap) ResourceManager.GetObject("Icon_Scale", resourceCulture));

        internal static Bitmap Icon_Trim =>
            ((Bitmap) ResourceManager.GetObject("Icon_Trim", resourceCulture));

        internal static Bitmap Logo =>
            ((Bitmap) ResourceManager.GetObject("Logo", resourceCulture));

        internal static Bitmap OptionBG =>
            ((Bitmap) ResourceManager.GetObject("OptionBG", resourceCulture));

        internal static Bitmap pi_erase =>
            ((Bitmap) ResourceManager.GetObject("pi_erase", resourceCulture));

        internal static Bitmap pi_pen =>
            ((Bitmap) ResourceManager.GetObject("pi_pen", resourceCulture));

        internal static Bitmap pi_text =>
            ((Bitmap) ResourceManager.GetObject("pi_text", resourceCulture));

        internal static Bitmap PicasaLogo =>
            ((Bitmap) ResourceManager.GetObject("PicasaLogo", resourceCulture));

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("SETUNA.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }
    }
}

