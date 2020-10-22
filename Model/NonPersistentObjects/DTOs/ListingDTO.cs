using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class ListingDTO : Listing {

        #region Fields
        private bool _isFavorite = false;
        private List<NameValuePair> _photos = new List<NameValuePair>();
        private List<NameValuePair> _urls = new List<NameValuePair>();
        #endregion (Fields)

        #region Methods
        public static ListingDTO GetByListingOid(Int64 tiListingOid) {
            ListingDTO oReturn = null;
            List<ListingDTO_Receiver> oReceivers = new List<ListingDTO_Receiver>();
            oReceivers = Base.Database.GetInstance().Fetch<ListingDTO_Receiver>(SqlConstants.GET_LISTING_DTO_DATA + " WHERE l.Oid = @0", tiListingOid);
            if (oReceivers.Count == 0) {
                throw new Exception($"No Receiver's found for Listing Oid of [{tiListingOid}]");
            }
            List<ListingDTO> oListings = ListingDTO_Receiver.Rollup(oReceivers);
            if(oListings.Count > 0) {
            oReturn = oListings[0];
            }

            return oReturn;
        }

        public static ListingDTO GetActiveAndNonPendingListingsByListingOid(Int64 tiListingOid) {
            ListingDTO oReturn = null;
            List<ListingDTO_Receiver> oReceivers = new List<ListingDTO_Receiver>();
            oReceivers = Base.Database.GetInstance().Fetch<ListingDTO_Receiver>(SqlConstants.GET_LISTING_DTO_DATA + " WHERE l.Oid = @0 AND l.IsPending = 0 AND l.IsActive = 1", tiListingOid);
            if (oReceivers.Count == 0) {
                throw new Exception($"No Receiver's found for Listing Oid of [{tiListingOid}]");
            }
            List<ListingDTO> oListings = ListingDTO_Receiver.Rollup(oReceivers);
            if (oListings.Count > 0) {
                oReturn = oListings[0];
            }

            return oReturn;
        }

        public static List<ListingDTO> GetMyPendingListings(Int64 tiEntityOid) {
            List<ListingDTO> oReturn = new List<ListingDTO>();
            List<ListingDTO_Receiver> oReceivers = new List<ListingDTO_Receiver>();
            oReceivers = Base.Database.GetInstance().Fetch<ListingDTO_Receiver>(SqlConstants.GET_LISTING_DTO_DATA + " WHERE l.EntityOid = @0 AND l.lkpListingSetupStatusOid != @1 AND l.IsPending = 1", tiEntityOid, 36016);
            if (oReceivers.Count == 0) {
                //throw new Exception($"No Pending Listings Found Where EntityOid = [{tiEntityOid}]");
            }
            oReturn = ListingDTO_Receiver.Rollup(oReceivers);

            return oReturn;
        }


        public void ToggleIsFavorite() {
            bool IsNewRecord = false;
            IsFavorite = !IsFavorite;
            Entity2ListingMap_Stat oMap = null;
            if (E2LMapOid != null && E2LMapOid > 0) {
                oMap = SQL.GetEntity2ListingMap_StatByOid(E2LMapOid);
            } 
            if (oMap == null) {
                oMap = SQL.GetEntity2ListingMap_StatByEntityOidAndListingOid(SessionMgr.Instance.User.EntityOid, this.Oid);
            }
            if (oMap == null) {
                IsNewRecord = true;
                oMap = Entity2ListingMap_Stat.CreateNewMapForListing((ListingDTO)this);
            }
            oMap.IsFavorite = IsFavorite;
            if (oMap.IsFavorite == true) {
                oMap.DateFavorited = DateTime.Now;
            } else {
                oMap.DateFavorited = null;
            }
            oMap.Save();

            if (IsNewRecord) {
                E2LMapOid = oMap.Oid;
            }
        }

        public string GetCityStateAsString() {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(City)) {
                sb.Append(City);
                if (!string.IsNullOrEmpty(State)) {
                    sb.Append(", " + State);
                }
            } else {
                if (!string.IsNullOrEmpty(State)) {
                    sb.Append(State);
                }
            }
            return sb.ToString();
        }

        #region Save
        public override void Save() {
            bool bIsNewRecord = false;
            Listing oCurrentListing = null;
            DateTime oDateTimeNow = DateTime.UtcNow.Date;

            try {
                if (Oid == null || Oid <= 0) {
                    //TODO: Make sure the Oid of the person running the app is the Oid that will be put into the EntityOid column of a listing.
                    oCurrentListing = new Listing() { EntityOid = SessionMgr.Instance.User.EntityOid, EntityOid_BillingAuthority = SessionMgr.Instance.User.EntityOid_Master, CreatedOn = oDateTimeNow, ListingDate = oDateTimeNow, IsActive = true, IsPending = true };
                    bIsNewRecord = true;
                    oCurrentListing.lkpListingSetupStatusOid = (lkpListingSetupStatusOid != null) ? lkpListingSetupStatusOid : LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->STEPONE");
                } else {
                    oCurrentListing = SQL.GetListingByOid((Int64)Oid);
                    oCurrentListing.lkpListingSetupStatusOid = lkpListingSetupStatusOid;
                }

                if (IsPending == false) {
                    CheckRequiredFieldsForNonPendingListing();
                }
                Base.Database.GetInstance().BeginTransaction();

                oCurrentListing.AdDescription = AdDescription;
                oCurrentListing.Address = Address;
                oCurrentListing.Address2 = Address2;
                oCurrentListing.AdPhoto = AdPhoto;
                oCurrentListing.AdTagLine = !string.IsNullOrEmpty(AdTagLine) ? AdTagLine : "";
                oCurrentListing.AdTitle = !string.IsNullOrEmpty(AdTitle) ? AdTitle : "";
                oCurrentListing.BuildingCount = BuildingCount;
                oCurrentListing.CashFlow = CashFlow;
                oCurrentListing.City = City;
                oCurrentListing.ContactName = ContactName;
                oCurrentListing.ContactEmail = ContactEmail;
                oCurrentListing.ContactPhone = ContactPhone;
                oCurrentListing.CompanyName = CompanyName;
                oCurrentListing.County = County;
                oCurrentListing.EBITDA = EBITDA;
                oCurrentListing.EditInProgress = EditInProgress;
                oCurrentListing.EmployeeCount = EmployeeCount;
                oCurrentListing.ExpirationDate = ExpirationDate;
                oCurrentListing.AdFacilityDescription = AdFacilityDescription;
                oCurrentListing.FacilityOwned_Int = FacilityOwned_Int;
                oCurrentListing.FFandE = FFandE;
                oCurrentListing.GrossRevenue = GrossRevenue;
                oCurrentListing.Inventory = Inventory;
                oCurrentListing.IsAbsenteeOwner = IsAbsenteeOwner;
                oCurrentListing.IsFranchise = IsFranchise;
                oCurrentListing.IsHomeBased = IsHomeBased;
                oCurrentListing.IsRealEstateInPrice = IsRealEstateInPrice;
                oCurrentListing.IsRelocatable = IsRelocatable;
                oCurrentListing.IsSbaPreApproved = IsSbaPreApproved;
                oCurrentListing.IsSellerFinanace = IsSellerFinanace;
                oCurrentListing.Keywords = Keywords;
                oCurrentListing.ListingPrice = ListingPrice;
                oCurrentListing.lkpBusinessCategoryOids = lkpBusinessCategoryOids;
                oCurrentListing.lkpStateOid = lkpStateOid;
                oCurrentListing.lkpCityOid = lkpCityOid;
                oCurrentListing.lkpCountryOid = lkpCountryOid;
                oCurrentListing.lkpCountyOid = lkpCountyOid;
                oCurrentListing.MinimumDownPayment = MinimumDownPayment;
                oCurrentListing.OccupiedSqFt = OccupiedSqFt;
                oCurrentListing.RealEstateIncluded_Int= RealEstateIncluded_Int;
                oCurrentListing.RealEstateValue = RealEstateValue;
                if (IsSellerFinanace == false || IsSellerFinanace == null) {
                    oCurrentListing.SellerFinanceUpTo = 0;
                    oCurrentListing.IsSellerFinanace = false;
                } else {
                    oCurrentListing.SellerFinanceUpTo = SellerFinanceUpTo;
                }
                oCurrentListing.AdReasonForSelling = AdReasonForSelling;
                oCurrentListing.ShowCashFlow_Int = ShowCashFlow_Int;
                oCurrentListing.ShowCity_Int = ShowCity_Int;
                oCurrentListing.ShowCompanyWebsite_Int = ShowCompanyWebsite_Int;
                oCurrentListing.ShowCounty_Int = ShowCounty_Int;
                oCurrentListing.ShowEBITDA_Int = ShowEBITDA_Int;
                oCurrentListing.ShowFFE_Int = ShowFFE_Int;
                oCurrentListing.ShowGrossRevenues_Int = ShowGrossRevenues_Int;
                oCurrentListing.ShowInventory_Int = ShowInventory_Int;
                oCurrentListing.ShowNumberOfEmployees_Int = ShowNumberOfEmployees_Int;
                oCurrentListing.ShowYearEstablished_Int = ShowYearEstablished_Int;
                oCurrentListing.ShowZip_Int = ShowZip_Int;
                oCurrentListing.State = State;
                oCurrentListing.AdSupportAndTraining = AdSupportAndTraining;
                oCurrentListing.TotalSqFt = TotalSqFt;
                oCurrentListing.WebsiteURL = WebsiteURL;
                oCurrentListing.YearEstablished = YearEstablished;
                oCurrentListing.Zip = Zip;

                //Below Fields can not be null. Check for values on the object being passed in, assign defaults if none given
                // oCurrentListing.ListingDate = (ListingDate != null) ? ListingDate : oDateTimeNow;
                // oCurrentListing.CreatedOn = (CreatedOn != null) ? CreatedOn : oDateTimeNow;
                oCurrentListing.IsPending = (IsPending == true) ? true : false;
                oCurrentListing.IsActive = (IsActive == true) ? true : false;

                oCurrentListing.Save();

                //Add the Oid to the DTOs overridden Oid.
                if (bIsNewRecord) {
                    Oid = oCurrentListing.Oid;
                }

                if (IsPending == false) {
                    SaveWhseListingStat(oCurrentListing);
                }

                //TODO Below doesn't account for photos or Urls that have been deleted when this save goes through
                //if (Photos[0].Value != null) {
                //    SaveListingPhotos();
                //}
                //if (URLs[0].Value != null) {
                //    SaveListingExternalUrls();
                //}

                Base.Database.GetInstance().CompleteTransaction();
            } catch (Exception ex) {
                Base.Database.GetInstance().AbortTransaction();
                throw ex;
            }
        }

        private void CheckRequiredFieldsForNonPendingListing() {
            if (string.IsNullOrEmpty(Zip)) {
                throw new Exception($"A listing must have a Zipcode");
            }
            if (string.IsNullOrEmpty(State) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(County)) {
                ZipCode oZip = ZipCode.FirstOrDefault("WHERE Zip = @0", Zip);
                if (oZip == null) {
                    throw new Exception($"No Zipcode exists with a value of:  ${Zip}");
                }
                State = oZip.State;
                City = oZip.City;
                County = oZip.County;
                lkpStateOid = oZip.lkpStateOid;
                lkpCityOid = oZip.lkpCityOid;
                lkpCountyOid = oZip.lkpCountyOid;
                lkpCountryOid = oZip.lkpCountryOid;
            }
            if (lkpCountryOid == null) {
                throw new Exception(@"A Country is required to proceed.");
            }
            // If Listing is being saved with a status of complete, must enforce the presence of essential fields
                if (string.IsNullOrEmpty(CompanyName)) {
                    throw new Exception(@"A Business Name is required to proceed.");
                }
                if (string.IsNullOrEmpty(Address)) {
                    throw new Exception(@"A Street Address is required to proceed.");
                }
                if (string.IsNullOrEmpty(ContactEmail)) {
                    throw new Exception(@"A Contact Email Address is required to proceed.");
                }
            
        }

        private void SaveListingPhotos() {
                List<Int64> iDeleteList = new List<Int64>();
                foreach (NameValuePair oPhoto in Photos) {
                    if (oPhoto.DeleteMe) {
                        iDeleteList.Add(oPhoto.Oid);
                    } else {
                        ListingAttribute oAttribute = null;
                        if (oPhoto.Oid > 0) {
                            oAttribute = SQL.GetListingAttributeByOid(oPhoto.Oid, false);
                        }
                        if (oAttribute == null) {
                            oAttribute = new ListingAttribute();
                            oAttribute.ListingOid = (Int64)Oid;
                            oAttribute.lkpAttributeTypeOid = LookupManager.Instance.GetOidByConstantValue("ATTRIBUTETYPE->IMAGE");
                            oAttribute.ParentOid = EntityOid;
                        }

                        oAttribute.Value = oPhoto.Value;

                        oAttribute.Save();
                        ListingAttribute2Photo(oAttribute, oPhoto);
                    }
                Base.Database.GetInstance().Execute("DELETE ListingAttribute WHERE Oid IN (@0)", iDeleteList);
            }

        }

        private void SaveListingExternalUrls() {
            List<Int64> iDeleteList = new List<Int64>();
            foreach (NameValuePair oExternalUrl in URLs) {
                if (oExternalUrl.DeleteMe) {
                    iDeleteList.Add(oExternalUrl.Oid);
                } else {
                    ListingAttribute oAttribute = null;
                    if (oExternalUrl.Oid > 0) {
                        oAttribute = SQL.GetListingAttributeByOid(oExternalUrl.Oid, false);
                    }
                    if (oAttribute == null) {
                        oAttribute = new ListingAttribute();
                        oAttribute.ListingOid = (Int64)Oid;
                        oAttribute.lkpAttributeTypeOid = LookupManager.Instance.GetOidByConstantValue("ATTRIBUTETYPE->EXTERNALURL");
                        oAttribute.ParentOid = EntityOid;

                    }

                    oAttribute.Value = oExternalUrl.Value;

                    oAttribute.Save();
                    ListingAttribute2ExternalUrl(oAttribute, oExternalUrl);
                }
                Base.Database.GetInstance().Execute("DELETE ListingAttribute WHERE Oid IN (@0)", iDeleteList);
            }

        }

        private void SaveWhseListingStat(Listing toListing) {
            Whse_ListingStat oWhse_ListingStat;
            oWhse_ListingStat = SQL.GetWhse_ListingStatByListingOid(toListing.Oid, false);
            if (oWhse_ListingStat == null) {
                oWhse_ListingStat = Whse_ListingStat.CreateNewEmptyRecord(toListing.Oid);
            }
            oWhse_ListingStat.EntityOid = toListing.EntityOid;
            oWhse_ListingStat.ListingOid = toListing.Oid;
            oWhse_ListingStat.AdTitle = toListing.AdTitle;
            oWhse_ListingStat.AdTagLine = toListing.AdTagLine;
            oWhse_ListingStat.CompanyName = toListing.CompanyName;

            oWhse_ListingStat.Save();
        }

        public void ListingAttribute2Photo(ListingAttribute toAttribute, NameValuePair toPair) {
            toPair.Oid = toAttribute.Oid;
            toPair.Value = toAttribute.Value;
        }

        public void ListingAttribute2ExternalUrl(ListingAttribute toAttribute, NameValuePair toPair) {
            toPair.Oid = toAttribute.Oid;
            toPair.Value = toAttribute.Value;
        }
        #endregion (Save)

        #region Sorting
        #region Ad Title
        public static int SortByAdTitle(ListingDTO x, ListingDTO y) {
            int iReturn = 0;
            if (x == null || x.AdTitle == null) {
                if (y == null || y.AdTitle == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (y == null || y.AdTitle == null) {
                    iReturn = -1;
                } else {
                    iReturn = x.AdTitle.CompareTo(y.AdTitle);
                }
            }
            return iReturn;
        }
        #endregion (Ad Title)

        #region EBITDA
        public static int SortByEBITDA(ListingDTO x, ListingDTO y) {
            int iReturn = 0;
            if (x == null || x.EBITDA == null) {
                if (y == null || y.EBITDA == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (y == null || y.EBITDA == null) {
                    iReturn = -1;
                } else {
                    iReturn = ((decimal)x.EBITDA).CompareTo((decimal)y.EBITDA);
                }
            }
            return iReturn;
        }
        #endregion (EBITDA)

        #region ListingPrice
        public static int SortByListingPrice(ListingDTO x, ListingDTO y) {
            int iReturn = 0;
            if (x == null || x.ListingPrice == null) {
                if (y == null || y.ListingPrice == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (y == null || y.ListingPrice == null) {
                    iReturn = -1;
                } else {
                    iReturn = ((decimal)x.ListingPrice).CompareTo((decimal)y.ListingPrice);
                }
            }
            return iReturn;
        }
        #endregion (ListingPrice)

        #region CashFlow
        public static int SortByCashFlow(ListingDTO x, ListingDTO y) {
            int iReturn = 0;
            if (x == null || x.CashFlow == null) {
                if (y == null || y.CashFlow == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (y == null || y.CashFlow == null) {
                    iReturn = -1;
                } else {
                    iReturn = ((decimal)x.CashFlow).CompareTo((decimal)y.CashFlow);
                }
            }
            return iReturn;
        }
        #endregion (CashFlow)

        #region IsSbaPreApproved
        public static int SortByIsSbaPreApproved(ListingDTO x, ListingDTO y) {
            int iReturn = 0;
            if (x == null || x.IsSbaPreApproved == null) {
                if (y == null || y.IsSbaPreApproved == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (y == null || y.IsSbaPreApproved == null) {
                    iReturn = -1;
                } else {
                    iReturn = ((bool)x.IsSbaPreApproved).CompareTo((bool)y.IsSbaPreApproved);
                }
            }
            return iReturn;
        }
        #endregion (IsSbaPreApproved)

        #region IsSellerFinanace
        public static int SortByIsSellerFinanace(ListingDTO x, ListingDTO y) {
            int iReturn = 0;
            if (x == null || x.IsSellerFinanace == null) {
                if (y == null || y.IsSellerFinanace == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (y == null || y.IsSellerFinanace == null) {
                    iReturn = -1;
                } else {
                    iReturn = ((bool)x.IsSellerFinanace).CompareTo((bool)y.IsSellerFinanace);
                }
            }
            return iReturn;
        }
        #endregion (IsSellerFinanace)
        #endregion (Sorting)

        #endregion (Methods)

        #region Properties
        public List<NameValuePair> Photos { get => _photos; set => _photos = value; }
        public List<NameValuePair> URLs { get => _urls; set => _urls = value; }
        public bool IsPartialSave { get; set; }
        public bool IsReviewed { get; set; }
        public bool IsFavorite { get=>_isFavorite; set=>_isFavorite = value; }
        public bool IsContacted { get; set; }
        public Int64 E2LMapOid { get; set; }
        public string CityState { get => GetCityStateAsString(); }
        #endregion (Properties)
    }
}
