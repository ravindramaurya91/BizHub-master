using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CommonUtil {
    public class SocketListener_Tcp : SocketChannel {
        #region Events
        public event EventHandler OnMessageReceived;
        #endregion (Events)

        #region Fields
        TcpListener _listener = null;
        #endregion (Fields)

        #region Constructor
        public SocketListener_Tcp() {
            StartListener();
        }
        ~SocketListener_Tcp() {
            //ShutDownListener();
        }
        #endregion (Constructor)

        #region Methods
        public void StartListener() {

            SetDefaults();


            // TcpListener server = new TcpListener(port);
            _listener = new TcpListener(_ipAddress, _port);

            // Start listening for client requests.
            try {
                _listener.Start();
                Console.WriteLine("TCP Socket Listener Started Successfully");

                // Buffer for reading data
                Byte[] bytes = new Byte[_maxMessageSize];

                // Enter the listening loop.
                while (true) {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = _listener.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    object data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        //data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes("Message Received");

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("Error starting TCP Socket Listener");
                Console.WriteLine(ex.Message);
            }


        }
        #endregion (Methods)

    }
}
