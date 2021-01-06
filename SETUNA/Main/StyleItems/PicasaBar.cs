using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using com.clearunit;

namespace SETUNA.Main.StyleItems
{
    // Token: 0x02000075 RID: 117
    public partial class PicasaBar : BaseForm
    {
        // Token: 0x17000091 RID: 145
        // (get) Token: 0x060003CD RID: 973 RVA: 0x0001756D File Offset: 0x0001576D
        // (set) Token: 0x060003CC RID: 972 RVA: 0x00017564 File Offset: 0x00015764
        public byte[] ID
        {
            private get => _id ?? new byte[0];
            set => _id = value;
        }

        // Token: 0x17000092 RID: 146
        // (get) Token: 0x060003CF RID: 975 RVA: 0x00017588 File Offset: 0x00015788
        // (set) Token: 0x060003CE RID: 974 RVA: 0x0001757F File Offset: 0x0001577F
        public byte[] Pass
        {
            private get => _pass ?? new byte[0];
            set => _pass = value;
        }

        // Token: 0x17000093 RID: 147
        // (get) Token: 0x060003D1 RID: 977 RVA: 0x000175A3 File Offset: 0x000157A3
        // (set) Token: 0x060003D0 RID: 976 RVA: 0x0001759A File Offset: 0x0001579A
        public string AlbumName
        {
            get => _albumname;
            set => _albumname = value;
        }

        // Token: 0x17000094 RID: 148
        // (get) Token: 0x060003D3 RID: 979 RVA: 0x000175B4 File Offset: 0x000157B4
        // (set) Token: 0x060003D2 RID: 978 RVA: 0x000175AB File Offset: 0x000157AB
        public string AlbumComment
        {
            get => _albumcomment;
            set => _albumcomment = value;
        }

        // Token: 0x17000095 RID: 149
        // (get) Token: 0x060003D5 RID: 981 RVA: 0x000175C5 File Offset: 0x000157C5
        // (set) Token: 0x060003D4 RID: 980 RVA: 0x000175BC File Offset: 0x000157BC
        public bool AlbumPublic
        {
            get => _albumaccess;
            set => _albumaccess = value;
        }

        // Token: 0x17000096 RID: 150
        // (get) Token: 0x060003D7 RID: 983 RVA: 0x000175E0 File Offset: 0x000157E0
        // (set) Token: 0x060003D6 RID: 982 RVA: 0x000175CD File Offset: 0x000157CD
        public System.Drawing.Image SendImage
        {
            private get => _img;
            set => _img = (System.Drawing.Image)value.Clone();
        }

        // Token: 0x17000097 RID: 151
        // (get) Token: 0x060003D8 RID: 984 RVA: 0x000175E8 File Offset: 0x000157E8
        private static byte[] Key
        {
            get
            {
                var array = new byte[16];
                var width = SETUNA.Resources.Image.Crypt.Width;
                var height = SETUNA.Resources.Image.Crypt.Height;
                array[0] = SETUNA.Resources.Image.Crypt.GetPixel(10, 8).R;
                array[1] = SETUNA.Resources.Image.Crypt.GetPixel(4, 9).G;
                array[2] = SETUNA.Resources.Image.Crypt.GetPixel(array[0] % width, array[1] % height).B;
                array[3] = SETUNA.Resources.Image.Crypt.GetPixel(array[1] % width, array[2] % height).R;
                array[4] = SETUNA.Resources.Image.Crypt.GetPixel(array[2] % width, array[3] % height).G;
                array[5] = SETUNA.Resources.Image.Crypt.GetPixel(array[3] % width, array[4] % height).G;
                array[6] = SETUNA.Resources.Image.Crypt.GetPixel(array[4] % width, array[5] % height).R;
                array[7] = SETUNA.Resources.Image.Crypt.GetPixel(array[5] % width, array[6] % height).B;
                array[8] = SETUNA.Resources.Image.Crypt.GetPixel(array[6] % width, array[7] % height).G;
                array[9] = SETUNA.Resources.Image.Crypt.GetPixel(array[7] % width, array[8] % height).R;
                array[10] = SETUNA.Resources.Image.Crypt.GetPixel(array[8] % width, array[9] % height).G;
                array[11] = SETUNA.Resources.Image.Crypt.GetPixel(array[9] % width, array[10] % height).B;
                array[12] = SETUNA.Resources.Image.Crypt.GetPixel(array[10] % width, array[11] % height).R;
                array[13] = SETUNA.Resources.Image.Crypt.GetPixel(array[11] % width, array[12] % height).G;
                array[14] = SETUNA.Resources.Image.Crypt.GetPixel(array[12] % width, array[13] % height).R;
                array[15] = SETUNA.Resources.Image.Crypt.GetPixel(array[13] % width, array[14] % height).G;
                return array;
            }
        }

