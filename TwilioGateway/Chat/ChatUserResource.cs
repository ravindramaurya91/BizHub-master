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
    public  class ChatUserResource
    {
        #region Fields
        private string _accountID = "";
        private string _chatServiceSID = "";
        private string _authToken = "";
        #endregion (Fields)

        public ChatUserResource()
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



        #region Create User
        public object CreateUserResource(string identity, string friendlyName = null, string roleSid = null, string attributes = null)
        {
            //>CGVAK - Here we should pass identity parameter as unique name(that can be unique name or unique emaild)
            // Other parameters are optional
            // Twilio will return user details with unqiue generated Sid. Example User Unique Sid = US92c17159727042bd84bcfca9e9468127


            // 1) Create a new User Resource on Twilio
            // 2) Get Twilio's User Account Id
            // 3) Store the Twilio User Account ID in the BizHub database

            CreateUserOptions createUserOptions = new CreateUserOptions(_chatServiceSID, identity);
            createUserOptions.FriendlyName = friendlyName;
            createUserOptions.RoleSid = roleSid;
            createUserOptions.Attributes = attributes;
            var user = UserResource.Create(createUserOptions);
            return user;
        }
        #endregion

        #region Update User
        public object UpdateUserResource(string identity, string friendlyName = null, string roleSid = null, string attributes = null)
        {
            //>CGVAK - identity parameter this value can be either the Sid(US92c17159727042bd84bcfca9e9468127) or the identity of the User(UserName which we passed to create user) resource to fetch.
            // Other parameters are optional

            // 1) Update User Resource on Twilio
            // 2) Store the Twilio User Account details in the BizHub database

            UpdateUserOptions updateUserOptions = new UpdateUserOptions(_chatServiceSID, identity);
            updateUserOptions.FriendlyName = friendlyName;
            updateUserOptions.RoleSid = roleSid;
            updateUserOptions.Attributes = attributes;
            var user = UserResource.Update(updateUserOptions);
            return user;

        }
        #endregion


        #region Fetch User
        public object FetchUserResource(string identity)
        {
            //>CGVAK - identity parameter this value can be either the Sid(US92c17159727042bd84bcfca9e9468127) or the identity of the User(UserName which we passed to create user) resource to fetch.

            // 1) Fetch User Resource From Twilio
            var user = UserResource.Fetch(_chatServiceSID, identity);
            return user;
        }
        #endregion

        #region Fetch All User
        public object FetchAllUserResource()
        {
            // 1) Fetch All User Resource From Twilio
            var userList = UserResource.Read(_chatServiceSID);
            return userList;
        }
        #endregion

        #region Delete User
        public bool DeleteUserResource(string identity)
        {
            //>CGVAK - identity parameter this value can be either the Sid(US92c17159727042bd84bcfca9e9468127) or the identity of the User(UserName which we passed to create user) resource to fetch.

            // 1) Delete User Resource From Twilio
            var result = UserResource.Delete(_chatServiceSID, identity);
            return result;
        }
        #endregion
    }
}
