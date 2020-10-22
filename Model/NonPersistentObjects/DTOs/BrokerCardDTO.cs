using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Model {
    public class BrokerCardDTO : BrokerCard {

        #region Fields
        private List<NameValuePair> _datesContacted = new List<NameValuePair>();
        #endregion (Fields)

        #region Methods
        public static BrokerCardDTO GetBrokerCardDTOByEntityOid(Int64 tiOid) {
            BrokerCardDTO oReturn = null;
            //Get the current logged in user from the session. Use their Oid in the query below.
            Int64 tiLoggedInEntityOid = SessionMgr.Instance.User.EntityOid;
 
            // The first parameter position on this query is used up in the SqlContant Join that is why the e.Oid is in the second position
            List<BrokerCardDTO_Receiver> oReceivers = Base.Database.GetInstance().Fetch<BrokerCardDTO_Receiver>(SqlConstants.GET_BROKER_CARD_DTO_INFO + " WHERE e.Oid = @1", tiLoggedInEntityOid, tiOid );
            if (oReceivers.Count == 0) {
                throw new Exception($"No Broker Exists with an EntityOid: [{tiOid}]");
            }

            List<BrokerCardDTO> oList = BrokerCardDTO_Receiver.Rollup(oReceivers);
            oReturn = oList[0];
            return oReturn;
        }

        #region Save
        public override void Save() {
            //bool bIsNewRecord = false;
            //Listing oCurrentListing = null;
            //DateTime oDateTimeNow = DateTime.UtcNow.Date;

            //try {
            //    Base.Database.GetInstance().BeginTransaction();
            //    if ((this.Oid == null) || (this.Oid == 0)) {
            //        //TODO: Make sure the Oid of the person running the app is the Oid that will be put into the EntityOid column of a listing.
            //        oCurrentListing = new Listing() { EntityOid = this.EntityOid /*Change to reflect the correct Oid from the logged in User. */, CreatedOn = oDateTimeNow, IsActive = true };
            //        bIsNewRecord = true;
            //    } else {
            //        oCurrentListing = SQL.GetListingByOid((Int64)this.Oid);
            //    }

            //    oCurrentListing.AdDescription = this.AdDescription;
            //    oCurrentListing.Address = this.Address;
            //    oCurrentListing.Address2 = this.Address2;
            //    oCurrentListing.AdPhoto = this.AdPhoto;
            //    oCurrentListing.AdTagLine = this.AdTagLine;
            //    oCurrentListing.AdTitle = this.AdTitle;
            //    oCurrentListing.BuildingCount = this.BuildingCount;
            //    oCurrentListing.CashFlow = this.CashFlow;
            //    oCurrentListing.City = this.City;
            //    oCurrentListing.CompanyName = this.CompanyName;
            //    oCurrentListing.County = this.County;
            //    oCurrentListing.EBITDA = this.EBITDA;
            //    oCurrentListing.EditInProgress = this.EditInProgress;
            //    oCurrentListing.EmployeeCount = this.EmployeeCount;
            //    oCurrentListing.EntityOid_BillingAuthority = this.EntityOid_BillingAuthority;
            //    oCurrentListing.ExpirationDate = this.ExpirationDate;
            //    oCurrentListing.FacilityDescription = this.FacilityDescription;
            //    oCurrentListing.FacilityOwned_Int = this.FacilityOwned_Int;
            //    oCurrentListing.FFandE = this.FFandE;
            //    oCurrentListing.GrossRevenue = this.GrossRevenue;
            //    oCurrentListing.Inventory = this.Inventory;
            //    oCurrentListing.IsAbsenteeOwner = this.IsAbsenteeOwner;
            //    oCurrentListing.IsActive = this.IsActive;
            //    oCurrentListing.IsFranchise = this.IsFranchise;
            //    oCurrentListing.IsHomeBased = this.IsHomeBased;
            //    oCurrentListing.IsRealEstateInPrice = this.IsRealEstateInPrice;
            //    oCurrentListing.IsRelocatable = this.IsRelocatable;
            //    oCurrentListing.IsSbaPreApproved = this.IsSbaPreApproved;
            //    oCurrentListing.IsSellerFinanace = this.IsSellerFinanace;
            //    oCurrentListing.Keywords = this.Keywords;
            //    oCurrentListing.ListingDate = oDateTimeNow;
            //    oCurrentListing.ListingPrice = this.ListingPrice;
            //    oCurrentListing.lkpBusinessCategoryOids = this.lkpBusinessCategoryOids;
            //    oCurrentListing.lkpCityOid = this.lkpCityOid;
            //    oCurrentListing.lkpCountryOid = this.lkpCountryOid;
            //    oCurrentListing.lkpCountyOid = this.lkpCountyOid;
            //    oCurrentListing.lkpListingStatusOid = this.lkpListingStatusOid;
            //    oCurrentListing.MinimumDownPayment = this.MinimumDownPayment;
            //    oCurrentListing.OccupiedSqFt = this.OccupiedSqFt;
            //    oCurrentListing.RealEstateIncluded_Int = this.RealEstateIncluded_Int;
            //    oCurrentListing.RealEstateValue = this.RealEstateValue;
            //    oCurrentListing.SellerFinanceUpTo = this.SellerFinanceUpTo;
            //    oCurrentListing.ReasonForSelling = this.ReasonForSelling;
            //    oCurrentListing.ShowCashFlow_Int = this.ShowCashFlow_Int;
            //    oCurrentListing.ShowCity_Int = this.ShowCity_Int;
            //    oCurrentListing.ShowCompanyWebsite_Int = this.ShowCompanyWebsite_Int;
            //    oCurrentListing.ShowCounty_Int = this.ShowCounty_Int;
            //    oCurrentListing.ShowEBITDA_Int = this.ShowEBITDA_Int;
            //    oCurrentListing.ShowFFE_Int = this.ShowFFE_Int;
            //    oCurrentListing.ShowGrossRevenues_Int = this.ShowGrossRevenues_Int;
            //    oCurrentListing.ShowInventory_Int = this.ShowInventory_Int;
            //    oCurrentListing.ShowNumberOfEmployees_Int = this.ShowNumberOfEmployees_Int;
            //    oCurrentListing.ShowYearEstablished_Int = this.ShowYearEstablished_Int;
            //    oCurrentListing.ShowZip_Int = this.ShowZip_Int;
            //    oCurrentListing.State = this.State;
            //    oCurrentListing.TotalSqFt = this.TotalSqFt;
            //    oCurrentListing.WebsiteURL = this.WebsiteURL;
            //    oCurrentListing.YearEstablished = this.YearEstablished;
            //    oCurrentListing.Zip = this.Zip;

            //    oCurrentListing.Save();

            //    SaveListingPhotos();


            //    //Add the Oid to the DTOs overridden Oid.
            //    if (bIsNewRecord) {
            //        this.Oid = oCurrentListing.Oid;
            //    }


            //    Base.Database.GetInstance().CompleteTransaction();
            //} catch (Exception ex) {
            //    Base.Database.GetInstance().AbortTransaction();
            //    throw ex;
            //}

        }

        public void ListingAttribute2Photo(ListingAttribute toAttribute, NameValuePair toPair) {
            toPair.Oid = toAttribute.Oid;
            toPair.Value = toAttribute.Value;
        }

        #endregion (Save)

        #endregion (Methods)

        #region Properties
        
        //Entity Properties
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string LicensedIn { get; set; }
        public string AreasServed { get; set; }

        //Company Properties
        public string CompanyName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public List<NameValuePair> DatesContacted
        {
            get => _datesContacted;
            set => _datesContacted = value;
        }
        #endregion (Properties)
    }

}
