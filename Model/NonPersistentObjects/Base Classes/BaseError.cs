using System.Runtime.Serialization;

namespace Model {
    [DataContract]
    public class BaseError {
        public BaseError() { }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 1)]
        public string ErrorCode { get; set; }
        [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
        public string FieldName { get; set; }
        [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 3)]
        public string Message { get; set; }
    }
}