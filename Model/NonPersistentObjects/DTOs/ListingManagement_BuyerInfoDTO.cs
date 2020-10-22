using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class ListingManagement_BuyerInfoDTO {

        #region Properties
        public Int64 BuyerOid { get; set; }
        public string BuyerName { get; set; }
        public string BuyerInfo { get; set; }
        public string BuyerEmail { get; set; }
        public int BuyerDoc { get; set; }
        public int BuyerChat { get; set; }
        public string BuyerPhone { get; set; }
        public bool NDA { get; set; }
        public bool Profile { get; set; }
        public bool CIM { get; set; }
        public bool WalkThro { get; set; }
        public bool Offer { get; set; }
        public bool Status { get; set; }
        public Int64 AgentOid { get; set; }
        public string AgentName { get; set; }
        public string AgentPhone { get; set; }
        public string AgentInfo { get; set; }
        public string AgentEmail { get; set; }
        public int AgentDoc { get; set; }
        public int AgentChat { get; set; }
        #endregion (Properties)
    }
}
