using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.FSLibrary.RadioButtons {
    public partial class FSRadioButton : IFSVisualComponent {

        #region Fields

        #endregion (Fields)

        #region Constructor

        #endregion (Constructor)

        protected override void OnInitialized() {
            if(Items.Count > 0) {
                Item = Items[0];
            } else {
                Item = new FSVisualItem();
            }
            if (string.IsNullOrEmpty(Item.CustomCSS)) {
                Item.CustomCSS = "e-primary";
            }
            if (IsSmall) {
                Item.CustomCSS += " e-small ";
            }
        }

        public virtual void On_Select(string tsValue) {
            OnSelect.InvokeAsync(tsValue);
        }

        #region Methods
        public Syncfusion.Blazor.Buttons.LabelPosition GetLabelPosition() {
            if (IsLabelRightOfButton) {
                return Syncfusion.Blazor.Buttons.LabelPosition.After;
            } else {
                return Syncfusion.Blazor.Buttons.LabelPosition.Before;
            }
        }
        #endregion (Methods)

        #region Properties
        public FSVisualItem Item { get; set; }

        [Parameter]
        public string BoundValue { get; set; }

        [Parameter]
        public List<FSVisualItem> Items { get; set; }

        [Parameter]
        public EventCallback<string> OnSelect { get; set; }

        [Parameter]
        public bool IsSmall { get; set; } = true;

        [Parameter]
        public bool IsLabelRightOfButton { get; set; } = true;

        public Syncfusion.Blazor.Buttons.LabelPosition LabelPositionString { get => GetLabelPosition(); }
        #endregion (Properties)

    }
}
