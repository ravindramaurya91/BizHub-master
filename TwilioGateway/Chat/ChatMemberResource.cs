using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Chat.V2.Service;
using System.Threading.Tasks;
using Twilio.Rest.Chat.V2.Service.Channel;
using Base;
using Microsoft.Extensions.Configuration;
using System.IO;
using Twilio.Rest.Chat.V2.Service.User;

namespace TwilioGateway
{
   public class ChatMemberResource
    {
        #region Fields
        private string _accountID = "";
        private string _chatServiceSID = "";
        private string _authToken = "";
        #endregion (Fields)
        public ChatMemberResource()
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

        #region Create Member
        public object CreateMemberResource(string channelSid, string userIdentity, string roleSid = null, int? lastConsumedMessageIndex = null, DateTime? lastConsumptionTimestamp = null, DateTime? dateCreated = null, DateTime? dateUpdated = null, string attributes = null)
        {
            //CGVAK - Parameter channelSid value should be channel id(ex:CHfc099107f5b2453b9c072496b8f1df3c)
            //Parameter userIdentity is the member name of the channel that should be unique name(Ex: Lee)
            //Other parameters are optional
            
            // 1) Create a new Member Resource on Twilio
            // 2) Get Twilio's Member Id
            // 3) Store the Twilio Member ID in the BizHub database

            CreateMemberOptions createMemberOptions = new CreateMemberOptions(_chatServiceSID, channelSid, userIdentity);
            createMemberOptions.RoleSid = roleSid;
            createMemberOptions.LastConsumedMessageIndex = lastConsumedMessageIndex;
            createMemberOptions.LastConsumptionTimestamp = lastConsumptionTimestamp;
            createMemberOptions.DateCreated = dateCreated;
            createMemberOptions.DateUpdated = dateUpdated;
            createMemberOptions.Attributes = attributes;

            var member = MemberResource.Create(createMemberOptions);
            return member;
        }
        #endregion

        #region Update Member
        public object UpdateMemberResource(string channelSid, string userIdentity, string roleSid = null, int? lastConsumedMessageIndex = null, DateTime? lastConsumptionTimestamp = null, DateTime? dateCreated = null, DateTime? dateUpdated = null, string attributes = null)
        {
            //CGVAK - Parameter channelSid value should be channel id(ex:CHfc099107f5b2453b9c072496b8f1df3c)
            //Parameter userIdentity is the member name of the channel that should be unique name(Ex: Lee)
            //Other parameters are optional

            // 1) Update a new Member Resource on Twilio
            // 2) Update the Twilio Member details in the BizHub database

            UpdateMemberOptions updateMemberOptions = new UpdateMemberOptions(_chatServiceSID, channelSid, userIdentity);
            updateMemberOptions.RoleSid = roleSid;
            updateMemberOptions.LastConsumedMessageIndex = lastConsumedMessageIndex;
            updateMemberOptions.LastConsumptionTimestamp = lastConsumptionTimestamp;
            updateMemberOptions.DateCreated = dateCreated;
            updateMemberOptions.DateUpdated = dateUpdated;
            updateMemberOptions.Attributes = attributes;

            var member = MemberResource.Update(updateMemberOptions);
            return member;
        }
        #endregion

        #region Fetch Member
        public object FetchMemberResource(string channelSid, string userIdentity)
        {
            //CGVAK - Parameter channelSid value should be channel id(ex:CHfc099107f5b2453b9c072496b8f1df3c)
            //Parameter userIdentity is the member name of the channel(Ex: Lee)

            // 1) Fetch Member Resource From Twilio
            var member = MemberResource.Fetch(_chatServiceSID, channelSid, userIdentity);
            return member;
        }
        #endregion

        #region Fetch All Member
        public object FetchAllMemberResource(string channelSid)
        {
            //CGVAK - Parameter channelSid value should be channel id(ex:CHfc099107f5b2453b9c072496b8f1df3c)

            // 1) Fetch All Member Resource From Twilio
            var members = MemberResource.Read(_chatServiceSID, channelSid);
            return members;
        }
        #endregion

        #region Delete Member
        public bool DeleteMemeberResource(string channelSid, string userIdentity)
        {
            //CGVAK - Parameter channelSid value should be channel id(ex:CHfc099107f5b2453b9c072496b8f1df3c)

            // 1) Delete Member Resource From Twilio
            var result = MemberResource.Delete(_chatServiceSID, channelSid,userIdentity);
            return result;
        }
        #endregion

    }
}
