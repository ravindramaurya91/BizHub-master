using Base;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class DisplayTag : IDeleteMe {

        #region Fields
        private Int64 _tagId = -1;
        private string _position = "A";
        private string _sortValue = "";
        #endregion (Fields)

        #region Constructor
        public DisplayTag() {}
        public DisplayTag(Int64 tiId, string tsPropertyName, string tsName) {
            TagId = tiId;
            PropertyName = tsPropertyName;
            Name = tsName;
            if (Name.Contains(">=")) {
                Position = "B";
            }
            if (Name.Contains("<=")) {
                Position = "C";
            }
        }
        #endregion (Constructor)

        #region Methods

        #region Events
        private void On_SortValueChanged() {
            _sortValue = _tagId.ToString().PadLeft(2, '0') + "-" + Position;
        }
        #endregion (Events)

        public static DisplayTag GetDisplayTag(string tsPropertyName) {
            return SearchCriteriaTagMap.GetDisplayTag(tsPropertyName);
        }
        #endregion (Methods)

        #region Sort
        public static int SortBySortValue(DisplayTag x, DisplayTag y) {
            int iReturn = 0;
            if (x == null || x.SortValue == null) {
                if (y == null || y.SortValue == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (y == null || y.SortValue == null) {
                    iReturn = -1;
                } else {
                    iReturn = x.SortValue.CompareTo(y.SortValue);
                }
            }
            return iReturn;
        }
        #endregion (Sort)
       
        #region Properties
        public Int64 TagId { get { return _tagId; } set { _tagId = value; On_SortValueChanged(); } }
        public string Position { get { return _position; } set { _position = value; On_SortValueChanged(); } }
        public string SortValue { get { return _sortValue; } }
        public string SecondaryId { get; set; } = "";
        public string TableName { get; set; } = "";
        public string PropertyName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
        public bool DeleteMe { get; set; } = false;
        public string DisplayName {
            get {
                string sReturn = "";
                if ((!string.IsNullOrEmpty(Name)) && (!string.IsNullOrEmpty(Value))) {
                    sReturn = Name + " " + Value;
                } else if ((!string.IsNullOrEmpty(Name))) {
                    sReturn = Name;
                } else if ((!string.IsNullOrEmpty(Value))) {
                    sReturn = Value;
                }
                return sReturn;
            }
        }

        #endregion (Properties)

    }

    // *********************************************************
    // ******        Class SearchCriteriaTagMap            *****
    // *********************************************************
    public class SearchCriteriaTagMap {
        public static DisplayTag GetDisplayTag(string tsPropertyName) {
            DisplayTag oReturn = null;
            switch (tsPropertyName) {
                case "lkpCountryOid":  oReturn = new DisplayTag(1, tsPropertyName, ""); break;
                case "lkpStateOid":  oReturn = new DisplayTag(2, tsPropertyName, ""); break;
                case "ZipCode":  oReturn = new DisplayTag(3, tsPropertyName, "Zip:"); break;
                case "SearchRadius": oReturn = new DisplayTag(3, tsPropertyName, "Zip:"); break;
                case "ListingPrice_From":  oReturn = new DisplayTag(4, tsPropertyName, "Price >="); break;
                case "ListingPrice_To":  oReturn = new DisplayTag(5, tsPropertyName, "Price <="); break;
                case "GrossRevenue_From":  oReturn = new DisplayTag(6,  tsPropertyName, "Revenue >="); break;
                case "GrossRevenue_To":  oReturn = new DisplayTag(7, tsPropertyName, "Revenue <="); break;
                case "EBITDA_From":  oReturn = new DisplayTag(8, tsPropertyName, "EBITDA >="); break;
                case "EBITDA_To":  oReturn = new DisplayTag(9, tsPropertyName, "EBITDA <="); break;
                case "CashFlow_From":  oReturn = new DisplayTag(10, tsPropertyName, "Cash >="); break;
                case "CashFlow_To":  oReturn = new DisplayTag(11, tsPropertyName, "Cash <="); break;
                case "MinimumDownPayment_From":  oReturn = new DisplayTag(12, tsPropertyName, "Down >="); break;
                case "MinimumDownPayment_To":  oReturn = new DisplayTag(13, tsPropertyName, "Down <="); break;
                case "TotalSqFt_From":  oReturn = new DisplayTag(14, tsPropertyName, "Sq Ft >="); break;
                case "TotalSqFt_To":  oReturn = new DisplayTag(15, tsPropertyName, "Sq Ft <="); break;
                case "EmployeeCount_From":  oReturn = new DisplayTag(16, tsPropertyName, "EEs >="); break;
                case "EmployeeCount_To":  oReturn = new DisplayTag(17, tsPropertyName, "EEs <="); break;
                case "IsAbsenteeOwner":  oReturn = new DisplayTag(18, tsPropertyName, "Absentee Owner"); break;
                case "IsHomeBased":  oReturn = new DisplayTag(19, tsPropertyName, "Home Based"); break;
                case "IsRelocatable":  oReturn = new DisplayTag(20, tsPropertyName, "Relocatable"); break;
                case "IsFranchise":  oReturn = new DisplayTag(21, tsPropertyName, "Franchise"); break;
                case "IsSellerFinanace":  oReturn = new DisplayTag(22, tsPropertyName, "Seller Finance"); break;
                case "IsSbaPreApproved":  oReturn = new DisplayTag(23, tsPropertyName, "Sba Pre-Approved"); break;
                case "IsRealEstateAvailable":  oReturn = new DisplayTag(24, tsPropertyName, "Real Estate Available"); break;
                case "Street":  oReturn = new DisplayTag(25, tsPropertyName, "Street:"); break;
                case "lkpCountyOids":  oReturn = new DisplayTag(26, tsPropertyName, "County:"); break;
                case "lkpCityOids":  oReturn = new DisplayTag(27, tsPropertyName, "City:"); break;
                case "lkpBusinessCategoryOids":  oReturn = new DisplayTag(28, tsPropertyName, "BC:"); break;
                case "Keywords":  oReturn = new DisplayTag(29, tsPropertyName, "KW:"); break;
                default:
                    break;
            }
            return oReturn;
        }
    }
}
