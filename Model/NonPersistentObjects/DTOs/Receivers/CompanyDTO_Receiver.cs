using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model {
    public class CompanyDTO_Receiver : CompanyDTO {

        #region Methods

        public static List<CompanyDTO> Rollup(List<CompanyDTO_Receiver> toRcvrs) {
            List<CompanyDTO> oReturnList = new List<CompanyDTO>();
            CompanyDTO oCurrentCompany = null;
            Entity oCurrentRegion = null;
            Entity oCurrentOffice = null;
            Entity oCurrentAgent = null;


            foreach (CompanyDTO_Receiver oRcvr in toRcvrs) {
                oCurrentCompany = ModelUtil.GetFromListByOid<CompanyDTO>((Int64)oRcvr.Oid, oReturnList);
                if (oCurrentCompany == null) {
                    oCurrentCompany = CreateCompanyFromReceiver(oRcvr);
                    oReturnList.Add(oCurrentCompany);
                }
                if (oRcvr.Region_Oid > 0) {
                    oCurrentRegion = ModelUtil.GetFromListByOid<Entity>((Int64)oRcvr.Region_Oid, oCurrentCompany.Regions);
                    if (oCurrentRegion == null) {
                        oCurrentRegion = CreateRegionFromReceiver(oRcvr);
                        oCurrentCompany.Regions.Add(oCurrentRegion);
                    }
                }
                if (oRcvr.Office_Oid > 0) {
                    oCurrentOffice = ModelUtil.GetFromListByOid<Entity>((Int64)oRcvr.Office_Oid, oCurrentCompany.Offices);
                    if (oCurrentOffice == null) {
                        oCurrentOffice = CreateRegionFromReceiver(oRcvr);
                        oCurrentCompany.Offices.Add(oCurrentOffice);
                    }
                }
                if (oRcvr.Agent_Oid > 0) {
                    oCurrentAgent = ModelUtil.GetFromListByOid<Entity>((Int64)oRcvr.Agent_Oid, oCurrentCompany.Agents);
                    if (oCurrentAgent == null) {
                        oCurrentAgent = CreateRegionFromReceiver(oRcvr);
                        oCurrentCompany.Agents.Add(oCurrentAgent);
                    }
                }
            }

            return oReturnList;
        }

        private static CompanyDTO CreateCompanyFromReceiver(CompanyDTO_Receiver toReceiver) {
            CompanyDTO oReturn = new CompanyDTO() {
                Oid = toReceiver.Oid, EntityOid_Master = toReceiver.EntityOid_Master, EntityOid_Office = toReceiver.EntityOid_Office, AreasServed = toReceiver.AreasServed, lkpStateOids_Servicing = toReceiver.lkpStateOids_Servicing,
                lkpUserTypeOid = toReceiver.lkpUserTypeOid, NumberOfEmployees = toReceiver.NumberOfEmployees, CompanyName = toReceiver.CompanyName, Country = toReceiver.Country, CreatedBy = toReceiver.CreatedBy,
                CreatedOn = toReceiver.CreatedOn, HasMultipleOffices = toReceiver.HasMultipleOffices, HasMultipleRegions = toReceiver.HasMultipleRegions
            };
            return oReturn;
        }

        private static Entity CreateRegionFromReceiver(CompanyDTO_Receiver toReceiver) {
            Entity oReturn = new Entity() {
                Oid = toReceiver.Region_Oid, EntityOid_Master = toReceiver.Oid, DisplayName = toReceiver.Region_DisplayName
            };
            return oReturn;
        }

        private static Entity CreateOfficeFromReceiver(CompanyDTO_Receiver toReceiver) {
            Entity oReturn = new Entity() {
                Oid = toReceiver.Office_Oid, EntityOid_Master = toReceiver.Oid, EntityOid_Region = toReceiver.Region_Oid, DisplayName = toReceiver.Office_DisplayName, Address1 = toReceiver.Office_Address1, Address2 = toReceiver.Office_Address2,
                Zip = toReceiver.Office_Zip, NumberOfEmployees = toReceiver.Office_NumberOfEmployees, Phone = toReceiver.Office_Phone
            };
            return oReturn;
        }

        private static Entity CreateAgentFromReceiver(CompanyDTO_Receiver toReceiver) {
            Entity oReturn = new Entity() {
                Oid = toReceiver.Agent_Oid, EntityOid_Master = toReceiver.Oid, EntityOid_Region = toReceiver.Region_Oid, EntityOid_Office = toReceiver.EntityOid_Office, FirstName = toReceiver.Agent_FirstName, LastName = toReceiver.Agent_LastName,
                Email = toReceiver.Agent_Email, lkpUserTypeOid = toReceiver.Agent_lkpUserTypeOid
            };
            return oReturn;
        }

        #endregion (Methods)


        #region Properties
        //Region Attributes
        [Column("Region_Oid")]
        public Int64 Region_Oid { get; set; }
        [Column("Region_DisplayName")]
        public string Region_DisplayName { get; set; }

        //Office Attributes
        [Column("Office_Oid")]
        public Int64 Office_Oid { get; set; }
        [Column("Region_DisplayName")]
        public string Office_DisplayName { get; set; }
        [Column("Office_Address1")]
        public string Office_Address1 { get; set; }
        [Column("Office_Address2")]
        public string Office_Address2 { get; set; }
        [Column("Office_Zip")]
        public string Office_Zip { get; set; }
        [Column("Office_NumberOfEmployees")]
        public int Office_NumberOfEmployees { get; set; }
        [Column("Office_Phone")]
        public string Office_Phone { get; set; }

        //Agent Attributes
        [Column("Agent_Oid")]
        public Int64 Agent_Oid { get; set; }
        [Column("Agent_FirstName")]
        public string Agent_FirstName { get; set; }
        [Column("Agent_LastName")]
        public string Agent_LastName { get; set; }
        [Column("Agent_Email")]
        public string Agent_Email { get; set; }
        [Column("Agent_lkpUserTypeOid")]
        public Int64 Agent_lkpUserTypeOid { get; set; }

        #endregion (Properties)
    }
}
