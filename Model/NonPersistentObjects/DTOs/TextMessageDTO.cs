using System;
using System.Collections.Generic;
using System.Text;
using Twilio.Rest.Api.V2010.Account.Usage;

namespace Model {
    public class TextMessageDTO : TextMessage{

        #region Constructor
        public TextMessageDTO() {}
        public TextMessageDTO(TextMessage toMsg) {
            DateSent = toMsg.DateSent;
            lkpMessageTypeOid = toMsg.lkpMessageTypeOid;
            Message = toMsg.Message;
            lkpMessageTypeOid = toMsg.lkpMessageTypeOid;
            Oid = toMsg.Oid;
            SentBy = toMsg.SentBy;
            SentByOid = toMsg.SentByOid;
            TextChannelOid = toMsg.TextChannelOid;
        }
        #endregion (Constructor)

        #region Properties
        public string MessageType { get; set; }
        public string Avatar { get; set; }
        #endregion (Properties)

    }
}
