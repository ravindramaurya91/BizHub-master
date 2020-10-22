using System;
using System.Collections.Generic;
using System.Text;

using Base;
using PetaPoco;
using CommonUtil;

namespace Model {
    public class LookupManager {

        #region Fields
        private List<Lookup> _lookups = new List<Lookup>();
        private List<LookupNode> _lookupNodes = new List<LookupNode>();
        private List<LookupDefinition> _lookupDefinitions = new List<LookupDefinition>();
        //private Dictionary<string, List<Lookup>> _listByLookupConstant = new Dictionary<string, List<Lookup>>(); // Dictionary<string (LookupName) , List<Lookup>)
        private Dictionary<string, List<Lookup>> _listByLookupName = new Dictionary<string, List<Lookup>>(); // Dictionary<string (LookupName) , List<Lookup>)
        private Dictionary<Int64, Lookup> _listByOid = new Dictionary<Int64, Lookup>(); // Dictionary<Int63 (Oid) , Lookup>
        private Dictionary<Int64, List<Lookup>> _listByParentOid = new Dictionary<Int64, List<Lookup>>(); // Dictionary<Int63 (Oid) , Lookup>
        private Dictionary<string, Lookup> _lookupListByConstant = new Dictionary<string, Lookup>(); // Dictionary<string(ConstantValue) , Lookup>
        private Dictionary<string, LookupNode> _lookupNodeByConstant = new Dictionary<string, LookupNode>(); // Dictionary<string(ConstantValue) , Lookup>
        private Dictionary<Int64, LookupNode> _lookupNodeByOid = new Dictionary<Int64, LookupNode>(); // Dictionary<string(ConstantValue) , Lookup>
        private static object _syncRoot = new Object(); //for multi thread protection
        private static volatile LookupManager _instance = null;
        private bool _lookupValuesHaveBeenUpdated = false;
        #endregion (Fields)

        #region Constructor 
        static LookupManager() {

        }
        #endregion (Constructor)

        #region Methods
        #region Refresh
        public void Refresh() {
            _lookups.Clear();
            _lookupNodes.Clear();
            _lookupDefinitions = new List<LookupDefinition>();
            _listByLookupName = new Dictionary<string, List<Lookup>>(); // Dictionary<string (LookupName) , List<Lookup>)
            _listByOid = new Dictionary<Int64, Lookup>(); // Dictionary<Int64 (Oid) , Lookup>
            _listByParentOid = new Dictionary<Int64, List<Lookup>>(); // Dictionary<Int64 (Oid) , Lookup>
            _lookupListByConstant = new Dictionary<string, Lookup>(); // Dictionary<string(ConstantValue) , Lookup>
            _lookupNodeByConstant = new Dictionary<string, LookupNode>(); // Dictionary<string(ConstantValue) , Lookup>
            _lookupNodeByOid = new Dictionary<long, LookupNode>();  // Dictionary<Int64 (Oid) , Lookup>
            LoadLookups();
            LoadLookupDefinitions();
        }
        #endregion (Refresh)

        #region Startup

        #region Load Lookups
        private void LoadLookups() {
            // List<Lookup> lkp = Lookup.Fetch("");
            _lookups = Lookup.Fetch("ORDER BY Value");
            _lookupNodes = Base.Database.GetInstance().Fetch<LookupNode>("SELECT * FROM Lookup ORDER BY Value", "");

            foreach (Lookup oLookup in _lookups) {
                AddToListByLookupName(oLookup);
                AddToListByOid(oLookup);
                AddToListByParentOid(oLookup);
                AddToLookupListByConstant(oLookup);
            }
        }
        private void BuildLookupNodeHierarchy(LookupNode toNode) {
            toNode.Children = GetLookupNodesByLookupParentOid(toNode.Oid);
            foreach(IHierarchy oChild in toNode.Children) {
                oChild.Parent = toNode;
                BuildLookupNodeHierarchy((LookupNode)oChild);
            }
        }

        private List<IHierarchy> GetLookupNodesByLookupParentOid(Int64 tiLookupNodeParentOid) {
            List<IHierarchy> oReturn = new List<IHierarchy>();

            foreach (LookupNode oNode in _lookupNodes) {
                if (oNode.ParentOid == tiLookupNodeParentOid) {
                    oReturn.Add(oNode);
                }
            }
            return oReturn;
        }
        private List<LookupNode> GetTopTierLookupNodesByLookupDefinitionOid(Int64 tiLookupDefinitionOid) {
            List<LookupNode> oReturn = new List<LookupNode>();

            foreach(LookupNode oNode in _lookupNodes) {
                if((oNode.LookupDefinitionOid == tiLookupDefinitionOid) && (oNode.ParentOid == null)) {
                    oReturn.Add(oNode);
                }
            }
            return oReturn;
        }
        private void AddToListByLookupName(Lookup toLookup) {
            List<Lookup> oLookupList;
            if (!_listByLookupName.ContainsKey(toLookup.LookupName)) {
                // This is a first time to add this LookupName
                oLookupList = new List<Lookup>();
                _listByLookupName.Add(toLookup.LookupName, oLookupList);
            } else {
                oLookupList = _listByLookupName[toLookup.LookupName];
            }
            oLookupList.Add(toLookup);
        }



