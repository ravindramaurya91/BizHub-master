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
    public class TestLoanCalculator {

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
        public void Test_01_LoanCalculation() {
            LoanCalcResult oResult = new LoanCalcResult();
            try {
                LoanCalcRequest oRequest = new LoanCalcRequest() { LoanAmount = 250000, InterestRate = 4.56, LoanMonths = 120, LoanYears = 10, Fees = 270, Points = 1.5 };
                oRequest = new LoanCalcRequest() { LoanAmount = 0, InterestRate = 0, LoanMonths = 0, LoanYears = 10, Fees = 270, Points = 1.5 };
                oResult = oRequest.CalculateLoanSchedule();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            Debug.WriteLine(oResult.PaymentSchedule.Count);
        }
    }
}
