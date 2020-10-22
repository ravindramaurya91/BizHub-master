// AUTO GENERATED - DO NOT MODIFY DIRECTLY

using Base;
using System;
using SqlKata;

namespace Model
{

    public partial class AttachmentMetadata : Metadata<Attachment>
    {
        public override string DbTableName => "Attachment";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo lkpDocumentTypeOid => DefineColumn("lkpDocumentTypeOid");
        public ColumnInfo TargetTable => DefineColumn("TargetTable");
        public ColumnInfo TargetOid => DefineColumn("TargetOid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo DocumentUrl => DefineColumn("DocumentUrl");
        public AttachmentMetadata As(string alias) => new AttachmentMetadata() { DbTableAlias = alias };
    }

    public partial class BrokerCardMetadata : Metadata<BrokerCard>
    {
        public override string DbTableName => "BrokerCard";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo Body => DefineColumn("Body");
        public ColumnInfo Footer => DefineColumn("Footer");
        public ColumnInfo TagLine => DefineColumn("TagLine");
        public ColumnInfo IsElite => DefineColumn("IsElite");
        public BrokerCardMetadata As(string alias) => new BrokerCardMetadata() { DbTableAlias = alias };
    }

    public partial class ConfigurationMetadata : Metadata<Configuration>
    {
        public override string DbTableName => "Configuration";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo Value => DefineColumn("Value");
        public ColumnInfo DataType => DefineColumn("DataType");
        public ColumnInfo ModuleName => DefineColumn("ModuleName");
        public ColumnInfo Description => DefineColumn("Description");
        public ConfigurationMetadata As(string alias) => new ConfigurationMetadata() { DbTableAlias = alias };
    }

    public partial class ContactRequestMetadata : Metadata<ContactRequest>
    {
        public override string DbTableName => "ContactRequest";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid_ContactTo => DefineColumn("EntityOid_ContactTo");
        public ColumnInfo EntityOid_ContactFrom => DefineColumn("EntityOid_ContactFrom");
        public ColumnInfo EntityEmail_To => DefineColumn("EntityEmail_To");
        public ColumnInfo EntityEmail_From => DefineColumn("EntityEmail_From");
        public ColumnInfo ListingOid => DefineColumn("ListingOid");
        public ColumnInfo ContactDate => DefineColumn("ContactDate");
        public ColumnInfo FirstName => DefineColumn("FirstName");
        public ColumnInfo LastName => DefineColumn("LastName");
        public ColumnInfo Phone => DefineColumn("Phone");
        public ColumnInfo Zip => DefineColumn("Zip");
        public ColumnInfo Message => DefineColumn("Message");
        public ColumnInfo Is401KReferral => DefineColumn("Is401KReferral");
        public ContactRequestMetadata As(string alias) => new ContactRequestMetadata() { DbTableAlias = alias };
    }

    public partial class EmailCampaignMetadata : Metadata<EmailCampaign>
    {
        public override string DbTableName => "EmailCampaign";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EmailTemplateOid => DefineColumn("EmailTemplateOid");
        public ColumnInfo EmailRecipientDefinitionOid => DefineColumn("EmailRecipientDefinitionOid");
        public ColumnInfo EntityOid_Master => DefineColumn("EntityOid_Master");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo Description => DefineColumn("Description");
        public ColumnInfo DateLastRun => DefineColumn("DateLastRun");
        public ColumnInfo CreatedOn => DefineColumn("CreatedOn");
        public ColumnInfo CreatedBy => DefineColumn("CreatedBy");
        public ColumnInfo Delivered => DefineColumn("Delivered");
        public ColumnInfo UniqueOpens => DefineColumn("UniqueOpens");
        public ColumnInfo UniqueClicks => DefineColumn("UniqueClicks");
        public ColumnInfo SpamReports => DefineColumn("SpamReports");
        public ColumnInfo Bounces => DefineColumn("Bounces");
        public ColumnInfo Unsubscribed => DefineColumn("Unsubscribed");
        public ColumnInfo RecipientCount => DefineColumn("RecipientCount");
        public ColumnInfo EstimatedCost => DefineColumn("EstimatedCost");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public EmailCampaignMetadata As(string alias) => new EmailCampaignMetadata() { DbTableAlias = alias };
    }

    public partial class EmailCampaignRunMetadata : Metadata<EmailCampaignRun>
    {
        public override string DbTableName => "EmailCampaignRun";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EmailCampaignOid => DefineColumn("EmailCampaignOid");
        public ColumnInfo EntityOid_ApprovedBy => DefineColumn("EntityOid_ApprovedBy");
        public ColumnInfo RecipientCount => DefineColumn("RecipientCount");
        public ColumnInfo NumberSent => DefineColumn("NumberSent");
        public ColumnInfo EstimatedCost => DefineColumn("EstimatedCost");
        public ColumnInfo TargetRunDate => DefineColumn("TargetRunDate");
        public ColumnInfo RunDate => DefineColumn("RunDate");
        public ColumnInfo ApprovalDate => DefineColumn("ApprovalDate");
        public ColumnInfo Delivered => DefineColumn("Delivered");
        public ColumnInfo UniqueOpens => DefineColumn("UniqueOpens");
        public ColumnInfo UniqueClicks => DefineColumn("UniqueClicks");
        public ColumnInfo SpamReports => DefineColumn("SpamReports");
        public ColumnInfo Bounces => DefineColumn("Bounces");
        public ColumnInfo Unsubscribed => DefineColumn("Unsubscribed");
        public EmailCampaignRunMetadata As(string alias) => new EmailCampaignRunMetadata() { DbTableAlias = alias };
    }

    public partial class EmailRecipientDefinitionMetadata : Metadata<EmailRecipientDefinition>
    {
        public override string DbTableName => "EmailRecipientDefinition";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo SearchCriteriaOid => DefineColumn("SearchCriteriaOid");
        public ColumnInfo lkpRecipientListTypeOid => DefineColumn("lkpRecipientListTypeOid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public EmailRecipientDefinitionMetadata As(string alias) => new EmailRecipientDefinitionMetadata() { DbTableAlias = alias };
    }

    public partial class EmailTemplateMetadata : Metadata<EmailTemplate>
    {
        public override string DbTableName => "EmailTemplate";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid_Master => DefineColumn("EntityOid_Master");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo Description => DefineColumn("Description");
        public ColumnInfo LkpTemplateCategoryOid => DefineColumn("LkpTemplateCategoryOid");
        public ColumnInfo HyperText => DefineColumn("HyperText");
        public ColumnInfo DateLastUpdated => DefineColumn("DateLastUpdated");
        public ColumnInfo CreatedOn => DefineColumn("CreatedOn");
        public ColumnInfo CreatedBy => DefineColumn("CreatedBy");
        public ColumnInfo Delivered => DefineColumn("Delivered");
        public ColumnInfo UniqueOpens => DefineColumn("UniqueOpens");
        public ColumnInfo UniqueClicks => DefineColumn("UniqueClicks");
        public ColumnInfo SpamReports => DefineColumn("SpamReports");
        public ColumnInfo Bounces => DefineColumn("Bounces");
        public ColumnInfo Unsubscribed => DefineColumn("Unsubscribed");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public EmailTemplateMetadata As(string alias) => new EmailTemplateMetadata() { DbTableAlias = alias };
    }

