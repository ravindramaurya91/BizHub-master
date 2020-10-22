//using Base;
//using CommonUtil;
//using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
//using System;
//using System.Collections.Generic;

//namespace Model {

//    public class LookupManager_Old {

//        #region Fields
//        private List<LookupNode> _lookupNodes = new List<LookupNode>(); // _lookupNodes ia a Flat list of lookups in a single long list
//        private List<LookupDefinitionHierarchy> _lookupDefinitionHierarchies = new List<LookupDefinitionHierarchy>();  // _lookupDefinitionHierarchies ia a Hierarchic list of lookupNodess in nested order
//        private List<Lookup> _lookups = null;
//        private Dictionary<string, List<Lookup>> _listByLookupName = new Dictionary<string, List<Lookup>>(); // Dictionary<string (LookupName) , List<Lookup>)
//        private Dictionary<Int64, Lookup> _listByOid = new Dictionary<Int64, Lookup>(); // Dictionary<Int63 (Oid) , Lookup>
//        private Dictionary<string, Lookup> _listByConstant = new Dictionary<string, Lookup>(); // Dictionary<string(ConstantValue) , Lookup>

//        //        private Dictionary<Int64, Lookup>;
//        private static object _syncRoot = new Object(); //for multi thread protection
//        private static volatile LookupManager_Old _instance = null;
//        private bool _lookupValuesHaveBeenUpdated = false;
//        #endregion (Fields)

//        #region Constructor 
//        static LookupManager_Old() {

//        }
//        #endregion (Constructor)

//        #region Refresh
//        public void Refresh() {
//            _lookups = null;
//            _lookupDefinitionHierarchies = new List<LookupDefinitionHierarchy>();
//            _listByLookupName = new Dictionary<string, List<Lookup>>(); // Dictionary<string (LookupName) , List<Lookup>)
//            _listByOid = new Dictionary<Int64, Lookup>(); // Dictionary<Int63 (Oid) , Lookup>
//            _listByConstant = new Dictionary<string, Lookup>(); // Dictionary<string(ConstantValue) , Lookup>
//            LoadLookupLists();
//        }
//        #endregion (Refresh)

//        public void AddLookupToCache(Lookup toLookup) {
//            _lookups.Add(toLookup);
//            AddToListByLookupName(toLookup);
//            AddToListByOid(toLookup);
//            AddToListByConstant(toLookup);
//        }

//        #region Load Lookups
//        private void LoadLookupLists() {
//            // List<Lookup> lkp = Lookup.Fetch("");
//            _lookups = Database.GetInstance().Fetch<Lookup>("");
//            foreach (Lookup oLookup in _lookups) {
//                AddToListByLookupName(oLookup);
//                AddToListByOid(oLookup);
//                AddToListByConstant(oLookup);
//            }

//            // After all the lookups have been loaded - Circle back and load the LookupHierarchies

//            // _lookupDefinitionHierarchies
//            // A LookupDefinitionHierarchy Exists 1 for each Lookup Definition.  
//            // Inside of that definition is a List of Lookups and a List of LookupNodes that are hierarchic
//            // The to level have no parents - then  we can trace the Children down the Hierarchy
//            _lookupDefinitionHierarchies.Clear();
//            List<LookupDefinition> oLookupDefinitions = Database.GetInstance().Fetch<LookupDefinition>("");
//            foreach(LookupDefinition oDef in oLookupDefinitions) {
//                LookupDefinitionHierarchy oHierarchy = new LookupDefinitionHierarchy(oDef);

//                //oHierarchy.Lookups = GetLookupsByLookupDefinitionOidForLoadingPurposesOnly(oDef.Oid);
//                _lookupDefinitionHierarchies.Add(oHierarchy);
//            }
            
//            // Why get the flat list of lookupNaodes?
//            //CreateLookupNodes();  // This method will create a Flat List of LookupNodes (_lookupNodes) that will be the complete list (no nesting) of the Lookups

//            BuildNestedHierarchyOfLookupNodes();  // This method will create the list of nested hierarchies of Lookup and LookupNodes in the _lookupDefinitionHierarchies collection
//            //ConnectLookupNodesToLookupDefinitionHierarchy();
//            //ConnectLookupDefinitionHierarchyToParent();
//        }

