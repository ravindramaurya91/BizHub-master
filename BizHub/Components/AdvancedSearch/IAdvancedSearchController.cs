using Model;
using System;
using System.Collections.Generic;

namespace BizHub {
    public interface IAdvancedSearchController {
        SearchCriteriaDisplay SearchCriteriaDisplay { get; set; }
        List<DisplayTag> SearchTags { get; set; }
        //List<LookupNode> SelectedBusinessCategoryNodes { get; set; }
        event EventHandler OnSearchDisplayChanged;
        void CreateDefaultSearchCriteria();
        void LoadSearchCriteriaDisplayByOid(long tiSearchCriteriaOid);
        void RemoveTag(DisplayTag toTag) {

        }
    }
}