﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberPlatGateway.Messages;

namespace CyberPlatGateway.Test.Messages
{
    public class PaymentRequest:PaymentRequestBase
    {

        public string DATE;
        public string TERM_ID;
        public string RRN;

        public override string ToString()
        {
            return ("BEGIN" + "\\r\\n" + "SD=" + SD + "\\r\\n" + "AP=" + AP + "\\r\\n" + "OP=" + OP + "\\r\\n" + "SESSION=" + SESSION + "\\r\\n" + "NUMBER=" + NUMBER + "\\r\\n" + "ACCOUNT=" + ACCOUNT + "\\r\\n" + "AMOUNT=" + AMOUNT + "\\r\\n" +
                    "AMOUNT_ALL=" + AMOUNT_ALL + "\\r\\n" + "DATE=" + DATE + "\\r\\n" + "PAY_TOOL=" + PAY_TOOL + "\\r\\n" + "TERM_ID" + TERM_ID + "\\r\\n" + "RRN=" + RRN + "\\r\\n" +
                   "ACCEPT_KEYS=" + ACCEPT_KEYS + "\\r\\n" + "NO_ROUTE=" + NO_ROUTE + "\\r\\n" + "END");
        }
    }
}
