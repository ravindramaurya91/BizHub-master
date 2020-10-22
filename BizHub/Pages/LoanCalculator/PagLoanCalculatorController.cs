using System;
using System.Collections.Generic;
using Syncfusion.Blazor.Charts;

using CommonUtil;
using Model;

namespace BizHub {
    public class PagLoanCalculatorController : BasePageController, IPieChartController {

        public void CalculateLoanPayment(LoanCalcRequest toRequest) {
            LoanCalcResult oResult = new LoanCalcResult();
            try {
                oResult = toRequest.CalculateLoanSchedule();
            } catch (Exception ex) {
                ShowPopupDialog(ex.Message, "Error");
            }

            if (oResult == null) {
                ResultDTO.LoanResult = new LoanCalcResult();
                ShowPopupDialog("Unable to calculate loan information", "Error");
            } else {
                ResultDTO.LoanResult = oResult;
                ResultDTO.CreatePieChartSetupData();
                ConvertDataIntoPieChartData();
                RefreshPieChart();
            }
        }

        #region Pie Chart
        public void ConvertDataIntoPieChartData() {
            if (ResultDTO.LoanResult != null && ResultDTO.LoanResult != null && ResultDTO.PieChartSetup.Count > 0) {
                ChartData = ResultDTO.PieChartSetup;
            } else {
                ChartData = new List<FSPieChartModel>();
            }
        }

        public void RefreshPieChart() {
            PieChartRef.Refresh();
        }

        public SfAccumulationChart PieChartRef { get; set; }
        public List<FSPieChartModel> ChartData { get; set; }
        #endregion (Pie Chart)

        public LoanCalcResultDTO ResultDTO { get; set; }

    }
}
