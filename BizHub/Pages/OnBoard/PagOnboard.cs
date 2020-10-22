using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace BizHub.Pages.OnBoard
{
    public partial class PagOnboard
    {
        #region Fields
        private PagOnboardController _controller = new PagOnboardController();
        private string _radioButtonSelection = "1";
        #endregion (Fields)

        #region Methods
        protected override void OnInitialized()
        {
            Controller.ActivePage = 1;
            //IsLoading = true;
            //Controller = new PagListingSetupController();
        }

        public void SaveAndExit()
        {
            Controller.Save();
        }


        public void BackClick(int currentpage)
        {
            Controller.Back(currentpage);
        }

        public void SelectMenuItem(int menuNumber)
        {
            Controller.NavigateTo("/OnBoard/" + menuNumber);
            //_controller.SelectMenuItem(menuNumber);
            //Controller.On_TypeOfIndividualChanged(menuNumber);
        }

        private void On_RadioButtonSelectionChanged() {
            switch (_radioButtonSelection) {
                case "1":
                    Controller.TypeOfIndividual = PagOnboardController.eOnboardedIndividualType.Buyer;
                    break;
                case "2":
                    Controller.TypeOfIndividual = PagOnboardController.eOnboardedIndividualType.Seller;
                    break;
                case "3":
                    Controller.TypeOfIndividual = PagOnboardController.eOnboardedIndividualType.Agent;
                    break;
            }
            Controller.IsSubmitted = false;
        }
        #endregion (Methods)

        public void UpdateRadioButtonSelection(string tsRadioButtonSelection) {
            RadioButtonSelection = tsRadioButtonSelection;
        }

        #region Properties
        public PagOnboardController Controller { get => _controller; }
        public bool IsSubmitted { get => Controller.IsSubmitted; set => Controller.IsSubmitted = value; }
        public bool HasMultipleRegions { get => Controller.HasMultipleRegions; set => Controller.HasMultipleRegions = value; }
        public bool HasMultipleOffices { get => Controller.HasMultipleOffices; set => Controller.HasMultipleOffices = value; }
        [Parameter]
        public int ActivePage { get => Controller.ActivePage; set => Controller.ActivePage = value; }
        public string RadioButtonSelection {
            get => _radioButtonSelection;
            set {
                _radioButtonSelection = value;
                On_RadioButtonSelectionChanged();
            }
        }
        public readonly List<FSVisualItem> ONBOARD_RADIO_BUTTONS = new List<FSVisualItem> {
            new FSVisualItem {Label = "I am an individual interested in researching business for sale", Value = "1", ElementName = "OnBoard", CustomCSS="e-primary", ToolTipContent = "tooltip 1 <br> Part 2"},
            new FSVisualItem {Label = "I am an individual listing a company for sale", Value = "2", ElementName = "OnBoard", CustomCSS="e-primary", ToolTipContent = "tooltip 2"},
            new FSVisualItem {Label = "I am a brokerage,agent,or intermediary representing others", Value = "3", ElementName = "OnBoard", CustomCSS="e-primary", ToolTipContent = "tooltip 3"}
        };
        #endregion (Properties)
    }
}
