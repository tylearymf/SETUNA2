using System.Drawing;
using System.Windows.Forms;

namespace SETUNA.Main.StyleItems
{
    using SETUNA.Properties;

    // Token: 0x0200008C RID: 140
    public class CPicasaUploaderStyleItem : CStyleItem
    {
        // Token: 0x170000AE RID: 174
        // (get) Token: 0x0600048D RID: 1165 RVA: 0x0001D917 File Offset: 0x0001BB17
        // (set) Token: 0x0600048C RID: 1164 RVA: 0x0001D915 File Offset: 0x0001BB15
        public string AlbumName
        {
            get => "SETUNA";
            set
            {
            }
        }

        // Token: 0x170000AF RID: 175
        // (get) Token: 0x0600048F RID: 1167 RVA: 0x0001D920 File Offset: 0x0001BB20
        // (set) Token: 0x0600048E RID: 1166 RVA: 0x0001D91E File Offset: 0x0001BB1E
        public string AlbumComment
        {
            get => "用SETUNA上传的相册。";
            set
            {
            }
        }

        // Token: 0x170000B0 RID: 176
        // (get) Token: 0x06000491 RID: 1169 RVA: 0x0001D929 File Offset: 0x0001BB29
        // (set) Token: 0x06000490 RID: 1168 RVA: 0x0001D927 File Offset: 0x0001BB27
        public bool IsPublic
        {
            get => false;
            set
            {
            }
        }

        // Token: 0x170000B1 RID: 177
        // (get) Token: 0x06000493 RID: 1171 RVA: 0x0001D935 File Offset: 0x0001BB35
        // (set) Token: 0x06000492 RID: 1170 RVA: 0x0001D92C File Offset: 0x0001BB2C
        public byte[] ID
        {
            get => _id ?? new byte[0];
            set => _id = value;
        }

        // Token: 0x170000B2 RID: 178
        // (get) Token: 0x06000495 RID: 1173 RVA: 0x0001D950 File Offset: 0x0001BB50
        // (set) Token: 0x06000494 RID: 1172 RVA: 0x0001D947 File Offset: 0x0001BB47
        public byte[] Pass
        {
            get => _pass ?? new byte[0];
            set => _pass = value;
        }

        // Token: 0x170000B3 RID: 179
        // (get) Token: 0x06000497 RID: 1175 RVA: 0x0001D972 File Offset: 0x0001BB72
        // (set) Token: 0x06000496 RID: 1174 RVA: 0x0001D962 File Offset: 0x0001BB62
        public byte Manage
        {
            get => _manage;
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                _manage = value;
            }
        }

        // Token: 0x06000498 RID: 1176 RVA: 0x0001D97C File Offset: 0x0001BB7C
        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            var scrapBase = scrap;
            var picasaBar = new PicasaBar
            {
                SendImage = scrapBase.Image,
                ID = ID,
                Pass = Pass,
                AlbumName = AlbumName,
                AlbumComment = AlbumComment,
                AlbumPublic = IsPublic,
                StartPosition = FormStartPosition.Manual,
                TopMost = true
            };
            picasaBar.Left = scrap.Left + scrap.Width / 2 - picasaBar.Width / 2;
            picasaBar.Top = scrap.Top + scrap.Height / 2 - picasaBar.Height / 2;
            picasaBar.Show();
        }

        // Token: 0x06000499 RID: 1177 RVA: 0x0001DA2E File Offset: 0x0001BC2E
        public override string GetName()
        {
            return "PicasaUploader";
        }

        // Token: 0x0600049A RID: 1178 RVA: 0x0001DA35 File Offset: 0x0001BC35
        public override string GetDisplayName()
        {
            return "上传到Picasa";
        }

        // Token: 0x0600049B RID: 1179 RVA: 0x0001DA3C File Offset: 0x0001BC3C
        public override string GetDescription()
        {
            return "把参考图上传到Picasa网络相册。";
        }

        // Token: 0x0600049C RID: 1180 RVA: 0x0001DA43 File Offset: 0x0001BC43
        protected override ToolBoxForm GetToolBoxForm()
        {
            return new PicasaStyleItemPanel(this);
        }

        // Token: 0x0600049D RID: 1181 RVA: 0x0001DA4C File Offset: 0x0001BC4C
        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            var cpicasaUploaderStyleItem = (CPicasaUploaderStyleItem)newOwn;
            ID = cpicasaUploaderStyleItem.ID;
            Pass = cpicasaUploaderStyleItem.Pass;
            Manage = cpicasaUploaderStyleItem.Manage;
        }

        // Token: 0x0600049E RID: 1182 RVA: 0x0001DA84 File Offset: 0x0001BC84
        public override Bitmap GetIcon()
        {
            return Resources.Icon_Picasa;
        }

        // Token: 0x040002C2 RID: 706
        private byte[] _id;

        // Token: 0x040002C3 RID: 707
        private byte[] _pass;

        // Token: 0x040002C4 RID: 708
        private byte _manage;
    }
}
