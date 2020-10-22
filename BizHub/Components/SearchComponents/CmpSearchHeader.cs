using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BizHub.Components.SearchComponents
{
    public partial class CmpSearchHeader
    {
        
        #region Fields
        private SearchCriteriaDisplay _searchCriteriaDisplay = new SearchCriteriaDisplay();

        private bool _editSearchName = false;
        private string _searchName = "";
        private PagListingsController _controller;

        #endregion(Fields)

        #region Constructor

        #endregion(Constructor)

        #region Methods

        public void OnSortByChanged(string tsValue) {
            // TOD This is the Sort Call for the Listings Page
            if (tsValue != null) {
                switch (tsValue) {
                    case "25":
                        Debug.WriteLine("Listing Price: High to Low");
                        break;
                    case "50":
                        Debug.WriteLine("Listing Price: Low to High");
                        break;
                    case "100":
                        Debug.WriteLine("Distance: Nearest First");
                        break;
                    case "200":
                        Debug.WriteLine("Date Listed: Newest First");
                        break;
                    case "400":
                        Debug.WriteLine("Date Listed: Oldest First");
                        break;
                }
            } else {
                System.Diagnostics.Debug.Write(tsValue);
            }
        }
    
        public void SaveSearch() {
            eSaveSearchRequested.InvokeAsync(true);
            ToggleEditSearchNameFlag();
        }
        public void RunSearch() {
            eSearchSelected.InvokeAsync(true);
        }
        public void CancelNameEdit() {
            _searchCriteriaDisplay.SearchCriteria.Name = SearchNameBeforeEdit;
            ToggleEditSearchNameFlag();
        }
        public void ToggleEditSearchNameFlag() {
            EditSearchNameFlag = !EditSearchNameFlag;
        }

        public void SaveSearchName()
        {
            //TODO: create call to save search name here
            ToggleEditSearchNameFlag();
        }

        #endregion(Methods)
        
        public PagListingsController Controller {get => _controller; set => _controller = value;}

        #region Properties
        public string CurrentSortBy { get; set; }
        [Parameter]
        public SearchCriteriaDisplay SearchCriteriaDisplay { get => _searchCriteriaDisplay; set => _searchCriteriaDisplay = value; }

        [Parameter]
        public EventCallback<bool> eSearchSelected { get; set; }
        // An Event in Blazor
        [Parameter]
        public EventCallback<bool> eSaveSearchRequested { get; set; }
        // TODO Implement  this call back to save a search
        
        

        [Parameter]
        public bool IsRunSearchButtonDisabled { get; set; }

        public bool EditSearchNameFlag {
            get { return _editSearchName; }
            set {
                _editSearchName = value;
                SearchNameBeforeEdit = _searchCriteriaDisplay.SearchCriteria.Name;
            }
        }
        
        public string SearchNameBeforeEdit { get => _searchName; set => _searchName = value; }

        #endregion(Properties)
        
        #region PreDefinedHTML
        public readonly List<FSVisualItem> SORT_BY_OPTIONS = new List<FSVisualItem> {
            new FSVisualItem {Label = "Listing Price: High to Low", Value = "25"},
            new FSVisualItem {Label = "Listing Price: Low to High", Value = "50"},
            new FSVisualItem {Label = "Date Listed: Newest First", Value = "200"},
            new FSVisualItem {Label = "Date Listed: Oldest First", Value = "400"},

        };
        #endregion (PreDefinedHTML)
    }
}