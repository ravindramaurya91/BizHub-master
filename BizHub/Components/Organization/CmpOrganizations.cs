using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.Components.Organization {
    public partial class CmpOrganizations {


        public CmpOrganizations() {
            LoadOrganization();
        }

        private void LoadOrganization() {
            Int64 iEntityOid_Master = SessionMgr.Instance.User.EntityOid_Master;
            Organization = SQL.GetOrganizationFromEntityOid_Master(iEntityOid_Master);
        }
        #region Properties
        [Parameter] public PagAccountSetupController PageController { get; set; }
        [Parameter] public CmpOrganizationsController Controller { get; set; }

        public OrganizationDTO Organization { get; set;}
        #endregion (Properties)
    }
}