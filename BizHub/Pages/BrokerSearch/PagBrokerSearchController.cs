using System;
using System.Collections.Generic;

using Model;

namespace BizHub {
    public class PagBrokerSearchController : BasePageController {

		#region Fields
		private CmpRegionLkpNodeSelectionController _regionLkpNodeSelectionController;
		private List<BrokerCardDTO> _brokerCards = new List<BrokerCardDTO>();
		private List<BrokerCardDTO> _masterList = new List<BrokerCardDTO>();
		
		private string _brokerName;
		#endregion (Fields)

		#region Constructor

		public PagBrokerSearchController() {
			// TODO: When using multiple countries remove this from being hard coded
			RegionNodeController = new CmpRegionLkpNodeSelectionController("COUNTRY->UNITEDSTATES");
		}

		public void Initialize() {
			if (LoggedInUser.lkpStateOid != null && LoggedInUser.lkpStateOid > 0) {
				RegionNodeController.SelectedStateNode = (LookupNode)ModelUtil.GetFromListByOid<IHierarchy>(LoggedInUser.lkpStateOid, RegionNodeController.SelectedCountryNode.Children);
			} else {
				RegionNodeController.SelectedStateNode = LookupManager.Instance.GetLookupNodeByConstant("STATE->CALIFORNIA");
			}
			if(RegionNodeController.SelectedStateNode == null) {
				List<LookupNode> oList = LookupManager.Instance.GetLookupNodesByLookupName("State");
				if(oList != null && oList.Count > 0) {
					RegionNodeController.SelectedStateNode = oList[0];
				} else {
					RegionNodeController.SelectedStateNode = new LookupNode();
                }
			}
		}
		#endregion (Constructor)

		#region Methods
		public void GetBrokerCards() {
			if(RegionNodeController.SelectedCountyOids.Count > 0) {
				try {
					BrokerCards = SQL.GetBrokerCardsDTOByServiceAreaOids("County", RegionNodeController.SelectedCountyOids);
					_masterList = BrokerCards;
				} catch (Exception ex) {
					// Trow error
				}
			} else if(RegionNodeController.SelectedStateNode != null) {
				try {
					BrokerCards = SQL.GetBrokerCardsDTOByServiceAreaOids("State", new List<Int64>() { RegionNodeController.SelectedStateNode.Oid });
					_masterList = BrokerCards;
				} catch (Exception ex) {
					// Throw error
				}
			} else {
				// throw dialog saying you have to at least select a state
            }
		}

        #region Key Word Search Filter
        public void KeywordSearch(string sSearchWords) {
			List<BrokerCardDTO> oHitList = new List<BrokerCardDTO>();
			foreach(BrokerCardDTO oItem in _masterList) { 
			    if((oItem.CompanyName.Contains(sSearchWords)) ||
				   (oItem.DisplayName.Contains(sSearchWords)) ||
				   (oItem.TagLine.Contains(sSearchWords)) ||
				   (oItem.State.Contains(sSearchWords)) ||
                   (oItem.Body.Contains(sSearchWords))) {
					oHitList.Add(oItem);
                }
			}
			BrokerCards = oHitList;
        }
		public void ClearWordSearch() {
			BrokerCards = _masterList;  
		}
		#endregion (Key Word Search Filter)

		#endregion (Methods)

		#region Properties
		public List<BrokerCardDTO> BrokerCards { get => _brokerCards; set => _brokerCards = value; }
		public CmpRegionLkpNodeSelectionController RegionNodeController { get => _regionLkpNodeSelectionController; set => _regionLkpNodeSelectionController = value; }
		#endregion (Properties)

	}
}
