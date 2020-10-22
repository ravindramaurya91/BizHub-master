using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BizHub.Components.TransitionPlanner
{
    public partial class CmpTransitionPlannerMenu
    {
        #region (Properties)

        #region Parameters
        [Parameter] public EventCallback<int> MenuItemSelected { get; set; }
        [Parameter] public long ActiveMenu { get; set; }
        #endregion (Parameters)

        #endregion (Properties)
    }
}
