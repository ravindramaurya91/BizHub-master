using System;
using BizHub.Components.Modals.ContactBroker;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System.Threading.Tasks;
using BizHub.Components.Modals.PreviewListingDetail;
using BizHub.Pages.ListingDetail;

namespace BizHub.Components.ListingSetup
{
    public partial class CmpListingSetupAdInfo {
        #region Fields
        private Listing _adListing = new Listing();
        private ListingDTO _listingDTO = new ListingDTO();
        private PagListingSetupController _controller = new PagListingSetupController();
        #endregion (Fields)

        #region Constructor
        #endregion(Constructor)

        #region Methods

        public void PreviewAd()
        {
            ShowModal();
        }

        async Task ShowModal() {
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("PreviewListingDTO", ListingDTO);
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.Class += " jumbo-modal modal-forward";
            // oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(CmpPreviewListingDetail),"", oParameters, oOptions).Result;
            if (BCModalResult.Cancelled) {
                Console.WriteLine("Modal was cancelled");
            } else {
                Console.WriteLine(BCModalResult.Data);
            }
        }

        public void UpdateBusinessDescription(string tsAboutBusiness) {
            ListingDTO.AdDescription = tsAboutBusiness;
        }

        string RadioValue = "Allow ad to be seen by the general public";
        string LandingPage = "yes";

        void LandingPageSelection(Microsoft.AspNetCore.Components.ChangeEventArgs args) {
            LandingPage = args.Value.ToString();
        }

        void RadioSelection(Microsoft.AspNetCore.Components.ChangeEventArgs args) {
            RadioValue = args.Value.ToString();
        }
        
        protected override void OnInitialized()
        {
            SetShowOptions();
        }

        public void SetShowOptions()
        {
            if (ListingDTO.ShowCounty_Int == null || ListingDTO.ShowCounty_Int <= 0)
            {
                ListingDTO.ShowCounty_Int = 2;
            }
            if (ListingDTO.ShowCity_Int == null || ListingDTO.ShowCity_Int <= 0)
            {
                ListingDTO.ShowCity_Int = 2;
            }
            if (ListingDTO.ShowZip_Int == null || ListingDTO.ShowZip_Int <= 0)
            {
                ListingDTO.ShowZip_Int = 2;
            }
            if (ListingDTO.ShowGrossRevenues_Int == null || ListingDTO.ShowGrossRevenues_Int <= 0)
            {
                ListingDTO.ShowGrossRevenues_Int = 2;
            }
            if (ListingDTO.ShowCashFlow_Int == null || ListingDTO.ShowCashFlow_Int <= 0)
            {
                ListingDTO.ShowCashFlow_Int = 2;
            }
            if (ListingDTO.ShowEBITDA_Int == null || ListingDTO.ShowEBITDA_Int <= 0)
            {
                ListingDTO.ShowEBITDA_Int = 2;
            }
            if (ListingDTO.ShowInventory_Int == null || ListingDTO.ShowInventory_Int <= 0)
            {
                ListingDTO.ShowInventory_Int = 2;
            }
            if (ListingDTO.ShowFFE_Int == null || ListingDTO.ShowFFE_Int <= 0)
            {
                ListingDTO.ShowFFE_Int = 2;
            }
            if (ListingDTO.ShowCompanyWebsite_Int == null || ListingDTO.ShowCompanyWebsite_Int <= 0)
            {
                ListingDTO.ShowCompanyWebsite_Int = 2;
            }
            if (ListingDTO.ShowNumberOfEmployees_Int == null || ListingDTO.ShowNumberOfEmployees_Int <= 0)
            {
                ListingDTO.ShowNumberOfEmployees_Int = 2;
            }
            if (ListingDTO.ShowYearEstablished_Int == null || ListingDTO.ShowYearEstablished_Int <= 0)
            {
                ListingDTO.ShowYearEstablished_Int = 2;
            }   
        }

        #endregion(Methods)

        #region Properties

        [Parameter]
        public ListingDTO ListingDTO { get => _listingDTO; set => _listingDTO = value; }

        [Parameter]
        public Listing AdListing { get => _adListing; set => _adListing = value; }

        [Parameter]
        public PagListingSetupController Controller { get; set; }

        public bool IsSubmitted { get => Controller.IsSubmitted; set => Controller.IsSubmitted = value; }


        #endregion(Properties)

    }
}