namespace SETUNA.Main.StyleItems
{
    using com.clearunit;
    using Properties;
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public class PicasaBar : Form
    {
        private bool _albumaccess;
        private string _albumcomment;
        private string _albumname;
        private string _error = "";
        private byte[] _id;
        private System.Drawing.Image _img;
        private byte[] _pass;
        private string _strID;
        private string _strPass;
        private BackgroundWorker backgroundWorker1;
        private IContainer components;
        private PictureBox pictureBox1;
        private ProgressBar progressBar1;

        public PicasaBar()
        {
            this.InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string filename = "";
            PicasaAccessor accessor = new PicasaAccessor();
            try
            {
                this.backgroundWorker1.ReportProgress(5);
                Console.WriteLine("创建一个临时文件");
                filename = Path.GetTempFileName();
                ImageCodecInfo imageCodecInfo = this.GetImageCodecInfo();
                System.Drawing.Imaging.Encoder quality = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters encoderParams = new EncoderParameters(1);
                EncoderParameter parameter = new EncoderParameter(quality, 100L);
                encoderParams.Param[0] = parameter;
                this.SendImage.Save(filename, imageCodecInfo, encoderParams);
                this.backgroundWorker1.ReportProgress(10);
                Console.WriteLine("登录");
                if (!accessor.ClientLogin(this._strID, this._strPass))
                {
                    switch (accessor.LoginErrorCode)
                    {
                        case PicasaLoginError.BadAuthentication:
                        case PicasaLoginError.NotVerified:
                        case PicasaLoginError.CaptchaRequired:
                        case PicasaLoginError.AccountDeleted:
                        case PicasaLoginError.AccountDisabled:
                            this._error = "无法登录。";
                            break;

                        case PicasaLoginError.TermsNotAgreed:
                            this._error = "不同意的条款和条件。";
                            break;

                        case PicasaLoginError.ServiceDisabled:
                            this._error = "Picasa服务当前无法使用。";
                            break;

                        case PicasaLoginError.ServiceUnavailable:
                            this._error = "Picasa服务未启动。";
                            break;

                        case PicasaLoginError.ConnectionError:
                            this._error = "无法连接。";
                            break;

                        default:
                            this._error = "登录失败。";
                            break;
                    }
                    e.Cancel = true;
                }
                else
                {
                    this.backgroundWorker1.ReportProgress(20);
                    Console.WriteLine("检查相册");
                    string str2 = accessor.ExistAlbum(this.AlbumName);
                    if (str2.Length == 0)
                    {
                        str2 = accessor.CreateAlbum(this.AlbumName, this.AlbumComment, this.AlbumPublic);
                    }
                    this.backgroundWorker1.ReportProgress(30);
                    if (str2.Length == 0)
                    {
                        this._error = "无法创建相册。\n\n※要使用此功能，您需要同意使用Picasa服务协议。\n请登陆 https://picasaweb.google.com/ 详细确认。";
                        e.Cancel = true;
                    }
                    else
                    {
                        Console.WriteLine("上传过程");
                        if (!accessor.UploadPhoto(this.AlbumName, filename, this.backgroundWorker1, 30))
                        {
                            switch (accessor.UploadErrorCode)
                            {
                                case PicasaUploadError.BadRequest:
                                case PicasaUploadError.UnAuthorized:
                                case PicasaUploadError.Conflict:
                                    this._error = "上传失败。";
                                    break;

                                case PicasaUploadError.Forbidden:
                                    this._error = "访问被禁止。";
                                    break;

                                case PicasaUploadError.NotFound:
                                    this._error = "无法找到所需的数据。";
                                    break;

                                case PicasaUploadError.InternalServerError:
                                    this._error = "内部服务器错误。";
                                    break;

                                default:
                                    this._error = "上传失败。";
                                    break;
                            }
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this._error = exception.Message;
                e.Cancel = true;
            }
            finally
            {
                if ((filename.Length > 0) && File.Exists(filename))
                {
                    File.Delete(filename);
                }
                this.SendImage.Dispose();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show(this, this._error, "上传到Picasa");
            }
            base.Close();
        }

        public static string Decrypto(byte[] cary)
        {
            byte[] bytes = DesCrypto.DesDecrypto(cary, Key, Iv);
            return Encoding.Unicode.GetString(bytes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public static byte[] Encrypto(string strv) => 
            DesCrypto.DesEncrypto(strv, Key, Iv);

        protected ImageCodecInfo GetImageCodecInfo()
        {
            ImageFormat jpeg = ImageFormat.Jpeg;
            ImageCodecInfo info = null;
            foreach (ImageCodecInfo info2 in ImageCodecInfo.GetImageEncoders())
            {
                if (info2.FormatID == jpeg.Guid)
                {
                    info = info2;
                    break;
                }
            }
            if (info == null)
            {
                MessageBox.Show("因为没找到可以利用的编码器，不能保存图像。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return info;
        }

        private void InitializeComponent()
        {
            this.backgroundWorker1 = new BackgroundWorker();
            this.pictureBox1 = new PictureBox();
            this.progressBar1 = new ProgressBar();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.pictureBox1.Image = Resources.PicasaLogo;
            this.pictureBox1.Location = new Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x5c, 30);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.progressBar1.Location = new Point(1, 0x20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(0x5c, 10);
            this.progressBar1.TabIndex = 1;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x5d, 0x2b);
            base.ControlBox = false;
            base.Controls.Add(this.progressBar1);
            base.Controls.Add(this.pictureBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximumSize = new Size(0x63, 0x31);
            this.MinimumSize = new Size(0x63, 0x31);
            base.Name = "PicasaBar";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.Shown += new EventHandler(this.PicasaBar_Shown);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void PicasaBar_Shown(object sender, EventArgs e)
        {
            this._strID = this._strPass = "";
            if (this.ID.Length > 0)
            {
                this._strID = Decrypto(this.ID);
            }
            if (this.Pass.Length > 0)
            {
                this._strPass = Decrypto(this.Pass);
            }
            if ((this._strID.Length == 0) || (this._strPass.Length == 0))
            {
                using (LoginInput input = new LoginInput())
                {
                    input.ID = this._strID;
                    input.Pass = this._strPass;
                    input.GroupTitle = "输入您的谷歌帐户";
                    input.Text = "上传到Picasa";
                    input.TopMost = true;
                    input.StartPosition = FormStartPosition.CenterParent;
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        this._strID = input.ID;
                        this._strPass = input.Pass;
                    }
                    else
                    {
                        base.Close();
                        return;
                    }
                }
            }
            if (this.SendImage != null)
            {
                this.backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                base.Close();
            }
        }

        public string AlbumComment
        {
            get{return  
                this._albumcomment;}
            set
            {
                this._albumcomment = value;
            }
        }

        public string AlbumName
        {
            get{return  
                this._albumname;}
            set
            {
                this._albumname = value;
            }
        }

        public bool AlbumPublic
        {
            get{return  
                this._albumaccess;}
            set
            {
                this._albumaccess = value;
            }
        }

        public byte[] ID
        {
            private get{return  
                (this._id ?? new byte[0]);}
            set
            {
                this._id = value;
            }
        }

        private static byte[] Iv
        {
            get
            {
                byte[] buffer = new byte[8];
                int width = Properties.Image.Crypt.Width;
                int height = Properties.Image.Crypt.Height;
                buffer[0] = Properties.Image.Crypt.GetPixel(6, 3).R;
                buffer[1] = Properties.Image.Crypt.GetPixel(0x12, 2).G;
                buffer[2] = Properties.Image.Crypt.GetPixel(buffer[0] % width, buffer[1] % height).B;
                buffer[3] = Properties.Image.Crypt.GetPixel(buffer[1] % width, buffer[2] % height).R;
                buffer[4] = Properties.Image.Crypt.GetPixel(buffer[2] % width, buffer[3] % height).G;
                buffer[5] = Properties.Image.Crypt.GetPixel(buffer[3] % width, buffer[4] % height).G;
                buffer[6] = Properties.Image.Crypt.GetPixel(buffer[4] % width, buffer[5] % height).R;
                buffer[7] = Properties.Image.Crypt.GetPixel(buffer[5] % width, buffer[6] % height).B;
                return buffer;
            }
        }

        private static byte[] Key
        {
            get
            {
                byte[] buffer = new byte[0x10];
                int width = Properties.Image.Crypt.Width;
                int height = Properties.Image.Crypt.Height;
                buffer[0] = Properties.Image.Crypt.GetPixel(10, 8).R;
                buffer[1] = Properties.Image.Crypt.GetPixel(4, 9).G;
                buffer[2] = Properties.Image.Crypt.GetPixel(buffer[0] % width, buffer[1] % height).B;
                buffer[3] = Properties.Image.Crypt.GetPixel(buffer[1] % width, buffer[2] % height).R;
                buffer[4] = Properties.Image.Crypt.GetPixel(buffer[2] % width, buffer[3] % height).G;
                buffer[5] = Properties.Image.Crypt.GetPixel(buffer[3] % width, buffer[4] % height).G;
                buffer[6] = Properties.Image.Crypt.GetPixel(buffer[4] % width, buffer[5] % height).R;
                buffer[7] = Properties.Image.Crypt.GetPixel(buffer[5] % width, buffer[6] % height).B;
                buffer[8] = Properties.Image.Crypt.GetPixel(buffer[6] % width, buffer[7] % height).G;
                buffer[9] = Properties.Image.Crypt.GetPixel(buffer[7] % width, buffer[8] % height).R;
                buffer[10] = Properties.Image.Crypt.GetPixel(buffer[8] % width, buffer[9] % height).G;
                buffer[11] = Properties.Image.Crypt.GetPixel(buffer[9] % width, buffer[10] % height).B;
                buffer[12] = Properties.Image.Crypt.GetPixel(buffer[10] % width, buffer[11] % height).R;
                buffer[13] = Properties.Image.Crypt.GetPixel(buffer[11] % width, buffer[12] % height).G;
                buffer[14] = Properties.Image.Crypt.GetPixel(buffer[12] % width, buffer[13] % height).R;
                buffer[15] = Properties.Image.Crypt.GetPixel(buffer[13] % width, buffer[14] % height).G;
                return buffer;
            }
        }

        public byte[] Pass
        {
            private get{return  
                (this._pass ?? new byte[0]);}
            set
            {
                this._pass = value;
            }
        }

        public System.Drawing.Image SendImage
        {
            private get{return  
                this._img;}
            set
            {
                this._img = (System.Drawing.Image) value.Clone();
            }
        }
    }
}

