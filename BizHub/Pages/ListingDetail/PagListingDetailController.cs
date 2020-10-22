using System;
using BizHub.Components.ListingDetail;
using Model;

namespace BizHub {
    public class PagListingDetailController : BasePageController {

        #region Fields
        private ListingDTO _listingDTO;
        private BrokerCardDTO _brokerCard = new BrokerCardDTO();

        #endregion (Fields)

        #region Methods
        public void GetSimilarListings() {
            try {
                BrokerCard = BrokerCardDTO.GetBrokerCardDTOByEntityOid(ListingDTO.EntityOid);
            } catch (Exception ex) {
                ShowPopupDialog(ex.Message, "Error");
            }
        }

        public void GetBrokerCardDTO() {
            try {
                BrokerCard = BrokerCardDTO.GetBrokerCardDTOByEntityOid(ListingDTO.EntityOid);
            } catch (Exception ex) {
                ShowPopupDialog(ex.Message, "Error");
            }
        }

        public void GetBusinessListing(Int64 tiListingOid) {
            try {
                ListingDTO = SQL.GetListingDTOByListingOid(tiListingOid, true);
            } catch (Exception ex) {
                ShowPopupDialog(ex.Message, "Error");
            }
        }

       
        #endregion (Methods)

        #region Properties
        public ListingDTO ListingDTO {get => _listingDTO; set => _listingDTO = value; }
        public BrokerCardDTO BrokerCard { get => _brokerCard; set => _brokerCard = value; }

        #endregion (Properties)

    }
}
