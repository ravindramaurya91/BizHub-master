using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizHub.Services;
using BizHub.Components.Modals.AddEditEmailTemplate;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;

using Model;
using Syncfusion.Blazor.Spinner;
using BizHub.Shared;
using Syncfusion.Blazor.Grids;

namespace BizHub.Components.EmailCenter.RecipientListGrid
{
    public partial class CmpRecipientListGrid
    {
        protected override void OnInitialized() {
        }
        
        public void ChangeCategory(ParentEmailObj toTemplate) {
            //TODO: set dropdown info
        }

        public void CreateNewEmailTemplate() {
            //EmailTemplate oTemplate = Controller.CreateNewEmailTemplate().Result;

            //if (oTemplate != null) {
            //    EailTemplateList.Add(oTemplate);
            //    Grid.Refresh();
            //}
        }

        //public void Edit(Int64 tiOid) {
        //    Template = SQL.GetEmailTemplateByOid(tiOid);
        //    OpenModal();
        //}

        //public void Delete(Int64 tiOid) {
        //    Template = SQL.GetEmailTemplateByOid(tiOid);
        //    Template.Delete();
        //    EailTemplateList.Remove(Template);
        //    oTemplates = oTemplates;
        //    //Grid.Refresh();
        //}

        public void DeleteEmailTemplate(EmailTemplate toTemplate) {
            // TODO This is not bullet proof - An attempt to delete that violates the 
            // database constraints will fail.  This needs try-catch

            EailTemplateList.Remove(toTemplate);
            Grid.Refresh();
        }

        #region Spinner
        SfSpinner SpinnerObj =  new SfSpinner();
        string target { get; set; } = "#container";
        #endregion (Spinner)

        #region Properties

        #region Parameters
        [Parameter] public PagEmailCenterController Controller { get; set; } 
        [Parameter] public AdvancedSearchController SearchController { get; set; } 
        [Parameter] public List<EmailTemplate> EailTemplateList { get; set; } = new List<EmailTemplate>();
        [Parameter] public EmailTemplate Template { get; set; }
        [Parameter] public List<ParentEmailObj> GridData { get; set; } = new List<ParentEmailObj>(){
           new ParentEmailObj(){Category = "Email Blast", Description = "Templates used for Targeting selected buyers", NumberOfDocsIncluded = 6, Templates =
               new List<ChildEmailObj>(){
                    new ChildEmailObj(){Name = "Child Labor Declaration", Description = "Statement of company policy", PercentDelivered = 95.89M, PercentOpened = 69.40M, NumberOfAttachments = 2, DateAdded = DateTime.Now},
                    new ChildEmailObj(){Name = "Packing Instructions", Description = "Instructions on proper handling", PercentDelivered = Decimal.Zero, PercentOpened = Decimal.Zero, NumberOfAttachments = 0, DateAdded = DateTime.Now},
                    new ChildEmailObj(){Name = "Packing Demonstration", Description = "Video of a proper packed carton", PercentDelivered = Decimal.Zero, PercentOpened = Decimal.Zero, NumberOfAttachments = 0, DateAdded = DateTime.Now},
               } },
           new ParentEmailObj(){Category = "Sales/Solicitation", Description = "Templates Intendedfor direct solicitation of targeted buyers", NumberOfDocsIncluded = 4, Templates =
               new List<ChildEmailObj>(){
                    new ChildEmailObj(){Name = "Child Labor Declaration", Description = "Statement of company policy", PercentDelivered = 95.89M, PercentOpened = 69.40M, NumberOfAttachments = 2, DateAdded = DateTime.Now},
                    new ChildEmailObj(){Name = "Packing Instructions", Description = "Instructions on proper handling", PercentDelivered = Decimal.Zero, PercentOpened = Decimal.Zero, NumberOfAttachments = 0, DateAdded = DateTime.Now},
                    new ChildEmailObj(){Name = "Packing Demonstration", Description = "Video of a proper packed carton", PercentDelivered = Decimal.Zero, PercentOpened = Decimal.Zero, NumberOfAttachments = 0, DateAdded = DateTime.Now},
               } },
           new ParentEmailObj(){Category = "Thank you", Description = "Thank you templates for follow ups to meetings/inqueries etc", NumberOfDocsIncluded = 7, Templates =
               new List<ChildEmailObj>(){
                    new ChildEmailObj(){Name = "Child Labor Declaration", Description = "Statement of company policy", PercentDelivered = 95.89M, PercentOpened = 69.40M, NumberOfAttachments = 2, DateAdded = DateTime.Now},
                    new ChildEmailObj(){Name = "Packing Instructions", Description = "Instructions on proper handling", PercentDelivered = Decimal.Zero, PercentOpened = Decimal.Zero, NumberOfAttachments = 0, DateAdded = DateTime.Now},
                    new ChildEmailObj(){Name = "Packing Demonstration", Description = "Video of a proper packed carton", PercentDelivered = Decimal.Zero, PercentOpened = Decimal.Zero, NumberOfAttachments = 0, DateAdded = DateTime.Now},
               } },
           new ParentEmailObj(){Category = "Invitations", Description = "Invitations to company events", NumberOfDocsIncluded = 4, Templates =
               new List<ChildEmailObj>(){
                    new ChildEmailObj(){Name = "Child Labor Declaration", Description = "Statement of company policy", PercentDelivered = 95.89M, PercentOpened = 69.40M, NumberOfAttachments = 2, DateAdded = DateTime.Now},
                    new ChildEmailObj(){Name = "Packing Instructions", Description = "Instructions on proper handling", PercentDelivered = Decimal.Zero, PercentOpened = Decimal.Zero, NumberOfAttachments = 0, DateAdded = DateTime.Now},
                    new ChildEmailObj(){Name = "Packing Demonstration", Description = "Video of a proper packed carton", PercentDelivered = Decimal.Zero, PercentOpened = Decimal.Zero, NumberOfAttachments = 0, DateAdded = DateTime.Now},
               } }
        };

        #endregion (Parameters)

        public SfGrid<ParentEmailObj> Grid { get; set; }
        #endregion (Properties)
    }
}