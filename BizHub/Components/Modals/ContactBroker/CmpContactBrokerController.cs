using BizHub.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub{
    public class CmpContactBrokerController : BasePageController {

        #region Fields
        private ContactRequest _request = new ContactRequest();
        #endregion (Fields)


        #region Methods
        public void SendContact() {
            Request.EntityEmail_To = BrokerCardDTO.Email;
            Request.EntityOid_ContactTo = BrokerCardDTO.EntityOid;
            Request.SendRequest(ListingDTO);

            ShowPopupDialog("Contact Request Sent", "Success");
        }

        public void GetBrokerCardDTO(Int64 tiBrokerEntityOid) {
            try {
                BrokerCardDTO = DataService.GetBrokerCardByEntityOid(tiBrokerEntityOid);
            } catch (Exception ex) {
                ShowPopupDialog(ex.Message, "Error");
            }
        }
        #endregion (Methods)

        #region Properties
        public BrokerCardDTO BrokerCardDTO { get; set; }
        public ContactRequest Request { get => _request; set => _request = value; }
        public ListingDTO ListingDTO { get; set; }
        #endregion (Properties)
    }
}
