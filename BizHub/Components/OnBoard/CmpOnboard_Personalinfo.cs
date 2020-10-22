using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BizHub.Components.OnBoard
{
    public partial class CmpOnboard_Personalinfo
    {
        #region Properties
        [Parameter] public PagOnboardController Controller { get; set; }
        [Parameter] public bool IsSubmitted { get; set; }
        #endregion
    }
}
