using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CommonUtil {

    public class LoanCalcRequest_Mortgage : LoanCalcRequest{

        public static LoanCalcResult CalculateMortgagePayment_WithImpoundAccount(LoanCalcRequest_Mortgage toRequest) {
            double iPeriodicInterest = Math.Pow(1 + (toRequest.InterestRate / 100), 1.0 / 12) - 1;
            double iIntRate = toRequest.InterestRate / 100;
            // (Loan Value) * (1 + r/12) ^ p = (12x / r) * ((1 + r/12)^p - 1)
            // payment = (((Loan Value) * (1 + r/12) ^ p) * r)/ (12 * ((1 + r/12)^p - 1)));

            double propertyTax_Monthly = toRequest.TaxesPerYear / 12;
            double insurance_Monthly = toRequest.InsurancePerYear / 12;

            // plug the values from the input into the mortgage formula

            double iTestpayment = (toRequest.LoanAmount) * (Math.Pow(iPeriodicInterest, toRequest.LoanMonths) * iIntRate) / (12 * (Math.Pow(iPeriodicInterest, toRequest.LoanMonths)));
            double payment = (toRequest.LoanAmount) * (Math.Pow((1 + iIntRate / 12), toRequest.LoanMonths) * iIntRate) / (12 * (Math.Pow((1 + iIntRate / 12), toRequest.LoanMonths) - 1));

            // add on a monthly property tax and insurance

            payment += (propertyTax_Monthly + insurance_Monthly);

            // return the monthly payment calculated 

            return new LoanCalcResult() { APR = 0.00, Fees = toRequest.Fees, InterestRate = toRequest.InterestRate, LoanAmount = toRequest.LoanAmount, LoanMonths = toRequest.LoanMonths };
        }

        //function that calculates total payment
        private double CalculateTotalPayment(double pAmount, int loanTerm, double interestRate) {

            double totPayment;
            double monthlyPayment = CalculateMonthlyPayment(pAmount, loanTerm, interestRate);
            totPayment = loanTerm * monthlyPayment;
            return totPayment;
        }

        //function that calculates monthly payments     
        private double CalculateMonthlyPayment(double pAmount, int noOfPayment, double interestRate) {
            double monthlyPayment;
            double intRate = (interestRate / 100) / 12;
            monthlyPayment = (pAmount * (Math.Pow((1 + intRate), noOfPayment)) * intRate / (Math.Pow((1 + intRate), noOfPayment) - 1));
            return Convert.ToDouble(monthlyPayment);
        }


        #region VB (Microsoft)
    //    Sub TestPPMT()
    //Dim PVal, APR, TotPmts, Payment, Period, P, I As Double
    //Dim PayType As DueDate
    //Dim Msg As String
    //Dim Response As MsgBoxResult

    //' Define money format.
    //Dim Fmt As String = "###,###,##0.00"
    //' Usually 0 for a loan.
    //Dim Fval As Double = 0
    //PVal = CDbl(InputBox("How much do you want to borrow?"))
    //APR = CDbl(InputBox("What is the annual percentage rate of your loan?"))
    //' Ensure proper form.
    //If APR > 1 Then APR = APR / 100
    //TotPmts = CDbl(InputBox("How many monthly payments do you have to make?"))
    //Response = MsgBox("Do you make payments at the end of month?", MsgBoxStyle.YesNo)
    //If Response = MsgBoxResult.No Then
    //    PayType = DueDate.BegOfPeriod
    //Else
    //    PayType = DueDate.EndOfPeriod
    //End If
    //Payment = Math.Abs(-Pmt(APR / 12, TotPmts, PVal, FVal, PayType))
    //Msg = "Your monthly payment is " & Format(Payment, Fmt) & ". "
    //Msg = Msg & "Would you like a breakdown of your principal and "
    //Msg = Msg & "interest per period?"
    //' See if chart is desired. 
    //Response = MsgBox(Msg, MsgBoxStyle.YesNo)
    //If Response<> MsgBoxResult.No Then
    //    If TotPmts > 12 Then MsgBox("Only first year will be shown.")
    //    Msg = "Month  Payment  Principal  Interest" & vbNewLine
    //    For Period = 1 To TotPmts
    //        ' Show only first 12.
    //        If Period > 12 Then Exit For
    //        P = PPmt(APR / 12, Period, TotPmts, -PVal, FVal, PayType)
    //        ' Round principal.
    //        P = (Int((P + 0.005) * 100) / 100)
    //        I = Payment - P
    //        ' Round interest.
    //        I = (Int((I + 0.005) * 100) / 100)
    //        Msg = Msg & Period & vbTab & Format(Payment, Fmt)
    //        Msg = Msg & vbTab & Format(P, Fmt) & vbTab & Format(I, Fmt) & vbNewLine
    //    Next Period
    //    ' Display amortization table.
    //    MsgBox(Msg)
    //End If
        #endregion (VB (Microsoft))

        #region C++ Amortization

        //29
        //        while (ending_balance > 0.0) {
        //30
        //            new_balance = ending_balance;  
        //31

        //32
        //            // Calculate interest by multiplying rate against balance
        //33
        //            interest_paid = new_balance* (annual_rate / 12.0);
        //34

        //35
        //            // Subtract interest from your payment
        //36
        //            principle_paid = payment - interest_paid;
        //37

        //38
        //            // Subtract final payment from running balance
        //39
        //            ending_balance = new_balance - principle_paid;
        //40

        //41
        //            // If the balance remaining plus its interest is less than payment amount
        //42
        //            // Then print out 0 balance, the interest paid and that balance minus the interest will tell us
        //43
        //            // how much principle you paid to get to zero.
        //44

        //45
        //            if ((new_balance + interest_paid) < payment) {
        //46
        //                System.out.println(count + ". Payment: " + f.format(new_balance + interest_paid) + " Interest: " + f.format(interest_paid) + " Principle: " + f.format(new_balance - interest_paid) + " Loan Balance is: $0.00");
        //47
        //            }
        //48
        //            else {
        //49
        //                // Lets show the table, loan, interest, and payment made towards principle
        //50
        //                System.out.println(count + ". Payment: " + f.format(payment) + " Interest: " + f.format(interest_paid) + " Principle: " + f.format(principle_paid) + " Loan Balance is: " + f.format(ending_balance));
        //51
        //            }
        //52
        //            count++;
        //53
        //        }

        #endregion (C++)


        #region Properties
        public double TaxesPerYear { get; set; } = 0.00;
        public double InsurancePerYear { get; set; } = 0.00;

        #endregion (Properties)

    }
}
