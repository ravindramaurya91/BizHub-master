using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using CommonUtil;
using PetaPoco;

namespace Model {
    public partial class SearchCriteria {


        #region Events
        #endregion (Events)

        private class ParameterObject {
            public string ColumnName { get; set; }
            public string ShortName { get; set; }
            public string DefaultValue { get; set; }
        }

        #region Constructor
        public SearchCriteria() {
            SearchRadius = Convert.ToInt32(Constants.ZIPCODE_SEARCH_DISTANCES[0].Value);
        }
        #endregion (Constructor)

        #region Fields
        private List<ParameterObject> _searchParameters = new List<ParameterObject> {
            new ParameterObject{ColumnName = "Oid", ShortName = "ID", DefaultValue = "0"},
            new ParameterObject{ColumnName = "SearchRadius", ShortName = "SR", DefaultValue = "0"},
            new ParameterObject{ColumnName = "ZipCode", ShortName = "ZC", DefaultValue = "0"},
            new ParameterObject{ColumnName = "lkpBusinessCategoryOids", ShortName = "BCIDS", DefaultValue = ""},
            new ParameterObject{ColumnName = "ListingPrice_From", ShortName = "LPF", DefaultValue = "0"},
            new ParameterObject{ColumnName = "ListingPrice_To", ShortName = "LPT", DefaultValue = "0"},
            new ParameterObject{ColumnName = "CashFlow_From", ShortName = "CFF", DefaultValue = "0"},
            new ParameterObject{ColumnName = "CashFlow_To", ShortName = "CFT", DefaultValue = "0"},
            new ParameterObject{ColumnName = "GrossRevenue_From", ShortName = "GRF", DefaultValue = "0"},
            new ParameterObject{ColumnName = "GrossRevenue_To", ShortName = "GRT", DefaultValue = "0"},
            new ParameterObject{ColumnName = "EBITDA_From", ShortName = "EBF", DefaultValue = "0"},
            new ParameterObject{ColumnName = "EBITDA_To", ShortName = "EBT", DefaultValue = "0"},
            new ParameterObject{ColumnName = "MinimumDownPayment_From", ShortName = "MDF", DefaultValue = "0"},
            new ParameterObject{ColumnName = "MinimumDownPayment_To", ShortName = "MDT", DefaultValue = "0"},
            new ParameterObject{ColumnName = "EmployeeCount_From", ShortName = "ECF", DefaultValue = "0"},
            new ParameterObject{ColumnName = "EmployeeCount_To", ShortName = "ECT", DefaultValue = "0"},
            new ParameterObject{ColumnName = "IsSbaPreApproved", ShortName = "SBA", DefaultValue = "False"},
            new ParameterObject{ColumnName = "IsSellerFinanace", ShortName = "SF", DefaultValue = "False"},
            new ParameterObject{ColumnName = "IsAbsenteeOwner", ShortName = "AO", DefaultValue = "False"},
            new ParameterObject{ColumnName = "IsFranchise", ShortName = "FR", DefaultValue = "False"},
            new ParameterObject{ColumnName = "IsRelocatable", ShortName = "RE", DefaultValue = "False"},
            new ParameterObject{ColumnName = "IsRealEstateAvailable", ShortName = "RA", DefaultValue = "False"},
            //new ParameterObject{ColumnName = "lkpCountryOid", ShortName = "CTRYID", DefaultValue = "0"},
            //new ParameterObject{ColumnName = "lkpStateOid", ShortName = "STID", DefaultValue = "0"},
        };
        #endregion (Fields)

        #region Methods
        public static string ToUrl(SearchCriteria toSearchCriteria) {
            // Create a StringBuilder and Ratchet through the SearchCriteriaColumns to build a URL extension string
            StringBuilder sb = new System.Text.StringBuilder();
            foreach (ParameterObject oParam in toSearchCriteria._searchParameters) {
                var value = toSearchCriteria[oParam.ColumnName];
                string oValue = (value != null) ? value.ToString() : "";
                if (!oValue.Equals(oParam.DefaultValue) && !string.IsNullOrEmpty(oValue)) {
                    sb.Append("!" + oParam.ShortName + "!" + toSearchCriteria[oParam.ColumnName].ToString() + "+" + oParam.ShortName + "+");
                }
            }
            return sb.ToString();
        }