    public partial class EntityMetadata : Metadata<Entity>
    {
        public override string DbTableName => "Entity";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid_Master => DefineColumn("EntityOid_Master");
        public ColumnInfo EntityOid_Region => DefineColumn("EntityOid_Region");
        public ColumnInfo EntityOid_Office => DefineColumn("EntityOid_Office");
        public ColumnInfo EntityOid_ReferredBy => DefineColumn("EntityOid_ReferredBy");
        public ColumnInfo lkpEntityTypeOid => DefineColumn("lkpEntityTypeOid");
        public ColumnInfo lkpUserTypeOid => DefineColumn("lkpUserTypeOid");
        public ColumnInfo lkpLegalEntityOid => DefineColumn("lkpLegalEntityOid");
        public ColumnInfo lkpTimeZoneOid => DefineColumn("lkpTimeZoneOid");
        public ColumnInfo lkpCountryOid => DefineColumn("lkpCountryOid");
        public ColumnInfo lkpStateOid => DefineColumn("lkpStateOid");
        public ColumnInfo lkpGenderOid => DefineColumn("lkpGenderOid");
        public ColumnInfo lkpProspectTypeOid => DefineColumn("lkpProspectTypeOid");
        public ColumnInfo lkpBusinessCategoryOids => DefineColumn("lkpBusinessCategoryOids");
        public ColumnInfo lkpStateOids_Servicing => DefineColumn("lkpStateOids_Servicing");
        public ColumnInfo DefaultSearchCriteriaOid => DefineColumn("DefaultSearchCriteriaOid");
        public ColumnInfo CompanyName => DefineColumn("CompanyName");
        public ColumnInfo FirstName => DefineColumn("FirstName");
        public ColumnInfo LastName => DefineColumn("LastName");
        public ColumnInfo DisplayName => DefineColumn("DisplayName");
        public ColumnInfo Title => DefineColumn("Title");
        public ColumnInfo Phone => DefineColumn("Phone");
        public ColumnInfo Email => DefineColumn("Email");
        public ColumnInfo FaxNumber => DefineColumn("FaxNumber");
        public ColumnInfo StartDate => DefineColumn("StartDate");
        public ColumnInfo DOB => DefineColumn("DOB");
        public ColumnInfo Avatar => DefineColumn("Avatar");
        public ColumnInfo BannerImage => DefineColumn("BannerImage");
        public ColumnInfo AboutMe => DefineColumn("AboutMe");
        public ColumnInfo ListingCount => DefineColumn("ListingCount");
        public ColumnInfo NumberOfEmployees => DefineColumn("NumberOfEmployees");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public ColumnInfo IsElite => DefineColumn("IsElite");
        public ColumnInfo EmailOptOut => DefineColumn("EmailOptOut");
        public ColumnInfo HasMultipleRegions => DefineColumn("HasMultipleRegions");
        public ColumnInfo HasMultipleOffices => DefineColumn("HasMultipleOffices");
        public ColumnInfo Address1 => DefineColumn("Address1");
        public ColumnInfo Address2 => DefineColumn("Address2");
        public ColumnInfo AreasServed => DefineColumn("AreasServed");
        public ColumnInfo City => DefineColumn("City");
        public ColumnInfo LicensedIn => DefineColumn("LicensedIn");
        public ColumnInfo State => DefineColumn("State");
        public ColumnInfo Zip => DefineColumn("Zip");
        public ColumnInfo Country => DefineColumn("Country");
        public ColumnInfo Preferences => DefineColumn("Preferences");
        public ColumnInfo CreatedOn => DefineColumn("CreatedOn");
        public ColumnInfo CreatedBy => DefineColumn("CreatedBy");
        public EntityMetadata As(string alias) => new EntityMetadata() { DbTableAlias = alias };
    }

    public partial class Entity2EntityMap_ContactMetadata : Metadata<Entity2EntityMap_Contact>
    {
        public override string DbTableName => "Entity2EntityMap_Contact";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid_From => DefineColumn("EntityOid_From");
        public ColumnInfo EntityOid_To => DefineColumn("EntityOid_To");
        public Entity2EntityMap_ContactMetadata As(string alias) => new Entity2EntityMap_ContactMetadata() { DbTableAlias = alias };
    }

    public partial class Entity2ListingMap_ParticipantMetadata : Metadata<Entity2ListingMap_Participant>
    {
        public override string DbTableName => "Entity2ListingMap_Participant";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo ListingOid => DefineColumn("ListingOid");
        public ColumnInfo lkpListingRoleOid => DefineColumn("lkpListingRoleOid");
        public Entity2ListingMap_ParticipantMetadata As(string alias) => new Entity2ListingMap_ParticipantMetadata() { DbTableAlias = alias };
    }

    public partial class Entity2ListingMap_StatMetadata : Metadata<Entity2ListingMap_Stat>
    {
        public override string DbTableName => "Entity2ListingMap_Stat";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo ListingOid => DefineColumn("ListingOid");
        public ColumnInfo DateFavorited => DefineColumn("DateFavorited");
        public ColumnInfo IsNotifyOnPriceChange_Text => DefineColumn("IsNotifyOnPriceChange_Text");
        public ColumnInfo IsNotifyOnPriceChange_Email => DefineColumn("IsNotifyOnPriceChange_Email");
        public ColumnInfo IsSeen => DefineColumn("IsSeen");
        public ColumnInfo IsVisited => DefineColumn("IsVisited");
        public ColumnInfo IsFavorite => DefineColumn("IsFavorite");
        public ColumnInfo IsContacted => DefineColumn("IsContacted");
        public Entity2ListingMap_StatMetadata As(string alias) => new Entity2ListingMap_StatMetadata() { DbTableAlias = alias };
    }

    public partial class Entity2LookupMapMetadata : Metadata<Entity2LookupMap>
    {
        public override string DbTableName => "Entity2LookupMap";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo LookupOid => DefineColumn("LookupOid");
        public ColumnInfo LookupName => DefineColumn("LookupName");
        public Entity2LookupMapMetadata As(string alias) => new Entity2LookupMapMetadata() { DbTableAlias = alias };
    }

    public partial class EntityAttributeMetadata : Metadata<EntityAttribute>
    {
        public override string DbTableName => "EntityAttribute";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ParentOid => DefineColumn("ParentOid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo lkpAttributeTypeOid => DefineColumn("lkpAttributeTypeOid");
        public ColumnInfo Text => DefineColumn("Text");
        public ColumnInfo Text2 => DefineColumn("Text2");
        public ColumnInfo HasChildren => DefineColumn("HasChildren");
        public EntityAttributeMetadata As(string alias) => new EntityAttributeMetadata() { DbTableAlias = alias };
    }

    public partial class IngredientMetadata : Metadata<Ingredient>
    {
        public override string DbTableName => "Ingredient";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo RecipeOid => DefineColumn("RecipeOid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo Amount => DefineColumn("Amount");
        public IngredientMetadata As(string alias) => new IngredientMetadata() { DbTableAlias = alias };
    }

    public partial class InterfaceHostMetadata : Metadata<InterfaceHost>
    {
        public override string DbTableName => "InterfaceHost";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo Name => DefineColumn("Name");
        public InterfaceHostMetadata As(string alias) => new InterfaceHostMetadata() { DbTableAlias = alias };
    }

    public partial class InterfaceIdentityMapMetadata : Metadata<InterfaceIdentityMap>
    {
        public override string DbTableName => "InterfaceIdentityMap";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo InterfaceHostOid => DefineColumn("InterfaceHostOid");
        public ColumnInfo TargetTable => DefineColumn("TargetTable");
        public ColumnInfo TargetOid => DefineColumn("TargetOid");
        public ColumnInfo ExternalId => DefineColumn("ExternalId");
        public InterfaceIdentityMapMetadata As(string alias) => new InterfaceIdentityMapMetadata() { DbTableAlias = alias };
    }

