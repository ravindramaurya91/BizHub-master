using System;
using System.Collections;
using System.Collections.Generic;

namespace CommonUtil {
    public interface IResultSetCache {
        int ItemsPerPage { get; set; }

        ResultSet AddNewResultSet(long tiEntityOid, int tiResultSetType, IList toData);
        ResultSet AddNewResultSet(long tiEntityOid, int tiResultSetType, IList toData, int tiItemsPerPage);
        List<object> GetPage(int tiResultSetId, int tiPageNumber, out Int64 tiEntityOid);
        void On_CacheStartup();
        void RemoveResultSet(int tiResultSetId);
        void SetItemsPerPage(int tiResultSetId, int tiItemsPerPage);
    }
}