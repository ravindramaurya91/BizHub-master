using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using BizHub.Components.Modals.Email_Send;
using BizHub.Components.Modals.HierarchicSelector;
using BizHub.Shared;
using Blazored.Modal;
using Blazored.Modal.Services;
using CommonUtil;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.Pages.AccountSetup {

    public partial class PagAccountSetup {


        #region Fields
        private PagAccountSetupController _controller = new PagAccountSetupController();
        #endregion (Fields)

        #region Constructor
        public PagAccountSetup() {
        }
        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                if (CurrentMenu <= 0 || CurrentMenu == null) {
                    SelectMenuItem(1);
                }
            }
        }
        #endregion (Constructor)

        #region Methods

        public void GenerateEmail() {
            Email oEmail = new Email();
            oEmail.From = new MailAddress(SessionMgr.Instance.User.Email);
            ShowModal(oEmail);
        }
        
        async Task ShowModal(CommonUtil.Email email) {
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("Email", email);
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = false;
            oOptions.Class += " business-category-modal modal-forward";
            oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(Email_Send), "", oParameters, oOptions).Result;
            if (BCModalResult.Cancelled) {
                Console.WriteLine("Modal was cancelled");
            } else {
                Console.WriteLine(BCModalResult);
            }
        }
        
        public void SelectMenuItem(int menuNumber) {
            if (menuNumber == 9)
            {
                GenerateEmail();
            }
            else
            {
                Controller.NavigateTo("/Account-Setup/" + menuNumber);   
            }
        }
        #endregion(Methods)

        #region Properties
        [Parameter]
        public long CurrentMenu { get; set; }
        public PagAccountSetupController Controller {get => _controller; set => _controller = value; }
        public CmpOrganizationsController OrganizationController {get => _controller.CmpOrganizationsController; }
        #endregion(Properties)
    }
}
