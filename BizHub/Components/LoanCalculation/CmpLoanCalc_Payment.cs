using System;
using CommonUtil;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.LoanCalculation {
    public partial class CmpLoanCalc_Payment {

        private bool _isCalculating = false;

        #region Constructor
        protected override void OnInitialized() {
            LoanCalcRequest = new LoanCalcRequest();
            ResultDTO = new LoanCalcResultDTO();
            IsShowAmortizationGrid = false;
            IsShowLoanResult = false;
            TenureDurationType = Constants.TENURE_DURATION_TYPE_YEAR;
        }
        #endregion (Constructor)

        #region Methods
        public void ToggleShowAmortizationGrid(bool tbValue) {
            IsShowAmortizationGrid = tbValue;
        }

        public void CalculateLoanPayment() {
            IsCalculating = true;
            Controller.CalculateLoanPayment(LoanCalcRequest);
            IsShowLoanResult = true;
            IsCalculating = false;
            StateHasChanged();
        }
        #endregion (Methods)

        #region Properties
        [Parameter] public PagLoanCalculatorController Controller { get; set; }
        public string TenureDurationType { get; set; }

        public LoanCalcRequest LoanCalcRequest { get; set; }
        public LoanCalcResultDTO ResultDTO { get => Controller.ResultDTO; set => Controller.ResultDTO = value; }
        public bool IsShowAmortizationGrid { get; set; }
        public bool IsShowLoanResult { get; set; }

        public bool IsCalculating {
            get { return _isCalculating; }
            set { _isCalculating = value; }
        }

        public FSGridOptions GridOptions { get; set; } = new FSGridOptions {
            IsAllowFiltering = false,
            IsAllowGrouping = false,
            IsAllowSorting = false,
            IsAllowPaging = false
        };
        #endregion (Properties)
    }

}