using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Model.Interfaces.Sydney {
    public class SydneyClient {
        public HttpClient Client { get; private set; }

        #region Constructor
        public SydneyClient(HttpClient toClient) {
            Client = toClient;
            Client.BaseAddress = new Uri("https://sydney.tworld.com/index.php/api2/");
            Client.DefaultRequestHeaders.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
        }
        #endregion (Constructor)

    }
}
