using System;
using System.Collections.Generic;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace BizHub.Components.Modals.AdvancedSearch {

    public partial class AdvancedSearchModal {

        public void SaveChanges() {
            BlazoredModal.Close(ModalResult.Ok(Controller.SearchCriteriaDisplay));
        }

        #region Properties
        [CascadingParameter]
        BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public AdvancedSearchController Controller { get; set; }
        [Parameter] public bool IsZipCodeValid { get; set; }
        [Parameter] public bool IsShowParentCheckBoxInBusinessCategoryModal { get; set; } = true;
        public string ModalId { get; set; } = "0";
        #endregion (Properties)


    }
}
