using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public partial class EmailRecipientDefinition {



        #region Methods
        public static EmailRecipientDefinition CreateDefinitionFromSearchCriteria(SearchCriteria toCriteria) {
            EmailRecipientDefinition oDefinition = new EmailRecipientDefinition();
            oDefinition.IsActive = true;
            //TODO: Remove the below hard coding with a lookupmanager lookup
            oDefinition.lkpRecipientListTypeOid = 39158;
            oDefinition.SearchCriteriaOid = toCriteria.Oid;
            oDefinition.Name = toCriteria.Name;
            oDefinition.Save();

            return oDefinition;
        }
        #endregion (Methods)

    }
}
