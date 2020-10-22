using BizHub.Shared;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;

namespace BizHub.Components.Modals.LoginRequiredModal {
    public partial class LoginRequired {

        #region Fields
        private BasePageController _controller = new BasePageController();
        #endregion (Fields)

        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        public bool BindVisible { get; set; } = true;

        public void NavigateToLogin() {
            Controller.NavigateTo("/Identity/Account/Login");
            BlazoredModal.Close();
        }

        public void CancelModal() {
            BlazoredModal.Cancel();
        }

        public BasePageController Controller { get => _controller; set => _controller = value; }
    }
}