using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BizHub.Components.LoanCalculation
{
    public partial class CmpLoanMenu
    {
        #region Properties

        #region Parameters
        [Parameter] public PagLoanCalculatorController Controller { get; set; }
        [Parameter] public EventCallback<int> MenuItemSelected { get; set; }
        [Parameter] public long ActiveMenu { get; set; }
        #endregion (Parameters)
        #endregion (Properties)
    }
}
