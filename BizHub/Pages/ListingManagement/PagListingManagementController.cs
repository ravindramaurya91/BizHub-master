using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub {
    public class PagListingManagementController : BasePageController {
        #region Fields
        private CmpOrganizationsController _organizationController;
        private List<ListingDTO_Short> _listings = new List<ListingDTO_Short>();
        #endregion(Fields)

        #region Constructor
        public PagListingManagementController() {
            Listings = SQL.ListingDTO_ShortByEntityLoggedInUser();
        }
        #endregion (Constructor)

        #region Properties
        public List<ListingDTO_Short> Listings { get => _listings; set => _listings = value; }
        #endregion (Properties 
    }
}
