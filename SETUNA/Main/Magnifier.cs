using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace SETUNA.Main
{
    public partial class Magnifier : Form
    {
        const int scale = 4;


        public LocationType LocationType { set; get; } = LocationType.LeftTop;

        System.Timers.Timer timer;


        public Magnifier()
        {
            InitializeComponent();

            timer = new System.Timers.Timer
            {
                Enabled = false,
                Interval = 100
            };
            timer.Enabled = false;
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
        }

        public void SetLocation(LocationType location)
        {
            LocationType = location;
            var bounds = CaptureForm.TargetScreen.Bounds;

            switch (location)
            {
                case LocationType.LeftTop:
                    Location = new Point(bounds.X + 1, bounds.Y + 1); ;
                    break;
                case LocationType.RightBottom:
                    Location = new Point(bounds.X + bounds.Width - Width - 1, bounds.Y + bounds.Height - Height - 1);
                    break;
            }
        }

        public void SetText(int x, int y, int width, int height)
        {
            label1.Text = string.Format("X:{0}, Y:{1}, W:{2}, H:{3}", x, y, width, height);
        }

        void ChangeLocation()
        {
            if (LocationType == LocationType.LeftTop)
            {
                SetLocation(LocationType.RightBottom);
            }
            else
            {
                SetLocation(LocationType.LeftTop);
            }
        }

        void CheckPosition()
        {
            var cursorPos = Cursor.Position;
            var pictureWidth = pictureBox1.Width;
            var pictureHeight = pictureBox1.Height;
            var point = new Point(cursorPos.X - pictureWidth / 2, cursorPos.Y - pictureHeight / 2);

            var mouseRect = new Rectangle(point, new Size(pictureWidth, pictureHeight));
            var viewRect = new Rectangle(Location, Size);

            if (mouseRect.IntersectsWith(viewRect))
            {
                ChangeLocation();
            }
        }

        void RefreshImage()
        {
            var pictureWidth = pictureBox1.Width;
            var pictureHeight = pictureBox1.Height;

            var bt = new Bitmap(pictureWidth / scale, pictureHeight / scale);
            var g = Graphics.FromImage(bt);
            g.CopyFromScreen(
                new Point(Cursor.Position.X - bt.Width / 2, Cursor.Position.Y - bt.Height / 2),
                new Point(0, 0),
                bt.Size);
            var dc1 = g.GetHdc();
            g.ReleaseHdc(dc1);
            pictureBox1.Image = bt.ScaleToSize(pictureWidth, pictureHeight);
        }

        private void Magnifier_VisibleChanged(object sender, EventArgs e)
        {
            timer.Enabled = Visible;

            if (Visible)
            {
                TopMost = true;
                SetLocation(LocationType);
            }
        }

        private void timer_Tick(object sender, ElapsedEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke(new Action(CheckPosition));
                Invoke(new Action(RefreshImage));
            }
        }
    }


    public enum LocationType
    {
        LeftTop,
        RightBottom,
    }
}
