using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.Components.Modals.PreviewListingDetail
{
    public partial class CmpPreviewListingDetail
    {
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public ListingDTO PreviewListingDTO {get; set; }
        
    }
}