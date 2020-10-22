using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Base;
using CommonUtil;

namespace Model {
    public class SearchCriteriaDisplay : IHierarchyListManager {

        #region Events
        public delegate void MyDelegate(string s);
        public event EventHandler OnSearchCriteriaLoaded;
        public event EventHandler<SearchCriteriaChangedEventArgs> OnIsEmailNotificationChanged;
        public event EventHandler<SearchCriteriaChangedEventArgs> OnSearchCriteriaPropertyChanged;
        public event EventHandler<SearchCriteriaChangedEventArgs> OnTagListChanged;
        #endregion (Events)

        #region Fields
        private SearchCriteria _searchCriteria;
        private List<DisplayTag> _searchTags = new List<DisplayTag>();
        private List<Int64> _lkpBusinessCategoryOids_Int64List = new List<Int64>();
        private string _resultAmount = "";
        #endregion(Fields)

        #region Constructor
        public SearchCriteriaDisplay() {
            SearchCriteria = new SearchCriteria{ SearchRadius = 25 };
            SearchTags = GenerateTagListFromSearchCriteriaRecord(SearchCriteria);
        }

        public SearchCriteriaDisplay(SearchCriteria toSearchCriteria) {
            SearchCriteria = toSearchCriteria;
            if(SearchCriteria.SearchRadius == null) {
                SearchCriteria.SearchRadius = 25;
            }
            SearchTags = GenerateTagListFromSearchCriteriaRecord(SearchCriteria);
        }

        #endregion(Constructor)

        #region Methods

        #region Events
        public void On_SearchCriteriaLoaded() {
            // This method is triggered when someone assigns a new SearchCriteria object to the SearchCriteria Property
            // A new Criteria means we should clear the current list of tags andcreate a new list
            if(_searchTags != null) {
                _searchTags = GenerateTagListFromSearchCriteriaRecord(_searchCriteria);
            }
            // Trigger the outside event for any subscribers
            OnSearchCriteriaLoaded?.Invoke(this, null);
        }

        public void On_IsEmailChanged() {
            OnIsEmailNotificationChanged?.Invoke(this, null);
        }

        public void On_SearchCriteriaPropertyChanged(string tsPropertyName) {
            // This is triggered each time a property is changed which affects the search criteria 
            RefreshTag(tsPropertyName);
            if (tsPropertyName.Equals("lkpBusinessCategoryOids")) {
                _lkpBusinessCategoryOids_Int64List = FSTools.ConvertDelimitedStringToList<Int64>(lkpBusinessCategoryOids, ",");
            }
            // We will pass the nameo of the property which changed in the event
            SearchCriteriaChangedEventArgs oArgs = new SearchCriteriaChangedEventArgs(tsPropertyName, _searchCriteria[tsPropertyName]?.ToString());
            OnSearchCriteriaPropertyChanged?.Invoke(this, oArgs);
            SearchTags.Sort(DisplayTag.SortBySortValue);
            OnTagListChanged?.Invoke(this, null);
        }

        #endregion (Events)

        #region Tag Management

        #region Refresh or Create Tag one Property at a Time on Property Value Change

