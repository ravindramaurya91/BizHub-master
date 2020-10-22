using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

using Model;
using Syncfusion.Blazor.Grids;

namespace BizHub.Components.EmailCenter.EmailTemplatesGrid {
    public partial class CmpEmailTemplatesGrid {

        protected override void OnInitialized() {
            IsLoading = true;
        }

        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                GetTemplates();
                IsLoading = false;
                this.StateHasChanged();
            }
        }

        public void GetTemplates() {
            Controller.GetTemplates();
        }

        public async void CreateNewTemplate() {
            EmailTemplate oTemplate = await Controller.AddEditTemplate();
            if (oTemplate != null) {
                Templates.Add(oTemplate);
                Grid.Refresh();
            }
        }

        public async void EditTemplate(EmailTemplate toTemplate) {
            EmailTemplate oTemplate = await Controller.AddEditTemplate(toTemplate);
            if(oTemplate != null) {
                ModelUtil.FindAndReplaceInList(Templates, toTemplate, oTemplate);
                Grid.Refresh();
            }
        }

        public async void DeleteTemplate(EmailTemplate toTemplate) {
            bool bReponse = await Controller.ConfirmDelete("Are you sure you want to delete this Template?");
            if (bReponse == true) {
                Templates.Remove(toTemplate);
                toTemplate.IsActive = false;
                toTemplate.Save();
                Grid.Refresh();
            }
        }

        #region Properties
        [Parameter] public PagEmailCenterController Controller { get; set; }

        public List<EmailTemplate> Templates { get => Controller.Templates; set => Controller.Templates = value; }
        public FSGridOptions GridOptions { get => Controller.GridOptions; }
        public SfGrid<EmailTemplate> Grid { get; set; }
        public bool IsLoading { get; set; }
        #endregion (Properties)


    }
}
