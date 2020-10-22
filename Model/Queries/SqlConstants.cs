using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public partial class SqlConstants {
	    

		#region Application

        #endregion (Application)

        #region Association
        public const string GET_ASSOCIATIONS_BY_ASSOCIATION_MAP = @"SELECT a.* 
            FROM Entity2AssociationMap map
            INNER JOIN Association a ON map.AssociationOid = a.Oid ";

		#endregion (Association)

		#region BrokerCard
		public const string GET_BROKER_CARD_DTO_INFO = @"
			SELECT DISTINCT e.Oid AS e_Oid, e.Avatar AS e_Avatar, e.DisplayName AS e_DisplayName, e.AreasServed AS e_AreasServed, e.LicensedIn AS e_LicensedIn,
			e.State AS e_State, e.City AS e_City, e.Email AS e_Email,
			bc.*, 
			eCompany.CompanyName AS eCompany_CompanyName, 
			cr.ContactDate AS cr_ContactDate, cr.EntityOid_ContactFrom AS cr_EntityOid_ContactFrom, cr.EntityOid_ContactTo AS cr_EntityOid_ContactTo, cr.Oid AS cr_Oid
			FROM BrokerCard bc
			INNER JOIN Entity e ON e.Oid = bc.EntityOid 
			LEFT OUTER JOIN Entity2LookupMap lkpMap ON lkpMap.EntityOid = e.oid
			LEFT OUTER JOIN Entity eCompany ON eCompany.Oid = e.EntityOid_Master
			LEFT OUTER JOIN ContactRequest cr ON cr.EntityOid_ContactTo = bc.EntityOid AND cr.EntityOid_ContactFrom = @0 ";
		#endregion(BrokerCard)

		#region Contact
		public const string GET_CONTACT_DATA = @"SELECT Oid, Avatar, FirstName, LastName, DisplayName, Email, Phone, CreatedBy, CreatedOn
			FROM Entity ";
		#endregion (Contact)

		#region Region Name
		public const string GET_EMAIL_CAMPAIGN_DTOS = @"SELECT [EmailCampaign].[Oid],[EmailCampaign].[EmailTemplateOid],[EmailCampaign].[EmailRecipientDefinitionOid],[EmailCampaign].[EntityOid_Master],[EmailCampaign].[Name],
			[EmailCampaign].[Description],[EmailCampaign].[DateLastRun],[EmailCampaign].[CreatedOn],[EmailCampaign].[CreatedBy],[EmailCampaign].[Delivered],[EmailCampaign].[UniqueOpens], [EmailCampaign].[IsActive],
			[EmailCampaign].[UniqueClicks],[EmailCampaign].[SpamReports],[EmailCampaign].[Bounces],[EmailCampaign].[Unsubscribed],[EmailCampaign].[RecipientCount],[EmailCampaign].[EstimatedCost],
			et.Name AS TemplateName,
			eDef.Name AS RecipientDefinitionName, eDef.SearchCriteriaOid AS SearchCriteriaOid
			FROM [EmailCampaign]
			LEFT OUTER JOIN EmailTemplate et ON et.Oid = [EmailCampaign].[EmailTemplateOid] 
			LEFT OUTER JOIN EmailRecipientDefinition eDef ON eDef.Oid = [EmailCampaign].[EmailRecipientDefinitionOid] ";

		#endregion (Region Name)

		#region Entity
		public const string GET_ENTITY_AND_ALL_CONTACTS = @"SELECT e.Oid, e.EntityOid_Master, e.EntityOid_Authority, e.NumberOfEmployees, e.StartDate, e.DisplayName AS CompanyName, e.PhoneNumber, e.Address1, e.Address2, e.City, e.State, e.Zip, e.BannerImage, e.Avatar, e.BioText, e.lkpEntityTypeOid, e.lkpLegalEntityOid, e.LicensedIn, e.AreasServed,
            c.Oid AS cont_Oid, c.FirstName AS cont_FirstName, c.EntityOid_Master AS cont_EntityOid_Master, c.EntityOid_Authority AS cont_EntityOid_Authority, c.lkpCountryOid AS cont_lkpCountryOid, c.LastName AS cont_LastName, c.Title AS cont_Title, c.Email AS cont_Email, c.DisplayName AS cont_CompanyName, c.City AS cont_City, c.State AS cont_State, c.PhoneNumber AS cont_PhoneNumber, c.Avatar AS cont_Avatar 
	        FROM Entity e
	        LEFT OUTER JOIN Entity c ON c.EntityOid_Master = e.Oid ";

		public const string GET_ENTITYID_FROM_ENTITYMAP = @"SELECT e.Oid, e.FirstName, e.LastName, e.PrimaryPhoneNumber, e.lkpEntityTypeOid, e.Email, Map.PercentageAllocated
	        FROM Entity e
	        INNER JOIN Entity2EntityMap Map ON Map.EntityOid_From = e.Oid ";

		public const string GET_PROFILE_CARD_DTO = @"SELECT e.Oid, e.FirstName, e.FirstName, e.LastName, e.DisplayName, e.Email, e.Phone, e.AboutMe, e.Address1, e.Address2, e.AreasServed, e.Country, e.City, e.State, e.Avatar, e.CompanyName, e.Title, e.Zip, e.IsElite, e.LicensedIn, 
			ea.lkpAttributeTypeOid AS ea_lkpAttributeTypeOid, ea.Text AS ea_Text, ea.Text2 AS ea_Text2, ea.Oid AS ea_Oid, bc.TagLine AS bc_TagLine
	        FROM Entity e
			LEFT JOIN EntityAttribute ea ON ea.EntityOid = e.Oid
			LEFT JOIN BrokerCard bc ON bc.EntityOid = e.Oid ";

		#endregion(Entity)

		#region EntityAttribute
		public const string GET_ENTITY_ATTRIBUTES = @"SELECT ea.*, ea.Text AS URL, lkpType.Value AS AttributeType, lkpAttrib.Value AS AttributeName
            FROM EntityAttribute ea
	        INNER JOIN Lookup lkpType ON ea.lkpAttributeTypeOid = lkpType.Oid 
	        INNER JOIN Lookup lkpAttrib ON ea.lkpAttributeValueOid = lkpAttrib.Oid ";

        #endregion (EntityAttribute)

		#region Entity2Association
		public const string GET_ENTITY2ASSOCIATIONMAP = @"SELECT map.*
            FROM Entity2AssociationMap map
            INNER JOIN Association assoc ON assoc.Oid = map.AssociationOid
            INNER JOIN Entity e ON map.EntityOid = e.Oid ";

        #endregion (Entity2Association)

        #region Entity2Entity
        public const string GET_ENTITY2ENTITYMAP_USING_MAP_FROM = @"SELECT map.*
            FROM Entity2EntityMap map
            INNER JOIN Entity e ON map.EntityOid_From = e.Oid ";

        public const string GET_ENTITY2ENTITYMAP_USING_MAP_TO = @"SELECT map.*
            FROM Entity2EntityMap map
            INNER JOIN Entity e ON map.EntityOid_To = e.Oid ";

        public const string GET_ENTITY_2_ENTITY_RELATIONSHIPS = @"SELECT eParent.*,
	        eChild.Oid AS chi_Oid, eChild.FirstName AS chi_FirstName, eChild.LastName AS chi_LastName, 
	        eChild.lkpEntityTypeOid AS chi_lkpEntityTypeOid, eChild.Address1 AS chi_Address1, 
	        eChild.Address2 AS chi_Address2, eChild.City AS chi_City, eChild.Zip AS chi_Zip,
	        eChild.CompanyName AS chi_CompanyName, eChild.Email AS chi_Email, eChild.PrimaryPhoneNumber AS chi_PrimaryPhoneNumber,
			eChild.NumberOfCows AS chi_NumberOfCows, eChild.NumberOfEmployees AS chi_NumberOfEmployees, eChild.State AS chi_State,
			eChild.Preferences AS chi_Preferences, eChild.CreatedBy AS chi_CreatedBy, eChild.CreatedOn AS chi_CreatedOn,
			eChild.EntityOid_Authority AS chi_EntityOid_Authority, eChild.EntityOid_Master AS chi_EntityOid_Master,
			eChild.Is1099Relationship AS chi_Is1099Relationship, eChild.lkpTimeZoneOid AS chi_lkpTimeZoneOid,
			eChild.Preferences AS chi_Preferences, eChild.StartDate AS chi_StartDate, eChild.TerminationDate AS chi_TerminationDate,
			eChild.Preferences AS chi_Preferences, eChild.ContactName AS chi_ContactName, eChild.lkpStateOid AS chi_lkpStateOid,

	        eGrandChild.Oid AS grnd_Oid, eGrandChild.FirstName AS grnd_FirstName, eGrandChild.LastName AS grnd_LastName, 
	        eGrandChild.lkpEntityTypeOid AS grnd_lkpEntityTypeOid, eGrandChild.Address1 AS grnd_Address1, 
	        eGrandChild.Address2 AS grnd_Address2, eGrandChild.City AS grnd_City, eGrandChild.Zip AS grnd_Zip,
	        eGrandChild.CompanyName AS grnd_CompanyName, eGrandChild.Email AS grnd_Email, eGrandChild.PrimaryPhoneNumber AS grnd_PrimaryPhoneNumber,eGrandChild.NumberOfCows AS grnd_NumberOfCows, eGrandChild.NumberOfEmployees AS grnd_NumberOfEmployees, eGrandChild.State AS grnd_State,
			eGrandChild.Preferences AS grnd_Preferences, eGrandChild.CreatedBy AS grnd_CreatedBy, eGrandChild.CreatedOn AS grnd_CreatedOn,
			eGrandChild.EntityOid_Authority AS grnd_EntityOid_Authority, eGrandChild.EntityOid_Master AS grnd_EntityOid_Master,
			eGrandChild.Is1099Relationship AS grnd_Is1099Relationship,eGrandChild.lkpTimeZoneOid AS grnd_lkpTimeZoneOid,
			eGrandChild.Preferences AS grnd_Preferences, eGrandChild.StartDate AS grnd_StartDate, eGrandChild.TerminationDate AS grnd_TerminationDate,
			eGrandChild.Preferences AS grnd_Preferences, eGrandChild.ContactName AS grnd_ContactName, eGrandchild.lkpStateOid AS grnd_lkpStateOid

	        FROM Entity eParent
	        LEFT OUTER JOIN Entity2EntityMap MillMap ON MillMap.EntityOid_From = eParent.Oid
	        LEFT OUTER JOIN Entity eChild ON MillMap.EntityOid_To = eChild.Oid AND eChild.lkpEntityTypeOid = @1
	        LEFT OUTER JOIN Entity2EntityMap DairyMap ON DairyMap.EntityOid_From = eChild.Oid
	        LEFT OUTER JOIN Entity eGrandChild ON DairyMap.EntityOid_To = eGrandChild.Oid AND eGrandChild.lkpEntityTypeOid = @2 ";

        public const string GET_MILLS_DAIRIES_AND_NUTRITIONISTS = @"SELECT eMill.*,
	        eDairy.Oid AS chi_Oid, eDairy.FirstName AS chi_FirstName, eDairy.LastName AS chi_LastName, 
	        eDairy.lkpEntityTypeOid AS chi_lkpEntityTypeOid, eDairy.Address1 AS chi_Address1, 
	        eDairy.Address2 AS chi_Address2, eDairy.City AS chi_City, eDairy.Zip AS chi_Zip,
	        eDairy.CompanyName AS chi_CompanyName, eDairy.Email AS chi_Email, eDairy.PrimaryPhoneNumber AS chi_PrimaryPhoneNumber,
			eDairy.NumberOfCows AS chi_NumberOfCows, eDairy.NumberOfEmployees AS chi_NumberOfEmployees, eDairy.State AS chi_State,
			eDairy.Preferences AS chi_Preferences, eDairy.CreatedBy AS chi_CreatedBy, eDairy.CreatedOn AS chi_CreatedOn,
			eDairy.EntityOid_Authority AS chi_EntityOid_Authority, eDairy.EntityOid_Master AS chi_EntityOid_Master,
			eDairy.Is1099Relationship AS chi_Is1099Relationship, eDairy.lkpTimeZoneOid AS chi_lkpTimeZoneOid,
			eDairy.Preferences AS chi_Preferences, eDairy.StartDate AS chi_StartDate, eDairy.TerminationDate AS chi_TerminationDate,
			eDairy.Preferences AS chi_Preferences, eDairy.ContactName AS chi_ContactName, eDairy.lkpStateOid AS chi_lkpStateOid,

	        eNutritionist.Oid AS grnd_Oid, eNutritionist.FirstName AS grnd_FirstName, eNutritionist.LastName AS grnd_LastName, 
	        eNutritionist.lkpEntityTypeOid AS grnd_lkpEntityTypeOid, eNutritionist.Address1 AS grnd_Address1, 
	        eNutritionist.Address2 AS grnd_Address2, eNutritionist.City AS grnd_City, eNutritionist.Zip AS grnd_Zip,
	        eNutritionist.CompanyName AS grnd_CompanyName, eNutritionist.Email AS grnd_Email, eNutritionist.PrimaryPhoneNumber AS grnd_PrimaryPhoneNumber,eNutritionist.NumberOfCows AS grnd_NumberOfCows, eNutritionist.NumberOfEmployees AS grnd_NumberOfEmployees, eNutritionist.State AS grnd_State,
			eNutritionist.Preferences AS grnd_Preferences, eNutritionist.CreatedBy AS grnd_CreatedBy, eNutritionist.CreatedOn AS grnd_CreatedOn,
			eNutritionist.EntityOid_Authority AS grnd_EntityOid_Authority, eNutritionist.EntityOid_Master AS grnd_EntityOid_Master,
			eNutritionist.Is1099Relationship AS grnd_Is1099Relationship,eNutritionist.lkpTimeZoneOid AS grnd_lkpTimeZoneOid,
			eNutritionist.Preferences AS grnd_Preferences, eNutritionist.StartDate AS grnd_StartDate, eNutritionist.TerminationDate AS grnd_TerminationDate,
			eNutritionist.Preferences AS grnd_Preferences, eNutritionist.ContactName AS grnd_ContactName, eNutritionist.lkpStateOid AS grnd_lkpStateOid

	        FROM Entity eMill
	        LEFT OUTER JOIN Entity2EntityMap MillMap ON MillMap.EntityOid_From = eMill.Oid
	        LEFT OUTER JOIN Entity eDairy ON MillMap.EntityOid_To = eDairy.Oid AND eDairy.lkpEntityTypeOid = 8
	        LEFT OUTER JOIN Entity2EntityMap DairyMap ON DairyMap.EntityOid_To = eDairy.Oid
	        LEFT OUTER JOIN Entity eNutritionist ON DairyMap.EntityOid_From = eNutritionist.Oid AND eNutritionist.lkpEntityTypeOid = 7 ";


		#endregion (Entity2Entity)

		#region Listing
		public const string LISTING_DTO_DATA_SET_DEFINTION = " l.*,la.Oid AS la_Oid, la.Value AS la_Value, e2lmap.IsFavorite AS e2lmap_IsFavorite, e2lMap.Oid AS e2lmap_Oid ";

		public const string GET_LISTING_DTO_DATA = "SELECT " + LISTING_DTO_DATA_SET_DEFINTION +
			@" FROM Listing l
			LEFT OUTER JOIN ListingAttribute la ON l.Oid = la.ListingOid 
			LEFT OUTER JOIN Entity2ListingMap_Stat e2lmap ON l.Oid = e2lmap.ListingOid ";

		public const string GET_LISTING_DTO_BY_FAVORITE_MAP = "SELECT " + LISTING_DTO_DATA_SET_DEFINTION +
			@" FROM Entity2ListingMap_Stat e2lMap
			INNER JOIN Listing l ON l.Oid = e2lmap.ListingOid
			LEFT OUTER JOIN ListingAttribute la ON l.Oid = la.ListingOid ";

		#endregion (Listing)

		#region ListingDTO_Short
		public const string GET_LISTINGDTO_SHORT = @"SELECT Oid, EntityOid, ExternalId, ExternalSystem, ContactName, ContactEmail, ContactPhone, CompanyName,
		   CompanyPhone, SellerName, Address, Address2, City, State, Zip, AdTitle, Adtagline, AdDescription,
		   AdPhoto, WebsiteUrl, YearEstablished, ListingPrice, ListingDate, BuyerCount, IsActive, IsPending
		   FROM Listing  ";

		#endregion (ListingDTO_Short)

		#region ListingViewStatsCardDTO
		public const string GET_LISTING_VIEW_STATS_CARD_DTO = @"SELECT wls.*, l.ListingDate AS l_DateListed, l.IsActive AS l_IsActive, l.IsPending AS l_IsPending, l.lkpListingSetupStatusOid AS l_lkpListingSetupStatusOid
			FROM Whse_ListingStat wls
			LEFT OUTER JOIN Listing l ON l.Oid = wls.ListingOid ";
        #endregion (ListingViewStatsCardDTO)

        #region Notification
        public const string GET_NOTIFICATION_INFO = @"SELECT n.*, 
            e.Oid AS Entity_Oid
            FROM Notification n
            LEFT OUTER JOIN Entity e ON n.EntityOid = e.Oid ";
		#endregion (Notification)

		#region OnboardingDTO
		public const string GET_ONBOARDINGDTO_INFO = @"SELECT company.Oid, company.EntityOid_Master, company.EntityOid_Office, company.AreasServed, company.lkpStateOids_Servicing, company.lkpUserTypeOid, company.NumberOfEmployees, company.CompanyName, company.Country, company.CreatedBy, company.CreatedOn, company.HasMultipleOffices, company.HasMultipleRegions,
			region.Oid AS Region_Oid, region.DisplayName AS Region_DisplayName,
			office.Oid AS Office_Oid, office.DisplayName AS Office_DisplayName, office.Address1 AS Office_Address1, office.Address2 AS Office_Address2, office.Zip AS Office_Zip, office.NumberOfEmployees AS Office_NumberOfEmployees, office.Phone AS Office_Phone,
			agent.Oid AS Agent_Oid, agent.FirstName AS Agent_FirstName, agent.LastName AS Agent_LastName, agent.Email AS Agent_Email, agent.lkpUserTypeOid AS Agent_lkpUserTypeOid
			FROM Entity company
			INNER JOIN Entity region ON region.EntityOid_Master = company.Oid
			INNER JOIN Entity office ON office.EntityOid_Region = region.Oid
			INNER JOIN Entity agent ON agent.EntityOid_Office = office.Oid";
		#endregion (OnboardingDTO)

		#region OrganizationDTO
		public const string GET_ORGANIZATION_RECEIVER = @"SELECT [org].[Oid], [org].[EntityOid_Master], [org].[EntityOid_Region], [org].[EntityOid_Office], [org].[lkpEntityTypeOid], [org].[lkpTimeZoneOid], [org].[lkpCountryOid], [org].[lkpStateOid], [org].[lkpStateOids_Servicing], 
		    [org].[CompanyName] AS Name, [org]. [DisplayName], [org].[Address1], [org].[Address2], [org].[City], [org].[State], [org].[Zip], [org].[Country], 
		    [org].[Phone], [org].[Email], [org].[FaxNumber], [org].[BannerImage], [org].[Avatar], 
		    [org].[StartDate], [org].[IsActive], [org].[ListingCount], [org].[Preferences], 
		    [org].[HasMultipleRegions], [org].[HasMultipleOffices], [org].[AboutMe],

		    [reg].[Oid] AS reg_Oid,[reg].[EntityOid_Master] AS reg_EntityOid_Master,[reg].[lkpTimeZoneOid] AS reg_lkpTimeZoneOid,[reg].[lkpCountryOid] AS reg_lkpCountryOid,[reg].[lkpStateOid] AS reg_lkpStateOid,[reg].[lkpStateOids_Servicing] AS reg_lkpStateOids_Servicing, [reg].[CompanyName] AS reg_Name, [reg].[DisplayName] AS reg_DisplayName,[reg].[HasMultipleOffices] AS reg_HasMultipleOffices,
		    [reg].[IsActive] AS reg_IsActive,[reg].[ListingCount] AS reg_ListingCount, 

			[ofc].[Oid] AS ofc_Oid,[ofc].[lkpTimeZoneOid] AS ofc_lkpTimeZoneOid,[ofc].[lkpCountryOid] AS ofc_lkpCountryOid,[ofc].[lkpStateOid] AS ofc_lkpStateOid,[ofc].[lkpStateOids_Servicing] AS ofc_lkpStateOids_Servicing,
		    [ofc].[CompanyName] AS ofc_Name, [ofc].[DisplayName] AS ofc_DisplayName,[ofc].[Address1] AS ofc_Address1,[ofc].[Address2] AS ofc_Address2,[ofc].[City] AS ofc_City,[ofc].[State] AS ofc_State,[ofc].[Zip] AS ofc_Zip,[ofc].[Country] AS ofc_Country,
		    [ofc].[Phone] AS ofc_Phone,[ofc].[Email] AS ofc_Email,[ofc].[FaxNumber] AS ofc_FaxNumber,[ofc].[BannerImage] AS ofc_BannerImage,[ofc].[Avatar] AS ofc_Avatar,
		    [ofc].[IsActive] AS ofc_IsActive,[ofc].[ListingCount] AS ofc_ListingCount,[ofc].[Preferences] AS ofc_Preferences,

			[usr].[Oid] AS usr_Oid,[usr].[lkpUserTypeOid] AS usr_lkpUserTypeOid,
			[usr].[lkpTimeZoneOid] AS usr_lkpTimeZoneOid,[usr].[lkpCountryOid] AS usr_lkpCountryOid,[usr].[lkpStateOid] AS usr_lkpStateOid,[usr].[lkpStateOids_Servicing] AS usr_lkpStateOids_Servicing,
			[usr].[FirstName] AS usr_FirstName, [usr].[LastName] AS usr_LastName, [usr].[DisplayName] AS usr_DisplayName,[usr].[Address1] AS usr_Address1,[usr].[Address2] AS usr_Address2,[usr].[City] AS usr_City,[usr].[State] AS usr_State,[usr].[Zip] AS usr_Zip,[usr].[Country] AS usr_Country,
			[usr].[Phone] AS usr_Phone,[usr].[Email] AS usr_Email,[usr].[FaxNumber] AS usr_FaxNumber,[usr].[BannerImage],[usr].[Avatar] AS usr_Avatar, [usr].[StartDate] AS usr_StartDate,[usr].[IsActive] AS usr_IsActive,[usr].[ListingCount] AS usr_ListingCount,[usr].[Preferences] AS usr_Preferences,
			[usr].[Title] AS usr_Title,[usr].[AboutMe] AS usr_AboutMe,[usr].[DOB] AS usr_DOB,[usr].[IsElite] AS usr_IsElite

			FROM Entity org
			LEFT OUTER JOIN Entity reg ON reg.EntityOid_Master = org.Oid AND reg.lkpEntityTypeOid = @0
			LEFT OUTER JOIN Entity ofc ON ofc.EntityOid_Region = reg.Oid AND ofc.lkpEntityTypeOid = @1
			LEFT OUTER JOIN Entity usr ON usr.EntityOid_Office = ofc.Oid AND usr.lkpEntityTypeOid = @2 ";

		#endregion (OrganizationDTO)

		#region Profiles
		public const string GET_PROFILE_CARD = @"SELECT e.Oid, e.EntityOid_Master, e.Email, e.DisplayName, e.Avatar, e.Country, e.CompanyName, e.FirstName , e.LastName, e.Phone, e.NumberOfEmployees, 
			e.StartDate, e.Address1, e.Address2, e.City, e.State, e.Zip, e.BannerImage, e.AboutMe, e.Title, 
			ea.Oid AS ea_Oid, ea.Text AS ea_Text, ea.Text2 AS ea_Text2

			FROM Entity e  
			LEFT JOIN EntityAttribute ea ON ea.EntityOid = e.Oid ";
		
		#endregion (Profiles)

		#region Region 
		public const string GET_REGION_INFO = @"SELECT Assoc.*
	        FROM Association Assoc ";

        public const string GET_REGION_DTO_INFO = @"SELECT Assoc.*, lkpRole.Value AS Role, 
	        e.Oid AS e_Oid, e.EntityOid_Master, e.FirstName, e.LastName, e.CompanyName, e.lkpEntityTypeOid, e.City, e.State, lkpEType.Value AS EntityType,
			map.ProductionShare AS e_PercentageAllocated
	        FROM Association Assoc 
	        LEFT OUTER JOIN Entity2AssociationMap map ON map.AssociationOid = Assoc.Oid
	        LEFT OUTER JOIN Entity e ON map.EntityOid = e.Oid
	        LEFT OUTER JOIN Lookup lkpRole ON map.lkpAssociationRoleOid = lkpRole.Oid
	        LEFT OUTER JOIN Lookup lkpEType ON e.lkpEntityTypeOid = lkpEType.Oid ";
		#endregion (Region)

		#region SavedSearchDetailsDTO
		public const string GET_SAVED_SEARCH_DETAILS_DTO = @"";

		#endregion (SavedSearchDetailsDTO)

		#region TextGroup
		#endregion (TextGroup)

		#region TextChannel
		public const string GET_TextChannel_DTO = @"SELECT [TextChannel].[Oid],[TextChannel].[TextGroupOid],[TextChannel].[Name],[TextChannel].[LastCommunicationDate],[TextChannel].[LastCommunicationDate] AS Date, [TextChannel].[Avatar]
			FROM [TextChannel]
  			INNER JOIN TextRecipient  ON TextRecipient.TextChannelOid = TextChannel.Oid AND TextRecipient.OptOut != 1";
		#endregion (TextChannel)

		#region TextMessage
		public const string GET_TEXTMESSAGES_DTO = @"SELECT [TextMessage].[Oid],[TextMessage].[TextChannelOid],[TextMessage].[lkpMessageTypeOid],[TextMessage].[Message],[TextMessage].[DateSent],[TextMessage].[SentBy],[TextMessage].[SentByOid],[TextMessage].[IsEdited], lkp.Value AS MessageType ,
			[Entity].[Avatar] 
			FROM [dbo].[TextMessage]
			INNER JOIN Entity ON Entity.Oid = TextMessage.SentByOid
			LEFT OUTER JOIN Lookup lkp ON lkp.Oid = TextMessage.lkpMessageTypeOid  ";

		#endregion (TextMessage)

		#region TODO
		public const string GET_TODO_DTO_INFO = @"SELECT td.*, 
	        eAuthor.Oid AS Auth_Oid, eAuthor.FirstName AS Auth_FirstName, eAuthor.LastName AS Auth_LastName,
            eAuthor.lkpGenderOid AS Auth_lkpGenderOid, eAuthor.EntityOid_Master AS Auth_EntityOid_Master, eAuthor.EntityOid_Authority AS Auth_EntityOid_Authority, eAuthor.lkpEntityTypeOid AS Auth_lkpEntityTypeOid, eAuthor.Email AS Auth_Email, eAuthor.CompanyName AS Auth_CompanyName, eAuthor.Address1 AS Auth_Address1, 
            eAuthor.Address2 AS Auth_Address2, eAuthor.City AS Auth_City, eAuthor.State AS Auth_State, eAuthor.Zip AS Auth_Zip, eAuthor.Avatar AS Auth_Avatar, eAuthor.StartDate AS Auth_StartDate, eAuthor.LinkedInURL AS Auth_LinkedInURL, eAuthor.WebsiteURL AS Auth_WebsiteURL, eAuthor.FacebookURL AS Auth_FacebookURL,
	        eTarg.Oid AS Targ_Oid, eTarg.FirstName AS Targ_FirstName, eTarg.LastName AS Targ_LastName,
            eTarg.lkpGenderOid AS Targ_lkpGenderOid, eTarg.EntityOid_Master AS Targ_EntityOid_Master, eTarg.EntityOid_Authority AS Targ_EntityOid_Authority, eTarg.lkpEntityTypeOid AS Targ_lkpEntityTypeOid, eTarg.Email AS Targ_Email, eTarg.CompanyName AS Targ_CompanyName, eTarg.Address1 AS Targ_Address1, 
            eTarg.Address2 AS Targ_Address2, eTarg.City AS Targ_City, eTarg.State AS Targ_State, eTarg.Zip AS Targ_Zip, eTarg.Avatar AS Targ_Avatar, eTarg.StartDate AS Targ_StartDate, eTarg.LinkedInURL AS Targ_LinkedInURL, eTarg.WebsiteURL AS Targ_WebsiteURL, eTarg.FacebookURL AS Targ_FacebookURL,

	        lkpAction.value AS Act_Value,
	        lkpStatus.value AS Sta_Value,
	        lkpRel.value AS Rel_Value
	
	        FROM TODO td
            INNER JOIN Entity eAuthor ON eAuthor.Oid = td.EntityOid_Author
	        INNER JOIN Entity eTarg ON eTarg.Oid = td.EntityOid_Target
	        INNER JOIN Lookup lkpAction ON lkpAction.Oid = td.lkpToDoActionOid
	        INNER JOIN Lookup lkpStatus ON lkpStatus.Oid = td.lkpTodoStatusOid
	        INNER JOIN Lookup lkpRel ON lkpRel.Oid = td.lkpRelationshipTypeOid ";
        #endregion (TODO) 

        #region UserDTO

        public const string GET_USER_DTO_INFO = @"SELECT e.*,
            e.CreatedOn, e.IsActive,
			dai.Oid AS dai_Oid, dai.CompanyName AS dai_CompanyName, dai.NumberOfCows AS dai_NumberOfCows, 
			dai.CompanyName, map.PercentageAllocated AS dai_PercentageAllocatedToNutritionist, dai.City AS dai_City, 
			dai.State AS dai_State, dai.IsPending AS dai_IsPending, dai.lkpStateOid AS dai_lkpStateOid,
			assoc.Oid AS assoc_Oid, assoc.Name AS RegionName, eamap.ProductionShare AS RegionBonusPercentage,
			cp.Oid AS cp_Oid, cp.Name AS cp_Name, cp.IsReadOnly AS cp_IsReadOnly

            FROM Entity e 

			LEFT OUTER JOIN Entity2EntityMap map ON map.EntityOid_From = e.Oid
			LEFT OUTER JOIN Entity dai ON map.EntityOid_To = dai.Oid 
			LEFT OUTER JOIN Entity2AssociationMap eamap ON eamap.EntityOid = e.Oid AND lkpAssociationRoleOid = 39 
			LEFT OUTER JOIN Association assoc ON assoc.Oid = eamap.AssociationOid AND assoc.lkpAssociationTypeOid = 9 
			LEFT OUTER JOIN Entity2CompPlanMap cpMap ON cpMap.EntityOid = e.oid
			LEFT OUTER JOIN CompPlan cp ON cp.Oid = cpMap.CompPlanOid ";

		#endregion (UserDTO)

		#region ValuePair

		#endregion(ValuePair)
	}
}
