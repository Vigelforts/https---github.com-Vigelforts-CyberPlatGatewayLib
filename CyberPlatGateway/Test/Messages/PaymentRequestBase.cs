using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberPlatGateway.Messages;

namespace CyberPlatGateway.Test.Messages
{
    public class PaymentRequestBase:CyberPlatMessage
    {
        public string SD;
        public string AP;
        public string OP;
        public string SESSION;
        public string NUMBER;
        public string ACCOUNT;
        public string AMOUNT;
        public string AMOUNT_ALL;
        public string PAY_TOOL;
        public string ACCEPT_KEYS;
        public string NO_ROUTE;
    }
}
