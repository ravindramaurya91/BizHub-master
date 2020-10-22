using PetaPoco;

namespace Model {
    public partial class EmailTemplate : IMailer{

        public EmailTemplate() {
            IsActive = true;
        }

        public string GetLkpCategoryValue() {
            if(LkpTemplateCategoryOid != null) {
                return LookupManager.Instance.GetLookupByOid((long)LkpTemplateCategoryOid).Value;
            } else {
                return "Unknown";
            }
        }

        [Ignore]
        public string LkpCategoryValue { get => GetLkpCategoryValue(); }
    }
}
