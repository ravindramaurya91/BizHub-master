using Blazored.Modal;
using System;
using System.Threading.Tasks;

using BizHub.Components.Modals.ContactBroker;

using Model;

namespace BizHub {
    public class ModalsService {

        public static async Task ShowContactBrokerModal(Int64 tiBrokerOid, ListingDTO? ListingDTO = null) {
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("BrokerOid", tiBrokerOid);
            if(ListingDTO != null) {
                oParameters.Add("ListingDTO", ListingDTO);
            }

            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.Class += " contact-broker-card-modal";

            BasePageController oCtr = new BasePageController();
            await oCtr.ShowModal(typeof(CmpContactBroker), "", oParameters, oOptions).Result;
        }


    }
}
