using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Base.Security;
using Model;

namespace BizHub.Pages {
    public partial class PagLogin {
        public string LoginName;
        public string Password;
        public string Failed = "";

        protected void On_Login() {
            LoginRequest oRequest = new LoginRequest() { ApplicationName = "BizHub", LoginName = LoginName, Password = Password };
        }
    }
}
