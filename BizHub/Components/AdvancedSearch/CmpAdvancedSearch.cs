using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using BizHub.Components.Modals.HierarchicSelector;
using Blazored.Modal;
using Blazored.Modal.Services;
using CommonUtil;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Model;

namespace BizHub.Components.AdvancedSearch {
	public partial class CmpAdvancedSearch {

		#region Fields
		private bool _editSearchName = false;
		private string _searchName = "";
		private SearchCriteriaDisplay _searchCriteriaDisplay = new SearchCriteriaDisplay();
		private List<LookupNode> _businessCategoryNodes = new List<LookupNode>();
		private System.Timers.Timer _Timer;
		#endregion (Fields)

		#region Methods

		protected override void OnInitialized() {

			_Timer = new System.Timers.Timer(1000);
			_Timer.Elapsed += OnUserZipCodeUpdate;
			_Timer.AutoReset = false;
			if (SearchCriteriaDisplay.SearchRadius == null) {
				SearchCriteriaDisplay.SearchRadius = Convert.ToInt32(Constants.ZIPCODE_SEARCH_DISTANCES[0].Value);
			}
			//if (!string.IsNullOrEmpty(SearchCriteriaDisplay.lkpBusinessCategoryOids)) {
			//	BusinessCategories = FSTools.ConvertDelimitedStringToList<Int64>(SearchCriteriaDisplay.lkpBusinessCategoryOids, ",");
			//	StateHasChanged();
			//}
		}

		private void OnZipCodeKeyUp(KeyboardEventArgs e) {
			_Timer.Stop();
			_Timer.Start();
		}

		private void OnUserZipCodeUpdate(Object source, ElapsedEventArgs e) {
			if(source != null) {

            }
		}

		public void OpenBusinessCategoriesModal() {
			ShowBusinessCategoriesModal();
		}

		async Task ShowBusinessCategoriesModal() {
			SearchCriteriaDisplay oDisplay = new SearchCriteriaDisplay();
			if (!String.IsNullOrEmpty(SearchCriteriaDisplay.lkpBusinessCategoryOids)) {
				oDisplay.AddItems(BusinessCategories);
			}

			ModalParameters oParameters = new ModalParameters();
			oParameters.Add("ListManager", oDisplay);
			oParameters.Add("ModalHeader", "Select Business Categories");
			oParameters.Add("ModalSubHeader", "Select/deselect business categories to refine search");
			oParameters.Add("IsShowParentCheckbox", IsShowParentCheckBoxInBusinessCategoryModal);
			FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
			oOptions.HideCloseButton = false;
			oOptions.Class += " business-category-modal modal-forward";
			oOptions.HideHeader = true;
			ModalResult BCModalResult = await Controller.ShowModal(typeof(CmpHierarchicSelector), "", oParameters, oOptions).Result;
			if (BCModalResult.Cancelled) {
				Console.WriteLine("Modal was cancelled");
			} else {
				SearchCriteriaDisplay.lkpBusinessCategoryOids = ModelUtil.IModelToOidDelimitedString((List<IHierarchy>)BCModalResult.Data);
				StateHasChanged();
			}
		}

		public void ToggleEditSearchNameFlag() {
			EditSearchNameFlag = !EditSearchNameFlag;
		}

		public void SaveSearch() {
			eSaveSearchRequested.InvokeAsync(true);
			ToggleEditSearchNameFlag();
		}

		public void RunSearch() {
			eSearchSelected.InvokeAsync(true);
		}

		public void CheckForZeroValue(decimal? tiValue, string tsPropertyName) {
			if (tiValue != null && tiValue <= 0) {
				typeof(SearchCriteriaDisplay).GetProperty(tsPropertyName).SetValue(SearchCriteriaDisplay, null);
			}
		}

