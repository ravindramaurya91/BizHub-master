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
using BizHub.Areas.Identity;
using Model;
using BizHub;

namespace Test {
    class TestUtilities {
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
        public void Test_01_GetProfileCard() {
            Int64 iEntityOid = 6;
            IdentityCardDTO oCard = null;
            BaseResponse oResponse;

            try {
                oResponse = DataService.GetIdentityCardByEntityOid(iEntityOid);
                oCard = (IdentityCardDTO)oResponse.Data;
                Console.WriteLine(oCard.FirstName);

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        

        [Test]
        public void Test_03_IntTest() {

            Int64 iOid = 23;
            Debug.WriteLine(iOid.ToString());


            try {
                List<Int32?> _ints = Base.Database.GetInstance().Fetch<Int32?>("SELECT ShowCompanyWebsite_Int FROM Listing WHERE Oid > @0", 0);
                List<EnumTester> oList = Base.Database.GetInstance().Fetch<EnumTester>("SELECT ShowCompanyWebsite_Int FROM Listing", null);


                EnumSample.eShowStatus eStatus = EnumSample.eShowStatus.NoShow;
                eStatus = EnumSample.eShowStatus.ShowProtected;

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public void Test_04_TestLookupManager_GetLookupNodes() {
            // This will load the LookupManger

            LookupManager oMgr = LookupManager.Instance;

            try {
                LookupDefinition oDef;
                oDef = oMgr.GetLookupDefinitionByLookupName("BusinessCategory");
                oDef = oMgr.GetLookupDefinitionByOid(oDef.Oid);

                //List<Lookup> oLookups = oMgr.GetLookupsByLookupDefinitionOid(oDef.Oid);
                List<LookupNode> oLookupNodes;
                oLookupNodes = oMgr.GetLookupNodesByLookupDefinitionOid(oDef.Oid); // This retrieves all of the LookupNode in a single list for a given definition
                oLookupNodes = oMgr.GetLookupNodesByLookupName("BusinessCategory"); // This retrieves a nested collection of LooupNode with Children in the nest for a given definition

                Int64 iOid = oLookupNodes[0].Oid;
                LookupNode oNode = LookupManager.Instance.GetLookupNodeByOid(iOid);

                LookupDefinition oStateDef = oMgr.GetLookupDefinitionByLookupName("State");
                List<Lookup> oStateLookups = oMgr.GetLookupsByLookupName("State");
                List<LookupNode> oStateNodes = oMgr.GetLookupNodesByLookupName("State");
                List<LookupNode> oCountyNodes = oMgr.GetLookupNodesByLookupName("County");
                List<LookupNode> oSelectCountyNodesForNewYork = oMgr.GetLookupNodesByLookupNameAndParentLookupValue("County", "New York");
                List<IHierarchy> oIHierarchyNodesForNewYork = oMgr.GetIHierarchyByLookupNameAndParentLookupValue("County", "New York");
                List<LookupNode> oSelectCountyNodesForMassachusetts = oMgr.GetLookupNodesByLookupNameAndParentLookupValue("County", "Massachusetts");
                List<LookupNode> oSelectCityNodesForCountyOfSuffolk = oMgr.GetLookupNodesByLookupNameAndParentLookupValue("City", "Suffolk");
                List<IHierarchy> oChildHiearchyForNewYork = oMgr.GetChildIHierarchyByParentConstant("STATE->NEWYORK");
                List<LookupNode> oChildNodesForNewYork = oMgr.GetChildLookupNodesByParentConstant("STATE->NEWYORK");
                List<LookupNode> oStateNodesForTheUSA = oMgr.GetChildLookupNodesByParentConstant("COUNTRY->UNITEDSTATES");
                LookupNode oStateNodeForTheUSA = oMgr.GetLookupNodeByConstant("COUNTRY->UNITEDSTATES");

                //List<Lookup> oStateLookupsForTheUSA1 = oMgr.GetChildLookupsByParentConstant("COUNTRY->UNITEDSTATES");
                //--??List<Lookup> oStateLookupsForTheUSA2 = oMgr.GetChildLookupsByParentOid(30);


                Int64[] oCountyList = new long[] { 33041, 33002 };  // Stanislaus and San Joaquin
                //List<Lookup> oCitiesCollectionByCounty = oMgr.GetChildLookupsByParentOidArray(oCountyList);
                //List<Lookup> oCitiesCollectionByCounty2 = oMgr.GetChildLookupsByParentOidArray_DelimitedString(",33041, 33002");

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public void Test_05_CreateListingWizardTester() {

            #region TestSetup
            ListingDTO oFullListing = ListingCreator.CreateFullTestListingObject();
            ListingDTO oEditedListingDTO = ListingCreator.CreateEditedFullTestListingObject();
            Model.BizHubUser oUser = null; // new Model.BizHubUser() { AccessFailedCount = 0, Country = "USA", DisplayName = "Test Testerson", Email = "Testerson@test.com", EmailConfirmed = true, EntityOid_Master = 1, FirstName = "Test", LastName = "Testerson", PhoneNumber = "222-222-2222", PhoneNumberConfirmed = true, UserName = "Tester", EntityOid = 6 };
            BizHub.PagListingSetupController Controller = new BizHub.PagListingSetupController();
            Controller.ListingDTO.lkpListingSetupStatusOid = LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->STEPONE");
            Controller.SetActiveArrow();
            #endregion (TestSetup)

            //---1
            #region Wizard Page 1 Properties

            //Wizard Page 1 Non-Required Fields
            Controller.ListingDTO.AdReasonForSelling = oFullListing.AdReasonForSelling;
            Controller.ListingDTO.FacilityOwned_Int = oFullListing.FacilityOwned_Int;
            Controller.ListingDTO.IsRealEstateInPrice = oFullListing.IsRealEstateInPrice;
            Controller.ListingDTO.BuildingCount = oFullListing.BuildingCount;
            Controller.ListingDTO.TotalSqFt = oFullListing.TotalSqFt;
            Controller.ListingDTO.OccupiedSqFt = oFullListing.OccupiedSqFt;
            Controller.ListingDTO.AdFacilityDescription = oFullListing.AdFacilityDescription;
            Controller.ListingDTO.Keywords = oFullListing.Keywords;
            Controller.ListingDTO.WebsiteURL = oFullListing.WebsiteURL;
            Controller.ListingDTO.YearEstablished = oFullListing.YearEstablished;
            Controller.ListingDTO.lkpBusinessCategoryOids = oFullListing.lkpBusinessCategoryOids;
            Controller.ListingDTO.EmployeeCount = oFullListing.EmployeeCount;
            Controller.ListingDTO.IsAbsenteeOwner = oFullListing.IsAbsenteeOwner;
            Controller.ListingDTO.IsFranchise = oFullListing.IsFranchise;
            Controller.ListingDTO.IsHomeBased = oFullListing.IsHomeBased;
            Controller.ListingDTO.IsRelocatable = oFullListing.IsRelocatable;
            Controller.ListingDTO.IsSbaPreApproved = oFullListing.IsSbaPreApproved;
            Controller.ListingDTO.Oid = oFullListing.Oid;
            Controller.ListingDTO.ContactName = oFullListing.ContactName;
            Controller.ListingDTO.ContactPhone = oFullListing.ContactPhone;

            #endregion (Wizard Page 1 Properties)

            #region Page 1 Assertions

            Assert.AreEqual(Controller.CurrentStep, 1);

            #endregion (Page 1 Assertions)

            #region Wizard Page 1
            //First Page of Wizard Start

            //This should error out asking for a Zip Code
            try {
                Controller.NavigateFromOneToTwo();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Zip Code is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            //This should error out asking for a Zip Code and Country to create Listing
            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "Must at least have a Country and Zip Code in order to save a listing in progress");
                Debug.WriteLine(ex.Message);
            }

            //Adding Zip Code to the Controller Object
            Controller.ListingDTO.Zip = oFullListing.Zip;

            //This should error out asking for a Business Name
            try {
                Controller.NavigateFromOneToTwo();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Business Name is required to proceed."); 
                Debug.WriteLine(ex.Message);
            }

            //Adding Company Name to the Controller Object
            Controller.ListingDTO.CompanyName = oFullListing.CompanyName;

            //This should error out asking for a Zip Code and Country to create Listing
            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "Must at least have a Country and Zip Code in order to save a listing in progress");
                Debug.WriteLine(ex.Message);
            }

          

            //This should error out asking for a Country
            try {
                Controller.NavigateFromOneToTwo();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Street Address is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            //This should error out asking for a Zip Code and Country to create Listing
            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "Must at least have a Country and Zip Code in order to save a listing in progress");
                Debug.WriteLine(ex.Message);
            }

            //Adding CountryOid to the Controller Object
            Controller.ListingDTO.lkpCountryOid = oFullListing.lkpCountryOid;

            //This should error out asking for an Address
            try {
                Controller.NavigateFromOneToTwo();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Street Address is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            //Adding Business Address to the Controller Object
            Controller.ListingDTO.Address = oFullListing.Address;
            Controller.ListingDTO.Address2 = oFullListing.Address2;

            //This should error out asking for a Contact Email
            try {
                Controller.NavigateFromOneToTwo();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Contact Email Address is required to proceed."); 
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            //Adding Contact Email to the Controller Object
            Controller.ListingDTO.ContactEmail = oFullListing.ContactEmail;

            //This Navigate should go through to the next page without errors.
            try {
                Controller.NavigateFromOneToTwo();
            } catch (Exception ex) {
                //This debug should not be hit.
                Debug.WriteLine(ex.Message);
            }

            //First Page of Wizard End
            #endregion (Wizard Page 1)

            //---2
            #region Wizard Page 2 Properties

            //Wizard Page 2 Non-Required Fields
            Controller.ListingDTO.EBITDA = oFullListing.EBITDA;
            Controller.ListingDTO.Inventory = oFullListing.Inventory;
            Controller.ListingDTO.FFandE = oFullListing.FFandE;
            Controller.ListingDTO.RealEstateValue = oFullListing.RealEstateValue;
            Controller.ListingDTO.MinimumDownPayment = oFullListing.MinimumDownPayment;

            #endregion (Wizard Page 2 Properties)

            #region Page 2 Assertions

            Assert.AreEqual(Controller.CurrentStep, 2);

            #endregion (Page 2 Assertions)

            #region Wizard Page 2
            //Second Page of Wizard Start

            //This should error out asking for a Asking Price
            try {
                Controller.NavigateFromTwoToThree();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Assert.AreEqual(ex.Message, "An Asking Price is required to proceed."); 
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.ListingPrice = oFullListing.ListingPrice;

            //This should error out asking for a Gross Revenue
            try {
                Controller.NavigateFromTwoToThree();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Assert.AreEqual(ex.Message, "Gross Revenue is required to proceed.");
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.GrossRevenue = oFullListing.GrossRevenue;

            //This should error out asking for Cash Flow
            try {
                Controller.NavigateFromTwoToThree();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Assert.AreEqual(ex.Message, "Cash Flow is required to proceed.");
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.CashFlow = oFullListing.CashFlow;

            //This should error out asking if the seller is Financed
            try {
                Controller.NavigateFromTwoToThree();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Assert.AreEqual(ex.Message, "Please select whether or not you are financed to proceed."); 
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.IsSellerFinanace = oFullListing.IsSellerFinanace;
            if (Controller.ListingDTO.IsSellerFinanace == true) {
                Controller.ListingDTO.SellerFinanceUpTo = oFullListing.SellerFinanceUpTo;
            }

            //This Navigate should go through to the next page without errors.
            try {
                Controller.NavigateFromTwoToThree();
            } catch (Exception ex) {
                //This debug should not be hit.
                Debug.WriteLine(ex.Message);
            }

            //Second Page of Wizard End
            #endregion (Wizard Page 2)

            //---3
            #region Wizard Page 3 Properties

            //Wizard Page 3 Non-Required Fields
            Controller.ListingDTO.ShowCashFlow_Int = oFullListing.ShowCashFlow_Int;
            Controller.ListingDTO.ShowCity_Int = oFullListing.ShowCity_Int;
            Controller.ListingDTO.ShowCompanyWebsite_Int = oFullListing.ShowCompanyWebsite_Int;
            Controller.ListingDTO.ShowCounty_Int = oFullListing.ShowCounty_Int;
            Controller.ListingDTO.ShowEBITDA_Int = oFullListing.ShowEBITDA_Int;
            Controller.ListingDTO.ShowFFE_Int = oFullListing.ShowFFE_Int;
            Controller.ListingDTO.ShowGrossRevenues_Int = oFullListing.ShowGrossRevenues_Int;
            Controller.ListingDTO.ShowInventory_Int = oFullListing.ShowInventory_Int;
            Controller.ListingDTO.ShowNumberOfEmployees_Int = oFullListing.ShowNumberOfEmployees_Int;
            Controller.ListingDTO.ShowYearEstablished_Int = oFullListing.ShowYearEstablished_Int;
            Controller.ListingDTO.ShowZip_Int = oFullListing.ShowZip_Int;
            Controller.ListingDTO.RealEstateIncluded_Int = oFullListing.RealEstateIncluded_Int;

            #endregion (Wizard Page 3 Properties)

            #region Page 3 Assertions

            Assert.AreEqual(Controller.CurrentStep, 3);

            #endregion (Page 3 Assertions)

            #region Wizard Page 3
            //Third Page of Wizard Start

            //This should error out asking for an Ad Title
            try {
                 Controller.CompleteListing();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Assert.AreEqual(ex.Message, "An Ad Title is required to proceed.");
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.AdTitle = oFullListing.AdTitle;

            //This should error out asking for an Ad TagLine
            try {
                Controller.CompleteListing();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Assert.AreEqual(ex.Message, "A Tag Line is required to proceed.");
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.AdTagLine = oFullListing.AdTagLine;

            //This should error out asking for an Ad Description
            try {
                Controller.CompleteListing();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Assert.AreEqual(ex.Message, "A Business Opportunity Description is required to proceed.");

            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.AdDescription = oFullListing.AdDescription;

            //This Navigate should go through and complete the save with no errors
            try {
                Controller.CompleteListing();
            } catch (Exception ex) {
                //This debug should not be hit.
                Debug.WriteLine(ex.Message);
            }

            //Third Page of Wizard End
            #endregion (Wizard Page 3)

            //---Complete
            #region Completed Listing Assertions

            #region Comparing Database Listing with the Controller Listing
            ListingDTO oCurrentListingDTO = SQL.GetListingDTOByListingOid(Controller.ListingDTO.Oid);
            Assert.AreEqual(oCurrentListingDTO.AdDescription, Controller.ListingDTO.AdDescription);
            Assert.AreEqual(oCurrentListingDTO.Address, Controller.ListingDTO.Address);
            Assert.AreEqual(oCurrentListingDTO.Address2, Controller.ListingDTO.Address2);
            Assert.AreEqual(oCurrentListingDTO.AdPhoto, Controller.ListingDTO.AdPhoto);
            Assert.AreEqual(oCurrentListingDTO.AdTagLine, Controller.ListingDTO.AdTagLine);
            Assert.AreEqual(oCurrentListingDTO.AdTitle, Controller.ListingDTO.AdTitle);
            Assert.AreEqual(oCurrentListingDTO.BuildingCount, Controller.ListingDTO.BuildingCount);
            Assert.AreEqual(oCurrentListingDTO.CashFlow, Controller.ListingDTO.CashFlow);
            Assert.AreEqual(oCurrentListingDTO.City, Controller.ListingDTO.City);
            Assert.AreEqual(oCurrentListingDTO.CompanyName, Controller.ListingDTO.CompanyName);
            Assert.AreEqual(oCurrentListingDTO.ContactEmail, Controller.ListingDTO.ContactEmail);
            Assert.AreEqual(oCurrentListingDTO.ContactName, Controller.ListingDTO.ContactName);
            Assert.AreEqual(oCurrentListingDTO.ContactPhone, Controller.ListingDTO.ContactPhone);
            Assert.AreEqual(oCurrentListingDTO.County, Controller.ListingDTO.County);
            Assert.AreEqual(oCurrentListingDTO.EBITDA, Controller.ListingDTO.EBITDA);
            Assert.AreEqual(oCurrentListingDTO.EmployeeCount, Controller.ListingDTO.EmployeeCount);
            Assert.AreEqual(oCurrentListingDTO.EntityOid, Controller.ListingDTO.EntityOid);
            Assert.AreEqual(oCurrentListingDTO.EntityOid_BillingAuthority, Controller.ListingDTO.EntityOid_BillingAuthority);
            Assert.AreEqual(oCurrentListingDTO.ExpirationDate, Controller.ListingDTO.ExpirationDate);
            Assert.AreEqual(oCurrentListingDTO.AdFacilityDescription, Controller.ListingDTO.AdFacilityDescription);
            Assert.AreEqual(oCurrentListingDTO.FacilityOwned_Int, Controller.ListingDTO.FacilityOwned_Int);
            Assert.AreEqual(oCurrentListingDTO.FFandE, Controller.ListingDTO.FFandE);
            Assert.AreEqual(oCurrentListingDTO.GrossRevenue, Controller.ListingDTO.GrossRevenue);
            Assert.AreEqual(oCurrentListingDTO.Inventory, Controller.ListingDTO.Inventory);
            Assert.AreEqual(oCurrentListingDTO.IsAbsenteeOwner, Controller.ListingDTO.IsAbsenteeOwner);
            Assert.AreEqual(oCurrentListingDTO.IsActive, Controller.ListingDTO.IsActive);
            Assert.AreEqual(oCurrentListingDTO.IsExpanded, Controller.ListingDTO.IsExpanded);
            Assert.AreEqual(oCurrentListingDTO.IsFranchise, Controller.ListingDTO.IsFranchise);
            Assert.AreEqual(oCurrentListingDTO.IsHidden, Controller.ListingDTO.IsHidden);
            Assert.AreEqual(oCurrentListingDTO.IsHomeBased, Controller.ListingDTO.IsHomeBased);
            Assert.AreEqual(oCurrentListingDTO.IsPartialSave, Controller.ListingDTO.IsPartialSave);
            Assert.AreEqual(oCurrentListingDTO.IsPending, Controller.ListingDTO.IsPending);
            Assert.AreEqual(oCurrentListingDTO.IsRealEstateInPrice, Controller.ListingDTO.IsRealEstateInPrice);
            Assert.AreEqual(oCurrentListingDTO.IsRelocatable, Controller.ListingDTO.IsRelocatable);
            Assert.AreEqual(oCurrentListingDTO.IsSbaPreApproved, Controller.ListingDTO.IsSbaPreApproved);
            Assert.AreEqual(oCurrentListingDTO.IsSellerFinanace, Controller.ListingDTO.IsSellerFinanace);
            Assert.AreEqual(oCurrentListingDTO.Keywords, Controller.ListingDTO.Keywords);
            Assert.AreEqual(oCurrentListingDTO.ListingPrice, Controller.ListingDTO.ListingPrice);
            Assert.AreEqual(oCurrentListingDTO.lkpBusinessCategoryOids, Controller.ListingDTO.lkpBusinessCategoryOids);
            Assert.AreEqual(oCurrentListingDTO.lkpCityOid, Controller.ListingDTO.lkpCityOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountryOid, Controller.ListingDTO.lkpCountryOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountyOid, Controller.ListingDTO.lkpCountyOid);
            Assert.AreEqual(oCurrentListingDTO.lkpLegalEntityTypeOid, Controller.ListingDTO.lkpLegalEntityTypeOid);
            Assert.AreEqual(oCurrentListingDTO.lkpListingSetupStatusOid, Controller.ListingDTO.lkpListingSetupStatusOid);
            Assert.AreEqual(oCurrentListingDTO.lkpStateOid, Controller.ListingDTO.lkpStateOid);
            Assert.AreEqual(oCurrentListingDTO.MinimumDownPayment, Controller.ListingDTO.MinimumDownPayment);
            Assert.AreEqual(oCurrentListingDTO.OccupiedSqFt, Controller.ListingDTO.OccupiedSqFt);
            Assert.AreEqual(oCurrentListingDTO.RealEstateIncluded_Int, Controller.ListingDTO.RealEstateIncluded_Int);
            Assert.AreEqual(oCurrentListingDTO.RealEstateValue, Controller.ListingDTO.RealEstateValue);
            Assert.AreEqual(oCurrentListingDTO.SellerFinanceUpTo, Controller.ListingDTO.SellerFinanceUpTo);
            Assert.AreEqual(oCurrentListingDTO.AdReasonForSelling, Controller.ListingDTO.AdReasonForSelling);
            Assert.AreEqual(oCurrentListingDTO.ShowCashFlow_Int, Controller.ListingDTO.ShowCashFlow_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCity_Int, Controller.ListingDTO.ShowCity_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCompanyWebsite_Int, Controller.ListingDTO.ShowCompanyWebsite_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCounty_Int, Controller.ListingDTO.ShowCounty_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowEBITDA_Int, Controller.ListingDTO.ShowEBITDA_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowFFE_Int, Controller.ListingDTO.ShowFFE_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowGrossRevenues_Int, Controller.ListingDTO.ShowGrossRevenues_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowInventory_Int, Controller.ListingDTO.ShowInventory_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowNumberOfEmployees_Int, Controller.ListingDTO.ShowNumberOfEmployees_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowYearEstablished_Int, Controller.ListingDTO.ShowYearEstablished_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowZip_Int, Controller.ListingDTO.ShowZip_Int);
            Assert.AreEqual(oCurrentListingDTO.State, Controller.ListingDTO.State);
            Assert.AreEqual(oCurrentListingDTO.TotalSqFt, Controller.ListingDTO.TotalSqFt);
            Assert.AreEqual(oCurrentListingDTO.WebsiteURL, Controller.ListingDTO.WebsiteURL);
            Assert.AreEqual(oCurrentListingDTO.YearEstablished, Controller.ListingDTO.YearEstablished);
            Assert.AreEqual(oCurrentListingDTO.Zip, Controller.ListingDTO.Zip);

            #endregion (Comparing Database Listing with the Controller Listing)

            Assert.IsTrue(Controller.ListingDTO.IsActive);
            Assert.IsFalse(Controller.ListingDTO.IsPending);
            Assert.AreEqual(Controller.ListingDTO.lkpListingSetupStatusOid, 36016);
            oEditedListingDTO.Oid = Controller.ListingDTO.Oid;

            #endregion (Completed Listing Assertions)

            //---Page 1 Wizard (With Completed and Active Listing)
            #region Nulling Required Page 1 Values And Assigning New Non-Required Values

            //Nulling out the required fields of the first Wizard Page.
            Controller.ListingDTO.Zip = null;
            Controller.ListingDTO.CompanyName = null;
            Controller.ListingDTO.lkpCountryOid = null;
            Controller.ListingDTO.Address = null;
            Controller.ListingDTO.ContactEmail = null;
            Controller.ListingDTO.ContactName = oEditedListingDTO.ContactName;
            Controller.ListingDTO.ContactPhone = oEditedListingDTO.ContactPhone;
            Controller.ListingDTO.AdReasonForSelling = oEditedListingDTO.AdReasonForSelling;
            Controller.ListingDTO.FacilityOwned_Int = oEditedListingDTO.FacilityOwned_Int;
            Controller.ListingDTO.IsRealEstateInPrice = oEditedListingDTO.IsRealEstateInPrice;
            Controller.ListingDTO.BuildingCount = oEditedListingDTO.BuildingCount;
            Controller.ListingDTO.TotalSqFt = oEditedListingDTO.TotalSqFt;
            Controller.ListingDTO.OccupiedSqFt = oEditedListingDTO.OccupiedSqFt;
            Controller.ListingDTO.AdFacilityDescription = oEditedListingDTO.AdFacilityDescription;
            Controller.ListingDTO.Keywords = oEditedListingDTO.Keywords;
            Controller.ListingDTO.WebsiteURL = oEditedListingDTO.WebsiteURL;
            Controller.ListingDTO.YearEstablished = oEditedListingDTO.YearEstablished;
            Controller.ListingDTO.lkpBusinessCategoryOids = oEditedListingDTO.lkpBusinessCategoryOids;
            Controller.ListingDTO.EmployeeCount = oEditedListingDTO.EmployeeCount;
            Controller.ListingDTO.IsAbsenteeOwner = oEditedListingDTO.IsAbsenteeOwner;
            Controller.ListingDTO.IsFranchise = oEditedListingDTO.IsFranchise;
            Controller.ListingDTO.IsHomeBased = oEditedListingDTO.IsHomeBased;
            Controller.ListingDTO.IsRelocatable = oEditedListingDTO.IsRelocatable;
            Controller.ListingDTO.IsSbaPreApproved = oEditedListingDTO.IsSbaPreApproved;

            #endregion (Nulling Required Page 1 Values And Assigning New Non-Required Values)

            //---1to3
            #region Page 1 Navigation to Page 3
            //Attempting to navigate from page 1 to page 3 after nulling out the required fields on the first page.
            try {
                Controller.NavigateFromOneToThree();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Zip Code is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A listing must have a Zipcode");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.Zip = oEditedListingDTO.Zip;

            try {
                Controller.NavigateFromOneToThree();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Business Name is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Country is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.CompanyName = oEditedListingDTO.CompanyName;

            try {
                Controller.NavigateFromOneToThree();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Country is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Country is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.lkpCountryOid = oEditedListingDTO.lkpCountryOid;

            try {
                Controller.NavigateFromOneToThree();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Street Address is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Street Address is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.Address = oEditedListingDTO.Address;
            Controller.ListingDTO.Address2 = oEditedListingDTO.Address2;

            try {
                Controller.NavigateFromOneToThree();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Contact Email Address is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Contact Email Address is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.ContactEmail = oEditedListingDTO.ContactEmail;

            try {
                Controller.NavigateFromOneToThree();
                Assert.AreEqual(Controller.CurrentStep, 3);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }


            #region Second Assertion Check to make sure the Database and Controller are sync'd

            //Checking to make sure the Database matches the object we are now holding.
            oCurrentListingDTO = SQL.GetListingDTOByListingOid(Controller.ListingDTO.Oid);
            Assert.AreEqual(oCurrentListingDTO.AdDescription, Controller.ListingDTO.AdDescription);
            Assert.AreEqual(oCurrentListingDTO.Address, Controller.ListingDTO.Address);
            Assert.AreEqual(oCurrentListingDTO.Address2, Controller.ListingDTO.Address2);
            Assert.AreEqual(oCurrentListingDTO.AdPhoto, Controller.ListingDTO.AdPhoto);
            Assert.AreEqual(oCurrentListingDTO.AdTagLine, Controller.ListingDTO.AdTagLine);
            Assert.AreEqual(oCurrentListingDTO.AdTitle, Controller.ListingDTO.AdTitle);
            Assert.AreEqual(oCurrentListingDTO.BuildingCount, Controller.ListingDTO.BuildingCount);
            Assert.AreEqual(oCurrentListingDTO.CashFlow, Controller.ListingDTO.CashFlow);
            Assert.AreEqual(oCurrentListingDTO.City, Controller.ListingDTO.City);
            Assert.AreEqual(oCurrentListingDTO.CompanyName, Controller.ListingDTO.CompanyName);
            Assert.AreEqual(oCurrentListingDTO.ContactEmail, Controller.ListingDTO.ContactEmail);
            Assert.AreEqual(oCurrentListingDTO.ContactName, Controller.ListingDTO.ContactName);
            Assert.AreEqual(oCurrentListingDTO.ContactPhone, Controller.ListingDTO.ContactPhone);
            Assert.AreEqual(oCurrentListingDTO.County, Controller.ListingDTO.County);
            Assert.AreEqual(oCurrentListingDTO.EBITDA, Controller.ListingDTO.EBITDA);
            Assert.AreEqual(oCurrentListingDTO.EmployeeCount, Controller.ListingDTO.EmployeeCount);
            Assert.AreEqual(oCurrentListingDTO.EntityOid, Controller.ListingDTO.EntityOid);
            Assert.AreEqual(oCurrentListingDTO.EntityOid_BillingAuthority, Controller.ListingDTO.EntityOid_BillingAuthority);
            Assert.AreEqual(oCurrentListingDTO.ExpirationDate, Controller.ListingDTO.ExpirationDate);
            Assert.AreEqual(oCurrentListingDTO.AdFacilityDescription, Controller.ListingDTO.AdFacilityDescription);
            Assert.AreEqual(oCurrentListingDTO.FacilityOwned_Int, Controller.ListingDTO.FacilityOwned_Int);
            Assert.AreEqual(oCurrentListingDTO.FFandE, Controller.ListingDTO.FFandE);
            Assert.AreEqual(oCurrentListingDTO.GrossRevenue, Controller.ListingDTO.GrossRevenue);
            Assert.AreEqual(oCurrentListingDTO.Inventory, Controller.ListingDTO.Inventory);
            Assert.AreEqual(oCurrentListingDTO.IsAbsenteeOwner, Controller.ListingDTO.IsAbsenteeOwner);
            Assert.AreEqual(oCurrentListingDTO.IsActive, Controller.ListingDTO.IsActive);
            Assert.AreEqual(oCurrentListingDTO.IsExpanded, Controller.ListingDTO.IsExpanded);
            Assert.AreEqual(oCurrentListingDTO.IsFranchise, Controller.ListingDTO.IsFranchise);
            Assert.AreEqual(oCurrentListingDTO.IsHidden, Controller.ListingDTO.IsHidden);
            Assert.AreEqual(oCurrentListingDTO.IsHomeBased, Controller.ListingDTO.IsHomeBased);
            Assert.AreEqual(oCurrentListingDTO.IsPartialSave, Controller.ListingDTO.IsPartialSave);
            Assert.AreEqual(oCurrentListingDTO.IsPending, Controller.ListingDTO.IsPending);
            Assert.AreEqual(oCurrentListingDTO.IsRealEstateInPrice, Controller.ListingDTO.IsRealEstateInPrice);
            Assert.AreEqual(oCurrentListingDTO.IsRelocatable, Controller.ListingDTO.IsRelocatable);
            Assert.AreEqual(oCurrentListingDTO.IsSbaPreApproved, Controller.ListingDTO.IsSbaPreApproved);
            Assert.AreEqual(oCurrentListingDTO.IsSellerFinanace, Controller.ListingDTO.IsSellerFinanace);
            Assert.AreEqual(oCurrentListingDTO.Keywords, Controller.ListingDTO.Keywords);
            Assert.AreEqual(oCurrentListingDTO.ListingPrice, Controller.ListingDTO.ListingPrice);
            Assert.AreEqual(oCurrentListingDTO.lkpBusinessCategoryOids, Controller.ListingDTO.lkpBusinessCategoryOids);
            Assert.AreEqual(oCurrentListingDTO.lkpCityOid, Controller.ListingDTO.lkpCityOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountryOid, Controller.ListingDTO.lkpCountryOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountyOid, Controller.ListingDTO.lkpCountyOid);
            Assert.AreEqual(oCurrentListingDTO.lkpLegalEntityTypeOid, Controller.ListingDTO.lkpLegalEntityTypeOid);
            Assert.AreEqual(oCurrentListingDTO.lkpListingSetupStatusOid, Controller.ListingDTO.lkpListingSetupStatusOid);
            Assert.AreEqual(oCurrentListingDTO.lkpStateOid, Controller.ListingDTO.lkpStateOid);
            Assert.AreEqual(oCurrentListingDTO.MinimumDownPayment, Controller.ListingDTO.MinimumDownPayment);
            Assert.AreEqual(oCurrentListingDTO.OccupiedSqFt, Controller.ListingDTO.OccupiedSqFt);
            Assert.AreEqual(oCurrentListingDTO.RealEstateIncluded_Int, Controller.ListingDTO.RealEstateIncluded_Int);
            Assert.AreEqual(oCurrentListingDTO.RealEstateValue, Controller.ListingDTO.RealEstateValue);
            Assert.AreEqual(oCurrentListingDTO.SellerFinanceUpTo, Controller.ListingDTO.SellerFinanceUpTo);
            Assert.AreEqual(oCurrentListingDTO.AdReasonForSelling, Controller.ListingDTO.AdReasonForSelling);
            Assert.AreEqual(oCurrentListingDTO.ShowCashFlow_Int, Controller.ListingDTO.ShowCashFlow_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCity_Int, Controller.ListingDTO.ShowCity_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCompanyWebsite_Int, Controller.ListingDTO.ShowCompanyWebsite_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCounty_Int, Controller.ListingDTO.ShowCounty_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowEBITDA_Int, Controller.ListingDTO.ShowEBITDA_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowFFE_Int, Controller.ListingDTO.ShowFFE_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowGrossRevenues_Int, Controller.ListingDTO.ShowGrossRevenues_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowInventory_Int, Controller.ListingDTO.ShowInventory_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowNumberOfEmployees_Int, Controller.ListingDTO.ShowNumberOfEmployees_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowYearEstablished_Int, Controller.ListingDTO.ShowYearEstablished_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowZip_Int, Controller.ListingDTO.ShowZip_Int);
            Assert.AreEqual(oCurrentListingDTO.State, Controller.ListingDTO.State);
            Assert.AreEqual(oCurrentListingDTO.TotalSqFt, Controller.ListingDTO.TotalSqFt);
            Assert.AreEqual(oCurrentListingDTO.WebsiteURL, Controller.ListingDTO.WebsiteURL);
            Assert.AreEqual(oCurrentListingDTO.YearEstablished, Controller.ListingDTO.YearEstablished);
            Assert.AreEqual(oCurrentListingDTO.Zip, Controller.ListingDTO.Zip);

            #endregion (Second Assertion Check to make sure the Database and Controller are sync'd)

            #endregion (Page 1 Navigation to Page 3)

            //---Page 3 Wizard (With Completed and Active Listing)
            #region Nulling Required Page 3 Values And Assigning New Non-Required Values
            Controller.ListingDTO.AdTitle = null;
            Controller.ListingDTO.AdTagLine = null;
            Controller.ListingDTO.AdDescription = null;
            Controller.ListingDTO.ShowCashFlow_Int = oEditedListingDTO.ShowCashFlow_Int;
            Controller.ListingDTO.ShowCity_Int = oEditedListingDTO.ShowCity_Int;
            Controller.ListingDTO.ShowCompanyWebsite_Int = oEditedListingDTO.ShowCompanyWebsite_Int;
            Controller.ListingDTO.ShowCounty_Int = oEditedListingDTO.ShowCounty_Int;
            Controller.ListingDTO.ShowEBITDA_Int = oEditedListingDTO.ShowEBITDA_Int;
            Controller.ListingDTO.ShowFFE_Int = oEditedListingDTO.ShowFFE_Int;
            Controller.ListingDTO.ShowGrossRevenues_Int = oEditedListingDTO.ShowGrossRevenues_Int;
            Controller.ListingDTO.ShowInventory_Int = oEditedListingDTO.ShowInventory_Int;
            Controller.ListingDTO.ShowNumberOfEmployees_Int = oEditedListingDTO.ShowNumberOfEmployees_Int;
            Controller.ListingDTO.ShowYearEstablished_Int = oEditedListingDTO.ShowYearEstablished_Int;
            Controller.ListingDTO.ShowZip_Int = oEditedListingDTO.ShowZip_Int;
            Controller.ListingDTO.RealEstateIncluded_Int = oEditedListingDTO.RealEstateIncluded_Int;

            #endregion (Nulling Required Page 3 Values And Assigning New Non-Required Values)

            //---3to2
            #region Page 3 Navigation to Page 2
            try {
                Controller.NavigateToNewStep(2);
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "An Ad Title is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "An Ad Title is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.AdTitle = oEditedListingDTO.AdTitle;

            try {
                Controller.NavigateToNewStep(2);
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Tag Line is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Tag Line is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.AdTagLine = oEditedListingDTO.AdTagLine;

            try {
                Controller.NavigateToNewStep(2);
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Business Opportunity Description is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Business Opportunity Description is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.AdDescription = oEditedListingDTO.AdDescription;

            try {
                Controller.NavigateToNewStep(2);
                Assert.AreEqual(Controller.CurrentStep, 2);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            #region Third Assertion Check to make sure the Database and Controller are sync'd

            //Checking to make sure the Database matches the object we are now holding.
            oCurrentListingDTO = SQL.GetListingDTOByListingOid(Controller.ListingDTO.Oid);
            Assert.AreEqual(oCurrentListingDTO.AdDescription, Controller.ListingDTO.AdDescription);
            Assert.AreEqual(oCurrentListingDTO.Address, Controller.ListingDTO.Address);
            Assert.AreEqual(oCurrentListingDTO.Address2, Controller.ListingDTO.Address2);
            Assert.AreEqual(oCurrentListingDTO.AdPhoto, Controller.ListingDTO.AdPhoto);
            Assert.AreEqual(oCurrentListingDTO.AdTagLine, Controller.ListingDTO.AdTagLine);
            Assert.AreEqual(oCurrentListingDTO.AdTitle, Controller.ListingDTO.AdTitle);
            Assert.AreEqual(oCurrentListingDTO.BuildingCount, Controller.ListingDTO.BuildingCount);
            Assert.AreEqual(oCurrentListingDTO.CashFlow, Controller.ListingDTO.CashFlow);
            Assert.AreEqual(oCurrentListingDTO.City, Controller.ListingDTO.City);
            Assert.AreEqual(oCurrentListingDTO.CompanyName, Controller.ListingDTO.CompanyName);
            Assert.AreEqual(oCurrentListingDTO.ContactEmail, Controller.ListingDTO.ContactEmail);
            Assert.AreEqual(oCurrentListingDTO.ContactName, Controller.ListingDTO.ContactName);
            Assert.AreEqual(oCurrentListingDTO.ContactPhone, Controller.ListingDTO.ContactPhone);
            Assert.AreEqual(oCurrentListingDTO.County, Controller.ListingDTO.County);
            Assert.AreEqual(oCurrentListingDTO.EBITDA, Controller.ListingDTO.EBITDA);
            Assert.AreEqual(oCurrentListingDTO.EmployeeCount, Controller.ListingDTO.EmployeeCount);
            Assert.AreEqual(oCurrentListingDTO.EntityOid, Controller.ListingDTO.EntityOid);
            Assert.AreEqual(oCurrentListingDTO.EntityOid_BillingAuthority, Controller.ListingDTO.EntityOid_BillingAuthority);
            Assert.AreEqual(oCurrentListingDTO.ExpirationDate, Controller.ListingDTO.ExpirationDate);
            Assert.AreEqual(oCurrentListingDTO.AdFacilityDescription, Controller.ListingDTO.AdFacilityDescription);
            Assert.AreEqual(oCurrentListingDTO.FacilityOwned_Int, Controller.ListingDTO.FacilityOwned_Int);
            Assert.AreEqual(oCurrentListingDTO.FFandE, Controller.ListingDTO.FFandE);
            Assert.AreEqual(oCurrentListingDTO.GrossRevenue, Controller.ListingDTO.GrossRevenue);
            Assert.AreEqual(oCurrentListingDTO.Inventory, Controller.ListingDTO.Inventory);
            Assert.AreEqual(oCurrentListingDTO.IsAbsenteeOwner, Controller.ListingDTO.IsAbsenteeOwner);
            Assert.AreEqual(oCurrentListingDTO.IsActive, Controller.ListingDTO.IsActive);
            Assert.AreEqual(oCurrentListingDTO.IsExpanded, Controller.ListingDTO.IsExpanded);
            Assert.AreEqual(oCurrentListingDTO.IsFranchise, Controller.ListingDTO.IsFranchise);
            Assert.AreEqual(oCurrentListingDTO.IsHidden, Controller.ListingDTO.IsHidden);
            Assert.AreEqual(oCurrentListingDTO.IsHomeBased, Controller.ListingDTO.IsHomeBased);
            Assert.AreEqual(oCurrentListingDTO.IsPartialSave, Controller.ListingDTO.IsPartialSave);
            Assert.AreEqual(oCurrentListingDTO.IsPending, Controller.ListingDTO.IsPending);
            Assert.AreEqual(oCurrentListingDTO.IsRealEstateInPrice, Controller.ListingDTO.IsRealEstateInPrice);
            Assert.AreEqual(oCurrentListingDTO.IsRelocatable, Controller.ListingDTO.IsRelocatable);
            Assert.AreEqual(oCurrentListingDTO.IsSbaPreApproved, Controller.ListingDTO.IsSbaPreApproved);
            Assert.AreEqual(oCurrentListingDTO.IsSellerFinanace, Controller.ListingDTO.IsSellerFinanace);
            Assert.AreEqual(oCurrentListingDTO.Keywords, Controller.ListingDTO.Keywords);
            Assert.AreEqual(oCurrentListingDTO.ListingPrice, Controller.ListingDTO.ListingPrice);
            Assert.AreEqual(oCurrentListingDTO.lkpBusinessCategoryOids, Controller.ListingDTO.lkpBusinessCategoryOids);
            Assert.AreEqual(oCurrentListingDTO.lkpCityOid, Controller.ListingDTO.lkpCityOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountryOid, Controller.ListingDTO.lkpCountryOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountyOid, Controller.ListingDTO.lkpCountyOid);
            Assert.AreEqual(oCurrentListingDTO.lkpLegalEntityTypeOid, Controller.ListingDTO.lkpLegalEntityTypeOid);
            Assert.AreEqual(oCurrentListingDTO.lkpListingSetupStatusOid, Controller.ListingDTO.lkpListingSetupStatusOid);
            Assert.AreEqual(oCurrentListingDTO.lkpStateOid, Controller.ListingDTO.lkpStateOid);
            Assert.AreEqual(oCurrentListingDTO.MinimumDownPayment, Controller.ListingDTO.MinimumDownPayment);
            Assert.AreEqual(oCurrentListingDTO.OccupiedSqFt, Controller.ListingDTO.OccupiedSqFt);
            Assert.AreEqual(oCurrentListingDTO.RealEstateIncluded_Int, Controller.ListingDTO.RealEstateIncluded_Int);
            Assert.AreEqual(oCurrentListingDTO.RealEstateValue, Controller.ListingDTO.RealEstateValue);
            Assert.AreEqual(oCurrentListingDTO.SellerFinanceUpTo, Controller.ListingDTO.SellerFinanceUpTo);
            Assert.AreEqual(oCurrentListingDTO.AdReasonForSelling, Controller.ListingDTO.AdReasonForSelling);
            Assert.AreEqual(oCurrentListingDTO.ShowCashFlow_Int, Controller.ListingDTO.ShowCashFlow_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCity_Int, Controller.ListingDTO.ShowCity_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCompanyWebsite_Int, Controller.ListingDTO.ShowCompanyWebsite_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCounty_Int, Controller.ListingDTO.ShowCounty_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowEBITDA_Int, Controller.ListingDTO.ShowEBITDA_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowFFE_Int, Controller.ListingDTO.ShowFFE_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowGrossRevenues_Int, Controller.ListingDTO.ShowGrossRevenues_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowInventory_Int, Controller.ListingDTO.ShowInventory_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowNumberOfEmployees_Int, Controller.ListingDTO.ShowNumberOfEmployees_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowYearEstablished_Int, Controller.ListingDTO.ShowYearEstablished_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowZip_Int, Controller.ListingDTO.ShowZip_Int);
            Assert.AreEqual(oCurrentListingDTO.State, Controller.ListingDTO.State);
            Assert.AreEqual(oCurrentListingDTO.TotalSqFt, Controller.ListingDTO.TotalSqFt);
            Assert.AreEqual(oCurrentListingDTO.WebsiteURL, Controller.ListingDTO.WebsiteURL);
            Assert.AreEqual(oCurrentListingDTO.YearEstablished, Controller.ListingDTO.YearEstablished);
            Assert.AreEqual(oCurrentListingDTO.Zip, Controller.ListingDTO.Zip);

            #endregion (Third Assertion Check to make sure the Database and Controller are sync'd)

            #endregion (Page 3 Navigation to Page 2)


            //---Page 2 Wizard (With Completed and Active Listing)
            #region Nulling Required Page 2 Values And Assigning New Non-Required Values

            Controller.ListingDTO.ListingPrice = null;
            Controller.ListingDTO.GrossRevenue = null;
            Controller.ListingDTO.CashFlow = null;
            Controller.ListingDTO.IsSellerFinanace = null;
            Controller.ListingDTO.EBITDA = oEditedListingDTO.EBITDA;
            Controller.ListingDTO.Inventory = oEditedListingDTO.Inventory;
            Controller.ListingDTO.FFandE = oEditedListingDTO.FFandE;
            Controller.ListingDTO.RealEstateValue = oEditedListingDTO.RealEstateValue;
            Controller.ListingDTO.MinimumDownPayment = oEditedListingDTO.MinimumDownPayment;

            #endregion (Nulling Required Page 3 Values And Assigning New Non-Required Values)

            //---2to1
            #region Page 2 Navigation to Page 1
            try {
                Controller.NavigateToNewStep(1);
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "An Asking Price is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.ListingPrice = oEditedListingDTO.ListingPrice;

            try {
                Controller.NavigateToNewStep(1);
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "Gross Revenue is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.GrossRevenue = oEditedListingDTO.GrossRevenue;

            try {
                Controller.NavigateToNewStep(1);
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "Cash Flow is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.CashFlow = oEditedListingDTO.CashFlow;

            try {
                Controller.NavigateToNewStep(1);
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "Please select whether or not you are financed to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.IsSellerFinanace = oFullListing.IsSellerFinanace;
            if (Controller.ListingDTO.IsSellerFinanace == true) {
                Controller.ListingDTO.SellerFinanceUpTo = oFullListing.SellerFinanceUpTo;
            }

            try {
                Controller.NavigateToNewStep(1);
                Assert.AreEqual(Controller.CurrentStep, 2);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            #region Third Assertion Check to make sure the Database and Controller are sync'd

            //Checking to make sure the Database matches the object we are now holding.
            oCurrentListingDTO = SQL.GetListingDTOByListingOid(Controller.ListingDTO.Oid);
            Assert.AreEqual(oCurrentListingDTO.AdDescription, Controller.ListingDTO.AdDescription);
            Assert.AreEqual(oCurrentListingDTO.Address, Controller.ListingDTO.Address);
            Assert.AreEqual(oCurrentListingDTO.Address2, Controller.ListingDTO.Address2);
            Assert.AreEqual(oCurrentListingDTO.AdPhoto, Controller.ListingDTO.AdPhoto);
            Assert.AreEqual(oCurrentListingDTO.AdTagLine, Controller.ListingDTO.AdTagLine);
            Assert.AreEqual(oCurrentListingDTO.AdTitle, Controller.ListingDTO.AdTitle);
            Assert.AreEqual(oCurrentListingDTO.BuildingCount, Controller.ListingDTO.BuildingCount);
            Assert.AreEqual(oCurrentListingDTO.CashFlow, Controller.ListingDTO.CashFlow);
            Assert.AreEqual(oCurrentListingDTO.City, Controller.ListingDTO.City);
            Assert.AreEqual(oCurrentListingDTO.CompanyName, Controller.ListingDTO.CompanyName);
            Assert.AreEqual(oCurrentListingDTO.ContactEmail, Controller.ListingDTO.ContactEmail);
            Assert.AreEqual(oCurrentListingDTO.ContactName, Controller.ListingDTO.ContactName);
            Assert.AreEqual(oCurrentListingDTO.ContactPhone, Controller.ListingDTO.ContactPhone);
            Assert.AreEqual(oCurrentListingDTO.County, Controller.ListingDTO.County);
            Assert.AreEqual(oCurrentListingDTO.EBITDA, Controller.ListingDTO.EBITDA);
            Assert.AreEqual(oCurrentListingDTO.EmployeeCount, Controller.ListingDTO.EmployeeCount);
            Assert.AreEqual(oCurrentListingDTO.EntityOid, Controller.ListingDTO.EntityOid);
            Assert.AreEqual(oCurrentListingDTO.EntityOid_BillingAuthority, Controller.ListingDTO.EntityOid_BillingAuthority);
            Assert.AreEqual(oCurrentListingDTO.ExpirationDate, Controller.ListingDTO.ExpirationDate);
            Assert.AreEqual(oCurrentListingDTO.AdFacilityDescription, Controller.ListingDTO.AdFacilityDescription);
            Assert.AreEqual(oCurrentListingDTO.FacilityOwned_Int, Controller.ListingDTO.FacilityOwned_Int);
            Assert.AreEqual(oCurrentListingDTO.FFandE, Controller.ListingDTO.FFandE);
            Assert.AreEqual(oCurrentListingDTO.GrossRevenue, Controller.ListingDTO.GrossRevenue);
            Assert.AreEqual(oCurrentListingDTO.Inventory, Controller.ListingDTO.Inventory);
            Assert.AreEqual(oCurrentListingDTO.IsAbsenteeOwner, Controller.ListingDTO.IsAbsenteeOwner);
            Assert.AreEqual(oCurrentListingDTO.IsActive, Controller.ListingDTO.IsActive);
            Assert.AreEqual(oCurrentListingDTO.IsExpanded, Controller.ListingDTO.IsExpanded);
            Assert.AreEqual(oCurrentListingDTO.IsFranchise, Controller.ListingDTO.IsFranchise);
            Assert.AreEqual(oCurrentListingDTO.IsHidden, Controller.ListingDTO.IsHidden);
            Assert.AreEqual(oCurrentListingDTO.IsHomeBased, Controller.ListingDTO.IsHomeBased);
            Assert.AreEqual(oCurrentListingDTO.IsPartialSave, Controller.ListingDTO.IsPartialSave);
            Assert.AreEqual(oCurrentListingDTO.IsPending, Controller.ListingDTO.IsPending);
            Assert.AreEqual(oCurrentListingDTO.IsRealEstateInPrice, Controller.ListingDTO.IsRealEstateInPrice);
            Assert.AreEqual(oCurrentListingDTO.IsRelocatable, Controller.ListingDTO.IsRelocatable);
            Assert.AreEqual(oCurrentListingDTO.IsSbaPreApproved, Controller.ListingDTO.IsSbaPreApproved);
            Assert.AreEqual(oCurrentListingDTO.IsSellerFinanace, Controller.ListingDTO.IsSellerFinanace);
            Assert.AreEqual(oCurrentListingDTO.Keywords, Controller.ListingDTO.Keywords);
            Assert.AreEqual(oCurrentListingDTO.ListingPrice, Controller.ListingDTO.ListingPrice);
            Assert.AreEqual(oCurrentListingDTO.lkpBusinessCategoryOids, Controller.ListingDTO.lkpBusinessCategoryOids);
            Assert.AreEqual(oCurrentListingDTO.lkpCityOid, Controller.ListingDTO.lkpCityOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountryOid, Controller.ListingDTO.lkpCountryOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountyOid, Controller.ListingDTO.lkpCountyOid);
            Assert.AreEqual(oCurrentListingDTO.lkpLegalEntityTypeOid, Controller.ListingDTO.lkpLegalEntityTypeOid);
            Assert.AreEqual(oCurrentListingDTO.lkpListingSetupStatusOid, Controller.ListingDTO.lkpListingSetupStatusOid);
            Assert.AreEqual(oCurrentListingDTO.lkpStateOid, Controller.ListingDTO.lkpStateOid);
            Assert.AreEqual(oCurrentListingDTO.MinimumDownPayment, Controller.ListingDTO.MinimumDownPayment);
            Assert.AreEqual(oCurrentListingDTO.OccupiedSqFt, Controller.ListingDTO.OccupiedSqFt);
            Assert.AreEqual(oCurrentListingDTO.RealEstateIncluded_Int, Controller.ListingDTO.RealEstateIncluded_Int);
            Assert.AreEqual(oCurrentListingDTO.RealEstateValue, Controller.ListingDTO.RealEstateValue);
            Assert.AreEqual(oCurrentListingDTO.SellerFinanceUpTo, Controller.ListingDTO.SellerFinanceUpTo);
            Assert.AreEqual(oCurrentListingDTO.AdReasonForSelling, Controller.ListingDTO.AdReasonForSelling);
            Assert.AreEqual(oCurrentListingDTO.ShowCashFlow_Int, Controller.ListingDTO.ShowCashFlow_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCity_Int, Controller.ListingDTO.ShowCity_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCompanyWebsite_Int, Controller.ListingDTO.ShowCompanyWebsite_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCounty_Int, Controller.ListingDTO.ShowCounty_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowEBITDA_Int, Controller.ListingDTO.ShowEBITDA_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowFFE_Int, Controller.ListingDTO.ShowFFE_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowGrossRevenues_Int, Controller.ListingDTO.ShowGrossRevenues_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowInventory_Int, Controller.ListingDTO.ShowInventory_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowNumberOfEmployees_Int, Controller.ListingDTO.ShowNumberOfEmployees_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowYearEstablished_Int, Controller.ListingDTO.ShowYearEstablished_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowZip_Int, Controller.ListingDTO.ShowZip_Int);
            Assert.AreEqual(oCurrentListingDTO.State, Controller.ListingDTO.State);
            Assert.AreEqual(oCurrentListingDTO.TotalSqFt, Controller.ListingDTO.TotalSqFt);
            Assert.AreEqual(oCurrentListingDTO.WebsiteURL, Controller.ListingDTO.WebsiteURL);
            Assert.AreEqual(oCurrentListingDTO.YearEstablished, Controller.ListingDTO.YearEstablished);
            Assert.AreEqual(oCurrentListingDTO.Zip, Controller.ListingDTO.Zip);

            #endregion (Third Assertion Check to make sure the Database and Controller are sync'd)

            #endregion (Page 2 Navigation to Page 1)

            #region Page 1 Navigation to Page 3
            try {
                Controller.SetActiveArrow();
                Controller.NavigateFromOneToThree();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            #region Third Assertion Check to make sure the Database and Controller are sync'd

            //Checking to make sure the Database matches the object we are now holding.
            oCurrentListingDTO = SQL.GetListingDTOByListingOid(Controller.ListingDTO.Oid);
            Assert.AreEqual(oCurrentListingDTO.AdDescription, Controller.ListingDTO.AdDescription);
            Assert.AreEqual(oCurrentListingDTO.Address, Controller.ListingDTO.Address);
            Assert.AreEqual(oCurrentListingDTO.Address2, Controller.ListingDTO.Address2);
            Assert.AreEqual(oCurrentListingDTO.AdPhoto, Controller.ListingDTO.AdPhoto);
            Assert.AreEqual(oCurrentListingDTO.AdTagLine, Controller.ListingDTO.AdTagLine);
            Assert.AreEqual(oCurrentListingDTO.AdTitle, Controller.ListingDTO.AdTitle);
            Assert.AreEqual(oCurrentListingDTO.BuildingCount, Controller.ListingDTO.BuildingCount);
            Assert.AreEqual(oCurrentListingDTO.CashFlow, Controller.ListingDTO.CashFlow);
            Assert.AreEqual(oCurrentListingDTO.City, Controller.ListingDTO.City);
            Assert.AreEqual(oCurrentListingDTO.CompanyName, Controller.ListingDTO.CompanyName);
            Assert.AreEqual(oCurrentListingDTO.ContactEmail, Controller.ListingDTO.ContactEmail);
            Assert.AreEqual(oCurrentListingDTO.ContactName, Controller.ListingDTO.ContactName);
            Assert.AreEqual(oCurrentListingDTO.ContactPhone, Controller.ListingDTO.ContactPhone);
            Assert.AreEqual(oCurrentListingDTO.County, Controller.ListingDTO.County);
            Assert.AreEqual(oCurrentListingDTO.EBITDA, Controller.ListingDTO.EBITDA);
            Assert.AreEqual(oCurrentListingDTO.EmployeeCount, Controller.ListingDTO.EmployeeCount);
            Assert.AreEqual(oCurrentListingDTO.EntityOid, Controller.ListingDTO.EntityOid);
            Assert.AreEqual(oCurrentListingDTO.EntityOid_BillingAuthority, Controller.ListingDTO.EntityOid_BillingAuthority);
            Assert.AreEqual(oCurrentListingDTO.ExpirationDate, Controller.ListingDTO.ExpirationDate);
            Assert.AreEqual(oCurrentListingDTO.AdFacilityDescription, Controller.ListingDTO.AdFacilityDescription);
            Assert.AreEqual(oCurrentListingDTO.FacilityOwned_Int, Controller.ListingDTO.FacilityOwned_Int);
            Assert.AreEqual(oCurrentListingDTO.FFandE, Controller.ListingDTO.FFandE);
            Assert.AreEqual(oCurrentListingDTO.GrossRevenue, Controller.ListingDTO.GrossRevenue);
            Assert.AreEqual(oCurrentListingDTO.Inventory, Controller.ListingDTO.Inventory);
            Assert.AreEqual(oCurrentListingDTO.IsAbsenteeOwner, Controller.ListingDTO.IsAbsenteeOwner);
            Assert.AreEqual(oCurrentListingDTO.IsActive, Controller.ListingDTO.IsActive);
            Assert.AreEqual(oCurrentListingDTO.IsExpanded, Controller.ListingDTO.IsExpanded);
            Assert.AreEqual(oCurrentListingDTO.IsFranchise, Controller.ListingDTO.IsFranchise);
            Assert.AreEqual(oCurrentListingDTO.IsHidden, Controller.ListingDTO.IsHidden);
            Assert.AreEqual(oCurrentListingDTO.IsHomeBased, Controller.ListingDTO.IsHomeBased);
            Assert.AreEqual(oCurrentListingDTO.IsPartialSave, Controller.ListingDTO.IsPartialSave);
            Assert.AreEqual(oCurrentListingDTO.IsPending, Controller.ListingDTO.IsPending);
            Assert.AreEqual(oCurrentListingDTO.IsRealEstateInPrice, Controller.ListingDTO.IsRealEstateInPrice);
            Assert.AreEqual(oCurrentListingDTO.IsRelocatable, Controller.ListingDTO.IsRelocatable);
            Assert.AreEqual(oCurrentListingDTO.IsSbaPreApproved, Controller.ListingDTO.IsSbaPreApproved);
            Assert.AreEqual(oCurrentListingDTO.IsSellerFinanace, Controller.ListingDTO.IsSellerFinanace);
            Assert.AreEqual(oCurrentListingDTO.Keywords, Controller.ListingDTO.Keywords);
            Assert.AreEqual(oCurrentListingDTO.ListingPrice, Controller.ListingDTO.ListingPrice);
            Assert.AreEqual(oCurrentListingDTO.lkpBusinessCategoryOids, Controller.ListingDTO.lkpBusinessCategoryOids);
            Assert.AreEqual(oCurrentListingDTO.lkpCityOid, Controller.ListingDTO.lkpCityOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountryOid, Controller.ListingDTO.lkpCountryOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountyOid, Controller.ListingDTO.lkpCountyOid);
            Assert.AreEqual(oCurrentListingDTO.lkpLegalEntityTypeOid, Controller.ListingDTO.lkpLegalEntityTypeOid);
            Assert.AreEqual(oCurrentListingDTO.lkpListingSetupStatusOid, Controller.ListingDTO.lkpListingSetupStatusOid);
            Assert.AreEqual(oCurrentListingDTO.lkpStateOid, Controller.ListingDTO.lkpStateOid);
            Assert.AreEqual(oCurrentListingDTO.MinimumDownPayment, Controller.ListingDTO.MinimumDownPayment);
            Assert.AreEqual(oCurrentListingDTO.OccupiedSqFt, Controller.ListingDTO.OccupiedSqFt);
            Assert.AreEqual(oCurrentListingDTO.RealEstateIncluded_Int, Controller.ListingDTO.RealEstateIncluded_Int);
            Assert.AreEqual(oCurrentListingDTO.RealEstateValue, Controller.ListingDTO.RealEstateValue);
            Assert.AreEqual(oCurrentListingDTO.SellerFinanceUpTo, Controller.ListingDTO.SellerFinanceUpTo);
            Assert.AreEqual(oCurrentListingDTO.AdReasonForSelling, Controller.ListingDTO.AdReasonForSelling);
            Assert.AreEqual(oCurrentListingDTO.ShowCashFlow_Int, Controller.ListingDTO.ShowCashFlow_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCity_Int, Controller.ListingDTO.ShowCity_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCompanyWebsite_Int, Controller.ListingDTO.ShowCompanyWebsite_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCounty_Int, Controller.ListingDTO.ShowCounty_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowEBITDA_Int, Controller.ListingDTO.ShowEBITDA_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowFFE_Int, Controller.ListingDTO.ShowFFE_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowGrossRevenues_Int, Controller.ListingDTO.ShowGrossRevenues_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowInventory_Int, Controller.ListingDTO.ShowInventory_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowNumberOfEmployees_Int, Controller.ListingDTO.ShowNumberOfEmployees_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowYearEstablished_Int, Controller.ListingDTO.ShowYearEstablished_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowZip_Int, Controller.ListingDTO.ShowZip_Int);
            Assert.AreEqual(oCurrentListingDTO.State, Controller.ListingDTO.State);
            Assert.AreEqual(oCurrentListingDTO.TotalSqFt, Controller.ListingDTO.TotalSqFt);
            Assert.AreEqual(oCurrentListingDTO.WebsiteURL, Controller.ListingDTO.WebsiteURL);
            Assert.AreEqual(oCurrentListingDTO.YearEstablished, Controller.ListingDTO.YearEstablished);
            Assert.AreEqual(oCurrentListingDTO.Zip, Controller.ListingDTO.Zip);

            #endregion (Third Assertion Check to make sure the Database and Controller are sync'd)

            #endregion (Page 1 Navigation to Page 3)

            //---3to1
            #region Nulling Required Page 3 Values And Assigning New Non-Required Values

            Controller.ListingDTO.AdTitle = null;
            Controller.ListingDTO.AdTagLine = null;
            Controller.ListingDTO.AdDescription = null;

            #endregion (Nulling Required Page 3 Values And Assigning New Non-Required Values)

            #region Page 3 Navigation to Page 1
            try {
                Controller.NavigateToNewStep(1);
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "An Ad Title is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "An Ad Title is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.AdTitle = oEditedListingDTO.AdTitle;

            try {
                Controller.NavigateToNewStep(1);

            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Tag Line is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Tag Line is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.AdTagLine = oEditedListingDTO.AdTagLine;

            try {
                Controller.NavigateToNewStep(1);
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Business Opportunity Description is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            try {
                Controller.SaveAndExit();
            } catch (Exception ex) {
                Assert.AreEqual(ex.Message, "A Business Opportunity Description is required to proceed.");
                Debug.WriteLine(ex.Message);
            }

            Controller.ListingDTO.AdDescription = oEditedListingDTO.AdDescription;

            try {
                Controller.NavigateToNewStep(1);
                Assert.AreEqual(Controller.CurrentStep, 1);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            #region Fourth Assertion Check to make sure the Database and Controller are sync'd

            //Checking to make sure the Database matches the object we are now holding.
            oCurrentListingDTO = SQL.GetListingDTOByListingOid(Controller.ListingDTO.Oid);
            Assert.AreEqual(oCurrentListingDTO.AdDescription, Controller.ListingDTO.AdDescription);
            Assert.AreEqual(oCurrentListingDTO.Address, Controller.ListingDTO.Address);
            Assert.AreEqual(oCurrentListingDTO.Address2, Controller.ListingDTO.Address2);
            Assert.AreEqual(oCurrentListingDTO.AdPhoto, Controller.ListingDTO.AdPhoto);
            Assert.AreEqual(oCurrentListingDTO.AdTagLine, Controller.ListingDTO.AdTagLine);
            Assert.AreEqual(oCurrentListingDTO.AdTitle, Controller.ListingDTO.AdTitle);
            Assert.AreEqual(oCurrentListingDTO.BuildingCount, Controller.ListingDTO.BuildingCount);
            Assert.AreEqual(oCurrentListingDTO.CashFlow, Controller.ListingDTO.CashFlow);
            Assert.AreEqual(oCurrentListingDTO.City, Controller.ListingDTO.City);
            Assert.AreEqual(oCurrentListingDTO.CompanyName, Controller.ListingDTO.CompanyName);
            Assert.AreEqual(oCurrentListingDTO.ContactEmail, Controller.ListingDTO.ContactEmail);
            Assert.AreEqual(oCurrentListingDTO.ContactName, Controller.ListingDTO.ContactName);
            Assert.AreEqual(oCurrentListingDTO.ContactPhone, Controller.ListingDTO.ContactPhone);
            Assert.AreEqual(oCurrentListingDTO.County, Controller.ListingDTO.County);
            Assert.AreEqual(oCurrentListingDTO.EBITDA, Controller.ListingDTO.EBITDA);
            Assert.AreEqual(oCurrentListingDTO.EmployeeCount, Controller.ListingDTO.EmployeeCount);
            Assert.AreEqual(oCurrentListingDTO.EntityOid, Controller.ListingDTO.EntityOid);
            Assert.AreEqual(oCurrentListingDTO.EntityOid_BillingAuthority, Controller.ListingDTO.EntityOid_BillingAuthority);
            Assert.AreEqual(oCurrentListingDTO.ExpirationDate, Controller.ListingDTO.ExpirationDate);
            Assert.AreEqual(oCurrentListingDTO.AdFacilityDescription, Controller.ListingDTO.AdFacilityDescription);
            Assert.AreEqual(oCurrentListingDTO.FacilityOwned_Int, Controller.ListingDTO.FacilityOwned_Int);
            Assert.AreEqual(oCurrentListingDTO.FFandE, Controller.ListingDTO.FFandE);
            Assert.AreEqual(oCurrentListingDTO.GrossRevenue, Controller.ListingDTO.GrossRevenue);
            Assert.AreEqual(oCurrentListingDTO.Inventory, Controller.ListingDTO.Inventory);
            Assert.AreEqual(oCurrentListingDTO.IsAbsenteeOwner, Controller.ListingDTO.IsAbsenteeOwner);
            Assert.AreEqual(oCurrentListingDTO.IsActive, Controller.ListingDTO.IsActive);
            Assert.AreEqual(oCurrentListingDTO.IsExpanded, Controller.ListingDTO.IsExpanded);
            Assert.AreEqual(oCurrentListingDTO.IsFranchise, Controller.ListingDTO.IsFranchise);
            Assert.AreEqual(oCurrentListingDTO.IsHidden, Controller.ListingDTO.IsHidden);
            Assert.AreEqual(oCurrentListingDTO.IsHomeBased, Controller.ListingDTO.IsHomeBased);
            Assert.AreEqual(oCurrentListingDTO.IsPartialSave, Controller.ListingDTO.IsPartialSave);
            Assert.AreEqual(oCurrentListingDTO.IsPending, Controller.ListingDTO.IsPending);
            Assert.AreEqual(oCurrentListingDTO.IsRealEstateInPrice, Controller.ListingDTO.IsRealEstateInPrice);
            Assert.AreEqual(oCurrentListingDTO.IsRelocatable, Controller.ListingDTO.IsRelocatable);
            Assert.AreEqual(oCurrentListingDTO.IsSbaPreApproved, Controller.ListingDTO.IsSbaPreApproved);
            Assert.AreEqual(oCurrentListingDTO.IsSellerFinanace, Controller.ListingDTO.IsSellerFinanace);
            Assert.AreEqual(oCurrentListingDTO.Keywords, Controller.ListingDTO.Keywords);
            Assert.AreEqual(oCurrentListingDTO.ListingPrice, Controller.ListingDTO.ListingPrice);
            Assert.AreEqual(oCurrentListingDTO.lkpBusinessCategoryOids, Controller.ListingDTO.lkpBusinessCategoryOids);
            Assert.AreEqual(oCurrentListingDTO.lkpCityOid, Controller.ListingDTO.lkpCityOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountryOid, Controller.ListingDTO.lkpCountryOid);
            Assert.AreEqual(oCurrentListingDTO.lkpCountyOid, Controller.ListingDTO.lkpCountyOid);
            Assert.AreEqual(oCurrentListingDTO.lkpLegalEntityTypeOid, Controller.ListingDTO.lkpLegalEntityTypeOid);
            Assert.AreEqual(oCurrentListingDTO.lkpListingSetupStatusOid, Controller.ListingDTO.lkpListingSetupStatusOid);
            Assert.AreEqual(oCurrentListingDTO.lkpStateOid, Controller.ListingDTO.lkpStateOid);
            Assert.AreEqual(oCurrentListingDTO.MinimumDownPayment, Controller.ListingDTO.MinimumDownPayment);
            Assert.AreEqual(oCurrentListingDTO.OccupiedSqFt, Controller.ListingDTO.OccupiedSqFt);
            Assert.AreEqual(oCurrentListingDTO.RealEstateIncluded_Int, Controller.ListingDTO.RealEstateIncluded_Int);
            Assert.AreEqual(oCurrentListingDTO.RealEstateValue, Controller.ListingDTO.RealEstateValue);
            Assert.AreEqual(oCurrentListingDTO.SellerFinanceUpTo, Controller.ListingDTO.SellerFinanceUpTo);
            Assert.AreEqual(oCurrentListingDTO.AdReasonForSelling, Controller.ListingDTO.AdReasonForSelling);
            Assert.AreEqual(oCurrentListingDTO.ShowCashFlow_Int, Controller.ListingDTO.ShowCashFlow_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCity_Int, Controller.ListingDTO.ShowCity_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCompanyWebsite_Int, Controller.ListingDTO.ShowCompanyWebsite_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowCounty_Int, Controller.ListingDTO.ShowCounty_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowEBITDA_Int, Controller.ListingDTO.ShowEBITDA_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowFFE_Int, Controller.ListingDTO.ShowFFE_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowGrossRevenues_Int, Controller.ListingDTO.ShowGrossRevenues_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowInventory_Int, Controller.ListingDTO.ShowInventory_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowNumberOfEmployees_Int, Controller.ListingDTO.ShowNumberOfEmployees_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowYearEstablished_Int, Controller.ListingDTO.ShowYearEstablished_Int);
            Assert.AreEqual(oCurrentListingDTO.ShowZip_Int, Controller.ListingDTO.ShowZip_Int);
            Assert.AreEqual(oCurrentListingDTO.State, Controller.ListingDTO.State);
            Assert.AreEqual(oCurrentListingDTO.TotalSqFt, Controller.ListingDTO.TotalSqFt);
            Assert.AreEqual(oCurrentListingDTO.WebsiteURL, Controller.ListingDTO.WebsiteURL);
            Assert.AreEqual(oCurrentListingDTO.YearEstablished, Controller.ListingDTO.YearEstablished);
            Assert.AreEqual(oCurrentListingDTO.Zip, Controller.ListingDTO.Zip);

            #endregion (Fourth Assertion Check to make sure the Database and Controller are sync'd)

            #endregion (Page 3 Navigation to Page 1)
        }

        [Test]
        public void Test_06_IdentityCardCreationTester() {
            try {
                IdentityCardController oController = new IdentityCardController();
                oController.EntityOid = 8;
                Debug.WriteLine(oController.IdentityCardDTO.Oid);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        [Test]
        public void Test_07_GetOnboardingDTO() {
            try {
                List<CompanyDTO> oDTOs = SQL.GetOnBoardingDTOs(false);
                Debug.WriteLine(oDTOs.Count);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

    }

    



    public class EnumTester {
        public enum eShowComanyWebsite { ShowPublic = 1, ShowProtected = 2, ShowPrivate = 3 };
        [Column("ShowCompanyWebsite_Int")]
        public eShowComanyWebsite ShowCompanyWebsite_Int { get; set; }
    }

    public class ListingCreator {
        public static ListingDTO CreateFullTestListingObject() {
            ListingDTO oListing = new ListingDTO() {
                Oid = 36,
                AdDescription = "First Full Test For Wizard Ad Description",
                Address = "222 Wizard Test Way",
                Address2 = "Apartment 45",
                AdPhoto = "",
                AdTagLine = "This wizard test tagline makes you want to buy this business.",
                AdTitle = "This Title is the best WizardTest Title i could have.",
                BuildingCount = 22,
                CashFlow = (decimal)9500.00,
                City = "",
                CompanyName = "WizardTest",
                County = "",
                EBITDA = (decimal)16.50,
                EditInProgress = false,
                EmployeeCount = 13,
                EntityOid_BillingAuthority = 1,
                EntityOid = 6,
                AdFacilityDescription = "The Facilities in this test are incredibly spacious",
                FacilityOwned_Int = 2,
                FFandE = (decimal)62.35,
                GrossRevenue = (decimal)9000,
                Inventory = (decimal)75.25,
                IsAbsenteeOwner = true,
                IsFranchise = false,
                IsHomeBased = false,
                IsRealEstateInPrice = false,
                IsRelocatable = true,
                IsSbaPreApproved = false,
                IsSellerFinanace = true,
                ShowCashFlow_Int = 1,
                ShowInventory_Int = 2,
                ShowGrossRevenues_Int = 2,
                ShowFFE_Int = 3,
                ShowEBITDA_Int = 1,
                ShowCounty_Int = 3,
                ShowCompanyWebsite_Int = 2,
                ShowCity_Int = 2,
                ShowNumberOfEmployees_Int = 1,
                ShowYearEstablished_Int = 3,
                ShowZip_Int = 1,
                Keywords = "WizardTest Keyword",
                ListingPrice = (decimal)750000.00,
                lkpBusinessCategoryOids = "1",
                lkpCityOid = 1,
                lkpCountryOid = 1,
                lkpCountyOid = 1,
                lkpListingSetupStatusOid = 1,
                lkpStateOid = 1,
                MinimumDownPayment = (decimal)250000.00,
                OccupiedSqFt = 1,
                RealEstateIncluded_Int = 1,
                RealEstateValue = (decimal)75000.88,
                SellerFinanceUpTo = (decimal)72000.23,
                AdReasonForSelling = "This is the Wizard Test Selling Reason",
                TotalSqFt = 32,
                WebsiteURL = "www.testthiswizard.com",
                Zip = "95350",
                ContactEmail = "WizardTest@testing123.com",
                ContactName = "Tester Tersterson",
                ContactPhone = "222-222-2222",
                lkpLegalEntityTypeOid = 14,
                YearEstablished = "2019"
            };
            return oListing;
        }

        public static ListingDTO CreateEditedFullTestListingObject() {
            ListingDTO oListing = new ListingDTO() {
                AdDescription = "This is an updated version of the ad descirption set for the SetupWizard after i have come in with a completed listing.",
                Address = "222 Second Wizard Test Ave",
                Address2 = "Suite 54",
                AdPhoto = "",
                AdTagLine = "This wizard test tagline makes you want to buy this business. I have now updated it with this information to show that it is saving on an edited listing.",
                AdTitle = "This Title is the best WizardTest Title i could have. I have now updated it with this information to show that it is saving on an edited listing.",
                BuildingCount = 22,
                CashFlow = (decimal)9500.00,
                City = "",
                CompanyName = "UpdatedWizardTest",
                County = "",
                EBITDA = (decimal)16.50,
                EditInProgress = false,
                EmployeeCount = 13,
                EntityOid_BillingAuthority = 1,
                EntityOid = 6,
                AdFacilityDescription = "The Facilities in this test are incredibly spacious. I have now updated it with this information to show that it is saving on an edited listing.",
                FacilityOwned_Int = 2,
                FFandE = (decimal)62.35,
                GrossRevenue = (decimal)9000,
                Inventory = (decimal)75.25,
                IsAbsenteeOwner = true,
                IsFranchise = false,
                IsHomeBased = false,
                IsRealEstateInPrice = false,
                IsRelocatable = true,
                IsSbaPreApproved = false,
                IsSellerFinanace = true,
                ShowCashFlow_Int = 1,
                ShowInventory_Int = 2,
                ShowGrossRevenues_Int = 2,
                ShowFFE_Int = 3,
                ShowEBITDA_Int = 1,
                ShowCounty_Int = 3,
                ShowCompanyWebsite_Int = 2,
                ShowCity_Int = 2,
                ShowNumberOfEmployees_Int = 1,
                ShowYearEstablished_Int = 3,
                ShowZip_Int = 1,
                Keywords = "Updated WizardTest Keyword",
                ListingPrice = (decimal)750000.00,
                lkpBusinessCategoryOids = "1",
                lkpCityOid = 1,
                lkpCountryOid = 1,
                lkpCountyOid = 1,
                lkpListingSetupStatusOid = 1,
                lkpStateOid = 1,
                MinimumDownPayment = (decimal)250000.00,
                OccupiedSqFt = 1,
                RealEstateIncluded_Int = 1,
                RealEstateValue = (decimal)75000.88,
                SellerFinanceUpTo = (decimal)72000.23,
                AdReasonForSelling = "This is the Wizard Test Selling Reason. I have now updated it with this information to show that it is saving on an edited listing.",
                TotalSqFt = 32,
                WebsiteURL = "www.2ndtestthiswizard.org",
                Zip = "95356",
                ContactEmail = "2ndWizardTest@testing456.com",
                ContactName = "Tester Tersterson II",
                ContactPhone = "222-222-2222",
                lkpLegalEntityTypeOid = 14,
                YearEstablished = "2020"
            };
            return oListing;
        }


    }


}
