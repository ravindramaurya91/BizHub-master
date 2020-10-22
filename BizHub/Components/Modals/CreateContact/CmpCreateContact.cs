using System;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.Components.Modals.CreateContact
{
    public partial class CmpCreateContact
    {
        #region Fields
        private Contact _contact = new Contact();
        private bool _isSubmitted = false;
        #endregion(Fields)
        
        #region Constructor
        #endregion(Constructor)
        
        #region Methods
        public void CreateContact()
        {
            IsSubmitted = true;
            if ((!string.IsNullOrEmpty(Contact.FirstName)) && (!string.IsNullOrEmpty(Contact.LastName)) && (!string.IsNullOrEmpty(Contact.Email)))
            {
                Contact.AddContact(Contact);
                BlazoredModal.Close();   
            }
        }

        public void Cancel() {
            BlazoredModal.Cancel();
        }
        #endregion(Methods)
        
        #region Properties
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        public Contact Contact { get => _contact; set => _contact = value; }
        public bool IsSubmitted { get => _isSubmitted; set => _isSubmitted = value; }

        #endregion(Properties)
        
    }
}