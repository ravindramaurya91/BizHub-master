using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Areas.Identity {
    public class BizHubRole : IdentityRole{

        public BizHubRole() :base() { }
        public BizHubRole(string tsRoleName) : base(tsRoleName) { }
    }
}
