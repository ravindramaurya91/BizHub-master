using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub {
    public class PagAccountSetupController : BasePageController{

        #region Fields
        private CmpOrganizationsController _organizationController ;
        #endregion (Fields)


        #region Constructor
        public PagAccountSetupController() {
            _organizationController = new CmpOrganizationsController(this);
        }
        #endregion (Constructor)


        #region Properties
        public CmpOrganizationsController CmpOrganizationsController { get => _organizationController;  }
        #endregion (Properties 

    }
}
