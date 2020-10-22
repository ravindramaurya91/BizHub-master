//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Amazon.Runtime.Internal;
//using Base;
//using Microsoft.IdentityModel.Tokens;

//namespace Model {
//    public class LookupDefinitionHierarchy : IModel, IName {

//        #region Fields
//        //private List<Lookup> _lookups = new List<Lookup>();
//        private List<LookupNode> _lookupNodes = new List<LookupNode>();
//        #endregion (Fields)

//        #region Constructor
//        public LookupDefinitionHierarchy(LookupDefinition toDef) {
//            LookupDefinition = toDef;
//        }
//        #endregion (Constructor)

//        #region Methods


//        public List<LookupNode> GetLookupNodesByParentLookupNodeName(string tsParentNodeName) {
//            List<LookupNode> oReturn = new List<LookupNode>();
//            tsParentNodeName = tsParentNodeName.ToUpper();

//            foreach(LookupNode oNode in _lookupNodes) {

//                if (oNode.Value.ToUpper().Equals(tsParentNodeName)) {
//                    // TODO the following three lines are a workaround for a cast for List<IHierarchy> to List<LookupNode>
//                    foreach (IHierarchy oChild in oNode.Children) {
//                        oReturn.Add((LookupNode)oChild);
//                    }
//                    //oReturn = oNode.Children.Cast<LookupNode>().ToList();
//                    break;
//                }
//            }
//            return oReturn;
//        }

//        public List<LookupNode> GetLookupNodesByParentLookupNodeConstant(string tsParentNodeName) {
//            List<LookupNode> oReturn = new List<LookupNode>();
//            tsParentNodeName = tsParentNodeName.ToUpper();

//            foreach (LookupNode oNode in _lookupNodes) {
//                if (oNode.ConstantValue.Equals(tsParentNodeName)) {
//                    // TODO the following three lines are a workaround for a cast for List<IHierarchy> to List<LookupNode>
//                    foreach (IHierarchy oChild in oNode.Children) {
//                        oReturn.Add((LookupNode)oChild);
//                    }
//                    //oReturn = oNode.Children;
//                    break;
//                }
//            }
//            return oReturn;
//        }
//        public List<Lookup> GetLookupsByParentLookupNodeConstant(string tsParentNodeName) {
//            List<Lookup> oReturn = new List<Lookup>();
//            tsParentNodeName = tsParentNodeName.ToUpper();

//            foreach (LookupNode oNode in _lookupNodes) {
//                if (oNode.ConstantValue.Equals(tsParentNodeName)) {
//                    //--?? oReturn = oNode.ChildLookups;
//                    break;
//                }
//            }
//            return oReturn;
//        }

//        public LookupNode GetLookupNodeByLookupNodeConstant(string tsNodeName) {
//            LookupNode oReturn = null;
//            tsNodeName = tsNodeName.ToUpper();

//            foreach (LookupNode oNode in _lookupNodes) {
//                if (oNode.ConstantValue.Equals(tsNodeName)) {
//                    oReturn = oNode;
//                    break;
//                }
//            }
//            return oReturn;
//        }
        
//        private void SetOid() {
//            // nothing to do here.  This method exist because the IModel Interface requires that the Oid be Read/Write
//        }

//        private Int64 GetOid( ) {
//            Int64 iReturn = -1;
//            if(LookupDefinition != null) {
//                iReturn = LookupDefinition.Oid;
//            }
//            return iReturn;
//        }
//        public void AddLookupList(List<Lookup> toTopLevelList, List<Lookup> toTotalList) {
//            List<LookupNode> oNodeList = new List<LookupNode>();
//            LookupNode oNode;
//            foreach(Lookup oLookup in toTopLevelList) {
//                oNode = new LookupNode(oLookup);
//                oNodeList.Add(oNode);
//            }
//            //_lookups = toList;
//            _lookupNodes = oNodeList;
//            foreach (LookupNode oParent in _lookupNodes) {
//                BuildHierarchies(oParent, toTotalList);
//            }
//        }

//        private void BuildHierarchies(LookupNode toParentLookupNode, List<Lookup> toTotalList) {
//            LookupNode oChild;
//            List<Lookup> oLookupChildren = GetChildListByParentOid(toParentLookupNode.Oid, toTotalList);
//            foreach(Lookup oLookup in oLookupChildren) {
//                oChild = new LookupNode(oLookup);
//                oChild.Parent = toParentLookupNode;
//                toParentLookupNode.Children.Add(oChild);
//                BuildHierarchies(oChild, toTotalList);
//            }
//        }
//        private List<Lookup> GetChildListByParentOid(Int64 tiParentOid, List<Lookup> toList) {
//            List<Lookup> oReturn = new List<Lookup>();
//            foreach(Lookup oLookup in toList){
//                if(oLookup.ParentOid == tiParentOid) {
//                    oReturn.Add(oLookup);
//                }
//            }

//            return oReturn;

//        }
//        private string GetName() {
//            string sReturn = "";
//            if (LookupDefinition != null) {
//                sReturn = LookupDefinition.LookupName;
//            }
//            return sReturn;
//        }

//        #endregion (Methods)

//        #region Properties
//        public Int64 Oid { get=>GetOid(); set => SetOid(); }
//        public string Name { get => GetName(); }
//        public LookupDefinitionHierarchy Parent { get; set; }
//        public LookupDefinitionHierarchy Child { get; set; }
//        public LookupDefinition LookupDefinition { get; set; }
//       // public List<Lookup> Lookups { get=> _lookups; set => _lookups = value; }
//        public List<LookupNode> LookupNodes { get=> _lookupNodes; set => _lookupNodes = value; }
//        #endregion (Properties)
//    }
//}
