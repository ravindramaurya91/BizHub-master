﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace BizHub.Components.GenericComponents.CmpInLineTagsDisplay {
    public partial class CmpInLineTagsDisplay {

		#region Fields
		private List<NameValuePair> _tags = new List<NameValuePair>();
		#endregion (Fields)

		#region Constructor
		#endregion (Constructor)

		#region Methods
		#endregion (Methods)

		#region Properties
		public List<NameValuePair> Tags { get => _tags; set => _tags = value; }
		#endregion (Properties)

	}
}
