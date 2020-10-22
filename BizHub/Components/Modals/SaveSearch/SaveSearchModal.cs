using System;
using Blazored.Modal;
using Blazored.Modal.Services;
using CommonUtil;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

using Model;

namespace BizHub.Components.Modals.SaveSearch {
    public partial class SaveSearchModal {

        private BasePageController _controller = new BasePageController();
        private string _originalSearchName = "";

        protected override void OnInitialized() {
            Options = new FSGenericModalOptions() { Header = "Save Search" };
            if (IsSearchExists == true) {
                Options.Buttons = new List<FSModalButton>() {
                new FSModalButton(Constants.BUTTON_UPDATE, true),
                new FSModalButton(Constants.BUTTON_SAVE_NEW)
            };
            } else {
                Options.Buttons = new List<FSModalButton>() {
                    new FSModalButton(Constants.BUTTON_SAVE, true),
                };
            }
            if (!string.IsNullOrEmpty(SearchName)) {
                _originalSearchName = SearchName.DeepClone<string>();
            }
        }

        public void ButtonSelected(FSModalButton toButton) {
            if (toButton.Equals(Constants.BUTTON_SAVE_NEW) && _originalSearchName.Equals(SearchName)) {
                _controller.ShowPopupDialog("To create a new search it must have a different name than the current search", "Warning");
            } else {
                BlazoredModal.Close(ModalResult.Ok(new SaveSearchModalResponse() { ButtonName = toButton.Name, SearchName = SearchName }));
            }
        }

        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public bool IsSearchExists { get; set; }
        [Parameter] public string SearchName { get; set; }

        public FSGenericModalOptions Options { get; set; }
    }

    public class SaveSearchModalResponse {
        public string ButtonName { get; set; }
        public string SearchName { get; set; }
    }
}
