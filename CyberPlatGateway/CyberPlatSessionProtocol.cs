using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberPlatGateway.Messages;
using CyberPlatGateway.Test.Messages;

namespace CyberPlatGateway
{
    public abstract class CyberPlatSessionProtocolBase
    {
        private HTTPSClient httpsClient;
        private string _checkNumberUrl;
        private string _makePaymentUrl;
        private string _checkPaymentStatus;
        private Encoding _encoding;
        private string _keyPath;
        private IPrivKey _key;
        public event EventHandler<PaymentAnswerBase> MessageReceived;

        protected CyberPlatSessionProtocolBase(string checkNumberUrl, string makePaymentUrl, string checkPaymentStatus, string keyPath, Encoding encoding)
        {
            httpsClient = new HTTPSClient();
            _keyPath = keyPath;
            _encoding = encoding;
            _key = IPriv.openSecretKey(keyPath, "1111111111");
            this._checkNumberUrl = checkNumberUrl;
            this._makePaymentUrl = makePaymentUrl;
            this._checkPaymentStatus = checkPaymentStatus;
            httpsClient.AnswerReceived += ReceiveMessage;
        }

        public void SendMessage(CyberPlatMessage message)
        {
            var stringToSend = message.ToString().Replace("\\r\\n","%0D%0A").Replace("=","%3D");
            _key.signText(stringToSend);
            var bytesToSend = _encoding.GetBytes(stringToSend);
            if (message is PaymentAckRequest)
            {
                httpsClient.SendRequest(bytesToSend,_checkNumberUrl);
            }
            if (message is PaymentRequest)
            {
                httpsClient.SendRequest(bytesToSend, _makePaymentUrl);
            }
        }

        private void ReceiveMessage(object sender, string s)
        {
            if (s.Contains("REST"))
            {
                var answer = new PaymentAckAnswer(s);
                if (MessageReceived != null)
                {
                    MessageReceived(this, answer);
                }
            }
            else
            {
                var answer = new PaymentAnswer(s);
                if (MessageReceived != null)
                {
                    MessageReceived(this, answer);
                }
            }         
        }


}
}
