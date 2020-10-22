using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Forms {
    public class FormResource {

        #region Properties
        public Int64 EntityOid_Master_Brokerage { get; set; }
        public string BrokerageLogo { get; set; }
        public string BrokerageName { get; set; }
        #endregion (Properties)

    }
    public class ParagraphInfo
    {
        public string Paragraph { get; set; }
        public int PageNumber { get; set; }
    }
}
