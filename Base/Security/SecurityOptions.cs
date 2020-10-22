using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Security
{
    public class SecurityOptions
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public int JwtExpireHours { get; set; }
    }
}