    public partial class ListingMetadata : Metadata<Listing>
    {
        public override string DbTableName => "Listing";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo EntityOid_BillingAuthority => DefineColumn("EntityOid_BillingAuthority");
        public ColumnInfo lkpBusinessCategoryOids => DefineColumn("lkpBusinessCategoryOids");
        public ColumnInfo lkpListingSetupStatusOid => DefineColumn("lkpListingSetupStatusOid");
        public ColumnInfo lkpCountryOid => DefineColumn("lkpCountryOid");
        public ColumnInfo lkpStateOid => DefineColumn("lkpStateOid");
        public ColumnInfo lkpCountyOid => DefineColumn("lkpCountyOid");
        public ColumnInfo lkpCityOid => DefineColumn("lkpCityOid");
        public ColumnInfo lkpLegalEntityTypeOid => DefineColumn("lkpLegalEntityTypeOid");
        public ColumnInfo lkpCommissionTypeOid => DefineColumn("lkpCommissionTypeOid");
        public ColumnInfo lkpListingCloseStatusOid => DefineColumn("lkpListingCloseStatusOid");
        public ColumnInfo ExternalId => DefineColumn("ExternalId");
        public ColumnInfo ExternalSystem => DefineColumn("ExternalSystem");
        public ColumnInfo ContactName => DefineColumn("ContactName");
        public ColumnInfo ContactEmail => DefineColumn("ContactEmail");
        public ColumnInfo ContactPhone => DefineColumn("ContactPhone");
        public ColumnInfo CompanyName => DefineColumn("CompanyName");
        public ColumnInfo CompanyPhone => DefineColumn("CompanyPhone");
        public ColumnInfo GeneralLocation => DefineColumn("GeneralLocation");
        public ColumnInfo SellerName => DefineColumn("SellerName");
        public ColumnInfo HoursOfOperation => DefineColumn("HoursOfOperation");
        public ColumnInfo Address => DefineColumn("Address");
        public ColumnInfo Address2 => DefineColumn("Address2");
        public ColumnInfo City => DefineColumn("City");
        public ColumnInfo County => DefineColumn("County");
        public ColumnInfo State => DefineColumn("State");
        public ColumnInfo Zip => DefineColumn("Zip");
        public ColumnInfo Keywords => DefineColumn("Keywords");
        public ColumnInfo AdTitle => DefineColumn("AdTitle");
        public ColumnInfo AdTagLine => DefineColumn("AdTagLine");
        public ColumnInfo AdDescription => DefineColumn("AdDescription");
        public ColumnInfo AdBusinessHistory => DefineColumn("AdBusinessHistory");
        public ColumnInfo AdCompetitiveAnalysis => DefineColumn("AdCompetitiveAnalysis");
        public ColumnInfo AdOpportunityForGrowth => DefineColumn("AdOpportunityForGrowth");
        public ColumnInfo AdReasonForSelling => DefineColumn("AdReasonForSelling");
        public ColumnInfo AdFacilityDescription => DefineColumn("AdFacilityDescription");
        public ColumnInfo AdSupportAndTraining => DefineColumn("AdSupportAndTraining");
        public ColumnInfo AdPhoto => DefineColumn("AdPhoto");
        public ColumnInfo ListingPrice => DefineColumn("ListingPrice");
        public ColumnInfo GrossRevenue => DefineColumn("GrossRevenue");
        public ColumnInfo COGs => DefineColumn("COGs");
        public ColumnInfo EBITDA => DefineColumn("EBITDA");
        public ColumnInfo AccountsReceivable => DefineColumn("AccountsReceivable");
        public ColumnInfo Inventory => DefineColumn("Inventory");
        public ColumnInfo CashFlow => DefineColumn("CashFlow");
        public ColumnInfo FFandE => DefineColumn("FFandE");
        public ColumnInfo RealEstateValue => DefineColumn("RealEstateValue");
        public ColumnInfo RealEstateAskingPrice => DefineColumn("RealEstateAskingPrice");
        public ColumnInfo MinimumDownPayment => DefineColumn("MinimumDownPayment");
        public ColumnInfo SellerFinanceUpTo => DefineColumn("SellerFinanceUpTo");
        public ColumnInfo Rent => DefineColumn("Rent");
        public ColumnInfo RequestedDownPayment => DefineColumn("RequestedDownPayment");
        public ColumnInfo CommissionRate => DefineColumn("CommissionRate");
        public ColumnInfo CommissionMinimum => DefineColumn("CommissionMinimum");
        public ColumnInfo TotalSqFt => DefineColumn("TotalSqFt");
        public ColumnInfo OccupiedSqFt => DefineColumn("OccupiedSqFt");
        public ColumnInfo FacilityOwned_Int => DefineColumn("FacilityOwned_Int");
        public ColumnInfo RealEstateIncluded_Int => DefineColumn("RealEstateIncluded_Int");
        public ColumnInfo ShowCounty_Int => DefineColumn("ShowCounty_Int");
        public ColumnInfo ShowCity_Int => DefineColumn("ShowCity_Int");
        public ColumnInfo ShowZip_Int => DefineColumn("ShowZip_Int");
        public ColumnInfo ShowGrossRevenues_Int => DefineColumn("ShowGrossRevenues_Int");
        public ColumnInfo ShowCashFlow_Int => DefineColumn("ShowCashFlow_Int");
        public ColumnInfo ShowEBITDA_Int => DefineColumn("ShowEBITDA_Int");
        public ColumnInfo ShowInventory_Int => DefineColumn("ShowInventory_Int");
        public ColumnInfo ShowFFE_Int => DefineColumn("ShowFFE_Int");
        public ColumnInfo ShowCompanyWebsite_Int => DefineColumn("ShowCompanyWebsite_Int");
        public ColumnInfo ShowNumberOfEmployees_Int => DefineColumn("ShowNumberOfEmployees_Int");
        public ColumnInfo ShowYearEstablished_Int => DefineColumn("ShowYearEstablished_Int");
        public ColumnInfo BuildingCount => DefineColumn("BuildingCount");
        public ColumnInfo EmployeeCount => DefineColumn("EmployeeCount");
        public ColumnInfo BuyerCount => DefineColumn("BuyerCount");
        public ColumnInfo IsRealEstateInPrice => DefineColumn("IsRealEstateInPrice");
        public ColumnInfo IsAbsenteeOwner => DefineColumn("IsAbsenteeOwner");
        public ColumnInfo IsHomeBased => DefineColumn("IsHomeBased");
        public ColumnInfo IsRelocatable => DefineColumn("IsRelocatable");
        public ColumnInfo IsFranchise => DefineColumn("IsFranchise");
        public ColumnInfo IsSellerFinanace => DefineColumn("IsSellerFinanace");
        public ColumnInfo IsSbaPreApproved => DefineColumn("IsSbaPreApproved");
        public ColumnInfo IsInventoryIncluded => DefineColumn("IsInventoryIncluded");
        public ColumnInfo IsAccountsReceivableIncluded => DefineColumn("IsAccountsReceivableIncluded");
        public ColumnInfo WebsiteURL => DefineColumn("WebsiteURL");
        public ColumnInfo YearEstablished => DefineColumn("YearEstablished");
        public ColumnInfo ListingDate => DefineColumn("ListingDate");
        public ColumnInfo CloseDate => DefineColumn("CloseDate");
        public ColumnInfo ExpirationDate => DefineColumn("ExpirationDate");
        public ColumnInfo CreatedOn => DefineColumn("CreatedOn");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public ColumnInfo IsPending => DefineColumn("IsPending");
        public ListingMetadata As(string alias) => new ListingMetadata() { DbTableAlias = alias };
    }

