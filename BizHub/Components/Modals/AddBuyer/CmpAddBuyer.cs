using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Components.Modals.AddBuyer
{
    public partial class CmpAddBuyer
    {
        [CascadingParameter]
        BlazoredModalInstance BlazoredModal { get; set; }

        #region Fields
        #endregion(Fields)

        #region Constructor
        protected override void OnInitialized()
        {
            //Items = ListManager.GetAllItems();
            //GenerateDisplayListFromSelectedItems();
        }
        #endregion(Constructor)

        #region Methods

        public void SaveChanges()
        {
            BlazoredModal.Close(ModalResult.Ok(BuyerProfileDTO));
        }


        #endregion(Methods)

        #region Properties
        [Parameter]
        public BuyerProfileDTO BuyerProfileDTO { get; set; }
        [Parameter]
        public string SelectionTitle { get; set; } = "";
        [Parameter]
        public string ModalHeader { get; set; } = "";
        [Parameter]
        public string ModalSubHeader { get; set; }
      
        #endregion(Properties)
    }
}
