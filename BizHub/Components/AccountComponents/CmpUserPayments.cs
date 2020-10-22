using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Components.AccountComponents
{
    partial class CmpUserPayments
    {
        public bool isShowChargeHistory { get; set; }
        public void ShowHideChargeHistory()
        {
            if (isShowChargeHistory)
                isShowChargeHistory = false;
            else
                isShowChargeHistory = true;
        }
    }
}