        private void RefreshTag(string tsPropertyName) {
            var value = _searchCriteria[tsPropertyName];
            string sValue = (value != null) ? value.ToString() : "";
            DisplayTag oTagTemplate = DisplayTag.GetDisplayTag(tsPropertyName);
            if(oTagTemplate != null) {
                DisplayTag oExistingTag = GetTagById(oTagTemplate.TagId);
                bool bTagAlreadyExists = (oExistingTag != null);

                if (!string.IsNullOrEmpty(sValue)) {
                    if (!IsListBasedProperty(tsPropertyName)) {
                        // Standard Name/Value Display Tags
                        if (!sValue.Equals("False")) {
                            DisplayTag oNewTag = null;

                            #region Create or Edit Tag
                            switch (tsPropertyName) {
                                case "lkpCountryOid":
                                    oNewTag = GenerateTag(tsPropertyName, GetLookupValue(tsPropertyName)); break;
                                case "lkpStateOid": oNewTag = GenerateTag(tsPropertyName, GetLookupValue(tsPropertyName)); break;
                                case "Street": oNewTag = GenerateTag(tsPropertyName); break;
                                // decimal
                                case "ListingPrice_To": oNewTag = GenerateTag(tsPropertyName); break;
                                case "ListingPrice_From": oNewTag = GenerateTag(tsPropertyName); break;
                                case "GrossRevenue_From": oNewTag = GenerateTag(tsPropertyName); break;
                                case "GrossRevenue_To": oNewTag = GenerateTag(tsPropertyName); break;
                                case "EBITDA_From": oNewTag = GenerateTag(tsPropertyName); break;
                                case "EBITDA_To": oNewTag = GenerateTag(tsPropertyName); break;
                                case "CashFlow_From": oNewTag = GenerateTag(tsPropertyName); break;
                                case "CashFlow_To": oNewTag = GenerateTag(tsPropertyName); break;
                                case "MinimumDownPayment_From": oNewTag = GenerateTag(tsPropertyName); break;
                                case "MinimumDownPayment_To": oNewTag = GenerateTag(tsPropertyName); break;
                                // ints
                                case "TotalSqFt_From": oNewTag = GenerateTag(tsPropertyName); break;
                                case "TotalSqFt_To": oNewTag = GenerateTag(tsPropertyName); break;
                                case "EmployeeCount_From": oNewTag = GenerateTag(tsPropertyName); break;
                                case "EmployeeCount_To": oNewTag = GenerateTag(tsPropertyName); break;
                                // bools
                                case "IsAbsenteeOwner": oNewTag = GenerateTag(tsPropertyName); break;
                                case "IsHomeBased": oNewTag = GenerateTag(tsPropertyName); break;
                                case "IsRelocatable": oNewTag = GenerateTag(tsPropertyName); break;
                                case "IsFranchise": oNewTag = GenerateTag(tsPropertyName); break;
                                case "IsSellerFinanace": oNewTag = GenerateTag(tsPropertyName); break;
                                case "IsSbaPreApproved": oNewTag = GenerateTag(tsPropertyName); break;
                                case "IsRealEstateAvailable": oNewTag = GenerateTag(tsPropertyName); break;

                                // Paired Items
                                // ZipCode & SearchRaduius
                                case "SearchRadius":
                                case "ZipCode":
                                    //oNewTag = GenerateTag("Zip"); break;
                                    oNewTag = GenerateTag(tsPropertyName); break;
                                default:
                                    // Nothing to do - ignore these Properties as far as Tags go
                                    // ZipCodes (the user never sets these. The user sets 1 Zip code & a radius - we calculate the collection)
                                    // IsTextNotification
                                    // IsEmailNotification
                                    // NewListingsSinceLastSearchDate
                                    // LastSearchedDate
                                    // IsActive
                                    break;
                            }

                            #endregion (Create or Edit Tag)

                            if (!bTagAlreadyExists) {
                                AddSearchTagToList(oNewTag);
                            } else {
                                oExistingTag.Value = oNewTag.Value;
                            }

                        } else {
                            // A value of false indicates a checkbox has been unselected. Remove associated tag
                            if (bTagAlreadyExists) {
                                RemoveSearchTagFromList(oExistingTag);
                            }
                        }
                    } else {
                        // Special Lust Based Tags
                        //// Lists of Values
                        switch (tsPropertyName) {
                            case "lkpCountyOids":
                            case "lkpCityOids":
                            case "lkpBusinessCategoryOids":
                                ProcessSearchCriteriaLookupList(tsPropertyName);
                                break;
                            case "Keywords":
                                ProcessSearchCriteriaWordList(tsPropertyName);
                                break;
                        }

                    }
                } else {
                    if (bTagAlreadyExists) {
                        RemoveSearchTagFromList(oExistingTag);
                    }
                }
            }
        }

        private bool IsListBasedProperty(string tsPropertyName) {
            List<string> s = new List<string> { ",lkpCountyOids", ",lkpCityOids", ",lkpBusinessCategoryOids,", ",Keywords," };
            return s.Contains("," + tsPropertyName + ",");
        }

        #endregion (Refresh or Create Tag one Property at a Time on Property Value Change)

