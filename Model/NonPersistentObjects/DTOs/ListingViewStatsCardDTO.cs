using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using PetaPoco;

namespace Model {
    [Serializable]
    public class ListingViewStatsCardDTO : Whse_ListingStat {

        #region Sorting Options

        #region CompanyName
        public static int SortByCompanyName(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (x == null || x.CompanyName == null) {
                if (y == null || y.CompanyName == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (y == null || y.CompanyName == null) {
                    iReturn = -1;
                } else {
                    iReturn = x.CompanyName.CompareTo(y.CompanyName);
                }
            }
            return iReturn;
        }
        #endregion (CompanyName)

        #region Ad Title
        public static int SortByAdTitle(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (x == null || x.AdTitle == null) {
                if (y == null || y.AdTitle == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (y == null || y.AdTitle == null) {
                    iReturn = -1;
                } else {
                    iReturn = x.AdTitle.CompareTo(y.AdTitle);
                }
            }
            return iReturn;
        }
        #endregion (Ad Title)

        #region Views

        #region Views 24 Hours
        public static int SortByViews24HourDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null ) {
                if (x == null ) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null ) {
                    iReturn = -1;
                } else {
                    iReturn = y.ViewsLast24Hrs.CompareTo(x.ViewsLast24Hrs);
                }
            }
            return iReturn;
        }
        #endregion (Views 24 Hours)

