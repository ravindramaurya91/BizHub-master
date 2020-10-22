using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using BizHub.Components.Modals.Email_Send;
using BizHub.Components.Modals.IdentityCard;
using Blazored.Modal;
using Blazored.Modal.Services;
using CommonUtil;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace BizHub.Components.ListingManagement.ListingManagementGrid
{
    public partial class CmpListingManagementGridObj
    {
        #region Fields
        //private MyListingsController _controller = null;
        #endregion

        #region Method

        public void ViewContact(Int64 tiOid)
        {
            ViewContactModal(tiOid);
        }
        
        async Task ViewContactModal(Int64 tiOid) {
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("EntityOid", tiOid);
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.Class += " identity-card-modal modal-forward";
            // oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(IdentityCard),"", oParameters, oOptions).Result;
            if (BCModalResult.Cancelled) {
                Console.WriteLine("Modal was cancelled");
            } else {
                Console.WriteLine(BCModalResult.Data);
            }
        }

        public void EmailBuyer(ListingManagement_BuyerInfoDTO toContact)
        {
            // CommonUtil.Email Email = new Email();
            // MailAddress oAddress = new MailAddress(toContact.BuyerEmail);
            // Email.To.Add(oAddress);
            
            ShowModal(toContact);
        }
        
        async Task ShowModal(ListingManagement_BuyerInfoDTO toContact) {
            ModalParameters oParameters = new ModalParameters();
            //TODO: Add back when we have actual data to bind to
            oParameters.Add("ContactEmail", toContact.BuyerEmail);
            // oParameters.Add("EntityOid", BrokerDTO.EntityOid);
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.Class += " email-buyer-modal modal-forward";
            // oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(Email_Send),"", oParameters, oOptions).Result;
            if (BCModalResult.Cancelled) {
                Console.WriteLine("Modal was cancelled");
            } else {
                Console.WriteLine(BCModalResult.Data);
            }
        }
 
        #endregion

        #region Properties
        //public MyListingsController Controller { get => _controller; set => _controller = value; }
        [Parameter] public ListingManagement_BuyerInfoDTO ListingBuyerDetail { get; set; }
        public PagListingManagementController Controller { get; set; } = new PagListingManagementController();
        #endregion(Properties)
    }
}
