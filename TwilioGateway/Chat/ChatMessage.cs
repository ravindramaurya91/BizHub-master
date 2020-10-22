using System;
using System.Collections.Generic;
using System.Text;

namespace TwilioGateway {
    public class ChatMessage {

        public ChatMessage( string tsMessage) {
            Message = tsMessage;
        }

        #region Properties
        public TwilioUser Sender { get; set; }
        public DateTime DateSent { get; set; }
        public string Message { get; set; }
        #endregion (Properties)

    }
}
