using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtil {
    public class LoanPayment {

        #region Properties
        public double Payment { get; set; } = 0.00;
        public double Interest { get; set; } = 0.00;
        public double Principal { get; set; } = 0.00;
        public double AdditionalPayment { get; set; } = 0.00;
        public double Balance { get; set; } = 0.00;
        #endregion (Properties)

    }
    public class PieChartCalc {
        #region Properties
        public double Principal { get; set; } = 0.00;
        public double Interest { get; set; } = 0.00;
        public double FeesAndCharges { get; set; } = 0.00;
        #endregion (Properties)
    }

    public class PieChartModel {
        #region Properties
        public string Name { get; set; }
        public double Percentage { get; set; }
        public string Color { get; set; }
        #endregion (Properties)
    }

}
