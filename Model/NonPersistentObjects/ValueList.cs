using System;
using System.Collections.Generic;
using System.Text;

using PetaPoco;

namespace Model {
    public class ValuePair {

        #region Fields
        private bool _isActive = false;
        private bool _isChecked = false;
        private bool _isPending = false;
        private decimal _percentage = decimal.Zero;

        #endregion (Fields)

        #region Properties
        [Column("Oid")]
        public Int64 Oid { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("IsActive")]
        public bool IsActive { get { return _isActive; } set { _isActive = value; } }
        public bool IsChecked { get { return _isChecked; } set { _isChecked = value; } }
        [Column("IsPending")]
        public bool IsPending { get { return _isPending; } set { _isPending = value; } }
        [Column("Percentage")]
        public decimal Percentage { get { return _percentage; } set { _percentage = value; } }
        #endregion (Properties)
    }
}
