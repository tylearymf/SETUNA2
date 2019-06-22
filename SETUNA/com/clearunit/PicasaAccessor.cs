namespace com.clearunit
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;

    internal class PicasaAccessor
    {
        private string Auth = "";
        private string ID;
        public PicasaLoginError LoginErrorCode = PicasaLoginError.None;
        public PicasaUploadError UploadErrorCode;

        public bool ClientLogin(string id, string pass)
        {
            HttpWebResponse response;
            this.ID = id;
            this.Auth = "";
            this.LoginErrorCode = PicasaLoginError.None;
            this.UploadErrorCode = PicasaUploadError.None;
            bool flag = false;
            Encoding encoding = Encoding.UTF8;
            string s = "";
            Hashtable hashtable = new Hashtable {
                ["accountType"] = "GOOGLE",
                ["Email"] = id,
                ["Passwd"] = pass,
                ["service"] = "lh2",
                ["source"] = "Clearup-PicasaAccessor-1.00"
            };
            foreach (string str2 in hashtable.Keys)
            {
                s = s + $"{str2}={hashtable[str2]}&";
            }
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.LoginUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            try
            {
                response = (HttpWebResponse) request.GetResponse();
            }
            catch (WebException exception)
            {
                response = (HttpWebResponse) exception.Response;
                Console.WriteLine(exception.ToString());
            }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, encoding);
            string str3 = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                foreach (string str4 in str3.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] strArray2 = str4.Split(new char[] { '=' });
                    if ((strArray2.Length >= 2) && (strArray2[0] == "Auth"))
                    {
                        this.Auth = strArray2[1];
                        flag = true;
                    }
                }
                return flag;
            }
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                foreach (string str5 in str3.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] strArray4 = str5.Split(new char[] { '=' });
                    if ((strArray4.Length > 2) && (strArray4[0] == "Error"))
                    {
                        if (strArray4[1] == "BadAuthentication")
                        {
                            this.LoginErrorCode = PicasaLoginError.BadAuthentication;
                        }
                        else if (strArray4[1] == "NotVerified")
                        {
                            this.LoginErrorCode = PicasaLoginError.NotVerified;
                        }
                        else if (strArray4[1] == "TermsNotAgreed")
                        {
                            this.LoginErrorCode = PicasaLoginError.TermsNotAgreed;
                        }
                        else if (strArray4[1] == "CaptchaRequired")
                        {
                            this.LoginErrorCode = PicasaLoginError.CaptchaRequired;
                        }
                        else if (strArray4[1] == "AccountDeleted")
                        {
                            this.LoginErrorCode = PicasaLoginError.AccountDeleted;
                        }
                        else if (strArray4[1] == "AccountDisabled")
                        {
                            this.LoginErrorCode = PicasaLoginError.AccountDisabled;
                        }
                        else if (strArray4[1] == "ServiceDisabled")
                        {
                            this.LoginErrorCode = PicasaLoginError.ServiceDisabled;
                        }
                        else if (strArray4[1] == "ServiceUnavailable")
                        {
                            this.LoginErrorCode = PicasaLoginError.ServiceUnavailable;
                        }
                        else
                        {
                            this.LoginErrorCode = PicasaLoginError.Unknown;
                        }
                    }
                }
                return flag;
            }
            this.LoginErrorCode = PicasaLoginError.ConnectionError;
            return flag;
        }

        private string CreateAlbum(XmlDocument document)
        {
            HttpWebResponse response;
            string innerText = "";
            Encoding encoding = Encoding.UTF8;
            string s = "";
            new Hashtable();
            s = document.InnerXml.Replace("-xmlc-", ":");
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.Url);
            request.Method = "POST";
            request.ContentType = "application/atom+xml";
            request.Headers.Add(HttpRequestHeader.Authorization, "GoogleLogin auth=" + this.Auth);
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            try
            {
                response = (HttpWebResponse) request.GetResponse();
            }
            catch (WebException exception)
            {
                response = (HttpWebResponse) exception.Response;
                Console.WriteLine(exception.ToString());
            }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, encoding);
            string xml = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            if (response.StatusCode == HttpStatusCode.Created)
            {
                XmlDocument document2 = new XmlDocument();
                document2.LoadXml(xml);
                innerText = document2["entry"]["gphoto:id"].InnerText;
            }
            return innerText;
        }

        public string CreateAlbum(string title, string description, bool isPublic)
        {
            if (this.Auth.Length == 0)
            {
                throw new Exception("您还没有登录Picasa服务。");
            }
            XmlDocument document = new XmlDocument();
            XmlElement newChild = document.CreateElement("entry");
            newChild.Attributes.Append(document.CreateAttribute("xmlns")).Value = "http://www.w3.org/2005/Atom";
            newChild.Attributes.Append(document.CreateAttribute("xmlns:gphoto")).Value = "http://schemas.google.com/photos/2007";
            document.AppendChild(newChild);
            XmlElement element2 = document.CreateElement("title");
            element2.Attributes.Append(document.CreateAttribute("type")).Value = "text";
            element2.InnerText = title;
            newChild.AppendChild(element2);
            XmlElement element3 = document.CreateElement("summary");
            element3.Attributes.Append(document.CreateAttribute("type")).Value = "text";
            element3.InnerText = description;
            newChild.AppendChild(element3);
            newChild.AppendChild(document.CreateElement("gphoto-xmlc-access")).InnerText = isPublic ? "public" : "private";
            newChild.AppendChild(document.CreateElement("gphoto-xmlc-commentingEnabled")).InnerText = "false";
            XmlElement element4 = document.CreateElement("category");
            element4.Attributes.Append(document.CreateAttribute("scheme")).Value = "http://schemas.google.com/g/2005#kind";
            element4.Attributes.Append(document.CreateAttribute("term")).Value = "http://schemas.google.com/photos/2007#album";
            newChild.AppendChild(element4);
            return this.CreateAlbum(document);
        }

        public string ExistAlbum(string albumname)
        {
            HttpWebResponse response;
            if (this.Auth.Length == 0)
            {
                throw new Exception("您还没有登录Picasa服务。");
            }
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.AlbumFeedUrl);
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, "GoogleLogin auth=" + this.Auth);
            try
            {
                response = (HttpWebResponse) request.GetResponse();
            }
            catch (WebException exception)
            {
                response = (HttpWebResponse) exception.Response;
                Console.WriteLine(exception.ToString());
            }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, encoding);
            string xml = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                foreach (XmlElement element in document["feed"].GetElementsByTagName("entry"))
                {
                    if (element["title"].InnerText == albumname)
                    {
                        return element["gphoto:id"].InnerText;
                    }
                }
            }
            return "";
        }

        public bool UploadPhoto(string album, string imgfile, BackgroundWorker bgw, int progress)
        {
            HttpWebResponse response;
            bool flag = false;
            Encoding encoding = Encoding.UTF8;
            string s = "";
            Encoding.ASCII.GetBytes(s);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.UploadUrl + album);
            request.Method = "POST";
            request.ContentType = "image/jpg";
            request.Headers.Add("Slug: " + Path.GetFileName(imgfile));
            request.Headers.Add(HttpRequestHeader.Authorization, "GoogleLogin auth=" + this.Auth);
            FileStream stream = new FileStream(imgfile, FileMode.Open, FileAccess.Read);
            request.ContentLength = stream.Length;
            Stream requestStream = request.GetRequestStream();
            byte[] buffer = new byte[0x1000];
            int count = 0;
            int num2 = 100 - progress;
            int percentProgress = 0;
            while (true)
            {
                count = stream.Read(buffer, 0, buffer.Length);
                if (count == 0)
                {
                    break;
                }
                requestStream.Write(buffer, 0, count);
                percentProgress += (int) ((((float) count) / ((float) request.ContentLength)) * num2);
                bgw.ReportProgress(percentProgress);
            }
            stream.Close();
            requestStream.Close();
            bgw.ReportProgress(100);
            try
            {
                response = (HttpWebResponse) request.GetResponse();
            }
            catch (WebException exception)
            {
                response = (HttpWebResponse) exception.Response;
                Console.WriteLine(exception.ToString());
            }
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, encoding);
            reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            if ((response.StatusCode == HttpStatusCode.Created) || (response.StatusCode == HttpStatusCode.OK))
            {
                return true;
            }
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    this.UploadErrorCode = PicasaUploadError.BadRequest;
                    return flag;

                case HttpStatusCode.Unauthorized:
                    this.UploadErrorCode = PicasaUploadError.UnAuthorized;
                    return flag;

                case HttpStatusCode.Forbidden:
                    this.UploadErrorCode = PicasaUploadError.Forbidden;
                    return flag;

                case HttpStatusCode.NotFound:
                    this.UploadErrorCode = PicasaUploadError.NotFound;
                    return flag;

                case HttpStatusCode.Conflict:
                    this.UploadErrorCode = PicasaUploadError.Conflict;
                    return flag;

                case HttpStatusCode.InternalServerError:
                    this.UploadErrorCode = PicasaUploadError.InternalServerError;
                    return flag;
            }
            this.UploadErrorCode = PicasaUploadError.Unknown;
            return flag;
        }

        private string AlbumFeedUrl =>
            ("https://picasaweb.google.com/data/feed/api/user/" + this.ID + "?kind=album");

        private string LoginUrl =>
            "https://www.google.com/accounts/ClientLogin";

        private string UploadUrl =>
            ("https://picasaweb.google.com/data/feed/api/user/" + this.ID + "/album/");

        private string Url =>
            ("https://picasaweb.google.com/data/feed/api/user/" + this.ID);
    }
}

