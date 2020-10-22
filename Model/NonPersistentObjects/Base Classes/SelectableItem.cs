using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class SelectableItem {

        #region Fields
        private bool _isSelected = false;

        #endregion (Fields)


        #region Methods
        protected virtual void On_SelectedValueChanged() {

        }
        #endregion(Methods)

        #region Properties 
        public string DisplayName { get; set; }
        public bool IsSelected {
            get {
                return _isSelected;
            }
            set {
                if (_isSelected != value) {
                     _isSelected = value;
                    On_SelectedValueChanged();
                } 
            }
        }
        #endregion (Properties)
    }
}
