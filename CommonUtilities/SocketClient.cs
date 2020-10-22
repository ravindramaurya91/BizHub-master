using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CommonUtil {
    public class SocketClient : SocketChannel {

        #region Fields
        private Socket _sender;
        #endregion (Fields)

        #region Constructor
        public SocketClient() {
            StartClient();
        }
        ~SocketClient() {
            CloseConnection();
        }
        #endregion (Constructor)

        public void StartClient() {
            byte[] bytes = new byte[1024];

            try {
                // Connect to a Remote server  
                // Get Host IP Address that is used to establish a connection  
                // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
                // If a host has multiple addresses, you will get a list of addresses 
                SetDefaults();
                // Create a Socket that will use Tcp protocol      


                // A Socket must be associated with an endpoint using the Bind method  
                //_sender.Bind(_localEndPoint);

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public bool SendMessage(object toMessage) {
            bool bReturn = false;
            byte[] bReturnMessage = new byte[1024];
            try {
                _sender = new Socket(_ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                System.Diagnostics.Debug.WriteLine("Connection State = " + _sender.Connected.ToString());
                //// Encode the data string into a byte array.    
                //byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");
                byte[] oByteArray = FSTools.ConvertObjectToByteArray(toMessage);
                // Send the data through the socket.    
                int bytesSent = _sender.Send(oByteArray);

                // Receive the response from the remote device.    
                int bytesRec = _sender.Receive(bReturnMessage);
                string sReturnConfirmation = Encoding.ASCII.GetString(bReturnMessage, 0, bytesRec);
                
                Console.WriteLine("Echoed test = {0}", sReturnConfirmation);



            } catch (ArgumentNullException ane) {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            } catch (SocketException se) {
                Console.WriteLine("SocketException : {0}", se.ToString());
            } catch (Exception e) {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }


            _sender.Shutdown(SocketShutdown.Both);
            _sender.Close();
            return bReturn;

        }
        public void Send(object toPayload) {
            byte[] bytes = new byte[1024];
            try {
                byte[] oByteArray = FSTools.ConvertObjectToByteArray(toPayload);
                // Send the data through the socket.    
                int bytesSent = _sender.Send(oByteArray);

                // Receive the response from the remote device.    
                int bytesRec = _sender.Receive(bytes);

                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));


            } catch (ArgumentNullException ane) {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            } catch (SocketException se) {
                Console.WriteLine("SocketException : {0}", se.ToString());
            } catch (Exception e) {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }

        private void CloseConnection() {
            // Release the socket.    
            _sender.Shutdown(SocketShutdown.Both);
            _sender.Close();
        }


        #region Properties
        #endregion (Properties)

    }
}
