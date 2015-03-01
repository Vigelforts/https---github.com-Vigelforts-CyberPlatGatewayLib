using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberPlatGateway.Test;
using CyberPlatGateway.Test.Messages;

namespace CyberPlatGateway
{
    class Program
    {
        static void Main(string[] args)
        {
            var gateway = new CyberPlatGateway<TestCyberPlatSessionProtocol>();
            PaymentAckRequest message = new PaymentAckRequest
            {
                SD = 199.ToString(),
                AP = "8888888888",
                OP = 990.ToString(),
                SESSION = "56567567100010000000",
                NUMBER = 9998887766.ToString(),
                ACCOUNT = "",
                AMOUNT = 500.ToString(),
                AMOUNT_ALL = (505.00).ToString(),
                REQ_TYPE = 1.ToString(),
                PAY_TOOL = 0.ToString(),
                TERM_ID = 12345.ToString(),
                COMMENT = "test",
                ACCEPT_KEYS = "000141982",
                NO_ROUTE = "1"
            };
            gateway.SendAcknowledgementRequest(message);
        }
    }
}
