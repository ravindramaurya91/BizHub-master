using System;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.ListingDetail {
    public partial class CmpListingDetail {

        #region Properties
        [Parameter]
        public ListingDTO ListingDTO { get; set; }
        #endregion (Properties)

    }
}
