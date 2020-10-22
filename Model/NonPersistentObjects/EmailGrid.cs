using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class ParentEmailObj {
        #region Properties
        public string Category { get; set; }
        public string Description { get; set; }
        public int NumberOfDocsIncluded { get; set; }
        public List<ChildEmailObj> Templates { get; set; } = new List<ChildEmailObj>();
        #endregion (Properties)
    }

    public class ChildEmailObj {
        #region Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PercentDelivered { get; set; }
        public decimal PercentOpened { get; set; }
        public int NumberOfAttachments { get; set; }
        public DateTime DateAdded { get; set; }
        #endregion (Properties)
    }
}
