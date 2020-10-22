using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public partial class Whse_RunSearchArchive {


        #region Constructor
        public Whse_RunSearchArchive() { }

        public Whse_RunSearchArchive(SearchCriteria oC) {
            SearchCriteriaOid = oC.Oid;
            EntityOid = oC.EntityOid;
            RunDate = DateTime.UtcNow;
            CashFlow_From = oC.CashFlow_From;
            CashFlow_To = oC.CashFlow_To;
            EBITDA_From = oC.EBITDA_From;
            EBITDA_To = oC.EBITDA_To;
            EmployeeCount_From = oC.EmployeeCount_From;
            EmployeeCount_To = oC.EmployeeCount_To;
            GrossRevenue_From = oC.GrossRevenue_From;

        }

        #endregion (Constructor)
    }
}
