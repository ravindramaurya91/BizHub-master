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
using Microsoft.AspNetCore.Builder;
using BizHub;

using PetaPoco;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace TestUtilities {
    public class DataManipulation {
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
        public void Test_01_RemoveStateLookups() {
            // Remove aqll States, Counties, and Cities that are not in California, Washingto, or Oregon

            try {
                string sSql = @"SELECT * FROM Lookup WHERE LookupName = 'State' 
                    AND Value NOT IN('California', 'Oregon', 'Washington')
                    ORDER BY Value ";

                List<Lookup> oList = Base.Database.GetInstance().Fetch<Lookup>(sSql);
                foreach (Lookup lkp in oList) {
                    lkp.CascadingDelete();
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public void Test_02_AddBusinessCategories() {
            // Remove aqll States, Counties, and Cities that are not in California, Washingto, or Oregon

            try {
                BizCatLoader oLoader = new BizCatLoader();
                oLoader.LoadBizCats();
                int i = oLoader.BizCatCount;
                oLoader.SaveBizCats();
                Debug.WriteLine(oLoader.BizCats.Count.ToString());

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public void Test_03_TestListingIndexer() {
            // Remove aqll States, Counties, and Cities that are not in California, Washingto, or Oregon

            try {
                SearchCriteriaDisplay oDisplay = new SearchCriteriaDisplay();
                oDisplay.SearchCriteria["ListingPrice_To"] = 21.07M;
                Debug.WriteLine(oDisplay.SearchCriteria["ListingPrice_To"]);

                oDisplay.SearchCriteria["ListingPrice_From"] = 22.07M;
                Debug.WriteLine(oDisplay.SearchCriteria["ListingPrice_From"]);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
        [Test]
        public void Test_05_TestPagListingController() {
            // Remove aqll States, Counties, and Cities that are not in California, Washingto, or Oregon

            try {
                List<Entity> oList = Entity.Fetch("");

                //List<SearchCriteria> oCriteriaList = SearchCriteria.Fetch("");
                //SearchCriteria oCriteria = oCriteriaList[0];
                SearchCriteria oCriteria = new SearchCriteria();
                oCriteria.EntityOid = 6;
                oCriteria.EmployeeCount_From = 23;
                oCriteria.Keywords = "Hair, Nails";
                oCriteria.IsAbsenteeOwner = true;

                BizHub.Pages.Listings.PagListings oPage = new BizHub.Pages.Listings.PagListings();
                SearchCriteriaDisplay oSrchDisplay = oPage.Controller.SearchCriteriaDisplay;
                Debug.WriteLine(oSrchDisplay.SearchCriteria.ToString());

                PagListingsController oCtrl = oPage.Controller;
                oCtrl.SearchCriteriaDisplay.SearchCriteria = oCriteria;

                oCtrl.SearchCriteriaDisplay.MinimumDownPayment_To = 120000M;
                oCtrl.SearchCriteriaDisplay.MinimumDownPayment_To = 200000M;
                oCtrl.SearchCriteriaDisplay.Keywords = "Hair, Toes";
                oCtrl.SearchCriteriaDisplay.lkpBusinessCategoryOids = "34957, 34962, 34977";
                oCtrl.SearchCriteriaDisplay.lkpBusinessCategoryOids = "34957, 34962, 34977, 34992";
                oCtrl.SearchCriteriaDisplay.lkpBusinessCategoryOids = "34957, 34962";
                Debug.WriteLine("End of Test");


            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public void Test_04_TestExtensionProperties() {
            // Remove aqll States, Counties, and Cities that are not in California, Washingto, or Oregon

            try {
                SearchCriteria oCriteria = new SearchCriteria();
                oCriteria.Name = "Test Criteria";
                oCriteria.OnIsExpandedChanged += OCriteria_OnIsExpandedChanged;
                oCriteria.IsExpanded = !oCriteria.IsExpanded;
                oCriteria.IsExpanded = !oCriteria.IsExpanded;

                Debug.WriteLine("End of Test");


            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public void Test_06_TestListingCriteriaToXML() {
            // Remove aqll States, Counties, and Cities that are not in California, Washingto, or Oregon

            try {


                List<SearchCriteria> oList = SearchCriteria.Fetch("");
                if(oList.Count > 0) {
                    SearchCriteria oCriteria = oList[0];

                    oCriteria.Oid = FSTools.CopyValue("333", oCriteria.Oid);
                    oCriteria.ListingPrice_From = FSTools.CopyValue("333.00", oCriteria.ListingPrice_From);

                    PropertyInfo oInfo = oCriteria.GetType().GetProperty("ZipCode");
                    oCriteria["ZipCode"] = FSTools.ConvertValueByType(oInfo.PropertyType, "455.90");
                    
                    oInfo = oCriteria.GetType().GetProperty("EBITDA_From");
                    oCriteria["EBITDA_From"] = FSTools.ConvertValueByType(oInfo.PropertyType, 220000);
                    
                    oInfo = oCriteria.GetType().GetProperty("NewListingsSinceLastSearchDate");
                    oCriteria["NewListingsSinceLastSearchDate"] = FSTools.ConvertValueByType(oInfo.PropertyType, 2);

                    oInfo = oCriteria.GetType().GetProperty("Keywords");
                    oCriteria["Keywords"] = FSTools.ConvertValueByType(oInfo.PropertyType,null);

                    oInfo = oCriteria.GetType().GetProperty("TotalSqFt_From");
                    oCriteria["TotalSqFt_From"] = FSTools.ConvertValueByType(oInfo.PropertyType, null);
                    
                    
                    oInfo = oCriteria.GetType().GetProperty("IsHomeBased");
                    oCriteria["IsHomeBased"] = FSTools.ConvertValueByType(oInfo.PropertyType, "true");

                    oInfo = oCriteria.GetType().GetProperty("IsHomeBased");
                    oCriteria["IsHomeBased"] = FSTools.ConvertValueByType(oInfo.PropertyType, null);

                    oInfo = oCriteria.GetType().GetProperty("ListingDate");
                    oCriteria["ListingDate"] = FSTools.ConvertValueByType(oInfo.PropertyType, DateTime.Now);

                    oInfo = oCriteria.GetType().GetProperty("ListingPrice_From");
                    oCriteria["ListingPrice_From"] = FSTools.ConvertValueByType(oInfo.PropertyType, "455.90");


                    oCriteria.Name = "This is My Name";
                    string sUrl = SearchCriteria.ToUrl(oCriteria);

                    SearchCriteria oNewCriteria = SearchCriteria.FromUrl(sUrl);
                    Debug.WriteLine(oNewCriteria.Name);
                }

                SearchCriteriaDisplay oDisplay = new SearchCriteriaDisplay();
                oDisplay.SearchCriteria["ListingPrice_To"] = 21.07M;
                Debug.WriteLine(oDisplay.SearchCriteria["ListingPrice_To"]);

                oDisplay.SearchCriteria["ListingPrice_From"] = 22.07M;
                Debug.WriteLine(oDisplay.SearchCriteria["ListingPrice_From"]);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public void Test_07_TestOrganizationDTO() {
            // Remove aqll States, Counties, and Cities that are not in California, Washingto, or Oregon
            Int64 iEntityOid_Master = 1;
            try {
                OrganizationDTO oOrganization = SQL.GetOrganizationFromEntityOid_Master(iEntityOid_Master);
                Debug.WriteLine(oOrganization.Regions[0].Offices[0].Users.Count);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
           
        }
        [Test]
        public void Test_08_TestLookupPages() {
            // Remove aqll States, Counties, and Cities that are not in California, Washingto, or Oregon

            try {
                BizHub.PagAdminController oController = new PagAdminController();
                oController.ActiveLookupDefinition = oController.Definitions[3];
                oController.ActiveLookup = oController.Lookups[2];
                LookupUdfBlock oBlock = oController.LookupUdfBlock;

                Debug.WriteLine("UDF 3 Label = [" + oBlock.UDF3Label + "]");
                Debug.WriteLine("UDF 3 Value = [" + oBlock.UDF3Value + "]");

                oController.ActiveLookupDefinition.UDF3 = "Test 3";
                Debug.WriteLine("UDF 3 Label = [" + oBlock.UDF3Label + "]");
                Debug.WriteLine("UDF 3 Value = [" + oBlock.UDF3Value + "]");

                oController.LookupUdfBlock.UDF3Value = "Value 3";
                Debug.WriteLine("UDF 3 Label = [" + oBlock.UDF3Label + "]");
                Debug.WriteLine("UDF 3 Value = [" + oBlock.UDF3Value + "]");

                oBlock.UDF3Label = "Ammended UDF 3 Def";
                Debug.WriteLine("Active Defintion UDF 3 Value = [" + oController.ActiveLookupDefinition.UDF3 + "]");
                Debug.WriteLine("Active Lookup UDF 3 Value = [" + oController.ActiveLookup.UDF3 + "]");

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

        }
        [Test]
        public void Test_09_TestCmpTransitionPlanner() {
            // Remove aqll States, Counties, and Cities that are not in California, Washingto, or Oregon

            try {
                BizHub.CmpTransitionPlannerController oController = new CmpTransitionPlannerController();
                BizHub.Components.TransitionPlanner.CmpTransitionPlanner oPlanner = new BizHub.Components.TransitionPlanner.CmpTransitionPlanner();
                oPlanner.Controller = oController;
                oController.LoadSequences();
                Debug.WriteLine(oController.Sequences.Count.ToString());
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

        }
        private void OCriteria_OnIsExpandedChanged(object sender, EventArgs e) {
            Debug.WriteLine("On Expanded Change Occurred");
            SearchCriteria oCrfiteria = (SearchCriteria)sender;
            if (oCrfiteria.IsExpanded) {
                Debug.WriteLine("Is Expanded - True");
            }else {
                Debug.WriteLine("Is Expanded - False");
            }
        }
    }
}
