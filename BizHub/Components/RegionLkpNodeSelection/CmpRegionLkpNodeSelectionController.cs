using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub {
	public class CmpRegionLkpNodeSelectionController : BasePageController {

		#region Events
		#endregion (Events)

		#region Fields
		private List<Int64> _selectedCountyOids = new List<Int64>();
		private LookupNode _selectedCountryNode;
		private LookupNode _selectedStateNode;
		private List<LookupNode> _selectedCountyNodes = new List<LookupNode>();
		private List<LookupNode> _selectedCityNodes = new List<LookupNode>();
		private bool _isStatesShow = true;
		private bool _isCountiesShow = false;
		#endregion (Fields)

		#region Constructor
		public CmpRegionLkpNodeSelectionController() {
		}

		public CmpRegionLkpNodeSelectionController(string tsCountryConstant) {
			SelectedCountryNode = GetLookupNodeByCountry(tsCountryConstant);
		}
		#endregion (Constructor)

		#region Methods
		#region On_Change Events
		public void On_CountryChanged() {
			SelectedStateNode = null;
		}

		public void On_StateChanged() {
			SelectedCountyOids.Clear();
		}
		#endregion (On_Change Events)

		public LookupNode GetLookupNodeByCountry(string tsCountry) {
			LookupNode oReturn = null;
			LookupNode oNode = LookupManager.Instance.GetLookupNodeByConstant(tsCountry);
			if (oNode != null) {
				oReturn = oNode;
			}
			return oReturn;
		}

		public List<LookupNode> GetAvailableChildren(LookupNode toNode) {
			List<LookupNode> oReturn = new List<LookupNode>();
			if (toNode != null) {
				// TODO the following three lines are a workaround for a cast for List<IHierarchy> to List<LookupNode>
				foreach (IHierarchy oChild in toNode.Children) {
					oReturn.Add((LookupNode)oChild);
				}
				oReturn.Sort(LookupNode.SortByName); //= toNode.Children.OrderBy(o => o.Name).ToList();
			}
			return oReturn;
		}
		#endregion (Methods)

		#region Properties
		public List<LookupNode> AvailableStates { get => GetAvailableChildren(SelectedCountryNode); }
		public List<LookupNode> AvailableCounties { get => GetAvailableChildren(SelectedStateNode); }
		public List<Int64> SelectedCountyOids { get => _selectedCountyOids; set => _selectedCountyOids = value; }

		public LookupNode SelectedCountryNode {
			get { return _selectedCountryNode; }
			set { _selectedCountryNode = value;
				On_CountryChanged();
			}
		}

		public LookupNode SelectedStateNode {
			get { return _selectedStateNode; }
			set { _selectedStateNode = value;
				On_StateChanged();
			}
		}
		#endregion (Properties)
	}
}
