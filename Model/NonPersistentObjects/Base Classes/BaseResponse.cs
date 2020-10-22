using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
//using NLog;

namespace Model {
    [DataContract]
    public class BaseResponse {

        #region Fields 
        private List<BaseError> _errors = new List<BaseError>();
        private readonly static Logger _log = LogManager.GetCurrentClassLogger();
        private Int64 _entityOid = 0;
        private string _displayName = "";
        private string _email = "";
        private bool _success = true;
        #endregion (Fields )

        #region Constructor
        public BaseResponse() {
        }
        public BaseResponse(ICWSession toSession) {
        //public BaseResponse(Int64 tiEntityOid, string tsDisplayName, string tsEmail) {
            this.EntityOid = toSession.EntityOid;
            this.Email = toSession.Email;
            DisplayName = toSession.DisplayName;
        }
        #endregion (Constructor)

        public void LoadException(Exception ex) {
            Success = false;
            AddError(new BaseError() { ErrorCode = ex.GetType().Name, Message = ex.Message });
            StackTrace = ex.StackTrace;

            _log.Error("\r\nOid: " + this.EntityOid.ToString() + "\r\nName: " + DisplayName + "\r\nEmail: " + Email + "\r\n" + ex);
            _log.Error(ex);
        }

        public void AddError(BaseError toError) {
            Errors.Add(toError);
        }

        #region Properties
        public bool Success { get => _success; set => _success = value; }

        public int ErrorCount {
            get { return _errors.Count; }
        }

        public List<BaseError> Errors {
            get { return _errors; }
            set { _errors = value; }
        }

        public string StackTrace { get; set; }

        public Int64 EntityOid {
            get { return _entityOid; }
            set { _entityOid = value; }
        }

        //[DataMember(Order = 7)]
        public string DisplayName {
            get { return _displayName; }
            set { _displayName = value; }
        }
        //[DataMember(Order = 8)]
        public string Email {
            get { return _email; }
            set { _email = value; }
        }
        public object Data {get; set;}
        #endregion (Properties)
    }
}
