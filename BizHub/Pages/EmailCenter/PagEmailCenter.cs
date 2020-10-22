using Microsoft.AspNetCore.Components;

namespace BizHub.Pages.EmailCenter {
    public partial class PagEmailCenter {

        #region Fields
        private PagEmailCenterController _controller = new PagEmailCenterController();
        #endregion (Fields)

        #region Methods
        protected override void OnInitialized() {
            if (CurrentMenu == null || CurrentMenu <= 0) {
                SelectMenuItem(1);
            }
        }

        public void SelectMenuItem(int menuNumber) {
            _controller.NavigateTo("/Email-Center/" + menuNumber);
        }
        #endregion(Methods)

        #region Properties
        [Parameter] public long CurrentMenu { get; set; }
        public PagEmailCenterController Controller { get => _controller; }
        #endregion(Properties)
    }
}
