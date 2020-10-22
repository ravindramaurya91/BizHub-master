using System;
using System.Collections.Generic;

using Model;

namespace BizHub.Pages.BrokerSearch {
    public partial class PagBrokerSearch {
        #region Fields
        private PagBrokerSearchController _pageController;
        #endregion (Fields)

        #region Methods
        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                Controller.Initialize();
                IsLoading = false;
                StateHasChanged();
            }
        }

        protected override void OnInitialized() {
            Controller = new PagBrokerSearchController();
        }

        public void GetBrokerCards() {
            IsLoading = true;
            Controller.GetBrokerCards();
            IsLoading = false;
        }
        #endregion (Methods)

        #region Properties
        public bool IsLoading { get; set; } = true;
        public PagBrokerSearchController Controller { get => _pageController; set => _pageController = value; }
        public List<BrokerCardDTO> BrokerCards { get => Controller.BrokerCards; }
        #endregion (Properties)
    }
}