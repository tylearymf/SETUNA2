namespace SETUNA.Main.StyleItems
{
    using SETUNA.Main;
    using Properties;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class CPicasaUploaderStyleItem : CStyleItem
    {
        private byte[] _id;
        private byte _manage;
        private byte[] _pass;

        public override void Apply(ref ScrapBase scrap, Point clickpoint)
        {
            ScrapBase base2 = scrap;
            PicasaBar bar = new PicasaBar {
                SendImage = base2.Image,
                ID = this.ID,
                Pass = this.Pass,
                AlbumName = this.AlbumName,
                AlbumComment = this.AlbumComment,
                AlbumPublic = this.IsPublic,
                StartPosition = FormStartPosition.Manual,
                TopMost = true
            };
            bar.Left = (scrap.Left + (scrap.Width / 2)) - (bar.Width / 2);
            bar.Top = (scrap.Top + (scrap.Height / 2)) - (bar.Height / 2);
            bar.Show();
        }

        public override string GetDescription() => 
            "把参考图上传到Picasa网络相册。";

        public override string GetDisplayName() => 
            "上传到Picasa";

        public override Bitmap GetIcon() => 
            Resources.Icon_Picasa;

        public override string GetName() => 
            "PicasaUploader";

        protected override ToolBoxForm GetToolBoxForm() => 
            new PicasaStyleItemPanel(this);

        protected override void SetTunedStyleItem(CStyleItem newOwn)
        {
            CPicasaUploaderStyleItem item = (CPicasaUploaderStyleItem) newOwn;
            this.ID = item.ID;
            this.Pass = item.Pass;
            this.Manage = item.Manage;
        }

        public string AlbumComment
        {
            get{return  
                "用SETUNA上传的相册。";}
            set
            {
            }
        }

        public string AlbumName
        {
            get{return  
                "SETUNA";}
            set
            {
            }
        }

        public byte[] ID
        {
            get{return  
                (this._id ?? new byte[0]);}
            set
            {
                this._id = value;
            }
        }

        public bool IsPublic
        {
            get{return  
                false;}
            set
            {
            }
        }

        public byte Manage
        {
            get{return  
                this._manage;}
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                this._manage = value;
            }
        }

        public byte[] Pass
        {
            get{return  
                (this._pass ?? new byte[0]);}
            set
            {
                this._pass = value;
            }
        }
    }
}