    public partial class Listing2BizCategoryMapMetadata : Metadata<Listing2BizCategoryMap>
    {
        public override string DbTableName => "Listing2BizCategoryMap";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ListingOid => DefineColumn("ListingOid");
        public ColumnInfo lkpBusinessCategoryOid => DefineColumn("lkpBusinessCategoryOid");
        public ColumnInfo SearchListingOid => DefineColumn("SearchListingOid");
        public Listing2BizCategoryMapMetadata As(string alias) => new Listing2BizCategoryMapMetadata() { DbTableAlias = alias };
    }

    public partial class ListingAttributeMetadata : Metadata<ListingAttribute>
    {
        public override string DbTableName => "ListingAttribute";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ParentOid => DefineColumn("ParentOid");
        public ColumnInfo ListingOid => DefineColumn("ListingOid");
        public ColumnInfo lkpAttributeTypeOid => DefineColumn("lkpAttributeTypeOid");
        public ColumnInfo DataType => DefineColumn("DataType");
        public ColumnInfo Value => DefineColumn("Value");
        public ListingAttributeMetadata As(string alias) => new ListingAttributeMetadata() { DbTableAlias = alias };
    }

    public partial class ListingStatMetadata : Metadata<ListingStat>
    {
        public override string DbTableName => "ListingStat";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ListingOid => DefineColumn("ListingOid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo Context => DefineColumn("Context");
        public ColumnInfo Date => DefineColumn("Date");
        public ListingStatMetadata As(string alias) => new ListingStatMetadata() { DbTableAlias = alias };
    }

    public partial class LoginMetadata : Metadata<Login>
    {
        public override string DbTableName => "Login";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo SecurityGroupOid => DefineColumn("SecurityGroupOid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo EntityOid_Master => DefineColumn("EntityOid_Master");
        public ColumnInfo EntityOid_Authority => DefineColumn("EntityOid_Authority");
        public ColumnInfo lkpThirdPartyAuthTypeOid => DefineColumn("lkpThirdPartyAuthTypeOid");
        public ColumnInfo ThirdPartyAuthToken => DefineColumn("ThirdPartyAuthToken");
        public ColumnInfo LoginName => DefineColumn("LoginName");
        public ColumnInfo ScreenName => DefineColumn("ScreenName");
        public ColumnInfo Password => DefineColumn("Password");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public ColumnInfo IsLocked => DefineColumn("IsLocked");
        public ColumnInfo IsTermsAndConditionsAccepted => DefineColumn("IsTermsAndConditionsAccepted");
        public ColumnInfo IsNewUser => DefineColumn("IsNewUser");
        public ColumnInfo UserMustChangePwd => DefineColumn("UserMustChangePwd");
        public ColumnInfo IsCwsUser => DefineColumn("IsCwsUser");
        public ColumnInfo ConsecutiveLoginFailures => DefineColumn("ConsecutiveLoginFailures");
        public ColumnInfo LastLoginDate => DefineColumn("LastLoginDate");
        public ColumnInfo DatePwChanged => DefineColumn("DatePwChanged");
        public ColumnInfo CreatedOn => DefineColumn("CreatedOn");
        public ColumnInfo Ok2Delete => DefineColumn("Ok2Delete");
        public LoginMetadata As(string alias) => new LoginMetadata() { DbTableAlias = alias };
    }

    public partial class LookupMetadata : Metadata<Lookup>
    {
        public override string DbTableName => "Lookup";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo LookupDefinitionOid => DefineColumn("LookupDefinitionOid");
        public ColumnInfo ParentOid => DefineColumn("ParentOid");
        public ColumnInfo LookupName => DefineColumn("LookupName");
        public ColumnInfo ConstantValue => DefineColumn("ConstantValue");
        public ColumnInfo Value => DefineColumn("Value");
        public ColumnInfo Description => DefineColumn("Description");
        public ColumnInfo SortOrder => DefineColumn("SortOrder");
        public ColumnInfo UDF1 => DefineColumn("UDF1");
        public ColumnInfo UDF2 => DefineColumn("UDF2");
        public ColumnInfo UDF3 => DefineColumn("UDF3");
        public ColumnInfo UDF4 => DefineColumn("UDF4");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public ColumnInfo MetaData => DefineColumn("MetaData");
        public LookupMetadata As(string alias) => new LookupMetadata() { DbTableAlias = alias };
    }

    public partial class LookupDefinitionMetadata : Metadata<LookupDefinition>
    {
        public override string DbTableName => "LookupDefinition";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ParentOid => DefineColumn("ParentOid");
        public ColumnInfo LookupName => DefineColumn("LookupName");
        public ColumnInfo Description => DefineColumn("Description");
        public ColumnInfo UDF1 => DefineColumn("UDF1");
        public ColumnInfo UDF2 => DefineColumn("UDF2");
        public ColumnInfo UDF3 => DefineColumn("UDF3");
        public ColumnInfo UDF4 => DefineColumn("UDF4");
        public LookupDefinitionMetadata As(string alias) => new LookupDefinitionMetadata() { DbTableAlias = alias };
    }

    public partial class NotificationMetadata : Metadata<Notification>
    {
        public override string DbTableName => "Notification";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo TargetOid => DefineColumn("TargetOid");
        public ColumnInfo TargetTable => DefineColumn("TargetTable");
        public ColumnInfo Category => DefineColumn("Category");
        public ColumnInfo Title => DefineColumn("Title");
        public ColumnInfo Message => DefineColumn("Message");
        public ColumnInfo Data => DefineColumn("Data");
        public ColumnInfo Url => DefineColumn("Url");
        public ColumnInfo IsRead => DefineColumn("IsRead");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public ColumnInfo CreatedOnDate => DefineColumn("CreatedOnDate");
        public NotificationMetadata As(string alias) => new NotificationMetadata() { DbTableAlias = alias };
    }

    public partial class ProcessMetadata : Metadata<Process>
    {
        public override string DbTableName => "Process";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ProcessStepOid => DefineColumn("ProcessStepOid");
        public ProcessMetadata As(string alias) => new ProcessMetadata() { DbTableAlias = alias };
    }

    public partial class ProcessDescriptionMetadata : Metadata<ProcessDescription>
    {
        public override string DbTableName => "ProcessDescription";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ParentOid => DefineColumn("ParentOid");
        public ColumnInfo EntityOid_Master => DefineColumn("EntityOid_Master");
        public ColumnInfo lkpProcessTypeOid => DefineColumn("lkpProcessTypeOid");
        public ColumnInfo Name => DefineColumn("Name");
        public ProcessDescriptionMetadata As(string alias) => new ProcessDescriptionMetadata() { DbTableAlias = alias };
    }

    public partial class ProcessSequenceMapMetadata : Metadata<ProcessSequenceMap>
    {
        public override string DbTableName => "ProcessSequenceMap";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ProcessOid => DefineColumn("ProcessOid");
        public ColumnInfo ProcessStepOid => DefineColumn("ProcessStepOid");
        public ColumnInfo Sequence => DefineColumn("Sequence");
        public ProcessSequenceMapMetadata As(string alias) => new ProcessSequenceMapMetadata() { DbTableAlias = alias };
    }

    public partial class ProcessStepMetadata : Metadata<ProcessStep>
    {
        public override string DbTableName => "ProcessStep";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ParentOid => DefineColumn("ParentOid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo Notes => DefineColumn("Notes");
        public ColumnInfo ProgramCode => DefineColumn("ProgramCode");
        public ColumnInfo IsRequired => DefineColumn("IsRequired");
        public ColumnInfo SortOrder => DefineColumn("SortOrder");
        public ProcessStepMetadata As(string alias) => new ProcessStepMetadata() { DbTableAlias = alias };
    }

