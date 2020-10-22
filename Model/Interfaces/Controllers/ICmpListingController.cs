using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public interface ICmpListingController {

        #region Methods
        void NavigateToListingDetail(Int64 tiListingOid);
        void ToggleListingFavorite(ListingDTO toListingDTO);
        #endregion (Methods)

        #region Properties
        #endregion (Properties)

    }
}
