using System;
using Microsoft.AspNetCore.Components;

namespace BizHub.Components.GenericComponents.ErrorPopupMessage
{
    public partial class ErrorPopupMessage
    {
        
        #region Fields
        private bool _showVisibility = true;
        #endregion(Fields)

        #region Methods
        
        private void HideDialog(Object e)
        {
            this.ShowVisibility = false;
        }
        #endregion(Methods)
        
        #region Properties
        
        [Parameter] public string Title { get; set; }
        
        [Parameter] public string Message { get; set; }
        
        public bool ShowVisibility { get => _showVisibility; set => _showVisibility = value; }
        #endregion(Properties)
    }
}