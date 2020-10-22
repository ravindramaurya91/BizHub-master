using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Interfaces.Sydney {
    public class SydneyUser {

        #region Properties
        public string createDate { get; set; }
        public string emailAddress { get; set; }
        public string firstName { get; set; }
        public string GroupInfo { get; set; }
        public string lastLogin { get; set; }
        public string lastName { get; set; }
        public object lastUpdated { get; set; }
        public string status { get; set; }
        public object updatedBy { get; set; }
        public string userAlias { get; set; }
        public string username { get; set; }
        #endregion (Properties)

    }
}
