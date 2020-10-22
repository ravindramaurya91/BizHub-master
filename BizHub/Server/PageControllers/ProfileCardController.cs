using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace BizHub {
    public class ProfileCardController : BasePageController {


		#region Fields
		private IdentityCardDTO _profileCardDTO = new IdentityCardDTO();
		#endregion (Fields)

		#region Methods


		#endregion (Methods)

		#region Properties
		public IdentityCardDTO ProfileCard { get => _profileCardDTO; set => _profileCardDTO = value; }
		#endregion (Properties)


	}
}
