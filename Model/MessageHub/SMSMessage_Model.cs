using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class SMSMessageResponse_Model
    {
        public string SmsSid { get; set; }
        public string Body { get; set; }
        public string MessageStatus { get; set; }
    }
    public class SMSMessage_Model
    {
        public string ToNumber { get; set; }
        public string FromNumber { get; set; }
        public string Body { get; set; }

        public string MessageSid { get; set; }
        public string MessagingServiceSid { get; set; }

        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public int? ErrorCode { get; set; }
        public string DataSent { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
   
}
