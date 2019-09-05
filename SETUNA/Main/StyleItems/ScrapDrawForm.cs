namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using SETUNA.Main.Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ScrapDrawForm : Form
    {
        protected Image _baseimg;
        private Point _basepoint;
        protected ScrapBase _scrap;
        private const int CAPTUREBLT = 0x40000000;
        private IContainer components;
        protected const int Space = 50;
        private const int SRCCOPY = 0xcc0020;
        private LayerInfo mLayerInfo;

        private ScrapDrawForm()
        {
            this.InitializeComponent();
        }

        public ScrapDrawForm(ScrapBase scrap)
        {
            float num4;
            float num6;
            float num8;
            this.InitializeComponent();
            this._scrap = scrap;
            this._basepoint = new Point(50, 50);
            Point p = new Point(scrap.ClientRectangle.X + (scrap.ClientSize.Width / 2), scrap.ClientRectangle.Y + (scrap.ClientSize.Height / 2));
            p = scrap.PointToScreen(p);
            this._baseimg = new Bitmap(scrap.Image.Width + 100, scrap.Image.Height + 100, PixelFormat.Format24bppRgb);
            this.CopyFromScreen(this._baseimg, new Point((p.X - (scrap.Image.Width / 2)) - 50, (p.Y - (scrap.Image.Height / 2)) - 50));
            ColorMatrix newColorMatrix = new ColorMatrix();
            float num = 0.298912f;
            float num2 = 0.586611f;
            float num3 = 0.114478f;
            newColorMatrix[0, 2] = num4 = num * 0.5f;
            newColorMatrix[0, 0] = newColorMatrix[0, 1] = num4;
            newColorMatrix[1, 2] = num6 = num2 * 0.5f;
            newColorMatrix[1, 0] = newColorMatrix[1, 1] = num6;
            newColorMatrix[2, 2] = num8 = num3 * 0.5f;
            newColorMatrix[2, 0] = newColorMatrix[2, 1] = num8;
            newColorMatrix[3, 3] = newColorMatrix[4, 4] = 1f;
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(newColorMatrix);
            using (Graphics graphics = Graphics.FromImage(this._baseimg))
            {
                Point point2 = new Point(scrap.ClientRectangle.Left, scrap.ClientRectangle.Top);
                point2 = scrap.PointToScreen(point2);
                graphics.DrawImageUnscaled(scrap.Image, 50, 50);
                graphics.DrawImage(this._baseimg, new Rectangle(0, 0, this._baseimg.Width, this._baseimg.Height), 0, 0, this._baseimg.Width, this._baseimg.Height, GraphicsUnit.Pixel, imageAttr);
            }
            base.Width = this._baseimg.Width;
            base.Height = this._baseimg.Height;
            base.Left = p.X - (base.Width / 2);
            base.Top = p.Y - (base.Height / 2);
            this._scrap.Hide();
        }

        protected override void OnLoad(EventArgs e)
        {
            mLayerInfo = new LayerInfo(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            mLayerInfo.Dispose();
        }

        [DllImport("gdi32.dll")]
        private static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        public bool CopyFromScreen(Image img, Point location)
        {
            bool flag = true;
            IntPtr zero = IntPtr.Zero;
            try
            {
                zero = GetDC(IntPtr.Zero);
                using (Graphics graphics = Graphics.FromImage(img))
                {
                    IntPtr hDestDC = IntPtr.Zero;
                    try
                    {
                        try
                        {
                            hDestDC = graphics.GetHdc();
                            BitBlt(hDestDC, 0, 0, img.Width, img.Height, zero, location.X, location.Y, 0x40cc0020);
                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }
                        return flag;
                    }
                    finally
                    {
                        if (hDestDC != IntPtr.Zero)
                        {
                            graphics.ReleaseHdc(hDestDC);
                        }
                    }
                    return flag;
                }
            }
            catch (Exception exception2)
            {
                Console.WriteLine(exception2.Message);
                flag = false;
            }
            finally
            {
                if (zero != IntPtr.Zero)
                {
                    DeleteDC(zero);
                }
            }
            return flag;
        }

        [DllImport("Gdi32.dll")]
        private static extern bool DeleteDC(IntPtr handle);
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            if (this._baseimg != null)
            {
                this._baseimg.Dispose();
                this._baseimg = null;
            }
            base.Dispose(disposing);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);
        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x124, 0x10a);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "ScrapDrawForm";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "TrimWindow";
            base.TopMost = true;
            base.ResumeLayout(false);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (this._scrap != null)
            {
                this._scrap.Show();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this._baseimg != null)
            {
                e.Graphics.DrawImageUnscaled(this._baseimg, 0, 0);
            }
        }

        protected Point BasePoint =>
            this._basepoint;
    }
}

