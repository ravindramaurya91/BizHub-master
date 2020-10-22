using System;
using System.Diagnostics;

namespace CommonUtil {

    public class LoanCalcRequest : EventArgs {

        #region Fields
        private double _loanYears;
        private double _loanMonths;
        #endregion (Fields)

        #region Methods
        public LoanCalcResult CalculateLoanSchedule() {
            LoanCalcResult oReturn = null;
            if (OkToCalculate()) {
                oReturn = new LoanCalcResult() { Fees = this.Fees, APR = 0.00, InterestRate = this.InterestRate, LoanAmount = this.LoanAmount, LoanMonths = this.LoanMonths, LoanYears = this.LoanYears, MonthlyPayment = 0.00, Points = this.Points };

                double intRate = (this.InterestRate / 100) / 12;
                oReturn.MonthlyPayment = Math.Round((this.LoanAmount * (Math.Pow((1 + intRate), this.LoanMonths)) * intRate / (Math.Pow((1 + intRate), this.LoanMonths) - 1)), 2);
                oReturn.TotalPointsAndFees = oReturn.Fees + (oReturn.LoanAmount * (oReturn.Points / 100));
                oReturn.FundedAmount = oReturn.LoanAmount - oReturn.TotalPointsAndFees;
                CalculateAmortizationSchedule(oReturn);
                CalculateAPR(oReturn);
                oReturn.NumberOfPayments = Convert.ToInt32(LoanMonths);
            }
            return oReturn;
        }

        private void CalculateAPR(LoanCalcResult toResult) {
            double numPay = toResult.LoanMonths;
            double payment = toResult.MonthlyPayment;
            double amountReceived = toResult.LoanAmount - toResult.TotalPointsAndFees;
            double error = Math.Pow(10, -5);
            double approx = toResult.InterestRate / 12; // let's start with a guess that the APR is 5% 
            double prev_approx = 0.00;
            double diff = 0.00;

            Debug.WriteLine($"initial guess {approx}");
            for (int k = 0; k < 20; k++) {
                prev_approx = approx;
                approx = prev_approx - AprAttempt1(toResult, amountReceived, prev_approx) / AprAttempt2(toResult, amountReceived, prev_approx);
                diff = Math.Abs(approx - prev_approx);
                Debug.WriteLine($"new guess $approx diff is {diff}");
                if (diff < error) {
                    break;
                }
            }

            toResult.APR = Math.Round((approx * 12 * 10000) / 100, 2); // this way we get APRs like 7.5% or 6.55%
            Debug.WriteLine($"APR is {toResult.APR}% final approx {approx} ");
        }

        private double AprAttempt1(LoanCalcResult toResult, double amount, double x) {
            return amount * x * Math.Pow(1 + x, toResult.LoanMonths) / (Math.Pow(1 + x, toResult.LoanMonths) - 1) - toResult.MonthlyPayment;
        }

        private double AprAttempt2(LoanCalcResult toResult, double amount, double x) {
            return amount * (Math.Pow(1 + x, toResult.LoanMonths) / (-1 + Math.Pow(1 + x, toResult.LoanMonths)) - toResult.LoanMonths * x * Math.Pow(1 + x, -1 + 2 * toResult.LoanMonths) / Math.Pow(-1 + Math.Pow(1 + x, toResult.LoanMonths), 2) + toResult.LoanMonths * x * Math.Pow(1 + x, -1 + toResult.LoanMonths) / (-1 + Math.Pow(1 + x, toResult.LoanMonths)));
        }

