using System;
using System.Collections.Generic;
using System.Text;
using Twilio.Types;

namespace CommonUtil {
    public class SMSMessage {

        #region Fields
        List<PhoneNumber> _to = new List<PhoneNumber>();
        #endregion (Fields)

        #region Constructor
        public SMSMessage() { }
        public SMSMessage(string tsMessage, string tsPhoneNumber) {
            Message = tsMessage;
            To.Add(new PhoneNumber(tsPhoneNumber));
        }
        public SMSMessage(string tsMessage, List<string> toPhoneNumbers) {
            Message = tsMessage;
            foreach (string s in toPhoneNumbers) {
                To.Add(new PhoneNumber(s));
            }
        }
        public SMSMessage(string tsMessage, PhoneNumber toPhoneNumber) {
            Message = tsMessage;
            To.Add(toPhoneNumber);
        }
        public SMSMessage(string tsMessage, List<PhoneNumber> toPhoneNumbers) {
            Message = tsMessage;
            To.AddRange(toPhoneNumbers);
        }
       
        #endregion (Constructor)

        #region Properties
        public List<PhoneNumber> To { get => _to; set => _to = value; }
        public string Message { get; set; }
        #endregion (Properties)
    }
}