        private void AddToListByOid(Lookup toLookup) {
            Lookup oLookup;
            if (!_listByOid.ContainsKey(toLookup.Oid)) {
                // This is a first time to add this LookupName
                oLookup = toLookup;
                _listByOid.Add(toLookup.Oid, oLookup);
            }
        }

        private void AddToListByParentOid(Lookup toLookup) {
            if (toLookup.ParentOid != null) {
                List<Lookup> oLookupList = new List<Lookup>();
                if (!_listByParentOid.TryGetValue((Int64)toLookup.ParentOid, out oLookupList)) {
                    // This is a first time to add this LookupName
                    oLookupList = new List<Lookup>();
                    _listByParentOid.Add((Int64)toLookup.ParentOid, oLookupList);
                }
                oLookupList.Add(toLookup);
            }
        }

        private void AddToLookupListByConstant(Lookup toLookup) {
            if (!_lookupListByConstant.ContainsKey(toLookup.ConstantValue)) {
                // This is a first time to add this LookupName
                _lookupListByConstant.Add(toLookup.ConstantValue, toLookup);
            }
        }
        private void AddToLookupNodeListByConstant(LookupNode toLookupNode) {
            if (!_lookupNodeByConstant.ContainsKey(toLookupNode.ConstantValue)) {
                // This is a first time to add this LookupName
                _lookupNodeByConstant.Add(toLookupNode.ConstantValue, toLookupNode);
            }
        }
        private void AddToLookupNodeListByOid(LookupNode toLookupNode) {
            if (!_lookupNodeByOid.ContainsKey(toLookupNode.Oid)) {
                // This is a first time to add this LookupName
                _lookupNodeByOid.Add(toLookupNode.Oid, toLookupNode);
            }
        }
        

        #endregion (Load Lookups)

        #region Load LookupDefinitions
        private void LoadLookupDefinitions() {
            _lookupDefinitions = LookupDefinition.Fetch("");
            foreach (LookupDefinition oDef in _lookupDefinitions) {
                oDef.LookupNodes = GetTopTierLookupNodesByLookupDefinitionOid(oDef.Oid);
                foreach (LookupNode oNode in oDef.LookupNodes) {
                    BuildLookupNodeHierarchy(oNode);
                }
            }

            ConnectDefinitionHierarchy();
            
            foreach(LookupNode oNode in _lookupNodes) {
                AddToLookupNodeListByOid(oNode);
                AddToLookupNodeListByConstant(oNode);
            }
            _lookupNodes.Clear();
        }

        private void ConnectDefinitionHierarchy() {
            foreach (LookupDefinition oDef in _lookupDefinitions) {
                BuildLookupDefHierarchy(oDef);
            }
        }
        private void BuildLookupDefHierarchy(LookupDefinition toDef) {
            toDef.Children = GetLookupDefinitionByParentOid(toDef.Oid);
            foreach (LookupDefinition oChild in toDef.Children) {
                oChild.Parent = toDef;
                BuildLookupDefHierarchy(oChild);
            }
        }
        private List<LookupDefinition> GetLookupDefinitionByParentOid(Int64 tiOid) {
            List<LookupDefinition> oReturn = new List<LookupDefinition>();
            foreach (LookupDefinition oDef in _lookupDefinitions) {
                if(oDef.ParentOid == tiOid) {
                    oReturn.Add(oDef);
                }
            }
            return oReturn;
        }
        #endregion (Load LookupDefinitions)

        #endregion (Startup)

        #region Add New Lookup To Manager
        public void AddLookupToCache(Lookup toLookup) {
        _lookups.Add(toLookup);
        AddToListByLookupName(toLookup);
        AddToListByOid(toLookup);
        AddToLookupListByConstant(toLookup);
    }
        #endregion (Add New Lookup To Manager)


        #region Get Methods

        #region Get LookupDefinition
        public LookupDefinition GetLookupDefinitionByLookupName(string tsLookupName) {
            LookupDefinition oReturn = null;
            tsLookupName = tsLookupName.ToUpper();
            foreach (LookupDefinition oDef in _lookupDefinitions) {
                if (oDef.LookupName.ToUpper().Equals(tsLookupName)) {
                    oReturn = oDef;
                }
            }
            return oReturn;
        }
        public LookupDefinition GetLookupDefinitionByOid(Int64 tiOid) {
            LookupDefinition oReturn = null;
            foreach (LookupDefinition oDef in _lookupDefinitions) {
                if (oDef.Oid == tiOid) {
                    oReturn = oDef;
                }
            }
            return oReturn;
        }
        
