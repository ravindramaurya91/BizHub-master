using CommonUtil;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class TextGroupDTO: TextGroup, IImageHierarchy {
        #region Enums
        public enum eGroupLevel { CompanyLevel, IndividualUserLevel}
        #endregion (Enums)

        #region Fields
        private List<IImageHierarchy> _children = new List<IImageHierarchy>();
        private List<IImageHierarchy> _channels = new List<IImageHierarchy>();
        private IImageHierarchy _parent = null;
        private bool _isSelected = false;
        #endregion (Fields)

        public TextGroupDTO() {
        }

        #region Methods
         
        public void LoadChannels(Int64 tiEntityOid) {
            _channels = new List<IImageHierarchy>();
            List<TextChannelDTO> oList = SQL.GetTextChannelsByTextGroupOidAndEntityOid(this.Oid, tiEntityOid);
            foreach (TextChannelDTO oItem in oList) {
                _channels.Add((IImageHierarchy)oItem);
            }
        }

        public static List<TextGroupDTO> RollUp(List<TextGroupDTO> toList) {
            TextGroupDTO oParent = null;
            List<TextGroupDTO> oReturn = new List<TextGroupDTO>();
            foreach (TextGroupDTO oTxtGrp in toList) {
                oTxtGrp.Value = oTxtGrp.Name;

                if (oTxtGrp.ParentOid != null) {
                    oParent = ModelUtil.GetFromListByOid<TextGroupDTO>((Int64)oTxtGrp.ParentOid, oReturn);
                    if(oParent != null) {
                        oTxtGrp.Parent = oParent;
                        oParent.ChildrenLoaded = true;
                        oParent.Children.Add(oTxtGrp);
                    } else {
                        oReturn.Add(oTxtGrp);
                    }
                } else {
                    oReturn.Add(oTxtGrp);
                }
            }
            return oReturn;
        }
        #endregion (Methods)

        #region Properties
        [Ignore]
        public bool IsSelected { get=>_isSelected; set=> _isSelected = value; }
        [Ignore]
        public string Value { get; set; }
        [Ignore]
        public IImageHierarchy Parent {
            get { return _parent; }
            set { _parent = value; }
        }
        [Ignore]
        public List<IImageHierarchy> Children {
            get { return _children; }
            set { _children = value; }
        }
        public List<IImageHierarchy> Channels {
            get { return _channels; }
            set { _channels = value; }
        }
        [Ignore]
        public string Avatar { get; set; } = "";
        [Ignore]
        public DateTime Date { get; set; }
        [Ignore]
        public bool ChildrenLoaded { get; set; } = false;
        #endregion (Properties)
    }
}
