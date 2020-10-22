using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace BizHub.Components.Admin {
    public partial class CmpLookup {

        #region Fields
        private PagAdminController _controller = null;
        #endregion

        #region Methods
        public void DefinitionClick(LookupDefinition toLookupDefinition)
        {
            Controller.ActiveLookupDefinition = toLookupDefinition;
        }
        public void LookupClick(Lookup toLookup)
        {
            Controller.ActiveLookup = toLookup;
        }
        #endregion (Methods)

        #region Properties
        [Parameter] public PagAdminController Controller { get => _controller; set => _controller = value; }

        public List<LookupDefinition> Definitions { get => _controller.Definitions; }
        public List<Lookup> Lookups { get => _controller.Lookups; }
        public LookupDefinition ActiveLookupDefinition { get => _controller.ActiveLookupDefinition; set => _controller.ActiveLookupDefinition = value; }
        public Lookup ActiveLookup { get => _controller.ActiveLookup; set => _controller.ActiveLookup = value; }
        public LookupUdfBlock LookupUdfBlock { get => _controller.LookupUdfBlock; }
        #endregion (Properties)

    }
}
