using System;

namespace Model {
    public interface ICWSession {
        Int64 EntityOid { get; set; }
        string DisplayName { get; set; }
        string Email { get; set; }
    }

    public class CWSAuthSession: ICWSession{
        public Int64 EntityOid { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
