using SqlKata;
using System;
using System.Collections.Generic;
using System.Text;

using PetaPoco;

namespace Model {
    class BrokerCardDTO_Receiver : BrokerCardDTO {


        #region Methods
        public static List<BrokerCardDTO> Rollup(List<BrokerCardDTO_Receiver> toRcvrs) {
            List<BrokerCardDTO> oReturnList = new List<BrokerCardDTO>();
            BrokerCardDTO oCurrentBrokerCardDTO = null;
            NameValuePair oCurrentNameValuePair = null;

            foreach (BrokerCardDTO_Receiver oRcvr in toRcvrs) {
                oCurrentBrokerCardDTO = ModelUtil.GetFromListByOid<BrokerCardDTO>(oRcvr.Oid, oReturnList);
                if (oCurrentBrokerCardDTO == null) {
                    oCurrentBrokerCardDTO = CreateBrokerCardDTO(oRcvr);
                    oReturnList.Add(oCurrentBrokerCardDTO);
                }
                // Rollup ContactRequest Dates Contacted
                if((oRcvr.cr_Oid > 0 ) && ((oCurrentNameValuePair == null) || (oRcvr.cr_Oid != oCurrentNameValuePair.Oid))) {
                    //We are on a new contact for the first time. 
                    oCurrentNameValuePair = ModelUtil.GetFromListByOid<NameValuePair>(oRcvr.cr_Oid, oCurrentBrokerCardDTO.DatesContacted);
                    if (oCurrentNameValuePair == null) {
                        oCurrentNameValuePair = new NameValuePair() { Oid = oRcvr.cr_Oid, IsActive = true, Name = "Last Contacted", Value = oRcvr.cr_ContactDate.ToShortDateString() };
                        oCurrentBrokerCardDTO.DatesContacted.Add(oCurrentNameValuePair);
                    }
                }

            }
            return oReturnList;
        }

        //public static List<BrokerCardDTO> Rollup(List<BrokerCardDTO_Receiver> toRcvrs) {
        //    List<BrokerCardDTO> oReturnList = new List<BrokerCardDTO>();
        //    BrokerCardDTO oCurrentDTO = null;

        //    foreach (BrokerCardDTO_Receiver oRcvr in toRcvrs) {
        //        oCurrentDTO = ModelUtil.GetFromListByOid<BrokerCardDTO>(oRcvr.Oid, oReturnList);
        //        if(oCurrentDTO == null) {
        //            BrokerCardDTO oDTO = CreateBrokerCardDTO(oRcvr);

        //            // Rollup ContactRequest Dates Contacted
        //            oDTO.DatesContacted = CreateBrokerCardDatesSelectedFromList(toRcvrs, oDTO.EntityOid);

        //            oReturnList.Add(oDTO);
        //        }
        //    }
        //    return oReturnList;
        //}

        //private static List<NameValuePair> CreateBrokerCardDatesSelectedFromList(List<BrokerCardDTO_Receiver> toRcvrs, Int64 tiBrokerOid)
        //{
        //    List<NameValuePair> oReturnList = new List<NameValuePair>();
        //    NameValuePair oCurrentDate = null;

        //    foreach (BrokerCardDTO_Receiver oRcvr in toRcvrs) {
        //        if(oRcvr.cr_EntityOid_ContactTo == tiBrokerOid) {
        //            oCurrentDate = ModelUtil.GetFromListByOid<NameValuePair>(oRcvr.cr_Oid, oReturnList);
        //            if (oCurrentDate == null) {
        //                oCurrentDate = new NameValuePair() {
        //                    Oid = oRcvr.cr_Oid, Value = oRcvr.cr_ContactDate.ToShortDateString()
        //                };
        //                oReturnList.Add(oCurrentDate);
        //            }
        //        }
        //    }

        //    return oReturnList;
        //}

        private static BrokerCardDTO CreateBrokerCardDTO(BrokerCardDTO_Receiver toReceiver)
        {
            BrokerCardDTO oReturn = new BrokerCardDTO()
            {
                TagLine = toReceiver.TagLine, Footer = toReceiver.Footer, Body = toReceiver.Body,
                Avatar = toReceiver.e_Avatar, DisplayName = toReceiver.e_DisplayName, Email = toReceiver.e_Email,
                City = toReceiver.e_City, State = toReceiver.e_State,
                CompanyName = toReceiver.eCompany_CompanyName, Oid = toReceiver.Oid, EntityOid = toReceiver.EntityOid,
                IsElite = toReceiver.IsElite, AreasServed = toReceiver.e_AreasServed, LicensedIn = toReceiver.e_LicensedIn
            };
            return oReturn;
        }

        #endregion (Methods)


        #region Properties
        //Entity Properties
        [Column("e_DisplayName")]
        public string e_DisplayName { get; set; }

        [Column("e_Email")]
        public string e_Email { get; set; }

        [Column("e_Avatar")]
        public string e_Avatar { get; set; }

        [Column("e_LicensedIn")]
        public string e_LicensedIn { get; set; }

        [Column("e_AreasServed")]
        public string e_AreasServed { get; set; }

        //Company Properties

        [Column("eCompany_CompanyName")]
        public string eCompany_CompanyName { get; set; }
        
        [Column("e_State")]
        public string e_State { get; set; }
        
        [Column("e_City")]
        public string e_City { get; set; }

        //Contact Request Properties
        
        [Column("cr_ContactDate")]
        public DateTime cr_ContactDate { get; set; }
        
        [Column("cr_EntityOid_ContactFrom")]
        public Int64 cr_EntityOid_ContactFrom { get; set; }
        
        [Column("cr_EntityOid_ContactTo")]
        public Int64 cr_EntityOid_ContactTo { get; set; }
        
        [Column("cr_Oid")]
        public Int64 cr_Oid { get; set; }


        #endregion (Properties)

    }
}
