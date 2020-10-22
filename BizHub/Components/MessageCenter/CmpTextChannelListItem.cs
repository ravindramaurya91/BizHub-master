using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

using Model;


namespace BizHub.Components.MessageCenter {
    public partial class CmpTextChannelListItem{

        #region Properties
        [Parameter] public IImageHierarchy ListItem {get;set;}
        [Parameter] public EventCallback<IImageHierarchy> ListItemSelected { get; set; }
        [Parameter] public Int64 ActiveChannelOid { get; set; }
        #endregion (Properties)

    }
}
