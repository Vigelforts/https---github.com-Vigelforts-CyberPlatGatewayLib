using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberPlatGateway.Messages;
using CyberPlatGateway.Test;
using CyberPlatGateway.Test.Messages;

namespace CyberPlatGateway
{
   public class CyberPlatGateway<TSessionProtocol>
       where TSessionProtocol:TestCyberPlatSessionProtocol,new()
   {
       private readonly TSessionProtocol _sessionProtocol;
       private PaymentRequestBase _requestBase;
       private bool _onlyAckCheck;
       public event EventHandler notifyPaymentSucceed;
       public event EventHandler<CyberPlatException> NotifyPaymentFailed;

       public CyberPlatGateway()
       {
           _sessionProtocol = new TSessionProtocol();
           _onlyAckCheck = false;
           _sessionProtocol.MessageReceived += ProcessMessage;
       }

       private void ProcessMessage(object sender, PaymentAnswerBase e)
       {
           try
           {
               if (e.ERROR != 0) throw new CyberPlatException(e.ERROR);
               if (e is PaymentAckAnswer)
               {
                   if (_onlyAckCheck)
                   {
                       return;
                   }
                   var paymentRequest = _requestBase as PaymentRequest;
                   SendPaymentRequest(paymentRequest);

               }
               if (e is PaymentAnswer)
               {
                   if (notifyPaymentSucceed != null)
                   {
                       notifyPaymentSucceed.Invoke(this, new EventArgs());
                   }

               }
               else
               {
                   //;
               }
           }
           catch (CyberPlatException exception)
           {
               if (NotifyPaymentFailed!=null)
               {
                   NotifyPaymentFailed.Invoke(this, exception);   
               }
               
           }
       }

       public void SendAcknowledgementRequest(PaymentAckRequest request)
       {
           _requestBase = request;
           if (request.REQ_TYPE == "1")
           {
               _onlyAckCheck = true;
           }
           _sessionProtocol.SendMessage(request);
       }

       private void SendPaymentRequest(PaymentRequest request)
       {
           request.DATE = DateTime.UtcNow.ToLongDateString();
           _sessionProtocol.SendMessage(request);
       }

       public void SendCheckPaymentStatusRequest(CheckPaymentStatusRequest request)
       {
           
       }

       public void SendAccountBalanceRequest(AccountBalanceRequest request)
       {
           
       }
   }
}
