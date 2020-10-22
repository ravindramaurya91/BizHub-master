using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    [Serializable]
    public class LookupNode : Lookup, IHierarchy, IValue {

        #region Fields
        private IHierarchy _parent = null;
        private List<IHierarchy> _children = new List<IHierarchy>();
        #endregion (Fields)

        #region Sort
        public static int SortByName(LookupNode x, LookupNode y) {
            int iReturn = 0;
            if (x == null || x.Name == null) {
                if (y == null || y.Name == null) {
                    iReturn = 0;
                } else {
                    iReturn = 1;
                }
            } else {
                if (y == null || y.Name == null) {
                    iReturn = -1;
                } else {
                    iReturn = x.Name.CompareTo(y.Name);
                }
            }
            return iReturn;
        }
        #endregion (Sort)

        #region Methods
        public static void SetSelectedOnNodeFromOidList(List<IHierarchy> toList, List<Int64> tiOidList) {
            Int64 iCounter = 0;
            foreach(IHierarchy oItem in toList) {
                SetSelectedOnNodeFromOidList(oItem, tiOidList, iCounter);
            }
        }

        public static void SetSelectedOnNodeFromOidList(IHierarchy toItem, List<Int64> tiOidList) {
            Int64 iCounter = 0;
            SetSelectedOnNodeFromOidList(toItem, tiOidList, iCounter);
        }

        private static void SetSelectedOnNodeFromOidList(IHierarchy toItem, List<Int64> tiOidList, Int64 tiCounter) {
            toItem.IsSelected = (tiOidList.Contains(toItem.Oid));
            if (toItem.IsSelected) {
                tiCounter++;
            }
            if(tiOidList.Count > tiCounter) {
                foreach (IHierarchy oChild in toItem.Children) {
                    SetSelectedOnNodeFromOidList(oChild, tiOidList);
                    if(tiOidList.Count <= tiCounter) {
                        break;
                    }
                }
            }
        }

        #endregion (Methods)

        #region Properties
        public string Name { get => Value; set => Value = value; }
        public bool IsSelected { get; set; }
        public IHierarchy Parent { get => _parent; set => _parent = value; }
        public List<IHierarchy> Children { get => _children; set => _children = value; }
        #endregion (Properties)
    }
}
