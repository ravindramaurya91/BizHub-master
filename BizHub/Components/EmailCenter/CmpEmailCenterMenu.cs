using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BizHub.Components.EmailCenter {
    public partial class CmpEmailCenterMenu {

        #region Properties

        #region Parameters
        [Parameter] public PagEmailCenterController Controller { get; set; }
        [Parameter] public EventCallback<int> MenuItemSelected { get; set; }
        [Parameter] public long ActiveMenu { get; set; }
        #endregion (Parameters)
        #endregion (Properties)

    }
}
