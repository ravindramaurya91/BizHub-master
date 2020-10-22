using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.AccountDashboard
{
    public partial class CmpUserDashboard
    {
        #region Fields
        private AccountDashboardDTO _accountDTO = new AccountDashboardDTO();
        private MyListingsController _myListingsController = new MyListingsController();
        private AccountDashboardController _controller = new AccountDashboardController();
        #endregion(Fields)

        #region Constructor
        #endregion(Constructor)

        #region Methods
        private void NavigateToNewPage(string activeUrl) {
            Controller.NavManager.NavigateTo("/" + activeUrl);
        }

        protected override void OnInitialized()
        {
            // TODO: STEVEN FIX BELOW
            CurrentEntityOid = SessionMgr.Instance.User.EntityOid;
            GetActiveSearchCriteriaListByEntityOid(CurrentEntityOid);
            GetEntity2ListingMap_StatsByEntityOidAndIsFavorited(CurrentEntityOid);
            LoadListingStatistics();
            Controller.GetMyPendingListings();
            if (AccountDTO.SavedSearchCriteria.Count == 0)
            {
                int i = 0;
            }
        }

        public void GetActiveSearchCriteriaListByEntityOid(Int64 tiEntityOid) {
            AccountDTO.SavedSearchCriteria = Controller.GetActiveSearchCriteriaListByEntityOid(tiEntityOid);
        }

        public void GetEntity2ListingMap_StatsByEntityOidAndIsFavorited(Int64 tiEntityOid) {
            AccountDTO.FavoritedListings = SQL.GetEntity2ListingMap_StatsByEntityOidAndIsFavorited(tiEntityOid);
        }

        public void LoadListingStatistics() {
            _myListingsController.LoadListingStatistics();
        }

        #endregion(Methods)

        #region Properties

        public AccountDashboardController Controller { get => _controller; set => _controller = value; }

        public List<Entity2ListingMap_Stat> E2LMap { get => Controller.E2LMapList; set => Controller.E2LMapList = value; }

        public List<ListingViewStatsCardDTO> ListingViewStatsCardDTOs
        {
            get { return _myListingsController.ListingViewStatsCardDTOs; }
        }
        public Int64 CurrentEntityOid { get => Controller.CurrentEntityOid; set => Controller.CurrentEntityOid = value; }

        public List<ListingDTO> PendingListings { get => Controller.PendingListings; set => Controller.PendingListings = value; }
        
        // List<Listing> Listings = Base.Database.GetInstance().Fetch<Listing>("WHERE EntityOid = @0", 6);

        public AccountDashboardDTO AccountDTO {
            get => _accountDTO;
            set => _accountDTO = value;
        }

        #endregion(Properties)
    }
}