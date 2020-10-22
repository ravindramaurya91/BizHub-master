using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.FSLibrary.RadioButtons {
    public partial class FSRadioButtons : IFSVisualComponent {

        #region Fields
        #endregion (Fields)

        #region Methods
        protected override void OnInitialized() {
            if (Items.Count > 0) {
                foreach(FSVisualItem Item in Items) {
                    if (string.IsNullOrEmpty(Item.CustomCSS)) {
                        Item.CustomCSS = "e-primary";
                    }
                    if (IsSmall) {
                        Item.CustomCSS += " e-small ";
                    }
                }
            }
        }

        public virtual void On_Select(string tsValue) {
            OnSelect.InvokeAsync(tsValue);
        }

        public Syncfusion.Blazor.Buttons.LabelPosition GetLabelPosition() {
            if (IsLabelRightOfButton) {
                return Syncfusion.Blazor.Buttons.LabelPosition.After;
            } else {
                return Syncfusion.Blazor.Buttons.LabelPosition.Before;
            }
        }

        #endregion (Methods)

        public string GenerateHorizontalSpacingString() {
            if(HorizontalSpacing != null && HorizontalSpacing > 0) {
                return "pr-" + HorizontalSpacing.ToString();
            } else {
                return "";
            }
        }

        public string GenerateVerticalSpacingString() {
            if(VerticalSpacing != null && VerticalSpacing > 0) {
                return "pb-" + VerticalSpacing.ToString();
            } else {
                return "";
            }
        }

        #region Properties
        [Parameter]
        public string BoundValue { get; set; }

        [Parameter]
        public List<FSVisualItem> Items { get; set; }

        [Parameter]
        public EventCallback<string> OnSelect { get; set; }

        [Parameter]
        public bool IsVerticalDisplay { get; set; } = true;

        [Parameter]
        public bool IsSmall { get; set; } = true;

        [Parameter]
        public bool IsLabelRightOfButton { get; set; } = true;

        [Parameter]
        public int VerticalSpacing { get; set; }

        [Parameter]
        public int HorizontalSpacing { get; set; }

        public string AssignHorizontalSpacing { get => GenerateHorizontalSpacingString(); }
        public string AssignVerticalSpacing { get => GenerateVerticalSpacingString(); }

        public Syncfusion.Blazor.Buttons.LabelPosition LabelPositionString { get => GetLabelPosition(); }
        #endregion (Properties)

    }
}
