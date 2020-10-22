using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.FSLibrary.Dialog {
    public partial class FSDialog {

        protected override void OnInitialized() {
            //if (!string.IsNullOrEmpty(Options.Width)) {
            //    Options.Width = (Options.Width.Trim() + "px");
            //}
            
        }

        public void deactivate() {
            if (BindVisible) {

            }
        }

        public void ButtonClick(string tsButtonName) {
            eButtonClick.InvokeAsync(tsButtonName);
        }

        [Parameter]
        public FSInfoModalOptions Options { get; set; }

        [Parameter]
        public bool BindVisible { get; set; }

        [Parameter]
        public EventCallback<string> eButtonClick { get; set; }

        public Syncfusion.Blazor.Popups.SfDialog SFD { get; set; }
    }
}
