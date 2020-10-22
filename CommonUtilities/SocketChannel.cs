using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CommonUtil {
    public class SocketChannel {
        #region Fields
        protected int _port = 1152;
        protected int _maxClientConnections = 10;
        protected int _maxMessageSize = 5000;
        protected IPHostEntry _ipHostEntry = null;
        protected IPAddress _ipAddress = null;
        protected IPEndPoint _localEndPoint = null;
        #endregion (Fields)

        #region Methods
        protected void SetDefaults() {
            // Get Host IP Address that is used to establish a connection  
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
            // If a host has multiple addresses, you will get a list of addresses  

            if (_ipHostEntry == null) {
                // If someone has set the Host Entry before calling the Start method we will use it - 
                // otherwise we get the default

                //_ipHostEntry = Dns.GetHostEntry("localhost"); //  Default to Local Host
                _ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            }

            if (_ipAddress == null) {
                // If someone has set the IP Address before calling the Start method we will use it - 
                // otherwise we get the default
                _ipAddress = _ipHostEntry.AddressList[0];
            }

            _localEndPoint = new IPEndPoint(_ipAddress, _port);

        }
        #endregion (Methods)

        #region Properties
        public int MaxMessageSize { get => _maxMessageSize; set => _maxMessageSize = value; }
        // The Properties below this point need to be set prior to starting up the socket connection.  
        // We might want to track a boolen IsStarted and not allow them to be changed after starting
        public int Port { get => _port; set => _port = value; }
        public int MaxClientConnections { get => _maxClientConnections; set => _maxClientConnections = value; }
        public IPHostEntry IpHostEntry { get => _ipHostEntry; set => _ipHostEntry = value; }
        public IPAddress IpAddress { get => _ipAddress; set => _ipAddress = value; }
        public IPEndPoint LocalEndPoint { get => _localEndPoint; set => _localEndPoint = value; }
        #endregion (Properties)
    }
}
