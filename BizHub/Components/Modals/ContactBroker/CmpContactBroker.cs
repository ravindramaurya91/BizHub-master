using System;
using System.Collections.Generic;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.Components.Modals.ContactBroker {
    public partial class CmpContactBroker {
        #region Fields
        CmpContactBrokerController _controller = new CmpContactBrokerController();
        private string _preferredMethodOfContact = "";
        #endregion(Fields)

        #region Constructor
        protected override void OnInitialized() {
            if(ListingDTO != null) {
                Request.ListingOid = ListingDTO.Oid;
            }
            GetAllContactInformation();
        }
        #endregion(Constructor)

        #region Methods
        public void GetAllContactInformation() {
            GetBrokerInformation();
            AssignLoggedInUserInfo();
        }

        public void GetBrokerInformation() {
            Controller.GetBrokerCardDTO(BrokerOid);
        }

        public void AssignLoggedInUserInfo() {
            BizHubUser oUser = SessionMgr.Instance.User;
            if(oUser != null) {
                Request.FirstName = oUser.FirstName;
                Request.LastName = oUser.LastName;
                Request.Phone = oUser.PhoneNumber;
                Request.EntityEmail_From = oUser.Email;
                Request.EntityOid_ContactFrom = oUser.EntityOid;
            }
        }

        public void onCheckSelected(ChangeEventArgs te) {
            Request.Is401KReferral = (bool)te.Value;
        }

        public void SendContact() {
            Controller.SendContact();
            BlazoredModal.Close();
        }
        #endregion(Methods)

        #region Properties
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter] public Int64 BrokerOid { get; set; }
        [Parameter] public ListingDTO ListingDTO { get => Controller.ListingDTO; set => Controller.ListingDTO = value; }

        public ContactRequest Request { get => Controller.Request; set => Controller.Request = value; }
        public BrokerCardDTO BrokerCardDTO { get => Controller.BrokerCardDTO; }
        public CmpContactBrokerController Controller { get => _controller; set => _controller = value; }
        #endregion(Properties)

        #region PreDefinedHTML
        public readonly List<FSVisualItem> CONACT_RADIO_BUTTONS = new List<FSVisualItem> {
            new FSVisualItem {Label = "Phone Call", Value = "1", ElementName = "PreferPhoneCall", CustomCSS="e-primary"},
            new FSVisualItem {Label = "Email", Value = "2", ElementName = "PreferEmail", CustomCSS="e-primary"}
        };
        #endregion(PreDefinedHTML)
    }
}