//        #region Load Hierarchies
//        private void BuildNestedHierarchyOfLookupNodes() {
//            foreach(LookupDefinitionHierarchy oDefinition in _lookupDefinitionHierarchies) {
//                // Go through each definition. For each definition get the top level lookups (No ParentOid) and create a top level of Lookups and of LookupNodes
//                List<Lookup> oTopLevelList = GetLookupsByLookupDefinitionOidForLookupsWithNoParentOid(oDefinition.LookupDefinition.Oid); 
//                oDefinition.AddLookupList(oTopLevelList, _lookups);
//            }
            
//        }
//        //private void CreateLookupNodes() {
//        //    // Foreach Lookup  - Check to see if the Lookup has a ParentOid.
//        //    // If it does it should be connected to a Parent.  We will do the connection by another method for ythe sake of Recursion
//        //    LookupNode oLookupNode;
//        //    foreach (Lookup oLookup in _lookups) {
//        //        oLookupNode = ModelUtil.GetFromListByOid<LookupNode>(oLookup.Oid, _lookupNodes);
//        //        if (oLookupNode == null) {
//        //            oLookupNode = new LookupNode(oLookup);
//        //            _lookupNodes.Add(oLookupNode);
//        //        }
//        //        //ConnectToNode(oLookup, oLookupNode);
//        //    }
//        //}

//        //private void ConnectLookupNodesToLookupDefinitionHierarchy() {
//        //    LookupDefinitionHierarchy oHierarchy;

//        //    foreach(LookupNode oNode in _lookupNodes) {
//        //        // Get the LookupDefinitionHierarchy that for the LookupDefinition to which this LookupNode belongs
//        //        oHierarchy = ModelUtil.GetFromListByOid<LookupDefinitionHierarchy>(oNode.Lookup.LookupDefinitionOid, _lookupDefinitionHierarchies);
//        //        if(oHierarchy != null) {
//        //            oHierarchy.LookupNodes.Add(oNode);
//        //        } else {
//        //            throw new Exception("No LookupDefinitionHierarchy found for this LookupNode");
//        //        }
//        //    }
//        //}



//        private void ConnectToNode(Lookup toChildLookup, LookupNode toChildNode) {
//            // In this method we will attempt to traverse the Parent/Child connections.  
//            // The Child Lookup is passed in along with the LookupNode that represents it.
//            // 
//            // We will retrieve the LookupNode of the ParentOid then we will have a handle to both the Parent and the CHild
//            // From there we can cross connect the Parent & the Child



//            // Retrieve the LookupNode that belongs to the ParentOid
//            Lookup oParentLookup = null;
//            LookupNode oParentNode = ModelUtil.GetFromListByOid<LookupNode>((Int64)toChildLookup.ParentOid, _lookupNodes);


//            if (oParentNode == null) {
//                oParentLookup = GetLookupByOid((Int64)toChildLookup.ParentOid);
//                // This is the first time we have encountered this Parent Lookup
//                // Create a new node for the parent and add the child to the ParentNode.Children
//                oParentNode = new LookupNode(oParentLookup);
//                //--??oParentNode.ParentLookup = oParentLookup;
//                _lookupNodes.Add(oParentNode);

//                // If we created a new Node for the Parent - we will want to see if it has a ParentOid which needs to be matched up
//                if (oParentNode.Parent != null) {
//                    ConnectToNode(oParentLookup, oParentNode);
//                }
//            }

//            if(toChildNode != null) {
//                toChildNode.Parent = oParentNode;
//                if (!_lookupNodes.Contains(toChildNode)) {
//                    _lookupNodes.Add(toChildNode);
//                }
//            }
//            if (!oParentNode.Children.Contains(toChildNode)) {
//                oParentNode.Children.Add(toChildNode);
//            }
//            //--??if (!oParentNode.ChildLookups.Contains(toChildLookup)) {
//            //--??oParentNode.ChildLookups.Add(toChildLookup);
//            //--??}
//        }

//        private void ConnectLookupDefinitionHierarchyToParent() {
//            LookupDefinitionHierarchy oParentHierarchy;

//            foreach (LookupDefinitionHierarchy oHierarchy in _lookupDefinitionHierarchies) {
//                if(oHierarchy.LookupDefinition.ParentOid != null) {
//                    oParentHierarchy = ModelUtil.GetFromListByOid<LookupDefinitionHierarchy>((Int64)oHierarchy.LookupDefinition.ParentOid, _lookupDefinitionHierarchies);
//                    if (oParentHierarchy != null) {
//                        oHierarchy.Parent = oParentHierarchy;
//                        oParentHierarchy.Child = oHierarchy;
//                    }
//                }
//            }
//        }
//        #endregion (Load Hierarchies)


