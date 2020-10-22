using System;
using System.Threading.Tasks;
using BizHub.Components.Modals.CreateContact;
using BizHub.Components.Modals.IdentityCard;
using Microsoft.AspNetCore.Components.Web;

using BizHub.Shared;
using Blazored.Modal;
using Blazored.Modal.Services;
using Model;

namespace BizHub.Pages {
    public partial class Home {

        #region Fields
        private BasePageController _controller = new BasePageController();
        #endregion (Fields)

        #region Constructor
        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
            }
        }
        #endregion (Constructor)


        #region Methods
        public void NavigateToNewPage(string tsNewPage) {
            Controller.NavigateTo(tsNewPage);
        }

        public void NavigateToListingsWithPayload() {
            Controller.NavigateToListingsWithPayload(new SearchCriteria { ZipCode = ZipCode });
        }

        public void CheckForZipCodeEnter(KeyboardEventArgs e) {
            if(e.Key.Equals("Enter")) {
                NavigateToListingsWithPayload();
            }
        }
        #endregion (Methods)

        #region Properties
        public string ZipCode { get; set; }
        public BasePageController Controller { get => _controller; set => _controller = value; }
        #endregion (Properties)

        
        public void CreateContact() {
            ShowModal();
        }
    
        async Task ShowModal() {
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.Class += "create-contact modal-forward";
            // oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(CmpCreateContact),"", oOptions).Result;
            if (BCModalResult.Cancelled) {
                Console.WriteLine("Modal was cancelled");
            } else {
                Console.WriteLine(BCModalResult.Data);
            }
        }
        
    }
}
