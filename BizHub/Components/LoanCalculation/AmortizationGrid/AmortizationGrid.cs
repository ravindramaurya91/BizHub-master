using System;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using System.Collections.Generic;

using Model;
using CommonUtil;

namespace BizHub.Components.LoanCalculation.AmortizationGrid {
    public partial class AmortizationGrid {
        
        #region Fields
        private Int64 _rowCount = 1;
        #endregion(Fields)

        protected override void OnInitialized() {
            if(Result != null && Result.PaymentSchedule != null && Result.PaymentSchedule.Count > 0) {
                GridData = Result.PaymentSchedule;
            } else {
                GridData = new List<LoanPayment>();
            }
            if(GridOptions == null) {
                GridOptions = new FSGridOptions();
            }
        }

        #region Properties
        [Parameter]
        public LoanCalcResult Result { get; set; }

        [Parameter]
        public FSGridOptions GridOptions { get; set; }

        public List<LoanPayment> GridData { get; set; }

        public SfGrid<LoanPayment> Grid { get; set; }

        public Int64 RowCount {get => _rowCount;set => _rowCount = value; }



        #endregion (Properties)

    }
}
