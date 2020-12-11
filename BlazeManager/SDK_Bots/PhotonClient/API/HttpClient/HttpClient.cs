using System;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Linq;

namespace PhotonClient.API.HttpClient
{
    public class HttpClient : WebClient
    {
        internal string baseAddress;
        public HttpClient(string baseAddress)
        {
            this.baseAddress = baseAddress;
        }
        
        public bool HasHeader(string name) => Headers.AllKeys.FirstOrDefault(x => x == name) != null;
        public void AddHeader(string name, string value) => Headers.Add(name, value);
        public void AddHeader_Cookie(string value) => Headers.Add(HttpRequestHeader.Cookie, value);
        public void ClearHeader() => Headers.Clear();

        public HttpResponse Get(string uri)
        {
            HttpResponse result = new HttpResponse();
            try
            {
                result.result = DownloadString(baseAddress + uri);
                result.isSuccess = true;
                result.cookie = ResponseHeaders["Set-Cookie"];
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            finally
            {
                Dispose();
            }
            return result;
        }
        public HttpResponse Post(string uri, NameValueCollection data)
        {
            HttpResponse result = new HttpResponse();
            try
            {
                byte[] bytes = UploadValues(baseAddress + uri, "POST", data);
                result.result = Encoding.UTF8.GetString(bytes);
                result.isSuccess = true;
                result.cookie = ResponseHeaders["Set-Cookie"];
            }
            catch (Exception ex)
            {
                result.ex = ex;
            }
            finally
            {
                Dispose();
            }
            return result;
        }

        public class HttpResponse
        {
            public string result;

            public bool isSuccess;

            public string cookie;

            public Exception ex;
        }
    }
}
