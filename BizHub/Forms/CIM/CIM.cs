using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BizHub.Forms.CIM {
    public partial class CIM {
        #region Fields
        private CIMController _controller = new CIMController();
        #endregion (Fields)
        #region Constructor
        protected override void OnInitialized()
        {
          
        }
        #endregion (Constructor)
        #region Methods

        #endregion (Methods)

        #region Properties
        public CIMController Controller { get => _controller; set => _controller = value; }
        [Parameter] public List<ParagraphInfo> Content { get; set; }
        public string CompanyName { get => _controller.CompanyName; set => _controller.CompanyName = value; } 
        public string CompanyAcronym { get => _controller.CompanyAcronym; set => _controller.CompanyAcronym = value; }
        #endregion (Properties)

    }
}