    public partial class RecipeMetadata : Metadata<Recipe>
    {
        public override string DbTableName => "Recipe";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo Description => DefineColumn("Description");
        public ColumnInfo Source => DefineColumn("Source");
        public RecipeMetadata As(string alias) => new RecipeMetadata() { DbTableAlias = alias };
    }

    public partial class SearchCriteriaMetadata : Metadata<SearchCriteria>
    {
        public override string DbTableName => "SearchCriteria";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo lkpCountryOid => DefineColumn("lkpCountryOid");
        public ColumnInfo lkpStateOid => DefineColumn("lkpStateOid");
        public ColumnInfo lkpCountyOids => DefineColumn("lkpCountyOids");
        public ColumnInfo lkpCityOids => DefineColumn("lkpCityOids");
        public ColumnInfo ZipCode => DefineColumn("ZipCode");
        public ColumnInfo ZipCodes => DefineColumn("ZipCodes");
        public ColumnInfo SearchRadius => DefineColumn("SearchRadius");
        public ColumnInfo lkpBusinessCategoryOids => DefineColumn("lkpBusinessCategoryOids");
        public ColumnInfo Keywords => DefineColumn("Keywords");
        public ColumnInfo Street => DefineColumn("Street");
        public ColumnInfo ListingPrice_From => DefineColumn("ListingPrice_From");
        public ColumnInfo ListingPrice_To => DefineColumn("ListingPrice_To");
        public ColumnInfo GrossRevenue_From => DefineColumn("GrossRevenue_From");
        public ColumnInfo GrossRevenue_To => DefineColumn("GrossRevenue_To");
        public ColumnInfo EBITDA_From => DefineColumn("EBITDA_From");
        public ColumnInfo EBITDA_To => DefineColumn("EBITDA_To");
        public ColumnInfo CashFlow_From => DefineColumn("CashFlow_From");
        public ColumnInfo CashFlow_To => DefineColumn("CashFlow_To");
        public ColumnInfo MinimumDownPayment_From => DefineColumn("MinimumDownPayment_From");
        public ColumnInfo MinimumDownPayment_To => DefineColumn("MinimumDownPayment_To");
        public ColumnInfo TotalSqFt_From => DefineColumn("TotalSqFt_From");
        public ColumnInfo TotalSqFt_To => DefineColumn("TotalSqFt_To");
        public ColumnInfo EmployeeCount_From => DefineColumn("EmployeeCount_From");
        public ColumnInfo EmployeeCount_To => DefineColumn("EmployeeCount_To");
        public ColumnInfo IsAbsenteeOwner => DefineColumn("IsAbsenteeOwner");
        public ColumnInfo IsHomeBased => DefineColumn("IsHomeBased");
        public ColumnInfo IsRelocatable => DefineColumn("IsRelocatable");
        public ColumnInfo IsFranchise => DefineColumn("IsFranchise");
        public ColumnInfo IsSellerFinanace => DefineColumn("IsSellerFinanace");
        public ColumnInfo IsSbaPreApproved => DefineColumn("IsSbaPreApproved");
        public ColumnInfo IsRealEstateAvailable => DefineColumn("IsRealEstateAvailable");
        public ColumnInfo IsTextNotification => DefineColumn("IsTextNotification");
        public ColumnInfo IsEmailNotification => DefineColumn("IsEmailNotification");
        public ColumnInfo IsEmailRecipientListQuery => DefineColumn("IsEmailRecipientListQuery");
        public ColumnInfo LastSearchedDate => DefineColumn("LastSearchedDate");
        public ColumnInfo NewListingsSinceLastSearchDate => DefineColumn("NewListingsSinceLastSearchDate");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public ColumnInfo ListingCount => DefineColumn("ListingCount");
        public SearchCriteriaMetadata As(string alias) => new SearchCriteriaMetadata() { DbTableAlias = alias };
    }

    public partial class SecurityGroupMetadata : Metadata<SecurityGroup>
    {
        public override string DbTableName => "SecurityGroup";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ParentOid => DefineColumn("ParentOid");
        public ColumnInfo SecurityPwdRuleOid => DefineColumn("SecurityPwdRuleOid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo Constant => DefineColumn("Constant");
        public ColumnInfo Description => DefineColumn("Description");
        public ColumnInfo IsAdmin => DefineColumn("IsAdmin");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public ColumnInfo NavMenu_JSON => DefineColumn("NavMenu_JSON");
        public ColumnInfo CreatedBy => DefineColumn("CreatedBy");
        public ColumnInfo CreatedOn => DefineColumn("CreatedOn");
        public ColumnInfo ModifiedBy => DefineColumn("ModifiedBy");
        public ColumnInfo ModifiedOn => DefineColumn("ModifiedOn");
        public ColumnInfo Version => DefineColumn("Version");
        public SecurityGroupMetadata As(string alias) => new SecurityGroupMetadata() { DbTableAlias = alias };
    }

    public partial class SecurityPwdRuleMetadata : Metadata<SecurityPwdRule>
    {
        public override string DbTableName => "SecurityPwdRule";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo UserCanChangePwd => DefineColumn("UserCanChangePwd");
        public ColumnInfo PwdNeverExpires => DefineColumn("PwdNeverExpires");
        public ColumnInfo UserMustChangePwd => DefineColumn("UserMustChangePwd");
        public ColumnInfo DaysPasswordIsValid => DefineColumn("DaysPasswordIsValid");
        public ColumnInfo MaxLoginAttemptsAllowed => DefineColumn("MaxLoginAttemptsAllowed");
        public SecurityPwdRuleMetadata As(string alias) => new SecurityPwdRuleMetadata() { DbTableAlias = alias };
    }

