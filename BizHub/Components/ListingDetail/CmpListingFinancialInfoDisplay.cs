using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Components.ListingDetail {
    public partial class CmpListingFinancialInfoDisplay {

        #region Constructor
        protected override void OnInitialized() {
            EvaluateEnum();
        }
        #endregion (Constructor)


        #region Methods
        public void EvaluateEnum() {
            if (Enum != null) {
                //TODO : Once BizHubUserObject has an lkpUserType on it, use the below commented code.
                //if (Enum == 1 || (Enum == 2 && SessionMgr.Instance.User.lkpEntityTypeOid != Constants.ENTITY_TYPE_INDIVIDUAL)) {
                if (Enum == 1) {
                    IsShowData = true;
                } else {
                    IsShowData = false;
                }
            } else { IsShowData = false; }
        }
        #endregion (Methods)


        #region Properties
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public string Value { get; set; }
        [Parameter]
        public string ValuePrecursor { get; set; }
        [Parameter]
        public string ToolTip { get; set; }
        [Parameter]
        public int? Enum { get; set; }
        public bool IsShowData { get; set; }

        #endregion (Properties)

    }
}
