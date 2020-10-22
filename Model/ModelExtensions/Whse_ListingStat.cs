using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Model {
    public partial class Whse_ListingStat {


        public static Whse_ListingStat CreateNewEmptyRecord(Int64 tiListingOid) {
            return new Whse_ListingStat() {
                ListingOid = tiListingOid, EntityOid = -1,EntityOid_Master = -1, EntityOid_Region = -1, EntityOid_Office = -1, CompanyName = "", AdTitle = "", AdTagLine = "",
                Views = 0, ViewsLast3Months = 0, ViewsLastMonth = 0, ViewsLast7Days = 0, ViewsLast24Hrs = 0, Views_LastLook = 0, 
                Clicks = 0, ClicksLast3Months = 0, ClicksLast24Hrs = 0, ClicksLast7Days = 0, ClicksLastMonth = 0, Clicks_LastLook = 0,
                Favorited = 0, FavoritedLast24Hrs = 0, FavoritedLast3Months = 0, FavoritedLast7Days = 0, FavoritedLastMonth = 0, Favorited_LastLook = 0,
                ContactRequests = 0, ContactRequestsLast24Hrs = 0, ContactRequestsLast3Months = 0, ContactRequestsLast7Days = 0, ContactRequestsLastMonth = 0, ContactRequests_LastLook = 0
            };
        }



        #region Properties
        [Ignore]
        public int ViewsIncrease { get { return (Views - Views_LastLook); } }
        [Ignore]
        public int ViewsOver90Days { get { return (Views - ViewsLast3Months ); } }
        [Ignore]
        public int ClicksIncrease { get { return (Clicks - Clicks_LastLook); } }
        [Ignore]
        public int ClicksOver90Days { get { return (Clicks - ClicksLast3Months); } }
        [Ignore]
        public int FavoritedIncrease { get { return (Favorited - Favorited_LastLook); } }
        [Ignore]
        public int FavoritedOver90Days { get { return (Favorited - FavoritedLast3Months); } }
        [Ignore]
        public int ContactRequestsIncrease { get { return (ContactRequests - ContactRequests_LastLook); } }
        [Ignore]
        public int ContactRequestsOver90Days { get { return (ContactRequests - ContactRequestsLast3Months); }}

        #endregion (Properties)

}
}
