using System.Drawing;

namespace SETUNA.Main
{
    // Token: 0x0200005C RID: 92
    public struct RGBColor
    {
        // Token: 0x06000334 RID: 820 RVA: 0x000155E5 File Offset: 0x000137E5
        public RGBColor(byte red, byte green, byte blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
        }

        // Token: 0x06000335 RID: 821 RVA: 0x000155FC File Offset: 0x000137FC
        public RGBColor(Color color)
        {
            _red = color.R;
            _green = color.G;
            _blue = color.B;
        }

        // Token: 0x1700007A RID: 122
        // (get) Token: 0x06000337 RID: 823 RVA: 0x0001562E File Offset: 0x0001382E
        // (set) Token: 0x06000336 RID: 822 RVA: 0x00015625 File Offset: 0x00013825
        public byte R
        {
            get => _red;
            set => _red = value;
        }

        // Token: 0x1700007B RID: 123
        // (get) Token: 0x06000339 RID: 825 RVA: 0x0001563F File Offset: 0x0001383F
        // (set) Token: 0x06000338 RID: 824 RVA: 0x00015636 File Offset: 0x00013836
        public byte G
        {
            get => _green;
            set => _green = value;
        }

        // Token: 0x1700007C RID: 124
        // (get) Token: 0x0600033B RID: 827 RVA: 0x00015650 File Offset: 0x00013850
        // (set) Token: 0x0600033A RID: 826 RVA: 0x00015647 File Offset: 0x00013847
        public byte B
        {
            get => _green;
            set => _green = value;
        }

        // Token: 0x0600033C RID: 828 RVA: 0x00015658 File Offset: 0x00013858
        public Color GetColor()
        {
            return Color.FromArgb(R, G, B);
        }

        // Token: 0x040001D6 RID: 470
        private byte _red;

        // Token: 0x040001D7 RID: 471
        private byte _green;

        // Token: 0x040001D8 RID: 472
        private byte _blue;
    }
}
