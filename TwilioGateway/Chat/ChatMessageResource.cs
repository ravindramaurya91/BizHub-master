using Twilio;
using Twilio.Rest.Chat.V2.Service;
using System.Threading.Tasks;
using Twilio.Rest.Chat.V2.Service.Channel;
using Base;
using Microsoft.Extensions.Configuration;
using System;
using Amazon.SQS.Model;
using Twilio.AspNet.Common;
using System.Linq;
using System.Collections.Generic;

namespace TwilioGateway
{
   public class ChatMessageResource
    {
        #region Fields
        private string _accountID = "";
        private string _chatServiceSID = "";
        private string _authToken = "";
        #endregion (Fields)
        public ChatMessageResource()
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

        #region Create Message
        public MessageResource CreateMessageResource(string channelSid, string userIdentity, string body, string attributes = null, DateTime? dateCreated = null, DateTime? dateUpdated = null, string lastUpdatedBy = null, string mediaSid = null)
        {
            //CGVAK - Parameter channelSid value should be channel id(ex:CHfc099107f5b2453b9c072496b8f1df3c)
            //Parameter userIdentity is the member name of the channel that should be unique name(Ex: Lee)
            //Parameter body is the Message text
            //Other parameters are optional

            // 1) Create a new Message Resource on Twilio
            // 2) Update on chat window


            CreateMessageOptions createMessageOptions = new CreateMessageOptions(_chatServiceSID, channelSid);
            createMessageOptions.From = userIdentity;
            createMessageOptions.Body = body;
            createMessageOptions.Attributes = attributes;
            createMessageOptions.DateCreated = dateCreated;
            createMessageOptions.DateUpdated = dateUpdated;
            createMessageOptions.LastUpdatedBy = lastUpdatedBy;
            createMessageOptions.MediaSid = mediaSid;


            var message = MessageResource.Create(createMessageOptions);
            return message;
        }
        #endregion

        #region Update Message
        public object UpdateMessageResource(string messageSid,string channelSid, string userIdentity, string body, string attributes = null, DateTime? dateCreated = null, DateTime? dateUpdated = null, string lastUpdatedBy = null, string mediaSid = null)
        {
            //CGVAK - Parameter channelSid value should be channel id(ex:CHfc099107f5b2453b9c072496b8f1df3c)
            //Parameter userIdentity is the member name of the channel that should be unique name(Ex: Lee)
            //Parameter body is the Message text
            //Parameter message id is the Message id in twilio
            //Other parameters are optional

            // 1) Update a new Message Resource on Twilio
            // 2) Update on chat window


            UpdateMessageOptions updateMessageOptions = new UpdateMessageOptions(_chatServiceSID, channelSid, messageSid);
            updateMessageOptions.From = userIdentity;
            updateMessageOptions.Body = body;
            updateMessageOptions.Attributes = attributes;
            updateMessageOptions.DateCreated = dateCreated;
            updateMessageOptions.DateUpdated = dateUpdated;
            updateMessageOptions.LastUpdatedBy = lastUpdatedBy;

            var message = MessageResource.Update(updateMessageOptions);
            return message;
        }
        #endregion

        #region Fetch Message
        public object FetchMessageResource(string channelSid, string messageSid)
        {
            //CGVAK - Parameter channelSid value should be channel id(ex:CHfc099107f5b2453b9c072496b8f1df3c)
            //Parameter messageSid is the id of the message

            // 1) Fetch Message Resource from Twilio

            var message = MessageResource.Fetch(_chatServiceSID, channelSid, messageSid);
            return message;
        }
        #endregion


        #region Fetch All Message
        public List<MessageResource> FetchAllMessageResource(string channelSid)
        {
            //CGVAK - Parameter channelSid value should be channel id(ex:CHfc099107f5b2453b9c072496b8f1df3c)

            // 1) Fetch All Message Resource from Twilio
            // 2) Update on the chat window

            var message = MessageResource.Read(_chatServiceSID, channelSid).ToList();
            return message;
        }
        #endregion

        #region Delete Message
        public bool DeleteMessageResource(string channelSid, string userIdentity)
        {
            //CGVAK - Parameter channelSid value should be channel id(ex:CHfc099107f5b2453b9c072496b8f1df3c)
            //Parameter userIdentity is the member name of the channel that should be unique name(Ex: Lee)

            // 1) Fetch Message Resource from Twilio
            var result = MessageResource.Delete(_chatServiceSID, channelSid, userIdentity);
            return result;
        }
        #endregion
    }
}
