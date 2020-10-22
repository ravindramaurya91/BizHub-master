using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.FSLibrary.Dropdowns {
    public partial class FSSelect : IFSVisualComponent {

        private string _boundValue = "";

        protected override void OnInitialized() {
            if (string.IsNullOrEmpty(BoundValue)) {
                if (Items.Count > 0) {
                    BoundValue = Items[0].Value;
                }
            }
        }

        public virtual void On_Select(string tsValue) {
            OnSelect.InvokeAsync(tsValue);
        }

        [Parameter]
        public string BoundValue {
            get { return _boundValue; }
            set {
                if (value != null && !_boundValue.Equals(value)) {
                    _boundValue = value;
                    On_Select(BoundValue);
                }
            }
        }

        [Parameter]
        public List<FSVisualItem> Items { get; set; }

        [Parameter]
        public EventCallback<string> OnSelect { get; set; }

        [Parameter]
        public string PlaceHolder { get; set; } = "Select One";

    }
}