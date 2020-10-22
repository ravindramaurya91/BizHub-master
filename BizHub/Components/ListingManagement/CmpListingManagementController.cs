using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace BizHub.Components.ListingManagement
{
    public class CmpListingManagementController : BasePageController
    {
        #region Fields
        private BuyerProfileDTO _buyerProfileDTO;
        #endregion


        #region Constructor
        //public CmpListingManagementController(BuyerDetail buyerDetail) {
        //    _buyerDetail = buyerDetail;
        //}
        #endregion (Constructor)

        #region Methods

        #endregion (Methods)

        #region Properties
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
        #endregion (Properties)
    }
}
