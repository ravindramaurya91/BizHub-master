using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using NUnit.Framework;

using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//using Xunit;

using CommonUtil;
using System.Diagnostics;
using Model;

namespace TestUtilities {
    public class RestApiClientUnitTest {

        #region Setup / Tear down
        [SetUp]
        public void InitializeTestHarness() {
            Initialization.BuildServiceProvider();
        }

        [TearDown]
        public void TearDown() {
            // Noithing to do here
        }

        #endregion Setup / Tear down


        //    [Test]
        //    public void GetSydneyPackage() {
        //    Model.Interfaces.SydneyListingRecordRootObject oRoot;

        //    int iResolution = 25;
        //    string sImageResolution = ConfigurationMgr.Instance.GetValueByName("Webp Default Image Resolution");
        //    if (!String.IsNullOrEmpty(sImageResolution)) {
        //        iResolution = Convert.ToInt32(sImageResolution);
        //    }

        //    Uri baseUri = new Uri("https://sydney.tworld.com/index.php/api2/Listings2/?createDate=>1593085461");

        //    HttpClient_FS client = new HttpClient_FS(baseUri, request => {
        //        request.Headers.Add("Authorization", "Basic ZHZpbGxhcjpVQkV6T2J3dzhaZGJPNXM2WUtnM1JRS2JTZEc5eE1iWQ");
        //    });

        //    HttpResponseMessage response = client.SendJsonRequest(HttpMethod.Get, baseUri, "").Result;

        //    string send = RestClientExtensions.GetJsonString("");
        //    string json = response.Content.ReadAsStringAsync().Result;

        //    Debug.WriteLine(json);
        //}



        //    [Test]
        //    public void SendJson() {
        //        using (TestWebHost host = new TestWebHost()) {
        //            host.StarWebHost("http://*:15001");
        //            Thread.Sleep(1000);
        //            Uri baseUri = new Uri("http://localhost:15001");

        //            HttpClient_FS client = new HttpClient_FS(baseUri, request => {
        //                request.Headers.Add("CustomHeader", "CustomHeaderValue");
        //            }
        //            );

        //            PurchaseOrder sendObj = new PurchaseOrder();

        //            Uri relUri = new Uri(RequestPathAttribute.GetRestApiPath(sendObj), UriKind.Relative);
        //            HttpResponseMessage response = client.SendJsonRequest(HttpMethod.Post, relUri, sendObj).Result;

        //            string send = RestClientExtensions.GetJsonString(sendObj);
        //            string json = response.Content.ReadAsStringAsync().Result;
        //            string rest = host.Message;

        //            PurchaseOrder respObj = response.DeseriaseJsonResponse<PurchaseOrder>();

        //            Assert.AreEqual(send, json);
        //            Assert.AreEqual(rest, json);
        //            string test = response.Headers.GetValues("CustomHeader").First();

        //            Assert.AreEqual("CustomHeaderValue", test);

        //        }
        //    }

        //    [Test]
        //    public void SendXml() {
        //        using (TestWebHost host = new TestWebHost()) {
        //            host.StarWebHost("http://*:15002");
        //            Thread.Sleep(1000);
        //            Uri baseUri = new Uri("http://localhost:15002");

        //            HttpClient_FS client = new HttpClient_FS(baseUri);

        //            PurchaseOrder sendObj = new PurchaseOrder();

        //            HttpResponseMessage response = client.SendXmlRequest(HttpMethod.Post, new Uri("res", UriKind.Relative), sendObj).Result;

        //            PurchaseOrder respObj = response.DeseriaseXmlResponse<PurchaseOrder>();

        //            string send = RestClientExtensions.GetXmlString(sendObj);
        //            string xml = response.Content.ReadAsStringAsync().Result;
        //            string rest = host.Message;

        //            Assert.AreEqual(send, xml);
        //            Assert.AreEqual(rest, xml);

        //        }
        //    }


        //    [Test]
        //    public void SendDcXml() {
        //        using (TestWebHost host = new TestWebHost()) {
        //            host.StarWebHost("http://*:15003");
        //            Thread.Sleep(1000);
        //            Uri baseUri = new Uri("http://localhost:15003");

        //            HttpClient_FS client = new HttpClient_FS(baseUri);

        //            PurchaseOrder sendObj = new PurchaseOrder();

        //            HttpResponseMessage response = client.SendDcXmlRequest(HttpMethod.Post, new Uri("res", UriKind.Relative), sendObj).Result;

        //            PurchaseOrder respObj = response.DeseriaseDcXmlResponse<PurchaseOrder>();

        //            string send = RestClientExtensions.GetDcXmlString(sendObj);
        //            string xml = response.Content.ReadAsStringAsync().Result;
        //            string rest = host.Message;

        //            Assert.AreEqual(send, xml);
        //            Assert.AreEqual(rest, xml);
        //        }
        //    }
        //}
    }

    
        public class TestWebHost : IDisposable {
            public IHost Host2 { get; set; }
            public string Message { get; private set; }


            public void StarWebHost(string serverUrl = "http://localhost:15000") {

                var host = Host.CreateDefaultBuilder()
                  .ConfigureServices(services =>
                    services.AddResponseCompression()
                    )
                    .ConfigureWebHost(builder =>
                    {
                        builder.UseKestrel()
                    .UseUrls(serverUrl)
                    .Configure(app => {
                          app.UseResponseCompression();
                          app.Run(async (context) => {
                              foreach (var h in context.Request.Headers) {
                                  context.Response.Headers.Add(h);
                              }
                              MemoryStream ms = new MemoryStream();
                              await context.Request.Body.CopyToAsync(ms);
                              StreamReader sr = new StreamReader(ms);
                              ms.Position = 0;
                              Message = sr.ReadToEnd();
                              ms.Position = 0;
                              context.Response.StatusCode = StatusCodes.Status200OK;
                              await ms.CopyToAsync(context.Response.Body);
                          });
                      });
                    })
                  .Build();
                Host2 = host;
                host.Start();
            }



            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls

            protected virtual void Dispose(bool disposing) {
                if (!disposedValue) {
                    if (disposing) {
                        Host2?.Dispose();
                    }

                    disposedValue = true;
                }
            }
            // This code added to correctly implement the disposable pattern.
            public void Dispose() {
                Dispose(true);
            }
            #endregion

        }
    }