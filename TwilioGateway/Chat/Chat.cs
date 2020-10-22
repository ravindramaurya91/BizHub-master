using System;
using System.Collections.Generic;
using System.Text;

using Base;
using Microsoft.Extensions.Configuration;
using Twilio;

namespace TwilioGateway {
    public class Chat {

        #region Fields
        private string _accountID = "";
        private string _chatServiceSID = "";
        private string _authToken = "";
        #endregion (Fields)

        public Chat() {
            var config = Context.Get<IConfiguration>();
            var section = config.GetSection("TwilioSetup");
            _accountID = section.GetValue<string>("AccountSID");
            _authToken = section.GetValue<string>("AuthToken");
            _chatServiceSID = section.GetValue<string>("ChatServiceSID");
            TwilioClient.Init(_accountID, _authToken);
        }

        #region Create User
        public object CreateUserAccount() {
            // 1) Create a new User Resource on Twilio
            // 2) Get Twilio's Uaser Account Id
            // 3) Store the Twilio User Account ID in the BizHub database

            //TwilioClient.Init(_accountID, _authToken);
            //CreateUserOptions createUserOptions = new CreateUserOptions(_chatServiceSID, "SathishKumar");
            //var user = UserResource.Create(createUserOptions, null);

            return null;
        }
        #endregion

        #region Fetch User 
        public object GetUserResource(string tsPathSid) {
            // What is the Path Service Sid?  
            // Where dis it come from?  
            // I'm guessing it is the individual user's ID assigned by Twilio when the User Resource was created?

            // This method will connect to Twilio and return a User Resource (whatever type of object that is)
            //var userFetch = UserResource.Fetch(
            //pathServiceSid: "IS1753cf77305948839d394449c07f7a67",
            //pathSid: "US92c17159727042bd84bcfca9e9468127"
            //);

            return null;
        }
        #endregion

        #region Create Channel
        //var channel = ChannelResource.Create("IS1753cf77305948839d394449c07f7a67", "cgvakprivate", "cgvakprivate", null, ChannelResource.ChannelTypeEnum.Private);
        public ChatChannel CreateChannel() {
            // We may need to pass in the list of individuals on the channel or at least the originator of the channel request
            // 1) Create a new Channel
            // 2) return the channel object to the calling routine
            //var channel = ChannelResource.Create("IS1753cf77305948839d394449c07f7a67", "cgvakprivate", "cgvakprivate", null, ChannelResource.ChannelTypeEnum.Private);
            return null;
        }
        #endregion


        #region Fetch Channel 
        public ChatChannel GetChannel(string tsChannelID) {
            // var channel = ChannelResource.Fetch(
            //pathServiceSid: "IS1753cf77305948839d394449c07f7a67",
            //pathSid: "CHfc099107f5b2453b9c072496b8f1df3c"
            //  );

            // Get channel data from Twilio & instantiate a ChatChannel object with the data
            // then return the ChatrChannel object
            return null;
        }
        #endregion

 
        // NOTE; We should have a Twilio User object that we can pass around to the various methods that will carry the needed Twilio information
        // We should also have a TwilioChannel object that keeps track of the current Channel info and can pass top the SendMessage() method.
        // Once we establish the Channel object we will use it to send and receive messages on that channel.






    }
}
