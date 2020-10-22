using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class EntityIdCard {
        #region Methods
        public string GetFullName() {
            return FirstName + " " + LastName;
        }
        public string GetLastFirst() {
            string s = LastName;
            if (!String.IsNullOrEmpty(s)) {
                s += ", ";
            }
            s += FirstName;
            return s;
        }
        #endregion (Methods)

        #region Properties
        public Int64 Oid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal PercentageAllocated { get; set; }
        public string FullName {
            get { return GetFullName(); }
        }
        public string LastFirst {
            get { return GetLastFirst(); }
        }
        //TODO KEATEN: Expand the EntityIdCard to what i believe it should hold.
        public string PrimaryPhoneNumber { get; set; }
        public Int64 lkpEntityTypeOid { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
        // Limit Query to just Data in the EntityIdCard.
        #endregion (Properties)
    }
}
