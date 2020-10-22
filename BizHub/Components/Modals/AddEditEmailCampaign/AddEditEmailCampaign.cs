using System;
using System.Collections.Generic;
using BizHub.Components.Modals.AdvancedSearch;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.Modals.AddEditEmailCampaign {
    public partial class AddEditEmailCampaign {

        private PagEmailCenterController _controller = new PagEmailCenterController();

        #region Methods

        public void TemplateOidSelected(string tsOid) {
            Campaign.EmailTemplateOid = Convert.ToInt64(tsOid);
        }

        public void EmailRecipientDefinitionOidSelected(string tsOid) {
            Campaign.EmailRecipientDefinitionOid = Convert.ToInt64(tsOid);
        }

        public void Save() {
            BlazoredModal.Close(ModalResult.Ok(Campaign));
        }

        public void Cancel() {
            BlazoredModal.Cancel();
        }

        public async void CreateNewTemplate() {
            EmailTemplate oTemplate = await Controller.AddEditTemplate();
            if(oTemplate != null) {
                FSVisualItem oItem = new FSVisualItem() { Label = oTemplate.Name, Value = oTemplate.Oid.ToString() };
                EmailTemplatesAsFSItems.Add(oItem);
                Campaign.EmailTemplateOid = oTemplate.Oid;
                Campaign.TemplateName = oTemplate.Name;
                StateHasChanged();
            }
        }

        public async void CreateNewRecipientCriteria() {
            SearchCriteriaDisplay oDisplay = new SearchCriteriaDisplay() { Name = "New Criteria", IsEmailRecipientListQuery = true, 
                EntityOid = Controller.LoggedInUser.EntityOid, IsActive = true };
            AdvancedSearchController oController = new AdvancedSearchController(oDisplay);

            SearchCriteriaDisplay oNewDisplay = await Controller.EditSearchCriteria(oController);
            if (oNewDisplay != null) {
                EmailRecipientDefinition oDefinition = EmailRecipientDefinition.CreateDefinitionFromSearchCriteria(oNewDisplay.SearchCriteria);
               
                FSVisualItem oItem = new FSVisualItem() { Label = oDefinition.Name, Value = oDefinition.Oid.ToString() };
                EmailRecipientDefinitionsAsFSVisualItems.Add(oItem);
                Campaign.EmailRecipientDefinitionOid = oDefinition.Oid;
                Campaign.RecipientDefinitionName = oDefinition.Name;
                StateHasChanged();
            }
        }
        #endregion (Methods)

        #region Properties
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public EmailCampaignDTO Campaign { get; set; } = new EmailCampaignDTO();
        [Parameter] public List<FSVisualItem> EmailTemplatesAsFSItems { get; set; }
        [Parameter] public List<FSVisualItem> EmailRecipientDefinitionsAsFSVisualItems { get; set; }

        public PagEmailCenterController Controller { get => _controller; set => _controller = value; }
        #endregion (Properties)
    }
}
