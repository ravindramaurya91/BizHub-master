using System;
using System.Collections.Generic;
using BizHub.Services;
using Blazored.Modal;
using Blazored.Modal.Services;
using BizHub.Components.Modals.Generic;

using Model;
using System.Threading.Tasks;

namespace BizHub.Pages.SavedSearches {
    public class PagSavedSearchesController : BasePageController {

        #region Fields
        private List<SearchCriteriaDisplay> _savedSearches = new List<SearchCriteriaDisplay>();
        #endregion(Fields)

        #region Methods
        public void GetMySavedSearches() {
            try {
                SavedSearches = DataService.GetMySavedSearches();
            } catch (Exception ex) {
                ShowPopupDialog("Unable to retrieve saved searches <br>" + ex.Message, "Error");
            }
        }

        public async Task<bool> ConfirmDeleteSearch(SearchCriteriaDisplay toDisplay) {
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.HideHeader = true;
            oOptions.Class += " bizhub-large-modal";
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("Options", DeleteModalOptions);
            ModalResult DeleteModalResult = await ShowModal(typeof(GenericModal), "", oParameters, oOptions).Result;
            if (DeleteModalResult.Data.Equals(Constants.BUTTON_YES)) {
                return true;
            } else {
                return false;
            }
        }

        public void DeleteSearch(SearchCriteriaDisplay toDisplay) {
            toDisplay.IsActive = false;
            toDisplay.SearchCriteria.Save();
        }
        #endregion(Methods)

        #region Properties
        public List<SearchCriteriaDisplay> SavedSearches { get => _savedSearches; set => _savedSearches = value; }
        public FSGenericModalOptions DeleteModalOptions { get; set; } = new FSGenericModalOptions() {
            Header = "Delete",
            Body = "Are you sure you want to delete this search?",
            Buttons = new List<FSModalButton>() {
                new FSModalButton(Constants.BUTTON_YES, true),
                new FSModalButton(Constants.BUTTON_NO)
            }
        };
        #endregion(Properties)
    }
}