//        #region Get LookupNode
//        //public List<Lookup> GetLookupsByLookupDefinitionOid(Int64 tiLookupDefinitionOid) {
//        //    List<Lookup> oReturn = new List<Lookup>();

//        //    foreach(Lookup oLookup in _lookups) {
//        //        if(oLookup.LookupDefinitionOid == tiLookupDefinitionOid) {
//        //            oReturn.Add(oLookup);
//        //        }
//        //    }
//        //    return oReturn;
//        //}

//        public List<LookupNode> GetLookupNodesByLookupName(string tsLookupName) {
//            List<LookupNode> oReturn = new List<LookupNode>();

//            LookupDefinition oDef = GetLookupDefinitionByLookupName(tsLookupName);
//            if (oDef != null) {
//                oReturn = GetLookupNodesByLookupDefinitionOid(oDef.Oid);
//            }
//            return oReturn;
//        }
//        public List<LookupNode> GetLookupNodesByLookupDefinitionOid(Int64 tiLookupDefinitionOid) {
//            List<LookupNode> oReturn = null;

//            LookupDefinitionHierarchy oHierarchy = ModelUtil.GetFromListByOid<LookupDefinitionHierarchy>(tiLookupDefinitionOid, _lookupDefinitionHierarchies); ;
//            if (oHierarchy != null) {
//                oReturn = oHierarchy.LookupNodes;
//            }

//            return oReturn;
//        }

//        public List<LookupNode> GetLookupNodesByLookupNameAndParentLookupValue(string tsLookupName, string tsParentLookupName) {
            
//            LookupDefinitionHierarchy oHierarchy = ModelUtil.GetFromListByName<LookupDefinitionHierarchy>(tsLookupName, _lookupDefinitionHierarchies);
//            if(oHierarchy == null) {
//                throw new Exception($"There is no Lookup Hierarchy for {tsLookupName} .");
//            }
//            if (oHierarchy.Parent == null) {
//                throw new Exception($"The Lookup Hierarchy for {tsLookupName} does not have a Parent.  There is no match where parent = {tsParentLookupName}.");
//            }

//            return oHierarchy.Parent.GetLookupNodesByParentLookupNodeName(tsParentLookupName);
             
//        }

//        public List<LookupNode> GetChildLookupNodesByParentConstant(string tsParentConstant) {
//            string sLookupName = ParseLookupNameFromConstant(tsParentConstant);
//            string sValue = ParseValueFromConstant(tsParentConstant);

//            LookupDefinitionHierarchy oHierarchy = ModelUtil.GetFromListByName<LookupDefinitionHierarchy>(sLookupName, _lookupDefinitionHierarchies);
//            if (oHierarchy == null) {
//                throw new Exception($"There is no Lookup Hierarchy for {sLookupName} .");
//            }

//            return oHierarchy.GetLookupNodesByParentLookupNodeConstant(tsParentConstant);

//        }

//        public LookupNode GetLookupNodeByConstant(string tsConstant) {
//            string sLookupName = ParseLookupNameFromConstant(tsConstant);

//            LookupDefinitionHierarchy oHierarchy = ModelUtil.GetFromListByName<LookupDefinitionHierarchy>(sLookupName, _lookupDefinitionHierarchies);
//            if (oHierarchy == null) {
//                throw new Exception($"There is no Lookup Hierarchy for {sLookupName} .");
//            }

//            return oHierarchy.GetLookupNodeByLookupNodeConstant(tsConstant);
//        }

//        public List<Lookup> GetChildLookupsByParentConstant(string tsParentConstant) {
//            string sLookupName = ParseLookupNameFromConstant(tsParentConstant);
//            string sValue = ParseValueFromConstant(tsParentConstant);

//            LookupDefinitionHierarchy oHierarchy = ModelUtil.GetFromListByName<LookupDefinitionHierarchy>(sLookupName, _lookupDefinitionHierarchies);
//            if (oHierarchy == null) {
//                throw new Exception($"There is no Lookup Hierarchy for {sLookupName} .");
//            }

//            return oHierarchy.GetLookupsByParentLookupNodeConstant(tsParentConstant);

//        }

//        //--??
//        //public List<Lookup> GetChildLookupsByParentOid(Int64 tiParentOid) {

