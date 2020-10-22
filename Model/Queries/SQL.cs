using Base;
using System;
using System.Collections.Generic;

namespace Model {

    public partial class SQL {

        #region BrokerCardDTO
        public static BrokerCardDTO GetBrokerCardByEntityOid(Int64 tiOid, bool tbThrowException = false) {
            BrokerCardDTO oReturn = null;
            Int64 iMyOid = SessionMgr.Instance.User.EntityOid;

            /**** @0 refers to the logged in Entity's Oid and is Declared in the SQL Constant string. Do not use or replace  ****/
            List<BrokerCardDTO_Receiver> oReceivers = Base.Database.GetInstance().Fetch<BrokerCardDTO_Receiver>(SqlConstants.GET_BROKER_CARD_DTO_INFO +
                " WHERE bc.EntityOid = @1", iMyOid, tiOid);
            if (tbThrowException && oReceivers.Count == 0) {
                throw new Exception($"No Broker Exists with Oid: [{tiOid}]");
            }
            List<BrokerCardDTO> oList = BrokerCardDTO_Receiver.Rollup(oReceivers);
            if (oList.Count > 0) {
                oReturn = oList[0];
            }
            return oReturn;
        }

        public static List<BrokerCardDTO> GetBrokerCardsDTOByServiceAreaOids(string tsServiceArea, List<Int64> tiServiceAreaOids) {
            List<BrokerCardDTO> oReturn = new List<BrokerCardDTO>();
            Int64 iMyOid = SessionMgr.Instance.User.EntityOid;
            if (string.IsNullOrEmpty(tsServiceArea)) {
                throw new Exception($"Service Area string parameter was null");
            }
            if (tiServiceAreaOids == null) {
                throw new Exception($"List of Service Area Oids was null");
            }

            /**** @0 refers to the logged in Entity's Oid and is Declared in the SQL Constant string. Do not use or replace  ****/
            List<BrokerCardDTO_Receiver> oReceivers = Base.Database.GetInstance().Fetch<BrokerCardDTO_Receiver>(SqlConstants.GET_BROKER_CARD_DTO_INFO +
                " WHERE lkpMap.LookupName = @1 AND lkpMap.LookupOid IN (@2)", iMyOid, tsServiceArea, tiServiceAreaOids);

            oReturn = BrokerCardDTO_Receiver.Rollup(oReceivers);
            return oReturn;
        }

        public static List<BrokerCardDTO> GetBrokerCardsDTOByBrokerName(string tsBrokerName) {
            List<BrokerCardDTO> oReturn = new List<BrokerCardDTO>();
            Int64 iMyOid = SessionMgr.Instance.User.EntityOid;

            if (string.IsNullOrEmpty(tsBrokerName)) {
                throw new Exception($"Broker Name was null");
            }

            /**** @0 refers to the logged in Entity's Oid and is Declared in the SQL Constant string. Do not use or replace  ****/
            List<BrokerCardDTO_Receiver> oReceivers = Base.Database.GetInstance().Fetch<BrokerCardDTO_Receiver>(SqlConstants.GET_BROKER_CARD_DTO_INFO +
                " WHERE e.FirstName LIKE '%" + tsBrokerName + "%' OR e.LastName LIKE '%" + tsBrokerName + "%' OR e.CompanyName LIKE '%" + tsBrokerName + "%'", iMyOid, tsBrokerName);

            oReturn = BrokerCardDTO_Receiver.Rollup(oReceivers);
            return oReturn;
        }

        public static List<BrokerCardDTO> GetBrokerCardsDTOByBrokerNameAndStateOid(string tsBrokerName, Int64 tiStateOid) {
            List<BrokerCardDTO> oReturn = new List<BrokerCardDTO>();
            Int64 iMyOid = SessionMgr.Instance.User.EntityOid;

            if (string.IsNullOrEmpty(tsBrokerName)) {
                throw new Exception($"Broker Name was null");
            }
            List<BrokerCardDTO_Receiver> oReceivers = Base.Database.GetInstance().Fetch<BrokerCardDTO_Receiver>(SqlConstants.GET_BROKER_CARD_DTO_INFO +
                " WHERE (e.FirstName LIKE '%" + tsBrokerName + "%' OR e.LastName LIKE '%" + tsBrokerName + "%' OR e.CompanyName LIKE '%" + tsBrokerName + "%') AND (lkpMap.LookupOid = @2) ", iMyOid, tsBrokerName, tiStateOid);

            oReturn = BrokerCardDTO_Receiver.Rollup(oReceivers);
            return oReturn;
        }

