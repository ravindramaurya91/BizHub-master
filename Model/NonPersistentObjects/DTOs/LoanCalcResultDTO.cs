using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using CommonUtil;

namespace Model {
    public class LoanCalcResultDTO {


        #region Fields
        private List<FSPieChartModel> _pieCharts = new List<FSPieChartModel>();
        private LoanCalcResult _loanResult = new LoanCalcResult();
        #endregion (Fields)


        #region Methods
        #region PieChart 
        public void CreatePieChartSetupData() {
            PieChartSetup = new List<FSPieChartModel>();
            FSPieChartModel oPieChartModel;
            PieChartCalc oPieChart = new PieChartCalc();
            double TotalAmount = LoanResult.LoanAmount + LoanResult.TotalInterestPaid + LoanResult.Fees;
            oPieChart.Principal = Math.Round(((LoanResult.LoanAmount * 100) / TotalAmount), 2);
            oPieChart.Interest = Math.Round(((LoanResult.TotalInterestPaid * 100) / TotalAmount), 2);
            oPieChart.FeesAndCharges = Math.Round((((LoanResult.Fees + LoanResult.PointsDollars) * 100) / TotalAmount), 2);
            Type type = typeof(PieChartCalc);
            int NumberOfRecords = type.GetProperties().Length;
            foreach (PropertyInfo propertyInfo in oPieChart.GetType().GetProperties()) {
                oPieChartModel = new FSPieChartModel();

                oPieChartModel.Name = propertyInfo.Name;
                oPieChartModel.Percentage = Convert.ToDouble(propertyInfo.GetValue(oPieChart)).ToString() + "%";
                if (oPieChartModel.Name.Contains("Principal")) {
                    oPieChartModel.Color = "#00cc00";
                    oPieChartModel.Total = Math.Round(TotalAmount, 2);
                } else if (oPieChartModel.Name.Contains("Interest")) {
                    oPieChartModel.Color = "#ff6600";
                    oPieChartModel.Total = Math.Round(LoanResult.TotalInterestPaid, 2);
                } else {
                    oPieChartModel.Color = "#cc0000";
                    if (LoanResult.Fees > 0 || LoanResult.PointsDollars > 0) {
                        oPieChartModel.Total = Math.Round((LoanResult.Fees + LoanResult.PointsDollars), 2);
                    }
                }
                PieChartSetup.Add(oPieChartModel);
            }
            LoanResult.DisplayMonthlyPayment = String.Format("{0:n}", LoanResult.MonthlyPayment);
            LoanResult.DisplayTotalPaid = String.Format("{0:n}", LoanResult.TotalPaid);
            LoanResult.DisplayTotalInterestPaid = String.Format("{0:n}", LoanResult.TotalInterestPaid);
        }
        #endregion
        #endregion (Methods)


        #region Properties
        public LoanCalcResult LoanResult { get => _loanResult; set => _loanResult = value; }
        public List<FSPieChartModel> PieChartSetup { get => _pieCharts; set => _pieCharts = value; }
        #endregion (Properties)

    }
}
