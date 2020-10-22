using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class DualListAssignor {
        #region Fields
        private List<ValuePair> _list1 = new List<ValuePair>(); 
        private List<ValuePair> _list2 = new List<ValuePair>();
        #endregion (Fields)

        public static List<ValuePair> GetCheckedItems(List<ValuePair> toList) {
            List<ValuePair> oReturn = new List<ValuePair>();

            foreach(ValuePair oItem in toList) {
                if(oItem.IsChecked) {
                    oReturn.Add(oItem);
                }
            }

            return oReturn;
        }
        #region Properties
        public string Name { get; set; }
        public string TargetContext { get; set; }
        public Int64 TargetOid { get; set; }
        public List<ValuePair> List1 { get => _list1; set => _list1 = value; }
        public List<ValuePair> List2 { get => _list2; set => _list2 = value; }
        #endregion (Properties)

    }
}