using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Base;
using Model;
using CommonUtil;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Model.Interfaces.Sydney;

namespace Test {
    public class TestAPIs {
        private readonly IHttpClientFactory _httpClientFactory;

        #region Setup / Tear down
        [SetUp]
        public void InitializeTestHarness() {
            Initialization.BuildServiceProvider();
        }

        [TearDown]
        public void TearDown() {
            // Noithing to do here
        }
        
        [Test]
        public void TestTemplate() {

            try {

            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }
        }

        #endregion Setup / Tear down

        [Test]
        public void Test_01_ZipCodeAPI() {
            // This retrieves a Zip Code packet from the Web
            string sBaseUrl = "http://api.zippopotam.us/us/";
            string sZipCode = "95356";
            try {
                ZipCodeReturn oWebResult = HttpAccessor.Get<ZipCodeReturn>(sBaseUrl + sZipCode).Result;
                Debug.WriteLine(oWebResult.Places[0].Name);

            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }
        }

        [Test]
        public void Test_02_ZipCodeAPI() {
            string sBaseUrl = "http://api.zippopotam.us/us/";
            string sZipCode = "95356";

            try {
                ZipCodeReturn oWebResult = HttpAccessor.Get<ZipCodeReturn>(sBaseUrl + sZipCode).Result;
                Debug.WriteLine(oWebResult.Places[0].Name);

            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }

        }

