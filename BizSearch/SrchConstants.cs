using System;
using System.Collections.Generic;
using System.Text;

namespace BizSearch {
    public class SrchConstants {
        // Decimal Compare Indexes
        public const int DListingPriceIndex = 0;
        public const int DGrossRevenueIndex = 1;
        public const int DEBITDAIndex = 2;
        public const int DCashFlowIndex = 3;
        public const int DMinimumDownPaymentIndex = 4;
        public const int DecimalArrayCount = 5;

        // Integer Compare Indexes
        public const int ITotalSqFtIndex = 0;
        public const int IEmployeeCountIndex = 1;
        public const int IntegerArrayCount = 2;

        // Boolean Compare Indexes
        public const int BAbsenteeOwnerIndex = 0;
        public const int BHomeBasedIndex = 1;
        public const int BRelocatableIndex = 2;
        public const int BFranchiseIndex = 3;
        public const int BSellerFinanaceIndex = 4;
        public const int BSbaPreApprovedIndex = 5;
        public const int BooleanArrayCount = 6;

        // String:  Words to be ignored in the Key Word Search - We out them here so they only get instantiated once yet are universally available
        public const string IGNORED_WORDS = ",AND,OF,THE,A,";
    }
}
