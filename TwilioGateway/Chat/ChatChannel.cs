using System;
using System.Collections.Generic;
using System.Text;
using Twilio.Rest.Api.V2010;

namespace TwilioGateway {
    public class ChatChannel {

        #region Events
        public event EventHandler OnNewMessageReceived;
        #endregion (Events)

        #region Fields
        private List<ChatMessage> _messages = new List<ChatMessage>();
        #endregion (Fields)


        #region Methods
        #region Create member under the channel
        public object AddMemberToChannel(TwilioUser toUser) {
            //   var members = MemberResource.Create(
            //identity: "Lee",
            //pathServiceSid: "IS1753cf77305948839d394449c07f7a67",
            //pathChannelSid: "CHfc099107f5b2453b9c072496b8f1df3c"
            //);
            return null;
        }
        #endregion

        #region Fetch member list under the channel
        public object GetChannelMemberList(string tsChannelID) {
            // var membersFetch = MemberResource.Read(
            //pathServiceSid: "IS1753cf77305948839d394449c07f7a67",
            //pathChannelSid: "CHfc099107f5b2453b9c072496b8f1df3c",
            //limit: 20
            // );

            // Get the list of members into an object and return the list
            return null;
        }
        #endregion

        #region Send or Create message to the channel
        public object SendMessage(ChatMessage toMessage ) {
            toMessage.Sender = this.Sender;
            toMessage.DateSent = DateTime.UtcNow;
            _messages.Add(toMessage);
            //CreateMessageOptions createMessageOptions = new CreateMessageOptions("IS1753cf77305948839d394449c07f7a67", "CHfc099107f5b2453b9c072496b8f1df3c");
            //createMessageOptions.From = "SathishKumar";
            //createMessageOptions.Body = "This is test message from SathishKumar " + DateTime.Now;
            //var message = MessageResource.Create(createMessageOptions, null);

            //createMessageOptions.From = "Mani";
            //createMessageOptions.Body = "This is test message from Mani " + DateTime.Now;
            //var message1 = MessageResource.Create(createMessageOptions, null);

            //createMessageOptions.From = "Lee";
            //createMessageOptions.Body = "This is test message from Lee " + DateTime.Now;
            //var message2 = MessageResource.Create(createMessageOptions, null);

            //createMessageOptions.From = "Krishna";
            //createMessageOptions.Body = "This is test message from Krishna " + DateTime.Now;
            //var message3 = MessageResource.Create(createMessageOptions, null);
            return null;
        }
        #endregion


        #region Read message from channel
        public object ReadMessageFromChannel() {
            //var readmessages = MessageResource.Read(
            //pathServiceSid: "IS1753cf77305948839d394449c07f7a67",
            //pathChannelSid: "CHfc099107f5b2453b9c072496b8f1df3c",
            //limit: 20
            //);
            //foreach (var record in readmessages)
            //{
            //    Console.WriteLine(record.From + ": " + record.Body);
            //}

            // Get the messages from the channel
            // Create a ChatMessage object for each
            // Add them to the channel's list of messages
            // throw an event that a message has arrived

            OnNewMessageReceived?.Invoke(this, null);
            return null;
        }
        #endregion

        #endregion (Methods)

        #region Properties
        public string ChannelId { get; set; }
        public TwilioUser Sender { get; set; }
        public List<ChatMessage> Messages { get=> _messages; set=> _messages = value; }
        #endregion (Properties) 
    } 
 }
