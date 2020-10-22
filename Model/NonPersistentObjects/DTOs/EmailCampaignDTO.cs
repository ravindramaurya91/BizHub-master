using System;
using PetaPoco;

namespace Model {
    public class EmailCampaignDTO : EmailCampaign {

        #region Methods
        public void Save() {
            EmailCampaign oCampaign;
            if(this.Oid != null && this.Oid > 0) {
                oCampaign = EmailCampaign.First("Where Oid = @0", this.Oid);
                oCampaign.IsActive = this.IsActive;
            } else {
                oCampaign = new EmailCampaign();
                oCampaign.EntityOid = SessionMgr.Instance.User.EntityOid;
                oCampaign.EntityOid_Master = SessionMgr.Instance.User.EntityOid_Master;
                oCampaign.CreatedOn = DateTime.UtcNow;
                oCampaign.CreatedBy = oCampaign.EntityOid;
                oCampaign.IsActive = true;
            }
            oCampaign.EmailTemplateOid = this.EmailTemplateOid;
            oCampaign.EmailRecipientDefinitionOid = this.EmailRecipientDefinitionOid;
            oCampaign.Name = this.Name;
            oCampaign.Description = this.Description;

            oCampaign.Save();
            this.Oid = oCampaign.Oid;
        }
        #endregion (Methods)

        #region Properties
        [Column("TemplateName")]
        public string TemplateName { get; set; }
        [Column("RecipientDefinitionName")]
        public string RecipientDefinitionName { get; set; }
        [Column("SearchCriteriaOid")]
        public Int64 SearchCriteriaOid { get; set; }
        #endregion (Properties)

    }
}
