using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public partial class Lookup : IValue{

        #region CreateLookup 
        public static Lookup CreateLookup(string tsLookupName, string tsValue) {
            return CreateLookup(tsLookupName, tsValue, tsValue);
        }

        public static Lookup CreateLookup(string tsLookupName, string tsValue, string tsDescription) {
            Lookup oNewLookup = new Lookup() {
                LookupName = tsLookupName, ConstantValue = tsLookupName.ToUpper().Replace(" ", "") + "->" + tsValue.ToUpper(), Value = tsValue, IsActive = true,
                UDF1 = "", UDF2 = "", UDF3 = "", UDF4 = "", Description = tsDescription + " - " + tsValue, SortOrder = 1
            };

            oNewLookup.Save();
            LookupManager.Instance.LookupValuesHaveBeenUpdated = true;
            return oNewLookup;
        }
        #endregion (CreateLookup)

        #region Cascading Delete
        public override void CascadingDelete() {
            List<Lookup> oChildren = Lookup.Fetch("WHERE ParentOid = @0", this.Oid);
            foreach (Lookup oLookup in oChildren) {
                oLookup.CascadingDelete();
            }
            Delete();
        }
        #endregion (Cascading Delete)

        #region Properties
        [Ignore] public bool IsModified { get; set; } = false;
        #endregion (Properties)

    }
}
