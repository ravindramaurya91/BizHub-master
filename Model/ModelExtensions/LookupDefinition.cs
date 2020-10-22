using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public partial class LookupDefinition {

        #region Fields
        private LookupDefinition _parent = null;
        private List<LookupDefinition> _children = new List<LookupDefinition>();
        private List<LookupNode> _lookupNodes = new List<LookupNode>();
        #endregion (Fields)

        public LookupNode GetLookupNodeByValue(string tsValue) {
            LookupNode oReturn = null;
            foreach (LookupNode oNode in _lookupNodes) {
                if (oNode.Value.Equals(tsValue)) {
                    oReturn = oNode;
                    break;
                }
            }
            return oReturn;
        }

        #region Properties
        [Ignore] public LookupDefinition Parent { get => _parent; set => _parent = value; }
        [Ignore] public List<LookupDefinition> Children { get => _children; set => _children = value; }
        [Ignore] public List<LookupNode> LookupNodes { get => _lookupNodes; set => _lookupNodes = value; }
        [Ignore] public bool IsModified { get; set; }
        #endregion (Properties)

    }
}
