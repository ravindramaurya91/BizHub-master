using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Model;
using CommonUtil;

namespace BizHub {
    public class MyListingsController : BasePageController {

        #region Fields
        private Int64 _currentEntityOid = SessionMgr.Instance.User.EntityOid;
        private List<ListingViewStatsCardDTO> _listingViewStatsCardDTOs = new List<ListingViewStatsCardDTO>();
        private List<ListingViewStatsCardDTO> _listingViewStatsCardDTOs_Historical = new List<ListingViewStatsCardDTO>();
        private List<ListingDTO> _pendingListings = new List<ListingDTO>();
        private bool _allExpanded = false;
        #endregion (Fields)

        #region Constructor
        #endregion (Constructor)

        #region Methods
        private void On_CurrentEntityOidChanged() {
            LoadListingStatistics();
        }

        public void GetMyHistoricalListings() {
            try {
                List<ListingViewStatsCardDTO_Receiver> oRcvrs = Base.Database.GetInstance().Fetch<ListingViewStatsCardDTO_Receiver>(SqlConstants.GET_LISTING_VIEW_STATS_CARD_DTO + "WHERE wls.EntityOid = @0 AND l.IsActive = 0 AND l.lkpListingSetupStatusOid = @1", _currentEntityOid, 36016);
                _listingViewStatsCardDTOs_Historical = ListingViewStatsCardDTO_Receiver.Rollup(oRcvrs);
            } catch (Exception ex) {
                ShowPopupDialog("Error retrieving Historical Listings <br>" + ex.Message, "Error");
            }
        }

        public void LoadListingStatistics() {
            try {
                List<ListingViewStatsCardDTO_Receiver> oRcvrs = Base.Database.GetInstance().Fetch<ListingViewStatsCardDTO_Receiver>(SqlConstants.GET_LISTING_VIEW_STATS_CARD_DTO + "WHERE wls.EntityOid = @0", _currentEntityOid);
                ListingViewStatsCardDTOs = ListingViewStatsCardDTO_Receiver.Rollup(oRcvrs);
                ListingViewStatsCardDTOs_MasterList = ListingViewStatsCardDTO_Receiver.Rollup(oRcvrs);
                //ListingViewStatsCardDTOs_MasterList.AddRange(ListingViewStatsCardDTOs);
            } catch (Exception ex) {
                ShowPopupDialog("Error retrieving Listings <br>" + ex.Message, "Error");
            }
        }

        public void ResetListingViewStatCardDTOs() {
            ListingViewStatsCardDTOs.Clear();
            ListingViewStatsCardDTOs.AddRange(ListingViewStatsCardDTOs_MasterList);
        }

        #region Search Filter
        public async void OnKeywordInput(string tsSearchText) {
            ListingViewStatsCardDTOs = (List<ListingViewStatsCardDTO>)await SearchForKeyWords(tsSearchText);
        }

        private async Task<IEnumerable<ListingViewStatsCardDTO>> SearchForKeyWords(string tsSearchText) {
            return await Task.FromResult(ListingViewStatsCardDTOs.Where(x => x.CompanyName.ToLower().Contains(tsSearchText.ToLower()) ||
            x.AdTitle.ToLower().Contains(tsSearchText.ToLower()) ||
            x.AdTagLine.ToLower().Contains(tsSearchText.ToLower())).ToList());
        }
        #endregion (Search Filter)

        #region Expand / Collapse
        public void CheckExpandStatus() {
            ListingViewStatsCardDTO oCollapsedStat = ListingViewStatsCardDTOs.Find(DTO => !DTO.IsExpanded);
            if(oCollapsedStat != null) {
                AllExpanded = false;
            } else {
                AllExpanded = true;
            }
        }
        
        public void ExpandCollapseAll() {
            AllExpanded = !AllExpanded;
            foreach (ListingViewStatsCardDTO listing in ListingViewStatsCardDTOs) {
                listing.IsExpanded = _allExpanded;
            }
        }
        #endregion (Expand / Collapse)
        
