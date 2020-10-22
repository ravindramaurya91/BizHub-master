using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;
namespace BizHub.Components.OnBoard.DynamicPages
{
    public partial class CmpOnBoard_CompanyRegions
    {
        #region Methods
        //public void SetOfficeCount(int count)
        //{
        //    Controller.SetRegionCount(count);
        //}
        
        #endregion (Methods)
        #region Properties
        [Parameter] public PagOnboardController Controller { get; set; }
        [Parameter]
        public RegionDTO RegionDTO { get; set; }
        #endregion (Properties)
    }
}
