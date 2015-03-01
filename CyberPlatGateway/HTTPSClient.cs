using System;
using System.IO;
using System.Net;
using System.Text;

namespace CyberPlatGateway
{
    public class HTTPSClient
    {
        public event EventHandler<string> AnswerReceived;
        private const string ContentType = @"application/x-www-form-urlencoded";
        public void SendRequest(byte[] bytesToSend, string url)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Post;
            request.Timeout = 60000;
            request.ContentType = ContentType;
            request.ContentLength = bytesToSend.Length;
            var os = request.GetRequestStream();
            os.Write(bytesToSend,0,bytesToSend.Length);
            os.Close();
            var response = request.GetResponse();
            if (response == null)
            {
                throw new Exception();
            }
            var streamReader = new StreamReader(response.GetResponseStream());
            if (AnswerReceived != null)
            {
                AnswerReceived.Invoke(this, streamReader.ReadToEnd());
            }
            streamReader.Dispose();
        }
    }
}