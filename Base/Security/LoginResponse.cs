using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Security
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
    }
}
