using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;


namespace BizHub.Components.OnBoard
{
    public partial class CmpOnBoardSecondPage
    {
        #region Constructor
        protected override void OnInitialized()
        {
            Controller.RegionCount = 0;
            Controller.OfficeCount = 0;
            Controller.Regions.Clear();
            Controller.Offices.Clear();
        }
        #endregion (Constructor)

        #region Methods
        //public void SetOfficeCount(int count)
        //{
        //    RegionDTO.SetOfficeCount(count);
        //}
        public void ChangeMorethanOffice(string tsIsIncluded)
        {
            HasMultipleOffices = tsIsIncluded == "true" ? true : false;
            if (!HasMultipleOffices)
            {
                IsClicked = false;
                Controller.OfficeCount = 1;
                HasMultipleRegions = false;
                Controller.RegionCount = 0;
                Controller.Regions.Clear();
            }
            else
            {
                Controller.OfficeCount = 0;
                Controller.Offices.Clear();
            }
        }
        public void ChangeMorethanRegions(string tsIsIncluded)
        {
            HasMultipleRegions = tsIsIncluded == "true" ? true : false;
            if (HasMultipleRegions)
            {
                Controller.OfficeCount = 0;
                Controller.Offices.Clear();
                //Controller.UserCount = 0;
            }
            else
            {
                Controller.Regions.Clear();
                Controller.RegionCount = 0;
                //Controller.UserCount = 0;
            }

            //HasMultipleOffices = tsIsIncluded == "false" ? false : false;
            //RadiobuttionChange.InvokeAsync(true);
        }

        #endregion

        #region Properties
        #region Parameters
        [Parameter] public PagOnboardController Controller { get; set; }
        [Parameter] public EventCallback<bool> RadiobuttionChange { get; set; }
        [Parameter] public long ActiveMenu { get; set; }
        [Parameter]
        public RegionDTO RegionDTO { get; set; }
        [Parameter] public bool HasMultipleRegions { get; set; }
        [Parameter] public bool HasMultipleOffices { get; set; }
        public bool IsClicked { get; set; } = false;

        public readonly List<FSVisualItem> ONBOARD_OFFICE_RADIO_BUTTONS = new List<FSVisualItem> {
             new FSVisualItem {Label = "Yes", Value = "true", ElementName = "Office", CustomCSS="e-primary"},
            new FSVisualItem {Label = "No", Value = "false", ElementName = "Office", CustomCSS="e-primary"}
        };
        public readonly List<FSVisualItem> ONBOARD_OFFICEREGION_RADIO_BUTTONS = new List<FSVisualItem> {
             new FSVisualItem {Label = "Yes", Value = "true", ElementName = "OfficeRegion", CustomCSS="e-primary"},
            new FSVisualItem {Label = "No", Value = "false", ElementName = "OfficeRegion", CustomCSS="e-primary"}
        };
        #endregion (Parameters)

        #endregion (Properties)
    }
}
