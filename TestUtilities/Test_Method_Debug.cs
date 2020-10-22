using Model;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;

using Model;
using CommonUtil;
using BizHub;
using BizHub.Services;


namespace TestUtilities {
    public class Test_Method_Debug {
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

        [Test]
        public void Test_01_StatelkpOids() {
            Int64 iEntityOid = 6; //Steve-O-Reno
            
            try {
                Entity oEntity = SQL.GetEntityByOid(iEntityOid, true);
                if(!String.IsNullOrEmpty(oEntity.lkpStateOids_Servicing)) {
                    List<Int64> iOids = FSTools.ConvertListToInt64(oEntity.lkpStateOids_Servicing);
                    BaseResponse oBaseResponse = new BaseResponse();
                    oBaseResponse =  DataService.GetBrokerCardsByStateOids(iOids);

                }
            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }
        }
        [Test]
        public void Test_02_ShallowCloneExample() {
            Entity2ListingMap_Stat oMap = Entity2ListingMap_Stat.FirstOrDefault("WHERE Oid = @0", 86);

            Entity2ListingMap_Stat oNewObj = oMap.NewCopy<Entity2ListingMap_Stat>();
            Debug.WriteLine("New object IsNew() = " + oNewObj.IsNew().ToString());
        }

        [Test]
        public void Test_NestedIfExpression() {
            Int64 IncomingValue = 1234, lkp1 = 2434, lkp2 = 1234, iReturn1 = 453, iReturn2 = 2222, iDefaultReturn = 43435;

            var a = IncomingValue == lkp1 ? iReturn1 :
                    IncomingValue == lkp2 ? iReturn2 :
                                     iDefaultReturn;

        }
    }
}
