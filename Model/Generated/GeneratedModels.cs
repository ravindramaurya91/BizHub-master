// AUTO GENERATED - DO NOT MODIFY DIRECTLY

using Base;
using System;
using System.Collections.Generic;
using PetaPoco;

namespace Model {


    [Serializable]
    [TableName("Attachment")]
    [PrimaryKey("Oid")]
    public partial class Attachment : Record<Attachment>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("lkpDocumentTypeOid")]
        public long lkpDocumentTypeOid { get; set; }
        [Column("TargetTable")]
        public string TargetTable { get; set; }
        [Column("TargetOid")]
        public long TargetOid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("DocumentUrl")]
        public string DocumentUrl { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Attachment ShallowClone(){ return (Attachment)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "LKPDOCUMENTTYPEOID":  oReturn = this.lkpDocumentTypeOid; break;
                    case "TARGETTABLE":  oReturn = this.TargetTable; break;
                    case "TARGETOID":  oReturn = this.TargetOid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "DOCUMENTURL":  oReturn = this.DocumentUrl; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "LKPDOCUMENTTYPEOID":  this.lkpDocumentTypeOid = (long)value;  break;
                case "TARGETTABLE":  this.TargetTable = (string)value;  break;
                case "TARGETOID":  this.TargetOid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "DOCUMENTURL":  this.DocumentUrl = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("BrokerCard")]
    [PrimaryKey("Oid")]
    public partial class BrokerCard : Record<BrokerCard>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("Body")]
        public string Body { get; set; }
        [Column("Footer")]
        public string Footer { get; set; }
        [Column("TagLine")]
        public string TagLine { get; set; }
        [Column("IsElite")]
        public bool? IsElite { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public BrokerCard ShallowClone(){ return (BrokerCard)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "BODY":  oReturn = this.Body; break;
                    case "FOOTER":  oReturn = this.Footer; break;
                    case "TAGLINE":  oReturn = this.TagLine; break;
                    case "ISELITE":  oReturn = this.IsElite; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "BODY":  this.Body = (string)value;  break;
                case "FOOTER":  this.Footer = (string)value;  break;
                case "TAGLINE":  this.TagLine = (string)value;  break;
                case "ISELITE":  this.IsElite = (bool?)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Configuration")]
    [PrimaryKey("Oid")]
    public partial class Configuration : Record<Configuration>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Value")]
        public string Value { get; set; }
        [Column("DataType")]
        public string DataType { get; set; }
        [Column("ModuleName")]
        public string ModuleName { get; set; }
        [Column("Description")]
        public string Description { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Configuration ShallowClone(){ return (Configuration)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "VALUE":  oReturn = this.Value; break;
                    case "DATATYPE":  oReturn = this.DataType; break;
                    case "MODULENAME":  oReturn = this.ModuleName; break;
                    case "DESCRIPTION":  oReturn = this.Description; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "VALUE":  this.Value = (string)value;  break;
                case "DATATYPE":  this.DataType = (string)value;  break;
                case "MODULENAME":  this.ModuleName = (string)value;  break;
                case "DESCRIPTION":  this.Description = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("ContactRequest")]
    [PrimaryKey("Oid")]
    public partial class ContactRequest : Record<ContactRequest>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid_ContactTo")]
        public long EntityOid_ContactTo { get; set; }
        [Column("EntityOid_ContactFrom")]
        public long? EntityOid_ContactFrom { get; set; }
        [Column("EntityEmail_To")]
        public string EntityEmail_To { get; set; }
        [Column("EntityEmail_From")]
        public string EntityEmail_From { get; set; }
        [Column("ListingOid")]
        public long? ListingOid { get; set; }
        [Column("ContactDate")]
        public DateTime ContactDate { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        [Column("Zip")]
        public string Zip { get; set; }
        [Column("Message")]
        public string Message { get; set; }
        [Column("Is401KReferral")]
        public bool Is401KReferral { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public ContactRequest ShallowClone(){ return (ContactRequest)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID_CONTACTTO":  oReturn = this.EntityOid_ContactTo; break;
                    case "ENTITYOID_CONTACTFROM":  oReturn = this.EntityOid_ContactFrom; break;
                    case "ENTITYEMAIL_TO":  oReturn = this.EntityEmail_To; break;
                    case "ENTITYEMAIL_FROM":  oReturn = this.EntityEmail_From; break;
                    case "LISTINGOID":  oReturn = this.ListingOid; break;
                    case "CONTACTDATE":  oReturn = this.ContactDate; break;
                    case "FIRSTNAME":  oReturn = this.FirstName; break;
                    case "LASTNAME":  oReturn = this.LastName; break;
                    case "PHONE":  oReturn = this.Phone; break;
                    case "ZIP":  oReturn = this.Zip; break;
                    case "MESSAGE":  oReturn = this.Message; break;
                    case "IS401KREFERRAL":  oReturn = this.Is401KReferral; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID_CONTACTTO":  this.EntityOid_ContactTo = (long)value;  break;
                case "ENTITYOID_CONTACTFROM":  this.EntityOid_ContactFrom = (long?)value;  break;
                case "ENTITYEMAIL_TO":  this.EntityEmail_To = (string)value;  break;
                case "ENTITYEMAIL_FROM":  this.EntityEmail_From = (string)value;  break;
                case "LISTINGOID":  this.ListingOid = (long?)value;  break;
                case "CONTACTDATE":  this.ContactDate = (DateTime)value;  break;
                case "FIRSTNAME":  this.FirstName = (string)value;  break;
                case "LASTNAME":  this.LastName = (string)value;  break;
                case "PHONE":  this.Phone = (string)value;  break;
                case "ZIP":  this.Zip = (string)value;  break;
                case "MESSAGE":  this.Message = (string)value;  break;
                case "IS401KREFERRAL":  this.Is401KReferral = (bool)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("EmailCampaign")]
    [PrimaryKey("Oid")]
    public partial class EmailCampaign : Record<EmailCampaign>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EmailTemplateOid")]
        public long EmailTemplateOid { get; set; }
        [Column("EmailRecipientDefinitionOid")]
        public long EmailRecipientDefinitionOid { get; set; }
        [Column("EntityOid_Master")]
        public long EntityOid_Master { get; set; }
        [Column("EntityOid")]
        public long? EntityOid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("DateLastRun")]
        public DateTime? DateLastRun { get; set; }
        [Column("CreatedOn")]
        public DateTime? CreatedOn { get; set; }
        [Column("CreatedBy")]
        public long? CreatedBy { get; set; }
        [Column("Delivered")]
        public decimal? Delivered { get; set; }
        [Column("UniqueOpens")]
        public decimal? UniqueOpens { get; set; }
        [Column("UniqueClicks")]
        public decimal? UniqueClicks { get; set; }
        [Column("SpamReports")]
        public decimal? SpamReports { get; set; }
        [Column("Bounces")]
        public decimal? Bounces { get; set; }
        [Column("Unsubscribed")]
        public decimal? Unsubscribed { get; set; }
        [Column("RecipientCount")]
        public int? RecipientCount { get; set; }
        [Column("EstimatedCost")]
        public decimal? EstimatedCost { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public EmailCampaign ShallowClone(){ return (EmailCampaign)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "EMAILTEMPLATEOID":  oReturn = this.EmailTemplateOid; break;
                    case "EMAILRECIPIENTDEFINITIONOID":  oReturn = this.EmailRecipientDefinitionOid; break;
                    case "ENTITYOID_MASTER":  oReturn = this.EntityOid_Master; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "DESCRIPTION":  oReturn = this.Description; break;
                    case "DATELASTRUN":  oReturn = this.DateLastRun; break;
                    case "CREATEDON":  oReturn = this.CreatedOn; break;
                    case "CREATEDBY":  oReturn = this.CreatedBy; break;
                    case "DELIVERED":  oReturn = this.Delivered; break;
                    case "UNIQUEOPENS":  oReturn = this.UniqueOpens; break;
                    case "UNIQUECLICKS":  oReturn = this.UniqueClicks; break;
                    case "SPAMREPORTS":  oReturn = this.SpamReports; break;
                    case "BOUNCES":  oReturn = this.Bounces; break;
                    case "UNSUBSCRIBED":  oReturn = this.Unsubscribed; break;
                    case "RECIPIENTCOUNT":  oReturn = this.RecipientCount; break;
                    case "ESTIMATEDCOST":  oReturn = this.EstimatedCost; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "EMAILTEMPLATEOID":  this.EmailTemplateOid = (long)value;  break;
                case "EMAILRECIPIENTDEFINITIONOID":  this.EmailRecipientDefinitionOid = (long)value;  break;
                case "ENTITYOID_MASTER":  this.EntityOid_Master = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long?)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "DESCRIPTION":  this.Description = (string)value;  break;
                case "DATELASTRUN":  this.DateLastRun = (DateTime?)value;  break;
                case "CREATEDON":  this.CreatedOn = (DateTime?)value;  break;
                case "CREATEDBY":  this.CreatedBy = (long?)value;  break;
                case "DELIVERED":  this.Delivered = (decimal?)value;  break;
                case "UNIQUEOPENS":  this.UniqueOpens = (decimal?)value;  break;
                case "UNIQUECLICKS":  this.UniqueClicks = (decimal?)value;  break;
                case "SPAMREPORTS":  this.SpamReports = (decimal?)value;  break;
                case "BOUNCES":  this.Bounces = (decimal?)value;  break;
                case "UNSUBSCRIBED":  this.Unsubscribed = (decimal?)value;  break;
                case "RECIPIENTCOUNT":  this.RecipientCount = (int?)value;  break;
                case "ESTIMATEDCOST":  this.EstimatedCost = (decimal?)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("EmailCampaignRun")]
    [PrimaryKey("Oid")]
    public partial class EmailCampaignRun : Record<EmailCampaignRun>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EmailCampaignOid")]
        public long EmailCampaignOid { get; set; }
        [Column("EntityOid_ApprovedBy")]
        public long? EntityOid_ApprovedBy { get; set; }
        [Column("RecipientCount")]
        public int? RecipientCount { get; set; }
        [Column("NumberSent")]
        public int? NumberSent { get; set; }
        [Column("EstimatedCost")]
        public decimal? EstimatedCost { get; set; }
        [Column("TargetRunDate")]
        public DateTime TargetRunDate { get; set; }
        [Column("RunDate")]
        public DateTime? RunDate { get; set; }
        [Column("ApprovalDate")]
        public DateTime? ApprovalDate { get; set; }
        [Column("Delivered")]
        public decimal? Delivered { get; set; }
        [Column("UniqueOpens")]
        public decimal? UniqueOpens { get; set; }
        [Column("UniqueClicks")]
        public decimal? UniqueClicks { get; set; }
        [Column("SpamReports")]
        public decimal? SpamReports { get; set; }
        [Column("Bounces")]
        public decimal? Bounces { get; set; }
        [Column("Unsubscribed")]
        public decimal? Unsubscribed { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public EmailCampaignRun ShallowClone(){ return (EmailCampaignRun)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "EMAILCAMPAIGNOID":  oReturn = this.EmailCampaignOid; break;
                    case "ENTITYOID_APPROVEDBY":  oReturn = this.EntityOid_ApprovedBy; break;
                    case "RECIPIENTCOUNT":  oReturn = this.RecipientCount; break;
                    case "NUMBERSENT":  oReturn = this.NumberSent; break;
                    case "ESTIMATEDCOST":  oReturn = this.EstimatedCost; break;
                    case "TARGETRUNDATE":  oReturn = this.TargetRunDate; break;
                    case "RUNDATE":  oReturn = this.RunDate; break;
                    case "APPROVALDATE":  oReturn = this.ApprovalDate; break;
                    case "DELIVERED":  oReturn = this.Delivered; break;
                    case "UNIQUEOPENS":  oReturn = this.UniqueOpens; break;
                    case "UNIQUECLICKS":  oReturn = this.UniqueClicks; break;
                    case "SPAMREPORTS":  oReturn = this.SpamReports; break;
                    case "BOUNCES":  oReturn = this.Bounces; break;
                    case "UNSUBSCRIBED":  oReturn = this.Unsubscribed; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "EMAILCAMPAIGNOID":  this.EmailCampaignOid = (long)value;  break;
                case "ENTITYOID_APPROVEDBY":  this.EntityOid_ApprovedBy = (long?)value;  break;
                case "RECIPIENTCOUNT":  this.RecipientCount = (int?)value;  break;
                case "NUMBERSENT":  this.NumberSent = (int?)value;  break;
                case "ESTIMATEDCOST":  this.EstimatedCost = (decimal?)value;  break;
                case "TARGETRUNDATE":  this.TargetRunDate = (DateTime)value;  break;
                case "RUNDATE":  this.RunDate = (DateTime?)value;  break;
                case "APPROVALDATE":  this.ApprovalDate = (DateTime?)value;  break;
                case "DELIVERED":  this.Delivered = (decimal?)value;  break;
                case "UNIQUEOPENS":  this.UniqueOpens = (decimal?)value;  break;
                case "UNIQUECLICKS":  this.UniqueClicks = (decimal?)value;  break;
                case "SPAMREPORTS":  this.SpamReports = (decimal?)value;  break;
                case "BOUNCES":  this.Bounces = (decimal?)value;  break;
                case "UNSUBSCRIBED":  this.Unsubscribed = (decimal?)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("EmailRecipientDefinition")]
    [PrimaryKey("Oid")]
    public partial class EmailRecipientDefinition : Record<EmailRecipientDefinition>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("SearchCriteriaOid")]
        public long? SearchCriteriaOid { get; set; }
        [Column("lkpRecipientListTypeOid")]
        public long lkpRecipientListTypeOid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public EmailRecipientDefinition ShallowClone(){ return (EmailRecipientDefinition)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "SEARCHCRITERIAOID":  oReturn = this.SearchCriteriaOid; break;
                    case "LKPRECIPIENTLISTTYPEOID":  oReturn = this.lkpRecipientListTypeOid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "SEARCHCRITERIAOID":  this.SearchCriteriaOid = (long?)value;  break;
                case "LKPRECIPIENTLISTTYPEOID":  this.lkpRecipientListTypeOid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("EmailTemplate")]
    [PrimaryKey("Oid")]
    public partial class EmailTemplate : Record<EmailTemplate>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid_Master")]
        public long? EntityOid_Master { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("LkpTemplateCategoryOid")]
        public long? LkpTemplateCategoryOid { get; set; }
        [Column("HyperText")]
        public string HyperText { get; set; }
        [Column("DateLastUpdated")]
        public DateTime? DateLastUpdated { get; set; }
        [Column("CreatedOn")]
        public DateTime? CreatedOn { get; set; }
        [Column("CreatedBy")]
        public long? CreatedBy { get; set; }
        [Column("Delivered")]
        public decimal? Delivered { get; set; }
        [Column("UniqueOpens")]
        public decimal? UniqueOpens { get; set; }
        [Column("UniqueClicks")]
        public decimal? UniqueClicks { get; set; }
        [Column("SpamReports")]
        public decimal? SpamReports { get; set; }
        [Column("Bounces")]
        public decimal? Bounces { get; set; }
        [Column("Unsubscribed")]
        public decimal? Unsubscribed { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public EmailTemplate ShallowClone(){ return (EmailTemplate)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID_MASTER":  oReturn = this.EntityOid_Master; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "DESCRIPTION":  oReturn = this.Description; break;
                    case "LKPTEMPLATECATEGORYOID":  oReturn = this.LkpTemplateCategoryOid; break;
                    case "HYPERTEXT":  oReturn = this.HyperText; break;
                    case "DATELASTUPDATED":  oReturn = this.DateLastUpdated; break;
                    case "CREATEDON":  oReturn = this.CreatedOn; break;
                    case "CREATEDBY":  oReturn = this.CreatedBy; break;
                    case "DELIVERED":  oReturn = this.Delivered; break;
                    case "UNIQUEOPENS":  oReturn = this.UniqueOpens; break;
                    case "UNIQUECLICKS":  oReturn = this.UniqueClicks; break;
                    case "SPAMREPORTS":  oReturn = this.SpamReports; break;
                    case "BOUNCES":  oReturn = this.Bounces; break;
                    case "UNSUBSCRIBED":  oReturn = this.Unsubscribed; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID_MASTER":  this.EntityOid_Master = (long?)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "DESCRIPTION":  this.Description = (string)value;  break;
                case "LKPTEMPLATECATEGORYOID":  this.LkpTemplateCategoryOid = (long?)value;  break;
                case "HYPERTEXT":  this.HyperText = (string)value;  break;
                case "DATELASTUPDATED":  this.DateLastUpdated = (DateTime?)value;  break;
                case "CREATEDON":  this.CreatedOn = (DateTime?)value;  break;
                case "CREATEDBY":  this.CreatedBy = (long?)value;  break;
                case "DELIVERED":  this.Delivered = (decimal?)value;  break;
                case "UNIQUEOPENS":  this.UniqueOpens = (decimal?)value;  break;
                case "UNIQUECLICKS":  this.UniqueClicks = (decimal?)value;  break;
                case "SPAMREPORTS":  this.SpamReports = (decimal?)value;  break;
                case "BOUNCES":  this.Bounces = (decimal?)value;  break;
                case "UNSUBSCRIBED":  this.Unsubscribed = (decimal?)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Entity")]
    [PrimaryKey("Oid")]
    public partial class Entity : Record<Entity>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid_Master")]
        public long EntityOid_Master { get; set; }
        [Column("EntityOid_Region")]
        public long? EntityOid_Region { get; set; }
        [Column("EntityOid_Office")]
        public long? EntityOid_Office { get; set; }
        [Column("EntityOid_ReferredBy")]
        public long? EntityOid_ReferredBy { get; set; }
        [Column("lkpEntityTypeOid")]
        public long? lkpEntityTypeOid { get; set; }
        [Column("lkpUserTypeOid")]
        public long? lkpUserTypeOid { get; set; }
        [Column("lkpLegalEntityOid")]
        public long? lkpLegalEntityOid { get; set; }
        [Column("lkpTimeZoneOid")]
        public long? lkpTimeZoneOid { get; set; }
        [Column("lkpCountryOid")]
        public long? lkpCountryOid { get; set; }
        [Column("lkpStateOid")]
        public long? lkpStateOid { get; set; }
        [Column("lkpGenderOid")]
        public long? lkpGenderOid { get; set; }
        [Column("lkpProspectTypeOid")]
        public long? lkpProspectTypeOid { get; set; }
        [Column("lkpBusinessCategoryOids")]
        public string lkpBusinessCategoryOids { get; set; }
        [Column("lkpStateOids_Servicing")]
        public string lkpStateOids_Servicing { get; set; }
        [Column("DefaultSearchCriteriaOid")]
        public long? DefaultSearchCriteriaOid { get; set; }
        [Column("CompanyName")]
        public string CompanyName { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("DisplayName")]
        public string DisplayName { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("FaxNumber")]
        public string FaxNumber { get; set; }
        [Column("StartDate")]
        public DateTime StartDate { get; set; }
        [Column("DOB")]
        public DateTime? DOB { get; set; }
        [Column("Avatar")]
        public string Avatar { get; set; }
        [Column("BannerImage")]
        public string BannerImage { get; set; }
        [Column("AboutMe")]
        public string AboutMe { get; set; }
        [Column("ListingCount")]
        public int? ListingCount { get; set; }
        [Column("NumberOfEmployees")]
        public int? NumberOfEmployees { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("IsElite")]
        public bool? IsElite { get; set; }
        [Column("EmailOptOut")]
        public bool? EmailOptOut { get; set; }
        [Column("HasMultipleRegions")]
        public bool? HasMultipleRegions { get; set; }
        [Column("HasMultipleOffices")]
        public bool? HasMultipleOffices { get; set; }
        [Column("Address1")]
        public string Address1 { get; set; }
        [Column("Address2")]
        public string Address2 { get; set; }
        [Column("AreasServed")]
        public string AreasServed { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("LicensedIn")]
        public string LicensedIn { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("Zip")]
        public string Zip { get; set; }
        [Column("Country")]
        public string Country { get; set; }
        [Column("Preferences")]
        public string Preferences { get; set; }
        [Column("CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [Column("CreatedBy")]
        public string CreatedBy { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Entity ShallowClone(){ return (Entity)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID_MASTER":  oReturn = this.EntityOid_Master; break;
                    case "ENTITYOID_REGION":  oReturn = this.EntityOid_Region; break;
                    case "ENTITYOID_OFFICE":  oReturn = this.EntityOid_Office; break;
                    case "ENTITYOID_REFERREDBY":  oReturn = this.EntityOid_ReferredBy; break;
                    case "LKPENTITYTYPEOID":  oReturn = this.lkpEntityTypeOid; break;
                    case "LKPUSERTYPEOID":  oReturn = this.lkpUserTypeOid; break;
                    case "LKPLEGALENTITYOID":  oReturn = this.lkpLegalEntityOid; break;
                    case "LKPTIMEZONEOID":  oReturn = this.lkpTimeZoneOid; break;
                    case "LKPCOUNTRYOID":  oReturn = this.lkpCountryOid; break;
                    case "LKPSTATEOID":  oReturn = this.lkpStateOid; break;
                    case "LKPGENDEROID":  oReturn = this.lkpGenderOid; break;
                    case "LKPPROSPECTTYPEOID":  oReturn = this.lkpProspectTypeOid; break;
                    case "LKPBUSINESSCATEGORYOIDS":  oReturn = this.lkpBusinessCategoryOids; break;
                    case "LKPSTATEOIDS_SERVICING":  oReturn = this.lkpStateOids_Servicing; break;
                    case "DEFAULTSEARCHCRITERIAOID":  oReturn = this.DefaultSearchCriteriaOid; break;
                    case "COMPANYNAME":  oReturn = this.CompanyName; break;
                    case "FIRSTNAME":  oReturn = this.FirstName; break;
                    case "LASTNAME":  oReturn = this.LastName; break;
                    case "DISPLAYNAME":  oReturn = this.DisplayName; break;
                    case "TITLE":  oReturn = this.Title; break;
                    case "PHONE":  oReturn = this.Phone; break;
                    case "EMAIL":  oReturn = this.Email; break;
                    case "FAXNUMBER":  oReturn = this.FaxNumber; break;
                    case "STARTDATE":  oReturn = this.StartDate; break;
                    case "DOB":  oReturn = this.DOB; break;
                    case "AVATAR":  oReturn = this.Avatar; break;
                    case "BANNERIMAGE":  oReturn = this.BannerImage; break;
                    case "ABOUTME":  oReturn = this.AboutMe; break;
                    case "LISTINGCOUNT":  oReturn = this.ListingCount; break;
                    case "NUMBEROFEMPLOYEES":  oReturn = this.NumberOfEmployees; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                    case "ISELITE":  oReturn = this.IsElite; break;
                    case "EMAILOPTOUT":  oReturn = this.EmailOptOut; break;
                    case "HASMULTIPLEREGIONS":  oReturn = this.HasMultipleRegions; break;
                    case "HASMULTIPLEOFFICES":  oReturn = this.HasMultipleOffices; break;
                    case "ADDRESS1":  oReturn = this.Address1; break;
                    case "ADDRESS2":  oReturn = this.Address2; break;
                    case "AREASSERVED":  oReturn = this.AreasServed; break;
                    case "CITY":  oReturn = this.City; break;
                    case "LICENSEDIN":  oReturn = this.LicensedIn; break;
                    case "STATE":  oReturn = this.State; break;
                    case "ZIP":  oReturn = this.Zip; break;
                    case "COUNTRY":  oReturn = this.Country; break;
                    case "PREFERENCES":  oReturn = this.Preferences; break;
                    case "CREATEDON":  oReturn = this.CreatedOn; break;
                    case "CREATEDBY":  oReturn = this.CreatedBy; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID_MASTER":  this.EntityOid_Master = (long)value;  break;
                case "ENTITYOID_REGION":  this.EntityOid_Region = (long?)value;  break;
                case "ENTITYOID_OFFICE":  this.EntityOid_Office = (long?)value;  break;
                case "ENTITYOID_REFERREDBY":  this.EntityOid_ReferredBy = (long?)value;  break;
                case "LKPENTITYTYPEOID":  this.lkpEntityTypeOid = (long?)value;  break;
                case "LKPUSERTYPEOID":  this.lkpUserTypeOid = (long?)value;  break;
                case "LKPLEGALENTITYOID":  this.lkpLegalEntityOid = (long?)value;  break;
                case "LKPTIMEZONEOID":  this.lkpTimeZoneOid = (long?)value;  break;
                case "LKPCOUNTRYOID":  this.lkpCountryOid = (long?)value;  break;
                case "LKPSTATEOID":  this.lkpStateOid = (long?)value;  break;
                case "LKPGENDEROID":  this.lkpGenderOid = (long?)value;  break;
                case "LKPPROSPECTTYPEOID":  this.lkpProspectTypeOid = (long?)value;  break;
                case "LKPBUSINESSCATEGORYOIDS":  this.lkpBusinessCategoryOids = (string)value;  break;
                case "LKPSTATEOIDS_SERVICING":  this.lkpStateOids_Servicing = (string)value;  break;
                case "DEFAULTSEARCHCRITERIAOID":  this.DefaultSearchCriteriaOid = (long?)value;  break;
                case "COMPANYNAME":  this.CompanyName = (string)value;  break;
                case "FIRSTNAME":  this.FirstName = (string)value;  break;
                case "LASTNAME":  this.LastName = (string)value;  break;
                case "DISPLAYNAME":  this.DisplayName = (string)value;  break;
                case "TITLE":  this.Title = (string)value;  break;
                case "PHONE":  this.Phone = (string)value;  break;
                case "EMAIL":  this.Email = (string)value;  break;
                case "FAXNUMBER":  this.FaxNumber = (string)value;  break;
                case "STARTDATE":  this.StartDate = (DateTime)value;  break;
                case "DOB":  this.DOB = (DateTime?)value;  break;
                case "AVATAR":  this.Avatar = (string)value;  break;
                case "BANNERIMAGE":  this.BannerImage = (string)value;  break;
                case "ABOUTME":  this.AboutMe = (string)value;  break;
                case "LISTINGCOUNT":  this.ListingCount = (int?)value;  break;
                case "NUMBEROFEMPLOYEES":  this.NumberOfEmployees = (int?)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                case "ISELITE":  this.IsElite = (bool?)value;  break;
                case "EMAILOPTOUT":  this.EmailOptOut = (bool?)value;  break;
                case "HASMULTIPLEREGIONS":  this.HasMultipleRegions = (bool?)value;  break;
                case "HASMULTIPLEOFFICES":  this.HasMultipleOffices = (bool?)value;  break;
                case "ADDRESS1":  this.Address1 = (string)value;  break;
                case "ADDRESS2":  this.Address2 = (string)value;  break;
                case "AREASSERVED":  this.AreasServed = (string)value;  break;
                case "CITY":  this.City = (string)value;  break;
                case "LICENSEDIN":  this.LicensedIn = (string)value;  break;
                case "STATE":  this.State = (string)value;  break;
                case "ZIP":  this.Zip = (string)value;  break;
                case "COUNTRY":  this.Country = (string)value;  break;
                case "PREFERENCES":  this.Preferences = (string)value;  break;
                case "CREATEDON":  this.CreatedOn = (DateTime)value;  break;
                case "CREATEDBY":  this.CreatedBy = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Entity2EntityMap_Contact")]
    [PrimaryKey("Oid")]
    public partial class Entity2EntityMap_Contact : Record<Entity2EntityMap_Contact>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid_From")]
        public long EntityOid_From { get; set; }
        [Column("EntityOid_To")]
        public long EntityOid_To { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Entity2EntityMap_Contact ShallowClone(){ return (Entity2EntityMap_Contact)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID_FROM":  oReturn = this.EntityOid_From; break;
                    case "ENTITYOID_TO":  oReturn = this.EntityOid_To; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID_FROM":  this.EntityOid_From = (long)value;  break;
                case "ENTITYOID_TO":  this.EntityOid_To = (long)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Entity2ListingMap_Participant")]
    [PrimaryKey("Oid")]
    public partial class Entity2ListingMap_Participant : Record<Entity2ListingMap_Participant>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("ListingOid")]
        public long ListingOid { get; set; }
        [Column("lkpListingRoleOid")]
        public long lkpListingRoleOid { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Entity2ListingMap_Participant ShallowClone(){ return (Entity2ListingMap_Participant)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "LISTINGOID":  oReturn = this.ListingOid; break;
                    case "LKPLISTINGROLEOID":  oReturn = this.lkpListingRoleOid; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "LISTINGOID":  this.ListingOid = (long)value;  break;
                case "LKPLISTINGROLEOID":  this.lkpListingRoleOid = (long)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Entity2ListingMap_Stat")]
    [PrimaryKey("Oid")]
    public partial class Entity2ListingMap_Stat : Record<Entity2ListingMap_Stat>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("ListingOid")]
        public long ListingOid { get; set; }
        [Column("DateFavorited")]
        public DateTime? DateFavorited { get; set; }
        [Column("IsNotifyOnPriceChange_Text")]
        public bool? IsNotifyOnPriceChange_Text { get; set; }
        [Column("IsNotifyOnPriceChange_Email")]
        public bool? IsNotifyOnPriceChange_Email { get; set; }
        [Column("IsSeen")]
        public bool? IsSeen { get; set; }
        [Column("IsVisited")]
        public bool? IsVisited { get; set; }
        [Column("IsFavorite")]
        public bool? IsFavorite { get; set; }
        [Column("IsContacted")]
        public bool? IsContacted { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Entity2ListingMap_Stat ShallowClone(){ return (Entity2ListingMap_Stat)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "LISTINGOID":  oReturn = this.ListingOid; break;
                    case "DATEFAVORITED":  oReturn = this.DateFavorited; break;
                    case "ISNOTIFYONPRICECHANGE_TEXT":  oReturn = this.IsNotifyOnPriceChange_Text; break;
                    case "ISNOTIFYONPRICECHANGE_EMAIL":  oReturn = this.IsNotifyOnPriceChange_Email; break;
                    case "ISSEEN":  oReturn = this.IsSeen; break;
                    case "ISVISITED":  oReturn = this.IsVisited; break;
                    case "ISFAVORITE":  oReturn = this.IsFavorite; break;
                    case "ISCONTACTED":  oReturn = this.IsContacted; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "LISTINGOID":  this.ListingOid = (long)value;  break;
                case "DATEFAVORITED":  this.DateFavorited = (DateTime?)value;  break;
                case "ISNOTIFYONPRICECHANGE_TEXT":  this.IsNotifyOnPriceChange_Text = (bool?)value;  break;
                case "ISNOTIFYONPRICECHANGE_EMAIL":  this.IsNotifyOnPriceChange_Email = (bool?)value;  break;
                case "ISSEEN":  this.IsSeen = (bool?)value;  break;
                case "ISVISITED":  this.IsVisited = (bool?)value;  break;
                case "ISFAVORITE":  this.IsFavorite = (bool?)value;  break;
                case "ISCONTACTED":  this.IsContacted = (bool?)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Entity2LookupMap")]
    [PrimaryKey("Oid")]
    public partial class Entity2LookupMap : Record<Entity2LookupMap>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("LookupOid")]
        public long LookupOid { get; set; }
        [Column("LookupName")]
        public string LookupName { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Entity2LookupMap ShallowClone(){ return (Entity2LookupMap)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "LOOKUPOID":  oReturn = this.LookupOid; break;
                    case "LOOKUPNAME":  oReturn = this.LookupName; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "LOOKUPOID":  this.LookupOid = (long)value;  break;
                case "LOOKUPNAME":  this.LookupName = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("EntityAttribute")]
    [PrimaryKey("Oid")]
    public partial class EntityAttribute : Record<EntityAttribute>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ParentOid")]
        public long? ParentOid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("lkpAttributeTypeOid")]
        public long lkpAttributeTypeOid { get; set; }
        [Column("Text")]
        public string Text { get; set; }
        [Column("Text2")]
        public string Text2 { get; set; }
        [Column("HasChildren")]
        public bool HasChildren { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public EntityAttribute ShallowClone(){ return (EntityAttribute)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "PARENTOID":  oReturn = this.ParentOid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "LKPATTRIBUTETYPEOID":  oReturn = this.lkpAttributeTypeOid; break;
                    case "TEXT":  oReturn = this.Text; break;
                    case "TEXT2":  oReturn = this.Text2; break;
                    case "HASCHILDREN":  oReturn = this.HasChildren; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "PARENTOID":  this.ParentOid = (long?)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "LKPATTRIBUTETYPEOID":  this.lkpAttributeTypeOid = (long)value;  break;
                case "TEXT":  this.Text = (string)value;  break;
                case "TEXT2":  this.Text2 = (string)value;  break;
                case "HASCHILDREN":  this.HasChildren = (bool)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Ingredient")]
    [PrimaryKey("Oid")]
    public partial class Ingredient : Record<Ingredient>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("RecipeOid")]
        public long RecipeOid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Amount")]
        public string Amount { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Ingredient ShallowClone(){ return (Ingredient)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "RECIPEOID":  oReturn = this.RecipeOid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "AMOUNT":  oReturn = this.Amount; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "RECIPEOID":  this.RecipeOid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "AMOUNT":  this.Amount = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("InterfaceHost")]
    [PrimaryKey("Oid")]
    public partial class InterfaceHost : Record<InterfaceHost>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public InterfaceHost ShallowClone(){ return (InterfaceHost)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "NAME":  oReturn = this.Name; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("InterfaceIdentityMap")]
    [PrimaryKey("Oid")]
    public partial class InterfaceIdentityMap : Record<InterfaceIdentityMap>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("InterfaceHostOid")]
        public long InterfaceHostOid { get; set; }
        [Column("TargetTable")]
        public string TargetTable { get; set; }
        [Column("TargetOid")]
        public long TargetOid { get; set; }
        [Column("ExternalId")]
        public string ExternalId { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public InterfaceIdentityMap ShallowClone(){ return (InterfaceIdentityMap)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "INTERFACEHOSTOID":  oReturn = this.InterfaceHostOid; break;
                    case "TARGETTABLE":  oReturn = this.TargetTable; break;
                    case "TARGETOID":  oReturn = this.TargetOid; break;
                    case "EXTERNALID":  oReturn = this.ExternalId; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "INTERFACEHOSTOID":  this.InterfaceHostOid = (long)value;  break;
                case "TARGETTABLE":  this.TargetTable = (string)value;  break;
                case "TARGETOID":  this.TargetOid = (long)value;  break;
                case "EXTERNALID":  this.ExternalId = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Listing")]
    [PrimaryKey("Oid")]
    public partial class Listing : Record<Listing>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("EntityOid_BillingAuthority")]
        public long EntityOid_BillingAuthority { get; set; }
        [Column("lkpBusinessCategoryOids")]
        public string lkpBusinessCategoryOids { get; set; }
        [Column("lkpListingSetupStatusOid")]
        public long? lkpListingSetupStatusOid { get; set; }
        [Column("lkpCountryOid")]
        public long? lkpCountryOid { get; set; }
        [Column("lkpStateOid")]
        public long? lkpStateOid { get; set; }
        [Column("lkpCountyOid")]
        public long? lkpCountyOid { get; set; }
        [Column("lkpCityOid")]
        public long? lkpCityOid { get; set; }
        [Column("lkpLegalEntityTypeOid")]
        public long? lkpLegalEntityTypeOid { get; set; }
        [Column("lkpCommissionTypeOid")]
        public long? lkpCommissionTypeOid { get; set; }
        [Column("lkpListingCloseStatusOid")]
        public long? lkpListingCloseStatusOid { get; set; }
        [Column("ExternalId")]
        public string ExternalId { get; set; }
        [Column("ExternalSystem")]
        public string ExternalSystem { get; set; }
        [Column("ContactName")]
        public string ContactName { get; set; }
        [Column("ContactEmail")]
        public string ContactEmail { get; set; }
        [Column("ContactPhone")]
        public string ContactPhone { get; set; }
        [Column("CompanyName")]
        public string CompanyName { get; set; }
        [Column("CompanyPhone")]
        public string CompanyPhone { get; set; }
        [Column("GeneralLocation")]
        public string GeneralLocation { get; set; }
        [Column("SellerName")]
        public string SellerName { get; set; }
        [Column("HoursOfOperation")]
        public string HoursOfOperation { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("Address2")]
        public string Address2 { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("County")]
        public string County { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("Zip")]
        public string Zip { get; set; }
        [Column("Keywords")]
        public string Keywords { get; set; }
        [Column("AdTitle")]
        public string AdTitle { get; set; }
        [Column("AdTagLine")]
        public string AdTagLine { get; set; }
        [Column("AdDescription")]
        public string AdDescription { get; set; }
        [Column("AdBusinessHistory")]
        public string AdBusinessHistory { get; set; }
        [Column("AdCompetitiveAnalysis")]
        public string AdCompetitiveAnalysis { get; set; }
        [Column("AdOpportunityForGrowth")]
        public string AdOpportunityForGrowth { get; set; }
        [Column("AdReasonForSelling")]
        public string AdReasonForSelling { get; set; }
        [Column("AdFacilityDescription")]
        public string AdFacilityDescription { get; set; }
        [Column("AdSupportAndTraining")]
        public string AdSupportAndTraining { get; set; }
        [Column("AdPhoto")]
        public string AdPhoto { get; set; }
        [Column("ListingPrice")]
        public decimal? ListingPrice { get; set; }
        [Column("GrossRevenue")]
        public decimal? GrossRevenue { get; set; }
        [Column("COGs")]
        public decimal? COGs { get; set; }
        [Column("EBITDA")]
        public decimal? EBITDA { get; set; }
        [Column("AccountsReceivable")]
        public decimal? AccountsReceivable { get; set; }
        [Column("Inventory")]
        public decimal? Inventory { get; set; }
        [Column("CashFlow")]
        public decimal? CashFlow { get; set; }
        [Column("FFandE")]
        public decimal? FFandE { get; set; }
        [Column("RealEstateValue")]
        public decimal? RealEstateValue { get; set; }
        [Column("RealEstateAskingPrice")]
        public decimal? RealEstateAskingPrice { get; set; }
        [Column("MinimumDownPayment")]
        public decimal? MinimumDownPayment { get; set; }
        [Column("SellerFinanceUpTo")]
        public decimal? SellerFinanceUpTo { get; set; }
        [Column("Rent")]
        public decimal? Rent { get; set; }
        [Column("RequestedDownPayment")]
        public decimal? RequestedDownPayment { get; set; }
        [Column("CommissionRate")]
        public decimal? CommissionRate { get; set; }
        [Column("CommissionMinimum")]
        public decimal? CommissionMinimum { get; set; }
        [Column("TotalSqFt")]
        public int? TotalSqFt { get; set; }
        [Column("OccupiedSqFt")]
        public int? OccupiedSqFt { get; set; }
        [Column("FacilityOwned_Int")]
        public int? FacilityOwned_Int { get; set; }
        [Column("RealEstateIncluded_Int")]
        public int? RealEstateIncluded_Int { get; set; }
        [Column("ShowCounty_Int")]
        public int? ShowCounty_Int { get; set; }
        [Column("ShowCity_Int")]
        public int? ShowCity_Int { get; set; }
        [Column("ShowZip_Int")]
        public int? ShowZip_Int { get; set; }
        [Column("ShowGrossRevenues_Int")]
        public int? ShowGrossRevenues_Int { get; set; }
        [Column("ShowCashFlow_Int")]
        public int? ShowCashFlow_Int { get; set; }
        [Column("ShowEBITDA_Int")]
        public int? ShowEBITDA_Int { get; set; }
        [Column("ShowInventory_Int")]
        public int? ShowInventory_Int { get; set; }
        [Column("ShowFFE_Int")]
        public int? ShowFFE_Int { get; set; }
        [Column("ShowCompanyWebsite_Int")]
        public int? ShowCompanyWebsite_Int { get; set; }
        [Column("ShowNumberOfEmployees_Int")]
        public int? ShowNumberOfEmployees_Int { get; set; }
        [Column("ShowYearEstablished_Int")]
        public int? ShowYearEstablished_Int { get; set; }
        [Column("BuildingCount")]
        public int? BuildingCount { get; set; }
        [Column("EmployeeCount")]
        public int? EmployeeCount { get; set; }
        [Column("BuyerCount")]
        public int? BuyerCount { get; set; }
        [Column("IsRealEstateInPrice")]
        public bool? IsRealEstateInPrice { get; set; }
        [Column("IsAbsenteeOwner")]
        public bool? IsAbsenteeOwner { get; set; }
        [Column("IsHomeBased")]
        public bool? IsHomeBased { get; set; }
        [Column("IsRelocatable")]
        public bool? IsRelocatable { get; set; }
        [Column("IsFranchise")]
        public bool? IsFranchise { get; set; }
        [Column("IsSellerFinanace")]
        public bool? IsSellerFinanace { get; set; }
        [Column("IsSbaPreApproved")]
        public bool? IsSbaPreApproved { get; set; }
        [Column("IsInventoryIncluded")]
        public bool? IsInventoryIncluded { get; set; }
        [Column("IsAccountsReceivableIncluded")]
        public bool? IsAccountsReceivableIncluded { get; set; }
        [Column("WebsiteURL")]
        public string WebsiteURL { get; set; }
        [Column("YearEstablished")]
        public string YearEstablished { get; set; }
        [Column("ListingDate")]
        public DateTime ListingDate { get; set; }
        [Column("CloseDate")]
        public DateTime? CloseDate { get; set; }
        [Column("ExpirationDate")]
        public DateTime? ExpirationDate { get; set; }
        [Column("CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("IsPending")]
        public bool IsPending { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Listing ShallowClone(){ return (Listing)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "ENTITYOID_BILLINGAUTHORITY":  oReturn = this.EntityOid_BillingAuthority; break;
                    case "LKPBUSINESSCATEGORYOIDS":  oReturn = this.lkpBusinessCategoryOids; break;
                    case "LKPLISTINGSETUPSTATUSOID":  oReturn = this.lkpListingSetupStatusOid; break;
                    case "LKPCOUNTRYOID":  oReturn = this.lkpCountryOid; break;
                    case "LKPSTATEOID":  oReturn = this.lkpStateOid; break;
                    case "LKPCOUNTYOID":  oReturn = this.lkpCountyOid; break;
                    case "LKPCITYOID":  oReturn = this.lkpCityOid; break;
                    case "LKPLEGALENTITYTYPEOID":  oReturn = this.lkpLegalEntityTypeOid; break;
                    case "LKPCOMMISSIONTYPEOID":  oReturn = this.lkpCommissionTypeOid; break;
                    case "LKPLISTINGCLOSESTATUSOID":  oReturn = this.lkpListingCloseStatusOid; break;
                    case "EXTERNALID":  oReturn = this.ExternalId; break;
                    case "EXTERNALSYSTEM":  oReturn = this.ExternalSystem; break;
                    case "CONTACTNAME":  oReturn = this.ContactName; break;
                    case "CONTACTEMAIL":  oReturn = this.ContactEmail; break;
                    case "CONTACTPHONE":  oReturn = this.ContactPhone; break;
                    case "COMPANYNAME":  oReturn = this.CompanyName; break;
                    case "COMPANYPHONE":  oReturn = this.CompanyPhone; break;
                    case "GENERALLOCATION":  oReturn = this.GeneralLocation; break;
                    case "SELLERNAME":  oReturn = this.SellerName; break;
                    case "HOURSOFOPERATION":  oReturn = this.HoursOfOperation; break;
                    case "ADDRESS":  oReturn = this.Address; break;
                    case "ADDRESS2":  oReturn = this.Address2; break;
                    case "CITY":  oReturn = this.City; break;
                    case "COUNTY":  oReturn = this.County; break;
                    case "STATE":  oReturn = this.State; break;
                    case "ZIP":  oReturn = this.Zip; break;
                    case "KEYWORDS":  oReturn = this.Keywords; break;
                    case "ADTITLE":  oReturn = this.AdTitle; break;
                    case "ADTAGLINE":  oReturn = this.AdTagLine; break;
                    case "ADDESCRIPTION":  oReturn = this.AdDescription; break;
                    case "ADBUSINESSHISTORY":  oReturn = this.AdBusinessHistory; break;
                    case "ADCOMPETITIVEANALYSIS":  oReturn = this.AdCompetitiveAnalysis; break;
                    case "ADOPPORTUNITYFORGROWTH":  oReturn = this.AdOpportunityForGrowth; break;
                    case "ADREASONFORSELLING":  oReturn = this.AdReasonForSelling; break;
                    case "ADFACILITYDESCRIPTION":  oReturn = this.AdFacilityDescription; break;
                    case "ADSUPPORTANDTRAINING":  oReturn = this.AdSupportAndTraining; break;
                    case "ADPHOTO":  oReturn = this.AdPhoto; break;
                    case "LISTINGPRICE":  oReturn = this.ListingPrice; break;
                    case "GROSSREVENUE":  oReturn = this.GrossRevenue; break;
                    case "COGS":  oReturn = this.COGs; break;
                    case "EBITDA":  oReturn = this.EBITDA; break;
                    case "ACCOUNTSRECEIVABLE":  oReturn = this.AccountsReceivable; break;
                    case "INVENTORY":  oReturn = this.Inventory; break;
                    case "CASHFLOW":  oReturn = this.CashFlow; break;
                    case "FFANDE":  oReturn = this.FFandE; break;
                    case "REALESTATEVALUE":  oReturn = this.RealEstateValue; break;
                    case "REALESTATEASKINGPRICE":  oReturn = this.RealEstateAskingPrice; break;
                    case "MINIMUMDOWNPAYMENT":  oReturn = this.MinimumDownPayment; break;
                    case "SELLERFINANCEUPTO":  oReturn = this.SellerFinanceUpTo; break;
                    case "RENT":  oReturn = this.Rent; break;
                    case "REQUESTEDDOWNPAYMENT":  oReturn = this.RequestedDownPayment; break;
                    case "COMMISSIONRATE":  oReturn = this.CommissionRate; break;
                    case "COMMISSIONMINIMUM":  oReturn = this.CommissionMinimum; break;
                    case "TOTALSQFT":  oReturn = this.TotalSqFt; break;
                    case "OCCUPIEDSQFT":  oReturn = this.OccupiedSqFt; break;
                    case "FACILITYOWNED_INT":  oReturn = this.FacilityOwned_Int; break;
                    case "REALESTATEINCLUDED_INT":  oReturn = this.RealEstateIncluded_Int; break;
                    case "SHOWCOUNTY_INT":  oReturn = this.ShowCounty_Int; break;
                    case "SHOWCITY_INT":  oReturn = this.ShowCity_Int; break;
                    case "SHOWZIP_INT":  oReturn = this.ShowZip_Int; break;
                    case "SHOWGROSSREVENUES_INT":  oReturn = this.ShowGrossRevenues_Int; break;
                    case "SHOWCASHFLOW_INT":  oReturn = this.ShowCashFlow_Int; break;
                    case "SHOWEBITDA_INT":  oReturn = this.ShowEBITDA_Int; break;
                    case "SHOWINVENTORY_INT":  oReturn = this.ShowInventory_Int; break;
                    case "SHOWFFE_INT":  oReturn = this.ShowFFE_Int; break;
                    case "SHOWCOMPANYWEBSITE_INT":  oReturn = this.ShowCompanyWebsite_Int; break;
                    case "SHOWNUMBEROFEMPLOYEES_INT":  oReturn = this.ShowNumberOfEmployees_Int; break;
                    case "SHOWYEARESTABLISHED_INT":  oReturn = this.ShowYearEstablished_Int; break;
                    case "BUILDINGCOUNT":  oReturn = this.BuildingCount; break;
                    case "EMPLOYEECOUNT":  oReturn = this.EmployeeCount; break;
                    case "BUYERCOUNT":  oReturn = this.BuyerCount; break;
                    case "ISREALESTATEINPRICE":  oReturn = this.IsRealEstateInPrice; break;
                    case "ISABSENTEEOWNER":  oReturn = this.IsAbsenteeOwner; break;
                    case "ISHOMEBASED":  oReturn = this.IsHomeBased; break;
                    case "ISRELOCATABLE":  oReturn = this.IsRelocatable; break;
                    case "ISFRANCHISE":  oReturn = this.IsFranchise; break;
                    case "ISSELLERFINANACE":  oReturn = this.IsSellerFinanace; break;
                    case "ISSBAPREAPPROVED":  oReturn = this.IsSbaPreApproved; break;
                    case "ISINVENTORYINCLUDED":  oReturn = this.IsInventoryIncluded; break;
                    case "ISACCOUNTSRECEIVABLEINCLUDED":  oReturn = this.IsAccountsReceivableIncluded; break;
                    case "WEBSITEURL":  oReturn = this.WebsiteURL; break;
                    case "YEARESTABLISHED":  oReturn = this.YearEstablished; break;
                    case "LISTINGDATE":  oReturn = this.ListingDate; break;
                    case "CLOSEDATE":  oReturn = this.CloseDate; break;
                    case "EXPIRATIONDATE":  oReturn = this.ExpirationDate; break;
                    case "CREATEDON":  oReturn = this.CreatedOn; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                    case "ISPENDING":  oReturn = this.IsPending; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "ENTITYOID_BILLINGAUTHORITY":  this.EntityOid_BillingAuthority = (long)value;  break;
                case "LKPBUSINESSCATEGORYOIDS":  this.lkpBusinessCategoryOids = (string)value;  break;
                case "LKPLISTINGSETUPSTATUSOID":  this.lkpListingSetupStatusOid = (long?)value;  break;
                case "LKPCOUNTRYOID":  this.lkpCountryOid = (long?)value;  break;
                case "LKPSTATEOID":  this.lkpStateOid = (long?)value;  break;
                case "LKPCOUNTYOID":  this.lkpCountyOid = (long?)value;  break;
                case "LKPCITYOID":  this.lkpCityOid = (long?)value;  break;
                case "LKPLEGALENTITYTYPEOID":  this.lkpLegalEntityTypeOid = (long?)value;  break;
                case "LKPCOMMISSIONTYPEOID":  this.lkpCommissionTypeOid = (long?)value;  break;
                case "LKPLISTINGCLOSESTATUSOID":  this.lkpListingCloseStatusOid = (long?)value;  break;
                case "EXTERNALID":  this.ExternalId = (string)value;  break;
                case "EXTERNALSYSTEM":  this.ExternalSystem = (string)value;  break;
                case "CONTACTNAME":  this.ContactName = (string)value;  break;
                case "CONTACTEMAIL":  this.ContactEmail = (string)value;  break;
                case "CONTACTPHONE":  this.ContactPhone = (string)value;  break;
                case "COMPANYNAME":  this.CompanyName = (string)value;  break;
                case "COMPANYPHONE":  this.CompanyPhone = (string)value;  break;
                case "GENERALLOCATION":  this.GeneralLocation = (string)value;  break;
                case "SELLERNAME":  this.SellerName = (string)value;  break;
                case "HOURSOFOPERATION":  this.HoursOfOperation = (string)value;  break;
                case "ADDRESS":  this.Address = (string)value;  break;
                case "ADDRESS2":  this.Address2 = (string)value;  break;
                case "CITY":  this.City = (string)value;  break;
                case "COUNTY":  this.County = (string)value;  break;
                case "STATE":  this.State = (string)value;  break;
                case "ZIP":  this.Zip = (string)value;  break;
                case "KEYWORDS":  this.Keywords = (string)value;  break;
                case "ADTITLE":  this.AdTitle = (string)value;  break;
                case "ADTAGLINE":  this.AdTagLine = (string)value;  break;
                case "ADDESCRIPTION":  this.AdDescription = (string)value;  break;
                case "ADBUSINESSHISTORY":  this.AdBusinessHistory = (string)value;  break;
                case "ADCOMPETITIVEANALYSIS":  this.AdCompetitiveAnalysis = (string)value;  break;
                case "ADOPPORTUNITYFORGROWTH":  this.AdOpportunityForGrowth = (string)value;  break;
                case "ADREASONFORSELLING":  this.AdReasonForSelling = (string)value;  break;
                case "ADFACILITYDESCRIPTION":  this.AdFacilityDescription = (string)value;  break;
                case "ADSUPPORTANDTRAINING":  this.AdSupportAndTraining = (string)value;  break;
                case "ADPHOTO":  this.AdPhoto = (string)value;  break;
                case "LISTINGPRICE":  this.ListingPrice = (decimal?)value;  break;
                case "GROSSREVENUE":  this.GrossRevenue = (decimal?)value;  break;
                case "COGS":  this.COGs = (decimal?)value;  break;
                case "EBITDA":  this.EBITDA = (decimal?)value;  break;
                case "ACCOUNTSRECEIVABLE":  this.AccountsReceivable = (decimal?)value;  break;
                case "INVENTORY":  this.Inventory = (decimal?)value;  break;
                case "CASHFLOW":  this.CashFlow = (decimal?)value;  break;
                case "FFANDE":  this.FFandE = (decimal?)value;  break;
                case "REALESTATEVALUE":  this.RealEstateValue = (decimal?)value;  break;
                case "REALESTATEASKINGPRICE":  this.RealEstateAskingPrice = (decimal?)value;  break;
                case "MINIMUMDOWNPAYMENT":  this.MinimumDownPayment = (decimal?)value;  break;
                case "SELLERFINANCEUPTO":  this.SellerFinanceUpTo = (decimal?)value;  break;
                case "RENT":  this.Rent = (decimal?)value;  break;
                case "REQUESTEDDOWNPAYMENT":  this.RequestedDownPayment = (decimal?)value;  break;
                case "COMMISSIONRATE":  this.CommissionRate = (decimal?)value;  break;
                case "COMMISSIONMINIMUM":  this.CommissionMinimum = (decimal?)value;  break;
                case "TOTALSQFT":  this.TotalSqFt = (int?)value;  break;
                case "OCCUPIEDSQFT":  this.OccupiedSqFt = (int?)value;  break;
                case "FACILITYOWNED_INT":  this.FacilityOwned_Int = (int?)value;  break;
                case "REALESTATEINCLUDED_INT":  this.RealEstateIncluded_Int = (int?)value;  break;
                case "SHOWCOUNTY_INT":  this.ShowCounty_Int = (int?)value;  break;
                case "SHOWCITY_INT":  this.ShowCity_Int = (int?)value;  break;
                case "SHOWZIP_INT":  this.ShowZip_Int = (int?)value;  break;
                case "SHOWGROSSREVENUES_INT":  this.ShowGrossRevenues_Int = (int?)value;  break;
                case "SHOWCASHFLOW_INT":  this.ShowCashFlow_Int = (int?)value;  break;
                case "SHOWEBITDA_INT":  this.ShowEBITDA_Int = (int?)value;  break;
                case "SHOWINVENTORY_INT":  this.ShowInventory_Int = (int?)value;  break;
                case "SHOWFFE_INT":  this.ShowFFE_Int = (int?)value;  break;
                case "SHOWCOMPANYWEBSITE_INT":  this.ShowCompanyWebsite_Int = (int?)value;  break;
                case "SHOWNUMBEROFEMPLOYEES_INT":  this.ShowNumberOfEmployees_Int = (int?)value;  break;
                case "SHOWYEARESTABLISHED_INT":  this.ShowYearEstablished_Int = (int?)value;  break;
                case "BUILDINGCOUNT":  this.BuildingCount = (int?)value;  break;
                case "EMPLOYEECOUNT":  this.EmployeeCount = (int?)value;  break;
                case "BUYERCOUNT":  this.BuyerCount = (int?)value;  break;
                case "ISREALESTATEINPRICE":  this.IsRealEstateInPrice = (bool?)value;  break;
                case "ISABSENTEEOWNER":  this.IsAbsenteeOwner = (bool?)value;  break;
                case "ISHOMEBASED":  this.IsHomeBased = (bool?)value;  break;
                case "ISRELOCATABLE":  this.IsRelocatable = (bool?)value;  break;
                case "ISFRANCHISE":  this.IsFranchise = (bool?)value;  break;
                case "ISSELLERFINANACE":  this.IsSellerFinanace = (bool?)value;  break;
                case "ISSBAPREAPPROVED":  this.IsSbaPreApproved = (bool?)value;  break;
                case "ISINVENTORYINCLUDED":  this.IsInventoryIncluded = (bool?)value;  break;
                case "ISACCOUNTSRECEIVABLEINCLUDED":  this.IsAccountsReceivableIncluded = (bool?)value;  break;
                case "WEBSITEURL":  this.WebsiteURL = (string)value;  break;
                case "YEARESTABLISHED":  this.YearEstablished = (string)value;  break;
                case "LISTINGDATE":  this.ListingDate = (DateTime)value;  break;
                case "CLOSEDATE":  this.CloseDate = (DateTime?)value;  break;
                case "EXPIRATIONDATE":  this.ExpirationDate = (DateTime?)value;  break;
                case "CREATEDON":  this.CreatedOn = (DateTime)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                case "ISPENDING":  this.IsPending = (bool)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Listing2BizCategoryMap")]
    [PrimaryKey("Oid")]
    public partial class Listing2BizCategoryMap : Record<Listing2BizCategoryMap>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ListingOid")]
        public long ListingOid { get; set; }
        [Column("lkpBusinessCategoryOid")]
        public long lkpBusinessCategoryOid { get; set; }
        [Column("SearchListingOid")]
        public long SearchListingOid { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Listing2BizCategoryMap ShallowClone(){ return (Listing2BizCategoryMap)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "LISTINGOID":  oReturn = this.ListingOid; break;
                    case "LKPBUSINESSCATEGORYOID":  oReturn = this.lkpBusinessCategoryOid; break;
                    case "SEARCHLISTINGOID":  oReturn = this.SearchListingOid; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "LISTINGOID":  this.ListingOid = (long)value;  break;
                case "LKPBUSINESSCATEGORYOID":  this.lkpBusinessCategoryOid = (long)value;  break;
                case "SEARCHLISTINGOID":  this.SearchListingOid = (long)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("ListingAttribute")]
    [PrimaryKey("Oid")]
    public partial class ListingAttribute : Record<ListingAttribute>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ParentOid")]
        public long? ParentOid { get; set; }
        [Column("ListingOid")]
        public long ListingOid { get; set; }
        [Column("lkpAttributeTypeOid")]
        public long lkpAttributeTypeOid { get; set; }
        [Column("DataType")]
        public string DataType { get; set; }
        [Column("Value")]
        public string Value { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public ListingAttribute ShallowClone(){ return (ListingAttribute)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "PARENTOID":  oReturn = this.ParentOid; break;
                    case "LISTINGOID":  oReturn = this.ListingOid; break;
                    case "LKPATTRIBUTETYPEOID":  oReturn = this.lkpAttributeTypeOid; break;
                    case "DATATYPE":  oReturn = this.DataType; break;
                    case "VALUE":  oReturn = this.Value; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "PARENTOID":  this.ParentOid = (long?)value;  break;
                case "LISTINGOID":  this.ListingOid = (long)value;  break;
                case "LKPATTRIBUTETYPEOID":  this.lkpAttributeTypeOid = (long)value;  break;
                case "DATATYPE":  this.DataType = (string)value;  break;
                case "VALUE":  this.Value = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("ListingStat")]
    [PrimaryKey("Oid")]
    public partial class ListingStat : Record<ListingStat>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ListingOid")]
        public long ListingOid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("Context")]
        public string Context { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public ListingStat ShallowClone(){ return (ListingStat)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "LISTINGOID":  oReturn = this.ListingOid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "CONTEXT":  oReturn = this.Context; break;
                    case "DATE":  oReturn = this.Date; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "LISTINGOID":  this.ListingOid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "CONTEXT":  this.Context = (string)value;  break;
                case "DATE":  this.Date = (DateTime)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Login")]
    [PrimaryKey("Oid")]
    public partial class Login : Record<Login>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("SecurityGroupOid")]
        public long SecurityGroupOid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("EntityOid_Master")]
        public long EntityOid_Master { get; set; }
        [Column("EntityOid_Authority")]
        public long EntityOid_Authority { get; set; }
        [Column("lkpThirdPartyAuthTypeOid")]
        public long? lkpThirdPartyAuthTypeOid { get; set; }
        [Column("ThirdPartyAuthToken")]
        public string ThirdPartyAuthToken { get; set; }
        [Column("LoginName")]
        public string LoginName { get; set; }
        [Column("ScreenName")]
        public string ScreenName { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("IsLocked")]
        public bool? IsLocked { get; set; }
        [Column("IsTermsAndConditionsAccepted")]
        public bool? IsTermsAndConditionsAccepted { get; set; }
        [Column("IsNewUser")]
        public bool? IsNewUser { get; set; }
        [Column("UserMustChangePwd")]
        public bool UserMustChangePwd { get; set; }
        [Column("IsCwsUser")]
        public bool? IsCwsUser { get; set; }
        [Column("ConsecutiveLoginFailures")]
        public int ConsecutiveLoginFailures { get; set; }
        [Column("LastLoginDate")]
        public DateTime? LastLoginDate { get; set; }
        [Column("DatePwChanged")]
        public DateTime? DatePwChanged { get; set; }
        [Column("CreatedOn")]
        public DateTime? CreatedOn { get; set; }
        [Column("Ok2Delete")]
        public bool? Ok2Delete { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Login ShallowClone(){ return (Login)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "SECURITYGROUPOID":  oReturn = this.SecurityGroupOid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "ENTITYOID_MASTER":  oReturn = this.EntityOid_Master; break;
                    case "ENTITYOID_AUTHORITY":  oReturn = this.EntityOid_Authority; break;
                    case "LKPTHIRDPARTYAUTHTYPEOID":  oReturn = this.lkpThirdPartyAuthTypeOid; break;
                    case "THIRDPARTYAUTHTOKEN":  oReturn = this.ThirdPartyAuthToken; break;
                    case "LOGINNAME":  oReturn = this.LoginName; break;
                    case "SCREENNAME":  oReturn = this.ScreenName; break;
                    case "PASSWORD":  oReturn = this.Password; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                    case "ISLOCKED":  oReturn = this.IsLocked; break;
                    case "ISTERMSANDCONDITIONSACCEPTED":  oReturn = this.IsTermsAndConditionsAccepted; break;
                    case "ISNEWUSER":  oReturn = this.IsNewUser; break;
                    case "USERMUSTCHANGEPWD":  oReturn = this.UserMustChangePwd; break;
                    case "ISCWSUSER":  oReturn = this.IsCwsUser; break;
                    case "CONSECUTIVELOGINFAILURES":  oReturn = this.ConsecutiveLoginFailures; break;
                    case "LASTLOGINDATE":  oReturn = this.LastLoginDate; break;
                    case "DATEPWCHANGED":  oReturn = this.DatePwChanged; break;
                    case "CREATEDON":  oReturn = this.CreatedOn; break;
                    case "OK2DELETE":  oReturn = this.Ok2Delete; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "SECURITYGROUPOID":  this.SecurityGroupOid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "ENTITYOID_MASTER":  this.EntityOid_Master = (long)value;  break;
                case "ENTITYOID_AUTHORITY":  this.EntityOid_Authority = (long)value;  break;
                case "LKPTHIRDPARTYAUTHTYPEOID":  this.lkpThirdPartyAuthTypeOid = (long?)value;  break;
                case "THIRDPARTYAUTHTOKEN":  this.ThirdPartyAuthToken = (string)value;  break;
                case "LOGINNAME":  this.LoginName = (string)value;  break;
                case "SCREENNAME":  this.ScreenName = (string)value;  break;
                case "PASSWORD":  this.Password = (string)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                case "ISLOCKED":  this.IsLocked = (bool?)value;  break;
                case "ISTERMSANDCONDITIONSACCEPTED":  this.IsTermsAndConditionsAccepted = (bool?)value;  break;
                case "ISNEWUSER":  this.IsNewUser = (bool?)value;  break;
                case "USERMUSTCHANGEPWD":  this.UserMustChangePwd = (bool)value;  break;
                case "ISCWSUSER":  this.IsCwsUser = (bool?)value;  break;
                case "CONSECUTIVELOGINFAILURES":  this.ConsecutiveLoginFailures = (int)value;  break;
                case "LASTLOGINDATE":  this.LastLoginDate = (DateTime?)value;  break;
                case "DATEPWCHANGED":  this.DatePwChanged = (DateTime?)value;  break;
                case "CREATEDON":  this.CreatedOn = (DateTime?)value;  break;
                case "OK2DELETE":  this.Ok2Delete = (bool?)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Lookup")]
    [PrimaryKey("Oid")]
    public partial class Lookup : Record<Lookup>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("LookupDefinitionOid")]
        public long LookupDefinitionOid { get; set; }
        [Column("ParentOid")]
        public long? ParentOid { get; set; }
        [Column("LookupName")]
        public string LookupName { get; set; }
        [Column("ConstantValue")]
        public string ConstantValue { get; set; }
        [Column("Value")]
        public string Value { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("SortOrder")]
        public decimal SortOrder { get; set; }
        [Column("UDF1")]
        public string UDF1 { get; set; }
        [Column("UDF2")]
        public string UDF2 { get; set; }
        [Column("UDF3")]
        public string UDF3 { get; set; }
        [Column("UDF4")]
        public string UDF4 { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("MetaData")]
        public string MetaData { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Lookup ShallowClone(){ return (Lookup)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "LOOKUPDEFINITIONOID":  oReturn = this.LookupDefinitionOid; break;
                    case "PARENTOID":  oReturn = this.ParentOid; break;
                    case "LOOKUPNAME":  oReturn = this.LookupName; break;
                    case "CONSTANTVALUE":  oReturn = this.ConstantValue; break;
                    case "VALUE":  oReturn = this.Value; break;
                    case "DESCRIPTION":  oReturn = this.Description; break;
                    case "SORTORDER":  oReturn = this.SortOrder; break;
                    case "UDF1":  oReturn = this.UDF1; break;
                    case "UDF2":  oReturn = this.UDF2; break;
                    case "UDF3":  oReturn = this.UDF3; break;
                    case "UDF4":  oReturn = this.UDF4; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                    case "METADATA":  oReturn = this.MetaData; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "LOOKUPDEFINITIONOID":  this.LookupDefinitionOid = (long)value;  break;
                case "PARENTOID":  this.ParentOid = (long?)value;  break;
                case "LOOKUPNAME":  this.LookupName = (string)value;  break;
                case "CONSTANTVALUE":  this.ConstantValue = (string)value;  break;
                case "VALUE":  this.Value = (string)value;  break;
                case "DESCRIPTION":  this.Description = (string)value;  break;
                case "SORTORDER":  this.SortOrder = (decimal)value;  break;
                case "UDF1":  this.UDF1 = (string)value;  break;
                case "UDF2":  this.UDF2 = (string)value;  break;
                case "UDF3":  this.UDF3 = (string)value;  break;
                case "UDF4":  this.UDF4 = (string)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                case "METADATA":  this.MetaData = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("LookupDefinition")]
    [PrimaryKey("Oid")]
    public partial class LookupDefinition : Record<LookupDefinition>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ParentOid")]
        public long? ParentOid { get; set; }
        [Column("LookupName")]
        public string LookupName { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("UDF1")]
        public string UDF1 { get; set; }
        [Column("UDF2")]
        public string UDF2 { get; set; }
        [Column("UDF3")]
        public string UDF3 { get; set; }
        [Column("UDF4")]
        public string UDF4 { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public LookupDefinition ShallowClone(){ return (LookupDefinition)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "PARENTOID":  oReturn = this.ParentOid; break;
                    case "LOOKUPNAME":  oReturn = this.LookupName; break;
                    case "DESCRIPTION":  oReturn = this.Description; break;
                    case "UDF1":  oReturn = this.UDF1; break;
                    case "UDF2":  oReturn = this.UDF2; break;
                    case "UDF3":  oReturn = this.UDF3; break;
                    case "UDF4":  oReturn = this.UDF4; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "PARENTOID":  this.ParentOid = (long?)value;  break;
                case "LOOKUPNAME":  this.LookupName = (string)value;  break;
                case "DESCRIPTION":  this.Description = (string)value;  break;
                case "UDF1":  this.UDF1 = (string)value;  break;
                case "UDF2":  this.UDF2 = (string)value;  break;
                case "UDF3":  this.UDF3 = (string)value;  break;
                case "UDF4":  this.UDF4 = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Notification")]
    [PrimaryKey("Oid")]
    public partial class Notification : Record<Notification>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("TargetOid")]
        public long? TargetOid { get; set; }
        [Column("TargetTable")]
        public string TargetTable { get; set; }
        [Column("Category")]
        public string Category { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        [Column("Message")]
        public string Message { get; set; }
        [Column("Data")]
        public string Data { get; set; }
        [Column("Url")]
        public string Url { get; set; }
        [Column("IsRead")]
        public bool IsRead { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("CreatedOnDate")]
        public DateTime CreatedOnDate { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Notification ShallowClone(){ return (Notification)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "TARGETOID":  oReturn = this.TargetOid; break;
                    case "TARGETTABLE":  oReturn = this.TargetTable; break;
                    case "CATEGORY":  oReturn = this.Category; break;
                    case "TITLE":  oReturn = this.Title; break;
                    case "MESSAGE":  oReturn = this.Message; break;
                    case "DATA":  oReturn = this.Data; break;
                    case "URL":  oReturn = this.Url; break;
                    case "ISREAD":  oReturn = this.IsRead; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                    case "CREATEDONDATE":  oReturn = this.CreatedOnDate; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "TARGETOID":  this.TargetOid = (long?)value;  break;
                case "TARGETTABLE":  this.TargetTable = (string)value;  break;
                case "CATEGORY":  this.Category = (string)value;  break;
                case "TITLE":  this.Title = (string)value;  break;
                case "MESSAGE":  this.Message = (string)value;  break;
                case "DATA":  this.Data = (string)value;  break;
                case "URL":  this.Url = (string)value;  break;
                case "ISREAD":  this.IsRead = (bool)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                case "CREATEDONDATE":  this.CreatedOnDate = (DateTime)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Process")]
    [PrimaryKey("Oid")]
    public partial class Process : Record<Process>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ProcessStepOid")]
        public long ProcessStepOid { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Process ShallowClone(){ return (Process)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "PROCESSSTEPOID":  oReturn = this.ProcessStepOid; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "PROCESSSTEPOID":  this.ProcessStepOid = (long)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("ProcessDescription")]
    [PrimaryKey("Oid")]
    public partial class ProcessDescription : Record<ProcessDescription>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ParentOid")]
        public long? ParentOid { get; set; }
        [Column("EntityOid_Master")]
        public long? EntityOid_Master { get; set; }
        [Column("lkpProcessTypeOid")]
        public long? lkpProcessTypeOid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public ProcessDescription ShallowClone(){ return (ProcessDescription)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "PARENTOID":  oReturn = this.ParentOid; break;
                    case "ENTITYOID_MASTER":  oReturn = this.EntityOid_Master; break;
                    case "LKPPROCESSTYPEOID":  oReturn = this.lkpProcessTypeOid; break;
                    case "NAME":  oReturn = this.Name; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "PARENTOID":  this.ParentOid = (long?)value;  break;
                case "ENTITYOID_MASTER":  this.EntityOid_Master = (long?)value;  break;
                case "LKPPROCESSTYPEOID":  this.lkpProcessTypeOid = (long?)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("ProcessSequenceMap")]
    [PrimaryKey("Oid")]
    public partial class ProcessSequenceMap : Record<ProcessSequenceMap>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ProcessOid")]
        public long ProcessOid { get; set; }
        [Column("ProcessStepOid")]
        public long ProcessStepOid { get; set; }
        [Column("Sequence")]
        public int Sequence { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public ProcessSequenceMap ShallowClone(){ return (ProcessSequenceMap)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "PROCESSOID":  oReturn = this.ProcessOid; break;
                    case "PROCESSSTEPOID":  oReturn = this.ProcessStepOid; break;
                    case "SEQUENCE":  oReturn = this.Sequence; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "PROCESSOID":  this.ProcessOid = (long)value;  break;
                case "PROCESSSTEPOID":  this.ProcessStepOid = (long)value;  break;
                case "SEQUENCE":  this.Sequence = (int)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("ProcessStep")]
    [PrimaryKey("Oid")]
    public partial class ProcessStep : Record<ProcessStep>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ParentOid")]
        public long? ParentOid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Notes")]
        public string Notes { get; set; }
        [Column("ProgramCode")]
        public string ProgramCode { get; set; }
        [Column("IsRequired")]
        public bool IsRequired { get; set; }
        [Column("SortOrder")]
        public decimal SortOrder { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public ProcessStep ShallowClone(){ return (ProcessStep)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "PARENTOID":  oReturn = this.ParentOid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "NOTES":  oReturn = this.Notes; break;
                    case "PROGRAMCODE":  oReturn = this.ProgramCode; break;
                    case "ISREQUIRED":  oReturn = this.IsRequired; break;
                    case "SORTORDER":  oReturn = this.SortOrder; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "PARENTOID":  this.ParentOid = (long?)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "NOTES":  this.Notes = (string)value;  break;
                case "PROGRAMCODE":  this.ProgramCode = (string)value;  break;
                case "ISREQUIRED":  this.IsRequired = (bool)value;  break;
                case "SORTORDER":  this.SortOrder = (decimal)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Recipe")]
    [PrimaryKey("Oid")]
    public partial class Recipe : Record<Recipe>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Source")]
        public string Source { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Recipe ShallowClone(){ return (Recipe)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "DESCRIPTION":  oReturn = this.Description; break;
                    case "SOURCE":  oReturn = this.Source; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "DESCRIPTION":  this.Description = (string)value;  break;
                case "SOURCE":  this.Source = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("SearchCriteria")]
    [PrimaryKey("Oid")]
    public partial class SearchCriteria : Record<SearchCriteria>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("lkpCountryOid")]
        public long lkpCountryOid { get; set; }
        [Column("lkpStateOid")]
        public long lkpStateOid { get; set; }
        [Column("lkpCountyOids")]
        public string lkpCountyOids { get; set; }
        [Column("lkpCityOids")]
        public string lkpCityOids { get; set; }
        [Column("ZipCode")]
        public string ZipCode { get; set; }
        [Column("ZipCodes")]
        public string ZipCodes { get; set; }
        [Column("SearchRadius")]
        public int? SearchRadius { get; set; }
        [Column("lkpBusinessCategoryOids")]
        public string lkpBusinessCategoryOids { get; set; }
        [Column("Keywords")]
        public string Keywords { get; set; }
        [Column("Street")]
        public string Street { get; set; }
        [Column("ListingPrice_From")]
        public decimal? ListingPrice_From { get; set; }
        [Column("ListingPrice_To")]
        public decimal? ListingPrice_To { get; set; }
        [Column("GrossRevenue_From")]
        public decimal? GrossRevenue_From { get; set; }
        [Column("GrossRevenue_To")]
        public decimal? GrossRevenue_To { get; set; }
        [Column("EBITDA_From")]
        public decimal? EBITDA_From { get; set; }
        [Column("EBITDA_To")]
        public decimal? EBITDA_To { get; set; }
        [Column("CashFlow_From")]
        public decimal? CashFlow_From { get; set; }
        [Column("CashFlow_To")]
        public decimal? CashFlow_To { get; set; }
        [Column("MinimumDownPayment_From")]
        public decimal? MinimumDownPayment_From { get; set; }
        [Column("MinimumDownPayment_To")]
        public decimal? MinimumDownPayment_To { get; set; }
        [Column("TotalSqFt_From")]
        public int? TotalSqFt_From { get; set; }
        [Column("TotalSqFt_To")]
        public int? TotalSqFt_To { get; set; }
        [Column("EmployeeCount_From")]
        public int? EmployeeCount_From { get; set; }
        [Column("EmployeeCount_To")]
        public int? EmployeeCount_To { get; set; }
        [Column("IsAbsenteeOwner")]
        public bool? IsAbsenteeOwner { get; set; }
        [Column("IsHomeBased")]
        public bool? IsHomeBased { get; set; }
        [Column("IsRelocatable")]
        public bool? IsRelocatable { get; set; }
        [Column("IsFranchise")]
        public bool? IsFranchise { get; set; }
        [Column("IsSellerFinanace")]
        public bool? IsSellerFinanace { get; set; }
        [Column("IsSbaPreApproved")]
        public bool? IsSbaPreApproved { get; set; }
        [Column("IsRealEstateAvailable")]
        public bool? IsRealEstateAvailable { get; set; }
        [Column("IsTextNotification")]
        public bool? IsTextNotification { get; set; }
        [Column("IsEmailNotification")]
        public bool? IsEmailNotification { get; set; }
        [Column("IsEmailRecipientListQuery")]
        public bool? IsEmailRecipientListQuery { get; set; }
        [Column("LastSearchedDate")]
        public DateTime? LastSearchedDate { get; set; }
        [Column("NewListingsSinceLastSearchDate")]
        public int NewListingsSinceLastSearchDate { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("ListingCount")]
        public int? ListingCount { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public SearchCriteria ShallowClone(){ return (SearchCriteria)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "LKPCOUNTRYOID":  oReturn = this.lkpCountryOid; break;
                    case "LKPSTATEOID":  oReturn = this.lkpStateOid; break;
                    case "LKPCOUNTYOIDS":  oReturn = this.lkpCountyOids; break;
                    case "LKPCITYOIDS":  oReturn = this.lkpCityOids; break;
                    case "ZIPCODE":  oReturn = this.ZipCode; break;
                    case "ZIPCODES":  oReturn = this.ZipCodes; break;
                    case "SEARCHRADIUS":  oReturn = this.SearchRadius; break;
                    case "LKPBUSINESSCATEGORYOIDS":  oReturn = this.lkpBusinessCategoryOids; break;
                    case "KEYWORDS":  oReturn = this.Keywords; break;
                    case "STREET":  oReturn = this.Street; break;
                    case "LISTINGPRICE_FROM":  oReturn = this.ListingPrice_From; break;
                    case "LISTINGPRICE_TO":  oReturn = this.ListingPrice_To; break;
                    case "GROSSREVENUE_FROM":  oReturn = this.GrossRevenue_From; break;
                    case "GROSSREVENUE_TO":  oReturn = this.GrossRevenue_To; break;
                    case "EBITDA_FROM":  oReturn = this.EBITDA_From; break;
                    case "EBITDA_TO":  oReturn = this.EBITDA_To; break;
                    case "CASHFLOW_FROM":  oReturn = this.CashFlow_From; break;
                    case "CASHFLOW_TO":  oReturn = this.CashFlow_To; break;
                    case "MINIMUMDOWNPAYMENT_FROM":  oReturn = this.MinimumDownPayment_From; break;
                    case "MINIMUMDOWNPAYMENT_TO":  oReturn = this.MinimumDownPayment_To; break;
                    case "TOTALSQFT_FROM":  oReturn = this.TotalSqFt_From; break;
                    case "TOTALSQFT_TO":  oReturn = this.TotalSqFt_To; break;
                    case "EMPLOYEECOUNT_FROM":  oReturn = this.EmployeeCount_From; break;
                    case "EMPLOYEECOUNT_TO":  oReturn = this.EmployeeCount_To; break;
                    case "ISABSENTEEOWNER":  oReturn = this.IsAbsenteeOwner; break;
                    case "ISHOMEBASED":  oReturn = this.IsHomeBased; break;
                    case "ISRELOCATABLE":  oReturn = this.IsRelocatable; break;
                    case "ISFRANCHISE":  oReturn = this.IsFranchise; break;
                    case "ISSELLERFINANACE":  oReturn = this.IsSellerFinanace; break;
                    case "ISSBAPREAPPROVED":  oReturn = this.IsSbaPreApproved; break;
                    case "ISREALESTATEAVAILABLE":  oReturn = this.IsRealEstateAvailable; break;
                    case "ISTEXTNOTIFICATION":  oReturn = this.IsTextNotification; break;
                    case "ISEMAILNOTIFICATION":  oReturn = this.IsEmailNotification; break;
                    case "ISEMAILRECIPIENTLISTQUERY":  oReturn = this.IsEmailRecipientListQuery; break;
                    case "LASTSEARCHEDDATE":  oReturn = this.LastSearchedDate; break;
                    case "NEWLISTINGSSINCELASTSEARCHDATE":  oReturn = this.NewListingsSinceLastSearchDate; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                    case "LISTINGCOUNT":  oReturn = this.ListingCount; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "LKPCOUNTRYOID":  this.lkpCountryOid = (long)value;  break;
                case "LKPSTATEOID":  this.lkpStateOid = (long)value;  break;
                case "LKPCOUNTYOIDS":  this.lkpCountyOids = (string)value;  break;
                case "LKPCITYOIDS":  this.lkpCityOids = (string)value;  break;
                case "ZIPCODE":  this.ZipCode = (string)value;  break;
                case "ZIPCODES":  this.ZipCodes = (string)value;  break;
                case "SEARCHRADIUS":  this.SearchRadius = (int?)value;  break;
                case "LKPBUSINESSCATEGORYOIDS":  this.lkpBusinessCategoryOids = (string)value;  break;
                case "KEYWORDS":  this.Keywords = (string)value;  break;
                case "STREET":  this.Street = (string)value;  break;
                case "LISTINGPRICE_FROM":  this.ListingPrice_From = (decimal?)value;  break;
                case "LISTINGPRICE_TO":  this.ListingPrice_To = (decimal?)value;  break;
                case "GROSSREVENUE_FROM":  this.GrossRevenue_From = (decimal?)value;  break;
                case "GROSSREVENUE_TO":  this.GrossRevenue_To = (decimal?)value;  break;
                case "EBITDA_FROM":  this.EBITDA_From = (decimal?)value;  break;
                case "EBITDA_TO":  this.EBITDA_To = (decimal?)value;  break;
                case "CASHFLOW_FROM":  this.CashFlow_From = (decimal?)value;  break;
                case "CASHFLOW_TO":  this.CashFlow_To = (decimal?)value;  break;
                case "MINIMUMDOWNPAYMENT_FROM":  this.MinimumDownPayment_From = (decimal?)value;  break;
                case "MINIMUMDOWNPAYMENT_TO":  this.MinimumDownPayment_To = (decimal?)value;  break;
                case "TOTALSQFT_FROM":  this.TotalSqFt_From = (int?)value;  break;
                case "TOTALSQFT_TO":  this.TotalSqFt_To = (int?)value;  break;
                case "EMPLOYEECOUNT_FROM":  this.EmployeeCount_From = (int?)value;  break;
                case "EMPLOYEECOUNT_TO":  this.EmployeeCount_To = (int?)value;  break;
                case "ISABSENTEEOWNER":  this.IsAbsenteeOwner = (bool?)value;  break;
                case "ISHOMEBASED":  this.IsHomeBased = (bool?)value;  break;
                case "ISRELOCATABLE":  this.IsRelocatable = (bool?)value;  break;
                case "ISFRANCHISE":  this.IsFranchise = (bool?)value;  break;
                case "ISSELLERFINANACE":  this.IsSellerFinanace = (bool?)value;  break;
                case "ISSBAPREAPPROVED":  this.IsSbaPreApproved = (bool?)value;  break;
                case "ISREALESTATEAVAILABLE":  this.IsRealEstateAvailable = (bool?)value;  break;
                case "ISTEXTNOTIFICATION":  this.IsTextNotification = (bool?)value;  break;
                case "ISEMAILNOTIFICATION":  this.IsEmailNotification = (bool?)value;  break;
                case "ISEMAILRECIPIENTLISTQUERY":  this.IsEmailRecipientListQuery = (bool?)value;  break;
                case "LASTSEARCHEDDATE":  this.LastSearchedDate = (DateTime?)value;  break;
                case "NEWLISTINGSSINCELASTSEARCHDATE":  this.NewListingsSinceLastSearchDate = (int)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                case "LISTINGCOUNT":  this.ListingCount = (int?)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("SecurityGroup")]
    [PrimaryKey("Oid")]
    public partial class SecurityGroup : Record<SecurityGroup>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ParentOid")]
        public long? ParentOid { get; set; }
        [Column("SecurityPwdRuleOid")]
        public long SecurityPwdRuleOid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Constant")]
        public string Constant { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("IsAdmin")]
        public bool IsAdmin { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("NavMenu_JSON")]
        public string NavMenu_JSON { get; set; }
        [Column("CreatedBy")]
        public string CreatedBy { get; set; }
        [Column("CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [Column("ModifiedBy")]
        public string ModifiedBy { get; set; }
        [Column("ModifiedOn")]
        public DateTime ModifiedOn { get; set; }
        [Column("Version")]
        public int Version { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public SecurityGroup ShallowClone(){ return (SecurityGroup)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "PARENTOID":  oReturn = this.ParentOid; break;
                    case "SECURITYPWDRULEOID":  oReturn = this.SecurityPwdRuleOid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "CONSTANT":  oReturn = this.Constant; break;
                    case "DESCRIPTION":  oReturn = this.Description; break;
                    case "ISADMIN":  oReturn = this.IsAdmin; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                    case "NAVMENU_JSON":  oReturn = this.NavMenu_JSON; break;
                    case "CREATEDBY":  oReturn = this.CreatedBy; break;
                    case "CREATEDON":  oReturn = this.CreatedOn; break;
                    case "MODIFIEDBY":  oReturn = this.ModifiedBy; break;
                    case "MODIFIEDON":  oReturn = this.ModifiedOn; break;
                    case "VERSION":  oReturn = this.Version; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "PARENTOID":  this.ParentOid = (long?)value;  break;
                case "SECURITYPWDRULEOID":  this.SecurityPwdRuleOid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "CONSTANT":  this.Constant = (string)value;  break;
                case "DESCRIPTION":  this.Description = (string)value;  break;
                case "ISADMIN":  this.IsAdmin = (bool)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                case "NAVMENU_JSON":  this.NavMenu_JSON = (string)value;  break;
                case "CREATEDBY":  this.CreatedBy = (string)value;  break;
                case "CREATEDON":  this.CreatedOn = (DateTime)value;  break;
                case "MODIFIEDBY":  this.ModifiedBy = (string)value;  break;
                case "MODIFIEDON":  this.ModifiedOn = (DateTime)value;  break;
                case "VERSION":  this.Version = (int)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("SecurityPwdRule")]
    [PrimaryKey("Oid")]
    public partial class SecurityPwdRule : Record<SecurityPwdRule>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("UserCanChangePwd")]
        public bool UserCanChangePwd { get; set; }
        [Column("PwdNeverExpires")]
        public bool PwdNeverExpires { get; set; }
        [Column("UserMustChangePwd")]
        public bool UserMustChangePwd { get; set; }
        [Column("DaysPasswordIsValid")]
        public int DaysPasswordIsValid { get; set; }
        [Column("MaxLoginAttemptsAllowed")]
        public int MaxLoginAttemptsAllowed { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public SecurityPwdRule ShallowClone(){ return (SecurityPwdRule)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "USERCANCHANGEPWD":  oReturn = this.UserCanChangePwd; break;
                    case "PWDNEVEREXPIRES":  oReturn = this.PwdNeverExpires; break;
                    case "USERMUSTCHANGEPWD":  oReturn = this.UserMustChangePwd; break;
                    case "DAYSPASSWORDISVALID":  oReturn = this.DaysPasswordIsValid; break;
                    case "MAXLOGINATTEMPTSALLOWED":  oReturn = this.MaxLoginAttemptsAllowed; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "USERCANCHANGEPWD":  this.UserCanChangePwd = (bool)value;  break;
                case "PWDNEVEREXPIRES":  this.PwdNeverExpires = (bool)value;  break;
                case "USERMUSTCHANGEPWD":  this.UserMustChangePwd = (bool)value;  break;
                case "DAYSPASSWORDISVALID":  this.DaysPasswordIsValid = (int)value;  break;
                case "MAXLOGINATTEMPTSALLOWED":  this.MaxLoginAttemptsAllowed = (int)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("SequenceItem")]
    [PrimaryKey("Oid")]
    public partial class SequenceItem : Record<SequenceItem>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ParentOid")]
        public long? ParentOid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("ListingOid")]
        public long ListingOid { get; set; }
        [Column("lkpSequenceTypeOid")]
        public long lkpSequenceTypeOid { get; set; }
        [Column("lkpCheckListStatusOid")]
        public long lkpCheckListStatusOid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("InfoUrl")]
        public string InfoUrl { get; set; }
        [Column("DateCompleted")]
        public DateTime? DateCompleted { get; set; }
        [Column("Seq")]
        public decimal Seq { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public SequenceItem ShallowClone(){ return (SequenceItem)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "PARENTOID":  oReturn = this.ParentOid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "LISTINGOID":  oReturn = this.ListingOid; break;
                    case "LKPSEQUENCETYPEOID":  oReturn = this.lkpSequenceTypeOid; break;
                    case "LKPCHECKLISTSTATUSOID":  oReturn = this.lkpCheckListStatusOid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "INFOURL":  oReturn = this.InfoUrl; break;
                    case "DATECOMPLETED":  oReturn = this.DateCompleted; break;
                    case "SEQ":  oReturn = this.Seq; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "PARENTOID":  this.ParentOid = (long?)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "LISTINGOID":  this.ListingOid = (long)value;  break;
                case "LKPSEQUENCETYPEOID":  this.lkpSequenceTypeOid = (long)value;  break;
                case "LKPCHECKLISTSTATUSOID":  this.lkpCheckListStatusOid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "INFOURL":  this.InfoUrl = (string)value;  break;
                case "DATECOMPLETED":  this.DateCompleted = (DateTime?)value;  break;
                case "SEQ":  this.Seq = (decimal)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("TextAttachment")]
    [PrimaryKey("Oid")]
    public partial class TextAttachment : Record<TextAttachment>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("TextMessageOid")]
        public long TextMessageOid { get; set; }
        [Column("lkpFileTypeOid")]
        public long lkpFileTypeOid { get; set; }
        [Column("FilePath")]
        public string FilePath { get; set; }
        [Column("ThumbnailFilePath")]
        public string ThumbnailFilePath { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public TextAttachment ShallowClone(){ return (TextAttachment)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "TEXTMESSAGEOID":  oReturn = this.TextMessageOid; break;
                    case "LKPFILETYPEOID":  oReturn = this.lkpFileTypeOid; break;
                    case "FILEPATH":  oReturn = this.FilePath; break;
                    case "THUMBNAILFILEPATH":  oReturn = this.ThumbnailFilePath; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "TEXTMESSAGEOID":  this.TextMessageOid = (long)value;  break;
                case "LKPFILETYPEOID":  this.lkpFileTypeOid = (long)value;  break;
                case "FILEPATH":  this.FilePath = (string)value;  break;
                case "THUMBNAILFILEPATH":  this.ThumbnailFilePath = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("TextChannel")]
    [PrimaryKey("Oid")]
    public partial class TextChannel : Record<TextChannel>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("TextGroupOid")]
        public long TextGroupOid { get; set; }
        [Column("TwilliId")]
        public string TwilliId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Avatar")]
        public string Avatar { get; set; }
        [Column("LastCommunicationDate")]
        public DateTime LastCommunicationDate { get; set; }
        [Column("HasUnreadMessages")]
        public bool? HasUnreadMessages { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public TextChannel ShallowClone(){ return (TextChannel)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "TEXTGROUPOID":  oReturn = this.TextGroupOid; break;
                    case "TWILLIID":  oReturn = this.TwilliId; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "AVATAR":  oReturn = this.Avatar; break;
                    case "LASTCOMMUNICATIONDATE":  oReturn = this.LastCommunicationDate; break;
                    case "HASUNREADMESSAGES":  oReturn = this.HasUnreadMessages; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "TEXTGROUPOID":  this.TextGroupOid = (long)value;  break;
                case "TWILLIID":  this.TwilliId = (string)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "AVATAR":  this.Avatar = (string)value;  break;
                case "LASTCOMMUNICATIONDATE":  this.LastCommunicationDate = (DateTime)value;  break;
                case "HASUNREADMESSAGES":  this.HasUnreadMessages = (bool?)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("TextGroup")]
    [PrimaryKey("Oid")]
    public partial class TextGroup : Record<TextGroup>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ParentOid")]
        public long? ParentOid { get; set; }
        [Column("EntityOid")]
        public long? EntityOid { get; set; }
        [Column("EntityOid_Master")]
        public long? EntityOid_Master { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("HasMessages")]
        public bool? HasMessages { get; set; }
        [Column("HasUnreadMessages")]
        public bool? HasUnreadMessages { get; set; }
        [Column("Sort")]
        public decimal? Sort { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public TextGroup ShallowClone(){ return (TextGroup)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "PARENTOID":  oReturn = this.ParentOid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "ENTITYOID_MASTER":  oReturn = this.EntityOid_Master; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "HASMESSAGES":  oReturn = this.HasMessages; break;
                    case "HASUNREADMESSAGES":  oReturn = this.HasUnreadMessages; break;
                    case "SORT":  oReturn = this.Sort; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "PARENTOID":  this.ParentOid = (long?)value;  break;
                case "ENTITYOID":  this.EntityOid = (long?)value;  break;
                case "ENTITYOID_MASTER":  this.EntityOid_Master = (long?)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "HASMESSAGES":  this.HasMessages = (bool?)value;  break;
                case "HASUNREADMESSAGES":  this.HasUnreadMessages = (bool?)value;  break;
                case "SORT":  this.Sort = (decimal?)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("TextInvitation")]
    [PrimaryKey("Oid")]
    public partial class TextInvitation : Record<TextInvitation>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("TextMessageOid")]
        public long TextMessageOid { get; set; }
        [Column("EntityOid_Host")]
        public long EntityOid_Host { get; set; }
        [Column("lkpEventTypeOid")]
        public long lkpEventTypeOid { get; set; }
        [Column("Date")]
        public DateTime? Date { get; set; }
        [Column("RsvpBy")]
        public DateTime RsvpBy { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public TextInvitation ShallowClone(){ return (TextInvitation)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "TEXTMESSAGEOID":  oReturn = this.TextMessageOid; break;
                    case "ENTITYOID_HOST":  oReturn = this.EntityOid_Host; break;
                    case "LKPEVENTTYPEOID":  oReturn = this.lkpEventTypeOid; break;
                    case "DATE":  oReturn = this.Date; break;
                    case "RSVPBY":  oReturn = this.RsvpBy; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "TEXTMESSAGEOID":  this.TextMessageOid = (long)value;  break;
                case "ENTITYOID_HOST":  this.EntityOid_Host = (long)value;  break;
                case "LKPEVENTTYPEOID":  this.lkpEventTypeOid = (long)value;  break;
                case "DATE":  this.Date = (DateTime?)value;  break;
                case "RSVPBY":  this.RsvpBy = (DateTime)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("TextMessage")]
    [PrimaryKey("Oid")]
    public partial class TextMessage : Record<TextMessage>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("TextChannelOid")]
        public long TextChannelOid { get; set; }
        [Column("lkpMessageTypeOid")]
        public long lkpMessageTypeOid { get; set; }
        [Column("Message")]
        public string Message { get; set; }
        [Column("DateSent")]
        public DateTime DateSent { get; set; }
        [Column("SentBy")]
        public string SentBy { get; set; }
        [Column("SentByOid")]
        public long SentByOid { get; set; }
        [Column("IsEdited")]
        public bool IsEdited { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public TextMessage ShallowClone(){ return (TextMessage)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "TEXTCHANNELOID":  oReturn = this.TextChannelOid; break;
                    case "LKPMESSAGETYPEOID":  oReturn = this.lkpMessageTypeOid; break;
                    case "MESSAGE":  oReturn = this.Message; break;
                    case "DATESENT":  oReturn = this.DateSent; break;
                    case "SENTBY":  oReturn = this.SentBy; break;
                    case "SENTBYOID":  oReturn = this.SentByOid; break;
                    case "ISEDITED":  oReturn = this.IsEdited; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "TEXTCHANNELOID":  this.TextChannelOid = (long)value;  break;
                case "LKPMESSAGETYPEOID":  this.lkpMessageTypeOid = (long)value;  break;
                case "MESSAGE":  this.Message = (string)value;  break;
                case "DATESENT":  this.DateSent = (DateTime)value;  break;
                case "SENTBY":  this.SentBy = (string)value;  break;
                case "SENTBYOID":  this.SentByOid = (long)value;  break;
                case "ISEDITED":  this.IsEdited = (bool)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("TextMessageAction")]
    [PrimaryKey("Oid")]
    public partial class TextMessageAction : Record<TextMessageAction>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("TextMessageOid")]
        public long TextMessageOid { get; set; }
        [Column("TextRecipientOid")]
        public long TextRecipientOid { get; set; }
        [Column("IsRead")]
        public bool IsRead { get; set; }
        [Column("IsDeletedByUser")]
        public bool IsDeletedByUser { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public TextMessageAction ShallowClone(){ return (TextMessageAction)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "TEXTMESSAGEOID":  oReturn = this.TextMessageOid; break;
                    case "TEXTRECIPIENTOID":  oReturn = this.TextRecipientOid; break;
                    case "ISREAD":  oReturn = this.IsRead; break;
                    case "ISDELETEDBYUSER":  oReturn = this.IsDeletedByUser; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "TEXTMESSAGEOID":  this.TextMessageOid = (long)value;  break;
                case "TEXTRECIPIENTOID":  this.TextRecipientOid = (long)value;  break;
                case "ISREAD":  this.IsRead = (bool)value;  break;
                case "ISDELETEDBYUSER":  this.IsDeletedByUser = (bool)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("TextRecipient")]
    [PrimaryKey("Oid")]
    public partial class TextRecipient : Record<TextRecipient>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("TextChannelOid")]
        public long TextChannelOid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("TextInvitationOid")]
        public long? TextInvitationOid { get; set; }
        [Column("ChannelName")]
        public string ChannelName { get; set; }
        [Column("OptOut")]
        public bool OptOut { get; set; }
        [Column("IsInvite")]
        public bool? IsInvite { get; set; }
        [Column("Rsvp")]
        public bool? Rsvp { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public TextRecipient ShallowClone(){ return (TextRecipient)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "TEXTCHANNELOID":  oReturn = this.TextChannelOid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "TEXTINVITATIONOID":  oReturn = this.TextInvitationOid; break;
                    case "CHANNELNAME":  oReturn = this.ChannelName; break;
                    case "OPTOUT":  oReturn = this.OptOut; break;
                    case "ISINVITE":  oReturn = this.IsInvite; break;
                    case "RSVP":  oReturn = this.Rsvp; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "TEXTCHANNELOID":  this.TextChannelOid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "TEXTINVITATIONOID":  this.TextInvitationOid = (long?)value;  break;
                case "CHANNELNAME":  this.ChannelName = (string)value;  break;
                case "OPTOUT":  this.OptOut = (bool)value;  break;
                case "ISINVITE":  this.IsInvite = (bool?)value;  break;
                case "RSVP":  this.Rsvp = (bool?)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Whse_ListingStat")]
    [PrimaryKey("Oid")]
    public partial class Whse_ListingStat : Record<Whse_ListingStat>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ListingOid")]
        public long ListingOid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("EntityOid_Master")]
        public long EntityOid_Master { get; set; }
        [Column("EntityOid_Region")]
        public long EntityOid_Region { get; set; }
        [Column("EntityOid_Office")]
        public long EntityOid_Office { get; set; }
        [Column("CompanyName")]
        public string CompanyName { get; set; }
        [Column("AdTitle")]
        public string AdTitle { get; set; }
        [Column("AdTagLine")]
        public string AdTagLine { get; set; }
        [Column("Views")]
        public int Views { get; set; }
        [Column("Views_LastLook")]
        public int Views_LastLook { get; set; }
        [Column("ViewsLast3Months")]
        public int ViewsLast3Months { get; set; }
        [Column("ViewsLastMonth")]
        public int ViewsLastMonth { get; set; }
        [Column("ViewsLast7Days")]
        public int ViewsLast7Days { get; set; }
        [Column("ViewsLast24Hrs")]
        public int ViewsLast24Hrs { get; set; }
        [Column("Clicks")]
        public int Clicks { get; set; }
        [Column("Clicks_LastLook")]
        public int Clicks_LastLook { get; set; }
        [Column("ClicksLast3Months")]
        public int ClicksLast3Months { get; set; }
        [Column("ClicksLastMonth")]
        public int ClicksLastMonth { get; set; }
        [Column("ClicksLast7Days")]
        public int ClicksLast7Days { get; set; }
        [Column("ClicksLast24Hrs")]
        public int ClicksLast24Hrs { get; set; }
        [Column("Favorited")]
        public int Favorited { get; set; }
        [Column("Favorited_LastLook")]
        public int Favorited_LastLook { get; set; }
        [Column("FavoritedLast3Months")]
        public int FavoritedLast3Months { get; set; }
        [Column("FavoritedLastMonth")]
        public int FavoritedLastMonth { get; set; }
        [Column("FavoritedLast7Days")]
        public int FavoritedLast7Days { get; set; }
        [Column("FavoritedLast24Hrs")]
        public int FavoritedLast24Hrs { get; set; }
        [Column("ContactRequests")]
        public int ContactRequests { get; set; }
        [Column("ContactRequests_LastLook")]
        public int ContactRequests_LastLook { get; set; }
        [Column("ContactRequestsLast3Months")]
        public int ContactRequestsLast3Months { get; set; }
        [Column("ContactRequestsLastMonth")]
        public int ContactRequestsLastMonth { get; set; }
        [Column("ContactRequestsLast7Days")]
        public int ContactRequestsLast7Days { get; set; }
        [Column("ContactRequestsLast24Hrs")]
        public int ContactRequestsLast24Hrs { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Whse_ListingStat ShallowClone(){ return (Whse_ListingStat)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "LISTINGOID":  oReturn = this.ListingOid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "ENTITYOID_MASTER":  oReturn = this.EntityOid_Master; break;
                    case "ENTITYOID_REGION":  oReturn = this.EntityOid_Region; break;
                    case "ENTITYOID_OFFICE":  oReturn = this.EntityOid_Office; break;
                    case "COMPANYNAME":  oReturn = this.CompanyName; break;
                    case "ADTITLE":  oReturn = this.AdTitle; break;
                    case "ADTAGLINE":  oReturn = this.AdTagLine; break;
                    case "VIEWS":  oReturn = this.Views; break;
                    case "VIEWS_LASTLOOK":  oReturn = this.Views_LastLook; break;
                    case "VIEWSLAST3MONTHS":  oReturn = this.ViewsLast3Months; break;
                    case "VIEWSLASTMONTH":  oReturn = this.ViewsLastMonth; break;
                    case "VIEWSLAST7DAYS":  oReturn = this.ViewsLast7Days; break;
                    case "VIEWSLAST24HRS":  oReturn = this.ViewsLast24Hrs; break;
                    case "CLICKS":  oReturn = this.Clicks; break;
                    case "CLICKS_LASTLOOK":  oReturn = this.Clicks_LastLook; break;
                    case "CLICKSLAST3MONTHS":  oReturn = this.ClicksLast3Months; break;
                    case "CLICKSLASTMONTH":  oReturn = this.ClicksLastMonth; break;
                    case "CLICKSLAST7DAYS":  oReturn = this.ClicksLast7Days; break;
                    case "CLICKSLAST24HRS":  oReturn = this.ClicksLast24Hrs; break;
                    case "FAVORITED":  oReturn = this.Favorited; break;
                    case "FAVORITED_LASTLOOK":  oReturn = this.Favorited_LastLook; break;
                    case "FAVORITEDLAST3MONTHS":  oReturn = this.FavoritedLast3Months; break;
                    case "FAVORITEDLASTMONTH":  oReturn = this.FavoritedLastMonth; break;
                    case "FAVORITEDLAST7DAYS":  oReturn = this.FavoritedLast7Days; break;
                    case "FAVORITEDLAST24HRS":  oReturn = this.FavoritedLast24Hrs; break;
                    case "CONTACTREQUESTS":  oReturn = this.ContactRequests; break;
                    case "CONTACTREQUESTS_LASTLOOK":  oReturn = this.ContactRequests_LastLook; break;
                    case "CONTACTREQUESTSLAST3MONTHS":  oReturn = this.ContactRequestsLast3Months; break;
                    case "CONTACTREQUESTSLASTMONTH":  oReturn = this.ContactRequestsLastMonth; break;
                    case "CONTACTREQUESTSLAST7DAYS":  oReturn = this.ContactRequestsLast7Days; break;
                    case "CONTACTREQUESTSLAST24HRS":  oReturn = this.ContactRequestsLast24Hrs; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "LISTINGOID":  this.ListingOid = (long)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "ENTITYOID_MASTER":  this.EntityOid_Master = (long)value;  break;
                case "ENTITYOID_REGION":  this.EntityOid_Region = (long)value;  break;
                case "ENTITYOID_OFFICE":  this.EntityOid_Office = (long)value;  break;
                case "COMPANYNAME":  this.CompanyName = (string)value;  break;
                case "ADTITLE":  this.AdTitle = (string)value;  break;
                case "ADTAGLINE":  this.AdTagLine = (string)value;  break;
                case "VIEWS":  this.Views = (int)value;  break;
                case "VIEWS_LASTLOOK":  this.Views_LastLook = (int)value;  break;
                case "VIEWSLAST3MONTHS":  this.ViewsLast3Months = (int)value;  break;
                case "VIEWSLASTMONTH":  this.ViewsLastMonth = (int)value;  break;
                case "VIEWSLAST7DAYS":  this.ViewsLast7Days = (int)value;  break;
                case "VIEWSLAST24HRS":  this.ViewsLast24Hrs = (int)value;  break;
                case "CLICKS":  this.Clicks = (int)value;  break;
                case "CLICKS_LASTLOOK":  this.Clicks_LastLook = (int)value;  break;
                case "CLICKSLAST3MONTHS":  this.ClicksLast3Months = (int)value;  break;
                case "CLICKSLASTMONTH":  this.ClicksLastMonth = (int)value;  break;
                case "CLICKSLAST7DAYS":  this.ClicksLast7Days = (int)value;  break;
                case "CLICKSLAST24HRS":  this.ClicksLast24Hrs = (int)value;  break;
                case "FAVORITED":  this.Favorited = (int)value;  break;
                case "FAVORITED_LASTLOOK":  this.Favorited_LastLook = (int)value;  break;
                case "FAVORITEDLAST3MONTHS":  this.FavoritedLast3Months = (int)value;  break;
                case "FAVORITEDLASTMONTH":  this.FavoritedLastMonth = (int)value;  break;
                case "FAVORITEDLAST7DAYS":  this.FavoritedLast7Days = (int)value;  break;
                case "FAVORITEDLAST24HRS":  this.FavoritedLast24Hrs = (int)value;  break;
                case "CONTACTREQUESTS":  this.ContactRequests = (int)value;  break;
                case "CONTACTREQUESTS_LASTLOOK":  this.ContactRequests_LastLook = (int)value;  break;
                case "CONTACTREQUESTSLAST3MONTHS":  this.ContactRequestsLast3Months = (int)value;  break;
                case "CONTACTREQUESTSLASTMONTH":  this.ContactRequestsLastMonth = (int)value;  break;
                case "CONTACTREQUESTSLAST7DAYS":  this.ContactRequestsLast7Days = (int)value;  break;
                case "CONTACTREQUESTSLAST24HRS":  this.ContactRequestsLast24Hrs = (int)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("Whse_RunSearchArchive")]
    [PrimaryKey("Oid")]
    public partial class Whse_RunSearchArchive : Record<Whse_RunSearchArchive>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("SearchCriteriaOid")]
        public long? SearchCriteriaOid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("lkpCountryOid")]
        public long lkpCountryOid { get; set; }
        [Column("lkpStateOid")]
        public long lkpStateOid { get; set; }
        [Column("lkpCountyOids")]
        public string lkpCountyOids { get; set; }
        [Column("lkpCityOids")]
        public string lkpCityOids { get; set; }
        [Column("ZipCode")]
        public string ZipCode { get; set; }
        [Column("ZipCodes")]
        public string ZipCodes { get; set; }
        [Column("SearchRadius")]
        public int? SearchRadius { get; set; }
        [Column("lkpBusinessCategoryOids")]
        public string lkpBusinessCategoryOids { get; set; }
        [Column("Keywords")]
        public string Keywords { get; set; }
        [Column("Street")]
        public string Street { get; set; }
        [Column("ListingPrice_From")]
        public decimal? ListingPrice_From { get; set; }
        [Column("ListingPrice_To")]
        public decimal? ListingPrice_To { get; set; }
        [Column("GrossRevenue_From")]
        public decimal? GrossRevenue_From { get; set; }
        [Column("GrossRevenue_To")]
        public decimal? GrossRevenue_To { get; set; }
        [Column("EBITDA_From")]
        public decimal? EBITDA_From { get; set; }
        [Column("EBITDA_To")]
        public decimal? EBITDA_To { get; set; }
        [Column("CashFlow_From")]
        public decimal? CashFlow_From { get; set; }
        [Column("CashFlow_To")]
        public decimal? CashFlow_To { get; set; }
        [Column("MinimumDownPayment_From")]
        public decimal? MinimumDownPayment_From { get; set; }
        [Column("MinimumDownPayment_To")]
        public decimal? MinimumDownPayment_To { get; set; }
        [Column("TotalSqFt_From")]
        public int? TotalSqFt_From { get; set; }
        [Column("TotalSqFt_To")]
        public int? TotalSqFt_To { get; set; }
        [Column("EmployeeCount_From")]
        public int? EmployeeCount_From { get; set; }
        [Column("EmployeeCount_To")]
        public int? EmployeeCount_To { get; set; }
        [Column("IsAbsenteeOwner")]
        public bool? IsAbsenteeOwner { get; set; }
        [Column("IsHomeBased")]
        public bool? IsHomeBased { get; set; }
        [Column("IsRelocatable")]
        public bool? IsRelocatable { get; set; }
        [Column("IsFranchise")]
        public bool? IsFranchise { get; set; }
        [Column("IsSellerFinanace")]
        public bool? IsSellerFinanace { get; set; }
        [Column("IsSbaPreApproved")]
        public bool? IsSbaPreApproved { get; set; }
        [Column("IsRealEstateAvailable")]
        public bool? IsRealEstateAvailable { get; set; }
        [Column("IsTextNotification")]
        public bool? IsTextNotification { get; set; }
        [Column("IsEmailNotification")]
        public bool? IsEmailNotification { get; set; }
        [Column("IsEmailRecipientListQuery")]
        public bool? IsEmailRecipientListQuery { get; set; }
        [Column("LastSearchedDate")]
        public DateTime? LastSearchedDate { get; set; }
        [Column("NewListingsSinceLastSearchDate")]
        public int NewListingsSinceLastSearchDate { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("ListingCount")]
        public int? ListingCount { get; set; }
        [Column("RunDate")]
        public DateTime? RunDate { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public Whse_RunSearchArchive ShallowClone(){ return (Whse_RunSearchArchive)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "SEARCHCRITERIAOID":  oReturn = this.SearchCriteriaOid; break;
                    case "ENTITYOID":  oReturn = this.EntityOid; break;
                    case "NAME":  oReturn = this.Name; break;
                    case "LKPCOUNTRYOID":  oReturn = this.lkpCountryOid; break;
                    case "LKPSTATEOID":  oReturn = this.lkpStateOid; break;
                    case "LKPCOUNTYOIDS":  oReturn = this.lkpCountyOids; break;
                    case "LKPCITYOIDS":  oReturn = this.lkpCityOids; break;
                    case "ZIPCODE":  oReturn = this.ZipCode; break;
                    case "ZIPCODES":  oReturn = this.ZipCodes; break;
                    case "SEARCHRADIUS":  oReturn = this.SearchRadius; break;
                    case "LKPBUSINESSCATEGORYOIDS":  oReturn = this.lkpBusinessCategoryOids; break;
                    case "KEYWORDS":  oReturn = this.Keywords; break;
                    case "STREET":  oReturn = this.Street; break;
                    case "LISTINGPRICE_FROM":  oReturn = this.ListingPrice_From; break;
                    case "LISTINGPRICE_TO":  oReturn = this.ListingPrice_To; break;
                    case "GROSSREVENUE_FROM":  oReturn = this.GrossRevenue_From; break;
                    case "GROSSREVENUE_TO":  oReturn = this.GrossRevenue_To; break;
                    case "EBITDA_FROM":  oReturn = this.EBITDA_From; break;
                    case "EBITDA_TO":  oReturn = this.EBITDA_To; break;
                    case "CASHFLOW_FROM":  oReturn = this.CashFlow_From; break;
                    case "CASHFLOW_TO":  oReturn = this.CashFlow_To; break;
                    case "MINIMUMDOWNPAYMENT_FROM":  oReturn = this.MinimumDownPayment_From; break;
                    case "MINIMUMDOWNPAYMENT_TO":  oReturn = this.MinimumDownPayment_To; break;
                    case "TOTALSQFT_FROM":  oReturn = this.TotalSqFt_From; break;
                    case "TOTALSQFT_TO":  oReturn = this.TotalSqFt_To; break;
                    case "EMPLOYEECOUNT_FROM":  oReturn = this.EmployeeCount_From; break;
                    case "EMPLOYEECOUNT_TO":  oReturn = this.EmployeeCount_To; break;
                    case "ISABSENTEEOWNER":  oReturn = this.IsAbsenteeOwner; break;
                    case "ISHOMEBASED":  oReturn = this.IsHomeBased; break;
                    case "ISRELOCATABLE":  oReturn = this.IsRelocatable; break;
                    case "ISFRANCHISE":  oReturn = this.IsFranchise; break;
                    case "ISSELLERFINANACE":  oReturn = this.IsSellerFinanace; break;
                    case "ISSBAPREAPPROVED":  oReturn = this.IsSbaPreApproved; break;
                    case "ISREALESTATEAVAILABLE":  oReturn = this.IsRealEstateAvailable; break;
                    case "ISTEXTNOTIFICATION":  oReturn = this.IsTextNotification; break;
                    case "ISEMAILNOTIFICATION":  oReturn = this.IsEmailNotification; break;
                    case "ISEMAILRECIPIENTLISTQUERY":  oReturn = this.IsEmailRecipientListQuery; break;
                    case "LASTSEARCHEDDATE":  oReturn = this.LastSearchedDate; break;
                    case "NEWLISTINGSSINCELASTSEARCHDATE":  oReturn = this.NewListingsSinceLastSearchDate; break;
                    case "ISACTIVE":  oReturn = this.IsActive; break;
                    case "LISTINGCOUNT":  oReturn = this.ListingCount; break;
                    case "RUNDATE":  oReturn = this.RunDate; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "SEARCHCRITERIAOID":  this.SearchCriteriaOid = (long?)value;  break;
                case "ENTITYOID":  this.EntityOid = (long)value;  break;
                case "NAME":  this.Name = (string)value;  break;
                case "LKPCOUNTRYOID":  this.lkpCountryOid = (long)value;  break;
                case "LKPSTATEOID":  this.lkpStateOid = (long)value;  break;
                case "LKPCOUNTYOIDS":  this.lkpCountyOids = (string)value;  break;
                case "LKPCITYOIDS":  this.lkpCityOids = (string)value;  break;
                case "ZIPCODE":  this.ZipCode = (string)value;  break;
                case "ZIPCODES":  this.ZipCodes = (string)value;  break;
                case "SEARCHRADIUS":  this.SearchRadius = (int?)value;  break;
                case "LKPBUSINESSCATEGORYOIDS":  this.lkpBusinessCategoryOids = (string)value;  break;
                case "KEYWORDS":  this.Keywords = (string)value;  break;
                case "STREET":  this.Street = (string)value;  break;
                case "LISTINGPRICE_FROM":  this.ListingPrice_From = (decimal?)value;  break;
                case "LISTINGPRICE_TO":  this.ListingPrice_To = (decimal?)value;  break;
                case "GROSSREVENUE_FROM":  this.GrossRevenue_From = (decimal?)value;  break;
                case "GROSSREVENUE_TO":  this.GrossRevenue_To = (decimal?)value;  break;
                case "EBITDA_FROM":  this.EBITDA_From = (decimal?)value;  break;
                case "EBITDA_TO":  this.EBITDA_To = (decimal?)value;  break;
                case "CASHFLOW_FROM":  this.CashFlow_From = (decimal?)value;  break;
                case "CASHFLOW_TO":  this.CashFlow_To = (decimal?)value;  break;
                case "MINIMUMDOWNPAYMENT_FROM":  this.MinimumDownPayment_From = (decimal?)value;  break;
                case "MINIMUMDOWNPAYMENT_TO":  this.MinimumDownPayment_To = (decimal?)value;  break;
                case "TOTALSQFT_FROM":  this.TotalSqFt_From = (int?)value;  break;
                case "TOTALSQFT_TO":  this.TotalSqFt_To = (int?)value;  break;
                case "EMPLOYEECOUNT_FROM":  this.EmployeeCount_From = (int?)value;  break;
                case "EMPLOYEECOUNT_TO":  this.EmployeeCount_To = (int?)value;  break;
                case "ISABSENTEEOWNER":  this.IsAbsenteeOwner = (bool?)value;  break;
                case "ISHOMEBASED":  this.IsHomeBased = (bool?)value;  break;
                case "ISRELOCATABLE":  this.IsRelocatable = (bool?)value;  break;
                case "ISFRANCHISE":  this.IsFranchise = (bool?)value;  break;
                case "ISSELLERFINANACE":  this.IsSellerFinanace = (bool?)value;  break;
                case "ISSBAPREAPPROVED":  this.IsSbaPreApproved = (bool?)value;  break;
                case "ISREALESTATEAVAILABLE":  this.IsRealEstateAvailable = (bool?)value;  break;
                case "ISTEXTNOTIFICATION":  this.IsTextNotification = (bool?)value;  break;
                case "ISEMAILNOTIFICATION":  this.IsEmailNotification = (bool?)value;  break;
                case "ISEMAILRECIPIENTLISTQUERY":  this.IsEmailRecipientListQuery = (bool?)value;  break;
                case "LASTSEARCHEDDATE":  this.LastSearchedDate = (DateTime?)value;  break;
                case "NEWLISTINGSSINCELASTSEARCHDATE":  this.NewListingsSinceLastSearchDate = (int)value;  break;
                case "ISACTIVE":  this.IsActive = (bool)value;  break;
                case "LISTINGCOUNT":  this.ListingCount = (int?)value;  break;
                case "RUNDATE":  this.RunDate = (DateTime?)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("ZC")]
    [PrimaryKey("Oid")]
    public partial class ZC : Record<ZC>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ZipCode")]
        public string ZipCode { get; set; }
        [Column("PrimaryRecord")]
        public string PrimaryRecord { get; set; }
        [Column("Population")]
        public int? Population { get; set; }
        [Column("HouseholdsPerZipcode")]
        public int? HouseholdsPerZipcode { get; set; }
        [Column("WhitePopulation")]
        public int? WhitePopulation { get; set; }
        [Column("BlackPopulation")]
        public int? BlackPopulation { get; set; }
        [Column("HispanicPopulation")]
        public int? HispanicPopulation { get; set; }
        [Column("AsianPopulation")]
        public int? AsianPopulation { get; set; }
        [Column("HawaiianPopulation")]
        public int? HawaiianPopulation { get; set; }
        [Column("IndianPopulation")]
        public int? IndianPopulation { get; set; }
        [Column("OtherPopulation")]
        public int? OtherPopulation { get; set; }
        [Column("MalePopulation")]
        public int? MalePopulation { get; set; }
        [Column("FemalePopulation")]
        public int? FemalePopulation { get; set; }
        [Column("PersonsPerHousehold")]
        public decimal? PersonsPerHousehold { get; set; }
        [Column("AverageHouseValue")]
        public int? AverageHouseValue { get; set; }
        [Column("IncomePerHousehold")]
        public int? IncomePerHousehold { get; set; }
        [Column("MedianAge")]
        public decimal? MedianAge { get; set; }
        [Column("MedianAgeMale")]
        public decimal? MedianAgeMale { get; set; }
        [Column("MedianAgeFemale")]
        public decimal? MedianAgeFemale { get; set; }
        [Column("Latitude")]
        public decimal? Latitude { get; set; }
        [Column("Longitude")]
        public decimal? Longitude { get; set; }
        [Column("Elevation")]
        public int? Elevation { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("StateFullName")]
        public string StateFullName { get; set; }
        [Column("CityType")]
        public string CityType { get; set; }
        [Column("CityAliasAbbreviation")]
        public string CityAliasAbbreviation { get; set; }
        [Column("AreaCode")]
        public string AreaCode { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("CityAliasName")]
        public string CityAliasName { get; set; }
        [Column("County")]
        public string County { get; set; }
        [Column("CountyFIPS")]
        public string CountyFIPS { get; set; }
        [Column("StateFIPS")]
        public string StateFIPS { get; set; }
        [Column("TimeZone")]
        public string TimeZone { get; set; }
        [Column("DayLightSaving")]
        public string DayLightSaving { get; set; }
        [Column("MSA")]
        public string MSA { get; set; }
        [Column("PMSA")]
        public string PMSA { get; set; }
        [Column("CSA")]
        public string CSA { get; set; }
        [Column("CBSA")]
        public string CBSA { get; set; }
        [Column("CBSA_DIV")]
        public string CBSA_DIV { get; set; }
        [Column("CBSA_Type")]
        public string CBSA_Type { get; set; }
        [Column("CBSA_Name")]
        public string CBSA_Name { get; set; }
        [Column("MSA_Name")]
        public string MSA_Name { get; set; }
        [Column("PMSA_Name")]
        public string PMSA_Name { get; set; }
        [Column("Region")]
        public string Region { get; set; }
        [Column("Division")]
        public string Division { get; set; }
        [Column("MailingName")]
        public string MailingName { get; set; }
        [Column("NumberOfBusinesses")]
        public int? NumberOfBusinesses { get; set; }
        [Column("NumberOfEmployees")]
        public int? NumberOfEmployees { get; set; }
        [Column("BusinessFirstQuarterPayroll")]
        public int? BusinessFirstQuarterPayroll { get; set; }
        [Column("BusinessAnnualPayroll")]
        public int? BusinessAnnualPayroll { get; set; }
        [Column("BusinessEmploymentFlag")]
        public string BusinessEmploymentFlag { get; set; }
        [Column("GrowthRank")]
        public int? GrowthRank { get; set; }
        [Column("GrowingCountiesA")]
        public int? GrowingCountiesA { get; set; }
        [Column("GrowingCountiesB")]
        public int? GrowingCountiesB { get; set; }
        [Column("GrowthIncreaseNumber")]
        public int? GrowthIncreaseNumber { get; set; }
        [Column("GrowthIncreasePercentage")]
        public decimal? GrowthIncreasePercentage { get; set; }
        [Column("CBSAPopulation")]
        public int? CBSAPopulation { get; set; }
        [Column("CBSADivisionPopulation")]
        public int? CBSADivisionPopulation { get; set; }
        [Column("CongressionalDistrict")]
        public string CongressionalDistrict { get; set; }
        [Column("CongressionalLandArea")]
        public string CongressionalLandArea { get; set; }
        [Column("DeliveryResidential")]
        public int? DeliveryResidential { get; set; }
        [Column("DeliveryBusiness")]
        public int? DeliveryBusiness { get; set; }
        [Column("DeliveryTotal")]
        public int? DeliveryTotal { get; set; }
        [Column("PreferredLastLineKey")]
        public string PreferredLastLineKey { get; set; }
        [Column("ClassificationCode")]
        public string ClassificationCode { get; set; }
        [Column("MultiCounty")]
        public string MultiCounty { get; set; }
        [Column("CSAName")]
        public string CSAName { get; set; }
        [Column("CBSA_DIV_Name")]
        public string CBSA_DIV_Name { get; set; }
        [Column("CityStateKey")]
        public string CityStateKey { get; set; }
        [Column("PopulationEstimate")]
        public int? PopulationEstimate { get; set; }
        [Column("LandArea")]
        public decimal? LandArea { get; set; }
        [Column("WaterArea")]
        public decimal? WaterArea { get; set; }
        [Column("CityAliasCode")]
        public string CityAliasCode { get; set; }
        [Column("CityMixedCase")]
        public string CityMixedCase { get; set; }
        [Column("CityAliasMixedCase")]
        public string CityAliasMixedCase { get; set; }
        [Column("BoxCount")]
        public int? BoxCount { get; set; }
        [Column("SFDU")]
        public int? SFDU { get; set; }
        [Column("MFDU")]
        public int? MFDU { get; set; }
        [Column("StateANSI")]
        public string StateANSI { get; set; }
        [Column("CountyANSI")]
        public string CountyANSI { get; set; }
        [Column("ZIPIntroDate")]
        public string ZIPIntroDate { get; set; }
        [Column("AliasIntroDate")]
        public string AliasIntroDate { get; set; }
        [Column("FacilityCode")]
        public string FacilityCode { get; set; }
        [Column("CityDeliveryIndicator")]
        public string CityDeliveryIndicator { get; set; }
        [Column("CarrierRouteRateSortation")]
        public string CarrierRouteRateSortation { get; set; }
        [Column("FinanceNumber")]
        public string FinanceNumber { get; set; }
        [Column("UniqueZIPName")]
        public string UniqueZIPName { get; set; }
        [Column("SSAStateCountyCode")]
        public string SSAStateCountyCode { get; set; }
        [Column("MedicareCBSACode")]
        public string MedicareCBSACode { get; set; }
        [Column("MedicareCBSAName")]
        public string MedicareCBSAName { get; set; }
        [Column("MedicareCBSAType")]
        public string MedicareCBSAType { get; set; }
        [Column("MarketRatingAreaID")]
        public int? MarketRatingAreaID { get; set; }
        [Column("CountyMixedCase")]
        public string CountyMixedCase { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public ZC ShallowClone(){ return (ZC)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ZIPCODE":  oReturn = this.ZipCode; break;
                    case "PRIMARYRECORD":  oReturn = this.PrimaryRecord; break;
                    case "POPULATION":  oReturn = this.Population; break;
                    case "HOUSEHOLDSPERZIPCODE":  oReturn = this.HouseholdsPerZipcode; break;
                    case "WHITEPOPULATION":  oReturn = this.WhitePopulation; break;
                    case "BLACKPOPULATION":  oReturn = this.BlackPopulation; break;
                    case "HISPANICPOPULATION":  oReturn = this.HispanicPopulation; break;
                    case "ASIANPOPULATION":  oReturn = this.AsianPopulation; break;
                    case "HAWAIIANPOPULATION":  oReturn = this.HawaiianPopulation; break;
                    case "INDIANPOPULATION":  oReturn = this.IndianPopulation; break;
                    case "OTHERPOPULATION":  oReturn = this.OtherPopulation; break;
                    case "MALEPOPULATION":  oReturn = this.MalePopulation; break;
                    case "FEMALEPOPULATION":  oReturn = this.FemalePopulation; break;
                    case "PERSONSPERHOUSEHOLD":  oReturn = this.PersonsPerHousehold; break;
                    case "AVERAGEHOUSEVALUE":  oReturn = this.AverageHouseValue; break;
                    case "INCOMEPERHOUSEHOLD":  oReturn = this.IncomePerHousehold; break;
                    case "MEDIANAGE":  oReturn = this.MedianAge; break;
                    case "MEDIANAGEMALE":  oReturn = this.MedianAgeMale; break;
                    case "MEDIANAGEFEMALE":  oReturn = this.MedianAgeFemale; break;
                    case "LATITUDE":  oReturn = this.Latitude; break;
                    case "LONGITUDE":  oReturn = this.Longitude; break;
                    case "ELEVATION":  oReturn = this.Elevation; break;
                    case "STATE":  oReturn = this.State; break;
                    case "STATEFULLNAME":  oReturn = this.StateFullName; break;
                    case "CITYTYPE":  oReturn = this.CityType; break;
                    case "CITYALIASABBREVIATION":  oReturn = this.CityAliasAbbreviation; break;
                    case "AREACODE":  oReturn = this.AreaCode; break;
                    case "CITY":  oReturn = this.City; break;
                    case "CITYALIASNAME":  oReturn = this.CityAliasName; break;
                    case "COUNTY":  oReturn = this.County; break;
                    case "COUNTYFIPS":  oReturn = this.CountyFIPS; break;
                    case "STATEFIPS":  oReturn = this.StateFIPS; break;
                    case "TIMEZONE":  oReturn = this.TimeZone; break;
                    case "DAYLIGHTSAVING":  oReturn = this.DayLightSaving; break;
                    case "MSA":  oReturn = this.MSA; break;
                    case "PMSA":  oReturn = this.PMSA; break;
                    case "CSA":  oReturn = this.CSA; break;
                    case "CBSA":  oReturn = this.CBSA; break;
                    case "CBSA_DIV":  oReturn = this.CBSA_DIV; break;
                    case "CBSA_TYPE":  oReturn = this.CBSA_Type; break;
                    case "CBSA_NAME":  oReturn = this.CBSA_Name; break;
                    case "MSA_NAME":  oReturn = this.MSA_Name; break;
                    case "PMSA_NAME":  oReturn = this.PMSA_Name; break;
                    case "REGION":  oReturn = this.Region; break;
                    case "DIVISION":  oReturn = this.Division; break;
                    case "MAILINGNAME":  oReturn = this.MailingName; break;
                    case "NUMBEROFBUSINESSES":  oReturn = this.NumberOfBusinesses; break;
                    case "NUMBEROFEMPLOYEES":  oReturn = this.NumberOfEmployees; break;
                    case "BUSINESSFIRSTQUARTERPAYROLL":  oReturn = this.BusinessFirstQuarterPayroll; break;
                    case "BUSINESSANNUALPAYROLL":  oReturn = this.BusinessAnnualPayroll; break;
                    case "BUSINESSEMPLOYMENTFLAG":  oReturn = this.BusinessEmploymentFlag; break;
                    case "GROWTHRANK":  oReturn = this.GrowthRank; break;
                    case "GROWINGCOUNTIESA":  oReturn = this.GrowingCountiesA; break;
                    case "GROWINGCOUNTIESB":  oReturn = this.GrowingCountiesB; break;
                    case "GROWTHINCREASENUMBER":  oReturn = this.GrowthIncreaseNumber; break;
                    case "GROWTHINCREASEPERCENTAGE":  oReturn = this.GrowthIncreasePercentage; break;
                    case "CBSAPOPULATION":  oReturn = this.CBSAPopulation; break;
                    case "CBSADIVISIONPOPULATION":  oReturn = this.CBSADivisionPopulation; break;
                    case "CONGRESSIONALDISTRICT":  oReturn = this.CongressionalDistrict; break;
                    case "CONGRESSIONALLANDAREA":  oReturn = this.CongressionalLandArea; break;
                    case "DELIVERYRESIDENTIAL":  oReturn = this.DeliveryResidential; break;
                    case "DELIVERYBUSINESS":  oReturn = this.DeliveryBusiness; break;
                    case "DELIVERYTOTAL":  oReturn = this.DeliveryTotal; break;
                    case "PREFERREDLASTLINEKEY":  oReturn = this.PreferredLastLineKey; break;
                    case "CLASSIFICATIONCODE":  oReturn = this.ClassificationCode; break;
                    case "MULTICOUNTY":  oReturn = this.MultiCounty; break;
                    case "CSANAME":  oReturn = this.CSAName; break;
                    case "CBSA_DIV_NAME":  oReturn = this.CBSA_DIV_Name; break;
                    case "CITYSTATEKEY":  oReturn = this.CityStateKey; break;
                    case "POPULATIONESTIMATE":  oReturn = this.PopulationEstimate; break;
                    case "LANDAREA":  oReturn = this.LandArea; break;
                    case "WATERAREA":  oReturn = this.WaterArea; break;
                    case "CITYALIASCODE":  oReturn = this.CityAliasCode; break;
                    case "CITYMIXEDCASE":  oReturn = this.CityMixedCase; break;
                    case "CITYALIASMIXEDCASE":  oReturn = this.CityAliasMixedCase; break;
                    case "BOXCOUNT":  oReturn = this.BoxCount; break;
                    case "SFDU":  oReturn = this.SFDU; break;
                    case "MFDU":  oReturn = this.MFDU; break;
                    case "STATEANSI":  oReturn = this.StateANSI; break;
                    case "COUNTYANSI":  oReturn = this.CountyANSI; break;
                    case "ZIPINTRODATE":  oReturn = this.ZIPIntroDate; break;
                    case "ALIASINTRODATE":  oReturn = this.AliasIntroDate; break;
                    case "FACILITYCODE":  oReturn = this.FacilityCode; break;
                    case "CITYDELIVERYINDICATOR":  oReturn = this.CityDeliveryIndicator; break;
                    case "CARRIERROUTERATESORTATION":  oReturn = this.CarrierRouteRateSortation; break;
                    case "FINANCENUMBER":  oReturn = this.FinanceNumber; break;
                    case "UNIQUEZIPNAME":  oReturn = this.UniqueZIPName; break;
                    case "SSASTATECOUNTYCODE":  oReturn = this.SSAStateCountyCode; break;
                    case "MEDICARECBSACODE":  oReturn = this.MedicareCBSACode; break;
                    case "MEDICARECBSANAME":  oReturn = this.MedicareCBSAName; break;
                    case "MEDICARECBSATYPE":  oReturn = this.MedicareCBSAType; break;
                    case "MARKETRATINGAREAID":  oReturn = this.MarketRatingAreaID; break;
                    case "COUNTYMIXEDCASE":  oReturn = this.CountyMixedCase; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ZIPCODE":  this.ZipCode = (string)value;  break;
                case "PRIMARYRECORD":  this.PrimaryRecord = (string)value;  break;
                case "POPULATION":  this.Population = (int?)value;  break;
                case "HOUSEHOLDSPERZIPCODE":  this.HouseholdsPerZipcode = (int?)value;  break;
                case "WHITEPOPULATION":  this.WhitePopulation = (int?)value;  break;
                case "BLACKPOPULATION":  this.BlackPopulation = (int?)value;  break;
                case "HISPANICPOPULATION":  this.HispanicPopulation = (int?)value;  break;
                case "ASIANPOPULATION":  this.AsianPopulation = (int?)value;  break;
                case "HAWAIIANPOPULATION":  this.HawaiianPopulation = (int?)value;  break;
                case "INDIANPOPULATION":  this.IndianPopulation = (int?)value;  break;
                case "OTHERPOPULATION":  this.OtherPopulation = (int?)value;  break;
                case "MALEPOPULATION":  this.MalePopulation = (int?)value;  break;
                case "FEMALEPOPULATION":  this.FemalePopulation = (int?)value;  break;
                case "PERSONSPERHOUSEHOLD":  this.PersonsPerHousehold = (decimal?)value;  break;
                case "AVERAGEHOUSEVALUE":  this.AverageHouseValue = (int?)value;  break;
                case "INCOMEPERHOUSEHOLD":  this.IncomePerHousehold = (int?)value;  break;
                case "MEDIANAGE":  this.MedianAge = (decimal?)value;  break;
                case "MEDIANAGEMALE":  this.MedianAgeMale = (decimal?)value;  break;
                case "MEDIANAGEFEMALE":  this.MedianAgeFemale = (decimal?)value;  break;
                case "LATITUDE":  this.Latitude = (decimal?)value;  break;
                case "LONGITUDE":  this.Longitude = (decimal?)value;  break;
                case "ELEVATION":  this.Elevation = (int?)value;  break;
                case "STATE":  this.State = (string)value;  break;
                case "STATEFULLNAME":  this.StateFullName = (string)value;  break;
                case "CITYTYPE":  this.CityType = (string)value;  break;
                case "CITYALIASABBREVIATION":  this.CityAliasAbbreviation = (string)value;  break;
                case "AREACODE":  this.AreaCode = (string)value;  break;
                case "CITY":  this.City = (string)value;  break;
                case "CITYALIASNAME":  this.CityAliasName = (string)value;  break;
                case "COUNTY":  this.County = (string)value;  break;
                case "COUNTYFIPS":  this.CountyFIPS = (string)value;  break;
                case "STATEFIPS":  this.StateFIPS = (string)value;  break;
                case "TIMEZONE":  this.TimeZone = (string)value;  break;
                case "DAYLIGHTSAVING":  this.DayLightSaving = (string)value;  break;
                case "MSA":  this.MSA = (string)value;  break;
                case "PMSA":  this.PMSA = (string)value;  break;
                case "CSA":  this.CSA = (string)value;  break;
                case "CBSA":  this.CBSA = (string)value;  break;
                case "CBSA_DIV":  this.CBSA_DIV = (string)value;  break;
                case "CBSA_TYPE":  this.CBSA_Type = (string)value;  break;
                case "CBSA_NAME":  this.CBSA_Name = (string)value;  break;
                case "MSA_NAME":  this.MSA_Name = (string)value;  break;
                case "PMSA_NAME":  this.PMSA_Name = (string)value;  break;
                case "REGION":  this.Region = (string)value;  break;
                case "DIVISION":  this.Division = (string)value;  break;
                case "MAILINGNAME":  this.MailingName = (string)value;  break;
                case "NUMBEROFBUSINESSES":  this.NumberOfBusinesses = (int?)value;  break;
                case "NUMBEROFEMPLOYEES":  this.NumberOfEmployees = (int?)value;  break;
                case "BUSINESSFIRSTQUARTERPAYROLL":  this.BusinessFirstQuarterPayroll = (int?)value;  break;
                case "BUSINESSANNUALPAYROLL":  this.BusinessAnnualPayroll = (int?)value;  break;
                case "BUSINESSEMPLOYMENTFLAG":  this.BusinessEmploymentFlag = (string)value;  break;
                case "GROWTHRANK":  this.GrowthRank = (int?)value;  break;
                case "GROWINGCOUNTIESA":  this.GrowingCountiesA = (int?)value;  break;
                case "GROWINGCOUNTIESB":  this.GrowingCountiesB = (int?)value;  break;
                case "GROWTHINCREASENUMBER":  this.GrowthIncreaseNumber = (int?)value;  break;
                case "GROWTHINCREASEPERCENTAGE":  this.GrowthIncreasePercentage = (decimal?)value;  break;
                case "CBSAPOPULATION":  this.CBSAPopulation = (int?)value;  break;
                case "CBSADIVISIONPOPULATION":  this.CBSADivisionPopulation = (int?)value;  break;
                case "CONGRESSIONALDISTRICT":  this.CongressionalDistrict = (string)value;  break;
                case "CONGRESSIONALLANDAREA":  this.CongressionalLandArea = (string)value;  break;
                case "DELIVERYRESIDENTIAL":  this.DeliveryResidential = (int?)value;  break;
                case "DELIVERYBUSINESS":  this.DeliveryBusiness = (int?)value;  break;
                case "DELIVERYTOTAL":  this.DeliveryTotal = (int?)value;  break;
                case "PREFERREDLASTLINEKEY":  this.PreferredLastLineKey = (string)value;  break;
                case "CLASSIFICATIONCODE":  this.ClassificationCode = (string)value;  break;
                case "MULTICOUNTY":  this.MultiCounty = (string)value;  break;
                case "CSANAME":  this.CSAName = (string)value;  break;
                case "CBSA_DIV_NAME":  this.CBSA_DIV_Name = (string)value;  break;
                case "CITYSTATEKEY":  this.CityStateKey = (string)value;  break;
                case "POPULATIONESTIMATE":  this.PopulationEstimate = (int?)value;  break;
                case "LANDAREA":  this.LandArea = (decimal?)value;  break;
                case "WATERAREA":  this.WaterArea = (decimal?)value;  break;
                case "CITYALIASCODE":  this.CityAliasCode = (string)value;  break;
                case "CITYMIXEDCASE":  this.CityMixedCase = (string)value;  break;
                case "CITYALIASMIXEDCASE":  this.CityAliasMixedCase = (string)value;  break;
                case "BOXCOUNT":  this.BoxCount = (int?)value;  break;
                case "SFDU":  this.SFDU = (int?)value;  break;
                case "MFDU":  this.MFDU = (int?)value;  break;
                case "STATEANSI":  this.StateANSI = (string)value;  break;
                case "COUNTYANSI":  this.CountyANSI = (string)value;  break;
                case "ZIPINTRODATE":  this.ZIPIntroDate = (string)value;  break;
                case "ALIASINTRODATE":  this.AliasIntroDate = (string)value;  break;
                case "FACILITYCODE":  this.FacilityCode = (string)value;  break;
                case "CITYDELIVERYINDICATOR":  this.CityDeliveryIndicator = (string)value;  break;
                case "CARRIERROUTERATESORTATION":  this.CarrierRouteRateSortation = (string)value;  break;
                case "FINANCENUMBER":  this.FinanceNumber = (string)value;  break;
                case "UNIQUEZIPNAME":  this.UniqueZIPName = (string)value;  break;
                case "SSASTATECOUNTYCODE":  this.SSAStateCountyCode = (string)value;  break;
                case "MEDICARECBSACODE":  this.MedicareCBSACode = (string)value;  break;
                case "MEDICARECBSANAME":  this.MedicareCBSAName = (string)value;  break;
                case "MEDICARECBSATYPE":  this.MedicareCBSAType = (string)value;  break;
                case "MARKETRATINGAREAID":  this.MarketRatingAreaID = (int?)value;  break;
                case "COUNTYMIXEDCASE":  this.CountyMixedCase = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("ZC_MultiCounty")]
    [PrimaryKey("Oid")]
    public partial class ZC_MultiCounty : Record<ZC_MultiCounty>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ZCOid")]
        public long? ZCOid { get; set; }
        [Column("ZipCode")]
        public string ZipCode { get; set; }
        [Column("StateFIPS")]
        public string StateFIPS { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("CountyFIPS")]
        public string CountyFIPS { get; set; }
        [Column("County")]
        public string County { get; set; }
        [Column("CountyMixedCase")]
        public string CountyMixedCase { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public ZC_MultiCounty ShallowClone(){ return (ZC_MultiCounty)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ZCOID":  oReturn = this.ZCOid; break;
                    case "ZIPCODE":  oReturn = this.ZipCode; break;
                    case "STATEFIPS":  oReturn = this.StateFIPS; break;
                    case "STATE":  oReturn = this.State; break;
                    case "COUNTYFIPS":  oReturn = this.CountyFIPS; break;
                    case "COUNTY":  oReturn = this.County; break;
                    case "COUNTYMIXEDCASE":  oReturn = this.CountyMixedCase; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ZCOID":  this.ZCOid = (long?)value;  break;
                case "ZIPCODE":  this.ZipCode = (string)value;  break;
                case "STATEFIPS":  this.StateFIPS = (string)value;  break;
                case "STATE":  this.State = (string)value;  break;
                case "COUNTYFIPS":  this.CountyFIPS = (string)value;  break;
                case "COUNTY":  this.County = (string)value;  break;
                case "COUNTYMIXEDCASE":  this.CountyMixedCase = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("ZC_PlaceFIPS")]
    [PrimaryKey("Oid")]
    public partial class ZC_PlaceFIPS : Record<ZC_PlaceFIPS>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("ZCOid")]
        public long? ZCOid { get; set; }
        [Column("ZipCode")]
        public string ZipCode { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("StateFIPS")]
        public string StateFIPS { get; set; }
        [Column("ZipCodes_PlaceFIPS")]
        public string ZipCodes_PlaceFIPS { get; set; }
        [Column("PlaceName")]
        public string PlaceName { get; set; }
        [Column("PlaceType")]
        public string PlaceType { get; set; }
        [Column("County")]
        public string County { get; set; }
        [Column("FincStat")]
        public string FincStat { get; set; }
        [Column("FuncStatText")]
        public string FuncStatText { get; set; }
        [Column("ClassFP")]
        public string ClassFP { get; set; }
        [Column("GeoID")]
        public string GeoID { get; set; }
        [Column("PopPT")]
        public long? PopPT { get; set; }
        [Column("HuPT")]
        public long? HuPT { get; set; }
        [Column("AreaPT")]
        public long? AreaPT { get; set; }
        [Column("AreaLandPT")]
        public long? AreaLandPT { get; set; }
        [Column("ZPOP")]
        public long? ZPOP { get; set; }
        [Column("ZHU")]
        public long? ZHU { get; set; }
        [Column("ZArea")]
        public long? ZArea { get; set; }
        [Column("ZAreaLand")]
        public long? ZAreaLand { get; set; }
        [Column("PLPop")]
        public long? PLPop { get; set; }
        [Column("PLHU")]
        public long? PLHU { get; set; }
        [Column("PLArea")]
        public long? PLArea { get; set; }
        [Column("PLAreaLand")]
        public long? PLAreaLand { get; set; }
        [Column("ZPopPCT")]
        public decimal? ZPopPCT { get; set; }
        [Column("ZHUPCT")]
        public decimal? ZHUPCT { get; set; }
        [Column("ZAreaPCT")]
        public decimal? ZAreaPCT { get; set; }
        [Column("ZAreaLandPCT")]
        public decimal? ZAreaLandPCT { get; set; }
        [Column("PLPOPPCT")]
        public decimal? PLPOPPCT { get; set; }
        [Column("PLHUPCT")]
        public decimal? PLHUPCT { get; set; }
        [Column("PLAreaPCT")]
        public decimal? PLAreaPCT { get; set; }
        [Column("PLAreaLandPCT")]
        public decimal? PLAreaLandPCT { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public ZC_PlaceFIPS ShallowClone(){ return (ZC_PlaceFIPS)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "ZCOID":  oReturn = this.ZCOid; break;
                    case "ZIPCODE":  oReturn = this.ZipCode; break;
                    case "STATE":  oReturn = this.State; break;
                    case "STATEFIPS":  oReturn = this.StateFIPS; break;
                    case "ZIPCODES_PLACEFIPS":  oReturn = this.ZipCodes_PlaceFIPS; break;
                    case "PLACENAME":  oReturn = this.PlaceName; break;
                    case "PLACETYPE":  oReturn = this.PlaceType; break;
                    case "COUNTY":  oReturn = this.County; break;
                    case "FINCSTAT":  oReturn = this.FincStat; break;
                    case "FUNCSTATTEXT":  oReturn = this.FuncStatText; break;
                    case "CLASSFP":  oReturn = this.ClassFP; break;
                    case "GEOID":  oReturn = this.GeoID; break;
                    case "POPPT":  oReturn = this.PopPT; break;
                    case "HUPT":  oReturn = this.HuPT; break;
                    case "AREAPT":  oReturn = this.AreaPT; break;
                    case "AREALANDPT":  oReturn = this.AreaLandPT; break;
                    case "ZPOP":  oReturn = this.ZPOP; break;
                    case "ZHU":  oReturn = this.ZHU; break;
                    case "ZAREA":  oReturn = this.ZArea; break;
                    case "ZAREALAND":  oReturn = this.ZAreaLand; break;
                    case "PLPOP":  oReturn = this.PLPop; break;
                    case "PLHU":  oReturn = this.PLHU; break;
                    case "PLAREA":  oReturn = this.PLArea; break;
                    case "PLAREALAND":  oReturn = this.PLAreaLand; break;
                    case "ZPOPPCT":  oReturn = this.ZPopPCT; break;
                    case "ZHUPCT":  oReturn = this.ZHUPCT; break;
                    case "ZAREAPCT":  oReturn = this.ZAreaPCT; break;
                    case "ZAREALANDPCT":  oReturn = this.ZAreaLandPCT; break;
                    case "PLPOPPCT":  oReturn = this.PLPOPPCT; break;
                    case "PLHUPCT":  oReturn = this.PLHUPCT; break;
                    case "PLAREAPCT":  oReturn = this.PLAreaPCT; break;
                    case "PLAREALANDPCT":  oReturn = this.PLAreaLandPCT; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "ZCOID":  this.ZCOid = (long?)value;  break;
                case "ZIPCODE":  this.ZipCode = (string)value;  break;
                case "STATE":  this.State = (string)value;  break;
                case "STATEFIPS":  this.StateFIPS = (string)value;  break;
                case "ZIPCODES_PLACEFIPS":  this.ZipCodes_PlaceFIPS = (string)value;  break;
                case "PLACENAME":  this.PlaceName = (string)value;  break;
                case "PLACETYPE":  this.PlaceType = (string)value;  break;
                case "COUNTY":  this.County = (string)value;  break;
                case "FINCSTAT":  this.FincStat = (string)value;  break;
                case "FUNCSTATTEXT":  this.FuncStatText = (string)value;  break;
                case "CLASSFP":  this.ClassFP = (string)value;  break;
                case "GEOID":  this.GeoID = (string)value;  break;
                case "POPPT":  this.PopPT = (long?)value;  break;
                case "HUPT":  this.HuPT = (long?)value;  break;
                case "AREAPT":  this.AreaPT = (long?)value;  break;
                case "AREALANDPT":  this.AreaLandPT = (long?)value;  break;
                case "ZPOP":  this.ZPOP = (long?)value;  break;
                case "ZHU":  this.ZHU = (long?)value;  break;
                case "ZAREA":  this.ZArea = (long?)value;  break;
                case "ZAREALAND":  this.ZAreaLand = (long?)value;  break;
                case "PLPOP":  this.PLPop = (long?)value;  break;
                case "PLHU":  this.PLHU = (long?)value;  break;
                case "PLAREA":  this.PLArea = (long?)value;  break;
                case "PLAREALAND":  this.PLAreaLand = (long?)value;  break;
                case "ZPOPPCT":  this.ZPopPCT = (decimal?)value;  break;
                case "ZHUPCT":  this.ZHUPCT = (decimal?)value;  break;
                case "ZAREAPCT":  this.ZAreaPCT = (decimal?)value;  break;
                case "ZAREALANDPCT":  this.ZAreaLandPCT = (decimal?)value;  break;
                case "PLPOPPCT":  this.PLPOPPCT = (decimal?)value;  break;
                case "PLHUPCT":  this.PLHUPCT = (decimal?)value;  break;
                case "PLAREAPCT":  this.PLAreaPCT = (decimal?)value;  break;
                case "PLAREALANDPCT":  this.PLAreaLandPCT = (decimal?)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

    [Serializable]
    [TableName("ZipCode")]
    [PrimaryKey("Oid")]
    public partial class ZipCode : Record<ZipCode>, IModel, IIndexer
    {
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("lkpCountryOid")]
        public long? lkpCountryOid { get; set; }
        [Column("lkpStateOid")]
        public long? lkpStateOid { get; set; }
        [Column("lkpCountyOid")]
        public long? lkpCountyOid { get; set; }
        [Column("lkpCityOid")]
        public long? lkpCityOid { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("County")]
        public string County { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("StateFullName")]
        public string StateFullName { get; set; }
        [Column("Zip")]
        public string Zip { get; set; }
        [Column("Longitude")]
        public decimal? Longitude { get; set; }
        [Column("Latitude")]
        public decimal? Latitude { get; set; }
        [Column("TimeZone")]
        public string TimeZone { get; set; }
        [Column("IsUnique")]
        public bool? IsUnique { get; set; }
        [Column("IsMultipleCounties")]
        public bool? IsMultipleCounties { get; set; }
        [Column("CountyList")]
        public string CountyList { get; set; }
 
        //*******   Extension Events and Properties    *****
        public event EventHandler OnIsExpandedChanged;
        public event EventHandler OnIsHiddenChanged;
        private bool _isExpanded = false;
        private bool _isHidden = false;
        [Ignore]
        public bool IsExpanded { get {return _isExpanded;} set {if(_isExpanded != value) {_isExpanded = value;OnIsExpandedChanged?.Invoke(this, null);}}}
        [Ignore]
        public bool IsHidden { get {return _isHidden;} set {if(_isHidden != value) {_isHidden = value;OnIsHiddenChanged?.Invoke(this, null);}}}
        public ZipCode ShallowClone(){ return (ZipCode)this.MemberwiseClone();}

        public object Get(string tsPropertyName) {
            return this[tsPropertyName];
        }

        public void Set(string tsPropertyName, object value) {
            this[tsPropertyName] = value;
        }

        #region Indexer
        [Ignore]
        public virtual object this[string tsPropertyName] {
            get {
                object oReturn = null;
                switch(tsPropertyName.ToUpper()){
                    case "OID":  oReturn = this.Oid; break;
                    case "LKPCOUNTRYOID":  oReturn = this.lkpCountryOid; break;
                    case "LKPSTATEOID":  oReturn = this.lkpStateOid; break;
                    case "LKPCOUNTYOID":  oReturn = this.lkpCountyOid; break;
                    case "LKPCITYOID":  oReturn = this.lkpCityOid; break;
                    case "CITY":  oReturn = this.City; break;
                    case "COUNTY":  oReturn = this.County; break;
                    case "STATE":  oReturn = this.State; break;
                    case "STATEFULLNAME":  oReturn = this.StateFullName; break;
                    case "ZIP":  oReturn = this.Zip; break;
                    case "LONGITUDE":  oReturn = this.Longitude; break;
                    case "LATITUDE":  oReturn = this.Latitude; break;
                    case "TIMEZONE":  oReturn = this.TimeZone; break;
                    case "ISUNIQUE":  oReturn = this.IsUnique; break;
                    case "ISMULTIPLECOUNTIES":  oReturn = this.IsMultipleCounties; break;
                    case "COUNTYLIST":  oReturn = this.CountyList; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch(tsPropertyName){
                case "OID":  this.Oid = (long)value;  break;
                case "LKPCOUNTRYOID":  this.lkpCountryOid = (long?)value;  break;
                case "LKPSTATEOID":  this.lkpStateOid = (long?)value;  break;
                case "LKPCOUNTYOID":  this.lkpCountyOid = (long?)value;  break;
                case "LKPCITYOID":  this.lkpCityOid = (long?)value;  break;
                case "CITY":  this.City = (string)value;  break;
                case "COUNTY":  this.County = (string)value;  break;
                case "STATE":  this.State = (string)value;  break;
                case "STATEFULLNAME":  this.StateFullName = (string)value;  break;
                case "ZIP":  this.Zip = (string)value;  break;
                case "LONGITUDE":  this.Longitude = (decimal?)value;  break;
                case "LATITUDE":  this.Latitude = (decimal?)value;  break;
                case "TIMEZONE":  this.TimeZone = (string)value;  break;
                case "ISUNIQUE":  this.IsUnique = (bool?)value;  break;
                case "ISMULTIPLECOUNTIES":  this.IsMultipleCounties = (bool?)value;  break;
                case "COUNTYLIST":  this.CountyList = (string)value;  break;
                }
            }
        }

        #endregion (Indexer)
    }

}
