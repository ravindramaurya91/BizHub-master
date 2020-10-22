using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Base;
using Model;


namespace Model {

    public class AuthenticationRequest {
        #region Properties
        public string ApplicationName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string ThirdPartyAuthToken { get; set; }
        public string ThirdPartyAuthSource { get; set; }
        #endregion (Properties)
    }

    public class AuthenticationResponse : BaseResponse {
        //public AuthenticationReturnPayload Data { get; set; }
    }

    public class NewAccountRequest : AuthenticationRequest {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 EntityOid_Master { get; set; }

    }
}
