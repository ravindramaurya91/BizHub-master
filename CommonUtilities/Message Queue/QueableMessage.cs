using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil {
    [Serializable]
    public class QueableMessage {

        #region Constructor
        public QueableMessage() { }
        public QueableMessage(int tiMsgType, object toData) { MessageType = tiMsgType; Data = toData; }
        public QueableMessage(int tiMsgType, object toData, string tsTargetTable, Int64 tiTargetOid) { MessageType = tiMsgType; Data = toData; TargetTable = tsTargetTable; TargetOid = tiTargetOid; }
        #endregion (Constructor)

        #region Methods
        public async Task<string> ToJsonAsync() {
            return await Task.Run(() => JsonConvert.SerializeObject(this));
        }
        public string ToJson() {
            return JsonConvert.SerializeObject(this);
        }
        #endregion (Methods)

        #region Properties
        public int MessageType { get; set; }
        public string TargetTable { get; set; }
        public Int64 TargetOid { get; set; }
        public object Data { get; set; }
        #endregion (Properties)

    }
}