        [Test]
        public async Task Test_Josh_Get() {
            try {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://localhost:5000/weatherforecast");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseBody);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
            
        }

        [Test]
        public async Task Test_Josh_Post() {
            try {
                HttpClient client = new HttpClient();
                QueableMessage oMsg = new QueableMessage(1, "This is a test message");
                string json = await oMsg.ToJsonAsync();
                //string json = await Task.Run(() => JsonConvert.SerializeObject(oMsg));
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/queue/PublishToQueue", httpContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseBody);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
        [Test]
        public async Task Test_Josh_Post2() {
            try {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback +=
               (sender, certificate, chain, errors) => {
                   return true;
               };
                HttpClient client = new HttpClient(httpClientHandler);
              
                QueableMessage oMsg = new QueableMessage(1, "This is a test message");
                string json = await oMsg.ToJsonAsync();
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://35.166.20.52:44344/api/queue/PublishToQueue", httpContent);
                //HttpResponseMessage response = await client.GetAsync("https://35.166.20.52:44344/weatherforecast");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                IHttpClientFactory oHttpClientFactory = CommonUtil.ContainerAccess.Get<IHttpClientFactory>();
                HttpClient oServiceHubClient = oHttpClientFactory.CreateClient("ServiceHub");
                response = await oServiceHubClient.PostAsync("queue/PublishToQueue", httpContent);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseBody);

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public async Task Test_04_ServiceHubTypedClient() {
            try {
                IHttpClientFactory oHttpClientFactory = CommonUtil.ContainerAccess.Get<IHttpClientFactory>();
                HttpClient oClient = oHttpClientFactory.CreateClient("ServiceHub");

                QueableMessage oMsg = new QueableMessage(Constants.QUE_MESSAGE_TYPE_TEST, "This is a test message");
                string json = await oMsg.ToJsonAsync();
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await oClient.PostAsync("queue/PublishToQueue", httpContent);
                //"https://localhost:44300/api/queue/PublishToQueue"
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(responseBody);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

        }


        [Test]
        public async Task Test_Lee_Post() {
            try {
                QueableMessage oMsg = new QueableMessage(0, "This is a test message");
                string sUrl = "http://localhost:5000/api/queue/PublishToQueue";
                //string responseBody = await HttpAccessor.Post<string>(sUrl, oMsg);
                string responseBody = await HttpAccessor.Post(sUrl, oMsg);

                //CommonUtil.HttpClient_FS oClient = new HttpClient_FS(new Uri("http://localhost:5000/api/"));
                //string sJson = await oMsg.ToJsonAsync();
                //string responseBody = await oClient.PostAsync("queue/PublishToQueue", sJson);
                Debug.WriteLine(responseBody);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

        }
        [Test]
        public void Test_02_SydneyListing_FromClientFactory() {
            Int64 iEpochDate = 1593085461;
            List<Model.Interfaces.Sydney.SydneyListing> oListings;
            List<Model.Interfaces.Sydney.SydneyEmployee> oEEs;
            SydneyEmployee oEE;


            try {

                string sDTValue = "2017-07-05T15:43:02.000Z";
                DateTime oDt = Convert.ToDateTime(sDTValue);
                string json = "";

                IHttpClientFactory oHttpClientFactory = CommonUtil.ContainerAccess.Get<IHttpClientFactory>();

                // Aproach 1
                HttpClient oClient = oHttpClientFactory.CreateClient("SydneyAccessor");
                var request1 = new HttpRequestMessage() {
                    RequestUri = new Uri($"https://sydney.tworld.com/index.php/api2/Listings2/?createDate=>{iEpochDate}"),
                    Method = HttpMethod.Get,
                };
                request1.Headers.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
                //var response1 = oClient.SendAsync(request1).Result;
                string sNameId = "jttatem@tworld.com";

                ////User record
                try {
                    request1 = new HttpRequestMessage() {
                        RequestUri = new Uri($"https://sydney.tworld.com/index.php/api2/User/?nameid=>{sNameId}"),
                        Method = HttpMethod.Get,
                    };
                    request1.Headers.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
                    var response1 = oClient.SendAsync(request1).Result;
                    json = response1.Content.ReadAsStringAsync().Result;

                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }

                // get Employee Record
                try {
                    request1 = new HttpRequestMessage() {
                        RequestUri = new Uri($"https://sydney.tworld.com/index.php/api2/Employees/?c_user__c={sNameId}"),
                        Method = HttpMethod.Get,
                    };
                    request1.Headers.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
                    var response1 = oClient.SendAsync(request1).Result;
                    json = response1.Content.ReadAsStringAsync().Result;
                    List<SydneyEmployee> oEEList = FSTools.FromJSON<List<SydneyEmployee>>(json);
                    SydneyEmployee oEmployee = oEEList[0];

                    // Get the Office Record
                    request1 = new HttpRequestMessage() {
                        RequestUri = new Uri($"https://sydney.tworld.com/index.php/api2/Offices/?nameId={ oEmployee.c_office_location__c}"),
                        Method = HttpMethod.Get,
                    };
                    request1.Headers.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
                    response1 = oClient.SendAsync(request1).Result;
                    json = response1.Content.ReadAsStringAsync().Result;
                    List<SydneyOffice> oOfficeList = FSTools.FromJSON<List<SydneyOffice>>(json);
                    SydneyOffice oOffice = oOfficeList[0];
                        
                    // Get the Office Record

                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
                


                // Approach 2
                //SydneyClient oSydneyAccessor = CommonUtil.ContainerAccess.Get<SydneyClient>();
                //var oResponse2 = oSydneyAccessor.Client.GetStringAsync("Employees").Result;
                //oResponse2 = oSydneyAccessor.Client.GetStringAsync("Listings2/?createDate=>{iEpochDate}").Result;


                // Approach 3
                //HttpClient oClient3 = oHttpClientFactory.CreateClient("Sydney");
                //string sJson oResponse3 = oClient3.GetStringAsync("Employees").Result;
                //string sJson = oClient3.GetStringAsync("Listings2/?createDate=>{iEpochDate}").Result;
                //oListings = FSTools.FromJSON<List<SydneyListing>>(sJson);

                //sNameId = oListings[0].assignedTo;



                // Process the Listings
                //if (response1.IsSuccessStatusCode) {
                //    string json = response1.Content.ReadAsStringAsync().Result;
                //    oListings = FSTools.FromJSON<List<Model.Interfaces.Sydney.SydneyListing>>(json);

                //    string sNameId = oListings[0].assignedTo;



                ////Single Employee record
                //try {
                //    request1 = new HttpRequestMessage() {
                //        RequestUri = new Uri("https://sydney.tworld.com/index.php/api2/Employee/? c_user__c ={"+sNameId+"}"),
                //        Method = HttpMethod.Get,
                //    };
                //    request1.Headers.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
                //    response1 = oClient.SendAsync(request1).Result;
                //    json = response1.Content.ReadAsStringAsync().Result;
                //    //oEEs = FSTools.FromJSON<List<Model.Interfaces.Sydney.SydneyEmployee>>(json);
                //    //string sOfficeLocation = oEEs[0].c_office_location__c;

                //    oResponse2 = oSydneyAccessor.Client.GetStringAsync($"Employee/?c_user__c={sNameId}").Result;
                //    oResponse2 = oSydneyAccessor.Client.GetStringAsync("Employee/?c_user__c={" + sNameId + "}").Result;
                //    oEE = FSTools.FromJSON<SydneyEmployee>(oResponse2);
                //    string sOfficeLocation = oEE.c_office_location__c;
                //    oResponse2 = oSydneyAccessor.Client.GetStringAsync("Offices/?nameid={" + sOfficeLocation + "}").Result;


                //    // Office Info  -> c_office_location__c
                //    request1 = new HttpRequestMessage() {
                //        RequestUri = new Uri($"https://sydney.tworld.com/index.php/api2/Officces"),
                //        Method = HttpMethod.Get,
                //    };
                //    request1.Headers.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
                //    response1 = oClient.SendAsync(request1).Result;
                //    json = response1.Content.ReadAsStringAsync().Result;

                //} catch (Exception ex) {
                //    Debug.WriteLine(ex.Message);
                //}


                ////All Employee records
                //try {
                //    request1 = new HttpRequestMessage() {
                //        RequestUri = new Uri($"https://sydney.tworld.com/index.php/api2/Employees"),
                //        Method = HttpMethod.Get,
                //    };
                //    request1.Headers.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
                //    response1 = oClient.SendAsync(request1).Result;
                //    json = response1.Content.ReadAsStringAsync().Result;
                //    oEEs = FSTools.FromJSON<List< Model.Interfaces.Sydney.SydneyEmployee >>(json);

                //    string sOfficeLocation = oEEs[0].c_office_location__c;

                //    // Office Info  -> c_office_location__c
                //    request1 = new HttpRequestMessage() {
                //        RequestUri = new Uri($"https://sydney.tworld.com/index.php/api2/Officces"),
                //        Method = HttpMethod.Get,
                //    };
                //    request1.Headers.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
                //    response1 = oClient.SendAsync(request1).Result;
                //    json = response1.Content.ReadAsStringAsync().Result;

                //} catch (Exception ex) {
                //    Debug.WriteLine(ex.Message);
                //}

                //return Ok(response.Content.ReadAsStreamAsync().Result);
                //} else {
                //    //return StatusCode(500, "Something Went Wrong! Error Occured");
                //}
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
        //[Test]
        //public void GetSydneyPackage() {
        //    Model.Interfaces.SydneyListingRecordRootObject oRoot;


        //    int iResolution = 25;
        //    string sImageResolution = ConfigurationMgr.Instance.GetValueByName("Webp Default Image Resolution");
        //    if (!String.IsNullOrEmpty(sImageResolution)) {
        //        iResolution = Convert.ToInt32(sImageResolution);
        //    }

        //    Uri baseUri = new Uri("https://sydney.tworld.com/index.php/api2/Listings2/?createDate=>1593085461");
        //    HttpClient client = new HttpClient();

        //    HttpClient_FS client = new HttpClient_FS(baseUri, request => {
        //        request.Headers.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
        //    });

        //    HttpResponseMessage response = client.SendJsonRequest(HttpMethod.Get, baseUri, "").Result;

        //    string send = RestClientExtensions.GetJsonString("");
        //    string json = response.Content.ReadAsStringAsync().Result;

        //    Debug.WriteLine(json);
        //}


    }
}
