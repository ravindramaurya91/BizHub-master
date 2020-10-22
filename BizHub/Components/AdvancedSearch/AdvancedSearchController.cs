using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace BizHub {
    public class AdvancedSearchController : BasePageController, IAdvancedSearchController {
        #region Events
        public event EventHandler OnSearchDisplayChanged;
        //public event EventHandler OnSearchCriteriaPropertyChanged;
        #endregion (Events)

        #region Fields
        private SearchCriteriaDisplay _searchCriteriaDisplay;
        private List<LookupNode> _selectedBusinessCategoryNodes;
        private bool _isInitialized = false;
        #endregion (Fields)

        #region Constructor
        public AdvancedSearchController() {
            SearchCriteriaDisplay = new SearchCriteriaDisplay();
            Initialize();
        }

        public AdvancedSearchController(SearchCriteriaDisplay toSearchCriteriaDisplay) {
            SearchCriteriaDisplay = toSearchCriteriaDisplay;
            Initialize();
        }

        private void Initialize() {
            SearchCriteriaDisplay.OnSearchCriteriaPropertyChanged += SearchCriteriaDisplay_OnSearchCriteriaPropertyChanged;
            _isInitialized = true;
        }

        #endregion (Constructor)

        #region Methods

        #region Events
        private void SearchCriteriaDisplay_OnSearchCriteriaPropertyChanged(object sender, SearchCriteriaChangedEventArgs e) {
            // A Property in the SearchCriteria has changed - the List of Tags will have been updated prior to this call.
            //OnSearchCriteriaPropertyChanged?.Invoke(SearchCriteriaDisplay, null);
        }
        #endregion (Events)

        public void LoadSearchCriteriaDisplayByOid(Int64 tiSearchCriteriaOid) {
            try {
                SearchCriteriaDisplay = SQL.GetSearchCriteriaDisplayByOid(tiSearchCriteriaOid, true);
            } catch {
                CreateDefaultSearchCriteria();
            }
        }

        public void OnSearchRadiusChanged(string tsSearchRadius) {
            if (!string.IsNullOrEmpty(tsSearchRadius)) {
                if (!Double.IsNaN(Convert.ToInt32(tsSearchRadius))) {
                    SearchCriteriaDisplay.SearchRadius = Convert.ToInt32(tsSearchRadius);
                }
            }
        }

        public void CreateDefaultSearchCriteria() {
            // Need to think about hopw we want to create a default for a buyer that is not registered
            SearchCriteriaDisplay oDisplay = new SearchCriteriaDisplay();
            oDisplay.lkpStateOid = LookupManager.Instance.GetOidByConstantValue("STATE->CALIFORNIA");
            SearchCriteriaDisplay = oDisplay;
        }

        public void RemoveTag(DisplayTag toTag) {
            SearchCriteriaDisplay.RemoveSearchTagFromList(toTag);
        }

        public void AddBusinessCategoryNodeToList(LookupNode toNode) {
            if ((toNode != null) && (!SelectedBusinessCategoryNodes.Contains(toNode))) {
                SelectedBusinessCategoryNodes.Add(toNode);
                //On_BusinessCategoryListChanged();
            }
        }

        private LookupNode GetLookupNodesByBusinessCategory(string tsBusinessCategory) {
            LookupNode oReturn = null;
            LookupNode oNode = LookupManager.Instance.GetLookupNodeByConstant(tsBusinessCategory);
            if (oNode != null) {
                oReturn = oNode;
            }

            return oReturn;
        }

        #endregion (Methods)

        #region Properties
        public List<LookupNode> SelectedBusinessCategoryNodes { get => _selectedBusinessCategoryNodes; set => _selectedBusinessCategoryNodes = value; }
        public SearchCriteriaDisplay SearchCriteriaDisplay {
            get { return _searchCriteriaDisplay; }
            set {
                if (_searchCriteriaDisplay != value) {
                    _searchCriteriaDisplay = value;
                }
            }
        }
        public List<DisplayTag> SearchTags { get => _searchCriteriaDisplay.SearchTags; set => _searchCriteriaDisplay.SearchTags = value; }
        #endregion (Properties)

    }
}
