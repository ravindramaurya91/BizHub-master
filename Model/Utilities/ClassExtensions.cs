using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public static class ClassExtensions {
        public static List<Int64> GetOids(this List<LookupNode> toList) {

            List<Int64> oReturn = new List<long>();
            foreach (LookupNode oNode in toList) {
                oReturn.Add(oNode.Oid);
            }
            return oReturn;
        }

        public static T NewCopy<T>(this object objSource) where T : new() {
            T oReturn = new T();
            foreach (var p in typeof(T).GetProperties()) {
                // Get the value of the property
                if ((!p.PropertyType.Name.Equals("Object")) && (!p.Name.Equals("Oid"))) {
                    var v = p.GetValue(objSource, null);
                    ((IIndexer)oReturn).Set(p.Name, v);
                }
            }
            return oReturn;
        }
    }
    //public delegate void Del(string message);
    //public void Add<T>() where T : A, new() {
    //    aList.Add(new T());
    //}

}

