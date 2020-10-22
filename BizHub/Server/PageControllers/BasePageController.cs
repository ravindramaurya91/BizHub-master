using BizHub.Shared;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;

using Model;
using BizHub.Components.Modals.Generic;

namespace BizHub {
    public class BasePageController {

        #region Events
        public event EventHandler On_Error;
        #endregion (Events)

        #region Fields
        protected BizHubUser _loggedInUser = SessionMgr.Instance.User;
        #endregion (Fields)

        #region Constructor
        public BasePageController() { }
        ~BasePageController() { DeactivateEvents(); }
        #endregion (Constructor)

        #region Methods

        #region Popup Dialog
        public void ShowPopupDialog(string tsContent, string? tsDialogType, string? tsHeader) {
            ModalParameters oParameters = new ModalParameters();
            FSInfoModalOptions oOptions = new FSInfoModalOptions(tsDialogType);
            oOptions.Body = tsContent;
            oOptions.Header = tsHeader;
            oParameters.Add("Options", oOptions);

            FSBlazorModalOptions oModalOptions = new FSBlazorModalOptions();
            oModalOptions.HideCloseButton = true;
            oModalOptions.DisableBackgroundCancel = false;

            ShowModal(typeof(GenericModal), "", oParameters, oModalOptions);
        }

        public void ShowPopupDialog(string tsContent) {
            ShowPopupDialog(tsContent, null, null);
        }

        public void ShowPopupDialog(string tsContent, string? tsDialogType) {
            ShowPopupDialog(tsContent, tsDialogType, null);
        }
        #endregion (Popup Dialog)

        public virtual void ActivateEvents() {
            // This method should be overriden by the subclassed controllers to load all of the the events they want to listenet to
        }
        public virtual void DeactivateEvents() {
            // This class should be overriden by the subclassed controllers to remove any events they setup in the ActivateEvents() method.
        }

        public void NavigateToListingsWithPayload(SearchCriteria toCriteria) {
            NavManager.NavigateTo("/Listings/" + SearchCriteria.ToUrl(toCriteria));
        }

        public void NavigateTo(string tsUrl) {
            NavManager.NavigateTo(tsUrl);
        }

        public IModalReference ShowModal(System.Type ttComponentType) {
            return BHModalService.Show(ttComponentType);
        }

        public IModalReference ShowModal(System.Type ttComponentType, string tsTitle) {
            return BHModalService.Show(ttComponentType, tsTitle);
        }

        public IModalReference ShowModal(System.Type ttComponentType, string tsTitle, ModalParameters toParameters) {
            return BHModalService.Show(ttComponentType, tsTitle, toParameters);
        }

        public IModalReference ShowModal(System.Type ttComponentType, string tsTitle, ModalOptions toOptions) {
            return BHModalService.Show(ttComponentType, tsTitle, toOptions);
        }

        public IModalReference ShowModal(System.Type ttComponentType, string tsTitle, ModalParameters toParameters, ModalOptions toOptions) {
            return BHModalService.Show(ttComponentType, tsTitle, toParameters, toOptions);
        }

        public void SetGlobalIsLoading(bool tbValue) {
            FSPageTools.Instance.MainLayout.SetIsLoading(tbValue);
        }
        #endregion (Methods)

        #region Properties
        public NavigationManager NavManager {
            get {
                return FSPageTools.Instance.NavManager;
            }
        }

        public IModalService BHModalService {
            get {
                return FSPageTools.Instance.ModalService;
            }
        }
        public BizHubUser LoggedInUser { get => _loggedInUser; set => _loggedInUser = value; }
        #endregion (Properties)
    }

    public class ControllerEventArgs : EventArgs {
        public BasePageController Controller { get; internal set; }
        public Exception Exception { get; internal set; }
    }
}
