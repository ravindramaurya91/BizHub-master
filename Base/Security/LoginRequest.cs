using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Security
{
    public class LoginRequest
    {
        public string ApplicationName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string ThirdPartyAuthToken { get; set; }
        public string ThirdPartyAuthSource { get; set; }
    }
}