        #region Views 7 Days
        public static int SortByViewsLast7DaysDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ViewsLast7Days.CompareTo(x.ViewsLast7Days);
                }
            }
            return iReturn;
        }
        #endregion (Views 7 Days)

        #region Views Last  Month
        public static int SortByViewsLastMonthDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null ) {
                if (x == null ) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null ) {
                    iReturn = -1;
                } else {
                    iReturn = y.ViewsLastMonth.CompareTo(x.ViewsLastMonth);
                }
            }
            return iReturn;
        }
        #endregion (Views Last  Month)

        #region Views Last 3 Months
        public static int SortByViewsLast3MonthsDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null ) {
                if (x == null ) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null ) {
                    iReturn = -1;
                } else {
                    iReturn = y.ViewsLast3Months.CompareTo(x.ViewsLast3Months);
                }
            }
            return iReturn;
        }

        #endregion (Views Last 3 Months)

        #region Views Over 90 Days
        public static int SortByViewsOver90DaysDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null || y.ViewsOver90Days == null) {
                if (x == null || x.ViewsOver90Days == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null || x.ViewsOver90Days == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ViewsOver90Days.CompareTo(x.ViewsOver90Days);
                }
            }
            return iReturn;
        }
        #endregion (ViewsOver90Days Over 90 Days)

        #region Total Views
        public static int SortByViewsDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null ) {
                if (x == null ) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null || x.Views == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.Views.CompareTo(x.Views);
                }
            }
            return iReturn;
        }

        #endregion (Total Views)

        #endregion (Views)

        #region Clicks

        #region Clicks 24 Hours
        public static int SortByClicks24HourDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ClicksLast24Hrs.CompareTo(x.ClicksLast24Hrs);
                }
            }
            return iReturn;
        }
        #endregion (Clicks 24 Hours)

        #region Clicks 7 days
        public static int SortByClicksLast7DaysDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ClicksLast7Days.CompareTo(x.ClicksLast7Days);
                }
            }
            return iReturn;
        }
        #endregion (Clicks 7 Days)

        #region Clicks Last  Month
        public static int SortByClicksLastMonthDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ClicksLastMonth.CompareTo(x.ClicksLastMonth);
                }
            }
            return iReturn;
        }
        #endregion (Clicks Last  Month)

        #region Clicks Last 3 Months
        public static int SortByClicksLast3MonthsDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null ) {
                if (x == null ) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null ) {
                    iReturn = -1;
                } else {
                    iReturn = y.ClicksLast3Months.CompareTo(x.ClicksLast3Months);
                }
            }
            return iReturn;
        }

        #endregion (Clicks Last 3 Months)

        #region Clicks Over 90 Days
        public static int SortByClicksOver90DaysDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null || y.ClicksOver90Days == null) {
                if (x == null || x.ClicksOver90Days == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null || x.ClicksOver90Days == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ClicksOver90Days.CompareTo(x.ClicksOver90Days);
                }
            }
            return iReturn;
        }
        #endregion (ClicksOver90Days Over 90 Days)

        #region Total Clicks
        public static int SortByClicksDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null ) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null ) {
                    iReturn = -1;
                } else {
                    iReturn = y.Clicks.CompareTo(x.Clicks);
                }
            }
            return iReturn;
        }

        #endregion (Total Clicks)

        #endregion (Clicks)

        #region Favorited

        #region Favorited 24 Hours
        public static int SortByFavorited24HourDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.FavoritedLast24Hrs.CompareTo(x.FavoritedLast24Hrs);
                }
            }
            return iReturn;
        }
        #endregion (Favorited 24 Hours)

        #region Favorited 7 days
        public static int SortByFavoritedLast7DaysDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.FavoritedLast7Days.CompareTo(x.FavoritedLast7Days);
                }
            }
            return iReturn;
        }
        #endregion (Favorited 7 Days)

        #region Favorited Last  Month
        public static int SortByFavoritedLastMonthDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.FavoritedLastMonth.CompareTo(x.FavoritedLastMonth);
                }
            }
            return iReturn;
        }
        #endregion (Favorited Last  Month)

        #region Favorited Last 3 Months
        public static int SortByFavoritedLast3MonthsDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null ) {
                if (x == null ) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null ) {
                    iReturn = -1;
                } else {
                    iReturn = y.FavoritedLast3Months.CompareTo(x.FavoritedLast3Months);
                }
            }
            return iReturn;
        }

        #endregion (Favorited Last 3 Months)

        #region Favorited Over 90 Days
        public static int SortByFavoritedOver90DaysDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null ) {
                if (x == null ) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null ) {
                    iReturn = -1;
                } else {
                    iReturn = y.FavoritedOver90Days.CompareTo(x.FavoritedOver90Days);
                }
            }
            return iReturn;
        }
        #endregion (FavoritedOver90Days Over 90 Days)

        #region Total Favorited
        public static int SortByFavoritedDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.Favorited.CompareTo(x.Favorited);
                }
            }
            return iReturn;
        }

        #endregion (Total Favorited)

        #endregion (Favorited)

        #region ContactRequests
        #region ContactRequests 24 Hours
        public static int SortByContactRequests24HourDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ContactRequestsLast24Hrs.CompareTo(x.ContactRequestsLast24Hrs);
                }
            }
            return iReturn;
        }
        #endregion (ContactRequests 24 Hours)

        #region ContactRequests 7 days
        public static int SortByContactRequestsLast7DaysDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ContactRequestsLast7Days.CompareTo(x.ContactRequestsLast7Days);
                }
            }
            return iReturn;
        }
        #endregion (ContactRequests 7 Days)

        #region ContactRequests Last  Month
        public static int SortByContactRequestsLastMonthDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ContactRequestsLastMonth.CompareTo(x.ContactRequestsLastMonth);
                }
            }
            return iReturn;
        }
        #endregion (ContactRequests Last  Month)

        #region ContactRequests Last 3 Months
        public static int SortByContactRequestsLast3MonthsDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null ) {
                if (x == null ) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null ) {
                    iReturn = -1;
                } else {
                    iReturn = y.ContactRequestsLast3Months.CompareTo(x.ContactRequestsLast3Months);
                }
            }
            return iReturn;
        }

        #endregion (ContactRequests Last 3 Months)

        #region ContactRequests Over 90 Days
        public static int SortByContactRequestsOver90DaysDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null ) {
                if (x == null ) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ContactRequestsOver90Days.CompareTo(x.ContactRequestsOver90Days);
                }
            }
            return iReturn;
        }
        #endregion (ContactRequestsOver90Days Over 90 Days)

        #region Total ContactRequests
        public static int SortByContactRequestsDescending(ListingViewStatsCardDTO x, ListingViewStatsCardDTO y) {
            int iReturn = 0;
            if (y == null) {
                if (x == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (x == null) {
                    iReturn = -1;
                } else {
                    iReturn = y.ContactRequests.CompareTo(x.ContactRequests);
                }
            }
            return iReturn;
        }

        #endregion (Total ContactRequests)

        #endregion (ContactRequests)

        #endregion (Sorting Options)

        #region Properties
        [Column("Title")]
        public string Title { get; set; }
        [Column("l_DateListed")]
        public DateTime l_DateListed { get; set; }

        [Column("l_IsActive")]
        public bool l_IsActive { get; set; }

        [Column("l_IsPending")]
        public bool l_IsPending { get; set; }
        
        [Column("l_lkpListingSetupStatusOid")]
        public Int64 l_lkpListingSetupStatusOid { get; set; }
        #endregion (Properties)

    }
}
