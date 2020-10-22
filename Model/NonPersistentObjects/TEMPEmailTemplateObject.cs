using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class TEMPEmailTemplateObject {

        #region Properties
        public Int64 Oid { get; set;}
        public Int64 EntityOid_Master { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TemplateHyperText { get; set; }
        public DateTime DateLastUpdated { get; set; }
        #endregion (Properties)


    }
}
