using SqlKata;
using System;
using System.Collections.Generic;
using System.Text;

using PetaPoco;

namespace Model {
    class ListingDTO_Receiver : ListingDTO {


        #region Methods
        

        public static List<ListingDTO> Rollup(List<ListingDTO_Receiver> toRcvrs) {
            ListingDTO oCurrentListingDTO = null;
            NameValuePair oCurrentListingAttribute = null;
            List<ListingDTO> oReturnList = new List<ListingDTO>();

            foreach (ListingDTO_Receiver oRcvr in toRcvrs) {
                oCurrentListingDTO = ModelUtil.GetFromListByOid<ListingDTO>((Int64)oRcvr.Oid, oReturnList);
                if(oCurrentListingDTO == null) {
                    oCurrentListingDTO = CreateListingDTOFromReceiver(oRcvr);
                    oReturnList.Add(oCurrentListingDTO);
                }

                oCurrentListingAttribute = ModelUtil.GetFromListByOid<NameValuePair>(oRcvr.la_Oid, oCurrentListingDTO.Photos);
                if (oCurrentListingAttribute == null) {
                    oCurrentListingAttribute = new NameValuePair() {
                        Oid = oRcvr.la_Oid, Value = oRcvr.la_Value
                    };
                    oCurrentListingDTO.Photos.Add(oCurrentListingAttribute);
                }
            }

            return oReturnList;
        }

        private static ListingDTO CreateListingDTOFromReceiver(ListingDTO_Receiver toReceiver) {
            ListingDTO oReturn = new ListingDTO() {
                AdDescription = toReceiver.AdDescription, Address = toReceiver.Address, Address2 = toReceiver.Address2, AdPhoto = toReceiver.AdPhoto, AdTagLine = toReceiver.AdTagLine, AdTitle = toReceiver.AdTitle,
                BuildingCount = toReceiver.BuildingCount, CashFlow = toReceiver.CashFlow, City = toReceiver.City, CompanyName = toReceiver.CompanyName, ContactName = toReceiver.ContactName, ContactPhone = toReceiver.ContactPhone, ContactEmail = toReceiver.ContactEmail,
                County = toReceiver.County, CreatedOn = toReceiver.CreatedOn, DeleteMe = toReceiver.DeleteMe, EBITDA = toReceiver.EBITDA, EditInProgress = toReceiver.EditInProgress, EmployeeCount = toReceiver.EmployeeCount, EntityOid = toReceiver.EntityOid,
                EntityOid_BillingAuthority = toReceiver.EntityOid_BillingAuthority, ExpirationDate = toReceiver.ExpirationDate, AdFacilityDescription = toReceiver.AdFacilityDescription, FacilityOwned_Int = toReceiver.FacilityOwned_Int, FFandE = toReceiver.FFandE,
                GrossRevenue = toReceiver.GrossRevenue, Inventory = toReceiver.Inventory, IsAbsenteeOwner = toReceiver.IsAbsenteeOwner, IsActive = toReceiver.IsActive, IsFranchise = toReceiver.IsFranchise, IsHomeBased = toReceiver.IsHomeBased, IsRealEstateInPrice = toReceiver.IsRealEstateInPrice,
                IsRelocatable = toReceiver.IsRelocatable, IsSbaPreApproved = toReceiver.IsSbaPreApproved, IsSellerFinanace = toReceiver.IsSellerFinanace, Keywords = toReceiver.Keywords, ListingDate = toReceiver.ListingDate,
                ListingPrice = toReceiver.ListingPrice, lkpBusinessCategoryOids = toReceiver.lkpBusinessCategoryOids, lkpCityOid = toReceiver.lkpCityOid, lkpCountryOid = toReceiver.lkpCountryOid, lkpCountyOid = toReceiver.lkpCountyOid,
                lkpLegalEntityTypeOid = toReceiver.lkpLegalEntityTypeOid, lkpListingSetupStatusOid = toReceiver.lkpListingSetupStatusOid, lkpStateOid = toReceiver.lkpStateOid, MinimumDownPayment = toReceiver.MinimumDownPayment, OccupiedSqFt = toReceiver.OccupiedSqFt,
                Oid = toReceiver.Oid, Photos = toReceiver.Photos, RealEstateIncluded_Int = toReceiver.RealEstateIncluded_Int, RealEstateValue = toReceiver.RealEstateValue, SellerFinanceUpTo = toReceiver.SellerFinanceUpTo,
                AdReasonForSelling = toReceiver.AdReasonForSelling, ShowCashFlow_Int = toReceiver.ShowCashFlow_Int, ShowCity_Int = toReceiver.ShowCity_Int, ShowCompanyWebsite_Int = toReceiver.ShowCompanyWebsite_Int, ShowCounty_Int = toReceiver.ShowCounty_Int,
                ShowEBITDA_Int = toReceiver.ShowEBITDA_Int, ShowFFE_Int = toReceiver.ShowFFE_Int, ShowGrossRevenues_Int = toReceiver.ShowGrossRevenues_Int, ShowInventory_Int = toReceiver.ShowInventory_Int, ShowNumberOfEmployees_Int = toReceiver.ShowNumberOfEmployees_Int,
                ShowYearEstablished_Int = toReceiver.ShowYearEstablished_Int, ShowZip_Int = toReceiver.ShowZip_Int, State = toReceiver.State, AdSupportAndTraining = toReceiver.AdSupportAndTraining, TotalSqFt = toReceiver.TotalSqFt, WebsiteURL = toReceiver.WebsiteURL, YearEstablished = toReceiver.YearEstablished, IsPending = toReceiver.IsPending,
                Zip = toReceiver.Zip, IsFavorite = toReceiver.e2lmap_IsFavorite, E2LMapOid = toReceiver.e2lmap_Oid
            };
            return oReturn;
        }

        #endregion (Methods)


        #region Properties
        //ListingAttribute Properties
        [Column("la_Oid")]
        public Int64 la_Oid { get; set; }

        [Column("e2lmap_Oid")]
        public Int64 e2lmap_Oid { get; set; }

        [Column("la_Value")]
        public string la_Value { get; set; }

        [Column("e2lmap_IsFavorite")]
        public bool e2lmap_IsFavorite { get; set; }
        




        #endregion (Properties)

    }
}
