using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Model;
using BizHub.Components.Modals.AddBuyer;

namespace BizHub.Components.ListingManagement
{
    public partial class CmpListingGrid
    {
        #region Fields
        private PagListingManagementController _controller = null;
        #endregion

        #region Method
        protected override void OnInitialized(){
        }
        public void OpenAddBuyerModal()
        {
            ShowAddBuyerModal();
        }

        public void ToggleExpanded(ListingDTO_Short toListing) {
            toListing.IsExpanded = !toListing.IsExpanded;
        }

        async Task ShowAddBuyerModal()
        {
            // The user has pressed the "Add Buyer" button on a listing.  We will now
            // pop a modal dialog to allow the user to enter the new Buyer's name, etc.
            // then add a new buyer to the database as associated with this listing

            BuyerProfileDTO oBuyerProfileDTO = new BuyerProfileDTO();
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("BuyerProfileDTO", oBuyerProfileDTO);
            oParameters.Add("ModalHeader", "Buyer");
            oParameters.Add("ModalSubHeader", "Add Buyer to Listing");
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = false;
            oOptions.Class += " business-category-modal modal-forward";
            oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(CmpAddBuyer), "", oParameters, oOptions).Result;
            if (BCModalResult.Cancelled)
            {
                Console.WriteLine("Modal was cancelled");
            }
            else
            {
                oBuyerProfileDTO = (BuyerProfileDTO)BCModalResult.Data;
                // We should first use the buyer's email to see if a record already exists in the database.  
                // If it does we will use the Entity.Oid to map the buyer to the listing.  
                // If it does not, we will create a new Entity record, Save te Entity record, then harvest the Oid 
                // to map the buyer to the listing.

                StateHasChanged();
            }
        }
        #endregion

        #region Properties
        [Parameter] public PagListingManagementController Controller { get => _controller; set => _controller = value; }
        public List<ListingDTO_Short> Listings { get => _controller.Listings; }
        //{
        //    new ListingManagementDTO{ListName="Barre Code",Count=2},
        //    new ListingManagementDTO{ListName="Cut And Beyond",Count=2},
        //    new ListingManagementDTO{ListName="Barre Code",Count=2},
        //    new ListingManagementDTO{ListName="Daily Method",Count=2},
        //    new ListingManagementDTO{ListName="Eurasian Auto Repair",Count=2},
        //    new ListingManagementDTO{ListName="Holistic PT",Count=2}
        //};
        #endregion(Properties)
    }
}
