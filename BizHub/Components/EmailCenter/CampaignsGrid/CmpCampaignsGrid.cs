using System;
using System.Collections.Generic;
using BizHub.Components.Modals.AddEditEmailCampaign;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

using Model;
using Syncfusion.Blazor.Grids;

namespace BizHub.Components.EmailCenter.CampaignsGrid {
    public partial class CmpCampaignsGrid {

        #region Constructor
        protected override void OnInitialized() {
            IsLoading = true;
        }

        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                GetEmailCampaignDTOs();
                IsLoading = false;
                StateHasChanged();
            }
        }
        #endregion (Constructor)

        public void GetEmailCampaignDTOs() {
            Controller.GetEmailCampaignDTOs();
        }

        public async void CreateNewCampaign() {
            EmailCampaignDTO oDTO = await Controller.AddEditCampaignDTO();
            if (oDTO != null) {
                Campaigns.Add(oDTO);
                Grid.Refresh();
            }
        }

        public async void EditCampaign(EmailCampaignDTO toCampaign) {
            EmailCampaignDTO oDTO = await Controller.AddEditCampaignDTO(toCampaign);
            if (oDTO != null) {
                ModelUtil.FindAndReplaceInList(Campaigns, toCampaign, oDTO);
                Grid.Refresh();
            }
        }

        public async void DeleteCampaign(EmailCampaignDTO toCampaign) {
            bool bReponse = await Controller.ConfirmDelete("Are you sure you want to delete this Campaign?");
            if (bReponse == true) {
                Campaigns.Remove(toCampaign);
                toCampaign.IsActive = false;
                toCampaign.Save();
                Grid.Refresh();
            }
        }

        public async void EditRecipientCriteria(EmailCampaignDTO toCampaign) {
            SearchCriteriaDisplay oDisplay = SQL.GetSearchCriteriaDisplayByOid(toCampaign.SearchCriteriaOid);
            AdvancedSearchController oController = new AdvancedSearchController(oDisplay);
            SearchCriteriaDisplay oEditedDisplay = await Controller.EditSearchCriteria(oController);
            if(oEditedDisplay != null) {
                toCampaign.Name = oDisplay.Name;
                toCampaign.Save();
                Grid.Refresh();
            }
        }

        public async void EditTemplate(EmailCampaignDTO toCampaign) {
            try {
                EmailTemplate oTemplate = SQL.GetEmailTemplateByOid(toCampaign.EmailTemplateOid);
                oTemplate = await Controller.AddEditTemplate(oTemplate);
                if (oTemplate != null) {
                    toCampaign.TemplateName = oTemplate.Name;
                    Grid.Refresh();
                }
            } catch (Exception ex) {
                Controller.ShowPopupDialog("Error editing Email Template: <br>" + ex.Message, "Warning");
            }
        }

        #region Properties
        [Parameter] public PagEmailCenterController Controller { get; set; }

        public List<EmailCampaignDTO> Campaigns { get => Controller.Campaigns; set => Controller.Campaigns = value; }
        public FSGridOptions GridOptions { get => Controller.GridOptions; }
        public SfGrid<EmailCampaignDTO> Grid { get; set; }
        public bool IsLoading { get; set; }
        #endregion (Properties)
    }
}
