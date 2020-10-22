using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Components.Admin {
    public partial class CmpAdminMenu {

        #region (Properties)

        #region Parameters
        [Parameter] public EventCallback<int> MenuItemSelected { get; set; }
        [Parameter] public long ActiveMenu { get; set; }
        #endregion (Parameters)

        #endregion (Properties)
    }
}
