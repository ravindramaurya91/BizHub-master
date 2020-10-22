using System;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

using Amazon;

using BizHub.Service;
using CommonUtil;
using Base;
using Model;
using System.Reflection.Metadata;
using System.Net.Http;

using TwilioGateway;
using System.Reflection;
using AngleSharp;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Linq.Expressions;
using Twilio.Exceptions;
using DocumentFormat.OpenXml.Drawing;
using BizHub;
using Model;
using Model.Interfaces;
using Microsoft.JSInterop;
using Twilio.Jwt.Client;
using Twilio.Jwt;

namespace TestUtilities {
    public class TestTwilio {

        #region Setup / Tear down
        [SetUp]
        public void InitializeTestHarness() {
            Initialization.BuildServiceProvider();
        }

        [TearDown]
        public void TearDown() {
            // Noithing to do here
        }

        #endregion Setup / Tear down


        [Test]
        public void Test_01_CreateNewTwilioUser_And_SendMessage() {
            // 1) Create an account and get a User object back to work with
            // The following is a mock up of what it might be like.

            // I can't spec it because there is not enough in the Program.cs yet to understand the interactions with Twilio
            // Please use this as a guide only.  Hopefully it will present the architectural pattern I am hoping we can build
            TwilioGateway.Chat oChatSession = new Chat();
            var TwilioUser1 = oChatSession.CreateUserAccount();


            //2) Retrieve an existing UserResource from Twilio using the TwilioID we saved from step 1
            TwilioUser oTestUser = new TwilioUser() { Name = "Satish", TwilioID = "xxxxx" };
            var TwilioUser2 = oChatSession.GetUserResource(oTestUser.TwilioID);


            // 3) Create a new Channel
            var TwilioReturn = oChatSession.CreateChannel();
            ChatChannel oNewChannel = new ChatChannel();


            // get a TwilioUser object to represent the sender
            // In the future we will pull the Twilio Name and ID from the BizHub database.
            // For now we can just hard code the name & ID
            TwilioUser oUser2 = new TwilioUser() { Name = "Satish", TwilioID = "xxxxx" };
            // Use the TwilioUser object to setup a channel
            ChatChannel channel = oChatSession.CreateChannel();

            // When we get the Channel back after creation we will store the Channel ID in the database.
            // Later we can use that ID to reconnect to the channel.
            string sChannelId = "xxxx";
            ChatChannel channel2 = oChatSession.GetChannel(sChannelId);
            channel2.Sender = oUser2;

            channel2.AddMemberToChannel(oUser2);
            channel2.SendMessage(new ChatMessage("This is the new text message"));
            channel2.ReadMessageFromChannel();

        }
        [Test]
        public void Test_02_TwilioVoiceCall() {
            // Role Values can be "support_agent" or "customer"
            // Use your account SID and authentication token instead
            // of the placeholders shown here.
            const string accountSID = "AC98412f8c26b4111d7ef5285223996d89";
            const string authToken = "bdd4ef7699fc6d853b319439d8ef3a26";
            try {

                // Initialize the TwilioClient.
                TwilioClient.Init(accountSID, authToken);

                // Use the Twilio-provided site for the TwiML response.
                var url = "https://twimlets.com/message";
                url = $"{url}?Message%5B0%5D=Hello%20World";

                // Set the call From, To, and URL values to use for the call.
                // This sample uses the sandbox number provided by
                // Twilio to make the call.
                var call = CallResource.Create(
                    to: new PhoneNumber("+12095957845"),
                    from: new PhoneNumber("+12099969495"),
                    url: new Uri(url));
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

        }
    
        [Test]
        public void Test_03_TwilioSMS() {
            try {
                List<string> oRecipients = new List<string>() { "+91 8668297251" };
                SMSMessage oMsg = new SMSMessage("This is a test message from BizHub framework", oRecipients);
                TwilioSMS.SendMessage(oMsg);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
       [Test]
        public async Task Test_05_SendGridTest() {
            try {
                SendGridManager oMgr = new SendGridManager();
                await oMgr.SendMailTest();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        //Send SMS
        [Test]
        public void Test_06_SendSMS() {
            try {
                SMSMessage_Model obj = new SMSMessage_Model();
                obj.FromNumber = "+16502001983";
                obj.ToNumber = "+12099969495";
                obj.Body = "Hi";
                TwilioSMSRepository objs = new TwilioSMSRepository("AC98412f8c26b4111d7ef5285223996d89", "bdd4ef7699fc6d853b319439d8ef3a26", "MG9f048b838620d8e04a5efa7c186a1af4", "");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        //MakeVoiceCall
        [Test]
        public async Task Test_07_MakeVoiceCall() {
            try {
                //Assign value from bizhub project
                IJSRuntime jsRuntime = null;

                //Get Token
                var token = GetToken();

                //Initialize Setup
                await jsRuntime.InvokeVoidAsync("Twilio.Device.setup", token);


                //Make Sure you have API project with the following POST method to connect the call
                //API Url must be configured with the twilio
                //Following URL configured with our twilio account
                //https://twiliocommunication.conveyor.cloud/api/twiliobackend/voice

                //_____________________________________________________________________________
                //[HttpPost("voice")]
                //public async Task<IActionResult> PostVoiceRequest([FromForm] string phone)
                //{
                //    var destination = !phone.StartsWith('+') ? $"+{phone}" : phone;

                //    var response = new VoiceResponse();
                //    var dial = new Twilio.TwiML.Voice.Dial
                //    {
                //        CallerId = PhoneNumber
                //    };
                //    dial.Number(new PhoneNumber(destination));

                //    response.Append(dial);

                //    return await Task.FromResult(Content(response.ToString(), "application/xml"));
                //}
                //_____________________________________________________________________________

                //Call this method to initiate call
                await jsRuntime.InvokeVoidAsync("Twilio.Device.connect", new IM { phone = "12095957845" });

                //Call this method to disconnect call
                await jsRuntime.InvokeVoidAsync("Twilio.Device.disconnectAll");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task<string> GetToken() {
            string AccountSid = "AC98412f8c26b4111d7ef5285223996d89";
            string AuthToken = "bdd4ef7699fc6d853b319439d8ef3a26";
            string AppSid = "AP18bf72b4ad2baa77978480553ed9a7b1";
            var scopes = new HashSet<IScope>
            {
                new OutgoingClientScope(AppSid),
                new IncomingClientScope("UserName")
            };
            var capability = new ClientCapability(AccountSid, AuthToken, scopes: scopes);
            return await Task.FromResult(capability.ToJwt());
        }

        public class IM {
            public string phone { get; set; }
        }

    }
}

