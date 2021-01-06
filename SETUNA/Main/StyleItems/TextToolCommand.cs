using System.Drawing;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x0200009F RID: 159
    public class TextToolCommand : ToolCommand
    {
        // Token: 0x170000B8 RID: 184
        // (get) Token: 0x06000533 RID: 1331 RVA: 0x00024626 File Offset: 0x00022826
        // (set) Token: 0x06000532 RID: 1330 RVA: 0x0002461D File Offset: 0x0002281D
        public string Text
        {
            get => _text;
            set => _text = value;
        }

        // Token: 0x170000B9 RID: 185
        // (get) Token: 0x06000534 RID: 1332 RVA: 0x0002462E File Offset: 0x0002282E
        // (set) Token: 0x06000535 RID: 1333 RVA: 0x00024636 File Offset: 0x00022836
        public Font Font
        {
            get => _font;
            set => _font = value;
        }

        // Token: 0x06000536 RID: 1334 RVA: 0x0002463F File Offset: 0x0002283F
        public TextToolCommand(string text, Font font, int x, int y)
        {
            _text = text;
            _font = font;
            _location = new Point(x, y);
        }

        // Token: 0x06000537 RID: 1335 RVA: 0x00024663 File Offset: 0x00022863
        public TextToolCommand(string text, Font font, Point location) : this(text, font, location.X, location.Y)
        {
        }

        // Token: 0x06000538 RID: 1336 RVA: 0x0002467B File Offset: 0x0002287B
        public override void Draw(Graphics g)
        {
            g.DrawString(_text, _font, Brushes.SkyBlue, _location);
        }

        // Token: 0x0400034C RID: 844
        private string _text;

        // Token: 0x0400034D RID: 845
        private Font _font;

        // Token: 0x0400034E RID: 846
        private Point _location;
    }
}
