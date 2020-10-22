using Microsoft.AspNetCore.Components;

namespace BizHub.Pages.Notifications
{
    public partial class PagNotifications
    {
      #region Fields
      #endregion(Fields)
      
      #region Constructor
      #endregion(Constructor)
      
      #region Methods
      
      protected override void OnInitialized() {
          if (CurrentMenu <= 0 || CurrentMenu == null) {
              SelectMenuItem(1);
          }
      }
      
      public void SelectMenuItem(int menuNumber) {
          NavManager.NavigateTo("/Notifications/" + menuNumber);
      }
      
      #endregion(Methods)
      
      #region Properties
      [Parameter]
      public long CurrentMenu { get; set; }
      #endregion(Properties)  
    }
}