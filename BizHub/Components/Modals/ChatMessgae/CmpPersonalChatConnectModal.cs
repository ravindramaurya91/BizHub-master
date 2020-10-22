using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Components.Modals.ChatMessgae
{
    public partial class CmpPersonalChatConnectModal
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



        #endregion(Methods)

        #region Properties
        
        [Parameter]
        public string SelectionTitle { get; set; } = "";
        [Parameter]
        public string ModalHeader { get; set; } = "";
        [Parameter]
        public string ModalSubHeader { get; set; }

        #endregion(Properties)
    }
}
