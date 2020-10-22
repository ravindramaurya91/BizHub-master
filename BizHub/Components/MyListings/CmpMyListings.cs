using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using System.Timers;
using BizHub.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Nancy.Session;

namespace BizHub.Components.MyListings {
    public partial class CmpMyListings {

        #region Fields
        private Int64 _stepOneOid = LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->STEPONE");
        private Int64 _stepTwoOid = LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->STEPTWO");
        private Int64 _stepThreeOid = LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->STEPTHREE");
        private Int64 _completeOid = LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->COMPLETE");
        private MyListingsController _controller = null;
        private System.Timers.Timer _Timer;
        private string _tabStatus = "Active";
        #endregion(Fields)

        #region Methods

        public Int64 GetActiveStep(Int64 tiOid)
        {
            if (tiOid != null && tiOid != 0) {
                if (tiOid == StepOneOid) {
                    return 1;
                }
                if (tiOid == StepTwoOid) {
                    return 2;
                }
                if (tiOid == StepThreeOid) {
                    return 3;
                }
            }
            return 1;
        }

        public void ArrowSelected(long tiStepSelected, ListingViewStatsCardDTO toListing)
        {
            if (tiStepSelected > GetActiveStep(toListing.l_lkpListingSetupStatusOid))
            {
                Controller.ShowPopupDialog("Must complete prior steps first.", "Warning");
            }
            else
            {
                Controller.NavigateTo("/Listing-Setup/" + toListing.ListingOid + "/" + tiStepSelected);   
            }
        }
        protected override void OnInitialized() {
            _controller = new MyListingsController();
            _Timer = new System.Timers.Timer(1000);
            _Timer.Elapsed += OnUserFinish;
            _Timer.AutoReset = false;
            _controller.LoadListingStatistics();

            Controller.CurrentEntityOid = SessionMgr.Instance.User.EntityOid;
        }

        public List<ListingViewStatsCardDTO> GetCurrentList() {
            List<ListingViewStatsCardDTO> oReturn;
            switch (TabStatus) {
                case "Active":
                    oReturn = ListingViewStatsCardDTOs.Where(x => x.l_IsActive == true).ToList();
                    break;
                case "Incomplete":
                    oReturn = ListingViewStatsCardDTOs.Where(x => (x.l_IsActive == false && x.l_IsPending == true)).ToList();
                    break;
                case "Historical":
                    oReturn = ListingViewStatsCardDTOs.Where(x => (x.l_IsActive == false && x.l_IsPending == false)).ToList();
                    break;
                default:
                    oReturn = ListingViewStatsCardDTOs;
                    break;
            }

            return oReturn;
        }
        public void FilterListingsByStatus(string tsStatus) {
            TabStatus = tsStatus;
        }

        #region Filter Handling
        public void OnSearchKeyUp(KeyboardEventArgs e) {
            _Timer.Stop();
            //./././././././
            _Timer.Start();
        }

        public void ClearSearchString() {
            SearchString = null;
            Controller.ClearWordSearch();
        }

        private void OnUserFinish(Object source, ElapsedEventArgs e) {
            _controller.OnKeywordInput(SearchString);
        }
        #endregion (Filter Handling)
        public void CheckExpandStatus() {
            Controller.CheckExpandStatus();
        }

        public void ExpandCollapseAll() {
            Controller.ExpandCollapseAll();
        }

        public void SearchListings()
        {
            Controller.KeywordSearch(SearchString);
        }
        
        public void CheckForSearchEnter(KeyboardEventArgs e) {
            if(e.Key.Equals("Enter")) {
                SearchListings();
            }
        }

        private void NavigateToNewPage(string tsUrl) {
            Controller.NavigateTo(tsUrl);
        }


        #region Sorting Options

        public void Sort(string tsSortCriteria) {
            ///./././././././././.
            _controller.Sort(tsSortCriteria);
        }
        #endregion (Sorting Options)

        #endregion(Methods)

        #region Properties
        public MyListingsController Controller { get => _controller; set => _controller = value; }
        public string SearchString { get; set; }

        public List<ListingViewStatsCardDTO> ListingViewStatsCardDTOs {
            get { return _controller.ListingViewStatsCardDTOs; }
        }

        public List<ListingViewStatsCardDTO> ListingViewStatsCardDTOs_MasterList {
            get { return _controller.ListingViewStatsCardDTOs_MasterList; }
        }

        public List<ListingViewStatsCardDTO> DisplayList
        {
            get => GetCurrentList();
        }

        public bool IsAllExpanded {
            get => _controller.AllExpanded;
            set => _controller.AllExpanded = value;
        }
        
        public string TabStatus { get => _tabStatus; set => _tabStatus = value; }
        public Int64 StepOneOid { get => _stepOneOid; }
        public Int64 StepTwoOid { get => _stepTwoOid; }
        public Int64 StepThreeOid { get => _stepThreeOid; }
        public Int64 CompleteOid { get => _completeOid; }
        
        #endregion(Properties)
    }
}
