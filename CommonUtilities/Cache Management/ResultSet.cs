using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CommonUtil {
    public class ResultSet {

        #region Fields
        private Int64 _entityOid;
        #endregion (Fields)

        public ResultSet(Int64 tiEntityOid, int tiResultSetType, int tiKey, IList toData, int tiItemsPerPage) {
            _entityOid = tiEntityOid;
            Id = tiKey;
            Data = toData;
            ResultSetType = tiResultSetType;
            ItemsPerPage = tiItemsPerPage;
            CreatedOn = DateTime.UtcNow;
            LastAccessed = CreatedOn;
        }


        #region Properties
        public Int64 EntityOid { get => _entityOid; }
        public int ResultSetType { get; set; }
        public int Id { get; set; }
        public int ItemsPerPage { get; set; }
        public int PageNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastAccessed { get; set; }
        public IList Data { get; set; }
        public int Count { get { return Data.Count; } }
        public int Pages {
            get {
                return Convert.ToInt32(CWMath.Ceiling(Data.Count / (ItemsPerPage * 1.00)));
            }
        }
        #endregion (Properties)


    }
}