		public void CheckForZeroValue(string tsValue, string tsPropertyName) {
			if (tsValue != null && (string.Equals("", tsValue) || string.Equals("0", tsValue))) {
				typeof(SearchCriteriaDisplay).GetProperty(tsPropertyName).SetValue(SearchCriteriaDisplay, null);
			}
        }

		public void CheckForZeroValue(int? tiValue, string tsPropertyName) {
			if (tiValue != null && tiValue <= 0) {
				typeof(SearchCriteriaDisplay).GetProperty(tsPropertyName).SetValue(SearchCriteriaDisplay, null);
			}
		}

		public void OnSortByChanged(string tsValue) {
			eSortBySelected.InvokeAsync(tsValue);
		}

		public void InitiateNewSearch() {
			eNewSearchSelected.InvokeAsync(true);
		}

		public void OnSearchRadiusChanged(string tsSearchRadius) {
			Controller.OnSearchRadiusChanged(tsSearchRadius);
		}


		public List<LookupNode> GetBusinessCategoryNodeList() {
			if (_businessCategoryNodes == null || _businessCategoryNodes.Count == 0) {
				_businessCategoryNodes = LookupManager.Instance.GetLookupNodesByLookupName("BusinessCategory");
			}
			return _businessCategoryNodes;
		}

		public string FormatAsCurrency(decimal? tdValue) {
			if(tdValue != null && tdValue > 0) {
				return String.Format("{0:n0}", Math.Round((decimal)tdValue, 2));
			} else {
				return "";
            }
		}

		public decimal? AssignDecimal(string tsValue) {
            if (!string.IsNullOrEmpty(tsValue)) {
				return Decimal.Parse(tsValue, NumberStyles.Currency);
			} else {
				return null;
            }
		}

		public int? AssignInt(string tsValue) {
			if (!string.IsNullOrEmpty(tsValue)) {
				return int.Parse(tsValue, NumberStyles.Currency);
			} else {
				return null;
			}
		}

		public string FormatAsCommaDelimited(int? tiValue) {
			if (tiValue != null && tiValue > 0) {
				return String.Format("{0:n}", tiValue);
			} else {
				return "";
			}
		}

		#endregion (Methods)

		#region Properties
		#region Parameters
		[Parameter] public AdvancedSearchController Controller { get; set; }
		[Parameter] public bool IsZipCodeValid { get; set; }
		[Parameter] public bool IsRunSearchButtonDisabled { get; set; }
		[Parameter] public bool IsShowFooterButtons { get; set; } = true;
		[Parameter] public bool IsShowSortBy { get; set; } = true;
		[Parameter] public bool IsShowRecipientTitle { get; set; } = false;
		[Parameter] public bool IsAlignAttributes { get; set; } = false;
		[Parameter] public bool IsShowParentCheckBoxInBusinessCategoryModal { get; set; } = true;
		[Parameter] public int? TotalListingsCount { get; set; }
		[Parameter] public EventCallback<bool> eNewSearchSelected { get; set; }
		[Parameter] public EventCallback<bool> eSearchSelected { get; set; }
		[Parameter] public EventCallback<bool> eSaveSearchRequested { get; set; }
		[Parameter] public EventCallback<string> eSortBySelected { get; set; }
		#endregion (Parameters)
		public SearchCriteriaDisplay SearchCriteriaDisplay { get => Controller.SearchCriteriaDisplay; }
		public List<Int64> BusinessCategories {
			get => SearchCriteriaDisplay.LkpBusinessCategoryOids_Int64List;
		}
		public bool EditSearchNameFlag {
			get { return _editSearchName; }
			set {
				_editSearchName = value;
				SearchNameBeforeEdit = _searchCriteriaDisplay.SearchCriteria.Name;
			}
		}
		public string CurrentSortBy { get; set; }
		List<FSVisualItem> ZipCodes = Constants.ZIPCODE_SEARCH_DISTANCES;
		public string SearchNameBeforeEdit { get => _searchName; set => _searchName = value; }

