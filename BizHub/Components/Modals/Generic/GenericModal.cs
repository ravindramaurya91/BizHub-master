using System;
using System.Collections.Generic;
using BizHub.Pages.Listings;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.Modals.Generic {
    public  partial class GenericModal {

        public void ButtonSelected(FSModalButton toButton) {
            BlazoredModal.Close(ModalResult.Ok(toButton.Name));
        }

        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public FSGenericModalOptions Options { get; set; }


    }
}
