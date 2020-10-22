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

using CommonUtil;

namespace TestUtilities {
    public class TestMessageCenter {

        #region Fields
        private IServiceProvider _serviceProvider { get; set; }
        #endregion (Fields)

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
        public void Test_01_TestMessageCenter_CS() {

            BizHub.Pages.MessageCenter.PagMessageCenter oPage = new BizHub.Pages.MessageCenter.PagMessageCenter();
            List<TextGroupDTO> oGroupList = oPage.Groups;
            oPage.ActiveGroup = oGroupList[1];

            //List<TextChannelDTO> 
            Debug.WriteLine("");
        }

        [Test]
        public void Test_02_TestMessageHub_Client() {
            try {
                MessageHubClient oClient1 = new MessageHubClient();
                oClient1.OnActiveGroupChanged += OClient1_OnActiveGroupChanged;
                oClient1.ActiveItem = oClient1.Groups[1]; // "Listings"
                oClient1.ActiveItem = oClient1.Groups[1].Children[0]; // "Capitol Door"

                List<Entity> oEntities = Entity.Fetch("WHERE Oid = @0", 6);
                oClient1.CreateNewChannel(oEntities); // This will set the new channel as the ActiveChannel
                
                
                oClient1.AddNewMessage("This is the next message");

                // oClient1.ActiveGroup = oClient1.ActiveGroup.Children[0]; // Capitol Door

                MessageHubClient oClient2 = new MessageHubClient(6, 1, Constants.DEFAULT_UNKNOWN_INDIVIDUAL_AVATAR);
            }catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        private void OClient1_OnActiveGroupChanged(object sender, ActiveGroupChangedEventArgs e) {
            Debug.WriteLine(((TextGroupDTO)sender).Name);
            Debug.WriteLine(e.Children.Count.ToString());
            if(e.Children.Count > 0) {
                e.MessageHubClient.ActiveItem = e.Children[0];
            }

        }
    };

}