        #region Keyword Search
        public void KeywordSearch(string sSearchWords)
        {
            List<ListingViewStatsCardDTO> oHitList = new List<ListingViewStatsCardDTO>();
            try
            {
                foreach (ListingViewStatsCardDTO oItem in ListingViewStatsCardDTOs_MasterList)
                {
                    if ((!String.IsNullOrEmpty(oItem.AdTitle) && oItem.AdTitle.Contains(sSearchWords)) ||
                        (!String.IsNullOrEmpty(oItem.AdTagLine) && oItem.AdTagLine.Contains(sSearchWords)))
                    {
                        oHitList.Add(oItem);
                    }
                }
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }

            ListingViewStatsCardDTOs = oHitList;
        }
        
        public void ClearWordSearch()
        {
            ListingViewStatsCardDTOs = ListingViewStatsCardDTOs_MasterList;
        }
        
        #endregion(Keyword Search)

        #region Sorting Options
        public void Sort(string tsSortCriteria) {
            string sContext, sValue;
            int iPos = tsSortCriteria.IndexOf("->");
            if (iPos > -1) {
                sContext = tsSortCriteria.Substring(0, iPos);
                sValue = tsSortCriteria.Substring(iPos + 2);
                switch (sContext) {
                    case "Alpha":
                        switch (sValue) {
                            case "CompanyName":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByCompanyName);
                                break;
                            case "AdTitle":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByAdTitle);
                                break;
                        }
                        break;

                    case "View":

                        switch (sValue) {
                            case "24Hours":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByViews24HourDescending);
                                break;
                            case "Last7Days":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByViewsLast7DaysDescending);
                                break;
                            case "LastMonth":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByViewsLastMonthDescending);
                                break;
                            case "Last3Months":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByViewsLast3MonthsDescending);
                                break;
                            case "Over90Days":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByViewsOver90DaysDescending);
                                break;
                            case "Total":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByViewsDescending);
                                break;
                        }
                        break;

                    case "Click":
                        switch (sValue) {
                            case "24Hours":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByClicks24HourDescending);
                                break;
                            case "Last7Days":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByClicksLast7DaysDescending);
                                break;
                            case "LastMonth":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByClicksLastMonthDescending);
                                break;
                            case "Last3Months":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByClicksLast3MonthsDescending);
                                break;
                            case "Over90Days":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByClicksOver90DaysDescending);
                                break;
                            case "Total":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByClicksDescending);
                                break;
                        }
                        break;
                    case "Favorited":
                        switch (sValue) {
                            case "24Hours":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByFavorited24HourDescending);
                                break;
                            case "Last7Days":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByFavoritedLast7DaysDescending);
                                break;
                            case "LastMonth":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByFavoritedLastMonthDescending);
                                break;
                            case "Last3Months":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByFavoritedLast3MonthsDescending);
                                break;
                            case "Over90Days":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByFavoritedOver90DaysDescending);
                                break;
                            case "Total":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByFavoritedDescending);
                                break;
                        }
                        break;
                    case "ContactRequest":
                        switch (sValue) {
                            case "24Hours":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByContactRequests24HourDescending);
                                break;
                            case "Last7Days":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByContactRequestsLast7DaysDescending);
                                break;
                            case "LastMonth":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByContactRequestsLastMonthDescending);
                                break;
                            case "Last3Months":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByContactRequestsLast3MonthsDescending);
                                break;
                            case "Over90Days":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByContactRequestsOver90DaysDescending);
                                break;
                            case "Total":
                                ListingViewStatsCardDTOs.Sort(ListingViewStatsCardDTO.SortByContactRequestsDescending);
                                break;
                        }
                        break;
                }
            }
        }
        #endregion (Sorting Options)

        #endregion (Methods)

        #region Properties
        public Int64 CurrentEntityOid {
            get { return _currentEntityOid; }
            set {
                if (_currentEntityOid != SessionMgr.Instance.User.EntityOid && SessionMgr.Instance.User.EntityOid > 0) {
                    _currentEntityOid = SessionMgr.Instance.User.EntityOid;
                    On_CurrentEntityOidChanged();
                }
            }
        }

        public bool AllExpanded {
            get {return _allExpanded;}
            set { _allExpanded = value; }
        }

        public List<ListingViewStatsCardDTO> ListingViewStatsCardDTOs { get => _listingViewStatsCardDTOs; set => _listingViewStatsCardDTOs = value; }
        public List<ListingViewStatsCardDTO> ListingViewStatsCardDTOs_MasterList { get => _listingViewStatsCardDTOs; set => _listingViewStatsCardDTOs = value; }
        #endregion (Properties)

    }
}