//        //    LookupNode oNode = ModelUtil.GetFromListByOid<LookupNode>(tiParentOid, _lookupNodes);
//        //    if (oNode == null) {
//        //        throw new Exception($"There is no Lookup Node where Oid = [{tiParentOid}].");
//        //    }

//        //    return oNode.ChildLookups;

//        //}
//        //--??

//        public List<Lookup> GetChildLookupsByParentOidArray_DelimitedString(string tsCommaDelimitedList) {
//            List<Int64> oOidList = FSTools.ConvertDelimitedStringToList<Int64>(tsCommaDelimitedList, ',');
//            return GetChildLookupsByParentOidArray(oOidList.ToArray());
//        }
//        public List<Lookup> GetChildLookupsByParentOidArray(List<Int64> toParentOidList) {
//            return GetChildLookupsByParentOidArray(toParentOidList.ToArray());
//        }
//        public List<Lookup> GetChildLookupsByParentOidArray(Int64[] toParentOidArray) {
//            List<Lookup> oReturn = new List<Lookup>();
//            foreach (Int64 iOid in toParentOidArray) {
//                //--??oReturn.AddRange(GetChildLookupsByParentOid(iOid));
//            }
//            return oReturn;
//        }
//        private string ParseLookupNameFromConstant(string tsConstant) {
//            string sReturn = "";
//            int iPos = tsConstant.IndexOf("->");
//            if(iPos > -1) {
//                sReturn = tsConstant.Substring(0, iPos);
//            }
//            return sReturn;
//        }
//        private string ParseValueFromConstant(string tsConstant) {
//            string sReturn = "";
//            int iPos = tsConstant.IndexOf("->");
//            if (iPos > -1) {
//                sReturn = tsConstant.Substring(iPos+2);
//            }
//            return sReturn;
//        }

//        #endregion (Get LookupNode)

//        #region Get Lookup Definition Hierarchy
//        public LookupDefinitionHierarchy GetLookupDefinitionHierarchyByOid(Int64 tiOid) {
//            return ModelUtil.GetFromListByOid<LookupDefinitionHierarchy>(tiOid, _lookupDefinitionHierarchies);
//        }

//        #endregion (Get Lookup Definition Hierarchy)

//        private void AddToListByLookupName(Lookup toLookup) {
//            List<Lookup> oLookupList;
//            if (!_listByLookupName.ContainsKey(toLookup.LookupName)) {
//                // This is a first time to add this LookupName
//                oLookupList = new List<Lookup>();
//                _listByLookupName.Add(toLookup.LookupName, oLookupList);
//            } else {
//                oLookupList = _listByLookupName[toLookup.LookupName];
//            }
//            oLookupList.Add(toLookup);
//        }

//        private void AddToListByOid(Lookup toLookup) {
//            Lookup oLookup;
//            if (!_listByOid.ContainsKey(toLookup.Oid)) {
//                // This is a first time to add this LookupName
//                oLookup = toLookup;
//                _listByOid.Add(toLookup.Oid, oLookup);
//            }
//        }

//        private void AddToListByConstant(Lookup toLookup) {
//            Lookup oLookup;
//            if (!_listByConstant.ContainsKey(toLookup.ConstantValue)) {
//                // This is a first time to add this LookupName
//                oLookup = toLookup;
//                _listByConstant.Add(toLookup.ConstantValue, oLookup);
//            }
//        }

//        #endregion (LoadLookupDefinitions)

//        #region Lookup Or Add
//        public Int64? GetLookupOidByLookupNameAndValue_AddIfMissing(string tsLookupName, string tsValue, bool tbThrowErrorOnNull = false) {
//            return GetLookupOidByLookupNameAndValue_AddIfMissing(tsLookupName, tsValue, tsValue, tbThrowErrorOnNull);
//        }

//        public Int64? GetLookupOidByLookupNameAndValue_AddIfMissing(string tsLookupName, string tsValue, string tsDescription, bool tbThrowErrorOnNull = false) {
//            Int64? iReturn = null;

//            if ((!String.IsNullOrEmpty(tsLookupName)) && (!String.IsNullOrEmpty(tsValue))) {
//                Lookup oLookup = GetLookupByLookupNameAndValue_AddIfMissing(tsLookupName, tsValue, tsValue);
//                if (oLookup != null) {
//                    iReturn = oLookup.Oid;
//                }
//            }