        #region First Time Generation of Tags from new SearchCriteria Record

        public List<DisplayTag> GenerateTagListFromSearchCriteriaRecord(SearchCriteria toItem) {
            // A new Search Criteria record has been selected - Generate a new Search Tag List
            List<DisplayTag> oReturn = new List<DisplayTag>();
            //Decimals 
            EvaluateTag("ListingPrice_From", oReturn);
            EvaluateTag("ListingPrice_To", oReturn);
            EvaluateTag("CashFlow_From", oReturn);
            EvaluateTag("CashFlow_To", oReturn);
            EvaluateTag("GrossRevenue_From", oReturn);
            EvaluateTag("GrossRevenue_To", oReturn);
            EvaluateTag("EBITDA_From", oReturn);
            EvaluateTag("EBITDA_To", oReturn);
            EvaluateTag("MinimumDownPayment_From", oReturn);
            EvaluateTag("MinimumDownPayment_To", oReturn);
            EvaluateTag("EmployeeCount_From", oReturn);
            EvaluateTag("EmployeeCount_To", oReturn);
            // booleans
            EvaluateTag("IsAbsenteeOwner", oReturn);
            EvaluateTag("IsHomeBased", oReturn);
            EvaluateTag("IsRelocatable", oReturn);
            EvaluateTag("IsFranchise", oReturn);
            EvaluateTag("IsSellerFinanace", oReturn);
            EvaluateTag("IsSbaPreApproved", oReturn);
            EvaluateTag("ZipCode", oReturn);
            EvaluateTag("lkpCountyOids", oReturn);
            EvaluateTag("lkpCityOids", oReturn);
            EvaluateTag("lkpBusinessCategoryOids", oReturn);
            EvaluateTag("Keywords", oReturn);

            return oReturn;
        }

        private void EvaluateTag(string tsPropertyName, List<DisplayTag> toList) {
            DisplayTag oTag;
            List<string> sKeys;
            var value = _searchCriteria[tsPropertyName];
            string sValue = (value != null) ? value.ToString() : "";
            if ((!string.IsNullOrEmpty(sValue)) && (!sValue.Equals("0")) && (!sValue.Equals("False"))) {
                switch (tsPropertyName) {
                    case "lkpCountyOids":
                    case "lkpCityOids":
                    case "lkpBusinessCategoryOids":
                        Lookup oLookup;
                        sKeys = FSTools.ConvertDelimitedStringToList<string>(sValue, ',');
                        foreach (string sKey in sKeys) {
                            oLookup = LookupManager.Instance.GetLookupByOid(Convert.ToInt64(sKey));
                            if (oLookup != null) {
                                oTag = GenerateTag(tsPropertyName, oLookup.Value);
                                //oTag.Name = "";
                                oTag.SecondaryId = sKey;
                                toList.Add(oTag);
                            }
                        }
                        break;
                    case "Keywords":
                        sKeys = FSTools.ConvertDelimitedStringToList<string>(sValue, ',');
                        foreach (string sKey in sKeys) {
                            oTag = GenerateTag(tsPropertyName, sKey);
                            oTag.SecondaryId = sKey;
                            toList.Add(oTag);
                        }
                        break;
                    default:
                        toList.Add(GenerateTag(tsPropertyName, sValue));
                        break;
                }
            }
        }

