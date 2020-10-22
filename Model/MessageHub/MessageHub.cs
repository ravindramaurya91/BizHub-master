using System;
using System.Collections.Generic;
using System.Text;

using CommonUtil;

namespace Model {
    public class MessageHub {

        #region Fields
        private Int64 _clientCounter = 0;
        private static volatile MessageHub _messageHub = null;
        private List<MessageHubClient> _clients = new List<MessageHubClient>();
        private static object _syncRoot = new Object(); //for multi thread protection
        #endregion (Fields)

        #region Constructor
        public MessageHub() { }

        private static MessageHub GetMessageHub() {
            // Return an object reference to GlobalUtilities
            if (_messageHub == null) {
                lock (_syncRoot) {
                    _messageHub = new MessageHub();
                }
            }
            return _messageHub;
        }
        #endregion (Constructor)

        #region Methods
        public Int64 RegisterClient(MessageHubClient toClient) {
            _clientCounter++;
            Int64 iReturn = _clientCounter;
            _clients.Add(toClient);
            return iReturn;
        }
        public void PostNewMessage(TextMessageDTO toMsg) {
            // Take in message - see what Clients are Registered that might participate and post to them in their call back.
// Look at the EntityOid & see if they are listening
        }
        #endregion (Methods)

        #region Properties
        public static MessageHub Instance {
            get {
                if (_messageHub == null) {
                    _messageHub = GetMessageHub();
                }
                return _messageHub;
            }
        }
        #endregion (Properties)


    }
}
