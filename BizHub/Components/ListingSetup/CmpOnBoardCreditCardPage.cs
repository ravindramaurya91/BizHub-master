using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BizHub.Components.ListingSetup
{
    public partial class CmpOnBoardCreditCardPage
    {
        #region Constructor
        protected override void OnInitialized()
        {

        }
        #endregion (Constructor)

        #region Methods

       

        #endregion

        #region Properties
        #region Parameters
        [Parameter] public PagOnboardController Controller { get; set; }
        [Parameter] public EventCallback<int> MenuItemSelected { get; set; }
        [Parameter] public long ActiveMenu { get; set; }

        #endregion (Parameters)

        #endregion (Properties)
    }
}
