using CommonUtil;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub {
    public class PagFavoritedListingsController : BasePageController, ICmpListingController
    {
        #region Fields

        private List<ListingDTO> _listings = new List<ListingDTO>();
        private List<ListingDTO> _masterList = new List<ListingDTO>();

        #endregion(Fields)

        #region Methods

        public void GetMyFavoritedListings()
        {
            List<ListingDTO> oListings = SQL.GetMyFavoritedListings();
            Listings = oListings;
            _masterList = oListings;
        }

        public void NavigateToListingDetail(Int64 tiListingOid) {
            NavigateTo("/ListingDetail/" + tiListingOid);
        }

        public void ToggleListingFavorite(ListingDTO toListingDTO) {
            toListingDTO.ToggleIsFavorite();
        }

        #region Key Word Search Filter

        public void KeywordSearch(string sSearchWords)
        {
            List<ListingDTO> oHitList = new List<ListingDTO>();
            try
            {
                foreach (ListingDTO oItem in _masterList)
                {
                    if ((!String.IsNullOrEmpty(oItem.AdTitle) && oItem.AdTitle.Contains(sSearchWords)) ||
                        (!String.IsNullOrEmpty(oItem.AdTagLine) && oItem.AdTagLine.Contains(sSearchWords)) ||
                        (!String.IsNullOrEmpty(oItem.AdDescription) && oItem.AdDescription.Contains(sSearchWords)) ||
                        (!String.IsNullOrEmpty(oItem.AdBusinessHistory) && oItem.AdBusinessHistory.Contains(sSearchWords)) ||
                        (!String.IsNullOrEmpty(oItem.AdReasonForSelling) && oItem.AdReasonForSelling.Contains(sSearchWords)) ||
                        (!String.IsNullOrEmpty(oItem.AdFacilityDescription) && oItem.AdFacilityDescription.Contains(sSearchWords)))
                    {
                        oHitList.Add(oItem);
                    }
                }
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }

            Listings = oHitList;
        }

        public void ClearWordSearch()
        {
            Listings = _masterList;
        }

        #endregion (Key Word Search Filter)

        #region Sorting Options

        public void Sort(string tsSortCriteria)
        {
            switch (tsSortCriteria)
            {
                case "AdTitle":
                    Listings.Sort(ListingDTO.SortByAdTitle);
                    break;
                case "EBITDA":
                    Listings.Sort(ListingDTO.SortByEBITDA);
                    break;
                case "ListingPrice":
                    Listings.Sort(ListingDTO.SortByListingPrice);
                    break;
                case "CashFlow":
                    Listings.Sort(ListingDTO.SortByCashFlow);
                    break;

                case "IsSbaPreApproved":
                    Listings.Sort(ListingDTO.SortByIsSbaPreApproved);
                    break;
                case "IsSellerFinanace":
                    Listings.Sort(ListingDTO.SortByIsSellerFinanace);
                    break;
            }
        }
    

    #endregion (Sorting Options)
    #region Search Filter
    public async void OnKeywordInput(string tsSearchText) {
        Listings = (List<ListingDTO>)await SearchForKeyWords(tsSearchText);
    }

    private async Task<IEnumerable<ListingDTO>> SearchForKeyWords(string tsSearchText) {
        return await Task.FromResult(Listings.Where(x => x.AdTitle.ToLower().Contains(tsSearchText.ToLower()) ||
                                                         x.ListingPrice.ToString().ToLower().Contains(tsSearchText.ToLower()) ||
                                                         x.CashFlow.ToString().ToLower().Contains(tsSearchText.ToLower())).ToList());
    }
    #endregion (Search Filter)

        #endregion(Methods)

        #region Properties
        

        public List<ListingDTO> Listings
        {
            get { return _listings; }
            set { _listings = value; }
        }
        #endregion(Properties)
    }
}
