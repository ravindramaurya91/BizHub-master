using System;
using System.Collections.Generic;
using System.Text;

using Base;

namespace Model {
    public class NameValuePair: IModel {

        #region Fields
        private bool _deleteMe = false;
        private bool _isActive = false;
        private List<NameValuePair> _children = new List<NameValuePair>();
        #endregion (Fields)

        #region Constructor
        #endregion (Constructor)

        #region Methods
        
        #region AddTag
        public static  void AddTagToList(string tsName, decimal? tdValue, List<NameValuePair> toList)
        {
            if (tdValue != null)
            {
                AddTagToList(tsName, ((decimal)tdValue).ToString(), toList);
            }
        }
        
        public static  void AddTagToList(string tsName, bool? tdValue, List<NameValuePair> toList)
        {
            if ((tdValue != null) && ((bool)tdValue) )
            {
                AddTagToList(tsName, "", toList);
            }
        }
        
        public static void AddTagToList(string tsName, string tsValue, List<NameValuePair> toList)
        {
            toList.Add(new NameValuePair() {Name = tsName, Value = tsValue});
        }
        #endregion(AddTag)
        
        public static NameValuePair GetNameValuePairFromListByOid(Int64 tiEA_Oid, List<NameValuePair> toList) {
            NameValuePair oReturn = null;
            foreach (NameValuePair pair in toList) {
                if (pair.Oid == tiEA_Oid) {
                    oReturn = pair;
                    break;
                }
            }

            return oReturn;
        }
        #endregion (Methods)

        #region Properties
        public Int64 Oid { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool DeleteMe { get => _deleteMe; set => _deleteMe = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public List<NameValuePair> Children { get => _children; set => _children = value; }
        #endregion (Properties)


    }
}
