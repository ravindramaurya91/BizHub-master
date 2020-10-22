using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;
using Syncfusion.Blazor.Popups;
using Syncfusion.Blazor.Buttons;

namespace BizHub.Components.OnBoard
{
    public partial class CmpOnboardMenu
    {

        #region Constructor
        protected override void OnInitialized()
        {
            //if (ActiveMenu == 0)
            //{
            ChangeOnboard("1");
            //}
        }
        #endregion (Constructor)

        #region Methods
        public void ChangeOnboard(string tsFacilityOwnedInt)
        {
            int iValue = 1;
            switch (tsFacilityOwnedInt)
            {
                case "1":
                    iValue = 1;
                    IsShowPersonalInfo = true;
                    IsShowCompanyInfo = false;
                    IsShowAgentInfo = false;
                    Controller.TypeOfIndividual = PagOnboardController.eOnboardedIndividualType.Buyer;
                        /*Controller.eOnboardedIndividualType.Buyer;*/
                    break;
                case "2":
                    iValue = 2;
                    IsShowCompanyInfo = true;
                    IsShowAgentInfo = false;
                    IsShowPersonalInfo = false;
                    Controller.TypeOfIndividual = PagOnboardController.eOnboardedIndividualType.Seller;

                    break;
                case "3":
                    iValue = 3;
                    IsShowAgentInfo = true;
                    IsShowCompanyInfo = false;
                    IsShowPersonalInfo = false;
                    Controller.TypeOfIndividual = PagOnboardController.eOnboardedIndividualType.Agent;
                    break;
                default:

                    break;
            }
            ActiveMenu = iValue;
            //  MenuItemSelected.InvokeAsync(iValue);
        }
        #endregion

        #region Properties

        #region Parameters
        [Parameter] public PagOnboardController Controller { get; set; }
        [Parameter] public EventCallback<int> MenuItemSelected { get; set; }
        [Parameter] public int ActiveMenu { get; set; }

        public bool IsShowPersonalInfo { get; set; }
        public bool IsShowCompanyInfo { get; set; }
        public bool IsShowAgentInfo { get; set; }

        #endregion (Parameters)

        public readonly List<FSVisualItem> ONBOARD_RADIO_BUTTONS = new List<FSVisualItem> {
            new FSVisualItem {Label = "I am an individual interested in researching business for sale", Value = "1", ElementName = "OnBoard", CustomCSS="e-primary", ToolTipContent = "tooltip 1 <br> Part 2"},
            new FSVisualItem {Label = "I am an individual listing a company for sale", Value = "2", ElementName = "OnBoard", CustomCSS="e-primary", ToolTipContent = "tooltip 2"},
            new FSVisualItem {Label = "I am a brokerage,agent,or intermediary representing others", Value = "3", ElementName = "OnBoard", CustomCSS="e-primary", ToolTipContent = "tooltip 3"}
        };
        #endregion (Properties)

    }
}
