using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Blazored.Modal;
using Blazored.Modal.Services;
using BizHub.Components.Modals.AddEditEmailTemplate;

using Model;
using BizHub.Components.Modals.Generic;
using BizHub.Components.Modals.AdvancedSearch;
using BizHub.Components.Modals.AddEditEmailCampaign;
using Microsoft.AspNetCore.Components;

namespace BizHub {
    public class PagEmailCenterController : BasePageController {

        #region Fields
        private FSGridOptions _gridOptions = new FSGridOptions();

        private List<EmailTemplate> _templates = new List<EmailTemplate>();
        private List<EmailCampaignDTO> _campaigns = new List<EmailCampaignDTO>();
        private FSBlazorModalOptions _modalOptions = new FSBlazorModalOptions();
        private FSGenericModalOptions _deleteTemplateModalOptions = new FSGenericModalOptions() { Header = "Delete", Body = "Are you sure you want to delete this template?",
            Buttons = new List<FSModalButton>() {
                new FSModalButton(Constants.BUTTON_YES, true),
                new FSModalButton(Constants.BUTTON_NO)
            }
        };

        #endregion (Fields)

        #region Contructor
        public PagEmailCenterController() {
            _modalOptions.HideCloseButton = false;
            _modalOptions.HideHeader = true;
            _gridOptions.IsAllowGrouping = false;
        }
        #endregion (Contructor)

        #region Methods

        #region Templates
        public void GetTemplates() {
            try {
                Templates = SQL.GetEmailTemplatesByEntityOidMaster(SessionMgr.Instance.User.EntityOid_Master);
            } catch (Exception ex) {
                ShowPopupDialog("Error retrieving Templates: <br>" + ex.Message, "Error");
                Templates = new List<EmailTemplate>();
            }
        }

        public async Task<EmailTemplate> AddEditTemplate(EmailTemplate toTemplate = null) {
            ModalParameters oParameters = new ModalParameters();
            if(toTemplate != null) {
                oParameters.Add("Template", toTemplate);
            } else {
                EmailTemplate oTemplate = new EmailTemplate() { EntityOid_Master = SessionMgr.Instance.User.EntityOid_Master,
                CreatedBy = SessionMgr.Instance.User.EntityOid, CreatedOn = DateTime.UtcNow };
                SetDefaultMailerStats(oTemplate);
                oParameters.Add("Template", oTemplate);
            }
            ModalResult Result = await ShowModal(typeof(AddEditEmailTemplateModal), "", oParameters, _modalOptions).Result;
            if (!Result.Cancelled) {
                EmailTemplate oTemplate = (EmailTemplate)Result.Data;
                oTemplate.DateLastUpdated = DateTime.UtcNow;
                oTemplate.Save();
                return oTemplate;
            } else {
                return null;
            }
        }
        #endregion (Templates)

        #region Campaign
        public void GetEmailCampaignDTOs() {
            try {
                Campaigns = SQL.GetEmailCampaignDTOsByEntityOidMaster(SessionMgr.Instance.User.EntityOid_Master);
                EmailRecipientDefinitionsAsFSVisualItems = SQL.GetEmailRecipientDefinitionsAsFSVisualItems();
                TemplatesAsFSItems = SQL.GetEmailTemplatesAsFSVisualItemsByEntityOidMaster(SessionMgr.Instance.User.EntityOid_Master);
            } catch (Exception ex) {
                ShowPopupDialog("Error retrieving Campaigns: <br>" + ex.Message, "Error");
                Campaigns = new List<EmailCampaignDTO>();
            }
        }

        public async Task<EmailCampaignDTO> AddEditCampaignDTO(EmailCampaignDTO toCampaign = null) {
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("Campaign", (toCampaign != null) ? toCampaign : new EmailCampaignDTO());
            oParameters.Add("EmailTemplatesAsFSItems", TemplatesAsFSItems);
            oParameters.Add("EmailRecipientDefinitionsAsFSVisualItems", EmailRecipientDefinitionsAsFSVisualItems);
            ModalResult Result = await ShowModal(typeof(AddEditEmailCampaign), "", oParameters, _modalOptions).Result;
            if (!Result.Cancelled) {
                EmailCampaignDTO oCampaign = (EmailCampaignDTO)Result.Data;
                oCampaign.Save();
                return oCampaign;
            } else {
                return null;
            }
        }

        #endregion (Campaign)

        public async Task<SearchCriteriaDisplay> EditSearchCriteria(AdvancedSearchController oController) {
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("Controller", oController);
            oParameters.Add("IsShowParentCheckBoxInBusinessCategoryModal", false);
            if (!string.IsNullOrEmpty(oController.SearchCriteriaDisplay.ZipCode)) {
                ZipCode oCode = SQL.GetZipCodeByZip(oController.SearchCriteriaDisplay.ZipCode);
                oParameters.Add("IsZipCodeValid", (oCode != null) ? true : false);
            } else {
                oParameters.Add("IsZipCodeValid", false);
            }

            ModalResult oModalResult = await ShowModal(typeof(AdvancedSearchModal), "", oParameters, _modalOptions).Result;
            if (!oModalResult.Cancelled) {
                if (oModalResult.Data != null) {
                    SearchCriteriaDisplay oDisplay = (SearchCriteriaDisplay)oModalResult.Data;
                    oDisplay.SearchCriteria.Save();
                    return oDisplay;
                } 
            }
            return null;
        }

        public async Task<bool> ConfirmDelete(string tsBodyText) {
            ModalParameters oParameters = new ModalParameters();
            _deleteTemplateModalOptions.Body = tsBodyText;
            oParameters.Add("Options", _deleteTemplateModalOptions);
            ModalResult DeleteModalResult = await ShowModal(typeof(GenericModal), "", oParameters, _modalOptions).Result;
            if (DeleteModalResult.Data.Equals(Constants.BUTTON_YES)) {
                return true;
            } else {
                return false;
            }
        }

        public static void SetDefaultMailerStats(IMailer toMailer) {
            toMailer.Delivered = decimal.Zero;
            toMailer.UniqueOpens = decimal.Zero;
            toMailer.UniqueClicks = decimal.Zero;
            toMailer.SpamReports = decimal.Zero;
            toMailer.Bounces = decimal.Zero;
            toMailer.Unsubscribed = decimal.Zero;
        }
        #endregion (Methods)

        #region Properties
        public List<EmailTemplate> Templates { get => _templates; set => _templates = value; }
        public List<EmailCampaignDTO> Campaigns { get => _campaigns; set => _campaigns = value; }
        public List<FSVisualItem> TemplatesAsFSItems { get; set; }
        public List<FSVisualItem> EmailRecipientDefinitionsAsFSVisualItems { get; set; }
        public FSGridOptions GridOptions { get => _gridOptions; set => _gridOptions = value; }
        #endregion (Properties)

    }
}
