using System;
using System.Collections.Generic;
using System.Text;

using Model;
using CommonUtil;

namespace BizSearch {
    public class QueryResponse : BaseResponse{
        #region Fields
        private List<object> _data = new List<object>();
        #endregion (Fields)

        ~QueryResponse() {
            ResultSetCache_SearchListing.Instance.RemoveResultSet(ResultSetId);
        }
        public List<object> GetNext() {
            List<object> oReturn = new List<object>();
            if (PageNumber >= PageCount) {
                throw new Exception("End of File reached");
            } else { 
                Int64 iEntityOid = EntityOid;
                PageNumber++;
                Data = ResultSetCache_SearchListing.Instance.GetPage(ResultSetId, PageNumber, out iEntityOid);
            }
            return oReturn;
        }

        #region Properties
        public List<object> Data { get => _data; set=> _data = value; }
        public string QueryDescription { get; set; }
        public Int64 EntityOid { get; set; }
        public int ResultSetId { get; set; }
        public int PageCount { get; set; }
        public int ItemCount { get; set; }
        public int PageNumber { get; set; }
        #endregion (Properties)

    }
}
