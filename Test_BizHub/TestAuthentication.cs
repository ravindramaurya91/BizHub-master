using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Base;
using Model;
using CommonUtil;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using BizHub.Services;

namespace Test {
    public class TestAuthentication {

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
        [Test]
        public void Test01_GetUserSession() {

            try {

           

            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }
        }
        #endregion Setup / Tear down


    }
}
