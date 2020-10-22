using System;
using System.Collections.Generic;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.RichTextEditor;

using Model;

namespace BizHub.Components.Modals.AddEditEmailTemplate {
    public partial class AddEditEmailTemplateModal {

        #region Fields
        private List<Lookup> _lkpTemplateCategories = LookupManager.Instance.GetLookupsByLookupName("TemplateCategory");
        private List<FSVisualItem> _categoryDropDownValues;
        private List<FSVisualItem> _dataInsertOptions = Constants.EMAIL_TEMPLATE_DATA_INSERT_OPTIONS;
        #endregion (Fields)

        #region Methods
        protected override void OnInitialized() {
            DataInsertDropdownValue = _dataInsertOptions[0].Value;
            _categoryDropDownValues = new List<FSVisualItem>();
            foreach (Lookup oLookup in _lkpTemplateCategories) {
                _categoryDropDownValues.Add(new FSVisualItem() { Label = oLookup.Value, Value = oLookup.Oid.ToString() });
            }
        }

        public void UpdateHypertext(string tsHypertext) {
            Template.HyperText = tsHypertext;
        }

        public void CategorySelected(string tsCategoryOid) {
            Template.LkpTemplateCategoryOid = Convert.ToInt64(tsCategoryOid);
        }

        public void DataInsertSelected(string tsDataValue) {
            if(!tsDataValue.Equals("Select One") && RTEditor != null) {
                RTEditor.ExecuteCommand(CommandName.InsertHTML, "<span style=\"color:var(--primary-blue)\"><strong>%" + tsDataValue + "%<strong></span> ");
                DataInsertDropdownValue = _dataInsertOptions[0].Value;
            }
        }

        public void AssignEditorReference(SfRichTextEditor toEditor) {
            RTEditor = toEditor;
        }

        public void Save() {
            BlazoredModal.Close(ModalResult.Ok(Template));
        }

        public void Cancel() {
            BlazoredModal.Cancel();
        }
        #endregion (Methods)

        #region Properties
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public EmailTemplate Template { get; set; } = new EmailTemplate();
        public SfRichTextEditor RTEditor { get; set; }
        public List<FSVisualItem> CategoryDropDownvalues { get => _categoryDropDownValues; set => _categoryDropDownValues = value; }
        public List<FSVisualItem> DataInsertOptions { get => _dataInsertOptions; set => _dataInsertOptions = value; }
        public string DataInsertDropdownValue { get; set; }
        #endregion (Properties)
    }
}