        public DisplayTag GenerateTag(string tsPropertyName) {
            string sValue = _searchCriteria[tsPropertyName].ToString();   // Get the value from the property
            return GenerateTag(tsPropertyName, sValue);
        }
        public DisplayTag GenerateTag(string tsPropertyName, string tsValue) {
            DisplayTag oDisplayTag = DisplayTag.GetDisplayTag(tsPropertyName);
            CompleteTag(oDisplayTag, tsValue);
            return oDisplayTag;
        }
        private string GetZipCodeTagValue() {
            string sReturn;
            if (string.IsNullOrEmpty(_searchCriteria.ZipCode)) {
                sReturn = "?";
            } else {
                sReturn = _searchCriteria.ZipCode;
            }

            if (_searchCriteria.SearchRadius == null) {
                sReturn += " + ? miles";
            } else {
                sReturn += $" +{_searchCriteria.SearchRadius} miles";
            }
            return sReturn;
        }
        private void CompleteTag(DisplayTag toTag, string tsValue) {
            // Special Handling Tags
            switch (toTag.PropertyName) {
                case "lkpCountryOid":
                case "lkpStateOid":
                    tsValue = GetLookupValue(toTag.PropertyName);
                    ; break;

                case "SearchRadius":
                case "ZipCode":
                    tsValue = GetZipCodeTagValue();
                    break;

                case "IsAbsenteeOwner": tsValue = ""; break;
                case "IsHomeBased": tsValue = ""; break;
                case "IsRelocatable": tsValue = ""; break;
                case "IsFranchise": tsValue = ""; break;
                case "IsSellerFinanace": tsValue = ""; break;
                case "IsSbaPreApproved": tsValue = ""; break;
                case "IsRealEstateAvailable": tsValue = ""; break;

                default:
                    break;
            }
            // Fill in the rest of the Display Tag
            toTag.TableName = "SearchCriteria";
            toTag.Value = FormatString(toTag.PropertyName, tsValue);
            toTag.SecondaryId = toTag.SecondaryId;
        }
        private string FormatString(string tsPropertyName, string tsValue) {
            if (!string.IsNullOrEmpty(tsValue)) {
                switch (tsPropertyName) {
                    // decimal conversion
                    case "ListingPrice_To":
                    case "ListingPrice_From":
                    case "GrossRevenue_From":
                    case "GrossRevenue_To":
                    case "EBITDA_From":
                    case "EBITDA_To":
                    case "CashFlow_From":
                    case "CashFlow_To":
                    case "MinimumDownPayment_From":
                    case "MinimumDownPayment_To":
                    // ints
                    case "TotalSqFt_From":
                    case "TotalSqFt_To":
                    case "EmployeeCount_From":
                    case "EmployeeCount_To":
                        // We are dealing with Numbers - First remove the decimals if the exist
                        tsValue = String.Format("{0:n0}", this.SearchCriteria[tsPropertyName]);
                        break;
                }
            }
            return tsValue;
        }
        #endregion (First Time Generation of Tags from new SearchCriteria Record)

        #region Process Properties That are Lookups
        private string GetLookupValue(string tsPropertyName) {
            string sReturn = "";
            Lookup oLookup = LookupManager.Instance.GetLookupByOid((Int64)_searchCriteria[tsPropertyName]);
            if (oLookup != null) {
                sReturn = oLookup.Value;
            }
            return sReturn;
        }

        private void ProcessSearchCriteriaLookupList(string tsPropertyName) {
            DisplayTag oTag;
            Lookup oLookup;
            // Get the list of values in this property
            string sValues = _searchCriteria[tsPropertyName]?.ToString();
            List<Int64> oOidList = new List<Int64>();

            // Convert the comma delimited list to a list of Oids
            if (!string.IsNullOrEmpty(sValues)) {
                oOidList = FSTools.ConvertDelimitedStringToList<Int64>(sValues, ',');
            }

            // get the collection of tags with the TagId for this property
            DisplayTag oTagTemplate = DisplayTag.GetDisplayTag(tsPropertyName);
            List<DisplayTag> oCurrentList = GetTagListById(oTagTemplate.TagId);
            // Flip DeleteMe flag to True on each item in oCurrentList
            ModelUtil.MarkItemsForDeletion<DisplayTag>(oCurrentList);

            foreach (Int64 iOid in oOidList) {
                oTag = null;
                foreach (DisplayTag oItem in oCurrentList) {
                    if (oItem.SecondaryId.Equals(iOid.ToString())) {
                        oTag = oItem;
                        oTag.DeleteMe = false;
                    }
                }
                if (oTag == null) {
                    oLookup = LookupManager.Instance.GetLookupByOid(iOid);
                    if (oLookup == null) {
                        throw new Exception($"Error finding Lookup Value where Oid = {iOid} and SearchCriteria.Property = {tsPropertyName}");
                    }

                    oTag = new DisplayTag() { PropertyName = tsPropertyName, TableName = "SearchCriteria", Name = oTagTemplate.Name, Value = oLookup.Value, TagId = oTagTemplate.TagId, SecondaryId = oLookup.Oid.ToString() };
                    _searchTags.Add(oTag);
                }
            }

            // Remove recorsds still marked for Deletion in oCurrentList
            foreach (DisplayTag oItem in oCurrentList) {
                if (oItem.DeleteMe) {
                    RemoveSearchTagFromList(oItem);
                }
            }
        }
        #endregion (Process Properties That are Lookups)