        // Token: 0x17000098 RID: 152
        // (get) Token: 0x060003D9 RID: 985 RVA: 0x00017818 File Offset: 0x00015A18
        private static byte[] Iv
        {
            get
            {
                var array = new byte[8];
                var width = SETUNA.Resources.Image.Crypt.Width;
                var height = SETUNA.Resources.Image.Crypt.Height;
                array[0] = SETUNA.Resources.Image.Crypt.GetPixel(6, 3).R;
                array[1] = SETUNA.Resources.Image.Crypt.GetPixel(18, 2).G;
                array[2] = SETUNA.Resources.Image.Crypt.GetPixel(array[0] % width, array[1] % height).B;
                array[3] = SETUNA.Resources.Image.Crypt.GetPixel(array[1] % width, array[2] % height).R;
                array[4] = SETUNA.Resources.Image.Crypt.GetPixel(array[2] % width, array[3] % height).G;
                array[5] = SETUNA.Resources.Image.Crypt.GetPixel(array[3] % width, array[4] % height).G;
                array[6] = SETUNA.Resources.Image.Crypt.GetPixel(array[4] % width, array[5] % height).R;
                array[7] = SETUNA.Resources.Image.Crypt.GetPixel(array[5] % width, array[6] % height).B;
                return array;
            }
        }

        // Token: 0x060003DA RID: 986 RVA: 0x00017934 File Offset: 0x00015B34
        public static byte[] Encrypto(string strv)
        {
            return DesCrypto.DesEncrypto(strv, PicasaBar.Key, PicasaBar.Iv);
        }

        // Token: 0x060003DB RID: 987 RVA: 0x00017954 File Offset: 0x00015B54
        public static string Decrypto(byte[] cary)
        {
            var bytes = DesCrypto.DesDecrypto(cary, PicasaBar.Key, PicasaBar.Iv);
            return Encoding.Unicode.GetString(bytes);
        }

        // Token: 0x060003DC RID: 988 RVA: 0x0001797D File Offset: 0x00015B7D
        public PicasaBar()
        {
            InitializeComponent();
        }

        // Token: 0x060003DD RID: 989 RVA: 0x00017998 File Offset: 0x00015B98
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var text = "";
            var picasaAccessor = new PicasaAccessor();
            try
            {
                backgroundWorker1.ReportProgress(5);
                Console.WriteLine("创建一个临时文件");
                text = Path.GetTempFileName();
                var imageCodecInfo = GetImageCodecInfo();
                var quality = System.Drawing.Imaging.Encoder.Quality;
                var encoderParameters = new EncoderParameters(1);
                var encoderParameter = new EncoderParameter(quality, 100L);
                encoderParameters.Param[0] = encoderParameter;
                SendImage.Save(text, imageCodecInfo, encoderParameters);
                backgroundWorker1.ReportProgress(10);
                Console.WriteLine("登录");
                if (!picasaAccessor.ClientLogin(_strID, _strPass))
                {
                    switch (picasaAccessor.LoginErrorCode)
                    {
                        case PicasaLoginError.BadAuthentication:
                        case PicasaLoginError.NotVerified:
                        case PicasaLoginError.CaptchaRequired:
                        case PicasaLoginError.AccountDeleted:
                        case PicasaLoginError.AccountDisabled:
                            _error = "无法登录。";
                            goto IL_119;
                        case PicasaLoginError.TermsNotAgreed:
                            _error = "不同意的条款和条件。";
                            goto IL_119;
                        case PicasaLoginError.ServiceDisabled:
                            _error = "Picasa服务当前无法使用。";
                            goto IL_119;
                        case PicasaLoginError.ServiceUnavailable:
                            _error = "Picasa服务未启动。";
                            goto IL_119;
                        case PicasaLoginError.ConnectionError:
                            _error = "无法连接。";
                            goto IL_119;
                    }
                    _error = "登录失败。";
                IL_119:
                    e.Cancel = true;
                }
                else
                {
                    backgroundWorker1.ReportProgress(20);
                    Console.WriteLine("检查相册");
                    var text2 = picasaAccessor.ExistAlbum(AlbumName);
                    if (text2.Length == 0)
                    {
                        text2 = picasaAccessor.CreateAlbum(AlbumName, AlbumComment, AlbumPublic);
                    }
                    backgroundWorker1.ReportProgress(30);
                    if (text2.Length == 0)
                    {
                        _error = "无法创建相册。\n\n※要使用此功能，您需要同意使用Picasa服务协议。\n请登陆 https://picasaweb.google.com/ 详细确认。";
                        e.Cancel = true;
                    }
                    else
                    {
                        Console.WriteLine("上传过程");
                        if (!picasaAccessor.UploadPhoto(AlbumName, text, backgroundWorker1, 30))
                        {
                            switch (picasaAccessor.UploadErrorCode)
                            {
                                case PicasaUploadError.BadRequest:
                                case PicasaUploadError.UnAuthorized:
                                case PicasaUploadError.Conflict:
                                    _error = "上传失败。";
                                    break;
                                case PicasaUploadError.Forbidden:
                                    _error = "访问被禁止。";
                                    break;
                                case PicasaUploadError.NotFound:
                                    _error = "无法找到所需的数据。";
                                    break;
                                case PicasaUploadError.InternalServerError:
                                    _error = "内部服务器错误。";
                                    break;
                                default:
                                    _error = "上传失败。";
                                    break;
                            }
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                e.Cancel = true;
            }
            finally
            {
                if (text.Length > 0 && File.Exists(text))
                {
                    File.Delete(text);
                }
                SendImage.Dispose();
            }
        }

        // Token: 0x060003DE RID: 990 RVA: 0x00017C40 File Offset: 0x00015E40
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        // Token: 0x060003DF RID: 991 RVA: 0x00017C53 File Offset: 0x00015E53
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show(this, _error, "上传到Picasa");
            }
            base.Close();
        }

