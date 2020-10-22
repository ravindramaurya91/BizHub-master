using System;
using System.Collections.Generic;

using Model;


namespace BizHub
{
    public class AccountDashboardController : BasePageController
    {
        
        #region Fields
        private Int64 _currentEntityOid = -1;
        private List<Whse_ListingStat> _whse_ListingStats = new List<Whse_ListingStat>();
        private List<ListingViewStatsCardDTO> _listingViewStatsCards = new List<ListingViewStatsCardDTO>();
        private List<SearchCriteria> _searchCriteriaList = new List<SearchCriteria>();
        private List<Entity2ListingMap_Stat> _e2LMap = new List<Entity2ListingMap_Stat>();
        private List<ListingDTO> _pendingListings = new List<ListingDTO>();


        #endregion (Fields)


        #region Methods
        private void On_CurrentEntityOidChanged() {
            LoadListingStatistics();
        }

        public List<SearchCriteria> GetActiveSearchCriteriaListByEntityOid(Int64 tiOid) {
            SearchCriteriaList = SQL.GetActiveSearchCriteriaListByEntityOid(tiOid);
            return SearchCriteriaList;
        }

        public List<Entity2ListingMap_Stat> GetFavoritedEntity2ListingMap_StatsByEntityOid(Int64 tiOid) {
            E2LMapList = SQL.GetEntity2ListingMap_StatsByEntityOidAndIsFavorited(tiOid);
            return E2LMapList;
        }

        public void LoadListingStatistics() {
            ListingStatsCards = Base.Database.GetInstance().Fetch<ListingViewStatsCardDTO>(SqlConstants.GET_LISTING_VIEW_STATS_CARD_DTO + "WHERE wls.EntityOid = @0", CurrentEntityOid);
        }

        public void GetMyPendingListings() {
            List<ListingDTO> oReturn = new List<ListingDTO>();
            PendingListings = ListingDTO.GetMyPendingListings(_currentEntityOid);
        }

        #endregion (Methods)

        #region Properties
        public Int64 CurrentEntityOid {
            get { return SessionMgr.Instance.User.EntityOid; }
            set {
                if ((_currentEntityOid != SessionMgr.Instance.User.EntityOid) && (_currentEntityOid != 0)) {
                    _currentEntityOid = SessionMgr.Instance.User.EntityOid;
                    On_CurrentEntityOidChanged();
                }
            }
        }
        public List<Whse_ListingStat> Whse_ListingStats { get => _whse_ListingStats; set => _whse_ListingStats = value; }
        public List<ListingViewStatsCardDTO> ListingStatsCards { get => _listingViewStatsCards; set => _listingViewStatsCards = value; }
        public List<SearchCriteria> SearchCriteriaList { get => _searchCriteriaList; set => _searchCriteriaList = value; }
        public List<Entity2ListingMap_Stat> E2LMapList { get => _e2LMap; set => _e2LMap = value; }
        public List<ListingDTO> PendingListings { get => _pendingListings; set => _pendingListings = value; }

        #endregion (Properties)
    }
}