using ExcelDataReader.Log;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Text;

using Base;

namespace Model {
    public interface IName {
        string Name { get;  }
    }

    public interface IValue : IModel {
        string Value { get; }
    }
    public interface IDeleteMe {
        bool DeleteMe { get; set; }
    }
    

    public class ModelUtil {
        public static T GetFromListByOid<T>(Int64 tiOid, List<T> toList) where T : IModel {
            T oReturn = default(T);
            foreach (T oRecord in toList) {
                if (oRecord.Oid == tiOid) {
                    oReturn = oRecord;
                    break;
                }
            }
            return oReturn;
        }

        public static void FindAndReplaceInList<T>(List<T> toList, T toItemToRemove, T toItemToInsert) {
            int index = toList.IndexOf(toItemToRemove);
            toList.RemoveAt(index);
            toList.Insert(index, toItemToInsert);
        }

        public static void FindAndReplaceInListByOid<T>(Int64 tiOid, List<T> toList, T toItemToInsert) where T : IModel {
            T oItemToRemove = toList.Find(x => x.Oid == tiOid);
            int index = toList.IndexOf(oItemToRemove);
            toList.RemoveAt(index);
            toList.Insert(index, toItemToInsert);
        }

        public static T GetFromListByName<T>(string tsName, List<T> toList) where T : IName {
            T oReturn = default(T);
            tsName = tsName.ToUpper();
            foreach (T oRecord in toList) {
                if (oRecord.Name.ToUpper().Equals(tsName)) {
                    oReturn = oRecord;
                    break;
                }
            }
            return oReturn;
        }
        public static void MarkItemsForDeletion<T>(List<T> toList) where T : IDeleteMe {
            foreach (T oRecord in toList) {
                oRecord.DeleteMe = true;
            }
        }
        
        public static string IModelToOidDelimitedString(List<IHierarchy> toList) { 
            string sDelimiter = ", ";
            StringBuilder sb = new StringBuilder();

            foreach (var oItem in toList) {
                sb.Append(sDelimiter + oItem.Oid.ToString());
            }

            string sReturn = sb.ToString();
            if (sReturn.Length > 2) {
                sReturn = sReturn.Substring(2);
            }
            return sReturn;
        }
        
        public static void RemoveItemsMarkedForDeletion<T>(List<T> toList) where T : IDeleteMe {
            List<int> oIndexList = new List<int>();
            for(int i = 0; i < toList.Count; i++) {
                if (toList[i].DeleteMe) {
                    oIndexList.Add(i);
                }
            }
            for (int i = oIndexList.Count -1; i >= 0; i--) {
                toList.RemoveAt(i);
            }
        }

        public static void ToggleE2LMapIsFavorite(Int64 tiMapOid) {
            Entity2ListingMap_Stat oMap = SQL.GetEntity2ListingMap_StatByOid(tiMapOid);
            oMap.IsFavorite = !oMap.IsFavorite;
            oMap.Save();
        }

        public static void ToggleE2LMapIsFavorite(Int64 tiEntityOid, Int64 tiListingOid) {
            Entity2ListingMap_Stat oMap = SQL.GetEntity2ListingMap_StatByEntityOidAndListingOid(tiEntityOid, tiListingOid);
            oMap.IsFavorite = !oMap.IsFavorite;
            oMap.Save();
        }
    }
}





