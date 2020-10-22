using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CommonUtil {
    public class TcpSocketListener {


        #region Fields
        private TcpListener _listener = null;
        #endregion (Fields)

        #region Constructor
        public TcpSocketListener() {
            IPHostEntry oIpHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress oIpAddress = oIpHostEntry.AddressList[0];
            //IPAddress localAddr = IPAddress.Parse(ip);
            _listener = new TcpListener(oIpAddress, 1531);
            _listener.Start();

        }
        #endregion (Constructor)

        #region Methods
        public void StartListener() {
            try {
                while (true) {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = _listener.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                    t.Start(client);
                }
            } catch (SocketException e) {
                Console.WriteLine("SocketException: {0}", e);
                _listener.Stop();
            }
        }
        public void HandleDeivce(Object obj) {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();
            string imei = String.Empty;
            string data = null;
            Byte[] bytes = new Byte[256];
            int i;
            try {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) {
                    string hex = BitConverter.ToString(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.ManagedThreadId);
                    string str = "Hey Device!";
                    Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                    stream.Write(reply, 0, reply.Length);
                    Console.WriteLine("{1}: Sent: {0}", str, Thread.CurrentThread.ManagedThreadId);
                }
            } catch (Exception e) {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }

        #endregion (Methods)

        #region Properties
        #endregion (Properties)

    }
}
