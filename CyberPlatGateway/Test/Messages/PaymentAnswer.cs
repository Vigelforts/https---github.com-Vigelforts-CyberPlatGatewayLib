using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberPlatGateway.Messages;

namespace CyberPlatGateway.Test.Messages
{
    public class PaymentAnswer:PaymentAnswerBase
    {


        public PaymentAnswer(string str)
        {
            var segments = str.Split('\n');

            foreach (var segment in segments)
            {
                if (segment.IndexOf('=') == -1)
                {
                    continue;
                }

                string segmentName = segment.Substring(0, segment.IndexOf('='));
                string segmentValue = segment.Substring(segment.IndexOf('=') + 1);
                segmentValue = segmentValue.Remove(segmentValue.IndexOf('\r'));
                switch (segmentName)
                {
                    case "DATE":
                        this.DATE = segmentValue;
                        break;
                    case "SESSION":
                        this.SESSION = segmentValue;
                        break;
                    case "ERROR":
                        this.ERROR = Int32.Parse(segmentValue);
                        break;
                    case "RESULT":
                        this.RESULT = segmentValue;
                        break;
                    case "TRANSID":
                        this.TRANSID = segmentValue;
                        break;
                    case "GATEWAY_IN":
                        this.GATEWAY_IN = segmentValue;
                        break;
                    case "GATEWAY_OUT":
                        this.GATEWAY_OUT = segmentValue;
                        break;
                }
            }
        }
    }
}
