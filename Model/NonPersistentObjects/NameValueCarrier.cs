using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class NameValueCarrier {
        #region Fields
        private List<NameValuePair> _items = new List<NameValuePair>();
        #endregion (Fields)

        #region Constructor
        #endregion (Constructor)

        #region Methods
        public List<NameValuePair> GetSelected() {
            List<NameValuePair> oReturn = new List<NameValuePair>();
            foreach(NameValuePair oItem in Items) {
                if (oItem.IsActive) { oReturn.Add(oItem); }
            }
            return oReturn;
        }
        #endregion (Methods)

        #region Properties
        public List<NameValuePair> Items { get => _items; set => _items = value; }
        #endregion (Properties)
    }
}
