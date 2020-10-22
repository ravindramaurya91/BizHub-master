using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Chat.V2.Service;
using System.Threading.Tasks;
using Twilio.Rest.Chat.V2.Service.Channel;
using Base;
using Microsoft.Extensions.Configuration;

namespace TwilioGateway
{
    public class ChatChannelResource
    {
        #region Fields
        private string _accountID = "";
        private string _chatServiceSID = "";
        private string _authToken = "";
        #endregion (Fields)
        public ChatChannelResource()
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

        #region Create Channel
        public object CreateChannelResource(string friendlyName = null, string attributes = null,string type  = null, DateTime? dateCreated = null, DateTime? dateUpdated = null, string createdBy = null)
        {
            //>CGVAK - Here all parameters are optional

            // 1) Create a new Channel Resource on Twilio
            // 2) Get Twilio's Channel Id
            // 3) Store the Twilio Channel ID in the BizHub database

            CreateChannelOptions createChannelOptions = new CreateChannelOptions(_chatServiceSID);
            createChannelOptions.FriendlyName = friendlyName;
            createChannelOptions.Attributes = attributes;
            createChannelOptions.Type = type.ToLower() == "public"? ChannelResource.ChannelTypeEnum.Public: ChannelResource.ChannelTypeEnum.Private;
            createChannelOptions.DateCreated = dateCreated;
            createChannelOptions.DateUpdated = dateUpdated;
            createChannelOptions.CreatedBy = createdBy;
            
            var channel = ChannelResource.Create(createChannelOptions);
            return channel;
        }
        #endregion


        #region Update Channel
        public object UpdateChannelResource(string channelId,string friendlyName=null, string attributes = null, string type = null, DateTime? dateCreated = null, DateTime? dateUpdated = null, string createdBy = null)
        {
            //>CGVAK - channelId parameter this value can be either the channel Sid(CHfc099107f5b2453b9c072496b8f1df3c) or the identity of the channel name( ex: BizhubPrivate).
            //Update the channel on twilio and store the twilio channel details in the BizHub database
            //Other parameters are optional

            UpdateChannelOptions updateChannelOptions = new UpdateChannelOptions(_chatServiceSID, channelId);
            updateChannelOptions.FriendlyName = friendlyName;
            updateChannelOptions.Attributes = attributes;
            updateChannelOptions.DateCreated = dateCreated;
            updateChannelOptions.DateUpdated = dateUpdated;
            updateChannelOptions.CreatedBy = createdBy;

            var channel = ChannelResource.Update(updateChannelOptions);
            return channel;
        }
        #endregion

        #region Fetch Channel
        public object FetchChannelResource(string channelId)
        {
            //>CGVAK - channelId parameter this value can be either the channel Sid(CHfc099107f5b2453b9c072496b8f1df3c) or the identity of the channel name( ex: BizhubPrivate).

            // 1) Fetch a Channel Resource From Twilio
            var channel = ChannelResource.Fetch(_chatServiceSID, channelId);
            return channel;
        }
        #endregion

        #region Fetch All Channel
        public object FetchAllChannelResource()
        {
            // 1) Fetch All Channel Resource From Twilio
            var channelList = ChannelResource.Read(_chatServiceSID);
            return channelList;
        }
        #endregion

        #region Delete Channel
        public bool DeleteChannelResource(string channelId)
        {
            //>CGVAK - channelId parameter this value can be either the channel Sid(CHfc099107f5b2453b9c072496b8f1df3c) or the identity of the channel name( ex: BizhubPrivate).

            // 1) Delete Channel 
            var channelList = ChannelResource.Delete(_chatServiceSID, channelId);
            return channelList;
        }
        #endregion

    }
}