        #region Process Keyword List
        private void ProcessSearchCriteriaWordList(string tsPropertyName) {
            DisplayTag oTag;
            // Get the list of values in this property
            string sValues = _searchCriteria[tsPropertyName]?.ToString();
            List<string> oWordList = new List<string>();

            // Convert the comma delimited list to a list of Oids
            if (!string.IsNullOrEmpty(sValues)) {
                oWordList = FSTools.ConvertDelimitedStringToList<string>(sValues, ',');
            }

            // get the collection of tags with the TagId for this property
            DisplayTag oTagTemplate = DisplayTag.GetDisplayTag(tsPropertyName);
            List<DisplayTag> oCurrentList = GetTagListById(oTagTemplate.TagId);
            // Flip DeleteMe flag to True on each item in oCurrentList
            ModelUtil.MarkItemsForDeletion<DisplayTag>(oCurrentList);

            foreach (string sWord in oWordList) {
                oTag = null;
                foreach (DisplayTag oItem in oCurrentList) {
                    if (oItem.SecondaryId.Equals(sWord)) {
                        oTag = oItem;
                        oTag.DeleteMe = false;
                    }
                }
                if (oTag == null) {
                    oTag = new DisplayTag() { PropertyName = tsPropertyName, TableName = "SearchCriteria", Name = oTagTemplate.Name, Value = sWord, TagId = oTagTemplate.TagId, SecondaryId = sWord };
                    _searchTags.Add(oTag);
                }
            }

            // Remove recorsds still marked for Deletion in oCurrentList
            foreach (DisplayTag oItem in oCurrentList) {
                if (oItem.DeleteMe) {
                    RemoveSearchTagFromList(oItem);
                }
            }
        }
        #endregion (Process Keyword List)

        public DisplayTag GetTagById(Int64 tiTagId) {
            DisplayTag oReturn = null;
            foreach (DisplayTag oTag in _searchTags) {
                if (oTag.TagId == tiTagId) {
                    oReturn = oTag;
                    break;
                }
            }
            return oReturn;
        }

        public List<DisplayTag> GetTagListById(Int64 tiTagId) {
            List<DisplayTag> oReturn = new List<DisplayTag>();
            foreach (DisplayTag oTag in _searchTags) {
                if (oTag.TagId == tiTagId) {
                    oReturn.Add(oTag);
                }
            }
            return oReturn;
        }

        public void AddSearchTagToList(DisplayTag toTag) {
            List<DisplayTag> oTemp = SearchTags;
            if ((toTag != null) && (!SearchTags.Contains(toTag))) {
                oTemp.Add(toTag);
                SearchTags = oTemp;
                OnTagListChanged?.Invoke(SearchTags, null);
                On_TagListCountChanged();
            }
        }

        public void RemoveSearchTagFromList(DisplayTag toTag) {
            if ((toTag != null) && (SearchTags.Contains(toTag))) {
                SearchTags.Remove(toTag);
                ClearSearchValue(toTag);
                On_TagListCountChanged();
            }
        }

        private void ClearSearchValue(DisplayTag toTag) {
            if (toTag.Name.Equals("BC:")) {
                RemoveItem(Convert.ToInt64(toTag.SecondaryId));
            } else {
                _searchCriteria[toTag.PropertyName] = null;
            }
        }

        public void ClearAllTags() {
            SearchTags.Clear();
        }

        public void On_TagListCountChanged() {
            SearchTags.Sort(DisplayTag.SortBySortValue);
        }

        #endregion (Tag Management)

        #region Business Category Management

        #region Add BusinessCategories
        public void AddItem(Int64 tiOid) {
            if (!_lkpBusinessCategoryOids_Int64List.Contains(tiOid)) {
                _lkpBusinessCategoryOids_Int64List.Add(tiOid);
                On_BusinessCategoryListChange();
            }
        }

