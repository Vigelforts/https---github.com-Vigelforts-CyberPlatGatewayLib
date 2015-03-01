using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberPlatGateway.Messages;

namespace CyberPlatGateway.Test.Messages
{
    public class PaymentAnswerBase:CyberPlatMessage
    {
        public string DATE;
        public string SESSION;
        public int ERROR;
        public string RESULT;
        public string TRANSID;
        public string GATEWAY_IN;
        public string GATEWAY_OUT;
    }
}
