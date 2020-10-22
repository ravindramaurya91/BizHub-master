using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizHub.Services;
using BizHub.Shared;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Pages.ListingSetup {
    public partial class PagListingSetup {

        #region Constructor  
        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                if (ListingOid != null && ListingOid > 0) {
                    Controller.GetAndSetListingDTOByOid((long)ListingOid);
                    CurrentStep = UrlCurrentStep;
                    if (CurrentStep == null || CurrentStep <= 0 || CurrentStep > 3)
                    {
                        Controller.SetActiveArrow();
                    }
                } else {
                    Controller.CreateDefaultListingDTO();
                    CurrentStep = 1;
                }
                IsLoading = false;
                this.StateHasChanged();
            }
        }

        protected override void OnInitialized() {
            IsLoading = true;
            Controller = new PagListingSetupController();
            IsSubmitted = false;
        }
        #endregion (Constructor)

        #region Methods
        public void ArrowSelected(Int64 tiStepNumber) {
            Controller.ArrowSelected(tiStepNumber);
            this.StateHasChanged();
        }

        public void NavToNewPage(string tsItem)
        {
            if (tsItem == "Login")
            {
                Controller.NavigateTo("Identity/Account/Login");
            } else 
            {
                Controller.NavigateTo("");
            }
        }

        public void CompleteListing() {
            Controller.CompleteListing();
            this.StateHasChanged();
        }

        public void SaveAndExit()
        {
            Controller.SaveAndExit();
            this.StateHasChanged();
        }
        #endregion (Methods)

        #region Properties
        [Parameter]
        public Int64? ListingOid { get; set; }

        public bool IsLoading { get; set; }
        public bool IsSubmitted { get => Controller.IsSubmitted; set => Controller.IsSubmitted = value; }
        public PagListingSetupController Controller { get; set; }
        public ListingDTO CreateListingDTO { get => Controller.ListingDTO; set => Controller.ListingDTO = value; }
        public Int64 CurrentStep { get => Controller.CurrentStep; set => Controller.CurrentStep = value; }
        [Parameter] public Int64 UrlCurrentStep { get; set; }
        #endregion (Properties)




    }
}