//            if ((iReturn == null) && (tbThrowErrorOnNull)) {
//                string sLookupNameValue = (!String.IsNullOrEmpty(tsLookupName)) ? tsLookupName : "null";
//                string sLookupValueValue = (!String.IsNullOrEmpty(tsValue)) ? tsValue : "null";
//                throw new Exception($"An attempt has been made to locate a Lookup Value but Null values were passed in the parameters\nClass: LookupManager\nMethod: GetLookupOidByLookupNameAndValue_AddIfMissing()\nParemeters:\n    LookupName = [{sLookupNameValue}]\n    Lookup Value = [{sLookupValueValue}]");
//            }
//            return iReturn;
//        }
//        public Lookup GetLookupByLookupNameAndValue_AddIfMissing(string tsLookupName, string tsValue) {
//            return GetLookupByLookupNameAndValue_AddIfMissing(tsLookupName, tsValue, tsValue);
//        }
//        public Lookup GetLookupByLookupNameAndValue_AddIfMissing(string tsLookupName, string tsValue, string tsDescription) {

//            Lookup oLookup = null;

//            if ((!String.IsNullOrEmpty(tsLookupName)) && (!String.IsNullOrEmpty(tsValue))) {
//                if (String.IsNullOrEmpty(tsDescription)) {
//                    tsDescription = tsValue;
//                }
//                oLookup = GetLookupByLookupNameAndValue(tsLookupName, tsValue);
//                if (oLookup == null) {
//                    // This is a new Lookup - Add it to the Lookup table
//                    oLookup = Lookup.CreateLookup(tsLookupName, tsValue, tsDescription);
//                    AddLookupToCache(oLookup);
//                }
//            }

//            return oLookup;
//        }
//        #endregion (Lookup Or Add)

//        #region Get Lookups
//        public List<Lookup> GetLookupsByLookupName(string tsLookupName) {
//            List<Lookup> oReturn = new List<Lookup>();
//            if (_listByLookupName.ContainsKey(tsLookupName)) {
//                oReturn = _listByLookupName[tsLookupName];
//            }
//            return oReturn;
//        }

//        private List<Lookup> GetLookupsByLookupDefinitionOidForLookupsWithNoParentOid(Int64 tiLookupDefinitionOid) {
//            List<Lookup> oReturn = new List<Lookup>();

//            foreach (Lookup oLookup in _lookups) {
//                if ((oLookup.LookupDefinitionOid == tiLookupDefinitionOid) && (oLookup.ParentOid == null)){
//                    oReturn.Add(oLookup);
//                }
//            }

//            return oReturn;
//        }
//        public Lookup GetLookupByOid(Int64 tiOid) {
//            Lookup oReturn = null;

//            if (_listByOid.ContainsKey(tiOid)) {
//                oReturn = _listByOid[tiOid];
//            }

//            return oReturn;
//        }

//        public Lookup GetLookupByLookupNameAndValue(string tsLookupName, string tsValue) {
//            Lookup oReturn = null;

//            if (!String.IsNullOrEmpty(tsValue)) {
//                List<Lookup> oList = GetLookupsByLookupName(tsLookupName);
//                foreach (Lookup oLookup in oList) {
//                    if (oLookup.Value.Equals(tsValue)) {
//                        oReturn = oLookup;
//                        break;
//                    }
//                }
//            }

//            return oReturn;
//        }

//        public Lookup GetLookupByConstantValue(string tsConstantValue) {
//            Lookup oReturn = null;
//            if (_listByConstant.ContainsKey(tsConstantValue)) {
//                oReturn = _listByConstant[tsConstantValue];
//            }
//            return oReturn;
//        }

//        #endregion (Get Lookup)

//        #region Get Value
//        public List<string> GetLookupValuesByLookupName(string tsLookupName, string tsLanguage) {
//            List<string> sReturn = new List<string>();
//            if (_listByLookupName.ContainsKey(tsLookupName)) {
//                List<Lookup> oList = _listByLookupName[tsLookupName];
//                foreach (Lookup oLookup in oList) {
//                    sReturn.Add(oLookup.Value);
//                }
//            }
//            return sReturn;
//        }

//        public string GetValueByOid(Int64? tiOid) {
//            return GetValueByOid(tiOid, "EN");
//        }

