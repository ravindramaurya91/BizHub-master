using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil {
    public class ResultSetCache : IResultSetCache {

        #region Fields
        private static volatile ResultSetCache _instance = null;
        private static object _syncRoot = new Object(); //for multi thread protection
        private int _resultId = 0;
        private int _itemsPerPage = 20;
        private Dictionary<int, ResultSet> _cache = new Dictionary<int, ResultSet>();
        #endregion (Fields)

        #region Constructor 
        static ResultSetCache() {
        }
        #endregion (Constructor)

        public void On_CacheStartup() {
            // This method is fired on first loading of the PagingCache only
        }

        public ResultSet AddNewResultSet(Int64 tiEntityOid, int tiResultSetType, IList toData) {
            // This method will receive a result set and store it in the cache, then return the _resultsetId which is the key for accessing the result later
            return AddNewResultSet(tiEntityOid, tiResultSetType, toData, _itemsPerPage);
        }

        public ResultSet AddNewResultSet(Int64 tiEntityOid, int tiResultSetType, IList toData, int tiItemsPerPage) {
            // This method will receive a result set and store it in the cache, then return the _resultsetId which is the key for accessing the result later
            if (toData.Count == 0) {
                // There are no results in the query - don't store a ResultSet
                throw new Exception("No Results");
            }
            _resultId++;
            int iKey = _resultId;
            ResultSet oReturn = new ResultSet(tiEntityOid, tiResultSetType, iKey, toData, tiItemsPerPage);
            _cache.Add(iKey, oReturn);
            return oReturn;
        }

        public void RemoveResultSet(int tiResultSetId) {
            if (_cache.ContainsKey(tiResultSetId)) {
                _cache.Remove(tiResultSetId);
            }
        }

        public void SetItemsPerPage(int tiResultSetId, int tiItemsPerPage) {
            ResultSet oWorkingSet = GetResultSetById(tiResultSetId);
            oWorkingSet.ItemsPerPage = tiItemsPerPage;
        }

        public List<object> GetPage(int tiResultSetId, int tiPageNumber, out Int64 tiEntityOid) {
            List<object> oReturn = new List<object>();

            ResultSet oWorkingSet = GetResultSetById(tiResultSetId);
            tiEntityOid = oWorkingSet.EntityOid;

            oWorkingSet.LastAccessed = DateTime.UtcNow;
            tiPageNumber = CWMath.GreaterOf(tiPageNumber, 1);
            tiPageNumber = CWMath.LesserOf(tiPageNumber, oWorkingSet.Pages);
            int iStart = oWorkingSet.ItemsPerPage * (tiPageNumber - 1);
            int iEnd = iStart + CWMath.LesserOf(oWorkingSet.ItemsPerPage, oWorkingSet.Count - iStart);

            for (int i = iStart; i < iEnd; i++) {
                oReturn.Add(oWorkingSet.Data[i]);
            }

            return oReturn;
        }

        private ResultSet GetResultSetById(int tiResultSetId) {
            ResultSet oReturn = null;
            if (_cache.ContainsKey(tiResultSetId)) {
                oReturn = _cache[tiResultSetId];
                oReturn.LastAccessed = DateTime.UtcNow;

            }
            return oReturn;
        }

        #region Properties
        public static ResultSetCache Instance {
            get {
                if (_instance == null) {
                    lock (_syncRoot) {
                        _instance = new ResultSetCache();
                        _instance.On_CacheStartup();
                    }
                }
                return _instance;
            }
        }
        public int ItemsPerPage {
            get { return _itemsPerPage; }
            set { _itemsPerPage = value; }
        }
        #endregion (Properties)
    }
}
