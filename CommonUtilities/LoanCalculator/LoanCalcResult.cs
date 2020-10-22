using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Schema;

namespace CommonUtil
{
    public class LoanCalcResult : LoanCalcRequest
    {
        #region Fields
        private List<LoanPayment> _payments = new List<LoanPayment>();
        #endregion (Fields)

        #region Properties
        public double FundedAmount { get; set; } = 0.00;  // Loan Amount - Points & fees (if points and fees come out of the loan)
        public double TotalLoanCost { get; set; } = 0.00;  // Loan Interest + Points & fees 
        public double MonthlyPayment { get; set; } = 0.00;
        public string DisplayMonthlyPayment { get; set; }
        public int NumberOfPayments { get; set; }
        public double TotalPaid { get; set; }
        public string DisplayTotalPaid { get; set; }
        public double TotalInterestPaid { get; set; }
        public string DisplayTotalInterestPaid { get; set; }
        public double APR { get; set; }
        public List<LoanPayment> PaymentSchedule { get => _payments; set => _payments = value; }
        #endregion (Properties)

    }
}
