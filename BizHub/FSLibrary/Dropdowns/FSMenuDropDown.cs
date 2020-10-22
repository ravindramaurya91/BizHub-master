using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;
using Syncfusion.Blazor.Navigations;

namespace BizHub.FSLibrary.Dropdowns {
    public partial class FSMenuDropDown : IFSVisualComponent {

        protected override void OnInitialized() {
            ConvertFSItemsToSyncMenuItems();
        }

        public void ConvertFSItemsToSyncMenuItems() {

        }

        public virtual void On_Select(string tsValue) {
            OnSelect.InvokeAsync(tsValue);
        }

        [Parameter]
        public string BoundValue {
            get { return BoundValue; }
            set {
                if (!BoundValue.Equals(value)) {
                    BoundValue = value;
                    On_Select(BoundValue);
                }
            }
        }

        public List<MenuItem> MenuItems { get; set; }

        [Parameter]
        public List<FSVisualItem> Items { get; set; }

        [Parameter]
        public EventCallback<string> OnSelect { get; set; }

    }
}
