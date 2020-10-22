using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace BizHub.Components.Admin
{
    public partial class CmpLookupDefinition
    {

        #region Fields
        private PagAdminController _controller = null;
        #endregion

        #region Constructor
        protected override void OnInitialized()
        {
           
        }
        #endregion (Constructor)

        #region Methods
        public void DefinitionClick(LookupDefinition toLookupDefinition)
        {
            Controller.ActiveLookupDefinition = toLookupDefinition;
            //Controller.IsDefinitionClicked = true;
            //Controller.IsValueClicked = false;
        }
        #endregion (Methods)

        #region Properties
        [Parameter] public PagAdminController Controller { get => _controller; set => _controller = value; }
        public List<LookupDefinition> Definitions { get => _controller.Definitions; }
        #endregion (Properties)

    }
}
