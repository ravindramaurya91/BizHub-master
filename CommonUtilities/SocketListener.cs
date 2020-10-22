using Amazon.Runtime.SharedInterfaces;
using System;
using System.IO;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommonUtil {
    public class SocketListener : SocketChannel {

        #region Events
        public event EventHandler OnMessageReceived;
        #endregion (Events)

        #region Fields

        #endregion (Fields)

        #region Constructor
        public SocketListener() {
        }
        ~SocketListener() {
            StopListener();
        }
        #endregion (Constructor)

        #region Methods
        public void StartListener() {

            SetDefaults();

            try {
                // Create a Socket that will use Tcp protocol      
                Socket oSocket_Listener = new Socket(_ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // A Socket must be associated with an endpoint using the Bind method  
                oSocket_Listener.Bind(_localEndPoint);
                // Specify how many requests a Socket can listen before it gives Server busy response.  
                // We will listen 10 requests at a time  
                oSocket_Listener.Listen(_maxClientConnections);

                // Start a Listening Loop
                while (true) {
                    Console.WriteLine("Waiting for a connection...");
                    Socket oSocket_MessageHandler = oSocket_Listener.Accept();

                    byte[] ooReceivingBuffer = new byte[_maxMessageSize];
                    // Incoming data from the client.    
                    int bytesRec = oSocket_MessageHandler.Receive(ooReceivingBuffer);
                    // Convet Message to Object.    
                    object oData = FSTools.ConvertByteArrayToObject(ooReceivingBuffer);

                    Console.WriteLine("Message received : {0}", oData.ToString());

                    // If anyone is listening for inbound messages - send it to them here
                    if(OnMessageReceived != null) {
                        OnMessageReceived.Invoke(oData, new EventArgs());
                    }

                    byte[] msg = Encoding.ASCII.GetBytes("Message Received");
                    oSocket_MessageHandler.Send(msg);
                    oSocket_MessageHandler.Shutdown(SocketShutdown.Both);
                    oSocket_MessageHandler.Close();
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }

        public void StopListener() {

        }
        #endregion (Methods)

    }
}
