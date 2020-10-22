using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using CommonUtil;
using BizSearch;
using Model;

namespace ServiceHub {
    public class ViewListingsAction : IAction{
        public void Run(QueableMessage toMessage) {
            // This method will be triggered when a user "Views" a collection of listings.  When the Search Engine generates a collection of listings
            // they are stored in a Result Set on the server.  As each page of data is retrieved we will marke the listings in that set as having been viewed.
            // The "Data" property on the inbound message will be a List<Listing>. For each Listing we will increment the "View" count as well as mark the Entity2Listing map
            // which tracks whether the user has ever seen this listing before.

            // QueableMessage
            // MessageType = int that drives the task
            // TargetTable = Meta data to identify the target table (matches with the targetOid below)
            // TargetOid = Oid for the target record in the Target Table
            // Data object to have as a carrier for passing anything through to the run method

            #region Validation Checking
            // Check for Data
            if (toMessage.Data == null) {
                throw new ArgumentException("A message has been received to register a [View] for a series of listings, but the Data property of the Queueable Message is null.  It should contain a list of Listing Oids which have been viewed by the Seacrh Results");
            }

            if (toMessage.TargetOid == null || toMessage.TargetOid == 0) {
                throw new ArgumentException("A message has been received to register a [View] for a listing, but there is no Entity Oid in the TargetOid property of the Queueable Message so the system will not be able to register the view to any specific individual");
            }
            #endregion (Validation Checking)

            Int64 iEntityOid_User = toMessage.TargetOid;

            try {
                // Process the Listings that have been viewed.
                List<Listing> oList = FSTools.FromJSON<List<Listing>>(toMessage.Data.ToString());

                foreach (Listing oListing in oList) {
                    ListingStatCapture.UpdateListingStatViewCount(iEntityOid_User, oListing);
                }

            } catch (Exception ex) {

                throw;
            }
        }

        private void UpdateUsersViewCountOnEntity2ListingMap(Int64 tiEntityOid, Int64 tiListingOid) {
            Entity2ListingMap_Stat oMap = SQL.GetEntity2ListingMap_StatByEntityOidAndListingOid(tiEntityOid, tiListingOid, false);
            if (oMap == null) {
                oMap = new Entity2ListingMap_Stat() { EntityOid = tiEntityOid, ListingOid = tiListingOid, IsNotifyOnPriceChange_Email = true, IsNotifyOnPriceChange_Text = true, IsFavorite = false, IsVisited = false, IsSeen = true, IsContacted = false };
                oMap.Save();
            } else {
                if (oMap.IsSeen == null || !(bool)oMap.IsSeen) {
                    // We check to see if the IsSeen flag is already true - if it is, there is no reason
                    // We could write this method so that there is only one 
                    oMap.IsSeen = true;
                    oMap.Save();
                }
            }
            oMap.IsSeen = true;
        }

        public void UpdateWhse_ListStatViewCount(Int64 tiListingOid) {
            try {
                int iViewsLast3Months = 0, iViewsLastMonth = 0, iViewsLast7Days = 0, iViewsLast24Hrs = 0;
                DateTime oDate = DateTime.UtcNow;
                DateTime dt7 = oDate.AddDays(-7), dt24 = oDate.AddHours(-24), dt3M = oDate.AddMonths(-3), dt1M = oDate.AddMonths(-1);

                // Get the Whse_ListingStatRecord
                Whse_ListingStat oWhse = Whse_ListingStat.FirstOrDefault("WHERE ListingOid = @0", tiListingOid);
                if (oWhse == null) {

                    oWhse = Whse_ListingStat.CreateNewEmptyRecord(tiListingOid);
                    Listing oListing = SQL.GetListingByOid(tiListingOid, true);
                    oWhse.CompanyName = oListing.CompanyName;
                    oWhse.AdTitle = oListing.AdTitle;

                    Entity oEntity = SQL.GetEntityByOid(oListing.EntityOid, true);
                    oWhse.EntityOid = oEntity.Oid;
                    oWhse.EntityOid_Master = oEntity.EntityOid_Master;
                    oWhse.EntityOid_Region = (Int64)oEntity.EntityOid_Region;
                    oWhse.EntityOid_Office = (Int64)oEntity.EntityOid_Office;
                }

                // Add up the View statistics for the Whse record
                List<ListingStat> oStats = SQL.GetListingStatsByListingOidAndContext(tiListingOid, Constants.LISTINGSTAT_EVENT_VIEW);
                foreach (ListingStat oStat in oStats) {
                    if (oDate >= dt24) {
                        iViewsLast24Hrs++;
                    } else {
                        if (oDate >= dt7) {
                            iViewsLast7Days++;
                        } else {
                            if (oDate >= dt1M) {
                                iViewsLastMonth++;
                            } else {
                                if (oDate >= dt3M) {
                                    iViewsLast3Months++;
                                } else {

                                }
                            }
                        }
                    }
                }

                // Add the View statistics to the Whse record
                oWhse.Views = oStats.Count;
                oWhse.ViewsLast24Hrs = iViewsLast24Hrs;
                oWhse.ViewsLast7Days = (iViewsLast24Hrs + iViewsLast7Days);
                oWhse.ViewsLastMonth = (oWhse.ViewsLast7Days + iViewsLastMonth);
                oWhse.ViewsLast3Months = (oWhse.ViewsLastMonth + iViewsLast3Months);
                oWhse.Save();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                // Logging here is fine but this is a non-Critical background thread
                // which monitors "Clicks" and we do noyt want this to interrupt the 
                // server in any way.  Exceptions will be consumed here.

                // ******    DO NOT RE THROW THE EXCEPTION   *****//
            }
        }


    }
}