        private void CalculateAmortizationSchedule(LoanCalcResult toLoanCalcResult) {
            LoanPayment oPayment;
            double dPeriodicRate = (toLoanCalcResult.InterestRate / 100) / 12;
            double dPeriodicPayment = Math.Round(toLoanCalcResult.MonthlyPayment, 2);
            double dBalance = toLoanCalcResult.LoanAmount;
            toLoanCalcResult.PointsDollars = ((toLoanCalcResult.Points / 100) * toLoanCalcResult.LoanAmount);
            double dPeriodicInterest = 0.00;
            double dPrincipalApplied = 0.00;
            double dAdditionalPayment = 0.00;

            while (dBalance > 0) {
                dPeriodicInterest = Math.Round((dBalance * dPeriodicRate), 2);  // The interest accrued for the month
                dPrincipalApplied = Math.Round(dPeriodicPayment - dPeriodicInterest, 2);  // How much of the payment goes to pricipal
                dBalance = Math.Round(dBalance - (dPrincipalApplied + dAdditionalPayment), 2);

                toLoanCalcResult.TotalPaid = Math.Round(toLoanCalcResult.TotalPaid + (dPeriodicPayment + dAdditionalPayment), 2);
                toLoanCalcResult.TotalInterestPaid = Math.Round(toLoanCalcResult.TotalInterestPaid + dPeriodicInterest, 2);

                oPayment = new LoanPayment() { AdditionalPayment = dAdditionalPayment, Payment = dPeriodicPayment, Interest = dPeriodicInterest, Principal = dPrincipalApplied, Balance = dBalance };
                toLoanCalcResult.PaymentSchedule.Add(oPayment);
            }

            // Adjust the final payment to bring the loan balance to Zero
            int i = toLoanCalcResult.PaymentSchedule.Count - 1;
            double dFinalBalance = toLoanCalcResult.PaymentSchedule[i].Balance;
            if (dFinalBalance != 0.00) {
                toLoanCalcResult.PaymentSchedule[i].Payment = Math.Round(toLoanCalcResult.PaymentSchedule[i].Payment + dFinalBalance, 2);
                toLoanCalcResult.PaymentSchedule[i].Balance = 0.00;
            }
            toLoanCalcResult.TotalPaid = toLoanCalcResult.TotalPaid + toLoanCalcResult.Fees;
        }

        private bool OkToCalculate() {
            bool bReturn = true;
            string sMsg = "";

            if ((InterestRate <= 0) ||
               (LoanAmount <= 0) ||
               (LoanMonths <= 0)) {

                if (InterestRate <= 0) {
                    sMsg += "<br>Interest rate must be greater than $0.00";
                }
                if (LoanAmount <= 0) {
                    sMsg += "<br>Loan amount rate must be greater than 0.00 %";
                }
                if (LoanMonths <= 0) {
                    sMsg += "<br>The number of months  must be greater than 0. ";
                }
                if (sMsg.Length > 0) {
                    throw new Exception("Incomplete information:" + sMsg);
                }
                bReturn = false;
            }
            return bReturn;
        }

        private void OnLoanYearsChanged() {
            if(_loanYears >= 0) {
                _loanMonths = Math.Ceiling((_loanYears * 12));
            } else {
                _loanMonths = 0;
            }
        }

        private void OnLoanMonthsChanged() {
            if (_loanMonths > 0) {
                _loanYears = Math.Round((_loanMonths / 12), 2);
            } else {
                _loanYears = 0;
            }
        }
        #endregion (Methods)

        #region Properties
        public double LoanAmount { get; set; } = 0.00;
        public string DisplayLoanAmount { get; set; } = "";
        public double InterestRate { get; set; } = 0.00;
        public string DisplayInterestRate { get; set; } = "";
        public double Points { get; set; } = 0.00;
        public double PointsDollars { get; set; } = 0.00;
        public double TotalPointsAndFees { get; set; } = 0.00;
        public string DisplayPoints { get; set; } = "";
        public double Fees { get; set; } = 0.00;
        public string DisplayFees { get; set; } = "";

        public double LoanYears {
            get { return _loanYears; }
            set {
                _loanYears = value;
                OnLoanYearsChanged();
            }
        }
        public double LoanMonths {
            get { return _loanMonths; }
            set {
                _loanMonths = value;
                OnLoanMonthsChanged();
            }
        }
        #endregion (Properties)
    }
}
