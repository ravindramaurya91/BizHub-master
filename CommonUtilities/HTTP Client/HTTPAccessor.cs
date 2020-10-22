using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace CommonUtil {
    public class HttpAccessor {

        public static async Task<T> Get<T>(string tsEndpoint) where T : new() {
            //public T MakeRequest<T>(string tsEndpoint, HttpVerb teMethod) where T : new() {
            try {
                string sUrl = tsEndpoint;
                var client = new HttpClient();
                var result = await client.GetAsync(sUrl);
                var json = await result.Content.ReadAsStringAsync();
                return FSTools.FromJSON<T>(json);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
            return new T();
        }

        public static async Task<T> Post<T>(string tsEndpoint, object o) {
            string sJsonReturn = await Post(1, tsEndpoint, o);
            return FSTools.FromJSON<T>(sJsonReturn);
        }

        public static async Task<string> Post(string tsEndpoint, object o) {
            string sJsonReturn = await Post(1, tsEndpoint, o);
            return sJsonReturn;
        }

        private static async Task<string> Post(int tiKey, string tsEndpoint, object o) {
            string sJson = "";
            try {
                sJson = FSTools.ToJSON(o);
                var data = new StringContent(sJson, Encoding.UTF8, "application/json");
                var url = tsEndpoint;
                var client = new HttpClient();
                HttpResponseMessage oResponseMessage = await client.PostAsync(url, data);
                sJson = oResponseMessage.Content.ReadAsStringAsync().Result;
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            return sJson;
        }
        #region Properties
        public static HttpClient Client { get; set; } = new HttpClient();
        #endregion (Properties)


    }

}
