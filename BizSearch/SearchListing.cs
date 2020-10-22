using System;
using System.Collections.Generic;
using System.Text;

using Model;

namespace BizSearch {
    public class SearchListing : ListingDTO {

        #region Fields

        #region Fields Used in the Primary Search Pass
        private decimal?[] _decimals = new decimal?[SrchConstants.DecimalArrayCount];
        private int?[] _integers = new int?[SrchConstants.IntegerArrayCount];
        private bool?[] _booleans = new bool?[SrchConstants.BooleanArrayCount];
        private StringValueSet _words = new StringValueSet();
        #endregion (Fields Used in the Primary Search Pass)


        #region Listing metrics added after search from Entity2ListingMap_Stat
        //private Entity2ListingMap_Stat _metrics = null;
        #endregion (Listing metrics added after search from Entity2ListingMap_Stat)

        #endregion (Fields)

        public void DeconstructData() {
            // Decimals
            _decimals[SrchConstants.DCashFlowIndex] = CashFlow;
            _decimals[SrchConstants.DEBITDAIndex] = EBITDA;
            _decimals[SrchConstants.DGrossRevenueIndex] = GrossRevenue;
            _decimals[SrchConstants.DListingPriceIndex] = ListingPrice;
            _decimals[SrchConstants.DMinimumDownPaymentIndex] = MinimumDownPayment;
            // Integers
            _integers[SrchConstants.IEmployeeCountIndex] = EmployeeCount;
            _integers[SrchConstants.ITotalSqFtIndex] = TotalSqFt;
            // Booleans
            _booleans[SrchConstants.BAbsenteeOwnerIndex] = IsAbsenteeOwner;
            _booleans[SrchConstants.BFranchiseIndex] = IsFranchise;
            _booleans[SrchConstants.BHomeBasedIndex] = IsHomeBased;
            _booleans[SrchConstants.BRelocatableIndex] = IsRelocatable;
            _booleans[SrchConstants.BSbaPreApprovedIndex] = IsSbaPreApproved;
            _booleans[SrchConstants.BSellerFinanaceIndex] = IsSellerFinanace;

            if (!string.IsNullOrEmpty(this.Keywords)) { _words.AddWords(this.Keywords); }
            if (!string.IsNullOrEmpty(this.AdTitle)) { _words.AddWords(this.AdTitle); }
            if (!string.IsNullOrEmpty(this.AdTagLine)) { _words.AddWords(this.AdTagLine); }
            if (!string.IsNullOrEmpty(this.AdDescription)) { _words.AddWords(this.AdDescription);}
        }

        #region Properties
        public decimal?[] Decimals { get => _decimals; } 
        public int?[] Integers { get => _integers; }
        public bool?[] Booleans { get => _booleans; }
        public StringValueSet Words { get => _words; }
        //public Entity2ListingMap_Stat Metrics { get => _metrics; set => _metrics = value; }
        #endregion (Properties)
    }

}