        private LookupDefinition GetLookupDefinitionByLookupConstant(string tsConstant) {
            string sLookupName = ParseLookupNameFromConstant(tsConstant);
            return GetLookupDefinitionByLookupName(sLookupName);
        }

        #endregion (Get LookupDefinition)

        #region Get LookupNode

        //public LookupNode GetLookupNodeByConstant(string tsConstant) {
        //    LookupNode oReturn = null;

        //    LookupDefinition oDef = GetLookupDefinitionByLookupConstant(tsConstant);
        //    if (oDef != null) {
        //        string sValue = ParseValueFromConstant(tsConstant).ToUpper().Replace(" ", "");
        //        foreach (LookupNode oNode in oDef.LookupNodes) {
        //            if (oNode.Value.ToUpper().Replace(" ", "").Equals(sValue)) {
        //                oReturn = oNode;
        //                break;
        //            }
        //        }
        //    }

        //    return oReturn;
        //}
        public LookupNode GetLookupNodeByConstant(string tsConstant) {
            LookupNode oReturn = null;
            if (_lookupNodeByConstant.ContainsKey(tsConstant)) {
                oReturn = _lookupNodeByConstant[tsConstant];
            }
            return oReturn;
        }
        public LookupNode GetLookupNodeByOid(Int64 tiOid) {
            LookupNode oReturn = null;
            if (_lookupNodeByOid.ContainsKey(tiOid)) {
                oReturn = _lookupNodeByOid[tiOid];
            }
            return oReturn;
        }
        
        public List<LookupNode> GetLookupNodesByLookupDefinitionOid(Int64 tiLookupDefinitionOid) {
            List<LookupNode> oReturn = new List<LookupNode>();

            LookupDefinition oDef = GetLookupDefinitionByOid(tiLookupDefinitionOid);
            if (oDef != null) {
                oReturn = oDef.LookupNodes;
            }

            return oReturn;
        }

        public List<LookupNode> GetCopyOfLookupNodeListByLookupName(string tsLookupName) {
            List<LookupNode> oReturn = new List<LookupNode>();

            foreach (LookupDefinition oDef in _lookupDefinitions) {
                if (oDef.LookupName.Equals(tsLookupName)) {
                    oReturn = oDef.LookupNodes;
                }
            }
            return oReturn.DeepClone<List<LookupNode>>();
        }

        public List<LookupNode> GetLookupNodesByLookupName(string tsLookupName) {
            List<LookupNode> oReturn = new List<LookupNode>();

            foreach (LookupDefinition oDef in _lookupDefinitions) {
                if (oDef.LookupName.Equals(tsLookupName)) {
                    oReturn = oDef.LookupNodes;
                }
            }
            return oReturn;
        }

        public List<LookupNode> GetChildLookupNodesByParentConstant(string tsParentConstant) {
            List<LookupNode> oReturn = new List<LookupNode>();
            List<IHierarchy> oList = GetChildIHierarchyByParentConstant(tsParentConstant);
            foreach(IHierarchy oItem in oList) {
                oReturn.Add((LookupNode)oItem);
            }
            return oReturn;
        }
        public List<IHierarchy> GetChildIHierarchyByParentConstant(string tsParentConstant) {
            List<IHierarchy> oReturn = new List<IHierarchy>();
            LookupNode oParentNode = GetLookupNodeByConstant(tsParentConstant);
            if (oParentNode != null) {
                oReturn = oParentNode.Children;
            }

            return oReturn;
        }

        public List<LookupNode> GetLookupNodesByLookupNameAndParentLookupValue(string tsLookupName, string tsParentValue) {
            List<LookupNode> oReturn = new List<LookupNode>();
            List<IHierarchy> oList = GetIHierarchyByLookupNameAndParentLookupValue(tsLookupName, tsParentValue);

            foreach(IHierarchy oNode in oList) {
                oReturn.Add((LookupNode)oNode);
            }
            return oReturn;
        }
        public List<IHierarchy> GetIHierarchyByLookupNameAndParentLookupValue(string tsLookupName, string tsParentValue) {
            LookupNode oParentNode;
            List<IHierarchy> oReturn = new List<IHierarchy>();

            //string sParentConstant = tsLookupName.ToUpper() + "->" + tsParentValue.ToUpper().Replace(" ", "");
            //oParentNode = GetLookupNodeByConstant(sParentConstant);
            //if(oParentNode != null) {
            //    oReturn = oParentNode.Children;
            //}

            LookupDefinition oChildDef = GetLookupDefinitionByLookupName(tsLookupName);
            if (oChildDef != null) {
                LookupDefinition oParentDef = oChildDef.Parent;
                if (oParentDef != null) {
                    oParentNode = oParentDef.GetLookupNodeByValue(tsParentValue);
                    if (oParentNode != null) {
                        oReturn = oParentNode.Children;
                    }
                }
            }

            return oReturn;
        }

