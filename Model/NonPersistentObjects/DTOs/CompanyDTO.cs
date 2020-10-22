using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class CompanyDTO : Entity {

        #region Methods
        public void Save() {
            Entity oCurrentRegion = null;
            Entity oCurrentOffice = null;
            Entity oCurrentAgent = null;

            Entity oCompany = null;

            // Create/Update the Company Record and Save
            if (this.Oid != null && this.Oid > 0) {
                oCompany = Entity.First("Where Oid = @0", this.Oid);
                oCompany.IsActive = this.IsActive;
            } else {
                oCompany = new Entity();
                oCompany.CompanyName = this.CompanyName;
                oCompany.EntityOid_Master = SessionMgr.Instance.User.EntityOid_Master;
                oCompany.CreatedOn = DateTime.UtcNow;
                oCompany.CreatedBy = SessionMgr.Instance.User.DisplayName;
                oCompany.IsActive = true;
            }
            oCompany.AreasServed = this.AreasServed;
            oCompany.lkpStateOids_Servicing = this.lkpStateOids_Servicing;
            oCompany.lkpUserTypeOid = this.lkpUserTypeOid;
            oCompany.NumberOfEmployees = this.NumberOfEmployees;
            oCompany.Country = this.Country;
            oCompany.HasMultipleOffices = this.HasMultipleOffices;
            oCompany.HasMultipleRegions = this.HasMultipleRegions;

            oCompany.Save();

            this.Oid = oCompany.Oid;
            oCompany.EntityOid_Master = oCompany.Oid;
            oCompany.EntityOid_Office = oCompany.Oid;

            oCompany.Save();

            // Create/Update the Region Information for the Company
            foreach (Entity oRegion in this.Regions) {
                if (oRegion.Oid != null && oRegion.Oid > 0) {
                    oCurrentRegion = Entity.First("Where Oid = @0", oRegion.Oid);
                    oCurrentRegion.IsActive = oCurrentRegion.IsActive;
                } else {
                    oCurrentRegion = new Entity();
                    oCurrentRegion.CompanyName = this.CompanyName;
                    oCurrentRegion.EntityOid_Master = this.Oid;
                    oCurrentRegion.CreatedOn = DateTime.UtcNow;
                    oCurrentRegion.CreatedBy = SessionMgr.Instance.User.DisplayName;
                    oCurrentRegion.IsActive = true;
                }
                oCurrentRegion.AreasServed = this.AreasServed;
                oCurrentRegion.lkpStateOids_Servicing = this.lkpStateOids_Servicing;
                oCurrentRegion.lkpUserTypeOid = this.lkpUserTypeOid;
                oCurrentRegion.NumberOfEmployees = this.NumberOfEmployees;
                oCurrentRegion.Country = this.Country;
                oCurrentRegion.HasMultipleOffices = this.HasMultipleOffices;
                oCurrentRegion.HasMultipleRegions = this.HasMultipleRegions;

                oCurrentRegion.Save();

                if (oCurrentRegion.Oid > 0) {
                    oCurrentRegion.Oid = (Int64)oCurrentRegion.EntityOid_Region;
                }

                oCurrentRegion.Save();
            }

            // Create/Update the Office Information for the Company
            foreach (Entity oOffice in this.Offices) {
                if (oOffice.Oid != null && oOffice.Oid > 0) {
                    oCurrentOffice = Entity.First("Where Oid = @0", oOffice.Oid);
                    oCurrentOffice.IsActive = oCurrentOffice.IsActive;
                } else {
                    oCurrentOffice = new Entity();
                    oCurrentOffice.CompanyName = this.CompanyName;
                    oCurrentOffice.EntityOid_Master = this.Oid;
                    oCurrentOffice.EntityOid_Region = oCurrentRegion.Oid;
                    oCurrentOffice.CreatedOn = DateTime.UtcNow;
                    oCurrentOffice.CreatedBy = SessionMgr.Instance.User.DisplayName;
                    oCurrentOffice.IsActive = true;
                }
                oCurrentOffice.Address1 = this.Address1;
                oCurrentOffice.Address2 = this.Address2;
                oCurrentOffice.Zip = this.Zip;
                oCurrentOffice.NumberOfEmployees = this.NumberOfEmployees;
                oCurrentOffice.Phone = this.Phone;

                oCurrentOffice.Save();

                if (oCurrentOffice.Oid > 0) {
                    oCurrentOffice.Oid = (Int64)oCurrentOffice.EntityOid_Office;
                }

                oCurrentOffice.Save();
            }

            // Create/Update the Agent Information for the Company
            foreach (Entity oAgent in this.Agents) {
                if (oAgent.Oid != null && oAgent.Oid > 0) {
                    oCurrentAgent = Entity.First("Where Oid = @0", oAgent.Oid);
                    oCurrentAgent.IsActive = oCurrentOffice.IsActive;
                } else {
                    oCurrentAgent = new Entity();
                    oCurrentAgent.CompanyName = this.CompanyName;
                    oCurrentAgent.EntityOid_Master = this.Oid;
                    oCurrentAgent.EntityOid_Region = oCurrentRegion.Oid;
                    oCurrentAgent.CreatedOn = DateTime.UtcNow;
                    oCurrentAgent.CreatedBy = SessionMgr.Instance.User.DisplayName;
                    oCurrentAgent.IsActive = true;
                }
                oCurrentAgent.FirstName = this.FirstName;
                oCurrentAgent.LastName = this.LastName;
                oCurrentAgent.Email = this.Email;
                oCurrentAgent.lkpUserTypeOid = this.lkpUserTypeOid;

                oCurrentAgent.Save();

            }

        }

        #endregion (Methods)


        #region Properties
        public List<Entity> Regions { get; set; } = new List<Entity>();
        public List<Entity> Offices { get; set; } = new List<Entity>();
        public List<Entity> Agents { get; set; } = new List<Entity>();
        #endregion (Properties)
    }
}
