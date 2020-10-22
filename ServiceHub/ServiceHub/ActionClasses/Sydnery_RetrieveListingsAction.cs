using CommonUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Model;
using Model.Interfaces.Sydney;
using CommonUtil;

namespace ServiceHub.ActionClasses {
    public class Sydnery_RetrieveListingsAction : IAction{

        public void Run(QueableMessage toMessage) {
            // This method will ping Sydney and retrieve the listings that have been updated since [LastUpdated]

            // QueableMessage
            // MessageType = int that drives the task
            // TargetTable = Meta data to identify the target table (matches with the targetOid below)
            // TargetOid = Oid for the target record in the Target Table
            // Data object to have as a carrier for passing anything through to the run method

            try {
                #region Validation Checking
                // Check for Data
                if (toMessage.Data == null) {
                    throw new ArgumentException("A message has been received to update listings from Sydney but the Data property of the Queueable Message is null.  It should contain the date of LastUpdate");
                }
                #endregion (Validation Checking)

                // Get the InterfaceHostOid
                InterfaceHost oInterfaceHost = SQL.GetInterfaceHostByName("Sydney", true);
                LastUpdated = (DateTime)toMessage.Data;

                // Get the Http Client
                IHttpClientFactory oHttpClientFactory = CommonUtil.ContainerAccess.Get<IHttpClientFactory>();
                HttpClient oClient = oHttpClientFactory.CreateClient("Sydney");

                // Convert LastUpdated (DateTime) to Epoch Time
                Int64 iEpochDate = LastUpdated.ToEpochTime();

                // Retrieve the Listings that have been modified since the last time we updated.
                string sJson = oClient.GetStringAsync("Listings2/?createDate=>{iEpochDate}").Result;
                List<SydneyListing> oListings = FSTools.FromJSON<List<SydneyListing>>(sJson);
                //Questions:
                // On the listing: What does the "id" relate to?
                // What other c_client_status__c values exist besides "Active"?
                // What is the difference between "assignedTo    & c_employee__c - both appear top be the agent on the listing
                // What is the diff between "c_listing_number__c" and "id" & what are they used for?
                // What is c_office_number__c? and what doies it relate to?
                // What is the difference between  c_client_status__c & c_listing_status__c -- c_client_status__c = "Active" : c_listing_status__c = "Inactive"
                // When I pull "Listings" I not see our office's listings
                // When I pull "Offices" with no parameter why do I not see our offices
                // When I pull "Employees" with no parameter why do I not see our people
                // c_own_or_lease_c__c sounds like a boolean but has a decimal for a value  ("0.00")
                // Diff between c_relocatable & c_relocatable__c  (c_relocatable = 0 & c_relocatable__c = 1)
                // c_Seller = "John Manousaridis_66682"  - looks like an Id to another record.
                // I see c_subcategory_1__c   - Where are the business categories & can I download the list?
                // On the listing the nameId looks like it may point to an additional record for the business being sold.. Does it?
                // How can c_country__c be empty on some listings?
                // What to do when Country/State/County/City/zip are all empty?  (Can I get a Zip anywhere ? I can deduce the rest.

                Listing oListing = null;

                foreach(SydneyListing oSydListing in oListings) {
                    if(!oSydListing.c_client_status__c.Equals("Active"))
                    //c_deal_stage__c = "Pending" -- Status
                    // assignedTo = Agent Id
                    // 

                    oListing.AdTitle = oSydListing.c_ad_headline__c;
                    oListing.AdDescription = oSydListing.c_business_description__c;

                    oListing.CompanyName = oSydListing.name;
                    oListing.Address = oSydListing.c_address;
                    oListing.Address2 = oSydListing.c_Address_2;

                    oListing.CompanyPhone = oSydListing.c_business_phone__c;
                    oListing.GeneralLocation = oSydListing.c_general_location__c;
                    oListing.HoursOfOperation = oSydListing.c_business_hours_of_operation__c;
                   
                    //*******************
                    // Zip to City matching Here
           //TODO         oSydListing.c_country__c must == "United States";
                    oListing.City = oSydListing.c_city__c;
                    oListing.County = oSydListing.c_county__c;
                    //*******************


                    oListing.lkpCommissionTypeOid = LookupManager.Instance.GetOidByConstantValue("COMMISSIONTYPE->FIXEDPERCENTAGE");

                    oListing.CommissionRate = GetDecimalOrNull(oSydListing.c_commission_rate__c);
                    oListing.RequestedDownPayment = GetDecimalOrNull(oSydListing.c_down_payment_requested__c); 
                    oListing.ListingPrice = GetDecimalOrNull(oSydListing.c_listing_price__c);
                    oListing.EBITDA = GetDecimalOrNull(oSydListing.c_ebitda__c);
                    oListing.Inventory = GetDecimalOrNull(oSydListing.c_inventory_value__c); 
                    
                    oListing.IsInventoryIncluded = (oSydListing.c_Inventory_Included_c.Equals("1"));
                    oListing.CommissionMinimum = GetDecimalOrNull(oSydListing.c_minimum_commission__c);
                    oListing.Rent = GetDecimalOrNull(oSydListing.c_monthly_rent__c);
                    oListing.EmployeeCount = GetIntOrNull(oSydListing.c_of_employees__c);
                    oListing.AdReasonForSelling = oSydListing.c_reason_for_sale__c;

                    // Real Estate
                    oListing.RealEstateAskingPrice = GetDecimalOrNull(oSydListing.c_RealEstateAskingPrice);
                    oListing.RealEstateValue = GetDecimalOrNull(oSydListing.c_RealEstateValue);
              // TODO      oListing.RealEstateIncluded_Int -- Could be 1,2 or 3  (c_real_estate_available__c, c_real_estate_included__c)
                    oListing.CashFlow = GetDecimalOrNull(oSydListing.c_seller_discretionary_earnings__c);
                    oListing.AccountsReceivable = GetDecimalOrNull(oSydListing.c_accounts_receivable);

                    // Flags
                    oListing.IsSellerFinanace = GetBooleanOrNull(oSydListing.c_Seller_Financing_Available_c);
                    oListing.TotalSqFt = GetIntOrNull(oSydListing.c_square_footage__c);
                    oListing.IsAccountsReceivableIncluded = GetBooleanOrNull(oSydListing.c_accounts_receivable_incl);

                    if (!string.IsNullOrEmpty(oSydListing.c_listing_url__c)) {
                        AddWebLink("Transworld", oSydListing.c_listing_url__c);
                    }

                    if (!AgentExists(oSydListing.assignedTo, oInterfaceHost.Oid)) {
                        CreateAgentRecord(oSydListing.assignedTo, oClient, oInterfaceHost.Oid);
                    }

                    // Complete the Listing record
                    // Save the listing

                }


            } catch (Exception ex) {
                throw;
            }
        }

