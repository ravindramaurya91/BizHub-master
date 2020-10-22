using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.Components.ListingSetup {
    public partial class CmpListingSetupFinancial {

        #region Methods
        protected override void OnInitialized() {
            if (ListingDTO.IsSellerFinanace == null)
            {
                ListingDTO.IsSellerFinanace = true;   
            }
        }
        public void ChangeIsSellerFinance(string tsSellerFinance) {
            ListingDTO.IsSellerFinanace = (tsSellerFinance == "true") ? true : false;
        }
        #endregion (Methods)

        #region Properties
        [Parameter] public ListingDTO ListingDTO { get; set; }
        [Parameter] public PagListingSetupController Controller { get; set; }

        public bool IsSubmitted { get => Controller.IsSubmitted; set => Controller.IsSubmitted = value; }
        #endregion (Properties)

        #region PreDefinedHTML
        public readonly List<FSVisualItem> SELLER_FINANCED_RADIO_BUTTONS = new List<FSVisualItem> {
            new FSVisualItem {Label = "Yes", Value = "true", CustomCSS = "e-primary", ElementName = "SellerFinance"},
            new FSVisualItem {Label = "No", Value = "2false", CustomCSS = "e-primary", ElementName = "SellerFinance"}
        };
        #endregion (PreDefinedHTML)
    }
    
    
}
