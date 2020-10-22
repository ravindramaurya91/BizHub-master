using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace BizHub.Components.ListingManagement
{
    public class BuyerModalController : BasePageController
    {
        #region Fields
        private CmpListingManagementController _listingController;
        private BuyerProfileDTO _buyerProfileDTO;
        #endregion

        #region Methods
        public BuyerModalController(BuyerProfileDTO toBuyerProfileDTO)
        {
            _buyerProfileDTO = toBuyerProfileDTO;
        }
        #endregion

        #region Properties
        //public ListingManagementController ListingController { get => _listingController; set => _listingController = value; }
        public BuyerProfileDTO BuyerProfileDTO
        {
            get { return _buyerProfileDTO; }
            set
            {
                if (_buyerProfileDTO != value)
                {
                    _buyerProfileDTO = value;
                }
            }
        }
        #endregion
    }
}