        // Token: 0x060003E0 RID: 992 RVA: 0x00017C78 File Offset: 0x00015E78
        protected ImageCodecInfo GetImageCodecInfo()
        {
            var jpeg = ImageFormat.Jpeg;
            ImageCodecInfo imageCodecInfo = null;
            foreach (var imageCodecInfo2 in ImageCodecInfo.GetImageEncoders())
            {
                if (imageCodecInfo2.FormatID == jpeg.Guid)
                {
                    imageCodecInfo = imageCodecInfo2;
                    break;
                }
            }
            if (imageCodecInfo == null)
            {
                MessageBox.Show("因为没找到可以利用的编码器，不能保存图像。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return imageCodecInfo;
        }

        // Token: 0x060003E1 RID: 993 RVA: 0x00017CD8 File Offset: 0x00015ED8
        private void PicasaBar_Shown(object sender, EventArgs e)
        {
            _strID = (_strPass = "");
            if (ID.Length > 0)
            {
                _strID = PicasaBar.Decrypto(ID);
            }
            if (Pass.Length > 0)
            {
                _strPass = PicasaBar.Decrypto(Pass);
            }
            if (_strID.Length == 0 || _strPass.Length == 0)
            {
                using (var loginInput = new LoginInput())
                {
                    loginInput.ID = _strID;
                    loginInput.Pass = _strPass;
                    loginInput.GroupTitle = "输入您的谷歌帐户";
                    loginInput.Text = "上传到Picasa";
                    loginInput.TopMost = true;
                    loginInput.StartPosition = FormStartPosition.CenterParent;
                    if (loginInput.ShowDialog() != DialogResult.OK)
                    {
                        base.Close();
                        return;
                    }
                    _strID = loginInput.ID;
                    _strPass = loginInput.Pass;
                }
            }
            if (SendImage != null)
            {
                backgroundWorker1.RunWorkerAsync();
                return;
            }
            base.Close();
        }

        // Token: 0x0400022B RID: 555
        private byte[] _id;

        // Token: 0x0400022C RID: 556
        private byte[] _pass;

        // Token: 0x0400022D RID: 557
        private string _albumname;

        // Token: 0x0400022E RID: 558
        private string _albumcomment;

        // Token: 0x0400022F RID: 559
        private bool _albumaccess;

        // Token: 0x04000230 RID: 560
        private System.Drawing.Image _img;

        // Token: 0x04000231 RID: 561
        private string _error = "";

        // Token: 0x04000232 RID: 562
        private string _strID;

        // Token: 0x04000233 RID: 563
        private string _strPass;
    }
}
