using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

using Model;

namespace BizHub.Components.EmailCenter.EmailTemplatesGrid {
    public partial class CmpEmailTemplatesChildGrid {

        [Parameter]
        public List<ChildEmailObj> GridData { get; set; } = new List<ChildEmailObj>();

        }
}