        private void AddWebLink(string tsLinkName, string tsUrl) {

        }
        #region User Record
        private bool AgentExists(string tsAgentId, Int64 tiInterfaceHostOid) {
            InterfaceIdentityMap oMap = SQL.GetInterfaceIdentityMapByInterfaceHostOidAndExternalIdAndTargetTable(tiInterfaceHostOid, tsAgentId, "Entity", false);
            return (oMap != null);
        }

        private void CreateAgentRecord(string tsAgentId, HttpClient toClient, Int64 tiInterfaceHostOid) {
            string sUserJson = toClient.GetStringAsync($"User/?nameid={tsAgentId}").Result;
            SydneyUser oUser = FSTools.FromJSON<SydneyUser>(sUserJson);

            string sEEJson = toClient.GetStringAsync($"Employees/?c_user__c={tsAgentId}").Result;
            List<SydneyEmployee> oEmployees = FSTools.FromJSON<List<SydneyEmployee>>(sEEJson);
            SydneyEmployee oEmployee = oEmployees[0];

            string sOfficeJson = toClient.GetStringAsync($"Offices/?nameId={ oEmployee.c_office_location__c}").Result;
            List<SydneyOffice> oOfficeList = FSTools.FromJSON<List<SydneyOffice>>(sOfficeJson);
            SydneyOffice oOffice = oOfficeList[0];

            InterfaceIdentityMap oOfficeInterfaceIdentityMapRecord = GetInterfaceIdentityMapForOffice(oOffice, tiInterfaceHostOid);
            if (oOfficeInterfaceIdentityMapRecord == null) {
                oOfficeInterfaceIdentityMapRecord = CreateOfficeRecord();
            }

            // Create Agent Record : Entity record for Agent - The oAgent.EntityOid_Master = oOfficeInterfaceIdentityMapRecord.TargetOid;
            // Create InterfaceIdentityMap record for Agent
        }
        #endregion (User Record)


        #region Office Record
        private InterfaceIdentityMap GetInterfaceIdentityMapForOffice(SydneyOffice toSydneyOffice, Int64 tiInterfaceHostOid) {
            InterfaceIdentityMap oReturn = null;
            oReturn = InterfaceIdentityMap.FirstOrDefault("WHERE InterfaceHostOid = @0 AND ExternalId = @1 AND TargetTable = @2", tiInterfaceHostOid, toSydneyOffice.nameId, "Entity"); ;
            return oReturn;
        }
        private InterfaceIdentityMap CreateOfficeRecord() {
            InterfaceIdentityMap oReturn = null;
            // Create Entity Record for Office
            // Create InterfaceIdentityMap record for Office and return
            // Create a Login Record for Agent
            return oReturn;
        }
        #endregion (Office Record)

        #region Conversions

        #region ToInt
        private int? GetIntOrNull(string toValue) {
            int? dReturn = null;

            if (!string.IsNullOrEmpty(toValue)) {
                dReturn = Convert.ToInt32(toValue);
            }
            return dReturn;
        }

        private int? GetIntOrNull(object toValue) {
            int? dReturn = null;

            if (toValue != null) {
                dReturn = Convert.ToInt32(toValue);
            }
            return dReturn;
        }
        #endregion (ToInt)

        #region ToDecimal
        private decimal? GetDecimalOrNull(string toValue) {
            decimal? dReturn = null;

            if (!string.IsNullOrEmpty(toValue)) {
                dReturn = Convert.ToDecimal(toValue);
            }
            return dReturn;
        }

        private decimal? GetDecimalOrNull(object toValue) {
            decimal? dReturn = null;

            if(toValue != null) {
                dReturn = Convert.ToDecimal(toValue);
            }
            return dReturn;
        }
        #endregion (ToDecimal)

        #region ToBoolean
        private bool? GetBooleanOrNull(string toValue) {
            bool? dReturn = null;

            if (!string.IsNullOrEmpty(toValue)) {
                dReturn = Convert.ToBoolean(toValue);
            }
            return dReturn;
        }

        private bool? GetBooleanOrNull(object toValue) {
            bool? dReturn = null;

            if (toValue != null) {
                dReturn = Convert.ToBoolean(toValue);
            }
            return dReturn;
        }
        #endregion (Boolean)

        #endregion (Conversions)


        #region Properties
        public DateTime LastUpdated { get; set; }
        #endregion (Properties)

    }
}
