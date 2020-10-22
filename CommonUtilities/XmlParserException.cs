using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtil {
    public class XmlParserException : Exception {

        public XmlParserException(string tsTagName, string tsDataType, string tsValue, Exception innerException) : base("Parse Exception", innerException) {
            TagName = tsTagName;
            DataType = tsDataType;
            Value = tsValue;
        }

        #region Properties
        public string TagName { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        #endregion (Properties)

    }
}
