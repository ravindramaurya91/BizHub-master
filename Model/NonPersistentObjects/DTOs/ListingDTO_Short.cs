using System;
using System.Collections.Generic;
using System.Text;

using PetaPoco;

namespace Model {
    public class ListingDTO_Short {

        #region Properties
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid")]
        public long EntityOid { get; set; }
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
        [Column("SellerName")]
        public string SellerName { get; set; }
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
        [Column("AdTitle")]
        public string AdTitle { get; set; }
        [Column("AdTagLine")]
        public string AdTagLine { get; set; }
        [Column("AdDescription")]
        public string AdDescription { get; set; }
        [Column("AdPhoto")]
        public string AdPhoto { get; set; }
        [Column("WebsiteURL")]
        public string WebsiteURL { get; set; }
        [Column("YearEstablished")]
        public string YearEstablished { get; set; }
        [Column("ListingPrice")]
        public decimal? ListingPrice { get; set; }
        [Column("ListingDate")]
        public DateTime ListingDate { get; set; }
        [Column("BuyerCount")]
        public int BuyerCount { get; set; }
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
        public bool IsExpanded { get { return _isExpanded; } set { if (_isExpanded != value) { _isExpanded = value; OnIsExpandedChanged?.Invoke(this, null); } } }
        [Ignore]
        public bool IsHidden { get { return _isHidden; } set { if (_isHidden != value) { _isHidden = value; OnIsHiddenChanged?.Invoke(this, null); } } }
        public Listing ShallowClone() { return (Listing)this.MemberwiseClone(); }

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
                switch (tsPropertyName.ToUpper()) {
                    case "OID": oReturn = this.Oid; break;
                    case "ENTITYOID": oReturn = this.EntityOid; break;
                    case "EXTERNALID": oReturn = this.ExternalId; break;
                    case "EXTERNALSYSTEM": oReturn = this.ExternalSystem; break;
                    case "CONTACTNAME": oReturn = this.ContactName; break;
                    case "CONTACTEMAIL": oReturn = this.ContactEmail; break;
                    case "CONTACTPHONE": oReturn = this.ContactPhone; break;
                    case "COMPANYNAME": oReturn = this.CompanyName; break;
                    case "COMPANYPHONE": oReturn = this.CompanyPhone; break;
                    case "SELLERNAME": oReturn = this.SellerName; break;
                    case "ADDRESS": oReturn = this.Address; break;
                    case "ADDRESS2": oReturn = this.Address2; break;
                    case "CITY": oReturn = this.City; break;
                    case "COUNTY": oReturn = this.County; break;
                    case "STATE": oReturn = this.State; break;
                    case "ZIP": oReturn = this.Zip; break;
                    case "ADTITLE": oReturn = this.AdTitle; break;
                    case "ADTAGLINE": oReturn = this.AdTagLine; break;
                    case "ADDESCRIPTION": oReturn = this.AdDescription; break;
                    case "ADPHOTO": oReturn = this.AdPhoto; break;
                    case "WEBSITEURL": oReturn = this.WebsiteURL; break;
                    case "YEARESTABLISHED": oReturn = this.YearEstablished; break;
                    case "LISTINGPRICE": oReturn = this.ListingPrice; break;
                    case "LISTINGDATE": oReturn = this.ListingDate; break;
                    case "ISACTIVE": oReturn = this.IsActive; break;
                    case "BUYERCOUNT": oReturn = this.BuyerCount; break;
                    case "ISPENDING": oReturn = this.IsPending; break;
                }
                return oReturn;
            }

            set {
                tsPropertyName = tsPropertyName.ToUpper();
                switch (tsPropertyName) {
                    case "OID": this.Oid = (long)value; break;
                    case "ENTITYOID": this.EntityOid = (long)value; break;
                    case "EXTERNALID": this.ExternalId = (string)value; break;
                    case "EXTERNALSYSTEM": this.ExternalSystem = (string)value; break;
                    case "CONTACTNAME": this.ContactName = (string)value; break;
                    case "CONTACTEMAIL": this.ContactEmail = (string)value; break;
                    case "CONTACTPHONE": this.ContactPhone = (string)value; break;
                    case "COMPANYNAME": this.CompanyName = (string)value; break;
                    case "COMPANYPHONE": this.CompanyPhone = (string)value; break;
                    case "SELLERNAME": this.SellerName = (string)value; break;
                    case "ADDRESS": this.Address = (string)value; break;
                    case "ADDRESS2": this.Address2 = (string)value; break;
                    case "CITY": this.City = (string)value; break;
                    case "COUNTY": this.County = (string)value; break;
                    case "STATE": this.State = (string)value; break;
                    case "ZIP": this.Zip = (string)value; break;
                    case "ADTITLE": this.AdTitle = (string)value; break;
                    case "ADTAGLINE": this.AdTagLine = (string)value; break;
                    case "ADDESCRIPTION": this.AdDescription = (string)value; break;
                    case "ADPHOTO": this.AdPhoto = (string)value; break;
                    case "WEBSITEURL": this.WebsiteURL = (string)value; break;
                    case "YEARESTABLISHED": this.YearEstablished = (string)value; break;
                    case "LISTINGDATE": this.ListingDate = (DateTime)value; break;
                    case "BUYERCOUNT": this.BuyerCount = (int)value; break;
                    case "ISACTIVE": this.IsActive = (bool)value; break;
                    case "ISPENDING": this.IsPending = (bool)value; break;
                }
            }
        }
        #endregion (Indexer)

        #endregion (Properties)

    }
}
