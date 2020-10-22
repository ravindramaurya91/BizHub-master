using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BizHub.Components.OnBoard
{
    public partial class CmpFooterButtonComponent
    {
        #region Properties
        [Parameter] public PagOnboardController Controller { get; set; }
        [Parameter] public string RadioButtonSelection { get; set; }
        [Parameter] public int ActivePage { get; set; }

        [Parameter]
        public EventCallback<bool> SaveAndExit { get; set; }
        [Parameter]
        public EventCallback<int> BackClick { get; set; }
        #endregion
    }
}