        public static List<BrokerCardDTO> GetBrokerCardsDTOByBrokerNameAndCountyOids(string tsBrokerName, List<Int64> tiCountyOids) {
            List<BrokerCardDTO> oReturn = new List<BrokerCardDTO>();
            Int64 iMyOid = SessionMgr.Instance.User.EntityOid;

            if (string.IsNullOrEmpty(tsBrokerName)) {
                throw new Exception($"Broker Name was null");
            }
            List<BrokerCardDTO_Receiver> oReceivers = Base.Database.GetInstance().Fetch<BrokerCardDTO_Receiver>(SqlConstants.GET_BROKER_CARD_DTO_INFO +
                " WHERE (e.FirstName LIKE '%" + tsBrokerName + "%' OR e.LastName LIKE '%" + tsBrokerName + "%' OR e.CompanyName LIKE '%" + tsBrokerName + "%') AND (lkpMap.LookupOid IN (@2)) ", iMyOid, tsBrokerName, tiCountyOids);

            oReturn = BrokerCardDTO_Receiver.Rollup(oReceivers);
            return oReturn;
        }
        #endregion (BrokerCardDTO)

        #region Contact
        public static Contact GetContactByEntityOid(Int64 tiEntityOid, bool tbThrowErrorOnNull = false) {
            Contact oReturn = null;
            oReturn = Base.Database.GetInstance().FirstOrDefault<Contact>(SqlConstants.GET_CONTACT_DATA + " WHERE Oid = @0", tiEntityOid);
            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"No Contact Exists with Oid: [{tiEntityOid}]");
            }
            return oReturn;
        }

        public static List<Contact> GetContactsByEntityOid_From(Int64 tiEntityOid_From) {
            List<Contact> oReturnList = new List<Contact>();
            oReturnList = Base.Database.GetInstance().Fetch<Contact>(SqlConstants.GET_CONTACT_DATA + " RIGHT JOIN Entity2EntityMap_Contact map ON e.Oid = map.EntityOid_From WHERE e.Oid = @0", tiEntityOid_From);
            return oReturnList;
        }
        
        public static Contact GetContactByContactDetails(Contact toContact, bool tbThrowErrorOnNull = false) {
            Contact oReturn = null;
            oReturn = Base.Database.GetInstance().FirstOrDefault<Contact>(SqlConstants.GET_CONTACT_DATA + " WHERE DisplayName = @0 AND (Phone = @1 OR Email = @2) ", toContact.DisplayName, toContact.Phone, toContact.Email);
            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"No Contact Exists with Contact Details Provided.");
            }
            return oReturn;
        }

        #endregion (Contact)

        #region EmailCampaign
        public static EmailCampaign GetEmailCampaignByOid(Int64 tiOid, bool tbThrowException = false) {
            EmailCampaign oReturn = EmailCampaign.FirstOrDefault(" WHERE Oid = @0", tiOid);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No Email Campaign Found Where Oid = [{tiOid}]");
            }
            return oReturn;
        }

        public static List<EmailCampaignDTO> GetEmailCampaignDTOsByEntityOidMaster(Int64 tiEntityOid) {
            List<EmailCampaignDTO> oReturn = Database.GetInstance().Fetch<EmailCampaignDTO>(SqlConstants.GET_EMAIL_CAMPAIGN_DTOS + " WHERE [EmailCampaign].EntityOid_Master = @0 AND [EmailCampaign].IsActive = 1", tiEntityOid);
            return oReturn;
        }

        public static EmailCampaignDTO GetEmailCampaignDTOByOid(Int64 tiOid) {
            EmailCampaignDTO oReturn = Database.GetInstance().First<EmailCampaignDTO>(SqlConstants.GET_EMAIL_CAMPAIGN_DTOS + " WHERE [EmailCampaign].Oid = @0", tiOid);
            return oReturn;
        }

        public static List<FSVisualItem> GetEmailTemplatesAsFSVisualItemsByEntityOidMaster(Int64 tiEntityOid) {
            return Database.GetInstance().Fetch<FSVisualItem>("SELECT Oid AS Value, [Name] AS Label FROM EmailTemplate WHERE EntityOid_Master = @0", tiEntityOid);
        }

        public static List<FSVisualItem> GetSearchCriteriaAsFSVisualItemsByEntity(Int64 tiEntityOid) {
            return Database.GetInstance().Fetch<FSVisualItem>("SELECT Oid AS Value, [Name] AS Label FROM SearchCriteria WHERE EntityOid = @0", tiEntityOid);
        }

        public static List<FSVisualItem> GetEmailRecipientDefinitionsAsFSVisualItems() {
            return Database.GetInstance().Fetch<FSVisualItem>("SELECT Oid AS Value, [Name] AS Label FROM EmailRecipientDefinition");
        }

        #endregion (EmailCampaign)

        #region EmailTemplate
        public static EmailTemplate GetEmailTemplateByOid(Int64 tiOid, bool tbThrowException = false) {
            EmailTemplate oReturn = EmailTemplate.FirstOrDefault("WHERE Oid = @0", tiOid);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No Email Template Found Where Oid = [{tiOid}]");
            }
            return oReturn;
        }

        public static List<EmailTemplate> GetEmailTemplatesByCreatedByOid(Int64 tiEntityOid) {
            List<EmailTemplate> oReturn = EmailTemplate.Fetch("WHERE CreatedBy = @0 AND IsActive = 1", tiEntityOid);
            return oReturn;
        }

        public static List<EmailTemplate> GetEmailTemplatesByEntityOidMaster(Int64 tiEntityMasterOid) {
            List<EmailTemplate> oReturn = EmailTemplate.Fetch("WHERE EntityOid_Master = @0 AND IsActive = 1", tiEntityMasterOid);
            return oReturn;
        }

        #endregion (EmailTemplate)

        #region Entity
        public static Entity GetEntityByOid(Int64 tiOid, bool tbThrowException = false) {
            Entity oReturn = Entity.FirstOrDefault("WHERE Oid = @0", tiOid);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No Entity Found Where Entity.Oid = [{tiOid}]");
            }
            return oReturn;
        }

        public static List<Entity> GetEntities() {
            return Entity.Fetch("");
        }

        #endregion (Entity)

        #region EntityAttribute
        public static EntityAttribute GetEntityAttributeByOid(Int64 tiOid, bool tbThrowException = false) {
            EntityAttribute oReturn = EntityAttribute.FirstOrDefault("WHERE Oid = @0", tiOid);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No Entity Attribute Found Where EntityAttribute.Oid = [{tiOid}]");
            }
            return oReturn;
        }
        #endregion (EntityAttribute)

        #region Entity2EntityMap_Contact
        public static Entity2EntityMap_Contact GetEntity2EntityMap_ContactByEntityOidAndContactOid(Int64 tiEntityOid_From, Int64 tiEntityOid_To, bool tbThrowErrorOnNull = false) {
            Entity2EntityMap_Contact oReturn = null;
            oReturn = Entity2EntityMap_Contact.FirstOrDefault("WHERE EntityOid_From = @0 AND EntityOid_To = @1", tiEntityOid_From, tiEntityOid_To);
            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"No Entity2EntityMap_Contact Exists with Oids: [{tiEntityOid_From} and {tiEntityOid_To}]");
            }
            return oReturn;
        }
        #endregion (Entity2EntityMap_Contact)

        #region Entity2ListingMap_Stat
        public static Entity2ListingMap_Stat GetEntity2ListingMap_StatByOid(Int64 tiOid, bool tbThrowException = false) {
            Entity2ListingMap_Stat oReturn = Entity2ListingMap_Stat.FirstOrDefault("WHERE Oid = @0", tiOid);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No Entity2ListingMap_Stat Found Where Entity2ListingMap_Stat.Oid = [{tiOid}]");
            }
            return oReturn;
        }

        public static List<Entity2ListingMap_Stat> GetEntity2ListingMap_StatsByEntityOid(Int64 tiEntityOid) {
            List<Entity2ListingMap_Stat> oReturn = new List<Entity2ListingMap_Stat>();
            oReturn = Entity2ListingMap_Stat.Fetch("WHERE EntityOid = @0", tiEntityOid);
            return oReturn;
        }

        public static List<Entity2ListingMap_Stat> GetEntity2ListingMap_StatsByEntityOidAndIsFavorited(Int64 tiEntityOid) {
            List<Entity2ListingMap_Stat> oReturn = new List<Entity2ListingMap_Stat>();
            oReturn = Entity2ListingMap_Stat.Fetch("WHERE EntityOid = @0 AND IsFavorite = @1", tiEntityOid, true);
            return oReturn;
        }

        public static Entity2ListingMap_Stat GetEntity2ListingMap_StatByEntityOidAndListingOid(Int64 tiEntityOid, Int64 tiListingOid, bool tbThrowException = false) {
            Entity2ListingMap_Stat oReturn = Entity2ListingMap_Stat.FirstOrDefault("WHERE EntityOid = @0 AND ListingOid = @1", tiEntityOid, tiListingOid);

            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No Entity2ListingMap_Stat Found Where EntityOid = [{tiEntityOid}] AND ListingOid = [{tiListingOid}]");
            }

            return oReturn;
        }

        #endregion (Entity2ListingMap_Stat)

        #region IdentityCardDTO
        public static IdentityCardDTO GetIdentityCardDTOByEntityOid(Int64 tiOid, bool tbThrowErrorOnNull = false) {
            IdentityCardDTO oReturn;
            List<IdentityCardDTO> oDTOs = new List<IdentityCardDTO>();
            List<ProfileCardDTO_Receiver> lResults = Base.Database.GetInstance().Fetch<ProfileCardDTO_Receiver>(SqlConstants.GET_PROFILE_CARD_DTO + " WHERE e.Oid = @0 ", tiOid);

            if((lResults.Count <= 0) && (tbThrowErrorOnNull)) {
                throw new Exception($"No Profile found for Entity Oid: [{tiOid}]");
            }

            oDTOs = ProfileCardDTO_Receiver.Rollup(lResults);
            oReturn = oDTOs[0];

            return oReturn;
        }

        #endregion (IdentityCardDTO)

        #region InterfaceHost
        public static InterfaceHost GetInterfaceHostByOid(Int64 tiOid, bool tbThrowException = false) {
            InterfaceHost oReturn = InterfaceHost.FirstOrDefault("WHERE Oid = @0", tiOid);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No InterfaceHost Found Where InterfaceHost.Oid = [{tiOid}]");
            }
            return oReturn;
        }
        public static InterfaceHost GetInterfaceHostByName(string tsName, bool tbThrowException = false) {
            InterfaceHost oReturn = InterfaceHost.FirstOrDefault("WHERE Name = @0", tsName);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No InterfaceHost Found Where InterfaceHost.Name = [{tsName}]");
            }
            return oReturn;
        }
        #endregion (InterfaceHost)

        #region InterfaceIdentityMap
        public static InterfaceIdentityMap GetInterfaceIdentityMapByOid(Int64 tiOid, bool tbThrowException = false) {
            InterfaceIdentityMap oReturn = InterfaceIdentityMap.FirstOrDefault("WHERE Oid = @0", tiOid);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No InterfaceIdentityMap Found Where InterfaceIdentityMap.Oid = [{tiOid}]");
            }
            return oReturn;
        }
        public static InterfaceIdentityMap GetInterfaceIdentityMapByInterfaceHostOidAndExternalIdAndTargetTable(Int64 tiInterfaceHostOid, string tsExternalId, string tsTargetTableName, bool tbThrowException = false) {
            InterfaceIdentityMap oReturn = InterfaceIdentityMap.FirstOrDefault("WHERE InterfaceHostOid = @0 AND ExternalId = @1 AND TargetTable = @2", tiInterfaceHostOid, tsExternalId, tsTargetTableName);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No InterfaceIdentityMap Found Where InterfaceHostOid = [{tiInterfaceHostOid}] AND ExternalId = [{tsExternalId}] AND TargetTable = [{tsTargetTableName}]");
            }
            return oReturn;
        }
        #endregion (InterfaceIdentityMap)

        #region Login
        //*********************** 
        public static Login GetLoginByOid(Int64 tiOid, bool tbThrowErrorOnNull = false) {
            Login oReturn = Login.FirstOrDefault("Where Oid = @0", tiOid);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Login record where Oid = [{tiOid}]");
            }
            return oReturn;
        }
        //*********************** 
        public static Login GetLoginByEntityOid(Int64 tiEntityOid, bool tbThrowErrorOnNull = false) {
            Login oReturn = Database.CreateQuery().From(Tables.Login).Where(Tables.Login.EntityOid, tiEntityOid).FirstOrDefault<Login>();

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Login record where EntityOid = [{tiEntityOid}]");
            }
            return oReturn;
        }
        //*********************** 
        public static Login GetLoginByLoginNameAndPassword(string tsLoginName, string tsPassword, bool tbThrowErrorOnNull = false) {
            Login oReturn = Login.FirstOrDefault("WHERE LoginName = @0 AND Password = @1", tsLoginName, tsPassword);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception("Unable to locate Login record with UserName / Password supplied.");
            }
            return oReturn;
        }
        //*********************** 
        public static Login GetLoginByThirdPartyAuthToken(string tsAuthToken, bool tbThrowErrorOnNull = false) {
            Login oReturn = Login.FirstOrDefault("Where ThirdPartyAuthToken = @0", tsAuthToken);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Login record where ThirdPartyAuthToken = [{tsAuthToken}]");
            }
            return oReturn;
        }
        //***********************
        public static Login GetLoginByLoginNameAndPassword(string tsLoginName, string tsPassword) {
            return Login.FirstOrDefault("WHERE LoginName = @0 AND Password = @1", tsLoginName, tsPassword);
        }
        //*********************** 
        public static bool IsLoginNameUnique(string tsLoginName) {
            if (String.IsNullOrEmpty(tsLoginName)) {
                throw new Exception("Login Name is Empty ");
            }
            Login oLogin = Login.FirstOrDefault("WHERE LoginName = @0 ", tsLoginName);
            return (oLogin == null);
        }

        //*********************** 
        public static Login GetLoginByLoginName(string tsLoginName, bool tbThrowErrorOnNull = false) {
            Login oReturn = null;
            if (String.IsNullOrEmpty(tsLoginName)) {
                throw new Exception("Login Name is Empty ");
            }
            oReturn = Login.FirstOrDefault("WHERE LoginName = @0 ", tsLoginName);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Login record where LoginName = [{tsLoginName}]");
            }
            return oReturn;
        }

        #endregion (Login)

        #region Lookup  
        //*********************** 
        public static Lookup GetLookupByOid(Int64 tiOid, bool tbThrowErrorOnNull = false) {
            Lookup oReturn = Lookup.FirstOrDefault("Where Oid = @0", tiOid);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Lookup record where Oid = [{tiOid}]");
            }
            return oReturn;
        }
        //*********************** 
        public static List<Lookup> GetLookupList_All() {
            return Lookup.Fetch("ORDER BY LookupName", null);
        }

        //*********************** 
        public static Lookup GetLookupByConstantValue(string tsConstantValue, bool tbThrowErrorOnNull = false) {
            Lookup oReturn = Lookup.FirstOrDefault("Where ConstantValue = @0", tsConstantValue);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Lookup record where ConstantValue = [{tsConstantValue}]");
            }
            return oReturn;
        }

        //*********************** 
        public static Lookup GetLookupByValue(string tsValue, bool tbThrowErrorOnNull = false) {
            Lookup oReturn = Lookup.FirstOrDefault("Where Value = @0", tsValue);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Lookup record where Value = [{tsValue}]");
            }
            return oReturn;
        }
        #endregion (Lookup)

        #region Listing
        public static Listing GetListingByOid(Int64 tiOid, bool tbThrowErrorOnNull = false) {
            // Listing oReturn = Listing.FirstOrDefault("WHERE Oid = @0", tiOid);
            Listing oReturn = Listing.FirstOrDefault("WHERE Oid = @0", tiOid, tbThrowErrorOnNull);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Listing record where Oid = [{tiOid}]");
            }
            return oReturn;
        }

        public static List<Listing> GetListingsByEntityOid(Int64 tiEntityOid) {
            //throw new Exception("Here is a new error.");
            List<Listing> oListings = new List<Listing>();
            oListings = Listing.Fetch("WHERE EntityOid = @0", tiEntityOid);
            return oListings;
        }

        public static List<Listing> GetSavedListingsByEntityOid(Int64 tiEntityOid) {
            List<Listing> oListings = new List<Listing>();
            oListings = Listing.Fetch("WHERE Oid IN (SELECT map.EntityOid FROM Entity2ListingMap_Stat_Saved map WHERE map.EntityOid = @0)", tiEntityOid);
            return oListings;
        }

        public static List<Listing> GetMyListingsAndMySavedListings(Int64 tiEntityOid) {
            List<Listing> oListings = new List<Listing>();
            oListings = Listing.Fetch("WHERE EntityOid = @0 OR IN (SELECT map.EntityOid FROM Entity2ListingMap_Stat_Saved map WHERE map.EntityOid = @0)", tiEntityOid);
            return oListings;
        }

        #endregion (Listing)

        #region ListingDTO
        public static ListingDTO GetListingDTOByListingOid(Int64 tiListingOid, bool tbThrowErrorOnNull = false) {
            ListingDTO oReturn = null;

            List<ListingDTO_Receiver> oReceivers = Base.Database.GetInstance().Fetch<ListingDTO_Receiver>(SqlConstants.GET_LISTING_DTO_DATA +
                " AND e2lmap.EntityOid = @0 WHERE l.Oid = @1", SessionMgr.Instance.User.EntityOid, tiListingOid);
            if (tbThrowErrorOnNull && oReceivers.Count == 0) {
                throw new Exception($"No Listing Exists with Oid: [{tiListingOid}]");
            }
            List<ListingDTO> oList = ListingDTO_Receiver.Rollup(oReceivers);
            if (oList.Count > 0) {
                oReturn = oList[0];
            }
            return oReturn;
        }

        public static List<ListingDTO> GetMyFavoritedListings(bool tbThrowErrorOnNull = false) {
            Int64 MyOid = SessionMgr.Instance.User.EntityOid;
            List<ListingDTO> oReturn;

            /**** @0 refers to the logged in Entity's Oid and is Declared in the SQL Constant string. Do not use or replace  ****/
            List<ListingDTO_Receiver> oReceivers = Base.Database.GetInstance().Fetch<ListingDTO_Receiver>(SqlConstants.GET_LISTING_DTO_BY_FAVORITE_MAP +
                " WHERE e2lmap.EntityOid = @0 AND e2lMap.IsFavorite = 1", MyOid);
            if (tbThrowErrorOnNull && oReceivers.Count == 0) {
                throw new Exception($"No Favorited Listings for user with EntityOid: [{MyOid}]");
            }

            oReturn = ListingDTO_Receiver.Rollup(oReceivers);

            return oReturn;
        }
        #endregion (ListingDTO)

        #region ListingDTO_Short
        public static List<ListingDTO_Short> ListingDTO_ShortByEntityOid(Int64 tiEntityOid) {
            return Database.GetInstance().Fetch<ListingDTO_Short>(SqlConstants.GET_LISTINGDTO_SHORT + "WHERE EntityOid = @0", tiEntityOid);
        }
        public static List<ListingDTO_Short> ListingDTO_ShortByEntityLoggedInUser() {
            return ListingDTO_ShortByEntityOid(SessionMgr.Instance.User.EntityOid);
        }
        #endregion (ListingDTO_Short)

        #region ListingAttribute
        public static ListingAttribute GetListingAttributeByOid(Int64 tiOid, bool tbThrowException = false) {
            ListingAttribute oReturn = ListingAttribute.FirstOrDefault("WHERE Oid = @0", tiOid);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No Listing Attribute Found Where ListingAttribute.Oid = [{tiOid}]");
            }
            return oReturn;
        }
        #endregion (ListingAttribute)

        #region ListingStat
        public static ListingStat GetListingStatByOid(Int64 tiOid, bool tbThrowErrorOnNull = false) {
            ListingStat oReturn = ListingStat.FirstOrDefault("WHERE ListingOid = @0", tiOid, tbThrowErrorOnNull);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate ListingStat record where Oid = [{tiOid}]");
            }
            return oReturn;
        }

        public static List<ListingStat> GetListingStatsByListingOid(Int64 tiEntityOid) {
            //throw new Exception("Here is a new error.");
            List<ListingStat> oListingStats = new List<ListingStat>();
            oListingStats = ListingStat.Fetch("WHERE ListingOid = @0", tiEntityOid);
            return oListingStats;
        }

        public static List<ListingStat> GetListingStatsByListingOidAndContext(Int64 tiEntityOid, string tsContext) {
            //throw new Exception("Here is a new error.");
            List<ListingStat> oListingStats = new List<ListingStat>();
            oListingStats = ListingStat.Fetch("WHERE ListingOid = @0 AND Context = @1", tiEntityOid, tsContext);
            return oListingStats;
        }
        #endregion (ListingStat)

        #region LookupDefinition  
        //*********************** 
        public static LookupDefinition GetLookupDefinitionByOid(Int64 tiOid, bool tbThrowErrorOnNull = false) {
            LookupDefinition oReturn = LookupDefinition.FirstOrDefault("Where Oid = @0", tiOid);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate LookupDefinition record where Oid = [{tiOid}]");
            }
            return oReturn;
        }
        //*********************** 
        public static List<LookupDefinition> GetLookupDefinitionList_All() {
            return LookupDefinition.Fetch("ORDER BY LookupName", null);
        }
        //*********************** 
        public static Lookup GetLookupByLookupName(string tsLookupName) {
            return Lookup.FirstOrDefault($"WHERE LookupName = [{tsLookupName}]", null);
        }
        #endregion (LookupDefinition)

        #region OnboardingDTO
        public static List<CompanyDTO> GetOnBoardingDTOs(bool tbThrowErrorOnNull = false) {
            Int64 MyOid = SessionMgr.Instance.User.EntityOid;
            List<CompanyDTO> oReturn = null;
            List<CompanyDTO_Receiver> oReceivers = Base.Database.GetInstance().Fetch<CompanyDTO_Receiver>(SqlConstants.GET_ONBOARDINGDTO_INFO + " WHERE company.EntityOid_Master = company.Oid");
            if(tbThrowErrorOnNull && oReceivers.Count == 0) {
                throw new Exception($"No OnBoarding Process Exists with this Oid: [{MyOid}]");
            }

            oReturn = CompanyDTO_Receiver.Rollup(oReceivers);

            return oReturn;
        }

        #endregion OnboardingDTO

        #region Organization
        public static OrganizationDTO GetOrganizationFromEntityOid_Master(Int64 tiEntityOid_Master) {
            Int64 ilkpEntityTypeOid_Region = LookupManager.Instance.GetOidByConstantValue("ENTITYTYPE->REGION");
            Int64 ilkpEntityTypeOid_Office = LookupManager.Instance.GetOidByConstantValue("ENTITYTYPE->OFFICE");
            Int64 ilkpEntityTypeOid_User = LookupManager.Instance.GetOidByConstantValue("ENTITYTYPE->USER");
            List<OrganizationDTO_Receiver> oRcvrList = Base.Database.GetInstance().Fetch<OrganizationDTO_Receiver>(SqlConstants.GET_ORGANIZATION_RECEIVER + "WHERE org.Oid = @3", ilkpEntityTypeOid_Region, ilkpEntityTypeOid_Office, ilkpEntityTypeOid_User, tiEntityOid_Master);
            return OrganizationDTO_Receiver.Rollup(oRcvrList); ;
        }
        #endregion (Organization)

        #region Search Criteria Display
        public static SearchCriteriaDisplay GetSearchCriteriaDisplayByOid(Int64 tiOid, bool tbThrowException = false) {
            return new SearchCriteriaDisplay(SQL.GetSearchCriteriaByOid(tiOid, false));
        }
        #endregion (Search Criteria Display)

        #region Search Criteria
        public static SearchCriteria GetSearchCriteriaByOid(Int64 tiOid, bool tbThrowException = false) {
            SearchCriteria oReturn = SearchCriteria.FirstOrDefault("WHERE Oid = @0", tiOid);
            if (tbThrowException && (oReturn == null)) {
                throw new Exception($"No SearchCriteria Found Where SearchCriteria.Oid = [{tiOid}]");
            }
            return oReturn;
        }

        public static Int64? GetDefaultSearchCriteriaOidForLoggedInUser(Int64 tiUserOid) {
            Int64? iReturn = null;
            Entity oEntity = SQL.GetEntityByOid(tiUserOid, false);
            if (oEntity != null) {
                iReturn = oEntity.DefaultSearchCriteriaOid;
            }

            return iReturn;
        }

        public static List<SearchCriteria> GetSearchCriteriaListByEntityOid(Int64 tiEntityOid) {
            List<SearchCriteria> oCriteria = new List<SearchCriteria>();
            oCriteria = SearchCriteria.Fetch("WHERE EntityOid = @0", tiEntityOid);
            return oCriteria;
        }

        public static List<SearchCriteria> GetActiveSearchCriteriaListByEntityOid(Int64 tiEntityOid) {
            List<SearchCriteria> oCriteria = new List<SearchCriteria>();
            oCriteria = SearchCriteria.Fetch("WHERE EntityOid = @0 AND (IsEmailRecipientListQuery IS NUll OR IsEmailRecipientListQuery = 0) AND IsActive = 1", tiEntityOid);
            return oCriteria;
        }



        #endregion (Search Criteria)

        #region SecurityGroup
        //*********************** 
        public static SecurityGroup GetSecurityGroupByOid(Int64 tiSecurityGroupOid, bool tbThrowErrorOnNull = false) {
            SecurityGroup oReturn = SecurityGroup.FirstOrDefault("Where Oid = @0", tiSecurityGroupOid);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Security Group record where Oid = [{tiSecurityGroupOid}]");
            }
            return oReturn;
        }

        #endregion (SecurityGroup)

        #region SecurityPwdRule

        //*********************** 
        public static SecurityPwdRule GetSecurityPasswordRuleByOid(Int64 tiSecurityPwdRuleOid, bool tbThrowErrorOnNull = false) {
            SecurityPwdRule oReturn = SecurityPwdRule.FirstOrDefault("Where Oid = @0", tiSecurityPwdRuleOid);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate SecurityPwdRule record where Oid = [{tiSecurityPwdRuleOid}]");
            }
            return oReturn;
        }
        #endregion(SecurityPwdRule)

        #region SequenceItem
        //*********************** 
        public static SequenceItem GetSequenceItemByOid(Int64 tiSequenceItemOid, bool tbThrowErrorOnNull = false) {
            SequenceItem oReturn = SequenceItem.FirstOrDefault("Where Oid = @0", tiSequenceItemOid);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Sequence Item record where Oid = [{tiSequenceItemOid}]");
            }
            return oReturn;
        }
        //*********************** 
        public static List<SequenceItem> GetSequenceItemByEntityOidAndListingOid(Int64 tiEntityOid, Int64 tiListingOid) {
            return SequenceItem.Fetch("Where EntityOid = @0 AND ListingOid = @1 ORDER BY Seq", tiEntityOid, tiListingOid);
        }
        //*********************** 
        public static List<SequenceItemDTO> GetSequenceItemDTOByEntityOidAndListingOid(Int64 tiEntityOid, Int64 tiListingOid) {
            List<SequenceItem> oItems = GetSequenceItemByEntityOidAndListingOid(tiEntityOid, tiListingOid);
            return SequenceItemDTO.Rollup(oItems);
        }

        #endregion (SequenceItem)

        #region Text Messaging

        #region Text Group
        //*********************** 
        public static TextGroup GetTextGroupByOid(Int64 tiSecurityPwdRuleOid, bool tbThrowErrorOnNull = false) {
            TextGroup oReturn = TextGroup.FirstOrDefault("Where Oid = @0", tiSecurityPwdRuleOid);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate TextGroup record where Oid = [{tiSecurityPwdRuleOid}]");
            }
            return oReturn;
        }

        public static List<TextGroupDTO> GetTextGroupDTOsByEntityOid_MasterAndEntityOid(Int64 tiEntityOid, Int64 tiEntityOid_Master) {
            List<TextGroupDTO> oTextGroups = Database.GetInstance().Fetch<TextGroupDTO>("SELECT * FROM TextGroup WHERE EntityOid_Master IS NULL OR EntityOid_Master = @0 OR EntityOid = @1 ORDER BY Sort,Name", tiEntityOid_Master, tiEntityOid);
            return TextGroupDTO.RollUp(oTextGroups);
        }

        #endregion (Text Group)

        #region TextChannel
        //*********************** 
        public static TextChannel GetTextChannelByOid(Int64 tiOid, bool tbThrowErrorOnNull = false) {
            TextChannel oReturn = TextChannel.FirstOrDefault("Where Oid = @0", tiOid);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate TextChannel record where Oid = [{tiOid}]");
            }
            return oReturn;
        }

        //*********************** 
        public static List<TextChannelDTO> GetTextChannelsByTextGroupOidAndEntityOid(Int64 tiTextGroupOid, Int64 tiEntityOid) {
            return Database.GetInstance().Fetch<TextChannelDTO>(SqlConstants.GET_TextChannel_DTO + "WHERE TextGroupOid = @0 AND TextRecipient.EntityOid = @1 ORDER BY TextChannel.LastCommunicationDate DESC", tiTextGroupOid, tiEntityOid);
        }

        #endregion (TextChannel)


        #region TextMessage
        //*********************** 
        public static TextMessage GetTextMessageByOid(Int64 tiOid, bool tbThrowErrorOnNull = false) {
            TextMessage oReturn = TextMessage.FirstOrDefault("Where Oid = @0", tiOid);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate TextMessage record where Oid = [{tiOid}]");
            }
            return oReturn;
        }

        //*********************** 
        public static List<TextMessageDTO> GetTextMessageDTOsByTextChannelOid_Last20(Int64 tiTextChannelOid) {
            // Special nested select (won't work in constant unless we bury the where clause
            // Queries the Top 20 by datesent DESC.  Then selects ot of the rsults set and flips the date order
            // so the last record is the most recent
            string sSql = @"SELECT  a.Oid,a.TextChannelOid,a.lkpMessageTypeOid,a.Message,a.DateSent,a.SentBy,a.SentByOid,a.IsEdited, a.MessageType , a.Avatar
			                FROM
			                (SELECT TOP(20) [TextMessage].[Oid],[TextMessage].[TextChannelOid],[TextMessage].[lkpMessageTypeOid],[TextMessage].[Message],[TextMessage].[DateSent],[TextMessage].[SentBy],[TextMessage].[SentByOid],[TextMessage].[IsEdited], lkp.Value AS MessageType ,
			                [Entity].[Avatar]
			                FROM [dbo].[TextMessage]
			                INNER JOIN Entity ON Entity.Oid = TextMessage.SentByOid
			                LEFT OUTER JOIN Lookup lkp ON lkp.Oid = TextMessage.lkpMessageTypeOid  
			                WHERE TextChannelOid = @0 ORDER BY TextMessage.DateSent DESC) a ORDER BY a.DateSent ";

            return Database.GetInstance().Fetch<TextMessageDTO>(sSql, tiTextChannelOid);
        }
        //*********************** 
        public static List<TextMessageDTO> GetTextMessageDTOsByTextChannelOid_All(Int64 tiTextChannelOid) {
            return Database.GetInstance().Fetch<TextMessageDTO>(SqlConstants.GET_TEXTMESSAGES_DTO + "WHERE TextChannelOid = @0 ORDER BY TextMessage.DateSent DESC", tiTextChannelOid);
        }

        #endregion (TextMessage)

        #endregion (Text Messaging)

        #region Whse_ListingStat
        public static Whse_ListingStat GetWhse_ListingStatByOid(Int64 tiOid, bool tbThrowErrorOnNull = false) {
            Whse_ListingStat oReturn = Whse_ListingStat.FirstOrDefault("WHERE Oid = @0", tiOid, tbThrowErrorOnNull);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Whse_ListingStat record where Oid = [{tiOid}]");
            }
            return oReturn;
        }

        public static Whse_ListingStat GetWhse_ListingStatByListingOid(Int64 tiListingOid, bool tbThrowErrorOnNull = false) {
            Whse_ListingStat oReturn = Whse_ListingStat.FirstOrDefault("WHERE ListingOid = @0", tiListingOid, tbThrowErrorOnNull);

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"Unable to locate Whse_ListingStat record where ListingOid = [{tiListingOid}]");
            }
            return oReturn;
        }
        public static List<Whse_ListingStat> GetWhse_ListingStatsByEntityOid(Int64 tiListingOid) {
            List<Whse_ListingStat> oReturn = Whse_ListingStat.Fetch("WHERE EntityOid = @0", tiListingOid);
            return oReturn;
        }
        #endregion (Whse_ListingStat)

        #region ZipCode
        public static ZipCode GetZipCodeByOid(Int64 tiOid, bool tbThrowException = false) {
            ZipCode oZipCode = ZipCode.FirstOrDefault("WHERE Oid = @0", tiOid);
            if (tbThrowException && (oZipCode == null)) {
                throw new Exception("No ZipCode Found Where ZipCode.Oid = [" + tiOid.ToString() + "]");
            }
            return oZipCode;
        }
        public static ZipCode GetZipCodeByZip(string tsZip, bool tbThrowException = false) {
            ZipCode oZipCode = ZipCode.FirstOrDefault("WHERE Zip = @0", tsZip);
            if (tbThrowException && (oZipCode == null)) {
                throw new Exception("No ZipCode Found Where ZipCode.Zip = [" + tsZip + "]");
            }
            return oZipCode;
        }
        #endregion (ZipCode)
    }
}

