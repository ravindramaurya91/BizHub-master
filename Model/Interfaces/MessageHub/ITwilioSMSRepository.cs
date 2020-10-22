using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace Model.Interfaces
{
    public interface ITwilioSMSRepository
    {
        void TwilioSMSCreate(SMSMessage_Model objsms);
        void UpdateSMS(SMSMessage_Model smsModel);

        TwiMLResult TwilioSMSReceive(SMSMessageResponse_Model objSMSMessageResponse_Model);
        
    }
}
