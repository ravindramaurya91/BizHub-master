using System;
using System.Threading.Tasks;
using BizHub.Components.Modals.IdentityCard;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.BrokerSearch {
    public partial class CmpBrokerCard {
        #region Fields
        private BrokerCardDTO _brokerDTO = new BrokerCardDTO();
        private CmpBrokerCardController _controller = new CmpBrokerCardController();
        #endregion(Fields)

        #region Methods
        protected override void OnInitialized() {
            Controller.Initialize(BrokerDTO);
        }

        public void ViewProfileCard() {
            ShowProfileModal();
        }

        async Task ShowProfileModal() {
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("EntityOid", BrokerDTO.EntityOid);
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.Class += " identity-card-modal modal-forward";
            // oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(IdentityCard), "", oParameters, oOptions).Result;
            if (BCModalResult.Cancelled) {
                Console.WriteLine("Modal was cancelled");
            } else {
                Console.WriteLine(BCModalResult.Data);
            }
        }

        public async void ShowContactBrokerModal() {
            await ModalsService.ShowContactBrokerModal(BrokerDTO.EntityOid);
        }
        #endregion(Methods)

        #region Properties
        [Parameter] public BrokerCardDTO BrokerDTO { get => _brokerDTO; set => _brokerDTO = value; }

        public CmpBrokerCardController Controller { get => _controller; }
        public bool IsBrokerLoggedInUser { get => Controller.IsBrokerLoggedInUser; }
        #endregion(Properties)
    }
}