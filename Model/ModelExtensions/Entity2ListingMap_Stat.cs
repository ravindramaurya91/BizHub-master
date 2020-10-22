using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public partial class Entity2ListingMap_Stat {

        public override void Save() {
            base.Save();
            SessionMgr.Instance.UpdateFavoritedListings();
        }

        public static Entity2ListingMap_Stat CreateNewMapForListing(Listing toListing) {
            Entity2ListingMap_Stat oMap = Entity2ListingMap_Stat.GenerateNewWithDefaultValues();
            oMap.ListingOid = toListing.Oid;
            oMap.EntityOid = SessionMgr.Instance.User.EntityOid;

            oMap.Save();
            return oMap;
        }

        public static Entity2ListingMap_Stat GenerateNewWithDefaultValues() {
            Entity2ListingMap_Stat oMap = new Entity2ListingMap_Stat();
            oMap.IsContacted = false;
            oMap.IsExpanded = false;
            oMap.IsExpanded = false;
            oMap.IsFavorite = false;
            oMap.IsNotifyOnPriceChange_Email = false;
            oMap.IsNotifyOnPriceChange_Text = false;
            oMap.IsSeen = false;
            oMap.IsVisited = false;
            return oMap;
        }

    }
}
