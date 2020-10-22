using CommonUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


using CommonUtil;
using Model;

namespace BizHub {
    public class ServiceHubClient {
        // This class will manage the passing of work to the ServiceHub
        #region Fields
        #endregion (Fields)

        #region Constructor
        #endregion (Constructor)

        #region Methods
        public async Task PublishMessage(QueableMessage toMsg) {
            string sSerialized = string.Empty;
            if (toMsg != null) {
                // TODO sSerialized = RestClientExtensions.GetJsonString<QueableMessage>(toMsg);
            }

            //Microsoft.AspNetCore.
            //var response = await client.PostAsJsonAsync("AddNewArticle", new Article {
            //    Title = "New Article Title",
            //    Body = "New Article Body"
            //});

            //HttpRequestMessage oRequest = new HttpRequestMessage();
            //oRequest.Headers.Accept.Add(APPLICATION_JSON_Q);
            //oRequest.Method = toMethod;
            //oRequest.RequestUri = uri;
            //if (toMethod != HttpMethod.Get) {
            //    oRequest.Content = new StringContent(json, Encoding.UTF8, APPLICATION_JSON.MediaType);
            //}
            ////request.Content.Headers.ContentType = ApplicationJson;
            //ConfigureHttpRequstMessage?.Invoke(oRequest);
            //return oClient.SendAsync(oRequest, CancellationTokenSource.Token);

            //using (HttpResponseMessage response = await HttpHelper.ApiClient.PostAsync(){

            //}
        }
        #endregion (Methods)

        #region Properties
        #endregion (Properties)
            
    }
}
