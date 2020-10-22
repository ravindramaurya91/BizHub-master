using Base;
using Microsoft.Extensions.Configuration;
using System;
using Amazon.SQS.Model;
using Twilio.AspNet.Common;
using System.Linq;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TwilioGateway
{
    public class SMSResource
    {
        #region Fields
        private string _accountID = "";
        private string _messageServiceID = "";
        private string _authToken = "";
        #endregion (Fields)

        public SMSResource()
        {
            var config = Context.Get<IConfiguration>();
            var section = config.GetSection("TwilioSetup");
            _accountID = section.GetValue<string>("AccountSID");
            _authToken = section.GetValue<string>("AuthToken");
            _messageServiceID = section.GetValue<string>("MessageServiceID");

            TwilioClient.Init(_accountID, _authToken);
        }

        #region Send SMS
        public MessageResource SendSMS(string toPhoneNumber, string messageBody)
        {
            var message = MessageResource.Create(
            body: messageBody,
            messagingServiceSid: _messageServiceID,
            to: new Twilio.Types.PhoneNumber(toPhoneNumber));

            return message;
        }
        #endregion

    }
}
