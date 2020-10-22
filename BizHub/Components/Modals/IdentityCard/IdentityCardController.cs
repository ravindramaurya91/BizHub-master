using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub {
    public class IdentityCardController : BasePageController {

        #region Fields
        private IdentityCardDTO _identityCardDTO;
        private bool _isLoggedInUser = false;
        #endregion (Fields)


        #region Methods
       public bool IsIdentityCardTheLoggedInUser() {
            Int64 iLoggedInUserOid = SessionMgr.Instance.User.EntityOid;
            return (iLoggedInUserOid == _identityCardDTO.Oid);
       }


        public void GetEntityCardDTOByOid(Int64 tiEntityOid) {
            if (tiEntityOid != null || tiEntityOid != 0) {
                _identityCardDTO = SQL.GetIdentityCardDTOByEntityOid(tiEntityOid, true);
            }
        }

        #endregion (Methods)


        #region Properties
        public IdentityCardDTO IdentityCardDTO { get => _identityCardDTO; set => _identityCardDTO = value; }
        public bool IsLoggedInUser { get => IsIdentityCardTheLoggedInUser(); }
        public Int64 EntityOid {
            set {
                GetEntityCardDTOByOid(value);
            }
        }
        #endregion (Properties)




    }
}
