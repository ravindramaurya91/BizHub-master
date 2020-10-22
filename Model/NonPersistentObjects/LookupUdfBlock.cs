using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class LookupUdfBlock {

        #region Fields
        private LookupDefinition _lookupDefinition;
        private Lookup _lookup;
        private string _udf1Label = "";
        private string _udf2Label = "";
        private string _udf3Label = "";
        private string _udf4Label = "";
        private string _udf1Value = "";
        private string _udf2Value = "";
        private string _udf3Value = "";
        private string _udf4Value = "";
        #endregion (Fields)

        #region Methods
        private void On_LookupDefinitionChanged() {
            _udf1Label = _lookupDefinition.UDF1;
            _udf1Value = "";

            _udf2Label = _lookupDefinition.UDF2;
            _udf2Value = "";

            _udf3Label = _lookupDefinition.UDF3;
            _udf3Value = "";

            _udf4Label = _lookupDefinition.UDF4;
            _udf4Value = "";
        }
        private void On_LookupChanged() {
            _udf1Value = (!String.IsNullOrEmpty(_lookup.UDF1)) ? _lookup.UDF1 : "";
            _udf2Value = (!String.IsNullOrEmpty(_lookup.UDF2)) ? _lookup.UDF2 : "";
            _udf3Value = (!String.IsNullOrEmpty(_lookup.UDF3)) ? _lookup.UDF3 : "";
            _udf4Value = (!String.IsNullOrEmpty(_lookup.UDF4)) ? _lookup.UDF4 : "";
        }
        #endregion (Methods)

        #region Properties
        public LookupDefinition LookupDefinition {
            get { return _lookupDefinition; }
            set {
                if(LookupDefinition != value) {
                    _lookupDefinition = value;
                    On_LookupDefinitionChanged();
                }
            }
        }
        public Lookup Lookup  {
            get { return _lookup ; }
            set {
                if (_lookup != value) {
                    _lookup = value;
                    On_LookupChanged();
                }
            }
        }
        public string UDF1Label {
            get { return _udf1Label; }
            set {
                _udf1Label = value;
                _lookupDefinition.UDF1 = value;
            }
        }
        public string UDF2Label {
            get { return _udf2Label; }
            set {
                _udf2Label = value;
                _lookupDefinition.UDF2 = value;
            }
        }
        public string UDF3Label {
            get { return _udf3Label; }
            set {
                _udf3Label = value;
                _lookupDefinition.UDF3 = value;
            }
        }
        public string UDF4Label {
            get { return _udf4Label; }
            set {
                _udf4Label = value;
                _lookupDefinition.UDF4 = value;
            }
        }
        public string UDF1Value {
            get { return _udf1Value; }
            set {
                _udf1Value = value;
                _lookup.UDF1 = value;
            }
        }
        public string UDF2Value {
            get { return _udf2Value; }
            set {
                _udf2Value = value;
                _lookup.UDF2 = value;
            }
        }
        public string UDF3Value {
            get { return _udf3Value; }
            set {
                _udf3Value = value;
                _lookup.UDF3 = value;
            }
        }
        public string UDF4Value {
            get { return _udf4Value; }
            set {
                _udf4Value = value;
                _lookup.UDF4 = value;
            }
        }
        #endregion (Properties)

    }
}