        public static SearchCriteria FromUrl(string tsUrl) {
            SearchCriteria oReturn;
            string oValue = GetString("ID", ref tsUrl, true, true);
            if (!oValue.Equals(0) && !string.IsNullOrEmpty(oValue)) {
                oReturn = SQL.GetSearchCriteriaByOid(Convert.ToInt32(oValue));
            } else {
                oReturn = new SearchCriteria();
            }
            return FromUrl(tsUrl, oReturn);
        }

        public static SearchCriteria FromUrl(string tsUrl, SearchCriteria toSearchCriteria) {
            foreach (ParameterObject oParam in toSearchCriteria._searchParameters) {
                string sValue = GetValueFromUrl(oParam.ShortName, ref tsUrl);
                if (!string.IsNullOrEmpty(sValue)) {
                    toSearchCriteria[oParam.ColumnName] = FSTools.ConvertValueByType(toSearchCriteria.GetType().GetProperty(oParam.ColumnName).PropertyType, sValue);
                }
            }
            return toSearchCriteria;
        }

        private static string GetValueFromUrl(string tsTag, ref string tsUrl) {
            return GetString(tsTag, ref tsUrl, false, true);
        }

        private static string GetString(string tsTag, ref string tsString, bool tbPreserveXml, bool tbTrim) {
            string sReturn = "";
            try {
                sReturn = ExtractDataBlockFromXML(ref tsTag, ref tsString, tbPreserveXml);
                if (tbTrim) {
                    sReturn = sReturn.Trim();
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message + "\r\n\r\nXML Tag = " + tsTag, ex);
            }
            return sReturn;
        }

        private static string ExtractDataBlockFromXML(ref string tsTag, ref string tsXml, bool tbPreserveXml) {
            int startPos = -1, startPos2 = -1, endPos = -1, endPos2 = -1;
            string returnValue = "";

            GetLocation(ref tsTag, ref tsXml, ref startPos, ref endPos, ref startPos2, ref endPos2);

            if (endPos < startPos) {
                // ERROR:  If endPos = 0 & startPos > 0 - there is an error in th XML- there should be an endPos
                Exception ex = new Exception("A request has been issued to the XML Parser to retrieve data inside the <" + tsTag + "> tag.  However, the data string submitted does not have an ending matching end tag.");
                throw (ex);
            } else {
                // Get inside content start and end positions
                if ((startPos > -1) && (endPos2 > -1)) {
                    // Get the return block from the XML string
                    returnValue = tsXml.Substring(startPos2, endPos - startPos2);

                    // Now remove the block from the original string
                    if (!tbPreserveXml) {
                        if (startPos == 0) {
                            tsXml = tsXml.Substring(endPos2);
                        } else {
                            tsXml = tsXml.Substring(0, startPos) + tsXml.Substring(endPos2);
                        }
                    }
                }
            }
            return returnValue;
        }

        private static void GetLocation(ref string tsTag, ref string tsString, ref int tiStartPos, ref int tiEndPos, ref int tiStartPos2, ref int tiEndPos2) {
            tsTag = tsTag.ToUpper();
            string startTag = "!" + tsTag + "!";
            string endTag = "+" + tsTag + "+";

            string comparisonString = tsString.ToUpper();
            // Get start and end tags
            tiStartPos = comparisonString.IndexOf(startTag);
            tiEndPos = comparisonString.IndexOf(endTag);
            tiStartPos2 = tiStartPos + startTag.Length;
            tiEndPos2 = tiEndPos + endTag.Length;
        }

        public List<Int64> ConvertBusinessCategoryStringsToInt64() {
            List<Int64> oReturn = new List<long>();
            if (!String.IsNullOrEmpty(lkpBusinessCategoryOids)) {
                oReturn = FSTools.ConvertDelimitedStringToList<Int64>(lkpBusinessCategoryOids, ',');
            }
            return oReturn;
        }

        public static List<SearchCriteriaDisplay> ConvertSearchCriteriaListToDisplayList(List<SearchCriteria> toList) {
            List<SearchCriteriaDisplay> rList = new List<SearchCriteriaDisplay>();

            foreach (SearchCriteria oSC in toList) {
                SearchCriteriaDisplay oNewDisplay = new SearchCriteriaDisplay(oSC);
                rList.Add(oNewDisplay);
            }

            return rList;
        }

        #endregion(Methods)

        #region Properties

