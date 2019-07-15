using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Common.Functions
{
    public class HttpClient
    {
        private object _lock = new object();

        private string _userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0";
        private string _accept = "text/html,application/json,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        private string _contentType = "application/x-www-form-urlencoded;charset=UTF-8";
        private string _referer = null;
        private string _charset = "UTF-8";
        private int _timeout = 30000;
        private int _readWriteTimeout = 30000;
        private CookieContainer _cookieContainer = new CookieContainer();
        private WebProxy _proxy = null;

        public HttpClient()
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 5000;
            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
        }

        public string UserAgent
        {
            get { return _userAgent; }
            set { _userAgent = value; }
        }

        public string Accept
        {
            get { return _accept; }
            set { _accept = value; }
        }

        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        public string Referer
        {
            get { return _referer; }
            set { _referer = value; }
        }

        public string Charset
        {
            get { return _charset; }
            set { _charset = value; }
        }

        public int TimeOut
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        public int ReadWriteTimeout
        {
            get { return _readWriteTimeout; }
            set { _readWriteTimeout = value; }
        }

        public CookieContainer CookieContainer
        {
            get { return _cookieContainer; }
            set { _cookieContainer = value; }
        }

        public WebProxy Proxy
        {
            get { return _proxy; }
            set { _proxy = value; }
        }

        public string Get(string uri)
        {
            lock (_lock)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.UserAgent = _userAgent;
                request.Accept = _accept;
                request.Referer = _referer;
                request.CookieContainer = _cookieContainer;
                request.Proxy = _proxy;
                request.Timeout = _timeout;
                request.ReadWriteTimeout = _readWriteTimeout;
                request.ProtocolVersion = HttpVersion.Version11;
                request.AllowWriteStreamBuffering = false;
                request.AllowAutoRedirect = true;
                request.KeepAlive = true;
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    _referer = uri;
                    _cookieContainer = request.CookieContainer;
                    
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (response.ContentEncoding == "gzip")
                        {
                            using (StreamReader sr = new StreamReader(new GZipStream(responseStream, CompressionMode.Decompress), Encoding.GetEncoding(_charset)))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                        else
                        {
                            using (StreamReader sr = new StreamReader(responseStream, Encoding.GetEncoding(_charset)))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }

        public string Post(string uri, string postData)
        {
            lock (_lock)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri); 
                request.UserAgent = _userAgent;
                request.Accept = _accept;
                request.Referer = _referer;
                request.CookieContainer = _cookieContainer;
                request.Proxy = _proxy;
                request.Timeout = _timeout;
                request.ReadWriteTimeout = _readWriteTimeout;
                request.ProtocolVersion = HttpVersion.Version11;
                request.AllowWriteStreamBuffering = false;
                request.AllowAutoRedirect = true;
                request.KeepAlive = true;


                byte[] postDataBytes = Encoding.GetEncoding(_charset).GetBytes(postData);
                request.Method = "POST";
                request.ContentType = _contentType;
                request.ContentLength = postDataBytes.Length;

                using (Stream writer = request.GetRequestStream())
                {
                    writer.Write(postDataBytes, 0, postDataBytes.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    _referer = uri;
                    _cookieContainer = request.CookieContainer;

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (response.ContentEncoding == "gzip")
                        {
                            using (StreamReader sr = new StreamReader(new GZipStream(responseStream, CompressionMode.Decompress), Encoding.GetEncoding(_charset)))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                        else
                        {
                            using (StreamReader sr = new StreamReader(responseStream, Encoding.GetEncoding(_charset)))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }

        public string SerializeCookies()
        {
            List<Cookie> listCookies = new List<Cookie>();

            Hashtable table = (Hashtable)_cookieContainer.GetType().InvokeMember("m_domainTable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, _cookieContainer, new object[] { });
            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                {
                    foreach (Cookie c in colCookies)
                    {
                        listCookies.Add(c);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (Cookie cookie in listCookies)
            {
                sb.AppendFormat("{0};{1};{2};{3};{4};{5}\r\n", cookie.Domain, cookie.Name, cookie.Path, cookie.Port, cookie.Secure.ToString(), cookie.Value);
            }

            return sb.ToString();
        }

        public void DeserializeCookies(string cookiesString)
        {
            string[] cookies = cookiesString.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string c in cookies)
            {
                string[] cc = c.Split(";".ToCharArray());

                Cookie ck = new Cookie(); ;
                ck.Domain = cc[0];
                ck.Name = cc[1];
                ck.Path = cc[2];
                ck.Port = cc[3];
                ck.Secure = bool.Parse(cc[4]);
                ck.Value = cc[5];

                _cookieContainer.Add(ck);
            }
        }

        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
    }
}
