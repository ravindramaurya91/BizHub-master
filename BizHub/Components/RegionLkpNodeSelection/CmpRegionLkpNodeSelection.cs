using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Model;
using Syncfusion.Blazor.DropDowns;

namespace BizHub.Components.RegionLkpNodeSelection {
    public partial class CmpRegionLkpNodeSelection {

        #region Fields
        private CmpRegionLkpNodeSelectionController _regionNodeController;
        #endregion (Fields)

        #region Methods
        public void StateSelected(string tsOid) {
            LookupNode oNode = ModelUtil.GetFromListByOid<LookupNode>(Convert.ToInt32(tsOid), RegionNodeController.AvailableStates);
            SelectedStateNode = oNode;
            StateHasChanged();
        }

        private void OnMultiSelectChange(MultiSelectChangeEventArgs<List<Int64>> args) {
            if (args.Value == null) {
                SelectedCountyOids = new List<Int64>();
            } else {
                SelectedCountyOids = args.Value;
            }
            StateHasChanged();
        }

        public List<FSVisualItem> GetStatesAsFSItems() {
            List<FSVisualItem> rList = new List<FSVisualItem>();
            foreach (LookupNode oNode in RegionNodeController.AvailableStates) {
                rList.Add(new FSVisualItem() { Label = oNode.Value, Value = oNode.Oid.ToString() });
            }
            return rList;
        }

        public List<NameValuePair> GetAvailableCountiesAsNameValuePair() {
            List<NameValuePair> rList = new List<NameValuePair>();
            foreach (LookupNode oNode in SelectedStateNode.Children) {
                rList.Add(new NameValuePair() { Name = oNode.Value, Oid = oNode.Oid });
            }
            return rList;
        }

        public void SearchByStateOrCounty() {
            eRunBrokerSearch.InvokeAsync(true);
        }
        #endregion (Methods)

        #region Properties
        [Parameter]
        public CmpRegionLkpNodeSelectionController RegionNodeController { get => _regionNodeController; set => _regionNodeController = value; }
        [Parameter]
        public EventCallback<bool> eRunBrokerSearch { get; set; }

        public LookupNode SelectedStateNode { get => RegionNodeController.SelectedStateNode; set => RegionNodeController.SelectedStateNode = value; }

        public List<Int64> SelectedCountyOids { get => RegionNodeController.SelectedCountyOids; set => RegionNodeController.SelectedCountyOids = value; }

        public List<FSVisualItem> StatesAsFSItems { get => GetStatesAsFSItems(); }
        public List<NameValuePair> AvailableCounties { get => GetAvailableCountiesAsNameValuePair(); }
        #endregion (Properties)
    }
}
