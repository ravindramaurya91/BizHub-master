using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Chat.V2.Service;
using System.Threading.Tasks;
using Twilio.Rest.Chat.V2.Service.Channel;
using Base;
using Microsoft.Extensions.Configuration;
using Twilio.Rest.Chat.V2.Service.User;
using System.Linq;

namespace TwilioGateway
{
   public class ChatUserChannelResource
    {
        #region Fields
        private string _accountID = "";
        private string _chatServiceSID = "";
        private string _authToken = "";
        #endregion (Fields)
        public ChatUserChannelResource()
        {
            var config = Context.Get<IConfiguration>();
            var section = config.GetSection("TwilioSetup");
            _accountID = section.GetValue<string>("AccountSID");
            _authToken = section.GetValue<string>("AuthToken");
            _chatServiceSID = section.GetValue<string>("ChatServiceSID");

            TwilioClient.Init(_accountID, _authToken);
            
            //const string accountSid = "AC98412f8c26b4111d7ef5285223996d89";
            //const string authToken = "bdd4ef7699fc6d853b319439d8ef3a26";
            //const string chatServiceId= "IS1753cf77305948839d394449c07f7a67"
        }

        #region Fetch User Channel
        public List<UserChannelResource> FetchUserChannelResource(string identity)
        {
            //>CGVAK - identity parameter this value can be either the Sid(US92c17159727042bd84bcfca9e9468127) or the identity of the User(UserName which we passed to create user) resource to fetch.

            // 1) Fetch User Resource From Twilio
           var userChannels = UserChannelResource.Read(
            pathServiceSid: _chatServiceSID,
            pathUserSid: identity
                ).ToList();

            return userChannels;
        }
        #endregion
    }
}
