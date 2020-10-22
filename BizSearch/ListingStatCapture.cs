using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Model;

namespace BizSearch {
    public class ListingStatCapture {

        #region Update Whse_Listing Stats
        public static void UpdateListingStatViewCount(Int64 tiEntityOid, Listing toListing) {
            UpdateListingStatViewCount(tiEntityOid, toListing.Oid);
        }

        public static void UpdateListingStatViewCount(Int64 tiEntityOid, SearchListing toSearchListing) {
            UpdateListingStatViewCount(tiEntityOid, toSearchListing.Oid);
        }

        public static void UpdateListingStatViewCount(Int64 tiEntityOid, Int64 tiListingOid) {
            DateTime oDate = DateTime.UtcNow;
            ListingStat oListingStat = new ListingStat() { Context = "VIEW", Date = oDate, EntityOid = tiEntityOid, ListingOid = tiListingOid };
            oListingStat.Save();
            UpdateWhse_ListStatViewCount(tiListingOid);
            UpdateUsersViewCountOnEntity2ListingMap_Stat(tiEntityOid, tiListingOid);
        }

        private static void UpdateUsersViewCountOnEntity2ListingMap_Stat(Int64 tiEntityOid, Int64 tiListingOid) {
            if ((tiEntityOid != null) && (tiEntityOid > 0)) {
                Entity2ListingMap_Stat oMap = SQL.GetEntity2ListingMap_StatByEntityOidAndListingOid(tiEntityOid, tiListingOid, false);
                if (oMap == null) {
                    oMap = new Entity2ListingMap_Stat() { EntityOid = tiEntityOid, ListingOid = tiListingOid, IsNotifyOnPriceChange_Email = true, IsNotifyOnPriceChange_Text = true, IsFavorite = false, IsVisited = false, IsContacted = false };
                    oMap.Save();
                } else {
                    if (oMap.IsVisited == null || !(bool)oMap.IsVisited) {
                        // We check to see if the IsSeen flag is already true - if it is, there is no reason
                        // We could write this method so that there is only one 
                        oMap.IsVisited = true;
                        oMap.Save();
                    }
                }
                oMap.IsVisited = true;
            }
        }
        public static void UpdateWhse_ListStatViewCount(Int64 tiListingOid) {
            try {
                int iViewsLast3Months = 0, iViewsLastMonth = 0, iViewsLast7Days = 0, iViewsLast24Hrs = 0;
                DateTime oDate = DateTime.UtcNow;
                DateTime dt7 = oDate.AddDays(-7), dt24 = oDate.AddHours(-24), dt3M = oDate.AddMonths(-3), dt1M = oDate.AddMonths(-1);

                // Get the Whse_ListingStatRecord
                Whse_ListingStat oWhse_ListingStat = Whse_ListingStat.FirstOrDefault("WHERE ListingOid = @0", tiListingOid);
                if (oWhse_ListingStat == null) {

                    oWhse_ListingStat = Whse_ListingStat.CreateNewEmptyRecord(tiListingOid);
                    Listing oListing = SQL.GetListingByOid(tiListingOid, true);
                    oWhse_ListingStat.CompanyName = oListing.CompanyName;
                    oWhse_ListingStat.AdTitle = oListing.AdTitle;

                    Entity oEntity = SQL.GetEntityByOid(oListing.EntityOid, true);
                    oWhse_ListingStat.EntityOid = oEntity.Oid;
                    oWhse_ListingStat.EntityOid_Master = oEntity.EntityOid_Master;
                    oWhse_ListingStat.EntityOid_Region = (Int64)oEntity.EntityOid_Region;
                    oWhse_ListingStat.EntityOid_Office = (Int64)oEntity.EntityOid_Office;
                }

                // Add up the View statistics for the Whse record
                List<ListingStat> oStats = SQL.GetListingStatsByListingOidAndContext(tiListingOid, Constants.LISTINGSTAT_EVENT_VIEW);
                foreach (ListingStat oStat in oStats) {
                    if (oStat.Date >= dt24) {
                        iViewsLast24Hrs++;
                    } else {
                        if (oStat.Date >= dt7) {
                            iViewsLast7Days++;
                        } else {
                            if (oStat.Date >= dt1M) {
                                iViewsLastMonth++;
                            } else {
                                if (oStat.Date >= dt3M) {
                                    iViewsLast3Months++;
                                } else {
                                    // Nothing to Do here - the Total Views will be picke dup below
                                }
                            }
                        }
                    }
                }

                // Add the View statistics to the Whse record
                oWhse_ListingStat.Views = oStats.Count;
                oWhse_ListingStat.ViewsLast24Hrs = iViewsLast24Hrs;
                oWhse_ListingStat.ViewsLast7Days = (iViewsLast24Hrs + iViewsLast7Days);
                oWhse_ListingStat.ViewsLastMonth = (oWhse_ListingStat.ViewsLast7Days + iViewsLastMonth);
                oWhse_ListingStat.ViewsLast3Months = (oWhse_ListingStat.ViewsLastMonth + iViewsLast3Months);
                oWhse_ListingStat.Save();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                // Logging here is fine but this is a non-Critical background thread
                // which monitors "Clicks" and we do noyt want this to interrupt the 
                // server in any way.  Exceptions will be consumed here.

                // ******    DO NOT RE THROW THE EXCEPTION   *****//
            }
        }

        #endregion (Update Whse_Listing Stats)
    }
}
