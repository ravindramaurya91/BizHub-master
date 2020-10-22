using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public interface IFSUser {
        string Country { get; set; }
        string DisplayName { get; set; }
        long EntityOid { get; set; }
        long EntityOid_Master { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Zip { get; set; }
        //string UserName { get; set; }
        //string Email { get; set; }
    }
}
