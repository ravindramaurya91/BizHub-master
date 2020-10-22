using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtil {
    public class LoanCalculator {

        #region Fields
        private const int _monthsPerYear = 12;
        #endregion (Fields)

        #region Constructor
        #endregion (Constructor)

        #region Methods
        #endregion (Methods)

        #region Properties
        public double LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public double LoanTermMonths { get; set; }
        #endregion (Properties)

        public double LoanTermYears {
            get { return LoanTermMonths / _monthsPerYear; }
            set { LoanTermMonths = (value * _monthsPerYear); }
        }

        public double CalculatePayment() {
            double payment = 0;

            if (LoanTermMonths > 0) {
                if (InterestRate != 0) {
                    double rate = ((InterestRate / _monthsPerYear) / 100);
                    double factor = (rate + (rate / (Math.Pow(rate + 1, LoanTermMonths) - 1)));
                    payment = (LoanAmount * factor);
                } else payment = (LoanAmount / LoanTermMonths);
            }
            return Math.Round(payment, 2);
        }
    }
}
