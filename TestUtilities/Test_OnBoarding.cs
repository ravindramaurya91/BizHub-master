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
using BizHub;

namespace TestUtilities {
    public class Test_OnBoarding {

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
        public void Test_01_OnBoardPageController() {

            PagOnboardController oCtrl = new PagOnboardController();
            
            try {
                oCtrl.TypeOfIndividual = PagOnboardController.eOnboardedIndividualType.Seller;
                oCtrl.Save();

                Debug.WriteLine("Success");

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
