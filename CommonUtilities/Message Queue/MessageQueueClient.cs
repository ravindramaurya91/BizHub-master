using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Concurrent;

namespace CommonUtil {
    public class MessageQueueClient {

        #region Events
        public EventHandler SocketStatusChangeEvent { get; set; }
        #endregion (Events)

        #region Fields
        private readonly string _socketurl;
        private int _port = 5000;
        private ClientWebSocket clwebsocket = new ClientWebSocket();
        #endregion (Fields)

        #region Constructor
        public MessageQueueClient(string socketurl) {
            _socketurl = socketurl;
        }
        #endregion (Constructor)

        #region Methods

        #region open/close
        public async Task OpenSocketAsync() {
            try {

                await clwebsocket.ConnectAsync(new Uri(_socketurl), CancellationToken.None);
                SocketStatusChangeEvent?.Invoke(this, new SocketEventArgs() { NewState = clwebsocket.State });
            } catch (Exception e) {
                SocketStatusChangeEvent?.Invoke(this, new SocketEventArgs() { NewState = clwebsocket.State });
            }
        }

        public async Task CloseSocketAsync() {
            await clwebsocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
            SocketStatusChangeEvent?.Invoke(this, new SocketEventArgs() { NewState = clwebsocket.State });
        }
        #endregion

        public async Task SendAsync(QueableMessage toMessage) {
            if (clwebsocket.State == WebSocketState.Open) {
                try {
                    BinaryFormatter oFormatter = new BinaryFormatter();
                    MemoryStream  oMemoryStream = new MemoryStream();
                    oFormatter.Serialize(oMemoryStream, toMessage);

                    await clwebsocket.SendAsync(oMemoryStream.ToArray(), WebSocketMessageType.Binary, true, System.Threading.CancellationToken.None);
                
                } catch (Exception e) {
                    SocketStatusChangeEvent?.Invoke(this, new SocketEventArgs() { NewState = clwebsocket.State });
                    Console.WriteLine(e.Message);
                }
            }
        }
        #endregion (Methods)

        #region Properties
        public int Port { get => _port; set => _port = value; }
        #endregion (Properties)

    }

    public class SocketEventArgs : EventArgs {
        public WebSocketState NewState { get; internal set; }
    }
}
