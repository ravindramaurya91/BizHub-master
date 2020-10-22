using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Core;

namespace CommonUtil {
    public class TwilioSMS : TwilioController
    {
        public static void SendMessage(SMSMessage toMsg) {
            // Use your account SID and authentication token instead
            // of the placeholders shown here.
            const string accountSID = "AC98412f8c26b4111d7ef5285223996d89";
            const string authToken = "bdd4ef7699fc6d853b319439d8ef3a26";
            PhoneNumber oFromNumber = new PhoneNumber("+16502001983"); // The Twilio reserved phone number for BizHub

            try {
                // Initialize the TwilioClient.
                TwilioClient.Init(accountSID, authToken);

                try {
                    // Send an SMS message.
                    foreach (PhoneNumber oRecipient in toMsg.To) {
                        var message = MessageResource.Create(
                            to: oRecipient,
                            from: oFromNumber,
                            body: toMsg.Message);

                    }
                } catch (TwilioException ex) {
                    // An exception occurred making the REST call
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        public void SendMessage_Test() {
            // Use your account SID and authentication token instead
            // of the placeholders shown here.
            const string accountSID = "AC98412f8c26b4111d7ef5285223996d89";
            const string authToken = "bdd4ef7699fc6d853b319439d8ef3a26";
            try {
                // Initialize the TwilioClient.
                TwilioClient.Init(accountSID, authToken);

                try {
                    string sKeaten = "+12096138971";
                    string sMelissa = "+12099880012";
                    string sSteven = "+12099969495";

                    // Send an SMS message.
                    var message = MessageResource.Create(
                        to: new PhoneNumber(sMelissa),
                        from: new PhoneNumber("+16502001983"),
                        body: "This is your first SMS message delivered by BizHub.  :)");



                } catch (TwilioException ex) {
                    // An exception occurred making the REST call
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

     }
}
