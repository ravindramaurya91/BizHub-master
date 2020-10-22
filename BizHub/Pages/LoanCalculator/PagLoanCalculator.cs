using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

using CommonUtil;

namespace BizHub.Pages.LoanCalculator {
    public partial class PagLoanCalculator {

        #region Fields
        private PagLoanCalculatorController _controller = new PagLoanCalculatorController();
        private LoanCalcRequest _loanCalcRequest = new LoanCalcRequest();
        #endregion (Fields)

        #region Constructor
        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                if (CurrentMenu <= 0 || CurrentMenu == null) {
                    SelectMenuItem(1);
                }
            }
        }
        #endregion (Constructor)
        private bool OkToCalculate() {
            // Put the validation of the _loanCalcRequest object here.  
            // If we have all the necessary pieces to perform a calculation return True.
            // Otherwise, pop a dialog box that tells the User what is missing.
            return true;
        }
        #region Properties
        public PagLoanCalculatorController Controller { get => _controller; }
        public LoanCalcRequest LoanCalcRequest { get => _loanCalcRequest; set => _loanCalcRequest = value; }
        #endregion (Properties)

        #region Methods
        public void SelectMenuItem(int menuNumber) {
            //FSPageTools.Instance.NavManager.NavigateTo("/Loan-Calculator/" + menuNumber);
            Controller.NavigateTo("/Loan-Calculator/" + menuNumber);
        }
        #endregion(Methods)

        #region Properties New
        [Parameter]
        public long CurrentMenu { get; set; }
        #endregion(Properties)

    }
}
