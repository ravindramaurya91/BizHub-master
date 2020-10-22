using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;
namespace BizHub.Components.OnBoard.DynamicPages
{
    public partial class CmpOnBoard_CompanyOffice
    {
        #region Methods
        //public void SetUserCount()
        //{
        //    OfficeDTO.SetUserCount(1);
        //}
        public void AddUserClick(int OfficeCountNumber, int RegionCountNumber)
        {
            if (RegionCountNumber != -1)
            {
                UserCountNumber = Controller.Regions[RegionCountNumber].Offices[OfficeCountNumber].UserCount++;
                Controller.SetUserCount(Controller.Regions[RegionCountNumber].Offices[OfficeCountNumber].UserCount, OfficeNumber, RegionNumber);
            }
            else
            {
                UserCountNumber = Controller.Offices[OfficeCountNumber].Users.Count + 1;
                Controller.SetUserCount(UserCountNumber, OfficeNumber);
            }

            //Controller.UserCount++;
        }
        #endregion (Methods)

        #region Properties
        [Parameter] public PagOnboardController Controller { get; set; }
        [Parameter]
        public OfficeDTO OfficeDTO { get; set; }

        [Parameter]
        public int RegionNumber { get; set; }

        [Parameter]
        public int OfficeNumber { get; set; }
        [Parameter]
        public int UserCountNumber { get; set; }


        #endregion (Properties)
    }
}