//        public string GetValueByOid(Int64? tiOid, string tsLanguage) {
//            string sReturn = "";
//            if (tiOid != null) {
//                Lookup oLookup = GetLookupByOid((Int64)tiOid);
//                if (oLookup != null) {
//                    sReturn = oLookup.Value;
//                }
//            }
//            return sReturn;
//        }
//        public string GetValueByConstantValue(string tsConstantValue) {
//            return GetValueByConstantValue(tsConstantValue, "EN");
//        }

//        public string GetValueByConstantValue(string tsConstantValue, string tsLanguage) {
//            string sReturn = "";
//            Lookup oLookup = GetLookupByConstantValue(tsConstantValue);
//            if (oLookup != null) {
//                sReturn = oLookup.Value;
//            }
//            return sReturn;
//        }


//        #endregion (GetValue)

//        #region Get Oid
//        public Int64 GetOidByOid(Int64 tiOid) {
//            Int64 iReturn = -1;
//            Lookup oLookup = GetLookupByOid(tiOid);
//            if (oLookup != null) {
//                iReturn = oLookup.Oid;
//            }
//            return iReturn;
//        }
//        public Int64 GetOidByLookupNameAndValue(string tsLookupName, string tsValue) {
//            Int64 iReturn = -1;
//            Lookup oLookup = GetLookupByLookupNameAndValue(tsLookupName, tsValue);
//            if (oLookup != null) {
//                iReturn = oLookup.Oid;
//            }
//            return iReturn;
//        }
//        public Int64 GetOidByConstantValue(string tsConstantValue) {
//            Int64 iReturn = -1;
//            Lookup oLookup = GetLookupByConstantValue(tsConstantValue);
//            if (oLookup != null) {
//                iReturn = oLookup.Oid;
//            }
//            return iReturn;
//        }
//        public Int64 GetOidByValue(string tsValue) {
//            Int64 iReturn = -1;
//            Lookup oLookup = SQL.GetLookupByValue(tsValue);
//            if (oLookup != null) {
//                iReturn = oLookup.Oid;
//            }
//            return iReturn;
//        }

//        #endregion (GetOid)


//        #region Lookup Definitions
//        public LookupDefinition GetLookupDefinitionByOid(Int64 tiOid, bool tbThrowException = false) {
//            LookupDefinition oReturn = null;

//            LookupDefinitionHierarchy oDescriptor = ModelUtil.GetFromListByOid<LookupDefinitionHierarchy>(tiOid, _lookupDefinitionHierarchies);
//            if (oDescriptor == null){
//                if (tbThrowException) {
//                    throw new Exception("No LookupDefinition Found Where Oid = [" + tiOid.ToString() + "]");
//                }
//            } else {
//                oReturn = oDescriptor.LookupDefinition;
//            }

//            return oReturn;
//        }
//        public LookupDefinition GetLookupDefinitionByLookupName(string tsLookupName, bool tbThrowException = false) {
//            LookupDefinition oReturn = null;

//            foreach (LookupDefinitionHierarchy oDescriptor in _lookupDefinitionHierarchies) {
//                if (oDescriptor.Name.Equals(tsLookupName)) {
//                    oReturn = oDescriptor.LookupDefinition;
//                }
//            }
//            if ((oReturn == null) && (tbThrowException)) {
//                throw new Exception("No LookupDefinition Found Where LookupName = [" + tsLookupName + "]");
//            }

//            return oReturn;
//        }
//        public Int64 GetLookupDefinitionOidByLookupName(string tsLookupName, bool tbThrowException = false) {
//            Int64 iReturn = -1;
//            LookupDefinition oLookupdefinition = GetLookupDefinitionByLookupName(tsLookupName, tbThrowException); ;
//            if (oLookupdefinition == null) {  
//                if(tbThrowException) {
//                    throw new Exception("No LookupDefinition Found Where LookupName = [" + tsLookupName + "]");
//                }
//            } else {
//                iReturn = oLookupdefinition.Oid;
//            }

//            return iReturn;
//        }

//        #endregion (Lookup Definitions)

//        #region Properties
//        public static LookupManager_Old Instance {
//            get {
//                if (_instance == null) {
//                    lock (_syncRoot) {
//                        _instance = new LookupManager_Old();
//                        _instance.Refresh();
//                    }
//                }
//                return _instance;
//            }
//        }
//        public bool LookupValuesHaveBeenUpdated {
//            get { return _lookupValuesHaveBeenUpdated; }
//            set { _lookupValuesHaveBeenUpdated = value; }
//        }

//        #endregion (Properties)
//    }


//}

