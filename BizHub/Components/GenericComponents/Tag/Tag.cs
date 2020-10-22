using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.Components.GenericComponents.Tag {
    public partial class Tag {

        #region Fields
        #endregion (Fields)

        #region Constructor
        #endregion (Constructor)

        #region Methods
        public void RemoveTag() {
            // TODO: give ability to remove state tag
            eRemoveTag.InvokeAsync(DisplayTag);
        }
        #endregion (Methods)

        #region Properties

        [Parameter] public bool IsHideRemoveButton { get; set; } = false;
        [Parameter]
        public DisplayTag DisplayTag { get; set; }

        [Parameter]
        public EventCallback<DisplayTag> eRemoveTag { get; set; }
        #endregion (Properties)

    }
}
