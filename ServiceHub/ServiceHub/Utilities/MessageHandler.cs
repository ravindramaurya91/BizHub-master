using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

using CommonUtil;
using Model;
using System.Threading;
using System.Diagnostics;

namespace ServiceHub {
    public class MessageHandler {
        #region Events
        public EventHandler OnNewMessageReceived { get; set; }
        #endregion (Events)


        #region Field
        private static volatile MessageHandler _queueManager = null;
        private static object _syncRoot = new Object(); //for multi thread protection
        private ConcurrentQueue<QueableMessage> _queue = new ConcurrentQueue<QueableMessage>();
        #endregion (Fields)

        #region Constructor
        public MessageHandler() { }

        private static MessageHandler GetQueueManager() {
            // Return an object reference to GlobalUtilities
            if (_queueManager == null) {
                lock (_syncRoot) {
                    _queueManager = new MessageHandler();
                    var thread = new Thread(new ThreadStart(_queueManager.RunQueueProcessor));
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
            return _queueManager;
        }
        #endregion (Constructor)

        #region Methods
        public void Enqueue(QueableMessage toMessage) {
            _queue.Enqueue(toMessage);
        }

        private void RunQueueProcessor() {
            while (true) {
                if (_queue.TryDequeue(out QueableMessage result)) {
                    Process(result);
                }
            }
        }
        private void Process(QueableMessage toMessage) {
            IAction oActionClass = null;
            try {
                switch (toMessage.MessageType) {
                    case Constants.QUE_MESSAGE_TYPE_TEST:
                        oActionClass = new TestAction();
                        break;
                    case Constants.QUE_MESSAGE_TYPE_VIEW:
                        oActionClass = new ViewListingsAction();
                        break;
                    case Constants.QUE_MESSAGE_TYPE_SEARCH_REQUEST:
                        oActionClass = new ViewListingsAction();
                        break;
                }

                if (oActionClass != null) {
                    oActionClass.Run(toMessage);
                }
            } catch (Exception ex) {

                Debug.WriteLine(ex.Message);
            }
        }
        #endregion (Methods)

        #region Properties
        public static MessageHandler Instance {
            get {
                if (_queueManager == null) {
                    _queueManager = GetQueueManager();
                }
                return _queueManager;
            }
        }
        #endregion (Properties)

    }
}