    public partial class SequenceItemMetadata : Metadata<SequenceItem>
    {
        public override string DbTableName => "SequenceItem";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ParentOid => DefineColumn("ParentOid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo ListingOid => DefineColumn("ListingOid");
        public ColumnInfo lkpSequenceTypeOid => DefineColumn("lkpSequenceTypeOid");
        public ColumnInfo lkpCheckListStatusOid => DefineColumn("lkpCheckListStatusOid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo InfoUrl => DefineColumn("InfoUrl");
        public ColumnInfo DateCompleted => DefineColumn("DateCompleted");
        public ColumnInfo Seq => DefineColumn("Seq");
        public SequenceItemMetadata As(string alias) => new SequenceItemMetadata() { DbTableAlias = alias };
    }

    public partial class TextAttachmentMetadata : Metadata<TextAttachment>
    {
        public override string DbTableName => "TextAttachment";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo TextMessageOid => DefineColumn("TextMessageOid");
        public ColumnInfo lkpFileTypeOid => DefineColumn("lkpFileTypeOid");
        public ColumnInfo FilePath => DefineColumn("FilePath");
        public ColumnInfo ThumbnailFilePath => DefineColumn("ThumbnailFilePath");
        public TextAttachmentMetadata As(string alias) => new TextAttachmentMetadata() { DbTableAlias = alias };
    }

    public partial class TextChannelMetadata : Metadata<TextChannel>
    {
        public override string DbTableName => "TextChannel";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo TextGroupOid => DefineColumn("TextGroupOid");
        public ColumnInfo TwilliId => DefineColumn("TwilliId");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo Avatar => DefineColumn("Avatar");
        public ColumnInfo LastCommunicationDate => DefineColumn("LastCommunicationDate");
        public ColumnInfo HasUnreadMessages => DefineColumn("HasUnreadMessages");
        public TextChannelMetadata As(string alias) => new TextChannelMetadata() { DbTableAlias = alias };
    }

    public partial class TextGroupMetadata : Metadata<TextGroup>
    {
        public override string DbTableName => "TextGroup";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ParentOid => DefineColumn("ParentOid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo EntityOid_Master => DefineColumn("EntityOid_Master");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo HasMessages => DefineColumn("HasMessages");
        public ColumnInfo HasUnreadMessages => DefineColumn("HasUnreadMessages");
        public ColumnInfo Sort => DefineColumn("Sort");
        public TextGroupMetadata As(string alias) => new TextGroupMetadata() { DbTableAlias = alias };
    }

    public partial class TextInvitationMetadata : Metadata<TextInvitation>
    {
        public override string DbTableName => "TextInvitation";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo TextMessageOid => DefineColumn("TextMessageOid");
        public ColumnInfo EntityOid_Host => DefineColumn("EntityOid_Host");
        public ColumnInfo lkpEventTypeOid => DefineColumn("lkpEventTypeOid");
        public ColumnInfo Date => DefineColumn("Date");
        public ColumnInfo RsvpBy => DefineColumn("RsvpBy");
        public TextInvitationMetadata As(string alias) => new TextInvitationMetadata() { DbTableAlias = alias };
    }

    public partial class TextMessageMetadata : Metadata<TextMessage>
    {
        public override string DbTableName => "TextMessage";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo TextChannelOid => DefineColumn("TextChannelOid");
        public ColumnInfo lkpMessageTypeOid => DefineColumn("lkpMessageTypeOid");
        public ColumnInfo Message => DefineColumn("Message");
        public ColumnInfo DateSent => DefineColumn("DateSent");
        public ColumnInfo SentBy => DefineColumn("SentBy");
        public ColumnInfo SentByOid => DefineColumn("SentByOid");
        public ColumnInfo IsEdited => DefineColumn("IsEdited");
        public TextMessageMetadata As(string alias) => new TextMessageMetadata() { DbTableAlias = alias };
    }

    public partial class TextMessageActionMetadata : Metadata<TextMessageAction>
    {
        public override string DbTableName => "TextMessageAction";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo TextMessageOid => DefineColumn("TextMessageOid");
        public ColumnInfo TextRecipientOid => DefineColumn("TextRecipientOid");
        public ColumnInfo IsRead => DefineColumn("IsRead");
        public ColumnInfo IsDeletedByUser => DefineColumn("IsDeletedByUser");
        public TextMessageActionMetadata As(string alias) => new TextMessageActionMetadata() { DbTableAlias = alias };
    }

    public partial class TextRecipientMetadata : Metadata<TextRecipient>
    {
        public override string DbTableName => "TextRecipient";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo TextChannelOid => DefineColumn("TextChannelOid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo TextInvitationOid => DefineColumn("TextInvitationOid");
        public ColumnInfo ChannelName => DefineColumn("ChannelName");
        public ColumnInfo OptOut => DefineColumn("OptOut");
        public ColumnInfo IsInvite => DefineColumn("IsInvite");
        public ColumnInfo Rsvp => DefineColumn("Rsvp");
        public TextRecipientMetadata As(string alias) => new TextRecipientMetadata() { DbTableAlias = alias };
    }

    public partial class Whse_ListingStatMetadata : Metadata<Whse_ListingStat>
    {
        public override string DbTableName => "Whse_ListingStat";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ListingOid => DefineColumn("ListingOid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo EntityOid_Master => DefineColumn("EntityOid_Master");
        public ColumnInfo EntityOid_Region => DefineColumn("EntityOid_Region");
        public ColumnInfo EntityOid_Office => DefineColumn("EntityOid_Office");
        public ColumnInfo CompanyName => DefineColumn("CompanyName");
        public ColumnInfo AdTitle => DefineColumn("AdTitle");
        public ColumnInfo AdTagLine => DefineColumn("AdTagLine");
        public ColumnInfo Views => DefineColumn("Views");
        public ColumnInfo Views_LastLook => DefineColumn("Views_LastLook");
        public ColumnInfo ViewsLast3Months => DefineColumn("ViewsLast3Months");
        public ColumnInfo ViewsLastMonth => DefineColumn("ViewsLastMonth");
        public ColumnInfo ViewsLast7Days => DefineColumn("ViewsLast7Days");
        public ColumnInfo ViewsLast24Hrs => DefineColumn("ViewsLast24Hrs");
        public ColumnInfo Clicks => DefineColumn("Clicks");
        public ColumnInfo Clicks_LastLook => DefineColumn("Clicks_LastLook");
        public ColumnInfo ClicksLast3Months => DefineColumn("ClicksLast3Months");
        public ColumnInfo ClicksLastMonth => DefineColumn("ClicksLastMonth");
        public ColumnInfo ClicksLast7Days => DefineColumn("ClicksLast7Days");
        public ColumnInfo ClicksLast24Hrs => DefineColumn("ClicksLast24Hrs");
        public ColumnInfo Favorited => DefineColumn("Favorited");
        public ColumnInfo Favorited_LastLook => DefineColumn("Favorited_LastLook");
        public ColumnInfo FavoritedLast3Months => DefineColumn("FavoritedLast3Months");
        public ColumnInfo FavoritedLastMonth => DefineColumn("FavoritedLastMonth");
        public ColumnInfo FavoritedLast7Days => DefineColumn("FavoritedLast7Days");
        public ColumnInfo FavoritedLast24Hrs => DefineColumn("FavoritedLast24Hrs");
        public ColumnInfo ContactRequests => DefineColumn("ContactRequests");
        public ColumnInfo ContactRequests_LastLook => DefineColumn("ContactRequests_LastLook");
        public ColumnInfo ContactRequestsLast3Months => DefineColumn("ContactRequestsLast3Months");
        public ColumnInfo ContactRequestsLastMonth => DefineColumn("ContactRequestsLastMonth");
        public ColumnInfo ContactRequestsLast7Days => DefineColumn("ContactRequestsLast7Days");
        public ColumnInfo ContactRequestsLast24Hrs => DefineColumn("ContactRequestsLast24Hrs");
        public Whse_ListingStatMetadata As(string alias) => new Whse_ListingStatMetadata() { DbTableAlias = alias };
    }

    public partial class Whse_RunSearchArchiveMetadata : Metadata<Whse_RunSearchArchive>
    {
        public override string DbTableName => "Whse_RunSearchArchive";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo SearchCriteriaOid => DefineColumn("SearchCriteriaOid");
        public ColumnInfo EntityOid => DefineColumn("EntityOid");
        public ColumnInfo Name => DefineColumn("Name");
        public ColumnInfo lkpCountryOid => DefineColumn("lkpCountryOid");
        public ColumnInfo lkpStateOid => DefineColumn("lkpStateOid");
        public ColumnInfo lkpCountyOids => DefineColumn("lkpCountyOids");
        public ColumnInfo lkpCityOids => DefineColumn("lkpCityOids");
        public ColumnInfo ZipCode => DefineColumn("ZipCode");
        public ColumnInfo ZipCodes => DefineColumn("ZipCodes");
        public ColumnInfo SearchRadius => DefineColumn("SearchRadius");
        public ColumnInfo lkpBusinessCategoryOids => DefineColumn("lkpBusinessCategoryOids");
        public ColumnInfo Keywords => DefineColumn("Keywords");
        public ColumnInfo Street => DefineColumn("Street");
        public ColumnInfo ListingPrice_From => DefineColumn("ListingPrice_From");
        public ColumnInfo ListingPrice_To => DefineColumn("ListingPrice_To");
        public ColumnInfo GrossRevenue_From => DefineColumn("GrossRevenue_From");
        public ColumnInfo GrossRevenue_To => DefineColumn("GrossRevenue_To");
        public ColumnInfo EBITDA_From => DefineColumn("EBITDA_From");
        public ColumnInfo EBITDA_To => DefineColumn("EBITDA_To");
        public ColumnInfo CashFlow_From => DefineColumn("CashFlow_From");
        public ColumnInfo CashFlow_To => DefineColumn("CashFlow_To");
        public ColumnInfo MinimumDownPayment_From => DefineColumn("MinimumDownPayment_From");
        public ColumnInfo MinimumDownPayment_To => DefineColumn("MinimumDownPayment_To");
        public ColumnInfo TotalSqFt_From => DefineColumn("TotalSqFt_From");
        public ColumnInfo TotalSqFt_To => DefineColumn("TotalSqFt_To");
        public ColumnInfo EmployeeCount_From => DefineColumn("EmployeeCount_From");
        public ColumnInfo EmployeeCount_To => DefineColumn("EmployeeCount_To");
        public ColumnInfo IsAbsenteeOwner => DefineColumn("IsAbsenteeOwner");
        public ColumnInfo IsHomeBased => DefineColumn("IsHomeBased");
        public ColumnInfo IsRelocatable => DefineColumn("IsRelocatable");
        public ColumnInfo IsFranchise => DefineColumn("IsFranchise");
        public ColumnInfo IsSellerFinanace => DefineColumn("IsSellerFinanace");
        public ColumnInfo IsSbaPreApproved => DefineColumn("IsSbaPreApproved");
        public ColumnInfo IsRealEstateAvailable => DefineColumn("IsRealEstateAvailable");
        public ColumnInfo IsTextNotification => DefineColumn("IsTextNotification");
        public ColumnInfo IsEmailNotification => DefineColumn("IsEmailNotification");
        public ColumnInfo IsEmailRecipientListQuery => DefineColumn("IsEmailRecipientListQuery");
        public ColumnInfo LastSearchedDate => DefineColumn("LastSearchedDate");
        public ColumnInfo NewListingsSinceLastSearchDate => DefineColumn("NewListingsSinceLastSearchDate");
        public ColumnInfo IsActive => DefineColumn("IsActive");
        public ColumnInfo ListingCount => DefineColumn("ListingCount");
        public ColumnInfo RunDate => DefineColumn("RunDate");
        public Whse_RunSearchArchiveMetadata As(string alias) => new Whse_RunSearchArchiveMetadata() { DbTableAlias = alias };
    }

    public partial class ZCMetadata : Metadata<ZC>
    {
        public override string DbTableName => "ZC";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ZipCode => DefineColumn("ZipCode");
        public ColumnInfo PrimaryRecord => DefineColumn("PrimaryRecord");
        public ColumnInfo Population => DefineColumn("Population");
        public ColumnInfo HouseholdsPerZipcode => DefineColumn("HouseholdsPerZipcode");
        public ColumnInfo WhitePopulation => DefineColumn("WhitePopulation");
        public ColumnInfo BlackPopulation => DefineColumn("BlackPopulation");
        public ColumnInfo HispanicPopulation => DefineColumn("HispanicPopulation");
        public ColumnInfo AsianPopulation => DefineColumn("AsianPopulation");
        public ColumnInfo HawaiianPopulation => DefineColumn("HawaiianPopulation");
        public ColumnInfo IndianPopulation => DefineColumn("IndianPopulation");
        public ColumnInfo OtherPopulation => DefineColumn("OtherPopulation");
        public ColumnInfo MalePopulation => DefineColumn("MalePopulation");
        public ColumnInfo FemalePopulation => DefineColumn("FemalePopulation");
        public ColumnInfo PersonsPerHousehold => DefineColumn("PersonsPerHousehold");
        public ColumnInfo AverageHouseValue => DefineColumn("AverageHouseValue");
        public ColumnInfo IncomePerHousehold => DefineColumn("IncomePerHousehold");
        public ColumnInfo MedianAge => DefineColumn("MedianAge");
        public ColumnInfo MedianAgeMale => DefineColumn("MedianAgeMale");
        public ColumnInfo MedianAgeFemale => DefineColumn("MedianAgeFemale");
        public ColumnInfo Latitude => DefineColumn("Latitude");
        public ColumnInfo Longitude => DefineColumn("Longitude");
        public ColumnInfo Elevation => DefineColumn("Elevation");
        public ColumnInfo State => DefineColumn("State");
        public ColumnInfo StateFullName => DefineColumn("StateFullName");
        public ColumnInfo CityType => DefineColumn("CityType");
        public ColumnInfo CityAliasAbbreviation => DefineColumn("CityAliasAbbreviation");
        public ColumnInfo AreaCode => DefineColumn("AreaCode");
        public ColumnInfo City => DefineColumn("City");
        public ColumnInfo CityAliasName => DefineColumn("CityAliasName");
        public ColumnInfo County => DefineColumn("County");
        public ColumnInfo CountyFIPS => DefineColumn("CountyFIPS");
        public ColumnInfo StateFIPS => DefineColumn("StateFIPS");
        public ColumnInfo TimeZone => DefineColumn("TimeZone");
        public ColumnInfo DayLightSaving => DefineColumn("DayLightSaving");
        public ColumnInfo MSA => DefineColumn("MSA");
        public ColumnInfo PMSA => DefineColumn("PMSA");
        public ColumnInfo CSA => DefineColumn("CSA");
        public ColumnInfo CBSA => DefineColumn("CBSA");
        public ColumnInfo CBSA_DIV => DefineColumn("CBSA_DIV");
        public ColumnInfo CBSA_Type => DefineColumn("CBSA_Type");
        public ColumnInfo CBSA_Name => DefineColumn("CBSA_Name");
        public ColumnInfo MSA_Name => DefineColumn("MSA_Name");
        public ColumnInfo PMSA_Name => DefineColumn("PMSA_Name");
        public ColumnInfo Region => DefineColumn("Region");
        public ColumnInfo Division => DefineColumn("Division");
        public ColumnInfo MailingName => DefineColumn("MailingName");
        public ColumnInfo NumberOfBusinesses => DefineColumn("NumberOfBusinesses");
        public ColumnInfo NumberOfEmployees => DefineColumn("NumberOfEmployees");
        public ColumnInfo BusinessFirstQuarterPayroll => DefineColumn("BusinessFirstQuarterPayroll");
        public ColumnInfo BusinessAnnualPayroll => DefineColumn("BusinessAnnualPayroll");
        public ColumnInfo BusinessEmploymentFlag => DefineColumn("BusinessEmploymentFlag");
        public ColumnInfo GrowthRank => DefineColumn("GrowthRank");
        public ColumnInfo GrowingCountiesA => DefineColumn("GrowingCountiesA");
        public ColumnInfo GrowingCountiesB => DefineColumn("GrowingCountiesB");
        public ColumnInfo GrowthIncreaseNumber => DefineColumn("GrowthIncreaseNumber");
        public ColumnInfo GrowthIncreasePercentage => DefineColumn("GrowthIncreasePercentage");
        public ColumnInfo CBSAPopulation => DefineColumn("CBSAPopulation");
        public ColumnInfo CBSADivisionPopulation => DefineColumn("CBSADivisionPopulation");
        public ColumnInfo CongressionalDistrict => DefineColumn("CongressionalDistrict");
        public ColumnInfo CongressionalLandArea => DefineColumn("CongressionalLandArea");
        public ColumnInfo DeliveryResidential => DefineColumn("DeliveryResidential");
        public ColumnInfo DeliveryBusiness => DefineColumn("DeliveryBusiness");
        public ColumnInfo DeliveryTotal => DefineColumn("DeliveryTotal");
        public ColumnInfo PreferredLastLineKey => DefineColumn("PreferredLastLineKey");
        public ColumnInfo ClassificationCode => DefineColumn("ClassificationCode");
        public ColumnInfo MultiCounty => DefineColumn("MultiCounty");
        public ColumnInfo CSAName => DefineColumn("CSAName");
        public ColumnInfo CBSA_DIV_Name => DefineColumn("CBSA_DIV_Name");
        public ColumnInfo CityStateKey => DefineColumn("CityStateKey");
        public ColumnInfo PopulationEstimate => DefineColumn("PopulationEstimate");
        public ColumnInfo LandArea => DefineColumn("LandArea");
        public ColumnInfo WaterArea => DefineColumn("WaterArea");
        public ColumnInfo CityAliasCode => DefineColumn("CityAliasCode");
        public ColumnInfo CityMixedCase => DefineColumn("CityMixedCase");
        public ColumnInfo CityAliasMixedCase => DefineColumn("CityAliasMixedCase");
        public ColumnInfo BoxCount => DefineColumn("BoxCount");
        public ColumnInfo SFDU => DefineColumn("SFDU");
        public ColumnInfo MFDU => DefineColumn("MFDU");
        public ColumnInfo StateANSI => DefineColumn("StateANSI");
        public ColumnInfo CountyANSI => DefineColumn("CountyANSI");
        public ColumnInfo ZIPIntroDate => DefineColumn("ZIPIntroDate");
        public ColumnInfo AliasIntroDate => DefineColumn("AliasIntroDate");
        public ColumnInfo FacilityCode => DefineColumn("FacilityCode");
        public ColumnInfo CityDeliveryIndicator => DefineColumn("CityDeliveryIndicator");
        public ColumnInfo CarrierRouteRateSortation => DefineColumn("CarrierRouteRateSortation");
        public ColumnInfo FinanceNumber => DefineColumn("FinanceNumber");
        public ColumnInfo UniqueZIPName => DefineColumn("UniqueZIPName");
        public ColumnInfo SSAStateCountyCode => DefineColumn("SSAStateCountyCode");
        public ColumnInfo MedicareCBSACode => DefineColumn("MedicareCBSACode");
        public ColumnInfo MedicareCBSAName => DefineColumn("MedicareCBSAName");
        public ColumnInfo MedicareCBSAType => DefineColumn("MedicareCBSAType");
        public ColumnInfo MarketRatingAreaID => DefineColumn("MarketRatingAreaID");
        public ColumnInfo CountyMixedCase => DefineColumn("CountyMixedCase");
        public ZCMetadata As(string alias) => new ZCMetadata() { DbTableAlias = alias };
    }

    public partial class ZC_MultiCountyMetadata : Metadata<ZC_MultiCounty>
    {
        public override string DbTableName => "ZC_MultiCounty";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ZCOid => DefineColumn("ZCOid");
        public ColumnInfo ZipCode => DefineColumn("ZipCode");
        public ColumnInfo StateFIPS => DefineColumn("StateFIPS");
        public ColumnInfo State => DefineColumn("State");
        public ColumnInfo CountyFIPS => DefineColumn("CountyFIPS");
        public ColumnInfo County => DefineColumn("County");
        public ColumnInfo CountyMixedCase => DefineColumn("CountyMixedCase");
        public ZC_MultiCountyMetadata As(string alias) => new ZC_MultiCountyMetadata() { DbTableAlias = alias };
    }

    public partial class ZC_PlaceFIPSMetadata : Metadata<ZC_PlaceFIPS>
    {
        public override string DbTableName => "ZC_PlaceFIPS";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo ZCOid => DefineColumn("ZCOid");
        public ColumnInfo ZipCode => DefineColumn("ZipCode");
        public ColumnInfo State => DefineColumn("State");
        public ColumnInfo StateFIPS => DefineColumn("StateFIPS");
        public ColumnInfo ZipCodes_PlaceFIPS => DefineColumn("ZipCodes_PlaceFIPS");
        public ColumnInfo PlaceName => DefineColumn("PlaceName");
        public ColumnInfo PlaceType => DefineColumn("PlaceType");
        public ColumnInfo County => DefineColumn("County");
        public ColumnInfo FincStat => DefineColumn("FincStat");
        public ColumnInfo FuncStatText => DefineColumn("FuncStatText");
        public ColumnInfo ClassFP => DefineColumn("ClassFP");
        public ColumnInfo GeoID => DefineColumn("GeoID");
        public ColumnInfo PopPT => DefineColumn("PopPT");
        public ColumnInfo HuPT => DefineColumn("HuPT");
        public ColumnInfo AreaPT => DefineColumn("AreaPT");
        public ColumnInfo AreaLandPT => DefineColumn("AreaLandPT");
        public ColumnInfo ZPOP => DefineColumn("ZPOP");
        public ColumnInfo ZHU => DefineColumn("ZHU");
        public ColumnInfo ZArea => DefineColumn("ZArea");
        public ColumnInfo ZAreaLand => DefineColumn("ZAreaLand");
        public ColumnInfo PLPop => DefineColumn("PLPop");
        public ColumnInfo PLHU => DefineColumn("PLHU");
        public ColumnInfo PLArea => DefineColumn("PLArea");
        public ColumnInfo PLAreaLand => DefineColumn("PLAreaLand");
        public ColumnInfo ZPopPCT => DefineColumn("ZPopPCT");
        public ColumnInfo ZHUPCT => DefineColumn("ZHUPCT");
        public ColumnInfo ZAreaPCT => DefineColumn("ZAreaPCT");
        public ColumnInfo ZAreaLandPCT => DefineColumn("ZAreaLandPCT");
        public ColumnInfo PLPOPPCT => DefineColumn("PLPOPPCT");
        public ColumnInfo PLHUPCT => DefineColumn("PLHUPCT");
        public ColumnInfo PLAreaPCT => DefineColumn("PLAreaPCT");
        public ColumnInfo PLAreaLandPCT => DefineColumn("PLAreaLandPCT");
        public ZC_PlaceFIPSMetadata As(string alias) => new ZC_PlaceFIPSMetadata() { DbTableAlias = alias };
    }

    public partial class ZipCodeMetadata : Metadata<ZipCode>
    {
        public override string DbTableName => "ZipCode";
        public override ColumnInfo Oid => DefineColumn("Oid");
        public ColumnInfo lkpCountryOid => DefineColumn("lkpCountryOid");
        public ColumnInfo lkpStateOid => DefineColumn("lkpStateOid");
        public ColumnInfo lkpCountyOid => DefineColumn("lkpCountyOid");
        public ColumnInfo lkpCityOid => DefineColumn("lkpCityOid");
        public ColumnInfo City => DefineColumn("City");
        public ColumnInfo County => DefineColumn("County");
        public ColumnInfo State => DefineColumn("State");
        public ColumnInfo StateFullName => DefineColumn("StateFullName");
        public ColumnInfo Zip => DefineColumn("Zip");
        public ColumnInfo Longitude => DefineColumn("Longitude");
        public ColumnInfo Latitude => DefineColumn("Latitude");
        public ColumnInfo TimeZone => DefineColumn("TimeZone");
        public ColumnInfo IsUnique => DefineColumn("IsUnique");
        public ColumnInfo IsMultipleCounties => DefineColumn("IsMultipleCounties");
        public ColumnInfo CountyList => DefineColumn("CountyList");
        public ZipCodeMetadata As(string alias) => new ZipCodeMetadata() { DbTableAlias = alias };
    }

}
