using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using BizHub.Components.Modals.ContactBroker;
using Blazored.Modal.Services;

using Model;

namespace BizHub.Components.Modals.IdentityCard {
    public partial class IdentityCard {

        #region Fields
        private IdentityCardController _controller = new IdentityCardController();
        #endregion(Fields)

        #region Methods
        public async void ShowContactBrokerModal() {
            await ModalsService.ShowContactBrokerModal(IdentityCardDTO.Oid);
        }
        #endregion(Methods)

        #region Properties
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public Int64 EntityOid { set => _controller.EntityOid = value; }

        public IdentityCardDTO IdentityCardDTO { get => _controller.IdentityCardDTO; }
        public bool IsLoggedInUser { get => _controller.IsLoggedInUser; }
        public IdentityCardController Controller { get => _controller; set => _controller = value; }
        #endregion(Properties)
    }

}