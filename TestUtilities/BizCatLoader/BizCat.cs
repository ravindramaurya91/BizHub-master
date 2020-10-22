using System;
using System.Collections.Generic;
using System.Text;

using Base;
using Model;

namespace TestUtilities {
    public class BizCat : IModel {

        #region Fields
        private string _lookupName = "BusinessCategory";
        private BizCat _parent = null;
        private List<BizCat> _children = new List<BizCat>();
        #endregion (Fields)

        #region Constructor
        public BizCat(string tsName) {
            Initiate(tsName, null);
        }
        public BizCat(string tsName, BizCat toParent) {
            Initiate(tsName, toParent);
        }
        private void Initiate(string tsName, BizCat toParent) {
            Name = tsName.Trim();
            if (toParent == null) {
                Constant = _lookupName.ToUpper()+"->" + Name.ToUpper().Replace(" ", "");
                Level = 0;
            } else {
                Constant = toParent.Constant + "->" + Name.ToUpper().Replace(" ", "");
                Level = toParent.Level + 1;
                Parent = toParent;
                toParent.Children.Add(this);
            }
        }
        #endregion (Constructor)

        public BizCat Add(string tsName) {
            BizCat oChild = new BizCat(tsName);
            oChild.Level = this.Level + 1;
            oChild.Constant = this.Constant + "->" + tsName.ToUpper();
            _children.Add(oChild);
            oChild.Parent = this;
            return oChild;
        }
        public void Save(Int64 tiLookupDefinitionOid, bool tbUpdate) {
            Lookup oLookup = LookupManager.Instance.GetLookupByConstantValue(this.Constant);
            if ((oLookup == null) || (tbUpdate)) {
                if (oLookup == null) {
                    oLookup = new Lookup() {
                        ConstantValue = Constant, Description = Name, IsActive = true,
                        LookupDefinitionOid = tiLookupDefinitionOid, LookupName = _lookupName,
                        MetaData = "", SortOrder = Level, UDF1 = Level.ToString(),
                        UDF2 = "", UDF3 = "", UDF4 = "", Value = Name
                    };
                } else {
                    if (tbUpdate) {
                        oLookup.ConstantValue = Constant;
                        oLookup.Description = Name;
                        oLookup.IsActive = true;
                        oLookup.LookupDefinitionOid = tiLookupDefinitionOid;
                        oLookup.LookupName = "BusinessCategory";
                        oLookup.MetaData = "";
                        oLookup.SortOrder = Level;
                        oLookup.UDF1 = Level.ToString();
                        oLookup.UDF2 = "";
                        oLookup.UDF3 = "";
                        oLookup.UDF4 = "";
                        oLookup.Value = Name;
                    }


                }
                if(Parent == null) {
                    oLookup.ParentOid = null;
                }else {
                    oLookup.ParentOid = Parent.Oid;
                }
             
                oLookup.Save();
                Oid = oLookup.Oid;

                foreach (BizCat oChild in Children) {
                    oChild.Save(tiLookupDefinitionOid, tbUpdate);
                }
            }
        }

        public int GetCount() {
            int iReturn = 0;
            foreach (BizCat oCat in _children) {
                iReturn += oCat.GetCount();
            }
            return iReturn+Children.Count;
        }
        #region Properties
        public Int64 Oid { get; set; }
        public string Name { get; set; }
        public string Constant { get; set; }
        public int Level { get; set; }

        private BizCat Parent { get => _parent; set => _parent = value; }
        private List<BizCat> Children { get => _children; set => _children = value; }
        #endregion (Properties)

    }
}
