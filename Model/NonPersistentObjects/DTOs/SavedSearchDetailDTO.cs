using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    
    public class SavedSearchDetailDTO {
        
        #region Fields
        private SearchCriteria _searchCriteria = new SearchCriteria();

        #endregion(Fields)
        
        #region Constructor
        #endregion(Constructor)
        
        #region Methods
        #endregion(Methods)
        
        #region Properties
        
        public SearchCriteria SearchCriteria { get => _searchCriteria; set => _searchCriteria = value; }
        public Int64 NumberOfNewMatchesSinceLastView { get; set; }
        
        #endregion(Properties)
    }
}