        public void AddItems(List<Int64> toList) {
            bool bDataAdded = false;
            foreach (Int64 oid in toList) {
                if (!_lkpBusinessCategoryOids_Int64List.Contains(oid)) {
                    _lkpBusinessCategoryOids_Int64List.Add(oid);
                    bDataAdded = true;
                }
            }
            if (bDataAdded) {
                On_BusinessCategoryListChange();
            }
        }

        public void On_BusinessCategoryListChange() {
            lkpBusinessCategoryOids = FSTools.ConvertListToDelimitedString(_lkpBusinessCategoryOids_Int64List);
        }

        public List<IHierarchy> GetAllItems() {
            List<IHierarchy> oReturnList = LookupManager.Instance.GetCopyOfLookupNodeListByLookupName("BusinessCategory").Cast<IHierarchy>().ToList();
            LookupNode.SetSelectedOnNodeFromOidList(oReturnList, _lkpBusinessCategoryOids_Int64List);
            return oReturnList;
        }

        #endregion (Add BusinessCategories)

        #region Remove BusinessCategories
        public void RemoveItem(Int64 tiOid) {
            if (_lkpBusinessCategoryOids_Int64List.Contains(tiOid)) {
                _lkpBusinessCategoryOids_Int64List.Remove(tiOid);
                On_BusinessCategoryListChange();
            }
        }

        public void RemoveItems(List<Int64> toList) {
            bool bDataAdded = false;
            foreach (Int64 oid in toList) {
                if (_lkpBusinessCategoryOids_Int64List.Contains(oid)) {
                    _lkpBusinessCategoryOids_Int64List.Remove(oid);
                    bDataAdded = true;
                }
            }
            if (bDataAdded) {
                On_BusinessCategoryListChange();
            }
        }
        #endregion (Remove BusinessCategories)

        public List<IHierarchy> GetBusinessCategoriesAsHierarchyItems() {
            List<IHierarchy> oReturnList = new List<IHierarchy>();
            foreach (Int64 Oid in _lkpBusinessCategoryOids_Int64List) {
                LookupNode oNode = LookupManager.Instance.GetLookupNodeByOid(Oid);
                oReturnList.Add(oNode);
            }
            return oReturnList;
        }

        #endregion (Business Category Management)

        public SearchCriteriaDisplay Save() {
            // Save is a pass through top the SearchCriteria record
            if (SearchCriteria != null) {
                GetUpdatedListingCount();
                SearchCriteria.Save();
            }
            return this;
        }

        public void GetUpdatedListingCount() {
            if (SearchCriteria.NewListingsSinceLastSearchDate > 0) {
                SearchCriteria.ListingCount += SearchCriteria.NewListingsSinceLastSearchDate;
            } 
        } 
        
        #endregion(Methods)

        #region Properties
        public SearchCriteria SearchCriteria {
            get => _searchCriteria;
            set {
                if (_searchCriteria != value) {
                    _searchCriteria = value;
                    On_SearchCriteriaLoaded();
                }
            }
        }

        public List<DisplayTag> SearchTags {
            get { return _searchTags; }
            set { _searchTags = value; }
        }

        public string ResultAmount { 
            get { return _resultAmount; } 
            set { _resultAmount = value; } 
        }

        //public List<Int64> LkpBusinessCategoryOids_Int64List { get => _lkpBusinessCategoryOids_Int64List; set => _lkpBusinessCategoryOids_Int64List = value; }

