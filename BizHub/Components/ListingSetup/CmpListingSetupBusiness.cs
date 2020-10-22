using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base;
using BizHub.Components.Modals.HierarchicSelector;
using Blazored.Modal;
using Blazored.Modal.Services;
using CommonUtil;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BizHub.Components.ListingSetup {
    public partial class CmpListingSetupBusiness {

        #region Fields
        private List<DisplayTag> _displayTags = new List<DisplayTag>();
        private ListingDTO _listingDTO;
        private bool _isShowRealEstateDetails = true;
        private PagListingSetupController _controller = new PagListingSetupController();
        #endregion (Fields)

        #region Methods
        
        public List<DisplayTag> GenerateTagListFromLookups(List<Lookup> toList)
        {
            List<DisplayTag> rList = new List<DisplayTag>();
            foreach (Lookup oItem in toList)
            {
                rList.Add(AddValueToTag(oItem));
            }
            return rList;
        }

        public void RemoveCategory(DisplayTag toTag)
        {
            ListingDTO.lkpBusinessCategoryOids = ListingDTO.lkpBusinessCategoryOids.Replace(", " + toTag.TagId.ToString() + ",", ",").Replace(toTag.TagId.ToString() + ",", "").Replace(", " + toTag.TagId.ToString(), "");
            DisplayTags.Remove(toTag);
        }
        public List<DisplayTag> GenerateTagListFromLookupNodes(List<IHierarchy> toList)
        {
            List<DisplayTag> rList = new List<DisplayTag>();
            foreach (IHierarchy item in toList)
            {
                rList.Add(AddValueToTag(item));
            }

            return rList;
        }

        private DisplayTag AddValueToTag(IValue toObj)
        {
            return new DisplayTag() {TagId = toObj.Oid, Name = toObj.Value};
        }
        
        public void OpenBusinessCategoriesModal()
        {
            ShowBusinessCategoriesModal();
        }

        async Task ShowBusinessCategoriesModal() {
            SearchCriteriaDisplay oDisplay = new SearchCriteriaDisplay();
            if (!String.IsNullOrEmpty(ListingDTO.lkpBusinessCategoryOids))
            {
                oDisplay.AddItems(ListingDTO.lkpBusinessCategoryOids.Split(", ").Select(Int64.Parse).ToList());    
            }
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("ListManager", oDisplay);
            oParameters.Add("ModalHeader", "Select Business Categories");
            oParameters.Add("ModalSubHeader", "Select/deselect business categories to refine search");
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = false;
            oOptions.Class += " business-category-modal modal-forward";
            oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(CmpHierarchicSelector),"", oParameters, oOptions).Result;
            if (BCModalResult.Cancelled) {
                Console.WriteLine("Modal was cancelled");
            } else {
                Console.WriteLine(BCModalResult.Data);
                ListingDTO.lkpBusinessCategoryOids = ModelUtil.IModelToOidDelimitedString((List<IHierarchy>)BCModalResult.Data);
                DisplayTags = GenerateTagListFromLookupNodes((List<IHierarchy>) BCModalResult.Data);
                StateHasChanged();
            }
        }
        public void ChangeRealEstateIncluded(string tsIncludedInt) {
            int iValue = 1;
            switch (tsIncludedInt) {
                case "2":
                    iValue = 2;
                    break;
                case "3":
                    iValue = 3;
                    break;
                default:
                    break;
            }
            ListingDTO.RealEstateIncluded_Int = iValue;
        }

        public void GenerateTagListFromListingDTO()
        {
            List<Lookup> Lookups = new List<Lookup>();
            List<Int64> OidList = FSTools.ConvertDelimitedStringToList<Int64>(ListingDTO.lkpBusinessCategoryOids, ",");
            foreach (Int64 item in OidList)
            {
                Lookups.Add(LookupManager.Instance.GetLookupByOid(item));
            }
            DisplayTags = GenerateTagListFromLookups(Lookups);
        }
        
        protected override void OnInitialized() {
            Console.WriteLine(ListingDTO);
            if (ListingDTO.RealEstateIncluded_Int == null || ListingDTO.RealEstateIncluded_Int <= 0)
            {
                ListingDTO.RealEstateIncluded_Int = 2;
            }
            if (ListingDTO.FacilityOwned_Int == null || ListingDTO.RealEstateIncluded_Int <= 0)
            {
                ListingDTO.FacilityOwned_Int = 1;
            }
            if (ListingDTO.IsRealEstateInPrice == null)
            {
                ListingDTO.IsRealEstateInPrice = true;
            }
            if (!string.IsNullOrEmpty(ListingDTO.lkpBusinessCategoryOids))
            {
                GenerateTagListFromListingDTO();
                StateHasChanged();
            }
        }

        public void ChangeFacilityOwned(string tsFacilityOwnedInt) {
            int iValue = 1;
            switch (tsFacilityOwnedInt) {
                case "2":
                    iValue = 2;
                    break;
                case "3":
                    iValue = 3;
                    break;
                default:
                    break;
            }
            ListingDTO.FacilityOwned_Int = iValue;
        }

        public void ChangeIsRealEstateInPrice(string tsIsIncluded) {
            ListingDTO.IsRealEstateInPrice = tsIsIncluded == "true" ? true : false;
        }
        #endregion (Methods)

        #region properties

        public Int64 CountryOidValue { get; set; } = 1;

        [Parameter] public ListingDTO ListingDTO { get; set; }
        [Parameter] public PagListingSetupController Controller { get; set; }

        public bool IsShowRealEstateDetails { get => _isShowRealEstateDetails; set => _isShowRealEstateDetails = value; }

       
        public bool IsSubmitted { get => Controller.IsSubmitted; set => Controller.IsSubmitted = value; }

        public List<DisplayTag> DisplayTags { get => _displayTags; set => _displayTags = value; }
        #endregion

        #region PreDefinedHTML
        public readonly List<FSVisualItem> FACILITIES_RADIO_BUTTONS = new List<FSVisualItem> {
            new FSVisualItem {Label = "Leased", Value = "1", ElementName = "FacilityOwnedInt", CustomCSS="e-primary"},
            new FSVisualItem {Label = "Owned", Value = "2", ElementName = "FacilityOwnedInt", CustomCSS="e-primary"},
            new FSVisualItem {Label = "No office or public facility", Value = "3", ElementName = "FacilityOwnedInt", CustomCSS="e-primary"}
        };

        public readonly List<FSVisualItem> REAL_ESTATE_RADIO_BUTTONS = new List<FSVisualItem> {
            new FSVisualItem {Label = "No Real estate included in sale", Value = "1", ElementName = "RealEstateIncluded", CustomCSS="e-primary"},
            new FSVisualItem {Label = "Real estate may be included if the price is right", Value = "2", ElementName = "RealEstateIncluded", CustomCSS="e-primary"},
            new FSVisualItem {Label = "Real estate purchase required as a part of the business sale", Value = "3", ElementName = "RealEstateIncluded", CustomCSS="e-primary"}
        };

        public readonly List<FSVisualItem> REAL_ESTATE_INCLUDED_IN_PRICE_RADIO_BUTTONS = new List<FSVisualItem> {
            new FSVisualItem {Label = "Yes", Value = "true", ElementName = "RealEstateInPrice", CustomCSS="e-primary"},
            new FSVisualItem {Label = "No", Value = "false", ElementName = "RealEstateInPrice", CustomCSS="e-primary"}
        };

        
        #endregion (PreDefinedHTML)


    }
}