        //#region Indexer
        //[Ignore]
        //public object this[string tsPropertyName] {
        //    get {
        //        object oReturn = null;
        //        switch (tsPropertyName) {
        //            // Int64
        //            case "Oid": oReturn = (Oid != null) ? (Int64)Oid : 0; break;
        //            case "EntityOid": oReturn = (EntityOid != null) ? (Int64)EntityOid : 0; break;
        //            case "lkpCountryOid": oReturn = (lkpCountryOid != null) ? (Int64)lkpCountryOid : 0; break;
        //            case "lkpStateOid": oReturn = (lkpStateOid != null) ? (Int64)lkpStateOid : 0; break;
        //            // string
        //            case "Name": oReturn = (!String.IsNullOrEmpty(Name)) ? (string)Name : ""; break;
        //            case "lkpCountyOids": oReturn = (!String.IsNullOrEmpty(lkpCountyOids)) ? (string)lkpCountyOids : ""; break;
        //            case "lkpCityOids": oReturn = (!String.IsNullOrEmpty(lkpCityOids)) ? (string)lkpCityOids : ""; break;
        //            case "ZipCode": oReturn = (!String.IsNullOrEmpty(ZipCode)) ? (string)ZipCode : ""; break;
        //            case "ZipCodes": oReturn = (!String.IsNullOrEmpty(ZipCodes)) ? (string)ZipCodes : ""; break;
        //            case "lkpBusinessCategoryOids": oReturn = (!String.IsNullOrEmpty(lkpBusinessCategoryOids)) ? (string)lkpBusinessCategoryOids : ""; break;
        //            case "Keywords": oReturn = (!String.IsNullOrEmpty(Keywords)) ? (string)Keywords : ""; break;
        //            case "Street": oReturn = (!String.IsNullOrEmpty(Street)) ? (string)Street : ""; break;
        //            // decimal
        //            case "ListingPrice_To": oReturn = (ListingPrice_To != null) ? (decimal)ListingPrice_To : 0M; break;
        //            case "ListingPrice_From": oReturn = (ListingPrice_From != null) ? (decimal)ListingPrice_From : default(decimal); break;
        //            case "GrossRevenue_From": oReturn = (GrossRevenue_From != null) ? (decimal)GrossRevenue_From : decimal.Zero; break;
        //            case "GrossRevenue_To": oReturn = (GrossRevenue_To != null) ? (decimal)GrossRevenue_To : decimal.Zero; break;
        //            case "EBITDA_From": oReturn = (EBITDA_From != null) ? (decimal)EBITDA_From : decimal.Zero; break;
        //            case "EBITDA_To": oReturn = (EBITDA_To != null) ? (decimal)EBITDA_To : decimal.Zero; break;
        //            case "CashFlow_From": oReturn = (CashFlow_From != null) ? (decimal)CashFlow_From : decimal.Zero; break;
        //            case "CashFlow_To": oReturn = (CashFlow_To != null) ? (decimal)CashFlow_To : decimal.Zero; break;
        //            case "MinimumDownPayment_From": oReturn = (MinimumDownPayment_From != null) ? (decimal)MinimumDownPayment_From : decimal.Zero; break;
        //            case "MinimumDownPayment_To": oReturn = (MinimumDownPayment_To != null) ? (decimal)MinimumDownPayment_To : decimal.Zero; break;
        //            // ints
        //            case "SearchRadius": oReturn = (SearchRadius != null) ? (int)SearchRadius : default(int); break;
        //            case "TotalSqFt_From": oReturn = (TotalSqFt_From != null) ? (int)TotalSqFt_From : default(int); break;
        //            case "TotalSqFt_To": oReturn = (TotalSqFt_To != null) ? (int)TotalSqFt_To : default(int); break;
        //            case "EmployeeCount_From": oReturn = (EmployeeCount_From != null) ? (int)EmployeeCount_From : default(int); break;
        //            case "EmployeeCount_To": oReturn = (EmployeeCount_To != null) ? (int)EmployeeCount_To : default(int); break;
        //            // bools
        //            case "IsAbsenteeOwner": oReturn = (IsAbsenteeOwner != null) ? (bool)IsAbsenteeOwner : default(bool); break;
        //            case "IsHomeBased": oReturn = (IsHomeBased != null) ? (bool)IsHomeBased : default(bool); break;
        //            case "IsRelocatable": oReturn = (IsRelocatable != null) ? (bool)IsRelocatable : default(bool); break;
        //            case "IsFranchise": oReturn = (IsFranchise != null) ? (bool)IsFranchise : default(bool); break;
        //            case "IsSellerFinanace": oReturn = (IsSellerFinanace != null) ? (bool)IsSellerFinanace : default(bool); break;
        //            case "IsSbaPreApproved": oReturn = (IsSbaPreApproved != null) ? (bool)IsSbaPreApproved : default(bool); break;
        //            case "IsRealEstateAvailable": oReturn = (IsRealEstateAvailable != null) ? (bool)IsRealEstateAvailable : default(bool); break;
        //            case "IsTextNotification": oReturn = (IsTextNotification != null) ? (bool)IsTextNotification : default(bool); break;
        //            case "IsEmailNotification": oReturn = (IsEmailNotification != null) ? (bool)IsEmailNotification : default(bool); break;
        //            // misc
        //            case "NewListingsSinceLastSearchDate": oReturn = (NewListingsSinceLastSearchDate != null) ? (int)NewListingsSinceLastSearchDate : default(int); break;
        //            case "LastSearchedDate": oReturn = (LastSearchedDate != null) ? (DateTime)LastSearchedDate : default(DateTime?); break;
        //            case "IsActive": oReturn = (IsActive != null) ? (bool)IsActive : default(bool); break;
        //        }
        //        if (oReturn.ToString().Equals("0")) {
        //            oReturn = "";
        //        }
        //        return oReturn;
        //    }
        //    set {
        //        switch (tsPropertyName) {
        //            // Int64
        //            case "Oid": Oid = (Int64)value; break;
        //            case "EntityOid": EntityOid = (Int64)value; break;
        //            case "lkpCountryOid": lkpCountryOid = (Int64)value; break;
        //            case "lkpStateOid": lkpStateOid = (Int64)value; break;
        //            // string
        //            case "Name": Name = (string)value; break;
        //            case "lkpCountyOids": lkpCountyOids = (string)value ?? ""; break;
        //            case "lkpCityOids": lkpCityOids = (string)value ?? ""; break;
        //            case "ZipCode": ZipCode = (string)value ?? ""; break;
        //            case "ZipCodes": ZipCodes = (string)value ?? ""; break;
        //            case "lkpBusinessCategoryOids": lkpBusinessCategoryOids = (string)value; break;
        //            case "Keywords": Keywords = (string)value ?? ""; break;
        //            case "Street": Street = (string)value; break;
        //            // decimal
        //            case "ListingPrice_To": ListingPrice_To = (decimal?)value; break;
        //            case "ListingPrice_From": ListingPrice_From = (decimal?)value; break;
        //            case "GrossRevenue_From": GrossRevenue_From = (decimal?)value; break;
        //            case "GrossRevenue_To": GrossRevenue_To = (decimal?)value; break;
        //            case "EBITDA_From": EBITDA_From = (decimal?)value; break;
        //            case "EBITDA_To": EBITDA_To = (decimal?)value; break;
        //            case "CashFlow_From": CashFlow_From = (decimal?)value; break;
        //            case "CashFlow_To": CashFlow_To = (decimal?)value; break;
        //            case "MinimumDownPayment_From": MinimumDownPayment_From = (decimal?)value; break;
        //            case "MinimumDownPayment_To": MinimumDownPayment_To = (decimal?)value; break;
        //            // ints
        //            case "SearchRadius": SearchRadius = (int?)value; break;
        //            case "TotalSqFt_From": TotalSqFt_From = (int?)value; break;
        //            case "TotalSqFt_To": TotalSqFt_To = (int?)value; break;
        //            case "EmployeeCount_From": EmployeeCount_From = (int?)value; break;
        //            case "EmployeeCount_To": EmployeeCount_To = (int?)value; break;
        //            // bools
        //            case "IsAbsenteeOwner": IsAbsenteeOwner = (bool?)value; break;
        //            case "IsHomeBased": IsHomeBased = (bool?)value; break;
        //            case "IsRelocatable": IsRelocatable = (bool?)value; break;
        //            case "IsFranchise": IsFranchise = (bool?)value; break;
        //            case "IsSellerFinanace": IsSellerFinanace = (bool?)value; break;
        //            case "IsSbaPreApproved": IsSbaPreApproved = (bool?)value; break;
        //            case "IsRealEstateAvailable": IsRealEstateAvailable = (bool?)value; break;
        //            case "IsTextNotification": IsTextNotification = (bool?)value; break;
        //            case "IsEmailNotification": IsEmailNotification = (bool?)value; break;
        //            // misc
        //            case "NewListingsSinceLastSearchDate": NewListingsSinceLastSearchDate = (int)value; break;
        //            case "LastSearchedDate": LastSearchedDate = (DateTime)value; break;
        //            case "IsActive": IsActive = (bool)value; break;
        //        }

        //    }
        //}
        //#endregion (Indexer)

        #endregion(Properties)

    }
}
