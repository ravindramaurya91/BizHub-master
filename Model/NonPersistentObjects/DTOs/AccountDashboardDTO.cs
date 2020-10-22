using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class AccountDashboardDTO {
        
        #region Fields
        private List<SearchCriteria> _savedSearchCriterias = new List<SearchCriteria>();
        private List<Entity2ListingMap_Stat> _favoritedListings = new List<Entity2ListingMap_Stat>();
        private List<Listing> _savedListings = new List<Listing>();
        private List<Listing> _myListings = new List<Listing>();
        #endregion(Fields)

        #region Methods
        public void ParseListings(List<Listing> tlListings, Int64 tiUserOid) {
            if(tlListings.Count > 0) {
                foreach(Listing listing in tlListings) {
                    if(listing.EntityOid == tiUserOid) {
                        MyListings.Add(listing);
                    } else {
                        SavedListings.Add(listing);
                    }
                }
            }
        }

        public Int64 GetTotalSearchDetailNewListings()
        {
            Int64 oReturn = 0;
            foreach (SearchCriteria DTO in SavedSearchCriteria)
            {
                oReturn += DTO.NewListingsSinceLastSearchDate;
            }

            return oReturn;
        }

        #endregion (Methods)


        #region Properties
        public Int64 TotalSearchDetailNewListings
        {
            get => GetTotalSearchDetailNewListings();
        }
        public List<SearchCriteria> SavedSearchCriteria { get => _savedSearchCriterias; set => _savedSearchCriterias = value; }
        public List<Entity2ListingMap_Stat> FavoritedListings { get => _favoritedListings; set => _favoritedListings = value; }
        public List<Listing> SavedListings { get => _savedListings; set => _savedListings = value;  }
        public List<Listing> MyListings { get => _myListings; set => _myListings = value; }

        #endregion (Properties)
    }
}
