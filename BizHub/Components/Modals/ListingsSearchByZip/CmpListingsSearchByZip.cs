using System;
using System.Collections.Generic;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

using Model;
using Microsoft.AspNetCore.Components.Web;

namespace BizHub.Components.Modals.ListingsSearchByZip {
    public partial class CmpListingsSearchByZip {

        #region Methods
        protected override void OnInitialized() {
            SearchRadius = Convert.ToInt32(ZipCodeDistances[0].Value);
        }

        public void OnSearchRadiusChanged(string tsSearchRadius) {
            if (!string.IsNullOrEmpty(tsSearchRadius)) {
                if (!Double.IsNaN(Convert.ToInt32(tsSearchRadius))) {
                    SearchRadius = Convert.ToInt32(tsSearchRadius);
                }
            }
        }

        public void MilesSelected(string tsMilesSelected) {
            SearchRadius = Convert.ToInt32(tsMilesSelected);
        }

        public void OnSearchSelected() {
            if (!string.IsNullOrEmpty(ZipCode)) {
                BlazoredModal.Close(ModalResult.Ok<ZipCodeSelectModalResponse>(new ZipCodeSelectModalResponse { SearchRadius = SearchRadius, ZipCode = ZipCode }));
            }
        }

        public void CheckForZipCodeEnter(KeyboardEventArgs e) {
            if (e.Key.Equals("Enter")) {
                OnSearchSelected();
            }
        }
        #endregion(Methods)

        #region Properties
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }

        List<FSVisualItem> ZipCodeDistances = Constants.ZIPCODE_SEARCH_DISTANCES;
        [Parameter] public string ZipCode { get; set; }
        public int SearchRadius { get; set; }
        #endregion(Properties)


    }

    #region ModalResponseClass
    public class ZipCodeSelectModalResponse {
        public int SearchRadius { get; set; }
        public string ZipCode { get; set; }
    }
    #endregion (ModalResponseClass)

}
