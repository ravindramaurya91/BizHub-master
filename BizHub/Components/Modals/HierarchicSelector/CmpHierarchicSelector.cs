using System;
using System.Collections.Generic;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.Components.Modals.HierarchicSelector {
    public partial class CmpHierarchicSelector {

        [CascadingParameter] 
        BlazoredModalInstance BlazoredModal { get; set; }

        #region Fields
        private List<IHierarchy> _items = new List<IHierarchy>();
        #endregion(Fields)

        #region Constructor
        protected override void OnInitialized() {
            Items = ListManager.GetAllItems();
            GenerateDisplayListFromSelectedItems();
        }
        #endregion(Constructor)

        #region Methods
        public void RemoveTagSelected(DisplayTag toTag) {
            foreach (IHierarchy Item in Items) {
                if (Item.Oid == toTag.TagId) {
                    Item.IsSelected = false;
                    ListManager.RemoveItem(Item.Oid);
                    RemoveItemFromDisplayList(Item);
                }
            }
        }

        public void ToggleExpandedView(IHierarchy oItem) {
            if (oItem.IsExpanded) {
                oItem.IsExpanded = false;
            } else {
                oItem.IsExpanded = true;
            }
        }

        public void onCheckSelected(ChangeEventArgs te, IHierarchy toHierarchy) {
            if ((bool)te.Value == true) {
                toHierarchy.IsSelected = true;
                ListManager.AddItem(toHierarchy.Oid);
            } else {
                toHierarchy.IsSelected = false;
                ListManager.RemoveItem(toHierarchy.Oid);
                RemoveItemFromDisplayList(toHierarchy);
            }
        }

        public void SaveChanges()
        {
            BlazoredModal.Close(ModalResult.Ok(ListManager.SelectedItems));
        }

        public void GenerateDisplayListFromSelectedItems() {
            foreach (IHierarchy item in ListManager.SelectedItems) {
                DisplayItems.Add(new DisplayTag() { TagId = item.Oid, Name = item.Name, Value = item.Value });
            }
        }

        public void AddItemToDisplayList(IHierarchy item) {
            DisplayItems.Add(new DisplayTag() { TagId = item.Oid, Name = item.Name, Value = item.Value });
        }

        public void RemoveItemFromDisplayList(IHierarchy toObj) {
            DisplayTag oTag = DisplayItems.Find(i => i.TagId == toObj.Oid);
            DisplayItems.Remove(oTag);
        }

        public void SelectAll() {

        }
        #endregion(Methods)

        #region Properties
        [Parameter]
        public IHierarchyListManager ListManager { get;  set; }
        [Parameter]
        public string SelectionTitle { get; set; } = "";
        [Parameter]
        public string ModalHeader { get; set; } = "";
        [Parameter]
        public string ModalSubHeader { get; set; }
        [Parameter]
        public bool IsShowParentCheckBox { get; set; } = true;
        [Parameter]
        public bool IsShowSelectAll { get; set; } = false;

        public List<IHierarchy> Items { get => _items; set => _items = value; }
        public List<DisplayTag> DisplayItems { get; set; } = new List<DisplayTag>();
        public bool IsAllSelected { get; set; } = false;
        #endregion(Properties)
    }
}