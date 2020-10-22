using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.AspNet.Common;
using Microsoft.AspNetCore.Mvc;

namespace Model.Interfaces
{
    public class TwilioSMSRepository : TwilioController, ITwilioSMSRepository
    {
        #region Variables
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _dbConnectionString;
        private readonly string _messageServiceId;

        #endregion

        #region Constructor
        public TwilioSMSRepository(string accountSid, string authToken, string messageServiceId, string dbConnectionString)
        {
            _accountSid = accountSid;
            _authToken = authToken;
            _dbConnectionString = dbConnectionString;
            _messageServiceId = messageServiceId;
        }
        #endregion

        #region Methods

        //Send SMS
        public void TwilioSMSCreate(SMSMessage_Model objsms)
        {
            TwilioClient.Init(_accountSid, _authToken);

            var message = MessageResource.Create(
            body: objsms.Body,
            messagingServiceSid: _messageServiceId,
            from: new Twilio.Types.PhoneNumber(objsms.FromNumber),
            to: new Twilio.Types.PhoneNumber(objsms.ToNumber),
            statusCallback: new Uri("http://postb.in/1234abcd")
            );

            //InsertSMS(message);
            //objsms.MessageSid = message.Sid;
            //objsms.ErrorCode = message.ErrorCode;
            //objsms.ErrorMessage = message.ErrorMessage;
            //objsms.CreatedDate = message.DateCreated;
            //objsms.UpdatedDate = message.DateUpdated;
            //objsms.MessagingServiceSid = message.MessagingServiceSid;
        }

        //Insert SMS Details
        public void InsertSMS(MessageResource message)
        {
            try
            {

                string query = "";
                Guid SMSId = Guid.Empty;

                query = "INSERT INTO TblSMS (Id,FromNumber,ToNumber,MessageContent,Status,ErrorCode, " +
                " ErrorStatus,RetryCount,CreatedDate,CreatedBy,MessageId) VALUES " +
                " ('" + Guid.NewGuid() + "','" + message.From + "','" + message.To + "','" + message.Body + "','" + message.Status + "','" + message.ErrorCode + "', " +
                " '" + message.ErrorMessage + "','" + 0 + "', '" + message.DateCreated + "','" + message.AccountSid + "','" + message.Sid + "')";

                using (var connection = new SqlConnection(_dbConnectionString))
                {
                    var cmd = new SqlCommand(query, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public TwiMLResult TwilioSMSReceive(SMSMessageResponse_Model objSMSMessageResponse_Model)
        {
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message(objSMSMessageResponse_Model.Body);
            return TwiML(messagingResponse);
        }

        //public TwiMLResult TwilioSMSReceive(Twilio.AspNet.Common.SmsRequest sm)
        //{
        // var aa = sm;
        // var response = new Twilio.TwiML.MessagingResponse();
        // response.Message("Hello I got your Message");
        // return TwiML(response);
        //}

        //Update SMS Status
        public void UpdateSMS(SMSMessage_Model smsModel)
        {
            try
            {
                string query = "";
                Guid SMSId = Guid.Empty;
                if (smsModel != null)
                {
                    query = "UPDATE TblSMS SET Status = '" + smsModel.Status + "',ModifiedDate = '" + DateTime.Now.ToString() + "' WHERE MessageId = '" + smsModel.MessageSid + "'";

                    using (var connection = new SqlConnection(_dbConnectionString))
                    {
                        var cmd = new SqlCommand(query, connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}