        #region Display Extension Properties
        public string ListingPrice_From { 
            get { return FormatAsCurrency(SearchCriteriaDisplay.ListingPrice_From); }
            set { SearchCriteriaDisplay.ListingPrice_From = AssignDecimal(value); }
        }

		public string ListingPrice_To {
			get { return FormatAsCurrency(SearchCriteriaDisplay.ListingPrice_To); }
			set { SearchCriteriaDisplay.ListingPrice_To = AssignDecimal(value); }
		}

        public string GrossRevenue_From {
			get { return FormatAsCurrency(SearchCriteriaDisplay.GrossRevenue_From); }
			set { SearchCriteriaDisplay.GrossRevenue_From = AssignDecimal(value); }
		}

        public string GrossRevenue_To {
			get { return FormatAsCurrency(SearchCriteriaDisplay.GrossRevenue_To); }
			set { SearchCriteriaDisplay.GrossRevenue_To = AssignDecimal(value); }
		}

        public string CashFlow_From {
			get { return FormatAsCurrency(SearchCriteriaDisplay.CashFlow_From); }
			set { SearchCriteriaDisplay.CashFlow_From = AssignDecimal(value); }
		}

        public string CashFlow_To {
			get { return FormatAsCurrency(SearchCriteriaDisplay.CashFlow_To); }
			set { SearchCriteriaDisplay.CashFlow_To = AssignDecimal(value); }
		}

        public string EBITDA_From {
			get { return FormatAsCurrency(SearchCriteriaDisplay.EBITDA_From); }
			set { SearchCriteriaDisplay.EBITDA_From = AssignDecimal(value); }
		}

        public string EBITDA_To {
			get { return FormatAsCurrency(SearchCriteriaDisplay.EBITDA_To); }
			set { SearchCriteriaDisplay.EBITDA_To = AssignDecimal(value); }
		}

        public string MinimumDownPayment_From {
			get { return FormatAsCurrency(SearchCriteriaDisplay.MinimumDownPayment_From); }
			set { SearchCriteriaDisplay.MinimumDownPayment_From = AssignDecimal(value); }
		}


		public string MinimumDownPayment_To {
			get { return FormatAsCurrency(SearchCriteriaDisplay.MinimumDownPayment_To); }
			set { SearchCriteriaDisplay.MinimumDownPayment_To = AssignDecimal(value); }
		}

        public string TotalSqFt_From {
			get { return FormatAsCommaDelimited(SearchCriteriaDisplay.TotalSqFt_From); }
			set { SearchCriteriaDisplay.TotalSqFt_From = AssignInt(value); }
		}

        public string TotalSqFt_To {
			get { return FormatAsCommaDelimited(SearchCriteriaDisplay.TotalSqFt_To); }
			set { SearchCriteriaDisplay.TotalSqFt_To = AssignInt(value); }
		}


		public string EmployeeCount_From {
			get { return FormatAsCommaDelimited(SearchCriteriaDisplay.EmployeeCount_From); }
			set { SearchCriteriaDisplay.EmployeeCount_From = AssignInt(value); }
		}

		public string EmployeeCount_To {
			get { return FormatAsCommaDelimited(SearchCriteriaDisplay.EmployeeCount_To); }
			set { SearchCriteriaDisplay.EmployeeCount_To = AssignInt(value); }
		}

		#endregion (Display Extension Properties)

		#endregion (Properties)

		#region PreDefinedHTML
		public readonly List<FSVisualItem> SORT_BY_OPTIONS = new List<FSVisualItem> {
			new FSVisualItem {Label = "Listing Price: High to Low", Value = "1"},
			new FSVisualItem {Label = "Listing Price: Low to High", Value = "2"},
			new FSVisualItem {Label = "Distance: Nearest First", Value = "3"},
			new FSVisualItem {Label = "Date Listed: Newest First", Value = "4"},
			new FSVisualItem {Label = "Date Listed: Oldest First", Value = "5"},

		};
		#endregion (PreDefinedHTML)
	}
}