        #endregion (Get LookupNode)

        #region Get Lookups
        public List<Lookup> GetLookupsByLookupName(string tsLookupName) {
            List<Lookup> oReturn = new List<Lookup>();
            if (_listByLookupName.ContainsKey(tsLookupName)) {
                oReturn = _listByLookupName[tsLookupName];
            }
            return oReturn;
        }

        public Lookup GetLookupByOid(Int64 tiOid) {
            Lookup oReturn = null;
            if (_listByOid.ContainsKey(tiOid)) {
                oReturn = _listByOid[tiOid];
            }
            return oReturn;
        }
        public List<Lookup> GetLookupByParentOid(Int64 tiOid) {
            List<Lookup> oReturn = new List<Lookup>();
            if (_listByParentOid.TryGetValue(tiOid, out oReturn)) {
                oReturn = _listByParentOid[tiOid];
            }
            return oReturn;
        }
        public Lookup GetLookupByLookupNameAndValue(string tsLookupName, string tsValue) {
            Lookup oReturn = null;

            if (!String.IsNullOrEmpty(tsValue)) {
                List<Lookup> oList = GetLookupsByLookupName(tsLookupName);
                foreach (Lookup oLookup in oList) {
                    if (oLookup.Value.Equals(tsValue)) {
                        oReturn = oLookup;
                        break;
                    }
                }
            }

            return oReturn;
        }

        public Lookup GetLookupByConstantValue(string tsConstantValue) {
            Lookup oReturn = null;
            if (_lookupListByConstant.ContainsKey(tsConstantValue)) {
                oReturn = _lookupListByConstant[tsConstantValue];
            }
            return oReturn;
        }

        #endregion (Get Lookup)

        private string ParseLookupNameFromConstant(string tsConstant) {
            string sReturn = "";
            int iPos = tsConstant.IndexOf("->");
            if (iPos > -1) {
                sReturn = tsConstant.Substring(0, iPos);
            }
            return sReturn;
        }
        private string ParseValueFromConstant(string tsConstant) {
            string sReturn = "";
            int iPos = tsConstant.IndexOf("->");
            if (iPos > -1) {
                sReturn = tsConstant.Substring(iPos + 2);
            }
            return sReturn;
        }

        #region Get Oid
        public Int64 GetOidByOid(Int64 tiOid) {
            Int64 iReturn = -1;
            Lookup oLookup = GetLookupByOid(tiOid);
            if (oLookup != null) {
                iReturn = oLookup.Oid;
            }
            return iReturn;
        }
        public Int64 GetOidByLookupNameAndValue(string tsLookupName, string tsValue) {
            Int64 iReturn = -1;
            Lookup oLookup = GetLookupByLookupNameAndValue(tsLookupName, tsValue);
            if (oLookup != null) {
                iReturn = oLookup.Oid;
            }
            return iReturn;
        }
        public Int64 GetOidByConstantValue(string tsConstantValue) {
            Int64 iReturn = -1;
            Lookup oLookup = GetLookupByConstantValue(tsConstantValue);
            if (oLookup != null) {
                iReturn = oLookup.Oid;
            }
            return iReturn;
        }
        public Int64 GetOidByValue(string tsValue) {
            Int64 iReturn = -1;
            Lookup oLookup = SQL.GetLookupByValue(tsValue);
            if (oLookup != null) {
                iReturn = oLookup.Oid;
            }
            return iReturn;
        }

        #endregion (GetOid)
        public Int64 GetLookupDefinitionOidByLookupName(string tsLookupName, bool tbThrowException = false) {
            Int64 iReturn = -1;
            LookupDefinition oDef = GetLookupDefinitionByLookupName(tsLookupName);
            if (oDef != null) {
                iReturn = oDef.Oid;
            }
            return iReturn;
        }
        #endregion (Get Methods)

        public void On_LookupValuesHaveBeenUpdated() {

        }
        #endregion (Methods)

        #region Properties
        public static LookupManager Instance {
            get {
                if (_instance == null) {
                    lock (_syncRoot) {
                        _instance = new LookupManager();
                        _instance.Refresh();
                    }
                }
                return _instance;
            }
        }

        public bool LookupValuesHaveBeenUpdated {
            get { return _lookupValuesHaveBeenUpdated; }
            set {
                if (_lookupValuesHaveBeenUpdated == value) {
                    _lookupValuesHaveBeenUpdated = value;
                    On_LookupValuesHaveBeenUpdated();
                }
            }
        }
        #endregion (Properties)

    }
}
