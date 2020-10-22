using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using NUnit.Framework;

using Base;
using Model;
using CommonUtil;
using BizHub.Services;
using BizHub.Service;
using PetaPoco;
using System.Linq;
using BizSearch;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace TestUtilities {
    public class TestSocket_Queue {

        private IServiceProvider _serviceProvider { get; set; }

        #region Setup / Tear down
        [SetUp]
        public void InitializeTestHarness() {
            _serviceProvider = Initialization.BuildServiceProvider();
        }

        [TearDown]
        public void TearDown() {
            // Noithing to do here
        }

        #endregion Setup / Tear down

        [Test]
        public void Test_01_TestWebSocketQueue() {

            //List<LookupNode> oList = new List<LookupNode>();
            //Lookup oLookup = LookupManager.Instance.GetLookupByConstantValue("ATTRIBUTETYPE->IMAGE");
            //LookupNode oLookupNode = new LookupNode(oLookup) ;
            //oList.Add(oLookupNode);
            //List<Int64> oOidList = oList.GetOids();

            try {
                SocketClient oClient = new SocketClient();

                QueableMessage oMsg = new QueableMessage();
                oMsg.MessageType = 1;
                oMsg.Data = "this is a test Message Sent through the Web Socket";
                oClient.SendMessage(oMsg);

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
        [Test]
        public void Test_02_TestMessageQueueClient() {

            MessageQueueClient oClient = new MessageQueueClient("ws://localhost:6001/socket1");
            QueableMessage oMessage = new QueableMessage();
            oMessage.MessageType = 1;
            oMessage.Data = "This is a test of the Message Queue";

            var task = oClient.OpenSocketAsync();
            task = oClient.SendAsync(oMessage);

            Debug.WriteLine("Message Sent");

        }

        [Test]
        public void Test_03_TestTheTester() {
            Debug.WriteLine("This is the Test");
        }

        [Test]
        public void Test_04_TestLocalAPI() {
            IHttpClientFactory toFactory = _serviceProvider.GetService<IHttpClientFactory>();
            Uri baseUri = new Uri("http://localhost:5000/weatherforecast");

            var request = new HttpRequestMessage(HttpMethod.Get, baseUri);
            var client = toFactory.CreateClient();

            var oTask = client.SendAsync(request);
            HttpResponseMessage response = oTask.Result;


            // Send to second Method
            List<Listing> oList = Model.Listing.Fetch("");
            var json = JsonConvert.SerializeObject(oList);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var Url = "http://localhost:5000/queue/NewTestPost";
            using var client2 = new HttpClient();
            //var response2 = await client2.PostAsync(Url, data);

            //string result2 = response2.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(result2);





            var url = "https://httpbin.org/post";


            //using var client2 = new HttpClient();

            //var response2 = await client2.PostAsync(baseUri, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);



            request = new HttpRequestMessage(HttpMethod.Post, baseUri);
            //request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            
            // make a POST request to the "cards" endpoint and pass in the parameters
            //return MakeRequest<CardInformation>("POST", "cards", postParams);


            oTask = client.SendAsync(request);
            response = oTask.Result;




            Debug.WriteLine("This is the Test");
        }

        //private static T MakeRequest<T>(string httpMethod, string route, Dictionary<string, string> postParams = null) {
        //    using (var client = new HttpClient()) {
        //        HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), $"{_apiBaseUri}/{route}");

        //        if (postParams != null)
        //            requestMessage.Content = new FormUrlEncodedContent(postParams);   // This is where your content gets added to the request body


        //        HttpResponseMessage response = client.SendAsync(requestMessage).Result;

        //        string apiResponse = response.Content.ReadAsStringAsync().Result;
        //        try {
        //            // Attempt to deserialise the reponse to the desired type, otherwise throw an expetion with the response from the api.
        //            if (apiResponse != "")
        //                return JsonConvert.DeserializeObject<T>(apiResponse);
        //            else
        //                throw new Exception();
        //        } catch (Exception ex) {
        //            throw new Exception($"An error ocurred while calling the API. It responded with the following message: {response.StatusCode} {response.ReasonPhrase}");
        //        }
        //    }
        //}
    }
}
