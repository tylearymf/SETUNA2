namespace com.clearunit
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class WithoutTabControl : TabControl
    {
        public WithoutTabControl()
        {
            base.Appearance = TabAppearance.Buttons;
            base.SizeMode = TabSizeMode.Fixed;
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            if (!base.DesignMode)
            {
                Size itemSize = base.ItemSize;
                itemSize.Width = 0;
                itemSize.Height = 1;
                base.ItemSize = itemSize;
            }
        }
    }
}

