using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace BizHub {
    public class CmpBrokerCardController : BasePageController {

        public void Initialize(BrokerCardDTO toDTO) {
            IsBrokerLoggedInUser = (toDTO.EntityOid == _loggedInUser.EntityOid);
        }

        #region Properties
        public bool IsBrokerLoggedInUser { get; set; }
        #endregion (Properties)
    }
}