        #region Properties that pass through to SeacrhCriteria
        //****************  The following properties are "pass throughs to the SearchCriteria object
        // Int64
        public Int64 Oid { get => _searchCriteria.Oid; set => _searchCriteria.Oid = value; }
        public Int64 EntityOid { get => _searchCriteria.EntityOid; set => _searchCriteria.EntityOid = value; }
        public Int64 lkpCountryOid { get => _searchCriteria.lkpCountryOid; set { _searchCriteria.lkpCountryOid = value; On_SearchCriteriaPropertyChanged("lkpCountryOid"); } }
        public Int64 lkpStateOid { get => _searchCriteria.lkpStateOid; set { _searchCriteria.lkpStateOid = value; On_SearchCriteriaPropertyChanged("lkpStateOid"); } }
        // string
        public string Name { get => _searchCriteria.Name; set { _searchCriteria.Name = value; } }
        public string lkpCountyOids { get => _searchCriteria.lkpCountyOids; set { _searchCriteria.lkpCountyOids = value; On_SearchCriteriaPropertyChanged("lkpCountyOids"); } }
        public string lkpCityOids { get => _searchCriteria.lkpCityOids; set { _searchCriteria.lkpCityOids = value; On_SearchCriteriaPropertyChanged("lkpCityOids"); } }
        public string ZipCode { get => _searchCriteria.ZipCode; 
            set { _searchCriteria.ZipCode = value; On_SearchCriteriaPropertyChanged("ZipCode"); } }
        public string ZipCodes { get => _searchCriteria.ZipCodes; set { _searchCriteria.ZipCodes = value; On_SearchCriteriaPropertyChanged("ZipCodes"); } }
        public string lkpBusinessCategoryOids { get => _searchCriteria.lkpBusinessCategoryOids; set { _searchCriteria.lkpBusinessCategoryOids = value; On_SearchCriteriaPropertyChanged("lkpBusinessCategoryOids"); } }
        public string Keywords { get => _searchCriteria.Keywords; set { _searchCriteria.Keywords = value; On_SearchCriteriaPropertyChanged("Keywords"); } }
        public string Street { get => _searchCriteria.Street; set { _searchCriteria.Street = value; On_SearchCriteriaPropertyChanged("Street"); } }
        // decimal
        public decimal? ListingPrice_From { get => _searchCriteria.ListingPrice_From; set { _searchCriteria.ListingPrice_From = value; On_SearchCriteriaPropertyChanged("ListingPrice_From"); } }
        public decimal? ListingPrice_To { get => _searchCriteria.ListingPrice_To; set { _searchCriteria.ListingPrice_To = value; On_SearchCriteriaPropertyChanged("ListingPrice_To"); } }
        public decimal? GrossRevenue_From { get => _searchCriteria.GrossRevenue_From; set { _searchCriteria.GrossRevenue_From = value; On_SearchCriteriaPropertyChanged("GrossRevenue_From"); } }
        public decimal? GrossRevenue_To { get => _searchCriteria.GrossRevenue_To; set { _searchCriteria.GrossRevenue_To = value; On_SearchCriteriaPropertyChanged("GrossRevenue_To"); } }
        public decimal? EBITDA_From { get => _searchCriteria.EBITDA_From; set { _searchCriteria.EBITDA_From = value; On_SearchCriteriaPropertyChanged("EBITDA_From"); } }
        public decimal? EBITDA_To { get => _searchCriteria.EBITDA_To; set { _searchCriteria.EBITDA_To = value; On_SearchCriteriaPropertyChanged("EBITDA_To"); } }
        public decimal? CashFlow_From { get => _searchCriteria.CashFlow_From; set { _searchCriteria.CashFlow_From = value; On_SearchCriteriaPropertyChanged("CashFlow_From"); } }
        public decimal? CashFlow_To { get => _searchCriteria.CashFlow_To; set { _searchCriteria.CashFlow_To = value; On_SearchCriteriaPropertyChanged("CashFlow_To"); } }
        public decimal? MinimumDownPayment_From { get => _searchCriteria.MinimumDownPayment_From; set { _searchCriteria.MinimumDownPayment_From = value; On_SearchCriteriaPropertyChanged("MinimumDownPayment_From"); } }
        public decimal? MinimumDownPayment_To {
            get => _searchCriteria.MinimumDownPayment_To;
            set { _searchCriteria.MinimumDownPayment_To = value; On_SearchCriteriaPropertyChanged("MinimumDownPayment_To"); }
        }
        // ints
        public int? SearchRadius { get => _searchCriteria.SearchRadius; 
            set { _searchCriteria.SearchRadius = value; On_SearchCriteriaPropertyChanged("SearchRadius"); } }
        public int? TotalSqFt_From { get => _searchCriteria.TotalSqFt_From; set { _searchCriteria.TotalSqFt_From = value; On_SearchCriteriaPropertyChanged("TotalSqFt_From"); } }
        public int? TotalSqFt_To { get => _searchCriteria.TotalSqFt_To; set { _searchCriteria.TotalSqFt_To = value; On_SearchCriteriaPropertyChanged("TotalSqFt_To"); } }
        public int? EmployeeCount_From { get => _searchCriteria.EmployeeCount_From; set { _searchCriteria.EmployeeCount_From = value; On_SearchCriteriaPropertyChanged("EmployeeCount_From"); } }
        public int? EmployeeCount_To { get => _searchCriteria.EmployeeCount_To; set { _searchCriteria.EmployeeCount_To = value; On_SearchCriteriaPropertyChanged("EmployeeCount_To"); } }
        // bools
        public bool? IsAbsenteeOwner { get => _searchCriteria.IsAbsenteeOwner; set { _searchCriteria.IsAbsenteeOwner = value; On_SearchCriteriaPropertyChanged("IsAbsenteeOwner"); } }
        public bool? IsHomeBased { get => _searchCriteria.IsHomeBased; set { _searchCriteria.IsHomeBased = value; On_SearchCriteriaPropertyChanged("IsHomeBased"); } }
        public bool? IsRelocatable { get => _searchCriteria.IsRelocatable; set { _searchCriteria.IsRelocatable = value; On_SearchCriteriaPropertyChanged("IsRelocatable"); } }
        public bool? IsFranchise { get => _searchCriteria.IsFranchise; set { _searchCriteria.IsFranchise = value; On_SearchCriteriaPropertyChanged("IsFranchise"); } }
        public bool? IsSellerFinanace { get => _searchCriteria.IsSellerFinanace; set { _searchCriteria.IsSellerFinanace = value; On_SearchCriteriaPropertyChanged("IsSellerFinanace"); } }
        public bool? IsSbaPreApproved { get => _searchCriteria.IsSbaPreApproved; set { _searchCriteria.IsSbaPreApproved = value; On_SearchCriteriaPropertyChanged("IsSbaPreApproved"); } }
        public bool? IsRealEstateAvailable { get => _searchCriteria.IsRealEstateAvailable; set { _searchCriteria.IsRealEstateAvailable = value; On_SearchCriteriaPropertyChanged("IsRealEstateAvailable"); } }
        public bool? IsTextNotification { get => _searchCriteria.IsTextNotification; set => _searchCriteria.IsTextNotification = value; }
        public bool? IsEmailRecipientListQuery { get => _searchCriteria.IsEmailRecipientListQuery; set => _searchCriteria.IsEmailRecipientListQuery = value; }
        public bool? IsEmailNotification { get => _searchCriteria.IsEmailNotification; set { _searchCriteria.IsEmailNotification = value; On_IsEmailChanged(); } }
        // misc
        public int NewListingsSinceLastSearchDate { get => _searchCriteria.NewListingsSinceLastSearchDate; set => _searchCriteria.NewListingsSinceLastSearchDate = value; }
        public DateTime? LastSearchedDate { get => _searchCriteria.LastSearchedDate; set => _searchCriteria.LastSearchedDate = value; }
        public bool IsActive { get => _searchCriteria.IsActive; set => _searchCriteria.IsActive = value; }
        public List<IHierarchy> SelectedItems { get => GetBusinessCategoriesAsHierarchyItems(); }
        public List<Int64> LkpBusinessCategoryOids_Int64List { get => _lkpBusinessCategoryOids_Int64List; }
        #endregion (Properties that pass through to SeacrhCriteria)

        #endregion(Properties)
    }


    public class SearchCriteriaChangedEventArgs : EventArgs {

        #region Constructor
        public SearchCriteriaChangedEventArgs() { }
        public SearchCriteriaChangedEventArgs(string tsPropertyName, string tsValue) {
            PropertyName = tsPropertyName;
            CurrentValue = tsValue;
        }
        #endregion (Constructor)

        public string PropertyName { get; set; } = "";
        public string CurrentValue { get; set; } = "";

    }
}